using HtmlAttr = System.Web.UI.HtmlTextWriterAttribute;
using HtmlTag = System.Web.UI.HtmlTextWriterTag;
using Server.Accounting;
using Server.Engines.Help;
using Server.Engines;
using Server.Items;
using Server.Mobiles;
using Server.Network;
using Server;
using System.Collections.Generic;
using System.Collections;
using System.Diagnostics;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.Drawing;
using System.IO;
using System.Net;
using System.Threading;
using System.Web.UI;
using System.Web;
using System.Xml;
using System;

namespace Server.Engines.Reports
{
	public class Reports
	{
		public static bool Enabled = false;

		public static void Initialize()
		{
			if ( !Enabled )
				return;

			m_StatsHistory = new SnapshotHistory();
			m_StatsHistory.Load();

			m_StaffHistory = new StaffHistory();
			m_StaffHistory.Load();

			DateTime now = DateTime.Now;

			DateTime date = now.Date;
			TimeSpan timeOfDay = now.TimeOfDay;

			m_GenerateTime = date + TimeSpan.FromHours( Math.Ceiling( timeOfDay.TotalHours ) );

			Timer.DelayCall( TimeSpan.FromMinutes( 0.5 ), TimeSpan.FromMinutes( 0.5 ), new TimerCallback( CheckRegenerate ) );
		}

		private static DateTime m_GenerateTime;

		public static void CheckRegenerate()
		{
			if ( DateTime.Now < m_GenerateTime )
				return;

			Generate();
			m_GenerateTime += TimeSpan.FromHours( 1.0 );
		}

		private static SnapshotHistory m_StatsHistory;
		private static StaffHistory m_StaffHistory;

		public static StaffHistory StaffHistory{ get{ return m_StaffHistory; } }

		public static void Generate()
		{
			Snapshot ss = new Snapshot();

			ss.TimeStamp = DateTime.Now;

			FillSnapshot( ss );

			m_StatsHistory.Snapshots.Add( ss );
			m_StaffHistory.QueueStats.Add( new QueueStatus( Engines.Help.PageQueue.List.Count ) );

			ThreadPool.QueueUserWorkItem( new WaitCallback( UpdateOutput ), ss );
		}

		private static void UpdateOutput( object state )
		{
			m_StatsHistory.Save();
			m_StaffHistory.Save();

			HtmlRenderer renderer = new HtmlRenderer( "stats", (Snapshot) state, m_StatsHistory );
			renderer.Render();
			renderer.Upload();

			renderer = new HtmlRenderer( "staff", m_StaffHistory );
			renderer.Render();
			renderer.Upload();
		}

		public static void FillSnapshot( Snapshot ss )
		{
			ss.Children.Add( CompileGeneralStats() );
			ss.Children.Add( CompileStatChart() );

			PersistableObject[] obs = CompileSkillReports();

			for ( int i = 0; i < obs.Length; ++i )
				ss.Children.Add( obs[i] );

			for ( int i = 0; i < obs.Length; ++i )
				ss.Children.Add( obs[i] );
		}

		public static Report CompileGeneralStats()
		{
			Report report = new Report( "General Stats", "200" );

			report.Columns.Add( "50%", "left" );
			report.Columns.Add( "50%", "left" );

			int npcs = 0, players = 0;

			foreach ( Mobile mob in World.Mobiles.Values )
			{
				if ( mob.Player )
					++players;
				else
					++npcs;
			}

			report.Items.Add( "NPCs", npcs, "N0" );
			report.Items.Add( "Players", players, "N0" );
			report.Items.Add( "Clients", NetState.Instances.Count, "N0" );
			report.Items.Add( "Accounts", Accounts.Count, "N0" );
			report.Items.Add( "Items", World.Items.Count, "N0" );

			return report;
		}

		public static Chart CompileStatChart()
		{
			PieChart chart = new PieChart( "Stat Distribution", "graphs_strdexint_distrib", true );

			ChartItem strItem = new ChartItem( "Strength", 0 );
			ChartItem dexItem = new ChartItem( "Dexterity", 0 );
			ChartItem intItem = new ChartItem( "Intelligence", 0 );

			foreach ( Mobile mob in World.Mobiles.Values )
			{
				if ( mob.RawStatTotal == mob.StatCap && mob is PlayerMobile )
				{
					strItem.Value += mob.RawStr;
					dexItem.Value += mob.RawDex;
					intItem.Value += mob.RawInt;
				}
			}

			chart.Items.Add( strItem );
			chart.Items.Add( dexItem );
			chart.Items.Add( intItem );

			return chart;
		}

		public class SkillDistribution : IComparable
		{
			public SkillInfo m_Skill;
			public int m_NumberOfGMs;

			public SkillDistribution( SkillInfo skill )
			{
				m_Skill = skill;
			}

			public int CompareTo( object obj )
			{
				return ( ((SkillDistribution)obj).m_NumberOfGMs - m_NumberOfGMs );
			}
		}

		public static SkillDistribution[] GetSkillDistribution()
		{
			int skip = ( Core.ML ? 0 : Core.SE ? 1 : Core.AOS ? 3 : 6 );

			SkillDistribution[] distribs = new SkillDistribution[SkillInfo.Table.Length - skip];

			for ( int i = 0; i < distribs.Length; ++i )
				distribs[i] = new SkillDistribution( SkillInfo.Table[i] );

			foreach ( Mobile mob in World.Mobiles.Values )
			{
				if ( mob.SkillsTotal >= 1500 && mob.SkillsTotal <= 7200 && mob is PlayerMobile )
				{
					Skills skills = mob.Skills;

					for ( int i = 0; i < skills.Length - skip; ++i )
					{
						Skill skill = skills[i];

						if ( skill.BaseFixedPoint >= 1000 )
							distribs[i].m_NumberOfGMs++;
					}
				}
			}

			return distribs;
		}

		public static PersistableObject[] CompileSkillReports()
		{
			SkillDistribution[] distribs = GetSkillDistribution();

			Array.Sort( distribs );

			return new PersistableObject[]{ CompileSkillChart( distribs ), CompileSkillReport( distribs ) };
		}

		public static Report CompileSkillReport( SkillDistribution[] distribs )
		{
			Report report = new Report( "Skill Report", "300" );

			report.Columns.Add( "70%", "left", "Name" );
			report.Columns.Add( "30%", "center", "GMs" );

			for ( int i = 0; i < distribs.Length; ++i )
				report.Items.Add( distribs[i].m_Skill.Name, distribs[i].m_NumberOfGMs, "N0" );

			return report;
		}

		public static Chart CompileSkillChart( SkillDistribution[] distribs )
		{
			PieChart chart = new PieChart( "GM Skill Distribution", "graphs_skill_distrib", true );

			for ( int i = 0; i < 12; ++i )
				chart.Items.Add( distribs[i].m_Skill.Name, distribs[i].m_NumberOfGMs );

			int rem = 0;

			for ( int i = 12; i < distribs.Length; ++i )
				rem += distribs[i].m_NumberOfGMs;

			chart.Items.Add( "Other", rem );

			return chart;
		}
	}
}

namespace Server.Engines.Reports
{
	// Modified from MS sample

	//*********************************************************************
	//
	// BarGraph Class
	//
	// This class uses GDI+ to render Bar Chart.
	//
	//*********************************************************************

	public class BarRegion
	{
		public int m_RangeFrom, m_RangeTo;
		public string m_Name;

		public BarRegion( int rangeFrom, int rangeTo, string name )
		{
			m_RangeFrom = rangeFrom;
			m_RangeTo = rangeTo;
			m_Name = name;
		}
	}

	public class BarGraphRenderer : ChartRenderer
	{
		private const float _graphLegendSpacer = 15F;
		private const float	_labelFontSize = 7f;
		private const int	_legendFontSize = 9;
		private const float _legendRectangleSize = 10F;
		private const float _spacer = 5F;

		public BarRegion[] _regions;

		private BarGraphRenderMode _renderMode;

		// Overall related members
		private Color	_backColor;
		private string	_fontFamily;
		private string	_longestTickValue = string.Empty;	// Used to calculate max value width
		private float	_maxTickValueWidth;					// Used to calculate left offset of bar graph
		private float	_totalHeight;
		private float	_totalWidth;
		
		// Graph related members
		private float	_barWidth;
		private float	_bottomBuffer;	// Space from bottom to x axis
		private bool	_displayBarData;	
		private Color	_fontColor;
		private float	_graphHeight;		
		private float	_graphWidth;
		private float	_maxValue = 0.0f;	// = final tick value * tick count
		private float	_scaleFactor;		// = _maxValue / _graphHeight
		private float	_spaceBtwBars;	// For now same as _barWidth
		private float	_topBuffer;		// Space from top to the top of y axis
		private float	_xOrigin;			// x position where graph starts drawing
		private float	_yOrigin;			// y position where graph starts drawing
		private string	_yLabel;
		private int		_yTickCount;
		private float	_yTickValue;		// Value for each tick = _maxValue/_yTickCount

		// Legend related members
		private bool	_displayLegend;
		private float	_legendWidth;
		private string	_longestLabel = string.Empty;	// Used to calculate legend width
		private float	_maxLabelWidth = 0.0f;

		public string FontFamily 
		{
			get{ return _fontFamily; }
			set{ _fontFamily = value; }
		}

		public BarGraphRenderMode RenderMode
		{
			get{ return _renderMode; }
			set{ _renderMode = value; }
		}

		public Color BackgroundColor 
		{
			set{ _backColor = value; }
		}

		public int BottomBuffer 
		{
			set { _bottomBuffer = Convert.ToSingle(value); }
		}

		public Color FontColor 
		{
			set{ _fontColor = value; }
		}

		public int Height 
		{
			get{ return Convert.ToInt32(_totalHeight); }
			set{ _totalHeight = Convert.ToSingle(value); }  
		}

		public int Width 
		{
			get{ return Convert.ToInt32(_totalWidth); }
			set{ _totalWidth = Convert.ToSingle(value); }	
		}

		public bool ShowLegend 
		{
			get{ return _displayLegend; }
			set{ _displayLegend = value; }
		}

		public bool ShowData 
		{
			get{ return _displayBarData; }
			set{ _displayBarData = value; }
		}
		public int TopBuffer 
		{
			set { _topBuffer = Convert.ToSingle(value); }
		}

		public string VerticalLabel 
		{
			get{ return _yLabel; }
			set{ _yLabel = value; }
		}

		public int VerticalTickCount 
		{
			get{ return _yTickCount; }
			set{ _yTickCount = value; }
		}

		private string _xTitle, _yTitle;

		public void SetTitles( string xTitle, string yTitle )
		{
			_xTitle = xTitle;
			_yTitle = yTitle;
		}

		public BarGraphRenderer()
		{
			AssignDefaultSettings();
		}

		public BarGraphRenderer(Color bgColor)
		{
			AssignDefaultSettings();
			BackgroundColor = bgColor;
		}

		//*********************************************************************
		//
		// This method collects all data points and calculate all the necessary dimensions 
		// to draw the bar graph.  It is the method called before invoking the Draw() method.
		// labels is the x values.
		// values is the y values.
		//
		//*********************************************************************

		public void CollectDataPoints(string[] labels, string[] values)
		{
			if (labels.Length == values.Length) 
			{
				for(int i=0; i<labels.Length; i++)
				{
					float temp = Convert.ToSingle(values[i]);
					string shortLbl = MakeShortLabel(labels[i]);

					// For now put 0.0 for start position and sweep size
					DataPoints.Add(new DataItem(shortLbl, labels[i], temp, 0.0f, 0.0f, GetColor(i)));
				
					// Find max value from data; this is only temporary _maxValue
					if (_maxValue < temp) _maxValue = temp;

					// Find the longest description
					if (_displayLegend) 
					{
						string currentLbl = labels[i] + " (" + shortLbl + ")";
						float currentWidth = CalculateImgFontWidth(currentLbl, _legendFontSize, FontFamily);
						if(_maxLabelWidth < currentWidth)
						{
							_longestLabel = currentLbl;
							_maxLabelWidth = currentWidth;
						}
					}
				}

				CalculateTickAndMax();
				CalculateGraphDimension();
				CalculateBarWidth(DataPoints.Count, _graphWidth);
				CalculateSweepValues();
			}
			else
				throw new Exception("X data count is different from Y data count");
		}
		
		//*********************************************************************
		//
		// Same as above; called when user doesn't care about the x values
		//
		//*********************************************************************

		public void CollectDataPoints(string[] values)
		{
			string[] labels = values;
			CollectDataPoints(labels, values);
		}

		public void DrawRegions( Graphics gfx )
		{
			if ( _regions == null )
				return;

			using ( StringFormat textFormat = new StringFormat() )
			{
				textFormat.Alignment = StringAlignment.Center;
				textFormat.LineAlignment = StringAlignment.Center;

				using ( Font font = new Font( _fontFamily, _labelFontSize ) )
				{
					using ( Brush textBrush = new SolidBrush( _fontColor ) )
					{
						using ( Pen solidPen = new Pen( _fontColor ) )
						{
							using ( Pen lightPen = new Pen( Color.FromArgb( 128, _fontColor ) ) )
							{
								float labelWidth = _barWidth + _spaceBtwBars;

								for ( int i = 0; i < _regions.Length; ++i )
								{
									BarRegion reg = _regions[i];

									RectangleF rc = new RectangleF( _xOrigin + (reg.m_RangeFrom * labelWidth), _yOrigin, (reg.m_RangeTo - reg.m_RangeFrom + 1) * labelWidth, _graphHeight );

									if ( rc.X+rc.Width > _xOrigin+_graphWidth )
										rc.Width = _xOrigin+_graphWidth-rc.X;

									using ( SolidBrush brsh = new SolidBrush( Color.FromArgb( 48, GetColor( i ) ) ) )
										gfx.FillRectangle( brsh, rc );

									rc.Offset( (rc.Width - 200.0f) * 0.5f, -16.0f );
									rc.Width = 200.0f;
									rc.Height = 20.0f;

									gfx.DrawString( reg.m_Name, font, textBrush, rc, textFormat );
								}
							}
						}
					}
				}
			}
		}

		//*********************************************************************
		//
		// This method returns a bar graph bitmap to the calling function.  It is called after 
		// all dimensions and data points are calculated.
		//
		//*********************************************************************

		public override Bitmap Draw()
		{
			int height = Convert.ToInt32(_totalHeight);
			int width = Convert.ToInt32(_totalWidth);

			Bitmap bmp = new Bitmap(width, height);
			
			using(Graphics graph = Graphics.FromImage(bmp))
			{
				graph.CompositingQuality = CompositingQuality.HighQuality;
				graph.SmoothingMode = SmoothingMode.AntiAlias;

				using ( SolidBrush brsh = new SolidBrush( _backColor ) )
					graph.FillRectangle(brsh, -1, -1, bmp.Width+1, bmp.Height+1);

				DrawRegions(graph);
				DrawVerticalLabelArea(graph);
				DrawXLabelBack(graph);
				DrawBars(graph);
				DrawXLabelArea(graph);

				if (_displayLegend)
					DrawLegend(graph);
			}

			return bmp;
		}

		//*********************************************************************
		//
		// This method draws all the bars for the graph.
		//
		//*********************************************************************

		public int _interval;

		private void DrawBars(Graphics graph)
		{
			SolidBrush brsFont = null;
			Font valFont = null;
			StringFormat sfFormat = null;

			try 
			{
				brsFont = new SolidBrush(_fontColor);
				valFont = new Font(_fontFamily, _labelFontSize);
				sfFormat = new StringFormat();
				sfFormat.Alignment = StringAlignment.Center;
				int i = 0;

				PointF[] linePoints = null;

				if ( _renderMode == BarGraphRenderMode.Lines )
					linePoints = new PointF[DataPoints.Count];

				int pointIndex = 0;

				// Draw bars and the value above each bar
				using ( Pen pen = new Pen(_fontColor,0.15f) )
				{
					using ( SolidBrush whiteBrsh = new SolidBrush( Color.FromArgb( 128, Color.White ) ) )
					{
						foreach(DataItem item in DataPoints)
						{
							using(SolidBrush barBrush = new SolidBrush(item.ItemColor))
							{
								float itemY = _yOrigin + _graphHeight - item.SweepSize;

								if ( _renderMode == BarGraphRenderMode.Lines )
								{
									linePoints[pointIndex++] = new PointF( _xOrigin + item.StartPos + (_barWidth / 2), itemY );
								}
								else if ( _renderMode == BarGraphRenderMode.Bars )
								{
									float ox = _xOrigin + item.StartPos;
									float oy = itemY;
									float ow = _barWidth;
									float oh = item.SweepSize;
									float of = 9.5f;

									PointF[] pts = new PointF[]
									{
										new PointF( ox, oy ),
										new PointF( ox + ow, oy ),
										new PointF( ox + of, oy + of ),
										new PointF( ox + of + ow, oy + of ),
										new PointF( ox, oy + oh ),
										new PointF( ox + of, oy + of + oh ),
										new PointF( ox + of + ow, oy + of + oh )
									};

									graph.FillPolygon( barBrush, new PointF[]{ pts[2], pts[3], pts[6], pts[5] } );

									using ( SolidBrush ltBrsh = new SolidBrush( System.Windows.Forms.ControlPaint.Light(item.ItemColor,0.1f) ) )
										graph.FillPolygon( ltBrsh, new PointF[]{ pts[0], pts[2], pts[5], pts[4] } );

									using ( SolidBrush drkBrush = new SolidBrush( System.Windows.Forms.ControlPaint.Dark(item.ItemColor,0.05f) ) )
										graph.FillPolygon( drkBrush, new PointF[]{ pts[0], pts[1], pts[3], pts[2] } );

									graph.DrawLine( pen, pts[0], pts[1] );
									graph.DrawLine( pen, pts[0], pts[2] );
									graph.DrawLine( pen, pts[1], pts[3] );
									graph.DrawLine( pen, pts[2], pts[3] );
									graph.DrawLine( pen, pts[2], pts[5] );
									graph.DrawLine( pen, pts[0], pts[4] );
									graph.DrawLine( pen, pts[4], pts[5] );
									graph.DrawLine( pen, pts[5], pts[6] );
									graph.DrawLine( pen, pts[3], pts[6] );

									// Draw data value
									if (_displayBarData&&(i%_interval)==0)
									{
										float sectionWidth = ( _barWidth + _spaceBtwBars );
										float startX = _xOrigin + (i * sectionWidth) + (sectionWidth / 2);  // This draws the value on center of the bar
										float startY = itemY - 2f - valFont.Height;					  // Positioned on top of each bar by 2 pixels
										RectangleF recVal = new RectangleF(startX-((sectionWidth * _interval) / 2), startY, sectionWidth * _interval, valFont.Height);
										SizeF sz = graph.MeasureString(item.Value.ToString("#,###.##"),valFont,recVal.Size,sfFormat);
										//using ( SolidBrush brsh = new SolidBrush( Color.FromArgb( 180, 255, 255, 255 ) ) )
										//	graph.FillRectangle( brsh, new RectangleF(recVal.X+((recVal.Width-sz.Width)/2),recVal.Y+((recVal.Height-sz.Height)/2),sz.Width+4,sz.Height) );

										//graph.DrawString(item.Value.ToString("#,###.##"), valFont, brsFont, recVal, sfFormat);

										for ( int box = -1; box <= 1; ++box )
										{
											for ( int boy = -1; boy <= 1; ++boy )
											{
												if ( box == 0 && boy == 0 )
													continue;

												RectangleF rco = new RectangleF( recVal.X+box, recVal.Y+boy, recVal.Width, recVal.Height );
												graph.DrawString(item.Value.ToString("#,###.##"), valFont, whiteBrsh, rco, sfFormat);
											}
										}

										graph.DrawString(item.Value.ToString("#,###.##"), valFont, brsFont, recVal, sfFormat);	
									}
								}

								i++;
							}
						}

						if ( _renderMode == BarGraphRenderMode.Lines )
						{
							if ( linePoints.Length >= 2 )
							{
								using ( Pen linePen = new Pen( Color.FromArgb(220,Color.Red), 2.5f ) )
									graph.DrawCurve( linePen, linePoints, 0.5f );
							}

							using ( Pen linePen = new Pen( Color.FromArgb(40,_fontColor), 0.8f ) )
							{
								for ( int j = 0; j < linePoints.Length; ++j )
								{
									graph.DrawLine( linePen, linePoints[j], new PointF( linePoints[j].X, _yOrigin + _graphHeight ) );

									DataItem item = DataPoints[j];
									float itemY = _yOrigin + _graphHeight - item.SweepSize;

									// Draw data value
									if (_displayBarData&&(j%_interval)==0)
									{
										graph.FillEllipse( brsFont, new RectangleF( linePoints[j].X-2.0f, linePoints[j].Y-2.0f, 4.0f, 4.0f ) );

										float sectionWidth = ( _barWidth + _spaceBtwBars );
										float startX = _xOrigin + (j * sectionWidth) + (sectionWidth/2);  // This draws the value on center of the bar
										float startY = itemY - 2f - valFont.Height;					  // Positioned on top of each bar by 2 pixels
										RectangleF recVal = new RectangleF(startX-((sectionWidth * _interval) / 2), startY, sectionWidth * _interval, valFont.Height);
										SizeF sz = graph.MeasureString(item.Value.ToString("#,###.##"),valFont,recVal.Size,sfFormat);
										//using ( SolidBrush brsh = new SolidBrush( Color.FromArgb( 48, 255, 255, 255 ) ) )
										//	graph.FillRectangle( brsh, new RectangleF(recVal.X+((recVal.Width-sz.Width)/2),recVal.Y+((recVal.Height-sz.Height)/2),sz.Width+4,sz.Height) );

										for ( int box = -1; box <= 1; ++box )
										{
											for ( int boy = -1; boy <= 1; ++boy )
											{
												if ( box == 0 && boy == 0 )
													continue;

												RectangleF rco = new RectangleF( recVal.X+box, recVal.Y+boy, recVal.Width, recVal.Height );
												graph.DrawString(item.Value.ToString("#,###.##"), valFont, whiteBrsh, rco, sfFormat);
											}
										}

										graph.DrawString(item.Value.ToString("#,###.##"), valFont, brsFont, recVal, sfFormat);	
									}
								}
							}
						}
					}
				}
			}
			finally 
			{
				if (brsFont != null) brsFont.Dispose();
				if (valFont != null) valFont.Dispose();
				if (sfFormat != null) sfFormat.Dispose();
			}
		}

