using System;
using System.Collections;
using Server.Regions;
using Server.Mobiles;
using Server.Network;
using Server.Targeting;
using Server.ContextMenus;
using System.Collections.Generic;

namespace Server.Items
{
	public enum BeverageType
	{
		Ale,
		Cider,
		Liquor,
		Milk,
		Wine,
		Water
	}

	public interface IHasQuantity
	{
		int Quantity { get; set; }
	}

	public interface IWaterSource : IHasQuantity
	{
	}

	// TODO: Flipable attributes

	[TypeAlias( "Server.Items.BottleAle", "Server.Items.BottleCider", "Server.Items.BottleLiquor", "Server.Items.BottleMilk", "Server.Items.BottleWine", "Server.Items.BottleWater", "Server.Items.GlassBottle" )]
	public class BeverageBottle : BaseBeverage
	{
		public override int BaseLabelNumber { get { return 1042959; } } // phial of ale
		public override int EmptyLabelNumber { get { return 1043006; } } // phial
		public override int MaxQuantity { get { return 5; } }

		public override int ComputeItemID()
		{
			Name = CliLocTable.Lookup( BaseLabelNumber + (int)Content );
			if( IsEmpty )
				Name = CliLocTable.Lookup( EmptyLabelNumber );

			switch( Content )
			{
				case BeverageType.Ale: Hue = 0x83B; break;
				case BeverageType.Cider: Hue = 0x981; break;
				case BeverageType.Liquor: Hue = 0xB51; break;
				case BeverageType.Milk: Hue = 0x9A3; break;
				case BeverageType.Wine: Hue = 0xB64; break;
				case BeverageType.Water: Hue = 0xB40; break;
			}

			if( IsEmpty )
				Hue = 0;

			return 0x282A;
		}

		[Constructable]
		public BeverageBottle() : this( BeverageType.Water )
		{
			Weight = 2.0;
		}

		[Constructable]
		public BeverageBottle( BeverageType type ): base( type )
		{
			Weight = 2.0;
		}

		public BeverageBottle( Serial serial ): base( serial )
		{
		}

		public override void Serialize( GenericWriter writer )
		{
			base.Serialize( writer );
			writer.Write( (int)1 ); // version
		}

		public override void Deserialize( GenericReader reader )
		{
			base.Deserialize( reader );

			int version = reader.ReadInt();

			switch( version )
			{
				case 0:
				{
					if( CheckType( "BottleAle" ) )
					{
						Quantity = MaxQuantity;
						Content = BeverageType.Ale;
					}
					else if( CheckType( "BottleCider" ) )
					{
						Quantity = MaxQuantity;
						Content = BeverageType.Cider;
					}
					else if( CheckType( "BottleLiquor" ) )
					{
						Quantity = MaxQuantity;
						Content = BeverageType.Liquor;
					}
					else if( CheckType( "BottleMilk" ) )
					{
						Quantity = MaxQuantity;
						Content = BeverageType.Milk;
					}
					else if( CheckType( "BottleWine" ) )
					{
						Quantity = MaxQuantity;
						Content = BeverageType.Wine;
					}
					else if( CheckType( "BottleWater" ) )
					{
						Quantity = MaxQuantity;
						Content = BeverageType.Water;
					}
					else if( CheckType( "GlassBottle" ) )
					{
						Quantity = 0;
						Content = BeverageType.Water;
					}
					else
					{
						throw new Exception( World.LoadingType );
					}
				}

				break;
			}
		}
	}

	[TypeAlias( "Server.Items.FlagonAle", "Server.Items.FlagonCider", "Server.Items.FlagonLiquor", "Server.Items.FlagonMilk", "Server.Items.FlagonWine", "Server.Items.FlagonWater", "Server.Items.FlagonEmpty" )]
	public class Jug : BaseBeverage
	{
		public override int BaseLabelNumber { get { return 1042965; } } // flagon of ale
		public override int EmptyLabelNumber { get { return 1043007; } } // flagon
		public override int MaxQuantity { get { return 15; } }

		public override int ComputeItemID()
		{
			Name = CliLocTable.Lookup( BaseLabelNumber + (int)Content );
			if( IsEmpty )
				Name = CliLocTable.Lookup( EmptyLabelNumber );

			switch( Content )
			{
				case BeverageType.Ale: Hue = 0x83B; break;
				case BeverageType.Cider: Hue = 0x981; break;
				case BeverageType.Liquor: Hue = 0xB51; break;
				case BeverageType.Milk: Hue = 0x9A3; break;
				case BeverageType.Wine: Hue = 0xB64; break;
				case BeverageType.Water: Hue = 0xB40; break;
			}

			if( IsEmpty )
				Hue = 0;

			return 0x4CEF;
		}

		[Constructable]
		public Jug() : this( BeverageType.Water )
		{
			Weight = 4.0;
		}

		[Constructable]
		public Jug( BeverageType type ): base( type )
		{
			Weight = 4.0;
		}

		public Jug( Serial serial ): base( serial )
		{
		}

		public override void Serialize( GenericWriter writer )
		{
			base.Serialize( writer );
			writer.Write( (int)1 ); // version
		}

		public override void Deserialize( GenericReader reader )
		{
			base.Deserialize( reader );
			int version = reader.ReadInt();

			switch( version )
			{
				case 0:
					{
						if( CheckType( "FlagonAle" ) )
						{
							Quantity = MaxQuantity;
							Content = BeverageType.Ale;
						}
						else if( CheckType( "FlagonCider" ) )
						{
							Quantity = MaxQuantity;
							Content = BeverageType.Cider;
						}
						else if( CheckType( "FlagonLiquor" ) )
						{
							Quantity = MaxQuantity;
							Content = BeverageType.Liquor;
						}
						else if( CheckType( "FlagonMilk" ) )
						{
							Quantity = MaxQuantity;
							Content = BeverageType.Milk;
						}
						else if( CheckType( "FlagonWine" ) )
						{
							Quantity = MaxQuantity;
							Content = BeverageType.Wine;
						}
						else if( CheckType( "FlagonWater" ) )
						{
							Quantity = MaxQuantity;
							Content = BeverageType.Water;
						}
						else if( CheckType( "FlagonEmpty" ) )
						{
							Quantity = 0;
							Content = BeverageType.Water;
						}
						else
						{
							throw new Exception( World.LoadingType );
						}

						break;
					}
			}
		}
	}

