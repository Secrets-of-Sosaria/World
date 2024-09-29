using System;
using Server;
using Server.Misc;

namespace Server.Items
{
	public class SeaChart : MapItem
	{
		public string MapWorld;

		[CommandProperty(AccessLevel.Owner)]
		public string Map_World { get { return MapWorld; } set { MapWorld = value; InvalidateProperties(); } }

		[Constructable]
		public SeaChart()
		{
			SetDisplay( 0, 0, 5119, 4095, 400, 400 );
		}

		public override void CraftInit( Mobile from )
		{
            Map map = from.Map;

			double skillValue = from.Skills[SkillName.Cartography].Value;
            int dist = 0; int size = 0;

			if ( from.Land == Land.Lodoria ){ 			dist = 64 + (int)(skillValue * 15); size = 24 + (int)(skillValue * 3.3); }
			else if ( from.Land == Land.Serpent ){ 		dist = 50 + (int)(skillValue * 10); size = 24 + (int)(skillValue * 2.8); }
			else if ( from.Land == Land.Savaged ){ 		dist = 40 + (int)(skillValue * 9); size = 24 + (int)(skillValue * 2.4); }
			else if ( from.Land == Land.IslesDread ){ 	dist = 40 + (int)(skillValue * 9); size = 24 + (int)(skillValue * 2.4); }
			else if ( from.Land == Land.Ambrosia ){ 	dist = 40 + (int)(skillValue * 8); size = 24 + (int)(skillValue * 2); }
			else if ( from.Land == Land.Kuldar ){ 		dist = 40 + (int)(skillValue * 8); size = 24 + (int)(skillValue * 2); }
			else if ( from.Land == Land.UmberVeil ){ 	dist = 40 + (int)(skillValue * 8); size = 24 + (int)(skillValue * 2); }
			else if ( from.Land == Land.Luna ){ 		dist = 40 + (int)(skillValue * 8); size = 24 + (int)(skillValue * 2); }
			else if ( from.Land == Land.Underworld ){ 	dist = 50 + (int)(skillValue * 10); size = 24 + (int)(skillValue * 2.8); }
			else { 										dist = 64 + (int)(skillValue * 15); size = 24 + (int)(skillValue * 3.3); }

			MapWorld = Server.Lands.LandName( from.Land );

			if ( dist < 200 )
				dist = 200;
			
			if ( size < 200 )
				size = 200;
			else if ( size > 400 )
				size = 400;

            SetDisplay(from.X - dist, from.Y - dist, from.X + dist, from.Y + dist, size, size, from.Map, from.X, from.Y );
		}

		public override int LabelNumber{ get{ return 1015232; } } // sea chart

		public SeaChart( Serial serial ) : base( serial )
		{
		}

        public override void GetProperties(ObjectPropertyList list)
        {
            base.GetProperties(list);
            string mDesc = "for " + MapWorld;
            list.Add(1053099, String.Format("<BASEFONT COLOR=#DDCC22>\t{0}<BASEFONT Color=#FBFBFB>", mDesc));
        }

		public override void Serialize( GenericWriter writer )
		{
			base.Serialize( writer );
			writer.Write( (int) 0 );
            writer.Write( MapWorld );
		}

		public override void Deserialize( GenericReader reader )
		{
			base.Deserialize( reader );
			int version = reader.ReadInt();
            MapWorld = reader.ReadString();
		}
	}
}