		//*********************************************************************
		//
		// This method draws the y label, tick marks, tick values, and the y axis.
		//
		//*********************************************************************

		private void DrawVerticalLabelArea(Graphics graph)
		{
			Font lblFont = null;
			SolidBrush brs = null;
			StringFormat lblFormat = null;
			Pen pen = null;
			StringFormat sfVLabel = null;

			float fo = (_yTitle==null?0.0f:20.0f);
			
			try
			{
				brs = new SolidBrush(_fontColor);
				lblFormat = new StringFormat();
				pen = new Pen(_fontColor);

				if ( _yTitle != null )
				{
					sfVLabel = new StringFormat();
					sfVLabel.Alignment = StringAlignment.Center;
					sfVLabel.LineAlignment = StringAlignment.Center;
					sfVLabel.FormatFlags=StringFormatFlags.DirectionVertical;

					lblFont = new Font(_fontFamily, _labelFontSize+4.0f);
					graph.DrawString(_yTitle,lblFont,brs,new RectangleF( 0.0f, _yOrigin, 20.0f, _graphHeight ), sfVLabel );
					lblFont.Dispose();
				}

				sfVLabel = new StringFormat();
				lblFormat.Alignment = StringAlignment.Far;
				lblFormat.FormatFlags|=StringFormatFlags.NoClip;

				// Draw vertical label at the top of y-axis and place it in the middle top of y-axis
				lblFont = new Font(_fontFamily, _labelFontSize+2.0f,FontStyle.Bold);
				RectangleF recVLabel = new RectangleF(0, _yOrigin-2*_spacer-lblFont.Height, _xOrigin*2, lblFont.Height);
				sfVLabel.Alignment = StringAlignment.Center;
				sfVLabel.FormatFlags|=StringFormatFlags.NoClip;
				//graph.DrawRectangle(Pens.Black,Rectangle.Truncate(recVLabel));
				graph.DrawString(_yLabel, lblFont, brs, recVLabel, sfVLabel);
				lblFont.Dispose();

				lblFont = new Font(_fontFamily, _labelFontSize);
				// Draw all tick values and tick marks
				using ( Pen smallPen = new Pen(Color.FromArgb(96,_fontColor),0.8f) )
				{
					for (int i=0; i<_yTickCount; i++)
					{
						float currentY = _topBuffer + (i * _yTickValue/_scaleFactor);	// Position for tick mark
						float labelY = currentY-lblFont.Height/2;						// Place label in the middle of tick
						RectangleF lblRec = new RectangleF(_spacer+fo-6, labelY, _maxTickValueWidth, lblFont.Height);
				
						float currentTick = _maxValue - i*_yTickValue;					// Calculate tick value from top to bottom
						graph.DrawString(currentTick.ToString("#,###.##"), lblFont, brs, lblRec, lblFormat);	// Draw tick value  
						graph.DrawLine(pen, _xOrigin, currentY, _xOrigin - 4.0f, currentY);						// Draw tick mark

						graph.DrawLine(smallPen, _xOrigin, currentY, _xOrigin + _graphWidth, currentY );
					}
				}

				// Draw y axis
				graph.DrawLine(pen, _xOrigin, _yOrigin, _xOrigin, _yOrigin + _graphHeight);
			}
			finally
			{
				if (lblFont != null) lblFont.Dispose();
				if (brs != null) brs.Dispose();
				if (lblFormat != null) lblFormat.Dispose();
				if (pen != null) pen.Dispose();
				if (sfVLabel != null) sfVLabel.Dispose();
			}
		}

		//*********************************************************************
		//
		// This method draws x axis and all x labels
		//
		//*********************************************************************

		private void DrawXLabelBack(Graphics graph)
		{
			Font lblFont = null;
			SolidBrush brs = null;
			StringFormat lblFormat = null;
			Pen pen = null;

			try
			{
				lblFont = new Font(_fontFamily, _labelFontSize);
				brs = new SolidBrush(_fontColor);
				lblFormat = new StringFormat();
				pen = new Pen(_fontColor);

				lblFormat.Alignment = StringAlignment.Center;

				// Draw x axis
				graph.DrawLine(pen, _xOrigin, _yOrigin + _graphHeight, _xOrigin + _graphWidth, _yOrigin + _graphHeight );
			}
			finally
			{
				if (lblFont != null) lblFont.Dispose();
				if (brs != null) brs.Dispose();
				if (lblFormat != null) lblFormat.Dispose();
				if (pen != null) pen.Dispose();
			}
		}

		private void DrawXLabelArea(Graphics graph)
		{
			Font lblFont = null;
			SolidBrush brs = null;
			StringFormat lblFormat = null;
			Pen pen = null;

			try
			{
				brs = new SolidBrush(_fontColor);
				pen = new Pen(_fontColor);

				if ( _xTitle != null )
				{
					lblFormat = new StringFormat();
					lblFormat.Alignment = StringAlignment.Center;
					lblFormat.LineAlignment = StringAlignment.Center;
					//					sfVLabel.FormatFlags=StringFormatFlags.DirectionVertical;

					lblFont = new Font(_fontFamily, _labelFontSize+2.0f, FontStyle.Bold);
					graph.DrawString(_xTitle,lblFont,brs,new RectangleF( _xOrigin, _yOrigin+_graphHeight+14.0f+(_renderMode==BarGraphRenderMode.Bars?10.0f:0.0f)+((DataPoints.Count/_interval)>24?16.0f:0.0f), _graphWidth, 20.0f ), lblFormat );
				}

				lblFont = new Font(_fontFamily, _labelFontSize);
				lblFormat = new StringFormat();
				lblFormat.Alignment = StringAlignment.Center;
				lblFormat.FormatFlags |= StringFormatFlags.NoClip;
				lblFormat.Trimming = StringTrimming.None;
				//lblFormat.FormatFlags |= StringFormatFlags.NoWrap;

				float of = 0.0f;

				if ( _renderMode == BarGraphRenderMode.Bars )
				{
					of = 10.0f;

					// Draw x axis
					graph.DrawLine( pen, _xOrigin + of, _yOrigin + _graphHeight + of, _xOrigin + _graphWidth + of, _yOrigin + _graphHeight + of );

					graph.DrawLine( pen, _xOrigin, _yOrigin + _graphHeight, _xOrigin + of, _yOrigin + _graphHeight + of );
					graph.DrawLine( pen, _xOrigin + _graphWidth, _yOrigin + _graphHeight, _xOrigin + of + _graphWidth, _yOrigin + _graphHeight + of );
				}

				float currentX;
				float currentY = _yOrigin + _graphHeight + 2.0f;	// All x labels are drawn 2 pixels below x-axis
				float labelWidth = _barWidth + _spaceBtwBars;		// Fits exactly below the bar
				int i = 0;

				// Draw x labels
				foreach(DataItem item in DataPoints)
				{
					if((i%_interval)==0)
					{
						currentX = _xOrigin + (i * labelWidth)+of+(labelWidth/2);
						RectangleF recLbl = new RectangleF(currentX-((labelWidth*_interval)/2), currentY+of, labelWidth*_interval, lblFont.Height*2);
						string lblString = _displayLegend ? item.Label : item.Description;	// Decide what to show: short or long

						graph.DrawString(lblString, lblFont, brs, recLbl, lblFormat);
					}
					i++;
				}
			}
			finally
			{
				if (lblFont != null) lblFont.Dispose();
				if (brs != null) brs.Dispose();
				if (lblFormat != null) lblFormat.Dispose();
				if (pen != null) pen.Dispose();
			}
		}

		//*********************************************************************
		//
		// This method determines where to place the legend box.
		// It draws the legend border, legend description, and legend color code.
		//
		//*********************************************************************

		private void DrawLegend(Graphics graph)
		{
			Font lblFont = null;
			SolidBrush brs = null;
			StringFormat lblFormat = null;
			Pen pen = null;

			try
			{
				lblFont = new Font(_fontFamily, _legendFontSize);
				brs = new SolidBrush(_fontColor);
				lblFormat = new StringFormat();
				pen = new Pen(_fontColor);
				lblFormat.Alignment = StringAlignment.Near;

				// Calculate Legend drawing start point
				float startX = _xOrigin + _graphWidth + _graphLegendSpacer;
				float startY = _yOrigin;

				float xColorCode = startX + _spacer;
				float xLegendText = xColorCode + _legendRectangleSize + _spacer;
				float legendHeight = 0.0f;
				for(int i=0; i<DataPoints.Count; i++)
				{
					DataItem point = DataPoints[i];
					string text = point.Description + " (" + point.Label + ")";
					float currentY = startY + _spacer + (i * (lblFont.Height + _spacer));
					legendHeight += lblFont.Height + _spacer;

					// Draw legend description
					graph.DrawString(text, lblFont, brs, xLegendText, currentY, lblFormat);

					// Draw color code
					using ( SolidBrush brsh = new SolidBrush(DataPoints[i].ItemColor) )
						graph.FillRectangle(brsh, xColorCode, currentY + 3f, _legendRectangleSize, _legendRectangleSize);
				}

				// Draw legend border
				graph.DrawRectangle(pen, startX, startY, _legendWidth, legendHeight + _spacer);
			}
			finally
			{
				if (lblFont != null) lblFont.Dispose();
				if (brs != null) brs.Dispose();
				if (lblFormat != null) lblFormat.Dispose();
				if (pen != null) pen.Dispose();
			}
		}

		//*********************************************************************
		//
		// This method calculates all measurement aspects of the bar graph from the given data points
		//
		//*********************************************************************

		private void CalculateGraphDimension() 
		{
			FindLongestTickValue();
			
			// Need to add another character for spacing; this is not used for drawing, just for calculation
			_longestTickValue += "0";		
			//_maxTickValueWidth = CalculateImgFontWidth(_longestTickValue, _labelFontSize, FontFamily);
			_maxTickValueWidth = 0.0f;

			float currentTick;
			string tickString;
			for (int i=0; i<_yTickCount; i++)
			{
				currentTick = _maxValue - i*_yTickValue;	
				tickString = currentTick.ToString("#,###.##");

				float measured = CalculateImgFontWidth( tickString, _labelFontSize, FontFamily );

				if ( measured > _maxTickValueWidth )
					_maxTickValueWidth = measured;
			}

			float leftOffset = _spacer + _maxTickValueWidth + (_yTitle == null ? 0.0f : 20.0f);
			float rtOffset = 0.0f;

			if (_displayLegend) 
			{
				_legendWidth = _spacer + _legendRectangleSize + _spacer + _maxLabelWidth + _spacer;
				rtOffset = _graphLegendSpacer + _legendWidth + _spacer;
			}
			else
				rtOffset = _spacer;		// Make graph in the middle

			if ( _renderMode == BarGraphRenderMode.Bars )
				rtOffset += 10.0f;

			rtOffset+=10.0f;

			_graphHeight = _totalHeight - _topBuffer - _bottomBuffer - (_xTitle == null ? 0.0f : 20.0f);	// Buffer spaces are used to print labels
			_graphWidth = _totalWidth - leftOffset - rtOffset;
			_xOrigin = leftOffset;
			_yOrigin = _topBuffer;

			// Once the correct _maxValue is determined, then calculate _scaleFactor
			_scaleFactor = _maxValue / _graphHeight;
		}

		//*********************************************************************
		//
		// This method determines the longest tick value from the given data points.
		// The result is needed to calculate the correct graph dimension.
		//
		//*********************************************************************

		private void FindLongestTickValue()
		{
			float currentTick;
			string tickString;
			for (int i=0; i<_yTickCount; i++)
			{
				currentTick = _maxValue - i*_yTickValue;	
				tickString = currentTick.ToString("#,###.##");
				if (_longestTickValue.Length < tickString.Length)
					_longestTickValue = tickString;
			}
		}

		//*********************************************************************
		//
		// This method calculates the image width in pixel for a given text
		//
		//*********************************************************************

		private float CalculateImgFontWidth(string text, float size, string family)
		{
			Bitmap bmp = null;
			Graphics graph = null;
			Font font = null;

			try
			{
				font = new Font(family, size);

				// Calculate the size of the string.
				bmp = new Bitmap(1,1,PixelFormat.Format32bppArgb);
				graph = Graphics.FromImage(bmp);
				SizeF oSize = graph.MeasureString(text, font);
				oSize.Width=4+(float)Math.Ceiling(oSize.Width);
			
				return oSize.Width;
			}
			finally
			{
				if (graph != null) graph.Dispose();
				if (bmp != null) bmp.Dispose();
				if (font != null) font.Dispose();
			}
		}
		
		//*********************************************************************
		//
		// This method creates abbreviation from long description; used for making legend
		//
		//*********************************************************************

		private string MakeShortLabel(string text)
		{
			string label = text;
			if (text.Length > 2) 
			{
				int midPostition = Convert.ToInt32(Math.Floor(text.Length/2.0));
				label = text.Substring(0,1) + text.Substring(midPostition, 1) + text.Substring(text.Length-1,1);
			}
			return label;
		}

		//*********************************************************************
		//
		// This method calculates the max value and each tick mark value for the bar graph.
		//
		//*********************************************************************

		private void CalculateTickAndMax()
		{
			float tempMax = 0.0f;

			// Give graph some head room first about 10% of current max
			_maxValue *= 1.1f;

			if (_maxValue != 0.0f)
			{
				// Find a rounded value nearest to the current max value
				// Calculate this max first to give enough space to draw value on each bar
				double exp = Convert.ToDouble(Math.Floor(Math.Log10(_maxValue)));
				tempMax = Convert.ToSingle(Math.Ceiling(_maxValue / Math.Pow(10, exp)) * Math.Pow(10, exp));
			}
			else
				tempMax = 1.0f;

			// Once max value is calculated, tick value can be determined; tick value should be a whole number
			_yTickValue = tempMax / _yTickCount;
			double expTick = Convert.ToDouble(Math.Floor(Math.Log10(_yTickValue)));
			_yTickValue = Convert.ToSingle(Math.Ceiling(_yTickValue / Math.Pow(10, expTick)) * Math.Pow(10, expTick));

			// Re-calculate the max value with the new tick value
			_maxValue = _yTickValue * _yTickCount;
		}

		//*********************************************************************
		//
		// This method calculates the height for each bar in the graph
		//
		//*********************************************************************

		private void CalculateSweepValues()
		{
			// Called when all values and scale factor are known
			// All values calculated here are relative from (_xOrigin, _yOrigin)
			int i = 0;
			foreach(DataItem item in DataPoints)
			{
				// This implementation does not support negative value
				if (item.Value >= 0) item.SweepSize = item.Value/_scaleFactor;
				
				// (_spaceBtwBars/2) makes half white space for the first bar
				item.StartPos = (_spaceBtwBars/2) + i * (_barWidth+_spaceBtwBars);
				i++;
			}
		}

		//*********************************************************************
		//
		// This method calculates the width for each bar in the graph
		//
		//*********************************************************************

		private void CalculateBarWidth(int dataCount, float barGraphWidth)
		{
			// White space between each bar is the same as bar width itself
			_barWidth = barGraphWidth / (dataCount * 2);  // Each bar has 1 white space 
			//_barWidth =/* (float)Math.Floor(*/_barWidth/*)*/;
			_spaceBtwBars = _barWidth;
		}

		//*********************************************************************
		//
		// This method assigns default value to the bar graph properties and is only 
		// called from BarGraph constructors
		//
		//*********************************************************************

		private void AssignDefaultSettings()
		{
			// default values
			_totalWidth = 680f;
			_totalHeight = 450f;
			_fontFamily = "Verdana";
			_backColor = Color.White;
			_fontColor = Color.Black;
			_topBuffer = 30f;
			_bottomBuffer = 30f;
			_yTickCount = 2;
			_displayLegend = false;
			_displayBarData = false;
		}
	}
}

namespace Server.Engines.Reports
{
	//*********************************************************************
	//
	// Chart Class
	//
	// Base class implementation for BarChart and PieChart
	//
	//*********************************************************************

	public abstract class ChartRenderer
	{
		private const int _colorLimit = 9;

		private Color[] _color = 
			{ 
				Color.Firebrick,
				Color.SkyBlue,
				Color.MediumSeaGreen,
				Color.MediumOrchid,
				Color.Chocolate,
				Color.SlateBlue,
				Color.LightPink,
				Color.LightGreen,
				Color.Khaki
			};

		// Represent collection of all data points for the chart
		private ChartItemsCollection _dataPoints = new ChartItemsCollection();  

		// The implementation of this method is provided by derived classes
		public abstract Bitmap Draw();	

		public ChartItemsCollection DataPoints
		{
			get{ return _dataPoints; }
			set{ _dataPoints = value; }
		}

		public void SetColor(int index, Color NewColor)
		{
			if (index < _colorLimit) 
			{
				_color[index] = NewColor;
			}
			else
			{
				throw new Exception("Color Limit is " + _colorLimit);
			}
		}

		public Color GetColor(int index)
		{
			//return _color[index%_colorLimit];

			if (index < _colorLimit) 
			{
				return _color[index];
			}
			else
			{
				return _color[(index+2)%_colorLimit];
				//throw new Exception("Color Limit is " + _colorLimit);
			}
		}
	}
}

namespace Server.Engines.Reports
{
	// Modified from MS sample

	//*********************************************************************
	//
	// ChartItem Class
	//
	// This class represents a data point in a chart
	//
	//*********************************************************************

	public class DataItem 
	{
		private string _label;
		private string _description;
		private float _value;
		private Color _color;
		private float _startPos;
		private float _sweepSize;

		private DataItem()	{}
		
		public DataItem(string label, string desc, float data, float start, float sweep, Color clr)
		{
			_label = label;
			_description = desc;
			_value = data;
			_startPos = start;
			_sweepSize = sweep;
			_color = clr;
		}

		public string Label 
		{
			get{ return _label; }
			set{ _label = value; }
		}

		public string Description 
		{
			get{ return _description; }
			set{ _description = value; }
		} 

		public float Value 
		{
			get{ return _value; }
			set{ _value = value; }
		}

		public Color ItemColor 
		{
			get{ return _color; }
			set{ _color = value; }
		}

		public float StartPos
		{
			get{ return _startPos; }
			set{ _startPos = value; }
		}

		public float SweepSize
		{
			get{ return _sweepSize; }
			set{ _sweepSize = value; }
		}
	}

	//*********************************************************************
	//
	// Custom Collection for ChartItems
	//
	//*********************************************************************

	public class ChartItemsCollection : CollectionBase 
	{
		public DataItem this[int index] 
		{
			get{ return (DataItem)(List[index]); }
			set{ List[index] = value; }
		}
 
		public int Add(DataItem value) 
		{
			return List.Add(value);
		}
 
		public int IndexOf(DataItem value) 
		{
			return List.IndexOf(value);
		}
 
		public bool Contains(DataItem value) 
		{
			return List.Contains(value);
		}

		public void Remove(DataItem value) 
		{
			List.Remove(value);
		}
	}
}

namespace Server.Engines.Reports
{
	public class HtmlRenderer
	{
		private string m_Type;
		private string m_Title;
		private string m_OutputDirectory;

		private DateTime m_TimeStamp;
		private ObjectCollection m_Objects;

		private HtmlRenderer( string outputDirectory )
		{
			m_Type = outputDirectory;
			m_Title = ( m_Type == "staff" ? "Staff" : "Stats" );
			m_OutputDirectory = Path.Combine( Core.BaseDirectory, "output" );

			if ( !Directory.Exists( m_OutputDirectory ) )
				Directory.CreateDirectory( m_OutputDirectory );

			m_OutputDirectory = Path.Combine( m_OutputDirectory, outputDirectory );

			if ( !Directory.Exists( m_OutputDirectory ) )
				Directory.CreateDirectory( m_OutputDirectory );
		}

		public HtmlRenderer( string outputDirectory, Snapshot ss, SnapshotHistory history ) : this( outputDirectory )
		{
			m_TimeStamp = ss.TimeStamp;

			m_Objects = new ObjectCollection();

			for ( int i = 0; i < ss.Children.Count; ++i )
				m_Objects.Add( ss.Children[i] );

			m_Objects.Add( BarGraph.OverTime( history, "General Stats", "Clients", 1, 100, 6 ) );
			m_Objects.Add( BarGraph.OverTime( history, "General Stats", "Items", 24, 9, 1  ) );
			m_Objects.Add( BarGraph.OverTime( history, "General Stats", "Players", 24, 9, 1 ) );
			m_Objects.Add( BarGraph.OverTime( history, "General Stats", "NPCs", 24, 9, 1 ) );
			m_Objects.Add( BarGraph.DailyAverage( history, "General Stats", "Clients" ) );
			m_Objects.Add( BarGraph.Growth( history, "General Stats", "Clients" ) );
		}

		public HtmlRenderer( string outputDirectory, StaffHistory history ) : this( outputDirectory )
		{
			m_TimeStamp = DateTime.Now;

			m_Objects = new ObjectCollection();

			history.Render( m_Objects );
		}