	[TypeAlias( "Server.Items.CeramicAle", "Server.Items.CeramicCider", "Server.Items.CeramicLiquor", "Server.Items.CeramicMilk", "Server.Items.CeramicWine", "Server.Items.CeramicWater", "Server.Items.CeramicEmpty" )]
	public class CeramicMug : BaseBeverage
	{
		public override int BaseLabelNumber { get { return 1042982; } } // ceramic mug of ale
		public override int EmptyLabelNumber { get { return 1044133; } } // ceramic mug
		public override int MaxQuantity { get { return 1; } }

		public override int ComputeItemID()
		{
			Name = CliLocTable.Lookup( BaseLabelNumber + (int)Content );
			if( IsEmpty )
				Name = CliLocTable.Lookup( EmptyLabelNumber );

			if( ItemID >= 0x995 && ItemID <= 0x999 )
				return ItemID;
			else if( ItemID == 0x9CA )
				return ItemID;

			return 0x995;
		}

		[Constructable]
		public CeramicMug()
		{
			Weight = 1.0;
		}

		[Constructable]
		public CeramicMug( BeverageType type ): base( type )
		{
			Weight = 1.0;
		}

		public CeramicMug( Serial serial ): base( serial )
		{
		}

		public override void Serialize( GenericWriter writer )
		{
			base.Serialize( writer );
			writer.Write( (int)1 ); // version
		}

		public override void Deserialize( GenericReader reader )
		{
			base.Deserialize( reader );
			int version = reader.ReadInt();

			switch( version )
			{
				case 0:
					{
						if( CheckType( "CeramicAle" ) )
						{
							Quantity = MaxQuantity;
							Content = BeverageType.Ale;
						}
						else if( CheckType( "CeramicCider" ) )
						{
							Quantity = MaxQuantity;
							Content = BeverageType.Cider;
						}
						else if( CheckType( "CeramicLiquor" ) )
						{
							Quantity = MaxQuantity;
							Content = BeverageType.Liquor;
						}
						else if( CheckType( "CeramicMilk" ) )
						{
							Quantity = MaxQuantity;
							Content = BeverageType.Milk;
						}
						else if( CheckType( "CeramicWine" ) )
						{
							Quantity = MaxQuantity;
							Content = BeverageType.Wine;
						}
						else if( CheckType( "CeramicWater" ) )
						{
							Quantity = MaxQuantity;
							Content = BeverageType.Water;
						}
						else if( CheckType( "CeramicEmpty" ) )
						{
							Quantity = 0;
							Content = BeverageType.Water;
						}
						else
						{
							throw new Exception( World.LoadingType );
						}

						break;
					}
			}
		}
	}

	public class WaterBottle : BaseBeverage
	{
		public override int BaseLabelNumber { get { return 0; } }
		public override int EmptyLabelNumber { get { return 0; } }
		public override int MaxQuantity { get { return 1; } }
		public override bool Fillable { get { return false; } }
		public override bool Pourable { get { return false; } }

		public override int ComputeItemID()
		{
			return 0x1847;
		}

		[Constructable]
		public WaterBottle() : this( BeverageType.Water )
		{
			Name = "magical flask of water";
			Weight = 1.0;
		}

		[Constructable]
		public WaterBottle( BeverageType type ): base( type )
		{
			Name = "magical flask of water";
			Weight = 1.0;
		}

		public WaterBottle( Serial serial ): base( serial )
		{
		}

		public override void Serialize( GenericWriter writer )
		{
			base.Serialize( writer );
			writer.Write( (int)1 ); // version
		}

		public override void Deserialize( GenericReader reader )
		{
			base.Deserialize( reader );
			int version = reader.ReadInt();
			Quantity = MaxQuantity;
			Content = BeverageType.Water;
		}
	}

	[TypeAlias( "Server.Items.SkullAle", "Server.Items.SkullCider", "Server.Items.SkullLiquor", "Server.Items.SkullMilk", "Server.Items.SkullWine", "Server.Items.SkullWater", "Server.Items.SkullEmpty" )]
	public class SkullMug : BaseBeverage
	{
		public override int BaseLabelNumber { get { return 1042988; } } // skull mug of ale
		public override int EmptyLabelNumber { get { return 1044135; } } // skull mug
		public override int MaxQuantity { get { return 1; } }

		public override int ComputeItemID()
		{
			Name = CliLocTable.Lookup( BaseLabelNumber + (int)Content );
			if( IsEmpty )
				Name = CliLocTable.Lookup( EmptyLabelNumber );

			if( ItemID >= 0x0FFB && ItemID <= 0x0FFE )
				return ItemID;

			return 0x0FFB;
		}

		[Constructable]
		public SkullMug()
		{
			Weight = 1.0;
		}

		[Constructable]
		public SkullMug( BeverageType type ): base( type )
		{
			Weight = 1.0;
		}

		public SkullMug( Serial serial ): base( serial )
		{
		}

		public override void Serialize( GenericWriter writer )
		{
			base.Serialize( writer );
			writer.Write( (int)1 ); // version
		}

