using Server;
using System;
using System.Collections;
using Server.Network;
using Server.Targeting;
using Server.Prompts;
using Server.Misc;

namespace Server.Items
{
	public class RareMetals : Item
	{
		[Constructable]
		public RareMetals() : this( 1, "silver stones" )
		{
		}

		[Constructable]
		public RareMetals( int amount, string name ) : base( 0x19B9 )
		{
			Weight = 12.0;
			Stackable = true;
			Amount = amount;
			Name = name;
		}

		public RareMetals( Serial serial ) : base( serial )
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

			if ( name == "onyx stones" ){ item = new OnyxStone(); }
			else if ( name == "quartz stones" ){ item = new QuartzStone(); }
			else if ( name == "ruby stones" ){ item = new RubyStone(); }
			else if ( name == "sapphire stones" ){ item = new SapphireStone(); }
			else if ( name == "spinel stones" ){ item = new SpinelStone(); }
			else if ( name == "topaz stones" ){ item = new TopazStone(); }
			else if ( name == "amethyst stones" ){ item = new AmethystStone(); }
			else if ( name == "emerald stones" ){ item = new EmeraldStone(); }
			else if ( name == "garnet stones" ){ item = new GarnetStone(); }
			else if ( name == "star ruby stones" ){ item = new StarRubyStone(); }
			else if ( name == "gargish marble stones" ){ item = new MarbleStone(); }
			else if ( name == "jade stones" ){ item = new JadeStone(); }
			else if ( name == "mystical ice stones" ){ item = new IceStone(); }
			else if ( name == "silver stones" ){ item = new SilverStone(); }
			else if ( name == "copper stones" ){ item = new CopperOre(); }
			else if ( name == "verite stones" ){ item = new VeriteOre(); }
			else if ( name == "valorite stones" ){ item = new ValoriteOre(); }
			else if ( name == "agapite stones" ){ item = new AgapiteOre(); }
			else if ( name == "bronze stones" ){ item = new BronzeOre(); }
			else if ( name == "dull copper stones" ){ item = new DullCopperOre(); }
			else if ( name == "gold stones" ){ item = new GoldOre(); }
			else if ( name == "shadow iron stones" ){ item = new ShadowIronOre(); }
			else if ( name == "mithril stones" ){ item = new MithrilOre(); }
			else if ( name == "xormite stones" ){ item = new XormiteOre(); }
			else if ( name == "obsidian stones" ){ item = new ObsidianOre(); }
			else if ( name == "nepturite stones" ){ item = new NepturiteOre(); }

			if ( item == null )
				item = new IronOre();

			item.Amount = ((Item)state).Amount;

			Server.Misc.Cleanup.DoCleanup( (Item)state, item );
		}
	}
}