		public void Render()
		{
			Console.WriteLine( "Reports: {0}: Render started", m_Title );

			RenderFull();

			for ( int i = 0; i < m_Objects.Count; ++i )
				RenderSingle( m_Objects[i] );

			Console.WriteLine( "Reports: {0}: Render complete", m_Title );
		}

		private static readonly string FtpHost = null;

		private static readonly string FtpUsername = null;
		private static readonly string FtpPassword = null;

		private static readonly string FtpStatsDirectory = null;
		private static readonly string FtpStaffDirectory = null;

		public void Upload()
		{
			if ( FtpHost == null )
				return;

			Console.WriteLine( "Reports: {0}: Upload started", m_Title );

			string filePath = Path.Combine( m_OutputDirectory, "upload.ftp" );

			using ( StreamWriter op = new StreamWriter( filePath ) )
			{
				op.WriteLine( "open \"{0}\"", FtpHost );
				op.WriteLine( FtpUsername );
				op.WriteLine( FtpPassword );
				op.WriteLine( "cd \"{0}\"", ( m_Type == "staff" ? FtpStaffDirectory : FtpStatsDirectory ) );
				op.WriteLine( "mput \"{0}\"", Path.Combine( m_OutputDirectory, "*.html" ) );
				op.WriteLine( "mput \"{0}\"", Path.Combine( m_OutputDirectory, "*.css" ) );
				op.WriteLine( "binary" );
				op.WriteLine( "mput \"{0}\"", Path.Combine( m_OutputDirectory, "*.png" ) );
				op.WriteLine( "disconnect" );
				op.Write( "quit" );
			}

			ProcessStartInfo psi = new ProcessStartInfo();

			psi.FileName = "ftp";
			psi.Arguments = String.Format( "-i -s:\"{0}\"", filePath );

			psi.CreateNoWindow = true;
			psi.WindowStyle = ProcessWindowStyle.Hidden;
			//psi.UseShellExecute = true;

			try
			{
				Process p = Process.Start( psi );

				p.WaitForExit();
			}
			catch
			{
			}

			Console.WriteLine( "Reports: {0}: Upload complete", m_Title );

			try{ File.Delete( filePath ); }
			catch{}
		}

		public void RenderFull()
		{
			string filePath = Path.Combine( m_OutputDirectory, "reports.html" );

			using ( StreamWriter op = new StreamWriter( filePath ) )
			{
				using ( HtmlTextWriter html = new HtmlTextWriter( op, "\t" ) )
					RenderFull( html );
			}

			string cssPath = Path.Combine( m_OutputDirectory, "styles.css" );

			if ( File.Exists( cssPath ) )
				return;

			using ( StreamWriter css = new StreamWriter( cssPath ) )
			{
				css.WriteLine( "body { background-color: White; font-family: verdana, arial; font-size: 11px; }" );
				css.WriteLine( "a { color: #28435E; }" );
				css.WriteLine( "a:hover { color: #4878A9; }" );
				css.WriteLine( "td.header { background-color: #9696AA; font-weight: bold; font-size: 12px; }" );
				css.WriteLine( "td.lentry { background-color: #D7D7EB; width: 10%; }" );
				css.WriteLine( "td.rentry { background-color: White; width: 90%; }" );
				css.WriteLine( "td.entry { background-color: White; }" );
				css.WriteLine( "td { font-size: 11px; }" );
				css.Write    ( ".tbl-border { background-color: #46465A; }" );
			}
		}

		private const string ShardTitle = "Shard";

		public void RenderFull( HtmlTextWriter html )
		{
			html.RenderBeginTag( HtmlTag.Html );

			html.RenderBeginTag( HtmlTag.Head );

			html.RenderBeginTag( HtmlTag.Title );
			html.Write( "{0} Statistics", ShardTitle );
			html.RenderEndTag();

			html.AddAttribute( "rel", "stylesheet" );
			html.AddAttribute( HtmlAttr.Type, "text/css" );
			html.AddAttribute( HtmlAttr.Href, "styles.css" );
			html.RenderBeginTag( HtmlTag.Link );
			html.RenderEndTag();

			html.RenderEndTag();

			html.RenderBeginTag( HtmlTag.Body );

			for ( int i = 0; i < m_Objects.Count; ++i )
			{
				RenderDirect( m_Objects[i], html );
				html.Write( "<br><br>" );
			}

			html.RenderBeginTag( HtmlTag.Center );
			TimeZone tz = TimeZone.CurrentTimeZone;
			bool isDaylight = tz.IsDaylightSavingTime( m_TimeStamp );
			TimeSpan utcOffset = tz.GetUtcOffset( m_TimeStamp );

			html.Write( "Snapshot taken at {0:d} {0:t}. All times are {1}.", m_TimeStamp, tz.StandardName );
			html.RenderEndTag();

			html.RenderEndTag();

			html.RenderEndTag();
		}

		public static string SafeFileName( string name )
		{
			return name.ToLower().Replace( ' ', '_' );
		}

		public void RenderSingle( PersistableObject obj )
		{
			string filePath = Path.Combine( m_OutputDirectory, SafeFileName( FindNameFrom( obj ) ) + ".html" );

			using ( StreamWriter op = new StreamWriter( filePath ) )
			{
				using ( HtmlTextWriter html = new HtmlTextWriter( op, "\t" ) )
					RenderSingle( obj, html );
			}
		}

		private string FindNameFrom( PersistableObject obj )
		{
			if ( obj is Report )
				return (obj as Report).Name;
			else if ( obj is Chart )
				return (obj as Chart).Name;

			return "Invalid";
		}

		public void RenderSingle( PersistableObject obj, HtmlTextWriter html )
		{
			html.RenderBeginTag( HtmlTag.Html );

			html.RenderBeginTag( HtmlTag.Head );

			html.RenderBeginTag( HtmlTag.Title );
			html.Write( "{0} Statistics - {1}", ShardTitle, FindNameFrom( obj ) );
			html.RenderEndTag();

			html.AddAttribute( "rel", "stylesheet" );
			html.AddAttribute( HtmlAttr.Type, "text/css" );
			html.AddAttribute( HtmlAttr.Href, "styles.css" );
			html.RenderBeginTag( HtmlTag.Link );
			html.RenderEndTag();

			html.RenderEndTag();

			html.RenderBeginTag( HtmlTag.Body );

			html.RenderBeginTag( HtmlTag.Center );

			RenderDirect( obj, html );

			html.Write( "<br>" );

			TimeZone tz = TimeZone.CurrentTimeZone;
			bool isDaylight = tz.IsDaylightSavingTime( m_TimeStamp );
			TimeSpan utcOffset = tz.GetUtcOffset( m_TimeStamp );

			html.Write( "Snapshot taken at {0:d} {0:t}. All times are {1}.", m_TimeStamp, tz.StandardName );
			html.RenderEndTag();

			html.RenderEndTag();

			html.RenderEndTag();
		}

		public void RenderDirect( PersistableObject obj, HtmlTextWriter html )
		{
			if ( obj is Report )
				RenderReport( obj as Report, html );
			else if ( obj is BarGraph )
				RenderBarGraph( obj as BarGraph, html );
			else if ( obj is PieChart )
				RenderPieChart( obj as PieChart, html );
		}

		private void RenderPieChart( PieChart chart, HtmlTextWriter html )
		{
			PieChartRenderer pieChart = new PieChartRenderer( Color.White );

			pieChart.ShowPercents = chart.ShowPercents;

			string[] labels = new string[chart.Items.Count];
			string[] values = new string[chart.Items.Count];

			for ( int i = 0; i < chart.Items.Count; ++i )
			{
				ChartItem item = chart.Items[i];

				labels[i] = item.Name;
				values[i] = item.Value.ToString();
			}

			pieChart.CollectDataPoints( labels, values );

			Bitmap bmp = pieChart.Draw();

			string fileName = chart.FileName + ".png";
			bmp.Save( Path.Combine( m_OutputDirectory, fileName ), ImageFormat.Png );

			html.Write( "<!-- " );

			html.AddAttribute( HtmlAttr.Href, "#" );
			html.AddAttribute( HtmlAttr.Onclick, String.Format( "javascript:window.open('{0}.html','ChildWindow','width={1},height={2},resizable=no,status=no,toolbar=no')", SafeFileName( FindNameFrom( chart ) ), bmp.Width+30,bmp.Height+80 ) );
			html.RenderBeginTag( HtmlTag.A );
			html.Write( chart.Name );
			html.RenderEndTag();

			html.Write( " -->" );

			html.AddAttribute( HtmlAttr.Cellpadding, "0" );
			html.AddAttribute( HtmlAttr.Cellspacing, "0" );
			html.AddAttribute( HtmlAttr.Border, "0" );
			html.RenderBeginTag( HtmlTag.Table );

			html.RenderBeginTag( HtmlTag.Tr );
			html.AddAttribute( HtmlAttr.Class, "tbl-border" );
			html.RenderBeginTag( HtmlTag.Td );

			html.AddAttribute( HtmlAttr.Width, "100%" );
			html.AddAttribute( HtmlAttr.Cellpadding, "4" );
			html.AddAttribute( HtmlAttr.Cellspacing, "1" );
			html.RenderBeginTag( HtmlTag.Table );

			html.RenderBeginTag( HtmlTag.Tr );

			html.AddAttribute( HtmlAttr.Colspan, "10" );
			html.AddAttribute( HtmlAttr.Width, "100%" );
			html.AddAttribute( HtmlAttr.Align, "center" );
			html.AddAttribute( HtmlAttr.Class, "header" );
			html.RenderBeginTag( HtmlTag.Td );
			html.Write( chart.Name );
			html.RenderEndTag();
			html.RenderEndTag();

			html.RenderBeginTag( HtmlTag.Tr );

			html.AddAttribute( HtmlAttr.Colspan, "10" );
			html.AddAttribute( HtmlAttr.Width, "100%" );
			html.AddAttribute( HtmlAttr.Align, "center" );
			html.AddAttribute( HtmlAttr.Class, "entry" );
			html.RenderBeginTag( HtmlTag.Td );

			html.AddAttribute( HtmlAttr.Width, bmp.Width.ToString() );
			html.AddAttribute( HtmlAttr.Height, bmp.Height.ToString() );
			html.AddAttribute( HtmlAttr.Src, fileName );
			html.RenderBeginTag( HtmlTag.Img );
			html.RenderEndTag();

			html.RenderEndTag();
			html.RenderEndTag();

			html.RenderEndTag();
			html.RenderEndTag();
			html.RenderEndTag();
			html.RenderEndTag();

			bmp.Dispose();
		}

		private void RenderBarGraph( BarGraph graph, HtmlTextWriter html )
		{
			BarGraphRenderer barGraph = new BarGraphRenderer( Color.White );

			barGraph.RenderMode = graph.RenderMode;

			barGraph._regions = graph.Regions;
			barGraph.SetTitles( graph.xTitle, null );

			if ( graph.yTitle != null )
				barGraph.VerticalLabel = graph.yTitle;

			barGraph.FontColor = Color.Black;
			barGraph.ShowData = ( graph.Interval == 1 );
			barGraph.VerticalTickCount = graph.Ticks;

			string[] labels = new string[graph.Items.Count];
			string[] values = new string[graph.Items.Count];

			for ( int i = 0; i < graph.Items.Count; ++i )
			{
				ChartItem item = graph.Items[i];

				labels[i] = item.Name;
				values[i] = item.Value.ToString();
			}

			barGraph._interval = graph.Interval;
			barGraph.CollectDataPoints( labels, values );

			Bitmap bmp = barGraph.Draw();

			string fileName = graph.FileName + ".png";
			bmp.Save( Path.Combine( m_OutputDirectory, fileName ), ImageFormat.Png );

			html.Write( "<!-- " );

			html.AddAttribute( HtmlAttr.Href, "#" );
			html.AddAttribute( HtmlAttr.Onclick, String.Format( "javascript:window.open('{0}.html','ChildWindow','width={1},height={2},resizable=no,status=no,toolbar=no')", SafeFileName( FindNameFrom( graph ) ), bmp.Width+30,bmp.Height+80 ) );
			html.RenderBeginTag( HtmlTag.A );
			html.Write( graph.Name );
			html.RenderEndTag();

			html.Write( " -->" );

			html.AddAttribute( HtmlAttr.Cellpadding, "0" );
			html.AddAttribute( HtmlAttr.Cellspacing, "0" );
			html.AddAttribute( HtmlAttr.Border, "0" );
			html.RenderBeginTag( HtmlTag.Table );

			html.RenderBeginTag( HtmlTag.Tr );
			html.AddAttribute( HtmlAttr.Class, "tbl-border" );
			html.RenderBeginTag( HtmlTag.Td );

			html.AddAttribute( HtmlAttr.Width, "100%" );
			html.AddAttribute( HtmlAttr.Cellpadding, "4" );
			html.AddAttribute( HtmlAttr.Cellspacing, "1" );
			html.RenderBeginTag( HtmlTag.Table );

			html.RenderBeginTag( HtmlTag.Tr );

			html.AddAttribute( HtmlAttr.Colspan, "10" );
			html.AddAttribute( HtmlAttr.Width, "100%" );
			html.AddAttribute( HtmlAttr.Align, "center" );
			html.AddAttribute( HtmlAttr.Class, "header" );
			html.RenderBeginTag( HtmlTag.Td );
			html.Write( graph.Name );
			html.RenderEndTag();
			html.RenderEndTag();

			html.RenderBeginTag( HtmlTag.Tr );

			html.AddAttribute( HtmlAttr.Colspan, "10" );
			html.AddAttribute( HtmlAttr.Width, "100%" );
			html.AddAttribute( HtmlAttr.Align, "center" );
			html.AddAttribute( HtmlAttr.Class, "entry" );
			html.RenderBeginTag( HtmlTag.Td );

			html.AddAttribute( HtmlAttr.Width, bmp.Width.ToString() );
			html.AddAttribute( HtmlAttr.Height, bmp.Height.ToString() );
			html.AddAttribute( HtmlAttr.Src, fileName );
			html.RenderBeginTag( HtmlTag.Img );
			html.RenderEndTag();

			html.RenderEndTag();
			html.RenderEndTag();

			html.RenderEndTag();
			html.RenderEndTag();
			html.RenderEndTag();
			html.RenderEndTag();

			bmp.Dispose();
		}

		private void RenderReport( Report report, HtmlTextWriter html )
		{
			html.AddAttribute( HtmlAttr.Width, report.Width );
			html.AddAttribute( HtmlAttr.Cellpadding, "0" );
			html.AddAttribute( HtmlAttr.Cellspacing, "0" );
			html.AddAttribute( HtmlAttr.Border, "0" );
			html.RenderBeginTag( HtmlTag.Table );

			html.RenderBeginTag( HtmlTag.Tr );
			html.AddAttribute( HtmlAttr.Class, "tbl-border" );
			html.RenderBeginTag( HtmlTag.Td );

			html.AddAttribute( HtmlAttr.Width, "100%" );
			html.AddAttribute( HtmlAttr.Cellpadding, "4" );
			html.AddAttribute( HtmlAttr.Cellspacing, "1" );
			html.RenderBeginTag( HtmlTag.Table );

			html.RenderBeginTag( HtmlTag.Tr );
			html.AddAttribute( HtmlAttr.Colspan, "10" );
			html.AddAttribute( HtmlAttr.Width, "100%" );
			html.AddAttribute( HtmlAttr.Align, "center" );
			html.AddAttribute( HtmlAttr.Class, "header" );
			html.RenderBeginTag( HtmlTag.Td );
			html.Write( report.Name );
			html.RenderEndTag();
			html.RenderEndTag();

			bool isNamed = false;

			for ( int i = 0; i < report.Columns.Count && !isNamed; ++i )
				isNamed = ( report.Columns[i].Name != null );

			if ( isNamed )
			{
				html.RenderBeginTag( HtmlTag.Tr );

				for ( int i = 0; i < report.Columns.Count; ++i )
				{
					ReportColumn column = report.Columns[i];

					html.AddAttribute( HtmlAttr.Class, "header" );
					html.AddAttribute( HtmlAttr.Width, column.Width );
					html.AddAttribute( HtmlAttr.Align, column.Align );
					html.RenderBeginTag( HtmlTag.Td );

					html.Write( column.Name );

					html.RenderEndTag();
				}

				html.RenderEndTag();
			}

			for ( int i = 0; i < report.Items.Count; ++i )
			{
				ReportItem item = report.Items[i];

				html.RenderBeginTag( HtmlTag.Tr );

				for ( int j = 0; j < item.Values.Count; ++j )
				{
					if ( !isNamed && j == 0 )
						html.AddAttribute( HtmlAttr.Width, report.Columns[j].Width );

					html.AddAttribute( HtmlAttr.Align, report.Columns[j].Align );
					html.AddAttribute( HtmlAttr.Class, "entry" );
					html.RenderBeginTag( HtmlTag.Td );

					if ( item.Values[j].Format == null )
						html.Write( item.Values[j].Value );
					else
						html.Write( int.Parse( item.Values[j].Value ).ToString( item.Values[j].Format ) );

					html.RenderEndTag();
				}

				html.RenderEndTag();
			}

			html.RenderEndTag();
			html.RenderEndTag();
			html.RenderEndTag();
			html.RenderEndTag();
		}
	}
}

namespace Server.Engines.Reports
{
	// Modified from MS sample

	//*********************************************************************
	//
	// PieChart Class
	//
	// This class uses GDI+ to render Pie Chart.
	//
	//*********************************************************************

	public class PieChartRenderer : ChartRenderer
	{
		private const int	_bufferSpace = 125;
		private ArrayList	_chartItems;
		private int			_perimeter;
		private Color		_backgroundColor;
		private Color		_borderColor;
		private float		_total;
		private int			_legendWidth;
		private int			_legendHeight;
		private int			_legendFontHeight;
		private string		_legendFontStyle;
		private float		_legendFontSize;
		private bool		_showPercents;

		public bool ShowPercents{ get{ return _showPercents; } set{ _showPercents = value; } }

		public PieChartRenderer()
		{
			_chartItems = new ArrayList();
			_perimeter = 250;
			_backgroundColor = Color.White;
			_borderColor = Color.FromArgb(63,63,63);
			_legendFontSize = 8;
			_legendFontStyle = "Verdana";
		}

		public PieChartRenderer(Color bgColor)
		{
			_chartItems = new ArrayList();
			_perimeter = 250;
			_backgroundColor = bgColor;
			_borderColor = Color.FromArgb(63,63,63);
			_legendFontSize = 8;
			_legendFontStyle = "Verdana";
		}

		//*********************************************************************
		//
		// This method collects all data points and calculate all the necessary dimensions 
		// to draw the chart.  It is the first method called before invoking the Draw() method.
		//
		//*********************************************************************

		public void CollectDataPoints(string[] xValues, string[] yValues)
		{
			_total = 0.0f;
			
			for (int i = 0;i < xValues.Length;i++)
			{
				float ftemp = Convert.ToSingle(yValues[i]);
				_chartItems.Add(new DataItem(xValues[i], xValues.ToString(), ftemp, 0, 0, Color.AliceBlue));
				_total += ftemp;
			}
			
			float nextStartPos = 0.0f;
			int counter = 0;
			foreach (DataItem item in _chartItems)
			{
				item.StartPos = nextStartPos;
				item.SweepSize = item.Value / _total * 360;
				nextStartPos = item.StartPos + item.SweepSize;
				item.ItemColor = GetColor(counter++);
			}

			CalculateLegendWidthHeight();
		}

		//*********************************************************************
		//
		// This method returns a bitmap to the calling function.  This is the method
		// that actually draws the pie chart and the legend with it.
		//
		//*********************************************************************