		public override void Deserialize( GenericReader reader )
		{
			base.Deserialize( reader );
			int version = reader.ReadInt();

			switch( version )
			{
				case 0:
					{
						if( CheckType( "SkullAle" ) )
						{
							Quantity = MaxQuantity;
							Content = BeverageType.Ale;
						}
						else if( CheckType( "SkullCider" ) )
						{
							Quantity = MaxQuantity;
							Content = BeverageType.Cider;
						}
						else if( CheckType( "SkullLiquor" ) )
						{
							Quantity = MaxQuantity;
							Content = BeverageType.Liquor;
						}
						else if( CheckType( "SkullMilk" ) )
						{
							Quantity = MaxQuantity;
							Content = BeverageType.Milk;
						}
						else if( CheckType( "SkullWine" ) )
						{
							Quantity = MaxQuantity;
							Content = BeverageType.Wine;
						}
						else if( CheckType( "SkullWater" ) )
						{
							Quantity = MaxQuantity;
							Content = BeverageType.Water;
						}
						else if( CheckType( "SkullEmpty" ) )
						{
							Quantity = 0;
							Content = BeverageType.Water;
						}
						else
						{
							throw new Exception( World.LoadingType );
						}

						break;
					}
			}
		}
	}

	[TypeAlias( "Server.Items.PewterAle", "Server.Items.PewterCider", "Server.Items.PewterLiquor", "Server.Items.PewterMilk", "Server.Items.PewterWine", "Server.Items.PewterWater", "Server.Items.PewterEmpty" )]
	public class PewterMug : BaseBeverage
	{
		public override int BaseLabelNumber { get { return 1042994; } } // pewter mug of ale
		public override int EmptyLabelNumber { get { return 1044134; } } // pewter mug
		public override int MaxQuantity { get { return 1; } }

		public override int ComputeItemID()
		{
			Name = CliLocTable.Lookup( BaseLabelNumber + (int)Content );
			if( IsEmpty )
				Name = CliLocTable.Lookup( EmptyLabelNumber );

			if( ItemID >= 0xFFF && ItemID <= 0x1002 )
				return ItemID;

			return 0xFFF;
		}

		[Constructable]
		public PewterMug()
		{
			Weight = 1.0;
		}

		[Constructable]
		public PewterMug( BeverageType type ): base( type )
		{
			Weight = 1.0;
		}

		public PewterMug( Serial serial ): base( serial )
		{
		}

		public override void Serialize( GenericWriter writer )
		{
			base.Serialize( writer );
			writer.Write( (int)1 ); // version
		}

		public override void Deserialize( GenericReader reader )
		{
			base.Deserialize( reader );
			int version = reader.ReadInt();

			switch( version )
			{
				case 0:
					{
						if( CheckType( "PewterAle" ) )
						{
							Quantity = MaxQuantity;
							Content = BeverageType.Ale;
						}
						else if( CheckType( "PewterCider" ) )
						{
							Quantity = MaxQuantity;
							Content = BeverageType.Cider;
						}
						else if( CheckType( "PewterLiquor" ) )
						{
							Quantity = MaxQuantity;
							Content = BeverageType.Liquor;
						}
						else if( CheckType( "PewterMilk" ) )
						{
							Quantity = MaxQuantity;
							Content = BeverageType.Milk;
						}
						else if( CheckType( "PewterWine" ) )
						{
							Quantity = MaxQuantity;
							Content = BeverageType.Wine;
						}
						else if( CheckType( "PewterWater" ) )
						{
							Quantity = MaxQuantity;
							Content = BeverageType.Water;
						}
						else if( CheckType( "PewterEmpty" ) )
						{
							Quantity = 0;
							Content = BeverageType.Water;
						}
						else
						{
							throw new Exception( World.LoadingType );
						}

						break;
					}
			}
		}
	}

	[TypeAlias( "Server.Items.GobletAle", "Server.Items.GobletCider", "Server.Items.GobletLiquor", "Server.Items.GobletMilk", "Server.Items.GobletWine", "Server.Items.GobletWater", "Server.Items.GobletEmpty" )]
	public class Goblet : BaseBeverage
	{
		public override int BaseLabelNumber { get { return 1043000; } } // goblet of ale
		public override int EmptyLabelNumber { get { return 1044136; } } // goblet
		public override int MaxQuantity { get { return 1; } }

		public override int ComputeItemID()
		{
			Name = CliLocTable.Lookup( BaseLabelNumber + (int)Content );
			if( IsEmpty )
				Name = CliLocTable.Lookup( EmptyLabelNumber );

			if( ItemID == 0x99A || ItemID == 0x9B3 || ItemID == 0x9BF || ItemID == 0x9CB )
				return ItemID;

			return 0x99A;
		}

		[Constructable]
		public Goblet()
		{
			Weight = 1.0;
		}

		[Constructable]
		public Goblet( BeverageType type ): base( type )
		{
			Weight = 1.0;
		}

		public Goblet( Serial serial ): base( serial )
		{
		}

		public override void Serialize( GenericWriter writer )
		{
			base.Serialize( writer );
			writer.Write( (int)1 ); // version
		}

		public override void Deserialize( GenericReader reader )
		{
			base.Deserialize( reader );
			int version = reader.ReadInt();

			switch( version )
			{
				case 0:
					{
						if( CheckType( "GobletAle" ) )
						{
							Quantity = MaxQuantity;
							Content = BeverageType.Ale;
						}
						else if( CheckType( "GobletCider" ) )
						{
							Quantity = MaxQuantity;
							Content = BeverageType.Cider;
						}
						else if( CheckType( "GobletLiquor" ) )
						{
							Quantity = MaxQuantity;
							Content = BeverageType.Liquor;
						}
						else if( CheckType( "GobletMilk" ) )
						{
							Quantity = MaxQuantity;
							Content = BeverageType.Milk;
						}
						else if( CheckType( "GobletWine" ) )
						{
							Quantity = MaxQuantity;
							Content = BeverageType.Wine;
						}
						else if( CheckType( "GobletWater" ) )
						{
							Quantity = MaxQuantity;
							Content = BeverageType.Water;
						}
						else if( CheckType( "GobletEmpty" ) )
						{
							Quantity = 0;
							Content = BeverageType.Water;
						}
						else
						{
							throw new Exception( World.LoadingType );
						}

						break;
					}
			}
		}
	}

