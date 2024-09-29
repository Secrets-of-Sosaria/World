using Server;
using System;
using System.Collections;
using Server.Network;
using Server.Targeting;
using Server.Prompts;
using Server.Misc;

namespace Server.Items
{
	public class HardScales : Item
	{
		[Constructable]
		public HardScales() : this( 1, "scales" )
		{
		}

		[Constructable]
		public HardScales( int amount, string name ) : base( 0x26B2 )
		{
			Weight = 0.01;
			Stackable = true;
			Amount = amount;
			Name = name;
		}

		public HardScales( Serial serial ) : base( serial )
		{
		}

		public override void Serialize( GenericWriter writer )
		{
			base.Serialize( writer );
			writer.Write( ( int) 0 ); // version
		}

		public override void Deserialize( GenericReader reader )
		{
			base.Deserialize( reader );
			int version = reader.ReadInt();
			Timer.DelayCall( TimeSpan.FromSeconds( 1.0 ), new TimerStateCallback( Cleanup ), this );
		}

		private void Cleanup( object state )
		{
			string name = ((Item)state).Name;
			Item item = null;

			if ( name == "dull copper scales" ){ 			item = new BrazenScales(); }
			else if ( name == "shadow iron scales" ){ 		item = new BlackScales(); }
			else if ( name == "copper scales" ){ 			item = new UmberScales(); }
			else if ( name == "bronze scales" ){ 			item = new UmberScales(); }
			else if ( name == "gold scales" ){ 				item = new YellowScales(); }
			else if ( name == "agapite scales" ){ 			item = new VioletScales(); }
			else if ( name == "verite scales" ){ 			item = new GreenScales(); }
			else if ( name == "valorite scales" ){ 			item = new BlueScales(); }
			else if ( name == "caddellite scales" ){ 		item = new CadalyteScales(); }
			else if ( name == "onyx scales" ){ 				item = new BlackScales(); }
			else if ( name == "quartz scales" ){ 			item = new YellowScales(); }
			else if ( name == "ruby scales" ){ 				item = new RedScales(); }
			else if ( name == "sapphire scales" ){ 			item = new BlueScales(); }
			else if ( name == "spinel scales" ){ 			item = new VioletScales(); }
			else if ( name == "topaz scales" ){ 			item = new GreenScales(); }
			else if ( name == "amethyst scales" ){ 			item = new VioletScales(); }
			else if ( name == "emerald scales" ){ 			item = new GreenScales(); }
			else if ( name == "garnet scales" ){ 			item = new GreenScales(); }
			else if ( name == "silver scales" ){ 			item = new MetallicScales(); }
			else if ( name == "star ruby scales" ){ 		item = new RedScales(); }
			else if ( name == "marble scales" ){ 			item = new WhiteScales(); }
			else if ( name == "jade scales" ){ 				item = new GreenScales(); }
			else if ( name == "ice scales" ){ 				item = new PlatinumScales(); }
			else if ( name == "obsidian scales" ){ 			item = new BlackScales(); }
			else if ( name == "nepturite scales" ){ 		item = new BlueScales(); }
			else if ( name == "steel scales" ){ 			item = new PlatinumScales(); }	
			else if ( name == "brass scales" ){ 			item = new YellowScales(); }
			else if ( name == "mithril scales" ){ 			item = new WhiteScales(); }
			else if ( name == "xormite scales" ){ 			item = new GreenScales(); }
			else if ( name == "iron scales" ){ 				item = new MetallicScales(); }

			if ( item == null )
				item = new RedScales();

			item.Amount = ((Item)state).Amount;

			Server.Misc.Cleanup.DoCleanup( (Item)state, item );
		}
	}
}

namespace Server.Items
{
	public class CrystalScales : Item
	{
		[Constructable]
		public CrystalScales() : base( 0x2DA )
		{
			Weight = Utility.RandomMinMax( 10, 25 );
			ItemID = 0x1444;
			Light = LightType.Circle300;
			Name = "sparkling crystal";
		}

		public CrystalScales(Serial serial) : base(serial)
		{
		}

		public override void Serialize( GenericWriter writer )
		{
			base.Serialize( writer );
            writer.Write( (int) 0 ); // version
		}

		public override void Deserialize( GenericReader reader )
		{
			base.Deserialize( reader );
            int version = reader.ReadInt();
			this.Delete();
		}
	}
}