		public override Bitmap Draw()
		{
			int perimeter = _perimeter;
			Rectangle pieRect = new Rectangle(0, 0, perimeter, perimeter-1);
			Bitmap bmp = new Bitmap(perimeter + _legendWidth, perimeter);
			Font fnt = null;
			Pen pen = null;
			Graphics grp = null;
			StringFormat sf = null, sfp = null;
			
			try
			{
				grp = Graphics.FromImage(bmp);
				grp.CompositingQuality = CompositingQuality.HighQuality;
				grp.SmoothingMode = SmoothingMode.AntiAlias;
				sf = new StringFormat();

				//Paint Back ground
				using ( SolidBrush brsh = new SolidBrush( _backgroundColor ) )
					grp.FillRectangle(brsh, -1, -1, perimeter + _legendWidth+1, perimeter+1);

				//Align text to the right
				sf.Alignment = StringAlignment.Far; 
			
				//Draw all wedges and legends
				for(int i=0; i<_chartItems.Count; i++)
				{
					DataItem item = (DataItem) _chartItems[i];
					SolidBrush brs = null;
					try
					{
						brs = new SolidBrush(item.ItemColor);
						grp.FillPie(brs, pieRect, item.StartPos, item.SweepSize);

						//grp.DrawPie(new Pen(_borderColor,1.2f),pieRect,item.StartPos,item.SweepSize);

						if ( fnt == null )
							fnt = new Font( _legendFontStyle, _legendFontSize );

						if ( _showPercents && item.SweepSize > 10 )
						{
							if ( sfp == null )
							{
								sfp = new StringFormat();
								sfp.Alignment = StringAlignment.Center;
								sfp.LineAlignment = StringAlignment.Center;
							}

							float perc = (item.SweepSize * 100.0f) / 360.0f;
							string percString = String.Format( "{0:F0}%", perc );

							float px = pieRect.X+(pieRect.Width/2);
							float py = pieRect.Y+(pieRect.Height/2);

							double angle = item.StartPos + (item.SweepSize/2);
							double rads = (angle/180.0)*Math.PI;

							px += (float)(Math.Cos( rads ) * perimeter / 3);
							py += (float)(Math.Sin( rads ) * perimeter / 3);

							grp.DrawString( percString, fnt, Brushes.Gray,
								new RectangleF( px - 30 - 1, py - 20, 60, 40 ), sfp );

							grp.DrawString( percString, fnt, Brushes.Gray,
								new RectangleF( px - 30 + 1, py - 20, 60, 40 ), sfp );

							grp.DrawString( percString, fnt, Brushes.Gray,
								new RectangleF( px - 30, py - 20 - 1, 60, 40 ), sfp );

							grp.DrawString( percString, fnt, Brushes.Gray,
								new RectangleF( px - 30, py - 20 + 1, 60, 40 ), sfp );

							grp.DrawString( percString, fnt, Brushes.White,
								new RectangleF( px - 30, py - 20, 60, 40 ), sfp );
						}

						if ( pen == null )
							pen = new Pen( _borderColor, 0.5f );

						grp.FillRectangle(brs, perimeter + _bufferSpace, i * _legendFontHeight + 15, 10, 10);
						grp.DrawRectangle(pen, perimeter + _bufferSpace, i * _legendFontHeight + 15, 10, 10);
					
						grp.DrawString(item.Label, fnt, 
							Brushes.Black, perimeter + _bufferSpace + 20, i * _legendFontHeight + 13);

						grp.DrawString(item.Value.ToString("#,###.##"), fnt, 
							Brushes.Black, perimeter + _bufferSpace + 200, i * _legendFontHeight + 13,sf);
					}
					finally
					{
						if (brs !=null)
							brs.Dispose();
					}
				}

				for(int i=0; i<_chartItems.Count; i++)
				{
					DataItem item = (DataItem) _chartItems[i];
					SolidBrush brs = null;
					try
					{
						grp.DrawPie(new Pen(_borderColor,0.5f),pieRect,item.StartPos,item.SweepSize);
					}
					finally
					{
						if (brs !=null)
							brs.Dispose();
					}
				}
			
				//draws the border around Pie
				using ( Pen pen2 = new Pen( _borderColor, 2 ) )
					grp.DrawEllipse(pen2, pieRect);  

				//draw border around legend
				using ( Pen pen1 = new Pen( _borderColor, 1 ) )
					grp.DrawRectangle(pen1, perimeter + _bufferSpace - 10, 10, 220, _chartItems.Count * _legendFontHeight + 25);

				//Draw Total under legend
				using ( Font fntb = new Font( _legendFontStyle, _legendFontSize, FontStyle.Bold ) )
				{
					grp.DrawString("Total", fntb, 
						Brushes.Black, perimeter + _bufferSpace + 30, (_chartItems.Count+1) * _legendFontHeight,sf);
					grp.DrawString(_total.ToString("#,###.##"), fntb, 
						Brushes.Black, perimeter + _bufferSpace + 200, (_chartItems.Count+1) * _legendFontHeight,sf);
				}
			
				grp.SmoothingMode = SmoothingMode.AntiAlias;
			}
			finally
			{
				if (sf != null)	sf.Dispose();
				if (grp != null) grp.Dispose();
				if (sfp != null) sfp.Dispose();
				if (fnt != null) fnt.Dispose();
				if (pen != null) pen.Dispose();
			}
			return bmp;
		}

		//*********************************************************************
		//
		//	This method calculates the space required to draw the chart legend.
		//
		//*********************************************************************
		
		private void CalculateLegendWidthHeight()
		{
			Font fontLegend = new Font(_legendFontStyle, _legendFontSize);
			_legendFontHeight = fontLegend.Height+3;
			_legendHeight = fontLegend.Height * (_chartItems.Count + 1);
			if (_legendHeight > _perimeter) _perimeter = _legendHeight;

			_legendWidth = _perimeter + _bufferSpace;
			fontLegend.Dispose();
		}
	}
}

namespace Server.Engines.Reports
{
	public abstract class PersistableObject
	{
		public abstract PersistableType TypeID{ get; }

		public virtual void SerializeAttributes( PersistanceWriter op )
		{
		}

		public virtual void SerializeChildren( PersistanceWriter op )
		{
		}

		public void Serialize( PersistanceWriter op )
		{
			op.BeginObject( this.TypeID );
			SerializeAttributes( op );
			op.BeginChildren();
			SerializeChildren( op );
			op.FinishChildren();
			op.FinishObject();
		}

		public virtual void DeserializeAttributes( PersistanceReader ip )
		{
		}

		public virtual void DeserializeChildren( PersistanceReader ip )
		{
		}

		public void Deserialize( PersistanceReader ip )
		{
			DeserializeAttributes( ip );

			if ( ip.BeginChildren() )
			{
				DeserializeChildren( ip );
				ip.FinishChildren();
			}
		}

		public PersistableObject()
		{
		}
	}
}//------------------------------------------------------------------------------
// <autogenerated>
//     This code was generated by a tool.
//     Runtime Version: 1.1.4322.573
//
//     Changes to this file may cause incorrect behavior and will be lost if 
//     the code is regenerated.
// </autogenerated>
//------------------------------------------------------------------------------

namespace Server.Engines.Reports
{
    /// <summary>
    /// Strongly typed collection of Server.Engines.Reports.PersistableObject.
    /// </summary>
    public class ObjectCollection : System.Collections.CollectionBase
    {
        
        /// <summary>
        /// Default constructor.
        /// </summary>
        public ObjectCollection() : 
                base()
        {
        }
        
        /// <summary>
        /// Gets or sets the value of the Server.Engines.Reports.PersistableObject at a specific position in the ObjectCollection.
        /// </summary>
        public Server.Engines.Reports.PersistableObject this[int index]
        {
            get
            {
                return ((Server.Engines.Reports.PersistableObject)(this.List[index]));
            }
            set
            {
                this.List[index] = value;
            }
        }
        
        /// <summary>
        /// Append a Server.Engines.Reports.PersistableObject entry to this collection.
        /// </summary>
        /// <param name="value">Server.Engines.Reports.PersistableObject instance.</param>
        /// <returns>The position into which the new element was inserted.</returns>
        public int Add(Server.Engines.Reports.PersistableObject value)
        {
            return this.List.Add(value);
        }

		public void AddRange( PersistableObject[] col )
		{
			this.InnerList.AddRange( col );
		}
        
        /// <summary>
        /// Determines whether a specified Server.Engines.Reports.PersistableObject instance is in this collection.
        /// </summary>
        /// <param name="value">Server.Engines.Reports.PersistableObject instance to search for.</param>
        /// <returns>True if the Server.Engines.Reports.PersistableObject instance is in the collection; otherwise false.</returns>
        public bool Contains(Server.Engines.Reports.PersistableObject value)
        {
            return this.List.Contains(value);
        }
        
        /// <summary>
        /// Retrieve the index a specified Server.Engines.Reports.PersistableObject instance is in this collection.
        /// </summary>
        /// <param name="value">Server.Engines.Reports.PersistableObject instance to find.</param>
        /// <returns>The zero-based index of the specified Server.Engines.Reports.PersistableObject instance. If the object is not found, the return value is -1.</returns>
        public int IndexOf(Server.Engines.Reports.PersistableObject value)
        {
            return this.List.IndexOf(value);
        }
        
        /// <summary>
        /// Removes a specified Server.Engines.Reports.PersistableObject instance from this collection.
        /// </summary>
        /// <param name="value">The Server.Engines.Reports.PersistableObject instance to remove.</param>
        public void Remove(Server.Engines.Reports.PersistableObject value)
        {
            this.List.Remove(value);
        }
        
        /// <summary>
        /// Returns an enumerator that can iterate through the Server.Engines.Reports.PersistableObject instance.
        /// </summary>
        /// <returns>An Server.Engines.Reports.PersistableObject's enumerator.</returns>
        public new ObjectCollectionEnumerator GetEnumerator()
        {
            return new ObjectCollectionEnumerator(this);
        }
        
        /// <summary>
        /// Insert a Server.Engines.Reports.PersistableObject instance into this collection at a specified index.
        /// </summary>
        /// <param name="index">Zero-based index.</param>
        /// <param name="value">The Server.Engines.Reports.PersistableObject instance to insert.</param>
        public void Insert(int index, Server.Engines.Reports.PersistableObject value)
        {
            this.List.Insert(index, value);
        }
        
        /// <summary>
        /// Strongly typed enumerator of Server.Engines.Reports.PersistableObject.
        /// </summary>
        public class ObjectCollectionEnumerator : System.Collections.IEnumerator
        {
            
            /// <summary>
            /// Current index
            /// </summary>
            private int _index;
            
            /// <summary>
            /// Current element pointed to.
            /// </summary>
            private Server.Engines.Reports.PersistableObject _currentElement;
            
            /// <summary>
            /// Collection to enumerate.
            /// </summary>
            private ObjectCollection _collection;
            
            /// <summary>
            /// Default constructor for enumerator.
            /// </summary>
            /// <param name="collection">Instance of the collection to enumerate.</param>
            internal ObjectCollectionEnumerator(ObjectCollection collection)
            {
                _index = -1;
                _collection = collection;
            }
            
            /// <summary>
            /// Gets the Server.Engines.Reports.PersistableObject object in the enumerated ObjectCollection currently indexed by this instance.
            /// </summary>
            public Server.Engines.Reports.PersistableObject Current
            {
                get
                {
                    if (((_index == -1) 
                                || (_index >= _collection.Count)))
                    {
                        throw new System.IndexOutOfRangeException("Enumerator not started.");
                    }
                    else
                    {
                        return _currentElement;
                    }
                }
            }
            
            /// <summary>
            /// Gets the current element in the collection.
            /// </summary>
            object IEnumerator.Current
            {
                get
                {
                    if (((_index == -1) 
                                || (_index >= _collection.Count)))
                    {
                        throw new System.IndexOutOfRangeException("Enumerator not started.");
                    }
                    else
                    {
                        return _currentElement;
                    }
                }
            }
            
            /// <summary>
            /// Reset the cursor, so it points to the beginning of the enumerator.
            /// </summary>
            public void Reset()
            {
                _index = -1;
                _currentElement = null;
            }
            
            /// <summary>
            /// Advances the enumerator to the next queue of the enumeration, if one is currently available.
            /// </summary>
            /// <returns>true, if the enumerator was succesfully advanced to the next queue; false, if the enumerator has reached the end of the enumeration.</returns>
            public bool MoveNext()
            {
                if ((_index 
                            < (_collection.Count - 1)))
                {
                    _index = (_index + 1);
                    _currentElement = this._collection[_index];
                    return true;
                }
                _index = _collection.Count;
                return false;
            }
        }
    }
}

namespace Server.Engines.Reports
{
	public delegate PersistableObject ConstructCallback();

	public sealed class PersistableTypeRegistry
	{
		private static Hashtable m_Table;

		public static PersistableType Find( string name )
		{
			return m_Table[name] as PersistableType;
		}

		public static void Register( PersistableType type )
		{
			if ( type != null )
				m_Table[type.Name] = type;
		}

		static PersistableTypeRegistry()
		{
			m_Table = new Hashtable( StringComparer.OrdinalIgnoreCase );

			Register( Report.ThisTypeID );
			Register( BarGraph.ThisTypeID );
			Register( PieChart.ThisTypeID );
			Register( Snapshot.ThisTypeID );
			Register( ItemValue.ThisTypeID );
			Register( ChartItem.ThisTypeID );
			Register( ReportItem.ThisTypeID );
			Register( ReportColumn.ThisTypeID );
			Register( SnapshotHistory.ThisTypeID );

			Register( PageInfo.ThisTypeID );
			Register( QueueStatus.ThisTypeID );
			Register( StaffHistory.ThisTypeID );
			Register( ResponseInfo.ThisTypeID );
		}
	}

	public sealed class PersistableType
	{
		private string m_Name;
		private ConstructCallback m_Constructor;

		public string Name{ get{ return m_Name; } }
		public ConstructCallback Constructor{ get{ return m_Constructor; } }

		public PersistableType( string name, ConstructCallback constructor )
		{
			m_Name = name;
			m_Constructor = constructor;
		}
	}
}

namespace Server.Engines.Reports
{
	public abstract class PersistanceReader
	{
		public abstract int GetInt32( string key );
		public abstract bool GetBoolean( string key );
		public abstract string GetString( string key );
		public abstract DateTime GetDateTime( string key );

		public abstract bool BeginChildren();
		public abstract void FinishChildren();
		public abstract bool HasChild{ get; }
		public abstract PersistableObject GetChild();

		public abstract void ReadDocument( PersistableObject root );
		public abstract void Close();

		public PersistanceReader()
		{
		}
	}

	public class XmlPersistanceReader : PersistanceReader
	{
		private StreamReader m_Reader;
		private XmlTextReader m_Xml;
		private string m_Title;

		public XmlPersistanceReader( string filePath, string title )
		{
			m_Reader = new StreamReader( filePath );
			m_Xml = new XmlTextReader( m_Reader );
			m_Xml.WhitespaceHandling=WhitespaceHandling.None;
			m_Title = title;
		}

		public override int GetInt32( string key )
		{
			return XmlConvert.ToInt32( m_Xml.GetAttribute( key ) );
		}

		public override bool GetBoolean( string key )
		{
			return XmlConvert.ToBoolean( m_Xml.GetAttribute( key ) );
		}

		public override string GetString( string key )
		{
			return m_Xml.GetAttribute( key );
		}

		public override DateTime GetDateTime( string key )
		{
			string val = m_Xml.GetAttribute( key );

			if ( val == null )
				return DateTime.MinValue;

			return XmlConvert.ToDateTime( val, XmlDateTimeSerializationMode.Local );
		}

		private bool m_HasChild;

		public override bool HasChild
		{
			get
			{
				return m_HasChild;
			}
		}

		private bool m_WasEmptyElement;

		public override bool BeginChildren()
		{
			m_HasChild = !m_WasEmptyElement;

			m_Xml.Read();

			return m_HasChild;
		}

		public override void FinishChildren()
		{
			m_Xml.Read();
		}

		public override PersistableObject GetChild()
		{
			PersistableType type = PersistableTypeRegistry.Find( m_Xml.Name );
			PersistableObject obj = type.Constructor();

			m_WasEmptyElement = m_Xml.IsEmptyElement;

			obj.Deserialize( this );

			m_HasChild = ( m_Xml.NodeType == XmlNodeType.Element );

			return obj;
		}

		public override void ReadDocument( PersistableObject root )
		{
			Console.Write( "Reports: {0}: Loading...", m_Title );
			m_Xml.Read();
			m_Xml.Read();
			m_HasChild = !m_Xml.IsEmptyElement;
			root.Deserialize( this );
			Console.WriteLine( "done" );
		}

		public override void Close()
		{
			m_Xml.Close();
			m_Reader.Close();
		}
	}
}

namespace Server.Engines.Reports
{
	public abstract class PersistanceWriter
	{
		public abstract void SetInt32( string key, int value );
		public abstract void SetBoolean( string key, bool value );
		public abstract void SetString( string key, string value );
		public abstract void SetDateTime( string key, DateTime value );

		public abstract void BeginObject( PersistableType typeID );
		public abstract void BeginChildren();
		public abstract void FinishChildren();
		public abstract void FinishObject();

		public abstract void WriteDocument( PersistableObject root );
		public abstract void Close();

		public PersistanceWriter()
		{
		}
	}

	public sealed class XmlPersistanceWriter : PersistanceWriter
	{
		private string m_RealFilePath;
		private string m_TempFilePath;

		private StreamWriter m_Writer;
		private XmlTextWriter m_Xml;
		private string m_Title;

		public XmlPersistanceWriter( string filePath, string title )
		{
			m_RealFilePath = filePath;
			m_TempFilePath = Path.ChangeExtension( filePath, ".tmp" );

			m_Writer = new StreamWriter( m_TempFilePath );
			m_Xml = new XmlTextWriter( m_Writer );

			m_Title = title;
		}

		public override void SetInt32( string key, int value )
		{
			m_Xml.WriteAttributeString( key, XmlConvert.ToString( value ) );
		}

		public override void SetBoolean( string key, bool value )
		{
			m_Xml.WriteAttributeString( key, XmlConvert.ToString( value ) );
		}

		public override void SetString( string key, string value )
		{
			if ( value != null )
				m_Xml.WriteAttributeString( key, value );
		}

		public override void SetDateTime( string key, DateTime value )
		{
			if ( value != DateTime.MinValue )
				m_Xml.WriteAttributeString( key, XmlConvert.ToString( value, XmlDateTimeSerializationMode.Local ) );
		}

		public override void BeginObject( PersistableType typeID )
		{
			m_Xml.WriteStartElement( typeID.Name );
		}

		public override void BeginChildren()
		{
		}

		public override void FinishChildren()
		{
		}

		public override void FinishObject()
		{
			m_Xml.WriteEndElement();
		}

		public override void WriteDocument( PersistableObject root )
		{
			Console.WriteLine( "Reports: {0}: Save started", m_Title );

			m_Xml.Formatting = Formatting.Indented;
			m_Xml.IndentChar = '\t';
			m_Xml.Indentation = 1;

			m_Xml.WriteStartDocument( true );

			root.Serialize( this );

			Console.WriteLine( "Reports: {0}: Save complete", m_Title );
		}

		public override void Close()
		{
			m_Xml.Close();
			m_Writer.Close();

			try
			{
				string renamed = null;

				if ( File.Exists( m_RealFilePath ) )
				{
					renamed = Path.ChangeExtension( m_RealFilePath, ".rem" );
					File.Move( m_RealFilePath, renamed );
					File.Move( m_TempFilePath, m_RealFilePath );
					File.Delete( renamed );
				}
				else
				{
					File.Move( m_TempFilePath, m_RealFilePath );
				}
			}
			catch ( Exception ex )
			{
				Console.WriteLine( ex );
			}
		}
	}
}

namespace Server.Engines.Reports
{
	public enum BarGraphRenderMode
	{
		Bars,
		Lines
	}

	public class BarGraph : Chart
	{
		#region Type Identification
		public static readonly PersistableType ThisTypeID = new PersistableType( "bg", new ConstructCallback( Construct ) );

		private static PersistableObject Construct()
		{
			return new BarGraph();
		}

		public override PersistableType TypeID{ get{ return ThisTypeID; } }
		#endregion

		private int m_Ticks;
		private BarGraphRenderMode m_RenderMode;

		private string m_xTitle;
		private string m_yTitle;

		private int m_FontSize = 7;
		private int m_Interval = 1;

		private BarRegion[] m_Regions;

		public int Ticks{ get{ return m_Ticks; } set{ m_Ticks = value; } }
		public BarGraphRenderMode RenderMode{ get{ return m_RenderMode; } set{ m_RenderMode = value; } }

		public string xTitle{ get{ return m_xTitle; } set{ m_xTitle = value; } }
		public string yTitle{ get{ return m_yTitle; } set{ m_yTitle = value; } }

		public int FontSize{ get{ return m_FontSize; } set{ m_FontSize = value; } }
		public int Interval{ get{ return m_Interval; } set{ m_Interval = value; } }

		public BarRegion[] Regions{ get{ return m_Regions; } set{ m_Regions = value; } }

		public BarGraph( string name, string fileName, int ticks, string xTitle, string yTitle, BarGraphRenderMode rm )
		{
			m_Name = name;
			m_FileName = fileName;
			m_Ticks = ticks;
			m_xTitle = xTitle;
			m_yTitle = yTitle;
			m_RenderMode = rm;
		}

		private BarGraph()
		{
		}

		public override void SerializeAttributes( PersistanceWriter op )
		{
			base.SerializeAttributes( op );

			op.SetInt32( "t", m_Ticks );
			op.SetInt32( "r", (int) m_RenderMode );

			op.SetString( "x", m_xTitle );
			op.SetString( "y", m_yTitle );

			op.SetInt32( "s", m_FontSize );
			op.SetInt32( "i", m_Interval );
		}

		public override void DeserializeAttributes( PersistanceReader ip )
		{
			base.DeserializeAttributes( ip );

			m_Ticks = ip.GetInt32( "t" );
			m_RenderMode = (BarGraphRenderMode) ip.GetInt32( "r" );

			m_xTitle = Utility.Intern( ip.GetString( "x" ) );
			m_yTitle = Utility.Intern( ip.GetString( "y" ) );

			m_FontSize = ip.GetInt32( "s" );
			m_Interval = ip.GetInt32( "i" );
		}

		public static int LookupReportValue( Snapshot ss, string reportName, string valueName )
		{
			for ( int j = 0; j < ss.Children.Count; ++j )
			{
				Report report = ss.Children[j] as Report;

				if ( report == null || report.Name != reportName )
					continue;

				for ( int k = 0; k < report.Items.Count; ++k )
				{
					ReportItem item = report.Items[k];

					if ( item.Values[0].Value == valueName )
						return Utility.ToInt32( item.Values[1].Value );
				}

				break;
			}

			return -1;
		}