	[TypeAlias( "Server.Items.GlassAle", "Server.Items.GlassCider", "Server.Items.GlassLiquor", "Server.Items.GlassMilk", "Server.Items.GlassWine", "Server.Items.GlassWater", "Server.Items.GlassEmpty" )]
	public class GlassMug : BaseBeverage
	{
		public override int BaseLabelNumber { get { return 1042976; } } // mug of ale
		public override int EmptyLabelNumber { get { return 1022456; } } // mug
		public override int MaxQuantity { get { return 1; } }

		public override int ComputeItemID()
		{
			Name = CliLocTable.Lookup( BaseLabelNumber + (int)Content );
			if( IsEmpty )
				Name = CliLocTable.Lookup( EmptyLabelNumber );

			if( IsEmpty )
				return ( ItemID >= 0x1F81 && ItemID <= 0x1F84 ? ItemID : 0x1F81 );

			switch( Content )
			{
				case BeverageType.Ale: return ( ItemID == 0x9EF ? 0x9EF : 0x9EE );
				case BeverageType.Cider: return ( ItemID >= 0x1F7D && ItemID <= 0x1F80 ? ItemID : 0x1F7D );
				case BeverageType.Liquor: return ( ItemID >= 0x1F85 && ItemID <= 0x1F88 ? ItemID : 0x1F85 );
				case BeverageType.Milk: return ( ItemID >= 0x1F89 && ItemID <= 0x1F8C ? ItemID : 0x1F89 );
				case BeverageType.Wine: return ( ItemID >= 0x1F8D && ItemID <= 0x1F90 ? ItemID : 0x1F8D );
				case BeverageType.Water: return ( ItemID >= 0x1F91 && ItemID <= 0x1F94 ? ItemID : 0x1F91 );
			}

			return 0;
		}

		[Constructable]
		public GlassMug()
		{
			Weight = 1.0;
		}

		[Constructable]
		public GlassMug( BeverageType type ): base( type )
		{
			Weight = 1.0;
		}

		public GlassMug( Serial serial ): base( serial )
		{
		}

		public override void Serialize( GenericWriter writer )
		{
			base.Serialize( writer );
			writer.Write( (int)1 ); // version
		}

		public override void Deserialize( GenericReader reader )
		{
			base.Deserialize( reader );

			int version = reader.ReadInt();

			switch( version )
			{
				case 0:
					{
						if( CheckType( "GlassAle" ) )
						{
							Quantity = MaxQuantity;
							Content = BeverageType.Ale;
						}
						else if( CheckType( "GlassCider" ) )
						{
							Quantity = MaxQuantity;
							Content = BeverageType.Cider;
						}
						else if( CheckType( "GlassLiquor" ) )
						{
							Quantity = MaxQuantity;
							Content = BeverageType.Liquor;
						}
						else if( CheckType( "GlassMilk" ) )
						{
							Quantity = MaxQuantity;
							Content = BeverageType.Milk;
						}
						else if( CheckType( "GlassWine" ) )
						{
							Quantity = MaxQuantity;
							Content = BeverageType.Wine;
						}
						else if( CheckType( "GlassWater" ) )
						{
							Quantity = MaxQuantity;
							Content = BeverageType.Water;
						}
						else if( CheckType( "GlassEmpty" ) )
						{
							Quantity = 0;
							Content = BeverageType.Water;
						}
						else
						{
							throw new Exception( World.LoadingType );
						}

						break;
					}
			}
		}
	}

	[TypeAlias( "Server.Items.PitcherAle", "Server.Items.PitcherCider", "Server.Items.PitcherLiquor", "Server.Items.PitcherMilk", "Server.Items.PitcherWine", "Server.Items.PitcherWater", "Server.Items.GlassPitcher" )]
	public class Pitcher : BaseBeverage
	{
		public override int BaseLabelNumber { get { return 1061722; } } // decanter of ale
		public override int EmptyLabelNumber { get { return 1061728; } } // decanter
		public override int MaxQuantity { get { return 10; } }

		public override int ComputeItemID()
		{
			Name = CliLocTable.Lookup( BaseLabelNumber + (int)Content );
			if( IsEmpty )
				Name = CliLocTable.Lookup( EmptyLabelNumber );

			switch( Content )
			{
				case BeverageType.Ale: Hue = 0x83B; break;
				case BeverageType.Cider: Hue = 0x981; break;
				case BeverageType.Liquor: Hue = 0xB51; break;
				case BeverageType.Milk: Hue = 0x9A3; break;
				case BeverageType.Wine: Hue = 0xB64; break;
				case BeverageType.Water: Hue = 0xB40; break;
			}

			if( IsEmpty )
				Hue = 0;

			return 0x65BA;
		}

		[Constructable]
		public Pitcher() : this( BeverageType.Water )
		{
			Weight = 3.0;
		}

		[Constructable]
		public Pitcher( BeverageType type ): base( type )
		{
			Weight = 3.0;
		}

		public Pitcher( Serial serial ): base( serial )
		{
		}

		public override void Serialize( GenericWriter writer )
		{
			base.Serialize( writer );
			writer.Write( (int)1 ); // version
		}

		public override void Deserialize( GenericReader reader )
		{
			if( CheckType( "PitcherWater" ) || CheckType( "GlassPitcher" ) )
				base.InternalDeserialize( reader, false );
			else
				base.InternalDeserialize( reader, true );

			int version = reader.ReadInt();

			switch( version )
			{
				case 0:
				{
					if( CheckType( "PitcherAle" ) )
					{
						Quantity = MaxQuantity;
						Content = BeverageType.Ale;
					}
					else if( CheckType( "PitcherCider" ) )
					{
						Quantity = MaxQuantity;
						Content = BeverageType.Cider;
					}
					else if( CheckType( "PitcherLiquor" ) )
					{
						Quantity = MaxQuantity;
						Content = BeverageType.Liquor;
					}
					else if( CheckType( "PitcherMilk" ) )
					{
						Quantity = MaxQuantity;
						Content = BeverageType.Milk;
					}
					else if( CheckType( "PitcherWine" ) )
					{
						Quantity = MaxQuantity;
						Content = BeverageType.Wine;
					}
					else if( CheckType( "PitcherWater" ) )
					{
						Quantity = MaxQuantity;
						Content = BeverageType.Water;
					}
					else if( CheckType( "GlassPitcher" ) )
					{
						Quantity = 0;
						Content = BeverageType.Water;
					}
					else
					{
						throw new Exception( World.LoadingType );
					}

					break;
				}
			}
		}
	}

	public abstract class BaseBeverage : Item, IHasQuantity
	{
		public override string DefaultDescription{ get{ return "Drinks can quench your thirst and sometimes be used in crafting. Beverages can be empty or filled with liquid. You can pour liquid from bottles in goblets and mugs. You can use an empty beverage container on a cow to milk it. If you want to quickly fill an empty container with water, use it near a water source. You can also single click the container and choose the fill option, where you can select a water source or cow. There are some single click menus available, dependent on the type of container. You can 'Fill' it up with liquid. If you want some in another container, you can 'Pour' it. You can 'Dump' the contents out on the ground. If you are thirsty, you can 'Drink', but if you want to drink as much of it as you can, you can always 'Drink Up'."; } }

		private BeverageType m_Content;
		private int m_Quantity;
		private Mobile m_Poisoner;
		private Poison m_Poison;

		public override int LabelNumber
		{
			get
			{
				Describe();
				int num = BaseLabelNumber;

				if( IsEmpty || num == 0 )
					return EmptyLabelNumber;

				return BaseLabelNumber + (int)m_Content;
			}
		}

		public virtual bool ShowQuantity { get { return ( MaxQuantity > 1 ); } }
		public virtual bool Fillable { get { return true; } }
		public virtual bool Pourable { get { return true; } }

		public virtual int EmptyLabelNumber { get { return base.LabelNumber; } }
		public virtual int BaseLabelNumber { get { return 0; } }

		public abstract int MaxQuantity { get; }

		public abstract int ComputeItemID();

		public void Describe(){ InfoData = DefaultDescription; }

		[CommandProperty( AccessLevel.GameMaster )]
		public bool IsEmpty
		{
			get { return ( m_Quantity <= 0 ); }
		}

		[CommandProperty( AccessLevel.GameMaster )]
		public bool ContainsAlchohol
		{
			get { return ( !IsEmpty && m_Content == BeverageType.Liquor ); }
		}

		[CommandProperty( AccessLevel.GameMaster )]
		public bool IsFull
		{
			get { return ( m_Quantity >= MaxQuantity ); }
		}

		[CommandProperty( AccessLevel.GameMaster )]
		public Poison Poison
		{
			get { return m_Poison; }
			set { m_Poison = value; }
		}

		[CommandProperty( AccessLevel.GameMaster )]
		public Mobile Poisoner
		{
			get { return m_Poisoner; }
			set { m_Poisoner = value; }
		}

		[CommandProperty( AccessLevel.GameMaster )]
		public BeverageType Content
		{
			get { return m_Content; }
			set
			{
				m_Content = value;
				Describe();

				InvalidateProperties();

				int itemID = ComputeItemID();

				if( itemID > 0 )
					ItemID = itemID;
				else
					Delete();
			}
		}

		[CommandProperty( AccessLevel.GameMaster )]
		public int Quantity
		{
			get { return m_Quantity; }
			set
			{
				Describe();
				if( value < 0 )
					value = 0;
				else if( value > MaxQuantity )
					value = MaxQuantity;

				m_Quantity = value;

				if ( m_Quantity < 1 )
				{
					Poisoner = null;
					Poison = null;
					Content = BeverageType.Water;
				}

				ColorText3 = "" + m_Quantity + " Drinks Remaining";
				ColorHue3 = "37AAFF";

				if ( ContainsAlchohol )
					ColorHue3 = "9CD674";

				if ( m_Quantity < 1 )
					ColorText3 = null;

				InvalidateProperties();

				int itemID = ComputeItemID();

				if( itemID > 0 )
					ItemID = itemID;
				else
					Delete();
			}
		}

		public virtual int GetQuantityDescription()
		{
			int perc = ( m_Quantity * 100 ) / MaxQuantity;

			if( perc <= 0 )
				return 1042975; // It's empty.
			else if( perc <= 33 )
				return 1042974; // It's nearly empty.
			else if( perc <= 66 )
				return 1042973; // It's half full.
			else
				return 1042972; // It's full.
		}

		public override void GetProperties( ObjectPropertyList list )
		{
			base.GetProperties( list );

			if( ShowQuantity )
				list.Add( GetQuantityDescription() );
		}

		public override void OnSingleClick( Mobile from )
		{
			base.OnSingleClick( from );

			if( ShowQuantity )
				LabelTo( from, GetQuantityDescription() );
		}

		public override void AddNameProperties( ObjectPropertyList list )
		{
			base.AddNameProperties( list );

			if( !IsEmpty )
			{
				if ( Content == BeverageType.Ale ){ list.Add( 1070722, "ale" ); }
				else if ( Content == BeverageType.Cider ){ list.Add( 1070722, "cider" ); }
				else if ( Content == BeverageType.Liquor ){ list.Add( 1070722, "liquor" ); }
				else if ( Content == BeverageType.Milk ){ list.Add( 1070722, "milk" ); }
				else if ( Content == BeverageType.Wine ){ list.Add( 1070722, "wine" ); }
				else if ( Content == BeverageType.Water ){ list.Add( 1070722, "water" ); }
			}

			switch( Content )
			{
				case BeverageType.Ale: list.Add( 1049644, "Thirst: 3"); break;
				case BeverageType.Cider: list.Add( 1049644, "Thirst: 2"); break;
				case BeverageType.Liquor: list.Add( 1049644, "Thirst: 1"); break;
				case BeverageType.Milk: list.Add( 1049644, "Thirst: 2"); break;
				case BeverageType.Wine: list.Add( 1049644, "Thirst: 2"); break;
				default: list.Add( 1049644, "Thirst: 1"); break;
			}
		}