		public static BarGraph DailyAverage( SnapshotHistory history, string reportName, string valueName )
		{
			int[] totals = new int[24];
			int[] counts = new int[24];

			int min = history.Snapshots.Count - (7 * 24); // averages over one week

			if ( min < 0 )
				min = 0;

			for ( int i = min; i < history.Snapshots.Count; ++i )
			{
				Snapshot ss = history.Snapshots[i];

				int val = LookupReportValue( ss, reportName, valueName );

				if ( val == -1 )
					continue;

				int hour = ss.TimeStamp.TimeOfDay.Hours;

				totals[hour] += val;
				counts[hour]++;
			}

			BarGraph barGraph = new BarGraph( "Hourly average " + valueName, "graphs_" + valueName.ToLower() + "_avg", 10, "Time", valueName, BarGraphRenderMode.Lines );

			barGraph.m_FontSize = 6;

			for ( int i = 7; i <= totals.Length+7; ++i )
			{
				int val;

				if ( counts[i%totals.Length] == 0 )
					val = 0;
				else
					val = (totals[i%totals.Length] + (counts[i%totals.Length] / 2)) / counts[i%totals.Length];

				int realHours = i%totals.Length;
				int hours;

				if ( realHours == 0 )
					hours = 12;
				else if ( realHours > 12 )
					hours = realHours - 12;
				else
					hours = realHours;

				barGraph.Items.Add( hours + (realHours >= 12 ? " PM" : " AM"), val );
			}

			return barGraph;
		}

		public static BarGraph Growth( SnapshotHistory history, string reportName, string valueName )
		{
			BarGraph barGraph = new BarGraph( "Growth of " + valueName + " over time", "graphs_" + valueName.ToLower() + "_growth", 10, "Time", valueName, BarGraphRenderMode.Lines );

			barGraph.FontSize = 6;
			barGraph.Interval = 7;

			DateTime startPeriod = history.Snapshots[0].TimeStamp.Date + TimeSpan.FromDays( 1.0 );
			DateTime endPeriod = history.Snapshots[history.Snapshots.Count - 1].TimeStamp.Date;

			ArrayList regions = new ArrayList();

			DateTime curDate = DateTime.MinValue;
			int curPeak = -1;
			int curLow  = 1000;
			int curTotl = 0;
			int curCont = 0;
			int curValu = 0;

			for ( int i = 0; i < history.Snapshots.Count; ++i )
			{
				Snapshot ss = history.Snapshots[i];
				DateTime timeStamp = ss.TimeStamp;

				if ( timeStamp < startPeriod || timeStamp >= endPeriod )
					continue;

				int val = LookupReportValue( ss, reportName, valueName );

				if ( val == -1 )
					continue;

				DateTime thisDate = timeStamp.Date;

				if ( curDate == DateTime.MinValue )
					curDate = thisDate;

				curCont++;
				curTotl += val;
				curValu = curTotl / curCont;

				if ( curDate != thisDate && curValu >= 0 )
				{
					string mnthName = thisDate.ToString( "MMMM" );

					if ( regions.Count == 0 )
					{
						regions.Add( new BarRegion( barGraph.Items.Count, barGraph.Items.Count, mnthName ) );
					}
					else
					{
						BarRegion region = (BarRegion)regions[regions.Count - 1];

						if ( region.m_Name == mnthName )
							region.m_RangeTo = barGraph.Items.Count;
						else
							regions.Add( new BarRegion( barGraph.Items.Count, barGraph.Items.Count, mnthName ) );
					}

					barGraph.Items.Add( thisDate.Day.ToString(), curValu );

					curPeak = val;
					curLow = val;
				}
				else
				{
					if ( val > curPeak )
						curPeak = val;

					if ( val > 0 && val < curLow )
						curLow = val;
				}

				curDate = thisDate;
			}

			barGraph.Regions = (BarRegion[])regions.ToArray( typeof( BarRegion ) );

			return barGraph;
		}

		public static BarGraph OverTime( SnapshotHistory history, string reportName, string valueName, int step, int max, int ival )
		{
			BarGraph barGraph = new BarGraph( valueName + " over time", "graphs_" + valueName.ToLower() + "_ot", 10, "Time", valueName, BarGraphRenderMode.Lines );

			TimeSpan ts = TimeSpan.FromHours( (max*step)-0.5 );

			DateTime mostRecent = history.Snapshots[history.Snapshots.Count - 1].TimeStamp;
			DateTime minTime = mostRecent - ts;

			barGraph.FontSize = 6;
			barGraph.Interval = ival;

			ArrayList regions = new ArrayList();

			for ( int i = 0; i < history.Snapshots.Count; ++i )
			{
				Snapshot ss = history.Snapshots[i];
				DateTime timeStamp = ss.TimeStamp;

				if ( timeStamp < minTime )
					continue;

				if ( (i % step) != 0 )
					continue;

				int val = LookupReportValue( ss, reportName, valueName );

				if ( val == -1 )
					continue;

				int realHours = timeStamp.TimeOfDay.Hours;
				int hours;

				if ( realHours == 0 )
					hours = 12;
				else if ( realHours > 12 )
					hours = realHours - 12;
				else
					hours = realHours;

				string dayName = timeStamp.DayOfWeek.ToString();

				if ( regions.Count == 0 )
				{
					regions.Add( new BarRegion( barGraph.Items.Count, barGraph.Items.Count, dayName ) );
				}
				else
				{
					BarRegion region = (BarRegion) regions[regions.Count - 1];

					if ( region.m_Name == dayName )
						region.m_RangeTo = barGraph.Items.Count;
					else
						regions.Add( new BarRegion( barGraph.Items.Count, barGraph.Items.Count, dayName ) );
				}

				barGraph.Items.Add( hours + (realHours >= 12 ? " PM" : " AM"), val );
			}

			barGraph.Regions = (BarRegion[])regions.ToArray( typeof( BarRegion ) );

			return barGraph;
		}
	}
}

namespace Server.Engines.Reports
{
	public abstract class Chart : PersistableObject
	{
		protected string m_Name;
		protected string m_FileName;
		protected ChartItemCollection m_Items;

		public string Name{ get{ return m_Name; } set{ m_Name = value; } }
		public string FileName{ get{ return m_FileName; } set{ m_FileName = value; } }
		public ChartItemCollection Items{ get{ return m_Items; } }

		public Chart()
		{
			m_Items = new ChartItemCollection();
		}

		public override void SerializeAttributes( PersistanceWriter op )
		{
			op.SetString( "n", m_Name );
			op.SetString( "f", m_FileName );
		}

		public override void DeserializeAttributes( PersistanceReader ip )
		{
			m_Name = Utility.Intern( ip.GetString( "n" ) );
			m_FileName = Utility.Intern( ip.GetString( "f" ) );
		}

		public override void SerializeChildren( PersistanceWriter op )
		{
			for ( int i = 0; i < m_Items.Count; ++i )
				m_Items[i].Serialize( op );
		}

		public override void DeserializeChildren( PersistanceReader ip )
		{
			while ( ip.HasChild )
				m_Items.Add( ip.GetChild() as ChartItem );
		}
	}
}

namespace Server.Engines.Reports
{
	public class ChartItem : PersistableObject
	{
		#region Type Identification
		public static readonly PersistableType ThisTypeID = new PersistableType( "ci", new ConstructCallback( Construct ) );

		private static PersistableObject Construct()
		{
			return new ChartItem();
		}

		public override PersistableType TypeID{ get{ return ThisTypeID; } }
		#endregion

		private string m_Name;
		private int m_Value;

		public string Name{ get{ return m_Name; } set{ m_Name = value; } }
		public int Value{ get{ return m_Value; } set{ m_Value = value; } }

		private ChartItem()
		{
		}

		public ChartItem( string name, int value )
		{
			m_Name = name;
			m_Value = value;
		}

		public override void SerializeAttributes( PersistanceWriter op )
		{
			op.SetString( "n", m_Name );
			op.SetInt32( "v", m_Value );
		}

		public override void DeserializeAttributes( PersistanceReader ip )
		{
			m_Name = Utility.Intern( ip.GetString( "n" ) );
			m_Value = ip.GetInt32( "v" );
		}
	}
}//------------------------------------------------------------------------------
// <autogenerated>
//     This code was generated by a tool.
//     Runtime Version: 1.1.4322.573
//
//     Changes to this file may cause incorrect behavior and will be lost if 
//     the code is regenerated.
// </autogenerated>
//------------------------------------------------------------------------------

namespace Server.Engines.Reports
{
    /// <summary>
    /// Strongly typed collection of Server.Engines.Reports.ChartItem.
    /// </summary>
    public class ChartItemCollection : System.Collections.CollectionBase
    {
        
        /// <summary>
        /// Default constructor.
        /// </summary>
        public ChartItemCollection() : 
                base()
        {
        }
        
        /// <summary>
        /// Gets or sets the value of the Server.Engines.Reports.ChartItem at a specific position in the ChartItemCollection.
        /// </summary>
        public Server.Engines.Reports.ChartItem this[int index]
        {
            get
            {
                return ((Server.Engines.Reports.ChartItem)(this.List[index]));
            }
            set
            {
                this.List[index] = value;
            }
		}

		public int Add( string name, int value )
		{
			return Add( new ChartItem( name, value ) );
		}

        /// <summary>
        /// Append a Server.Engines.Reports.ChartItem entry to this collection.
        /// </summary>
        /// <param name="value">Server.Engines.Reports.ChartItem instance.</param>
        /// <returns>The position into which the new element was inserted.</returns>
        public int Add(Server.Engines.Reports.ChartItem value)
        {
            return this.List.Add(value);
        }
        
        /// <summary>
        /// Determines whether a specified Server.Engines.Reports.ChartItem instance is in this collection.
        /// </summary>
        /// <param name="value">Server.Engines.Reports.ChartItem instance to search for.</param>
        /// <returns>True if the Server.Engines.Reports.ChartItem instance is in the collection; otherwise false.</returns>
        public bool Contains(Server.Engines.Reports.ChartItem value)
        {
            return this.List.Contains(value);
        }
        
        /// <summary>
        /// Retrieve the index a specified Server.Engines.Reports.ChartItem instance is in this collection.
        /// </summary>
        /// <param name="value">Server.Engines.Reports.ChartItem instance to find.</param>
        /// <returns>The zero-based index of the specified Server.Engines.Reports.ChartItem instance. If the object is not found, the return value is -1.</returns>
        public int IndexOf(Server.Engines.Reports.ChartItem value)
        {
            return this.List.IndexOf(value);
        }
        
        /// <summary>
        /// Removes a specified Server.Engines.Reports.ChartItem instance from this collection.
        /// </summary>
        /// <param name="value">The Server.Engines.Reports.ChartItem instance to remove.</param>
        public void Remove(Server.Engines.Reports.ChartItem value)
        {
            this.List.Remove(value);
        }
        
        /// <summary>
        /// Returns an enumerator that can iterate through the Server.Engines.Reports.ChartItem instance.
        /// </summary>
        /// <returns>An Server.Engines.Reports.ChartItem's enumerator.</returns>
        public new ChartItemCollectionEnumerator GetEnumerator()
        {
            return new ChartItemCollectionEnumerator(this);
        }
        
        /// <summary>
        /// Insert a Server.Engines.Reports.ChartItem instance into this collection at a specified index.
        /// </summary>
        /// <param name="index">Zero-based index.</param>
        /// <param name="value">The Server.Engines.Reports.ChartItem instance to insert.</param>
        public void Insert(int index, Server.Engines.Reports.ChartItem value)
        {
            this.List.Insert(index, value);
        }
        
        /// <summary>
        /// Strongly typed enumerator of Server.Engines.Reports.ChartItem.
        /// </summary>
        public class ChartItemCollectionEnumerator : System.Collections.IEnumerator
        {
            
            /// <summary>
            /// Current index
            /// </summary>
            private int _index;
            
            /// <summary>
            /// Current element pointed to.
            /// </summary>
            private Server.Engines.Reports.ChartItem _currentElement;
            
            /// <summary>
            /// Collection to enumerate.
            /// </summary>
            private ChartItemCollection _collection;
            
            /// <summary>
            /// Default constructor for enumerator.
            /// </summary>
            /// <param name="collection">Instance of the collection to enumerate.</param>
            internal ChartItemCollectionEnumerator(ChartItemCollection collection)
            {
                _index = -1;
                _collection = collection;
            }
            
            /// <summary>
            /// Gets the Server.Engines.Reports.ChartItem object in the enumerated ChartItemCollection currently indexed by this instance.
            /// </summary>
            public Server.Engines.Reports.ChartItem Current
            {
                get
                {
                    if (((_index == -1) 
                                || (_index >= _collection.Count)))
                    {
                        throw new System.IndexOutOfRangeException("Enumerator not started.");
                    }
                    else
                    {
                        return _currentElement;
                    }
                }
            }
            
            /// <summary>
            /// Gets the current element in the collection.
            /// </summary>
            object IEnumerator.Current
            {
                get
                {
                    if (((_index == -1) 
                                || (_index >= _collection.Count)))
                    {
                        throw new System.IndexOutOfRangeException("Enumerator not started.");
                    }
                    else
                    {
                        return _currentElement;
                    }
                }
            }
            
            /// <summary>
            /// Reset the cursor, so it points to the beginning of the enumerator.
            /// </summary>
            public void Reset()
            {
                _index = -1;
                _currentElement = null;
            }
            
            /// <summary>
            /// Advances the enumerator to the next queue of the enumeration, if one is currently available.
            /// </summary>
            /// <returns>true, if the enumerator was succesfully advanced to the next queue; false, if the enumerator has reached the end of the enumeration.</returns>
            public bool MoveNext()
            {
                if ((_index 
                            < (_collection.Count - 1)))
                {
                    _index = (_index + 1);
                    _currentElement = this._collection[_index];
                    return true;
                }
                _index = _collection.Count;
                return false;
            }
        }
    }
}

namespace Server.Engines.Reports
{
	public class PieChart : Chart
	{
		#region Type Identification
		public static readonly PersistableType ThisTypeID = new PersistableType( "pc", new ConstructCallback( Construct ) );

		private static PersistableObject Construct()
		{
			return new PieChart();
		}

		public override PersistableType TypeID{ get{ return ThisTypeID; } }
		#endregion

		private bool m_ShowPercents;

		public bool ShowPercents{ get{ return m_ShowPercents; } set{ m_ShowPercents = value; } }

		public PieChart( string name, string fileName, bool showPercents )
		{
			m_Name = name;
			m_FileName = fileName;
			m_ShowPercents = showPercents;
		}

		private PieChart()
		{
		}

		public override void SerializeAttributes( PersistanceWriter op )
		{
			base.SerializeAttributes( op );

			op.SetBoolean( "p", m_ShowPercents );
		}

		public override void DeserializeAttributes( PersistanceReader ip )
		{
			base.DeserializeAttributes( ip );

			m_ShowPercents = ip.GetBoolean( "p" );
		}
	}
}

namespace Server.Engines.Reports
{
	public abstract class BaseInfo : IComparable
	{
		private static TimeSpan m_SortRange;

		public static TimeSpan SortRange{ get{ return m_SortRange; } set{ m_SortRange = value; } }

		private string m_Account;
		private string m_Display;
		private PageInfoCollection m_Pages;

		public string Account{ get{ return m_Account; } set{ m_Account = value; } }
		public PageInfoCollection Pages{ get{ return m_Pages; } set{ m_Pages = value; } }

		public string Display
		{
			get
			{
				if ( m_Display != null )
					return m_Display;

				if ( m_Account != null )
				{
					IAccount acct = Accounts.GetAccount( m_Account );

					if ( acct != null )
					{
						Mobile mob = null;

						for ( int i = 0; i < acct.Length; ++i )
						{
							Mobile check = acct[i];

							if ( check != null && (mob == null || check.AccessLevel > mob.AccessLevel) )
								mob = check;
						}

						if ( mob != null && mob.Name != null && mob.Name.Length > 0 )
							return ( m_Display = mob.Name );
					}
				}

				return ( m_Display = m_Account );
			}
		}

		public int GetPageCount( PageResolution res, DateTime min, DateTime max )
		{
			return StaffHistory.GetPageCount( m_Pages, res, min, max );
		}

		public BaseInfo( string account )
		{
			m_Account = account;
			m_Pages = new PageInfoCollection();
		}

		public void Register( PageInfo page )
		{
			m_Pages.Add( page );
		}

		public void Unregister( PageInfo page )
		{
			m_Pages.Remove( page );
		}

		public int CompareTo( object obj )
		{
			BaseInfo cmp = obj as BaseInfo;

			int v = cmp.GetPageCount( cmp is StaffInfo ? PageResolution.Handled : PageResolution.None, DateTime.Now - m_SortRange, DateTime.Now )
				- this.GetPageCount( this is StaffInfo ? PageResolution.Handled : PageResolution.None, DateTime.Now - m_SortRange, DateTime.Now );

			if ( v == 0 )
				v = String.Compare( this.Display, cmp.Display );

			return v;
		}
	}

	public class StaffInfo : BaseInfo
	{
		public StaffInfo( string account ) : base( account )
		{
		}
	}

	public class UserInfo : BaseInfo
	{
		public UserInfo( string account ) : base( account )
		{
		}
	}
}

namespace Server.Engines.Reports
{
	public class ItemValue : PersistableObject
	{
		#region Type Identification
		public static readonly PersistableType ThisTypeID = new PersistableType( "iv", new ConstructCallback( Construct ) );

		private static PersistableObject Construct()
		{
			return new ItemValue();
		}

		public override PersistableType TypeID{ get{ return ThisTypeID; } }
		#endregion

		private string m_Value;
		private string m_Format;

		public string Value{ get{ return m_Value; } set{ m_Value = value; } }
		public string Format{ get{ return m_Format; } set{ m_Format = value; } }

		private ItemValue()
		{
		}

		public ItemValue( string value ) : this( value, null )
		{
		}

		public ItemValue( string value, string format )
		{
			m_Value = value;
			m_Format = format;
		}

		public override void SerializeAttributes( PersistanceWriter op )
		{
			op.SetString( "v", m_Value );
			op.SetString( "f", m_Format );
		}

		public override void DeserializeAttributes( PersistanceReader ip )
		{
			m_Value = ip.GetString( "v" );
			m_Format = Utility.Intern( ip.GetString( "f" ) );

			if ( m_Format == null )
				Utility.Intern( ref m_Value );
		}
	}
}//------------------------------------------------------------------------------
// <autogenerated>
//     This code was generated by a tool.
//     Runtime Version: 1.1.4322.573
//
//     Changes to this file may cause incorrect behavior and will be lost if 
//     the code is regenerated.
// </autogenerated>
//------------------------------------------------------------------------------

namespace Server.Engines.Reports
{
    /// <summary>
    /// Strongly typed collection of Server.Engines.Reports.ItemValue.
    /// </summary>
    public class ItemValueCollection : System.Collections.CollectionBase
    {
        
        /// <summary>
        /// Default constructor.
        /// </summary>
        public ItemValueCollection() : 
                base()
        {
        }
        
        /// <summary>
        /// Gets or sets the value of the Server.Engines.Reports.ItemValue at a specific position in the ItemValueCollection.
        /// </summary>
        public Server.Engines.Reports.ItemValue this[int index]
        {
            get
            {
                return ((Server.Engines.Reports.ItemValue)(this.List[index]));
            }
            set
            {
                this.List[index] = value;
            }
        }

		public int Add( string value )
		{
			return Add( new ItemValue( value ) );
		}

		public int Add( string value, string format )
		{
			return Add( new ItemValue( value, format ) );
		}

        /// <summary>
        /// Append a Server.Engines.Reports.ItemValue entry to this collection.
        /// </summary>
        /// <param name="value">Server.Engines.Reports.ItemValue instance.</param>
        /// <returns>The position into which the new element was inserted.</returns>
        public int Add(Server.Engines.Reports.ItemValue value)
        {
            return this.List.Add(value);
        }
        
        /// <summary>
        /// Determines whether a specified Server.Engines.Reports.ItemValue instance is in this collection.
        /// </summary>
        /// <param name="value">Server.Engines.Reports.ItemValue instance to search for.</param>
        /// <returns>True if the Server.Engines.Reports.ItemValue instance is in the collection; otherwise false.</returns>
        public bool Contains(Server.Engines.Reports.ItemValue value)
        {
            return this.List.Contains(value);
        }
        
        /// <summary>
        /// Retrieve the index a specified Server.Engines.Reports.ItemValue instance is in this collection.
        /// </summary>
        /// <param name="value">Server.Engines.Reports.ItemValue instance to find.</param>
        /// <returns>The zero-based index of the specified Server.Engines.Reports.ItemValue instance. If the object is not found, the return value is -1.</returns>
        public int IndexOf(Server.Engines.Reports.ItemValue value)
        {
            return this.List.IndexOf(value);
        }
        
        /// <summary>
        /// Removes a specified Server.Engines.Reports.ItemValue instance from this collection.
        /// </summary>
        /// <param name="value">The Server.Engines.Reports.ItemValue instance to remove.</param>
        public void Remove(Server.Engines.Reports.ItemValue value)
        {
            this.List.Remove(value);
        }
        
        /// <summary>
        /// Returns an enumerator that can iterate through the Server.Engines.Reports.ItemValue instance.
        /// </summary>
        /// <returns>An Server.Engines.Reports.ItemValue's enumerator.</returns>
        public new ItemValueCollectionEnumerator GetEnumerator()
        {
            return new ItemValueCollectionEnumerator(this);
        }
        
        /// <summary>
        /// Insert a Server.Engines.Reports.ItemValue instance into this collection at a specified index.
        /// </summary>
        /// <param name="index">Zero-based index.</param>
        /// <param name="value">The Server.Engines.Reports.ItemValue instance to insert.</param>
        public void Insert(int index, Server.Engines.Reports.ItemValue value)
        {
            this.List.Insert(index, value);
        }
        
        /// <summary>
        /// Strongly typed enumerator of Server.Engines.Reports.ItemValue.
        /// </summary>
        public class ItemValueCollectionEnumerator : System.Collections.IEnumerator
        {
            
            /// <summary>
            /// Current index
            /// </summary>
            private int _index;
            
            /// <summary>
            /// Current element pointed to.
            /// </summary>
            private Server.Engines.Reports.ItemValue _currentElement;
            