		public override bool OnDroppedToMobile( Mobile from, Mobile target )
		{
			if ( target is PlayerMobile )
			{
				base.OnDroppedToMobile( from, target );
			}
			else if ( target is BaseCreature && ((BaseCreature)target).CheckFoodPreference( this ) )
			{
				return true;
			}
			else if ( target is BaseVendor && target.Region.IsPartOf( typeof( VillageRegion ) ) && Poison != null )
			{
				if ( Poison == Poison.Lesser ) { target.ApplyPoison( from, PoisonImpl.Lesser ); }
				else if ( Poison == Poison.Regular ) { target.ApplyPoison( from, PoisonImpl.Regular ); }
				else if ( Poison == Poison.Greater ) { target.ApplyPoison( from, PoisonImpl.Greater ); }
				else if ( Poison == Poison.Deadly ) { target.ApplyPoison( from, PoisonImpl.Deadly ); }
				else { target.ApplyPoison( from, PoisonImpl.Lethal ); }

				target.Say( "Poison!");

				target.PlaySound( target.Female ? 813 : 1087 );
				if ( !target.Mounted ) 
					target.Animate( 32, 5, 1, true, false, 0 );                     
				Puke puke = new Puke(); 
				puke.Map = target.Map; 
				puke.Location = target.Location;

				this.Delete();
			}
			else if ( target.Body == 0x191 || target.Body == 0x190 || target.Body == 606 || target.Body == 605 )
			{
				from.AddToBackpack ( this );
				target.Say( "That doesn't look good.");
			}
			else
			{
				from.AddToBackpack ( this );
				from.PrivateOverheadMessage(MessageType.Regular, 1150, false, "They don't seem to want that.", from.NetState);
			}

			return true;
		}

		public virtual bool ValidateUse( Mobile from, bool message )
		{
			if( Deleted )
				return false;

			if( !Movable && !Fillable )
			{
				Multis.BaseHouse house = Multis.BaseHouse.FindHouseAt( this );

				if( house == null || !house.IsLockedDown( this ) )
				{
					if( message )
						from.SendLocalizedMessage( 502946, "", 0x59 ); // That belongs to someone else.

					return false;
				}
			}

			if( from.Map != Map || !from.InRange( GetWorldLocation(), 2 ) || !from.InLOS( this ) )
			{
				if( message )
					from.LocalOverheadMessage( MessageType.Regular, 0x3B2, 1019045 ); // I can't reach that.

				return false;
			}

			return true;
		}

		public virtual void Fill_OnTarget( Mobile from, object targ )
		{
			if( !IsEmpty || !Fillable || !ValidateUse( from, false ) )
				return;

			if ( targ is StaticTarget )
			{
				int id = ((StaticTarget)targ).ItemID;

				if ( DrinkingFunctions.CheckWaterTarget( id ) )
				{
					Content = BeverageType.Water;
					Quantity = MaxQuantity;
					from.SendLocalizedMessage( 1010089 ); // You fill the container with water.
					from.PlaySound( 0x240 );
				}
			}
			else if ( targ is Item && DrinkingFunctions.CheckWaterTarget( ((Item)targ).ItemID ) )
			{
				int id = ((Item)targ).ItemID;

				if ( DrinkingFunctions.CheckWaterTarget( id ) )
				{
					Content = BeverageType.Water;
					Quantity = MaxQuantity;
					from.SendLocalizedMessage( 1010089 ); // You fill the container with water.
					from.PlaySound( 0x240 );
				}
			}
			else if( targ is Item )
			{
				Item item = (Item)targ;
				IWaterSource src;

				src = ( item as IWaterSource );

				if( src == null && item is AddonComponent )
					src = ( ( (AddonComponent)item ).Addon as IWaterSource );

				if( src == null || src.Quantity <= 0 )
					return;

				if( from.Map != item.Map || !from.InRange( item.GetWorldLocation(), 2 ) || !from.InLOS( item ) )
				{
					from.LocalOverheadMessage( MessageType.Regular, 0x3B2, 1019045 ); // I can't reach that.
					return;
				}

				this.Content = BeverageType.Water;
				this.Poison = null;
				this.Poisoner = null;

				if( src.Quantity > this.MaxQuantity )
				{
					this.Quantity = this.MaxQuantity;
					src.Quantity -= this.MaxQuantity;
				}
				else
				{
					this.Quantity += src.Quantity;
					src.Quantity = 0;
				}

				from.SendLocalizedMessage( 1010089 ); // You fill the container with water.
			}
			else if( targ is Cow )
			{
				Cow cow = (Cow)targ;

				if( cow.TryMilk( from ) )
				{
					Content = BeverageType.Milk;
					Quantity = MaxQuantity;
					from.SendLocalizedMessage( 1080197 ); // You fill the container with milk.
				}
			}
		}

		private static int[] m_SwampTiles = new int[]
			{
				0x9C4, 0x9EB,
				0x3D65, 0x3D65,
				0x3DC0, 0x3DD9,
				0x3DDB, 0x3DDC,
				0x3DDE, 0x3EF0,
				0x3FF6, 0x3FF6,
				0x3FFC, 0x3FFE,
			};

		#region Effects of achohol
		private static Hashtable m_Table = new Hashtable();

		public static void Initialize()
		{
			EventSink.Login += new LoginEventHandler( EventSink_Login );
		}