            /// <summary>
            /// Collection to enumerate.
            /// </summary>
            private ItemValueCollection _collection;
            
            /// <summary>
            /// Default constructor for enumerator.
            /// </summary>
            /// <param name="collection">Instance of the collection to enumerate.</param>
            internal ItemValueCollectionEnumerator(ItemValueCollection collection)
            {
                _index = -1;
                _collection = collection;
            }
            
            /// <summary>
            /// Gets the Server.Engines.Reports.ItemValue object in the enumerated ItemValueCollection currently indexed by this instance.
            /// </summary>
            public Server.Engines.Reports.ItemValue Current
            {
                get
                {
                    if (((_index == -1) 
                                || (_index >= _collection.Count)))
                    {
                        throw new System.IndexOutOfRangeException("Enumerator not started.");
                    }
                    else
                    {
                        return _currentElement;
                    }
                }
            }
            
            /// <summary>
            /// Gets the current element in the collection.
            /// </summary>
            object IEnumerator.Current
            {
                get
                {
                    if (((_index == -1) 
                                || (_index >= _collection.Count)))
                    {
                        throw new System.IndexOutOfRangeException("Enumerator not started.");
                    }
                    else
                    {
                        return _currentElement;
                    }
                }
            }
            
            /// <summary>
            /// Reset the cursor, so it points to the beginning of the enumerator.
            /// </summary>
            public void Reset()
            {
                _index = -1;
                _currentElement = null;
            }
            
            /// <summary>
            /// Advances the enumerator to the next queue of the enumeration, if one is currently available.
            /// </summary>
            /// <returns>true, if the enumerator was succesfully advanced to the next queue; false, if the enumerator has reached the end of the enumeration.</returns>
            public bool MoveNext()
            {
                if ((_index 
                            < (_collection.Count - 1)))
                {
                    _index = (_index + 1);
                    _currentElement = this._collection[_index];
                    return true;
                }
                _index = _collection.Count;
                return false;
            }
        }
    }
}

namespace Server.Engines.Reports
{
	public enum PageResolution
	{
		None,
		Handled,
		Deleted,
		Logged,
		Canceled
	}

	public class PageInfo : PersistableObject
	{
		#region Type Identification
		public static readonly PersistableType ThisTypeID = new PersistableType( "pi", new ConstructCallback( Construct ) );

		private static PersistableObject Construct()
		{
			return new PageInfo();
		}

		public override PersistableType TypeID{ get{ return ThisTypeID; } }
		#endregion

		private StaffHistory m_History;
		private StaffInfo m_Resolver;
		private UserInfo m_Sender;

		public StaffInfo Resolver
		{
			get{ return m_Resolver; }
			set
			{
				if ( m_Resolver == value )
					return;

				lock ( StaffHistory.RenderLock )
				{
					if ( m_Resolver != null )
						m_Resolver.Unregister( this );

					m_Resolver = value;

					if ( m_Resolver != null )
						m_Resolver.Register( this );
				}
			}
		}

		public UserInfo Sender
		{
			get{ return m_Sender; }
			set
			{
				if ( m_Sender == value )
					return;

				lock ( StaffHistory.RenderLock )
				{
					if ( m_Sender != null )
						m_Sender.Unregister( this );

					m_Sender = value;

					if ( m_Sender != null )
						m_Sender.Register( this );
				}
			}
		}

		private PageType m_PageType;
		private PageResolution m_Resolution;

		private DateTime m_TimeSent;
		private DateTime m_TimeResolved;

		private string m_SentBy;
		private string m_ResolvedBy;

		private string m_Message;
		private ResponseInfoCollection m_Responses;

		public StaffHistory History
		{
			get{ return m_History; }
			set
			{
				if ( m_History == value )
					return;

				if ( m_History != null )
				{
					Sender = null;
					Resolver = null;
				}

				m_History = value;

				if ( m_History != null )
				{
					Sender = m_History.GetUserInfo( m_SentBy );
					UpdateResolver();
				}
			}
		}

		public PageType PageType{ get{ return m_PageType; } set{ m_PageType = value; } }
		public PageResolution Resolution{ get{ return m_Resolution; } }

		public DateTime TimeSent{ get{ return m_TimeSent; } set{ m_TimeSent = value; } }
		public DateTime TimeResolved{ get{ return m_TimeResolved; } }

		public string SentBy
		{
			get{ return m_SentBy; }
			set
			{
				m_SentBy = value;

				if ( m_History != null )
					Sender = m_History.GetUserInfo( m_SentBy );
			}
		}

		public string ResolvedBy
		{
			get{ return m_ResolvedBy; }
		}

		public string Message{ get{ return m_Message; } set{ m_Message = value; } }
		public ResponseInfoCollection Responses{ get{ return m_Responses; } set{ m_Responses = value; } }

		public void UpdateResolver()
		{
			string resolvedBy;
			DateTime timeResolved;
			PageResolution res = GetResolution( out resolvedBy, out timeResolved ); 

			if ( m_History != null && IsStaffResolution( res ) )
				Resolver = m_History.GetStaffInfo( resolvedBy );
			else
				Resolver = null;

			m_ResolvedBy = resolvedBy;
			m_TimeResolved = timeResolved;
			m_Resolution = res;
		}

		public bool IsStaffResolution( PageResolution res )
		{
			return ( res == PageResolution.Handled );
		}

		public static PageResolution ResFromResp( string resp )
		{
			switch ( resp )
			{
				case "[Handled]":	return PageResolution.Handled;
				case "[Deleting]":	return PageResolution.Deleted;
				case "[Logout]":	return PageResolution.Logged;
				case "[Canceled]":	return PageResolution.Canceled;
			}

			return PageResolution.None;
		}

		public PageResolution GetResolution( out string resolvedBy, out DateTime timeResolved )
		{
			for ( int i = m_Responses.Count - 1; i >= 0; --i )
			{
				ResponseInfo resp = m_Responses[i];
				PageResolution res = ResFromResp( resp.Message );

				if ( res != PageResolution.None )
				{
					resolvedBy = resp.SentBy;
					timeResolved = resp.TimeStamp;
					return res;
				}
			}

			resolvedBy = m_SentBy;
			timeResolved = m_TimeSent;
			return PageResolution.None;
		}

		public static string GetAccount( Mobile mob )
		{
			if ( mob == null )
				return null;

			Accounting.Account acct = mob.Account as Accounting.Account;

			if ( acct == null )
				return null;

			return acct.Username;
		}

		public PageInfo()
		{
			m_Responses = new ResponseInfoCollection();
		}

		public PageInfo( PageEntry entry )
		{
			m_PageType = entry.Type;

			m_TimeSent = entry.Sent;
			m_SentBy = GetAccount( entry.Sender );

			m_Message = entry.Message;
			m_Responses = new ResponseInfoCollection();
		}

		public override void SerializeAttributes( PersistanceWriter op )
		{
			op.SetInt32( "p", (int)m_PageType );

			op.SetDateTime( "ts", m_TimeSent );
			op.SetString( "s", m_SentBy );

			op.SetString( "m", m_Message );
		}

		public override void DeserializeAttributes( PersistanceReader ip )
		{
			m_PageType = (PageType) ip.GetInt32( "p" );

			m_TimeSent = ip.GetDateTime( "ts" );
			m_SentBy = ip.GetString( "s" );

			m_Message = ip.GetString( "m" );
		}

		public override void SerializeChildren( PersistanceWriter op )
		{
			lock ( this )
			{
				for ( int i = 0; i < m_Responses.Count; ++i )
					m_Responses[i].Serialize( op );
			}
		}

		public override void DeserializeChildren( PersistanceReader ip )
		{
			while ( ip.HasChild )
				m_Responses.Add( ip.GetChild() as ResponseInfo );
		}
	}
}//------------------------------------------------------------------------------
// <autogenerated>
//     This code was generated by a tool.
//     Runtime Version: 1.1.4322.573
//
//     Changes to this file may cause incorrect behavior and will be lost if 
//     the code is regenerated.
// </autogenerated>
//------------------------------------------------------------------------------

namespace Server.Engines.Reports
{
    /// <summary>
    /// Strongly typed collection of Server.Engines.Reports.PageInfo.
    /// </summary>
    public class PageInfoCollection : System.Collections.CollectionBase
    {
        
        /// <summary>
        /// Default constructor.
        /// </summary>
        public PageInfoCollection() : 
                base()
        {
        }
        
        /// <summary>
        /// Gets or sets the value of the Server.Engines.Reports.PageInfo at a specific position in the PageInfoCollection.
        /// </summary>
        public Server.Engines.Reports.PageInfo this[int index]
        {
            get
            {
                return ((Server.Engines.Reports.PageInfo)(this.List[index]));
            }
            set
            {
                this.List[index] = value;
            }
        }
        
        /// <summary>
        /// Append a Server.Engines.Reports.PageInfo entry to this collection.
        /// </summary>
        /// <param name="value">Server.Engines.Reports.PageInfo instance.</param>
        /// <returns>The position into which the new element was inserted.</returns>
        public int Add(Server.Engines.Reports.PageInfo value)
        {
            return this.List.Add(value);
        }
        
        /// <summary>
        /// Determines whether a specified Server.Engines.Reports.PageInfo instance is in this collection.
        /// </summary>
        /// <param name="value">Server.Engines.Reports.PageInfo instance to search for.</param>
        /// <returns>True if the Server.Engines.Reports.PageInfo instance is in the collection; otherwise false.</returns>
        public bool Contains(Server.Engines.Reports.PageInfo value)
        {
            return this.List.Contains(value);
        }
        
        /// <summary>
        /// Retrieve the index a specified Server.Engines.Reports.PageInfo instance is in this collection.
        /// </summary>
        /// <param name="value">Server.Engines.Reports.PageInfo instance to find.</param>
        /// <returns>The zero-based index of the specified Server.Engines.Reports.PageInfo instance. If the object is not found, the return value is -1.</returns>
        public int IndexOf(Server.Engines.Reports.PageInfo value)
        {
            return this.List.IndexOf(value);
        }
        
        /// <summary>
        /// Removes a specified Server.Engines.Reports.PageInfo instance from this collection.
        /// </summary>
        /// <param name="value">The Server.Engines.Reports.PageInfo instance to remove.</param>
        public void Remove(Server.Engines.Reports.PageInfo value)
        {
            this.List.Remove(value);
        }
        
        /// <summary>
        /// Returns an enumerator that can iterate through the Server.Engines.Reports.PageInfo instance.
        /// </summary>
        /// <returns>An Server.Engines.Reports.PageInfo's enumerator.</returns>
        public new PageInfoCollectionEnumerator GetEnumerator()
        {
            return new PageInfoCollectionEnumerator(this);
        }
        
        /// <summary>
        /// Insert a Server.Engines.Reports.PageInfo instance into this collection at a specified index.
        /// </summary>
        /// <param name="index">Zero-based index.</param>
        /// <param name="value">The Server.Engines.Reports.PageInfo instance to insert.</param>
        public void Insert(int index, Server.Engines.Reports.PageInfo value)
        {
            this.List.Insert(index, value);
        }
        
        /// <summary>
        /// Strongly typed enumerator of Server.Engines.Reports.PageInfo.
        /// </summary>
        public class PageInfoCollectionEnumerator : System.Collections.IEnumerator
        {
            
            /// <summary>
            /// Current index
            /// </summary>
            private int _index;
            
            /// <summary>
            /// Current element pointed to.
            /// </summary>
            private Server.Engines.Reports.PageInfo _currentElement;
            
            /// <summary>
            /// Collection to enumerate.
            /// </summary>
            private PageInfoCollection _collection;
            
            /// <summary>
            /// Default constructor for enumerator.
            /// </summary>
            /// <param name="collection">Instance of the collection to enumerate.</param>
            internal PageInfoCollectionEnumerator(PageInfoCollection collection)
            {
                _index = -1;
                _collection = collection;
            }
            
            /// <summary>
            /// Gets the Server.Engines.Reports.PageInfo object in the enumerated PageInfoCollection currently indexed by this instance.
            /// </summary>
            public Server.Engines.Reports.PageInfo Current
            {
                get
                {
                    if (((_index == -1) 
                                || (_index >= _collection.Count)))
                    {
                        throw new System.IndexOutOfRangeException("Enumerator not started.");
                    }
                    else
                    {
                        return _currentElement;
                    }
                }
            }
            
            /// <summary>
            /// Gets the current element in the collection.
            /// </summary>
            object IEnumerator.Current
            {
                get
                {
                    if (((_index == -1) 
                                || (_index >= _collection.Count)))
                    {
                        throw new System.IndexOutOfRangeException("Enumerator not started.");
                    }
                    else
                    {
                        return _currentElement;
                    }
                }
            }
            
            /// <summary>
            /// Reset the cursor, so it points to the beginning of the enumerator.
            /// </summary>
            public void Reset()
            {
                _index = -1;
                _currentElement = null;
            }
            
            /// <summary>
            /// Advances the enumerator to the next queue of the enumeration, if one is currently available.
            /// </summary>
            /// <returns>true, if the enumerator was succesfully advanced to the next queue; false, if the enumerator has reached the end of the enumeration.</returns>
            public bool MoveNext()
            {
                if ((_index 
                            < (_collection.Count - 1)))
                {
                    _index = (_index + 1);
                    _currentElement = this._collection[_index];
                    return true;
                }
                _index = _collection.Count;
                return false;
            }
        }
    }
}

namespace Server.Engines.Reports
{
	public class QueueStatus : PersistableObject
	{
		#region Type Identification
		public static readonly PersistableType ThisTypeID = new PersistableType( "qs", new ConstructCallback( Construct ) );

		private static PersistableObject Construct()
		{
			return new QueueStatus();
		}

		public override PersistableType TypeID{ get{ return ThisTypeID; } }
		#endregion

		private DateTime m_TimeStamp;
		private int m_Count;

		public DateTime TimeStamp{ get{ return m_TimeStamp; } set{ m_TimeStamp = value; } }
		public int Count{ get{ return m_Count; } set{ m_Count = value; } }

		public QueueStatus()
		{
		}

		public QueueStatus( int count )
		{
			m_TimeStamp = DateTime.Now;
			m_Count = count;
		}

		public override void SerializeAttributes( PersistanceWriter op )
		{
			op.SetDateTime( "t", m_TimeStamp );
			op.SetInt32( "c", m_Count );
		}

		public override void DeserializeAttributes( PersistanceReader ip )
		{
			m_TimeStamp = ip.GetDateTime( "t" );
			m_Count = ip.GetInt32( "c" );
		}
	}
}//------------------------------------------------------------------------------
// <autogenerated>
//     This code was generated by a tool.
//     Runtime Version: 1.1.4322.573
//
//     Changes to this file may cause incorrect behavior and will be lost if 
//     the code is regenerated.
// </autogenerated>
//------------------------------------------------------------------------------

namespace Server.Engines.Reports
{
    /// <summary>
    /// Strongly typed collection of Server.Engines.Reports.QueueStatus.
    /// </summary>
    public class QueueStatusCollection : System.Collections.CollectionBase
    {
        
        /// <summary>
        /// Default constructor.
        /// </summary>
        public QueueStatusCollection() : 
                base()
        {
        }
        
        /// <summary>
        /// Gets or sets the value of the Server.Engines.Reports.QueueStatus at a specific position in the QueueStatusCollection.
        /// </summary>
        public Server.Engines.Reports.QueueStatus this[int index]
        {
            get
            {
                return ((Server.Engines.Reports.QueueStatus)(this.List[index]));
            }
            set
            {
                this.List[index] = value;
            }
        }
        
        /// <summary>
        /// Append a Server.Engines.Reports.QueueStatus entry to this collection.
        /// </summary>
        /// <param name="value">Server.Engines.Reports.QueueStatus instance.</param>
        /// <returns>The position into which the new element was inserted.</returns>
        public int Add(Server.Engines.Reports.QueueStatus value)
        {
            return this.List.Add(value);
        }
        
        /// <summary>
        /// Determines whether a specified Server.Engines.Reports.QueueStatus instance is in this collection.
        /// </summary>
        /// <param name="value">Server.Engines.Reports.QueueStatus instance to search for.</param>
        /// <returns>True if the Server.Engines.Reports.QueueStatus instance is in the collection; otherwise false.</returns>
        public bool Contains(Server.Engines.Reports.QueueStatus value)
        {
            return this.List.Contains(value);
        }
        
        /// <summary>
        /// Retrieve the index a specified Server.Engines.Reports.QueueStatus instance is in this collection.
        /// </summary>
        /// <param name="value">Server.Engines.Reports.QueueStatus instance to find.</param>
        /// <returns>The zero-based index of the specified Server.Engines.Reports.QueueStatus instance. If the object is not found, the return value is -1.</returns>
        public int IndexOf(Server.Engines.Reports.QueueStatus value)
        {
            return this.List.IndexOf(value);
        }
        
        /// <summary>
        /// Removes a specified Server.Engines.Reports.QueueStatus instance from this collection.
        /// </summary>
        /// <param name="value">The Server.Engines.Reports.QueueStatus instance to remove.</param>
        public void Remove(Server.Engines.Reports.QueueStatus value)
        {
            this.List.Remove(value);
        }
        
        /// <summary>
        /// Returns an enumerator that can iterate through the Server.Engines.Reports.QueueStatus instance.
        /// </summary>
        /// <returns>An Server.Engines.Reports.QueueStatus's enumerator.</returns>
        public new QueueStatusCollectionEnumerator GetEnumerator()
        {
            return new QueueStatusCollectionEnumerator(this);
        }
        
        /// <summary>
        /// Insert a Server.Engines.Reports.QueueStatus instance into this collection at a specified index.
        /// </summary>
        /// <param name="index">Zero-based index.</param>
        /// <param name="value">The Server.Engines.Reports.QueueStatus instance to insert.</param>
        public void Insert(int index, Server.Engines.Reports.QueueStatus value)
        {
            this.List.Insert(index, value);
        }
        
        /// <summary>
        /// Strongly typed enumerator of Server.Engines.Reports.QueueStatus.
        /// </summary>
        public class QueueStatusCollectionEnumerator : System.Collections.IEnumerator
        {
            
            /// <summary>
            /// Current index
            /// </summary>
            private int _index;
            
            /// <summary>
            /// Current element pointed to.
            /// </summary>
            private Server.Engines.Reports.QueueStatus _currentElement;
            
            /// <summary>
            /// Collection to enumerate.
            /// </summary>
            private QueueStatusCollection _collection;
            
            /// <summary>
            /// Default constructor for enumerator.
            /// </summary>
            /// <param name="collection">Instance of the collection to enumerate.</param>
            internal QueueStatusCollectionEnumerator(QueueStatusCollection collection)
            {
                _index = -1;
                _collection = collection;
            }
            
            /// <summary>
            /// Gets the Server.Engines.Reports.QueueStatus object in the enumerated QueueStatusCollection currently indexed by this instance.
            /// </summary>
            public Server.Engines.Reports.QueueStatus Current
            {
                get
                {
                    if (((_index == -1) 
                                || (_index >= _collection.Count)))
                    {
                        throw new System.IndexOutOfRangeException("Enumerator not started.");
                    }
                    else
                    {
                        return _currentElement;
                    }
                }
            }
            
            /// <summary>
            /// Gets the current element in the collection.
            /// </summary>
            object IEnumerator.Current
            {
                get
                {
                    if (((_index == -1) 
                                || (_index >= _collection.Count)))
                    {
                        throw new System.IndexOutOfRangeException("Enumerator not started.");
                    }
                    else
                    {
                        return _currentElement;
                    }
                }
            }
            
            /// <summary>
            /// Reset the cursor, so it points to the beginning of the enumerator.
            /// </summary>
            public void Reset()
            {
                _index = -1;
                _currentElement = null;
            }
            
            /// <summary>
            /// Advances the enumerator to the next queue of the enumeration, if one is currently available.
            /// </summary>
            /// <returns>true, if the enumerator was succesfully advanced to the next queue; false, if the enumerator has reached the end of the enumeration.</returns>
            public bool MoveNext()
            {
                if ((_index 
                            < (_collection.Count - 1)))
                {
                    _index = (_index + 1);
                    _currentElement = this._collection[_index];
                    return true;
                }
                _index = _collection.Count;
                return false;
            }
        }
    }
}

namespace Server.Engines.Reports
{
	public class Report : PersistableObject
	{
		#region Type Identification
		public static readonly PersistableType ThisTypeID = new PersistableType( "rp", new ConstructCallback( Construct ) );

		private static PersistableObject Construct()
		{
			return new Report();
		}

		public override PersistableType TypeID{ get{ return ThisTypeID; } }
		#endregion

		private string m_Name;
		private string m_Width;
		private ReportColumnCollection m_Columns;
		private ReportItemCollection m_Items;

		public string Name{ get{ return m_Name; } set{ m_Name = value; } }
		public string Width{ get{ return m_Width; } set{ m_Width = value; } }
		public ReportColumnCollection Columns{ get{ return m_Columns; } }
		public ReportItemCollection Items{ get{ return m_Items; } }

		private Report() : this( null, null )
		{
		}

		public Report( string name, string width )
		{
			m_Name = name;
			m_Width = width;
			m_Columns = new ReportColumnCollection();
			m_Items = new ReportItemCollection();
		}

		public override void SerializeAttributes( PersistanceWriter op )
		{
			op.SetString( "n", m_Name );
			op.SetString( "w", m_Width );
		}

		public override void DeserializeAttributes( PersistanceReader ip )
		{
			m_Name = Utility.Intern( ip.GetString( "n" ) );
			m_Width = Utility.Intern( ip.GetString( "w" ) );
		}