		private static void EventSink_Login( LoginEventArgs e )
		{
			CheckHeaveTimer( e.Mobile );
		}

		public static void CheckHeaveTimer( Mobile from )
		{
			if( from.BAC > 0 && from.Map != Map.Internal && !from.Deleted )
			{
				Timer t = (Timer)m_Table[ from ];

				if( t == null )
				{
					if( from.BAC > 60 )
						from.BAC = 60;

					t = new HeaveTimer( from );
					t.Start();

					m_Table[ from ] = t;
				}
			}
			else
			{
				Timer t = (Timer)m_Table[ from ];

				if( t != null )
				{
					t.Stop();
					m_Table.Remove( from );

					from.SendLocalizedMessage( 500850 ); // You feel sober.
				}
			}
		}

		private class HeaveTimer : Timer
		{
			private Mobile m_Drunk;

			public HeaveTimer( Mobile drunk )
				: base( TimeSpan.FromSeconds( 5.0 ), TimeSpan.FromSeconds( 5.0 ) )
			{
				m_Drunk = drunk;

				Priority = TimerPriority.OneSecond;
			}

			protected override void OnTick()
			{
				if( m_Drunk.Deleted || m_Drunk.Map == Map.Internal )
				{
					Stop();
					m_Table.Remove( m_Drunk );
				}
				else if( m_Drunk.Alive )
				{
					if( m_Drunk.BAC > 60 )
						m_Drunk.BAC = 60;

					// chance to get sober
					if( 10 > Utility.Random( 100 ) )
						--m_Drunk.BAC;

					// lose some stats
					m_Drunk.Stam -= 1;
					m_Drunk.Mana -= 1;

					if( Utility.Random( 1, 4 ) == 1 )
					{
						if( !m_Drunk.Mounted )
						{
							// turn in a random direction
							m_Drunk.Direction = (Direction)Utility.Random( 8 );

							// heave
							m_Drunk.Animate( 32, 5, 1, true, false, 0 );
						}

						// *hic*
						m_Drunk.PublicOverheadMessage( Network.MessageType.Regular, 0x3B2, 500849 );
					}

					if( m_Drunk.BAC <= 0 )
					{
						Stop();
						m_Table.Remove( m_Drunk );

						m_Drunk.SendLocalizedMessage( 500850 ); // You feel sober.
					}
				}
			}
		}

		#endregion

		public virtual void Pour_OnTarget( Mobile from, object targ )
		{
			if ( !(this is WaterBottle) && ( IsEmpty || !Pourable || !ValidateUse( from, false ) ) )
				return;

			if( targ is BaseBeverage )
			{
				BaseBeverage bev = (BaseBeverage)targ;

				if( !bev.ValidateUse( from, true ) )
					return;

				if( bev.IsFull && bev.Content == this.Content )
				{
					from.SendLocalizedMessage( 500848 ); // Couldn't pour it there.  It was already full.
				}
				else if( !bev.IsEmpty )
				{
					from.SendLocalizedMessage( 500846 ); // Can't pour it there.
				}
				else
				{
					bev.Content = this.Content;
					bev.Poison = this.Poison;
					bev.Poisoner = this.Poisoner;

					if( this.Quantity > bev.MaxQuantity )
					{
						bev.Quantity = bev.MaxQuantity;
						this.Quantity -= bev.MaxQuantity;
					}
					else
					{
						bev.Quantity += this.Quantity;
						this.Quantity = 0;
					}

					from.PlaySound( 0x4E );
				}
			}
			else if ( from == targ && from.Thirst >= 20 )
			{
				from.SendMessage( "You are too quenched to drink more." );
			}
			else if ( from == targ )
			{
				int thirst = 1;

				switch( Content )
				{
					case BeverageType.Ale: thirst = 3; break;
					case BeverageType.Cider: thirst = 2; break;
					case BeverageType.Liquor: thirst = 1; break;
					case BeverageType.Milk: thirst = 2; break;
					case BeverageType.Wine: thirst = 2; break;
				}

				if( from.Thirst < 20 )
				{
					if ( from.Thirst < 5 )
						from.SendMessage( "You drink the liquid but are still extremely thirsty" );
					else if ( from.Thirst < 10 )
						from.SendMessage( "You drink the liquid and feel less thirsty" );
					else if ( from.Thirst < 15 )
						from.SendMessage( "You drink the liquid and feel much less thirsty" ); 
					else
						from.SendMessage( "You drink the liquid and are no longer thirsty" );

					from.Thirst += thirst;
				}

				if( ContainsAlchohol )
				{
					int bac = 2;

					from.BAC += bac;

					if( from.BAC > 60 )
						from.BAC = 60;

					CheckHeaveTimer( from );
				}

				from.PlaySound( Utility.RandomList( 0x30, 0x2D6 ) );

				if( m_Poison != null )
					from.ApplyPoison( m_Poisoner, m_Poison );

				--Quantity;

				if ( this is WaterBottle && IsEmpty )
					this.Delete();
			}
			else
			{
				from.SendLocalizedMessage( 500846 ); // Can't pour it there.
			}
		}

		public override void OnDoubleClick( Mobile from )
		{
			if ( !from.InRange( this.GetWorldLocation(), 1 ) )
			{
				from.SendMessage( "That is too far away!" );
				return;
			}

			bool WellNearby;
			DrinkingFunctions.CheckWater( from, 3, out WellNearby );

			if ( WellNearby && Fillable && ( IsEmpty || ( Content == BeverageType.Water && Quantity < MaxQuantity ) ) )
			{
				from.PlaySound( 0x240 );
				Content = BeverageType.Water;
				Quantity = MaxQuantity;
				from.SendLocalizedMessage( 1010089 ); // You fill the container with water.
			}
			else if ( IsEmpty && !Fillable )
				from.SendMessage( "That is empty and can no longer be filled." );
			else if ( IsEmpty && Fillable )
				from.SendMessage( "That is empty and will need to be refilled." );
			else if( ValidateUse( from, true ) )
				Pour_OnTarget( from, from );
		}