		public override void SerializeChildren( PersistanceWriter op )
		{
			for ( int i = 0; i < m_Columns.Count; ++i )
				m_Columns[i].Serialize( op );

			for ( int i = 0; i < m_Items.Count; ++i )
				m_Items[i].Serialize( op );
		}

		public override void DeserializeChildren( PersistanceReader ip )
		{
			while ( ip.HasChild )
			{
				PersistableObject child = ip.GetChild();

				if ( child is ReportColumn )
					m_Columns.Add( (ReportColumn) child );
				else if ( child is ReportItem )
					m_Items.Add( (ReportItem) child );
			}
		}
	}
}

namespace Server.Engines.Reports
{
	public class ReportColumn : PersistableObject
	{
		#region Type Identification
		public static readonly PersistableType ThisTypeID = new PersistableType( "rc", new ConstructCallback( Construct ) );

		private static PersistableObject Construct()
		{
			return new ReportColumn();
		}

		public override PersistableType TypeID{ get{ return ThisTypeID; } }
		#endregion

		private string m_Width;
		private string m_Align;
		private string m_Name;

		public string Width{ get{ return m_Width; } set{ m_Width = value; } }
		public string Align{ get{ return m_Align; } set{ m_Align = value; } }
		public string Name{ get{ return m_Name; } set{ m_Name = value; } }

		private ReportColumn()
		{
		}

		public ReportColumn( string width, string align ) : this( width, align, null )
		{
		}

		public ReportColumn( string width, string align, string name )
		{
			m_Width = width;
			m_Align = align;
			m_Name = name;
		}

		public override void SerializeAttributes( PersistanceWriter op )
		{
			op.SetString( "w", m_Width );
			op.SetString( "a", m_Align );
			op.SetString( "n", m_Name );
		}

		public override void DeserializeAttributes( PersistanceReader ip )
		{
			m_Width = Utility.Intern( ip.GetString( "w" ) );
			m_Align = Utility.Intern( ip.GetString( "a" ) );
			m_Name = Utility.Intern( ip.GetString( "n" ) );
		}
	}
}//------------------------------------------------------------------------------
// <autogenerated>
//     This code was generated by a tool.
//     Runtime Version: 1.1.4322.573
//
//     Changes to this file may cause incorrect behavior and will be lost if 
//     the code is regenerated.
// </autogenerated>
//------------------------------------------------------------------------------

namespace Server.Engines.Reports
{
    /// <summary>
    /// Strongly typed collection of Server.Engines.Reports.ReportColumn.
    /// </summary>
    public class ReportColumnCollection : System.Collections.CollectionBase
    {
        
        /// <summary>
        /// Default constructor.
        /// </summary>
        public ReportColumnCollection() : 
                base()
        {
        }
        
        /// <summary>
        /// Gets or sets the value of the Server.Engines.Reports.ReportColumn at a specific position in the ReportColumnCollection.
        /// </summary>
        public Server.Engines.Reports.ReportColumn this[int index]
        {
            get
            {
                return ((Server.Engines.Reports.ReportColumn)(this.List[index]));
            }
            set
            {
                this.List[index] = value;
            }
        }

		public int Add( string width, string align )
		{
			return Add( new ReportColumn( width, align ) );
		}

		public int Add( string width, string align, string name )
		{
			return Add( new ReportColumn( width, align, name ) );
		}

        /// <summary>
        /// Append a Server.Engines.Reports.ReportColumn entry to this collection.
        /// </summary>
        /// <param name="value">Server.Engines.Reports.ReportColumn instance.</param>
        /// <returns>The position into which the new element was inserted.</returns>
        public int Add(Server.Engines.Reports.ReportColumn value)
        {
            return this.List.Add(value);
        }
        
        /// <summary>
        /// Determines whether a specified Server.Engines.Reports.ReportColumn instance is in this collection.
        /// </summary>
        /// <param name="value">Server.Engines.Reports.ReportColumn instance to search for.</param>
        /// <returns>True if the Server.Engines.Reports.ReportColumn instance is in the collection; otherwise false.</returns>
        public bool Contains(Server.Engines.Reports.ReportColumn value)
        {
            return this.List.Contains(value);
        }
        
        /// <summary>
        /// Retrieve the index a specified Server.Engines.Reports.ReportColumn instance is in this collection.
        /// </summary>
        /// <param name="value">Server.Engines.Reports.ReportColumn instance to find.</param>
        /// <returns>The zero-based index of the specified Server.Engines.Reports.ReportColumn instance. If the object is not found, the return value is -1.</returns>
        public int IndexOf(Server.Engines.Reports.ReportColumn value)
        {
            return this.List.IndexOf(value);
        }
        
        /// <summary>
        /// Removes a specified Server.Engines.Reports.ReportColumn instance from this collection.
        /// </summary>
        /// <param name="value">The Server.Engines.Reports.ReportColumn instance to remove.</param>
        public void Remove(Server.Engines.Reports.ReportColumn value)
        {
            this.List.Remove(value);
        }
        
        /// <summary>
        /// Returns an enumerator that can iterate through the Server.Engines.Reports.ReportColumn instance.
        /// </summary>
        /// <returns>An Server.Engines.Reports.ReportColumn's enumerator.</returns>
        public new ReportColumnCollectionEnumerator GetEnumerator()
        {
            return new ReportColumnCollectionEnumerator(this);
        }
        
        /// <summary>
        /// Insert a Server.Engines.Reports.ReportColumn instance into this collection at a specified index.
        /// </summary>
        /// <param name="index">Zero-based index.</param>
        /// <param name="value">The Server.Engines.Reports.ReportColumn instance to insert.</param>
        public void Insert(int index, Server.Engines.Reports.ReportColumn value)
        {
            this.List.Insert(index, value);
        }
        
        /// <summary>
        /// Strongly typed enumerator of Server.Engines.Reports.ReportColumn.
        /// </summary>
        public class ReportColumnCollectionEnumerator : System.Collections.IEnumerator
        {
            
            /// <summary>
            /// Current index
            /// </summary>
            private int _index;
            
            /// <summary>
            /// Current element pointed to.
            /// </summary>
            private Server.Engines.Reports.ReportColumn _currentElement;
            
            /// <summary>
            /// Collection to enumerate.
            /// </summary>
            private ReportColumnCollection _collection;
            
            /// <summary>
            /// Default constructor for enumerator.
            /// </summary>
            /// <param name="collection">Instance of the collection to enumerate.</param>
            internal ReportColumnCollectionEnumerator(ReportColumnCollection collection)
            {
                _index = -1;
                _collection = collection;
            }
            
            /// <summary>
            /// Gets the Server.Engines.Reports.ReportColumn object in the enumerated ReportColumnCollection currently indexed by this instance.
            /// </summary>
            public Server.Engines.Reports.ReportColumn Current
            {
                get
                {
                    if (((_index == -1) 
                                || (_index >= _collection.Count)))
                    {
                        throw new System.IndexOutOfRangeException("Enumerator not started.");
                    }
                    else
                    {
                        return _currentElement;
                    }
                }
            }
            
            /// <summary>
            /// Gets the current element in the collection.
            /// </summary>
            object IEnumerator.Current
            {
                get
                {
                    if (((_index == -1) 
                                || (_index >= _collection.Count)))
                    {
                        throw new System.IndexOutOfRangeException("Enumerator not started.");
                    }
                    else
                    {
                        return _currentElement;
                    }
                }
            }
            
            /// <summary>
            /// Reset the cursor, so it points to the beginning of the enumerator.
            /// </summary>
            public void Reset()
            {
                _index = -1;
                _currentElement = null;
            }
            
            /// <summary>
            /// Advances the enumerator to the next queue of the enumeration, if one is currently available.
            /// </summary>
            /// <returns>true, if the enumerator was succesfully advanced to the next queue; false, if the enumerator has reached the end of the enumeration.</returns>
            public bool MoveNext()
            {
                if ((_index 
                            < (_collection.Count - 1)))
                {
                    _index = (_index + 1);
                    _currentElement = this._collection[_index];
                    return true;
                }
                _index = _collection.Count;
                return false;
            }
        }
    }
}

namespace Server.Engines.Reports
{
	public class ReportItem : PersistableObject
	{
		#region Type Identification
		public static readonly PersistableType ThisTypeID = new PersistableType( "ri", new ConstructCallback( Construct ) );

		private static PersistableObject Construct()
		{
			return new ReportItem();
		}

		public override PersistableType TypeID{ get{ return ThisTypeID; } }
		#endregion

		private ItemValueCollection m_Values;

		public ItemValueCollection Values{ get{ return m_Values; } }

		public ReportItem()
		{
			m_Values = new ItemValueCollection();
		}

		public override void SerializeChildren( PersistanceWriter op )
		{
			for ( int i = 0; i < m_Values.Count; ++i )
				m_Values[i].Serialize( op );
		}

		public override void DeserializeChildren( PersistanceReader ip )
		{
			while ( ip.HasChild )
				m_Values.Add( ip.GetChild() as ItemValue );
		}
	}
}//------------------------------------------------------------------------------
// <autogenerated>
//     This code was generated by a tool.
//     Runtime Version: 1.1.4322.573
//
//     Changes to this file may cause incorrect behavior and will be lost if 
//     the code is regenerated.
// </autogenerated>
//------------------------------------------------------------------------------

namespace Server.Engines.Reports
{
    /// <summary>
    /// Strongly typed collection of Server.Engines.Reports.ReportItem.
    /// </summary>
    public class ReportItemCollection : System.Collections.CollectionBase
    {
        
        /// <summary>
        /// Default constructor.
        /// </summary>
        public ReportItemCollection() : 
                base()
        {
        }
        
        /// <summary>
        /// Gets or sets the value of the Server.Engines.Reports.ReportItem at a specific position in the ReportItemCollection.
        /// </summary>
        public Server.Engines.Reports.ReportItem this[int index]
        {
            get
            {
                return ((Server.Engines.Reports.ReportItem)(this.List[index]));
            }
            set
            {
                this.List[index] = value;
            }
		}

		public int Add( string name, object value )
		{
			return Add( name, value, null );
		}

		public int Add( string name, object value, string format )
		{
			ReportItem item = new ReportItem();

			item.Values.Add( name );
			item.Values.Add( value == null ? "" : value.ToString(), format );

			return Add( item );
		}
        
        /// <summary>
        /// Append a Server.Engines.Reports.ReportItem entry to this collection.
        /// </summary>
        /// <param name="value">Server.Engines.Reports.ReportItem instance.</param>
        /// <returns>The position into which the new element was inserted.</returns>
        public int Add(Server.Engines.Reports.ReportItem value)
        {
            return this.List.Add(value);
        }
        
        /// <summary>
        /// Determines whether a specified Server.Engines.Reports.ReportItem instance is in this collection.
        /// </summary>
        /// <param name="value">Server.Engines.Reports.ReportItem instance to search for.</param>
        /// <returns>True if the Server.Engines.Reports.ReportItem instance is in the collection; otherwise false.</returns>
        public bool Contains(Server.Engines.Reports.ReportItem value)
        {
            return this.List.Contains(value);
        }
        
        /// <summary>
        /// Retrieve the index a specified Server.Engines.Reports.ReportItem instance is in this collection.
        /// </summary>
        /// <param name="value">Server.Engines.Reports.ReportItem instance to find.</param>
        /// <returns>The zero-based index of the specified Server.Engines.Reports.ReportItem instance. If the object is not found, the return value is -1.</returns>
        public int IndexOf(Server.Engines.Reports.ReportItem value)
        {
            return this.List.IndexOf(value);
        }
        
        /// <summary>
        /// Removes a specified Server.Engines.Reports.ReportItem instance from this collection.
        /// </summary>
        /// <param name="value">The Server.Engines.Reports.ReportItem instance to remove.</param>
        public void Remove(Server.Engines.Reports.ReportItem value)
        {
            this.List.Remove(value);
        }
        
        /// <summary>
        /// Returns an enumerator that can iterate through the Server.Engines.Reports.ReportItem instance.
        /// </summary>
        /// <returns>An Server.Engines.Reports.ReportItem's enumerator.</returns>
        public new ReportItemCollectionEnumerator GetEnumerator()
        {
            return new ReportItemCollectionEnumerator(this);
        }
        
        /// <summary>
        /// Insert a Server.Engines.Reports.ReportItem instance into this collection at a specified index.
        /// </summary>
        /// <param name="index">Zero-based index.</param>
        /// <param name="value">The Server.Engines.Reports.ReportItem instance to insert.</param>
        public void Insert(int index, Server.Engines.Reports.ReportItem value)
        {
            this.List.Insert(index, value);
        }
        
        /// <summary>
        /// Strongly typed enumerator of Server.Engines.Reports.ReportItem.
        /// </summary>
        public class ReportItemCollectionEnumerator : System.Collections.IEnumerator
        {
            
            /// <summary>
            /// Current index
            /// </summary>
            private int _index;
            
            /// <summary>
            /// Current element pointed to.
            /// </summary>
            private Server.Engines.Reports.ReportItem _currentElement;
            
            /// <summary>
            /// Collection to enumerate.
            /// </summary>
            private ReportItemCollection _collection;
            
            /// <summary>
            /// Default constructor for enumerator.
            /// </summary>
            /// <param name="collection">Instance of the collection to enumerate.</param>
            internal ReportItemCollectionEnumerator(ReportItemCollection collection)
            {
                _index = -1;
                _collection = collection;
            }
            
            /// <summary>
            /// Gets the Server.Engines.Reports.ReportItem object in the enumerated ReportItemCollection currently indexed by this instance.
            /// </summary>
            public Server.Engines.Reports.ReportItem Current
            {
                get
                {
                    if (((_index == -1) 
                                || (_index >= _collection.Count)))
                    {
                        throw new System.IndexOutOfRangeException("Enumerator not started.");
                    }
                    else
                    {
                        return _currentElement;
                    }
                }
            }
            
            /// <summary>
            /// Gets the current element in the collection.
            /// </summary>
            object IEnumerator.Current
            {
                get
                {
                    if (((_index == -1) 
                                || (_index >= _collection.Count)))
                    {
                        throw new System.IndexOutOfRangeException("Enumerator not started.");
                    }
                    else
                    {
                        return _currentElement;
                    }
                }
            }
            
            /// <summary>
            /// Reset the cursor, so it points to the beginning of the enumerator.
            /// </summary>
            public void Reset()
            {
                _index = -1;
                _currentElement = null;
            }
            
            /// <summary>
            /// Advances the enumerator to the next queue of the enumeration, if one is currently available.
            /// </summary>
            /// <returns>true, if the enumerator was succesfully advanced to the next queue; false, if the enumerator has reached the end of the enumeration.</returns>
            public bool MoveNext()
            {
                if ((_index 
                            < (_collection.Count - 1)))
                {
                    _index = (_index + 1);
                    _currentElement = this._collection[_index];
                    return true;
                }
                _index = _collection.Count;
                return false;
            }
        }
    }
}

namespace Server.Engines.Reports
{
	public class ResponseInfo : PersistableObject
	{
		#region Type Identification
		public static readonly PersistableType ThisTypeID = new PersistableType( "rs", new ConstructCallback( Construct ) );

		private static PersistableObject Construct()
		{
			return new ResponseInfo();
		}

		public override PersistableType TypeID{ get{ return ThisTypeID; } }
		#endregion

		private DateTime m_TimeStamp;

		private string m_SentBy;
		private string m_Message;

		public DateTime TimeStamp{ get{ return m_TimeStamp; } set{ m_TimeStamp = value; } }

		public string SentBy{ get{ return m_SentBy; } set{ m_SentBy = value; } }
		public string Message{ get{ return m_Message; } set{ m_Message = value; } }

		public ResponseInfo()
		{
		}

		public ResponseInfo( string sentBy, string message )
		{
			m_TimeStamp = DateTime.Now;
			m_SentBy = sentBy;
			m_Message = message;
		}

		public override void SerializeAttributes( PersistanceWriter op )
		{
			op.SetDateTime( "t", m_TimeStamp );

			op.SetString( "s", m_SentBy );
			op.SetString( "m", m_Message );
		}

		public override void DeserializeAttributes( PersistanceReader ip )
		{
			m_TimeStamp = ip.GetDateTime( "t" );

			m_SentBy = ip.GetString( "s" );
			m_Message = ip.GetString( "m" );
		}
	}
}//------------------------------------------------------------------------------
// <autogenerated>
//     This code was generated by a tool.
//     Runtime Version: 1.1.4322.573
//
//     Changes to this file may cause incorrect behavior and will be lost if 
//     the code is regenerated.
// </autogenerated>
//------------------------------------------------------------------------------

namespace Server.Engines.Reports
{
    /// <summary>
    /// Strongly typed collection of Server.Engines.Reports.ResponseInfo.
    /// </summary>
    public class ResponseInfoCollection : System.Collections.CollectionBase
    {
        
        /// <summary>
        /// Default constructor.
        /// </summary>
        public ResponseInfoCollection() : 
                base()
        {
        }
        
        /// <summary>
        /// Gets or sets the value of the Server.Engines.Reports.ResponseInfo at a specific position in the ResponseInfoCollection.
        /// </summary>
        public Server.Engines.Reports.ResponseInfo this[int index]
        {
            get
            {
                return ((Server.Engines.Reports.ResponseInfo)(this.List[index]));
            }
            set
            {
                this.List[index] = value;
            }
        }

		public int Add( string sentBy, string message )
		{
			return Add( new ResponseInfo( sentBy, message ) );
		}
        
        /// <summary>
        /// Append a Server.Engines.Reports.ResponseInfo entry to this collection.
        /// </summary>
        /// <param name="value">Server.Engines.Reports.ResponseInfo instance.</param>
        /// <returns>The position into which the new element was inserted.</returns>
        public int Add(Server.Engines.Reports.ResponseInfo value)
        {
            return this.List.Add(value);
        }
        
        /// <summary>
        /// Determines whether a specified Server.Engines.Reports.ResponseInfo instance is in this collection.
        /// </summary>
        /// <param name="value">Server.Engines.Reports.ResponseInfo instance to search for.</param>
        /// <returns>True if the Server.Engines.Reports.ResponseInfo instance is in the collection; otherwise false.</returns>
        public bool Contains(Server.Engines.Reports.ResponseInfo value)
        {
            return this.List.Contains(value);
        }
        
        /// <summary>
        /// Retrieve the index a specified Server.Engines.Reports.ResponseInfo instance is in this collection.
        /// </summary>
        /// <param name="value">Server.Engines.Reports.ResponseInfo instance to find.</param>
        /// <returns>The zero-based index of the specified Server.Engines.Reports.ResponseInfo instance. If the object is not found, the return value is -1.</returns>
        public int IndexOf(Server.Engines.Reports.ResponseInfo value)
        {
            return this.List.IndexOf(value);
        }
        
        /// <summary>
        /// Removes a specified Server.Engines.Reports.ResponseInfo instance from this collection.
        /// </summary>
        /// <param name="value">The Server.Engines.Reports.ResponseInfo instance to remove.</param>
        public void Remove(Server.Engines.Reports.ResponseInfo value)
        {
            this.List.Remove(value);
        }
        
        /// <summary>
        /// Returns an enumerator that can iterate through the Server.Engines.Reports.ResponseInfo instance.
        /// </summary>
        /// <returns>An Server.Engines.Reports.ResponseInfo's enumerator.</returns>
        public new ResponseInfoCollectionEnumerator GetEnumerator()
        {
            return new ResponseInfoCollectionEnumerator(this);
        }
        
        /// <summary>
        /// Insert a Server.Engines.Reports.ResponseInfo instance into this collection at a specified index.
        /// </summary>
        /// <param name="index">Zero-based index.</param>
        /// <param name="value">The Server.Engines.Reports.ResponseInfo instance to insert.</param>
        public void Insert(int index, Server.Engines.Reports.ResponseInfo value)
        {
            this.List.Insert(index, value);
        }
        
        /// <summary>
        /// Strongly typed enumerator of Server.Engines.Reports.ResponseInfo.
        /// </summary>
        public class ResponseInfoCollectionEnumerator : System.Collections.IEnumerator
        {
            
            /// <summary>
            /// Current index
            /// </summary>
            private int _index;
            
            /// <summary>
            /// Current element pointed to.
            /// </summary>
            private Server.Engines.Reports.ResponseInfo _currentElement;
            
            /// <summary>
            /// Collection to enumerate.
            /// </summary>
            private ResponseInfoCollection _collection;
            
            /// <summary>
            /// Default constructor for enumerator.
            /// </summary>
            /// <param name="collection">Instance of the collection to enumerate.</param>
            internal ResponseInfoCollectionEnumerator(ResponseInfoCollection collection)
            {
                _index = -1;
                _collection = collection;
            }
            
            /// <summary>
            /// Gets the Server.Engines.Reports.ResponseInfo object in the enumerated ResponseInfoCollection currently indexed by this instance.
            /// </summary>
            public Server.Engines.Reports.ResponseInfo Current
            {
                get
                {
                    if (((_index == -1) 
                                || (_index >= _collection.Count)))
                    {
                        throw new System.IndexOutOfRangeException("Enumerator not started.");
                    }
                    else
                    {
                        return _currentElement;
                    }
                }
            }
            
            /// <summary>
            /// Gets the current element in the collection.
            /// </summary>
            object IEnumerator.Current
            {
                get
                {
                    if (((_index == -1) 
                                || (_index >= _collection.Count)))
                    {
                        throw new System.IndexOutOfRangeException("Enumerator not started.");
                    }
                    else
                    {
                        return _currentElement;
                    }
                }
            }
            
            /// <summary>
            /// Reset the cursor, so it points to the beginning of the enumerator.
            /// </summary>
            public void Reset()
            {
                _index = -1;
                _currentElement = null;
            }
            
            /// <summary>
            /// Advances the enumerator to the next queue of the enumeration, if one is currently available.
            /// </summary>
            /// <returns>true, if the enumerator was succesfully advanced to the next queue; false, if the enumerator has reached the end of the enumeration.</returns>
            public bool MoveNext()
            {
                if ((_index 
                            < (_collection.Count - 1)))
                {
                    _index = (_index + 1);
                    _currentElement = this._collection[_index];
                    return true;
                }
                _index = _collection.Count;
                return false;
            }
        }
    }
}

namespace Server.Engines.Reports
{
	public class Snapshot : PersistableObject
	{
		#region Type Identification
		public static readonly PersistableType ThisTypeID = new PersistableType( "ss", new ConstructCallback( Construct ) );

		private static PersistableObject Construct()
		{
			return new Snapshot();
		}

		public override PersistableType TypeID{ get{ return ThisTypeID; } }
		#endregion

		private DateTime m_TimeStamp;
		private ObjectCollection m_Children;

		public DateTime TimeStamp{ get{ return m_TimeStamp; } set{ m_TimeStamp = value; } }
		public ObjectCollection Children{ get{ return m_Children; } set{ m_Children = value; } }

		public Snapshot()
		{
			m_Children = new ObjectCollection();
		}

		public override void SerializeAttributes( PersistanceWriter op )
		{
			op.SetDateTime( "t", m_TimeStamp );
		}

		public override void DeserializeAttributes( PersistanceReader ip )
		{
			m_TimeStamp = ip.GetDateTime( "t" );
		}

		public override void SerializeChildren( PersistanceWriter op )
		{
			for ( int i = 0; i < m_Children.Count; ++i )
				m_Children[i].Serialize( op );
		}

		public override void DeserializeChildren( PersistanceReader ip )
		{
			while ( ip.HasChild )
				m_Children.Add( ip.GetChild() );
		}
	}
}//------------------------------------------------------------------------------
// <autogenerated>
//     This code was generated by a tool.
//     Runtime Version: 1.1.4322.573
//
//     Changes to this file may cause incorrect behavior and will be lost if 
//     the code is regenerated.
// </autogenerated>
//------------------------------------------------------------------------------

namespace Server.Engines.Reports
{
    /// <summary>
    /// Strongly typed collection of Server.Engines.Reports.Snapshot.
    /// </summary>
    public class SnapshotCollection : System.Collections.CollectionBase
    {
        
        /// <summary>
        /// Default constructor.
        /// </summary>
        public SnapshotCollection() : 
                base()
        {
        }
        
        /// <summary>
        /// Gets or sets the value of the Server.Engines.Reports.Snapshot at a specific position in the SnapshotCollection.
        /// </summary>
        public Server.Engines.Reports.Snapshot this[int index]
        {
            get
            {
                return ((Server.Engines.Reports.Snapshot)(this.List[index]));
            }
            set
            {
                this.List[index] = value;
            }
        }
        
        /// <summary>
        /// Append a Server.Engines.Reports.Snapshot entry to this collection.
        /// </summary>
        /// <param name="value">Server.Engines.Reports.Snapshot instance.</param>
        /// <returns>The position into which the new element was inserted.</returns>
        public int Add(Server.Engines.Reports.Snapshot value)
        {
            return this.List.Add(value);
        }
        
        /// <summary>
        /// Determines whether a specified Server.Engines.Reports.Snapshot instance is in this collection.
        /// </summary>
        /// <param name="value">Server.Engines.Reports.Snapshot instance to search for.</param>
        /// <returns>True if the Server.Engines.Reports.Snapshot instance is in the collection; otherwise false.</returns>
        public bool Contains(Server.Engines.Reports.Snapshot value)
        {
            return this.List.Contains(value);
        }
        
        /// <summary>
        /// Retrieve the index a specified Server.Engines.Reports.Snapshot instance is in this collection.
        /// </summary>
        /// <param name="value">Server.Engines.Reports.Snapshot instance to find.</param>
        /// <returns>The zero-based index of the specified Server.Engines.Reports.Snapshot instance. If the object is not found, the return value is -1.</returns>
        public int IndexOf(Server.Engines.Reports.Snapshot value)
        {
            return this.List.IndexOf(value);
        }
        
        /// <summary>
        /// Removes a specified Server.Engines.Reports.Snapshot instance from this collection.
        /// </summary>
        /// <param name="value">The Server.Engines.Reports.Snapshot instance to remove.</param>
        public void Remove(Server.Engines.Reports.Snapshot value)
        {
            this.List.Remove(value);
        }
        
        /// <summary>
        /// Returns an enumerator that can iterate through the Server.Engines.Reports.Snapshot instance.
        /// </summary>
        /// <returns>An Server.Engines.Reports.Snapshot's enumerator.</returns>
        public new SnapshotCollectionEnumerator GetEnumerator()
        {
            return new SnapshotCollectionEnumerator(this);
        }
        
        /// <summary>
        /// Insert a Server.Engines.Reports.Snapshot instance into this collection at a specified index.
        /// </summary>
        /// <param name="index">Zero-based index.</param>
        /// <param name="value">The Server.Engines.Reports.Snapshot instance to insert.</param>
        public void Insert(int index, Server.Engines.Reports.Snapshot value)
        {
            this.List.Insert(index, value);
        }
        
        /// <summary>
        /// Strongly typed enumerator of Server.Engines.Reports.Snapshot.
        /// </summary>
        public class SnapshotCollectionEnumerator : System.Collections.IEnumerator
        {
            
            /// <summary>
            /// Current index
            /// </summary>
            private int _index;
            
            /// <summary>
            /// Current element pointed to.
            /// </summary>
            private Server.Engines.Reports.Snapshot _currentElement;
            
            /// <summary>
            /// Collection to enumerate.
            /// </summary>
            private SnapshotCollection _collection;
            
            /// <summary>
            /// Default constructor for enumerator.
            /// </summary>
            /// <param name="collection">Instance of the collection to enumerate.</param>
            internal SnapshotCollectionEnumerator(SnapshotCollection collection)
            {
                _index = -1;
                _collection = collection;
            }
            
            /// <summary>
            /// Gets the Server.Engines.Reports.Snapshot object in the enumerated SnapshotCollection currently indexed by this instance.
            /// </summary>
            public Server.Engines.Reports.Snapshot Current
            {
                get
                {
                    if (((_index == -1) 
                                || (_index >= _collection.Count)))
                    {
                        throw new System.IndexOutOfRangeException("Enumerator not started.");
                    }
                    else
                    {
                        return _currentElement;
                    }
                }
            }
            
            /// <summary>
            /// Gets the current element in the collection.
            /// </summary>
            object IEnumerator.Current
            {
                get
                {
                    if (((_index == -1) 
                                || (_index >= _collection.Count)))
                    {
                        throw new System.IndexOutOfRangeException("Enumerator not started.");
                    }
                    else
                    {
                        return _currentElement;
                    }
                }
            }
            
            /// <summary>
            /// Reset the cursor, so it points to the beginning of the enumerator.
            /// </summary>
            public void Reset()
            {
                _index = -1;
                _currentElement = null;
            }
            
            /// <summary>
            /// Advances the enumerator to the next queue of the enumeration, if one is currently available.
            /// </summary>
            /// <returns>true, if the enumerator was succesfully advanced to the next queue; false, if the enumerator has reached the end of the enumeration.</returns>
            public bool MoveNext()
            {
                if ((_index 
                            < (_collection.Count - 1)))
                {
                    _index = (_index + 1);
                    _currentElement = this._collection[_index];
                    return true;
                }
                _index = _collection.Count;
                return false;
            }
        }
    }
}

namespace Server.Engines.Reports
{
	public class SnapshotHistory : PersistableObject
	{
		#region Type Identification
		public static readonly PersistableType ThisTypeID = new PersistableType( "sh", new ConstructCallback( Construct ) );

		private static PersistableObject Construct()
		{
			return new SnapshotHistory();
		}

		public override PersistableType TypeID{ get{ return ThisTypeID; } }
		#endregion

		private SnapshotCollection m_Snapshots;

		public SnapshotCollection Snapshots{ get{ return m_Snapshots; } set{ m_Snapshots = value; } }

		public SnapshotHistory()
		{
			m_Snapshots = new SnapshotCollection();
		}

		public void Save()
		{
			string path = Path.Combine( Core.BaseDirectory, "reportHistory.xml" );
			PersistanceWriter pw = new XmlPersistanceWriter( path, "Stats" );

			pw.WriteDocument( this );

			pw.Close();
		}

		public void Load()
		{
			string path = Path.Combine( Core.BaseDirectory, "reportHistory.xml" );

			if ( !File.Exists( path ) )
				return;

			PersistanceReader pr = new XmlPersistanceReader( path, "Stats" );

			pr.ReadDocument( this );

			pr.Close();
		}

		public override void SerializeChildren( PersistanceWriter op )
		{
			for ( int i = 0; i < m_Snapshots.Count; ++i )
				m_Snapshots[i].Serialize( op );
		}

		public override void DeserializeChildren( PersistanceReader ip )
		{
			while ( ip.HasChild )
				m_Snapshots.Add( ip.GetChild() as Snapshot );
		}
	}
}

namespace Server.Engines.Reports
{
	public class StaffHistory : PersistableObject
	{
		#region Type Identification
		public static readonly PersistableType ThisTypeID = new PersistableType( "stfhst", new ConstructCallback( Construct ) );

		private static PersistableObject Construct()
		{
			return new StaffHistory();
		}

		public override PersistableType TypeID{ get{ return ThisTypeID; } }
		#endregion

		private PageInfoCollection m_Pages;
		private QueueStatusCollection m_QueueStats;

		private Hashtable m_UserInfo;
		private Hashtable m_StaffInfo;

		public PageInfoCollection Pages{ get{ return m_Pages; } set{ m_Pages = value; } }
		public QueueStatusCollection QueueStats{ get{ return m_QueueStats; } set{ m_QueueStats = value; } }

		public Hashtable UserInfo{ get{ return m_UserInfo; } set{ m_UserInfo = value; } }
		public Hashtable StaffInfo{ get{ return m_StaffInfo; } set{ m_StaffInfo = value; } }

		public void AddPage( PageInfo info )
		{
			lock ( SaveLock )
				m_Pages.Add( info );

			info.History = this;
		}

		public StaffHistory()
		{
			m_Pages = new PageInfoCollection();
			m_QueueStats = new QueueStatusCollection();

			m_UserInfo = new Hashtable( StringComparer.OrdinalIgnoreCase );
			m_StaffInfo = new Hashtable( StringComparer.OrdinalIgnoreCase );
		}

		public StaffInfo GetStaffInfo( string account )
		{
			lock ( RenderLock )
			{
				if ( account == null || account.Length == 0 )
					return null;

				StaffInfo info = m_StaffInfo[account] as StaffInfo;

				if ( info == null )
					m_StaffInfo[account] = info = new StaffInfo( account );

				return info;
			}
		}

		public UserInfo GetUserInfo( string account )
		{
			if ( account == null || account.Length == 0 )
				return null;

			UserInfo info = m_UserInfo[account] as UserInfo;

			if ( info == null )
				m_UserInfo[account] = info = new UserInfo( account );

			return info;
		}

		public static readonly object RenderLock = new object();
		public static readonly object SaveLock = new object();

		public void Save()
		{
			lock ( SaveLock )
			{
				string path = Path.Combine( Core.BaseDirectory, "staffHistory.xml" );
				PersistanceWriter pw = new XmlPersistanceWriter( path, "Staff" );

				pw.WriteDocument( this );

				pw.Close();
			}
		}

		public void Load()
		{
			string path = Path.Combine( Core.BaseDirectory, "staffHistory.xml" );

			if ( !File.Exists( path ) )
				return;

			PersistanceReader pr = new XmlPersistanceReader( path, "Staff" );

			pr.ReadDocument( this );

			pr.Close();
		}

		public override void SerializeChildren( PersistanceWriter op )
		{
			for ( int i = 0; i < m_Pages.Count; ++i )
				m_Pages[i].Serialize( op );

			for ( int i = 0; i < m_QueueStats.Count; ++i )
				m_QueueStats[i].Serialize( op );
		}

		public override void DeserializeChildren( PersistanceReader ip )
		{
			DateTime min = DateTime.Now - TimeSpan.FromDays( 8.0 );

			while ( ip.HasChild )
			{
				PersistableObject obj = ip.GetChild();

				if ( obj is PageInfo )
				{
					PageInfo pageInfo = obj as PageInfo;

					pageInfo.UpdateResolver();

					if ( pageInfo.TimeSent >= min || pageInfo.TimeResolved >= min )
					{
						m_Pages.Add( pageInfo );
						pageInfo.History = this;
					}
					else
					{
						pageInfo.Sender = null;
						pageInfo.Resolver = null;
					}
				}
				else if ( obj is QueueStatus )
				{
					QueueStatus queueStatus = obj as QueueStatus;

					if ( queueStatus.TimeStamp >= min )
						m_QueueStats.Add( queueStatus );
				}
			}
		}

		public StaffInfo[] GetStaff()
		{
			StaffInfo[] staff = new StaffInfo[m_StaffInfo.Count];
			int index = 0;

			foreach ( StaffInfo staffInfo in m_StaffInfo.Values )
				staff[index++] = staffInfo;

			return staff;
		}

		public void Render( ObjectCollection objects )
		{
			lock ( RenderLock )
			{
				objects.Add( GraphQueueStatus() );

				StaffInfo[] staff = GetStaff();

				BaseInfo.SortRange = TimeSpan.FromDays( 7.0 );
				Array.Sort( staff );

				objects.Add( GraphHourlyPages( m_Pages, PageResolution.None, "New pages by hour", "graph_new_pages_hr" ) );
				objects.Add( GraphHourlyPages( m_Pages, PageResolution.Handled, "Handled pages by hour", "graph_handled_pages_hr" ) );
				objects.Add( GraphHourlyPages( m_Pages, PageResolution.Deleted, "Deleted pages by hour", "graph_deleted_pages_hr" ) );
				objects.Add( GraphHourlyPages( m_Pages, PageResolution.Canceled, "Canceled pages by hour", "graph_canceled_pages_hr" ) );
				objects.Add( GraphHourlyPages( m_Pages, PageResolution.Logged, "Logged-out pages by hour", "graph_logged_pages_hr" ) );

				BaseInfo.SortRange = TimeSpan.FromDays( 1.0 );
				Array.Sort( staff );

				objects.Add( ReportTotalPages( staff, TimeSpan.FromDays(  1.0 ), "1 Day" ) );
				objects.AddRange( (PersistableObject[])ChartTotalPages( staff, TimeSpan.FromDays(  1.0 ), "1 Day", "graph_daily_pages" ) );

				BaseInfo.SortRange = TimeSpan.FromDays( 7.0 );
				Array.Sort( staff );

				objects.Add( ReportTotalPages( staff, TimeSpan.FromDays(  7.0 ), "1 Week" ) );
				objects.AddRange( (PersistableObject[])ChartTotalPages( staff, TimeSpan.FromDays(  7.0 ), "1 Week", "graph_weekly_pages" ) );

				BaseInfo.SortRange = TimeSpan.FromDays( 30.0 );
				Array.Sort( staff );

				objects.Add( ReportTotalPages( staff, TimeSpan.FromDays( 30.0 ), "1 Month" ) );
				objects.AddRange( (PersistableObject[])ChartTotalPages( staff, TimeSpan.FromDays( 30.0 ), "1 Month", "graph_monthly_pages" ) );

				for ( int i = 0; i < staff.Length; ++i )
					objects.Add( GraphHourlyPages( staff[i] ) );
			}
		}

		public static int GetPageCount( StaffInfo staff, DateTime min, DateTime max )
		{
			return GetPageCount( staff.Pages, PageResolution.Handled, min, max );
		}

		public static int GetPageCount( PageInfoCollection pages, PageResolution res, DateTime min, DateTime max )
		{
			int count = 0;

			for ( int i = 0; i < pages.Count; ++i )
			{
				if ( res != PageResolution.None && pages[i].Resolution != res )
					continue;

				DateTime ts = pages[i].TimeResolved;

				if ( ts >= min && ts < max )
					++count;
			}

			return count;
		}

		private BarGraph GraphQueueStatus()
		{
			int[] totals = new int[24];
			int[] counts = new int[24];

			DateTime max = DateTime.Now;
			DateTime min = max - TimeSpan.FromDays( 7.0 );

			for ( int i = 0; i < m_QueueStats.Count; ++i )
			{
				DateTime ts = m_QueueStats[i].TimeStamp;

				if ( ts >= min && ts < max )
				{
					DateTime date = ts.Date;
					TimeSpan time = ts.TimeOfDay;

					int hour = time.Hours;

					totals[hour] += m_QueueStats[i].Count;
					counts[hour]++;
				}
			}

			BarGraph barGraph = new BarGraph( "Average pages in queue", "graph_pagequeue_avg", 10, "Time", "Pages", BarGraphRenderMode.Lines );

			barGraph.FontSize = 6;

			for ( int i = 7; i <= totals.Length+7; ++i )
			{
				int val;

				if ( counts[i%totals.Length] == 0 )
					val = 0;
				else
					val = (totals[i%totals.Length] + (counts[i%totals.Length] / 2)) / counts[i%totals.Length];

				int realHours = i%totals.Length;
				int hours;

				if ( realHours == 0 )
					hours = 12;
				else if ( realHours > 12 )
					hours = realHours - 12;
				else
					hours = realHours;

				barGraph.Items.Add( hours + (realHours >= 12 ? " PM" : " AM"), val );
			}

			return barGraph;
		}

		private BarGraph GraphHourlyPages( StaffInfo staff )
		{
			return GraphHourlyPages( staff.Pages, PageResolution.Handled, "Average pages handled by " + staff.Display, "graphs_" + staff.Account.ToLower() + "_avg" );
		}

		private BarGraph GraphHourlyPages( PageInfoCollection pages, PageResolution res, string title, string fname )
		{
			int[] totals = new int[24];
			int[] counts = new int[24];
			
			DateTime[] dates = new DateTime[24];

			DateTime max = DateTime.Now;
			DateTime min = max - TimeSpan.FromDays( 7.0 );

			bool sentStamp = ( res == PageResolution.None );

			for ( int i = 0; i < pages.Count; ++i )
			{
				if ( res != PageResolution.None && pages[i].Resolution != res )
					continue;

				DateTime ts = ( sentStamp ? pages[i].TimeSent : pages[i].TimeResolved );

				if ( ts >= min && ts < max )
				{
					DateTime date = ts.Date;
					TimeSpan time = ts.TimeOfDay;

					int hour = time.Hours;

					totals[hour]++;

					if ( dates[hour] != date )
					{
						counts[hour]++;
						dates[hour] = date;
					}
				}
			}

			BarGraph barGraph = new BarGraph( title, fname, 10, "Time", "Pages", BarGraphRenderMode.Lines );

			barGraph.FontSize = 6;

			for ( int i = 7; i <= totals.Length+7; ++i )
			{
				int val;

				if ( counts[i%totals.Length] == 0 )
					val = 0;
				else
					val = (totals[i%totals.Length] + (counts[i%totals.Length] / 2)) / counts[i%totals.Length];

				int realHours = i%totals.Length;
				int hours;

				if ( realHours == 0 )
					hours = 12;
				else if ( realHours > 12 )
					hours = realHours - 12;
				else
					hours = realHours;

				barGraph.Items.Add( hours + (realHours >= 12 ? " PM" : " AM"), val );
			}

			return barGraph;
		}

		private Report ReportTotalPages( StaffInfo[] staff, TimeSpan ts, string title )
		{
			DateTime max = DateTime.Now;
			DateTime min = max - ts;

			Report report = new Report( title + " Staff Report", "400" );

			report.Columns.Add( "65%", "left", "Staff Name" );
			report.Columns.Add( "35%", "center", "Page Count" );

			for ( int i = 0; i < staff.Length; ++i )
				report.Items.Add( staff[i].Display, GetPageCount( staff[i], min, max ) );

			return report;
		}

		private PieChart[] ChartTotalPages( StaffInfo[] staff, TimeSpan ts, string title, string fname )
		{
			DateTime max = DateTime.Now;
			DateTime min = max - ts;

			PieChart staffChart = new PieChart( title + " Staff Chart", fname + "_staff", true );

			int other = 0;

			for ( int i = 0; i < staff.Length; ++i )
			{
				int count = GetPageCount( staff[i], min, max );

				if ( i < 12 && count > 0 )
					staffChart.Items.Add( staff[i].Display, count );
				else
					other += count;
			}

			if ( other > 0 )
				staffChart.Items.Add( "Other", other );

			PieChart resChart = new PieChart( title + " Resolutions", fname + "_resol", true );

			int countTotal = GetPageCount( m_Pages, PageResolution.None, min, max );
			int countHandled = GetPageCount( m_Pages, PageResolution.Handled, min, max );
			int countDeleted = GetPageCount( m_Pages, PageResolution.Deleted, min, max );
			int countCanceled = GetPageCount( m_Pages, PageResolution.Canceled, min, max );
			int countLogged = GetPageCount( m_Pages, PageResolution.Logged, min, max );
			int countUnres = countTotal - ( countHandled + countDeleted + countCanceled + countLogged );

			resChart.Items.Add( "Handled", countHandled );
			resChart.Items.Add( "Deleted", countDeleted );
			resChart.Items.Add( "Canceled", countCanceled );
			resChart.Items.Add( "Logged Out", countLogged );
			resChart.Items.Add( "Unresolved", countUnres );

			return new PieChart[]{ staffChart, resChart };
		}
	}
}