		public class PourMenu : ContextMenuEntry 
		{ 
			private BaseBeverage i_Beverage; 
			private Mobile m_From; 

			public PourMenu( Mobile from, BaseBeverage drink ) : base( 6250, 1 ) 
			{ 
				m_From = from; 
				i_Beverage = drink; 
			} 

			public override void OnClick() 
			{          
				if( i_Beverage.IsChildOf( m_From.Backpack ) ) 
				{ 
					m_From.BeginTarget( -1, true, TargetFlags.None, new TargetCallback( i_Beverage.Pour_OnTarget ) );
					m_From.SendLocalizedMessage( 1010086 ); // What do you want to use this on?
				} 
				else 
				{
					m_From.SendMessage( "This must be in your backpack to use." );
				} 
			} 
		} 

		public class DumpMenu : ContextMenuEntry 
		{ 
			private BaseBeverage i_Beverage; 
			private Mobile m_From; 

			public DumpMenu( Mobile from, BaseBeverage drink ) : base( 6256, 1 ) 
			{ 
				m_From = from; 
				i_Beverage = drink; 
			} 

			public override void OnClick() 
			{          
				if( i_Beverage.IsChildOf( m_From.Backpack ) ) 
				{ 
					m_From.PlaySound( 0x23F );
					i_Beverage.Poisoner = null;
					i_Beverage.Poison = null;
					i_Beverage.Content = BeverageType.Water;
					i_Beverage.Quantity = 0;
					m_From.SendMessage( "You dump out the liquid." );
				} 
				else 
				{
					m_From.SendMessage( "This must be in your backpack to dump out." );
				} 
			} 
		} 

		public class FillMenu : ContextMenuEntry 
		{ 
			private BaseBeverage i_Beverage; 
			private Mobile m_From; 

			public FillMenu( Mobile from, BaseBeverage drink ) : base( 6255, 1 ) 
			{ 
				m_From = from; 
				i_Beverage = drink; 
			} 

			public override void OnClick() 
			{          
				if( i_Beverage.IsChildOf( m_From.Backpack ) ) 
				{ 
					m_From.BeginTarget( -1, true, TargetFlags.None, new TargetCallback( i_Beverage.Fill_OnTarget ) );
					m_From.SendLocalizedMessage( 500837 ); // Fill from what?
				} 
				else 
				{
					m_From.SendMessage( "This must be in your backpack to use." );
				} 
			} 
		} 

		public override void GetContextMenuEntries( Mobile from, List<ContextMenuEntry> list ) 
		{
			base.GetContextMenuEntries( from, list );

			if ( from.Alive && IsEmpty )
			{
				if( !Fillable || !ValidateUse( from, true ) ){} else
					list.Add( new FillMenu( from, this ) );
			}
			else if ( from.Alive && Pourable && ValidateUse( from, true ) )
				list.Add( new PourMenu( from, this ) );

			if ( from.Alive && !IsEmpty )
			{
				list.Add( new DumpMenu( from, this ) );
				list.Add( new ContextMenus.GulpEntry( from, this ) );

				if ( Quantity > 1 )
					list.Add( new ContextMenus.GulpMaxEntry( from, this ) );
			}
		}

		public static bool ConsumeTotal( Container pack, BeverageType content, int quantity )
		{
			return ConsumeTotal( pack, typeof( BaseBeverage ), content, quantity );
		}

		public static bool ConsumeTotal( Container pack, Type itemType, BeverageType content, int quantity )
		{
			Item[] items = pack.FindItemsByType( itemType );

			// First pass, compute total
			int total = 0;

			for( int i = 0; i < items.Length; ++i )
			{
				BaseBeverage bev = items[ i ] as BaseBeverage;

				if( bev != null && bev.Content == content && !bev.IsEmpty )
					total += bev.Quantity;
			}

			if( total >= quantity )
			{
				// We've enough, so consume it

				int need = quantity;

				for( int i = 0; i < items.Length; ++i )
				{
					BaseBeverage bev = items[ i ] as BaseBeverage;

					if( bev == null || bev.Content != content || bev.IsEmpty )
						continue;

					int theirQuantity = bev.Quantity;

					if( theirQuantity < need )
					{
						bev.Quantity = 0;
						need -= theirQuantity;
					}
					else
					{
						bev.Quantity -= need;
						return true;
					}
				}
			}

			return false;
		}

		public BaseBeverage()
		{
			ItemID = ComputeItemID();
		}

		public BaseBeverage( BeverageType type )
		{
			m_Content = type;
			Quantity = MaxQuantity;
			ItemID = ComputeItemID();
		}

		public BaseBeverage( Serial serial ): base( serial )
		{
		}

		public override void Serialize( GenericWriter writer )
		{
			base.Serialize( writer );
			writer.Write( (int)1 ); // version
			writer.Write( (Mobile)m_Poisoner );
			Poison.Serialize( m_Poison, writer );
			writer.Write( (int)m_Content );
			writer.Write( (int)m_Quantity );
		}

		protected bool CheckType( string name )
		{
			return ( World.LoadingType == String.Format( "Server.Items.{0}", name ) );
		}

		public override void Deserialize( GenericReader reader )
		{
			InternalDeserialize( reader, true );
		}

		protected void InternalDeserialize( GenericReader reader, bool read )
		{
			base.Deserialize( reader );

			if( !read )
				return;

			int version = reader.ReadInt();

			switch( version )
			{
				case 1:
					{
						m_Poisoner = reader.ReadMobile();
						goto case 0;
					}
				case 0:
					{
						m_Poison = Poison.Deserialize( reader );
						m_Content = (BeverageType)reader.ReadInt();
						m_Quantity = reader.ReadInt();
						break;
					}
			}
		}
	}
}