using Server;
using System;
using System.Collections;
using Server.Network;
using Server.Targeting;
using Server.Prompts;
using Server.Misc;

namespace Server.Items
{
	public class HardCrystals : Item
	{
		[Constructable]
		public HardCrystals() : this( 1, "crystalline rock" )
		{
		}

		[Constructable]
		public HardCrystals( int amount, string name ) : base( 0x3003 )
		{
			Weight = 0.01;
			Stackable = true;
			Amount = amount;
			Name = name;

			string material = "";
		}

		public HardCrystals( Serial serial ) : base( serial )
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
			Item item = null;

			if ( Name == "crystalline dull copper" ){ item = new IronOre(); }
			else if ( Name == "crystalline shadow iron" ){ item = new ShadowIronOre(); }
			else if ( Name == "crystalline copper" ){ item = new CopperOre(); }
			else if ( Name == "crystalline bronze" ){ item = new BronzeOre(); }
			else if ( Name == "crystalline gold" ){ item = new GoldOre(); }
			else if ( Name == "crystalline agapite" ){ item = new AgapiteOre(); }
			else if ( Name == "crystalline verite" ){ item = new VeriteOre(); }
			else if ( Name == "crystalline valorite" ){ item = new ValoriteOre(); }
			else if ( Name == "crystalline caddellite" ){ item = new CaddelliteStone(); }
			else if ( Name == "crystalline onyx" ){ item = new OnyxStone(); }
			else if ( Name == "crystalline quartz" ){ item = new QuartzStone(); }
			else if ( Name == "crystalline ruby" ){ item = new RubyStone(); }
			else if ( Name == "crystalline sapphire" ){ item = new SapphireStone(); }
			else if ( Name == "crystalline spinel" ){ item = new SpinelStone(); }
			else if ( Name == "crystalline topaz" ){ item = new TopazStone(); }
			else if ( Name == "crystalline amethyst" ){ item = new AmethystStone(); }
			else if ( Name == "crystalline emerald" ){ item = new EmeraldStone(); }
			else if ( Name == "crystalline garnet" ){ item = new GarnetStone(); }
			else if ( Name == "crystalline silver" ){ item = new SilverStone(); }
			else if ( Name == "crystalline star ruby" ){ item = new StarRubyStone(); }
			else if ( Name == "crystalline marble" ){ item = new MarbleStone(); }
			else if ( Name == "crystalline jade" ){ item = new JadeStone(); }
			else if ( Name == "crystalline ice" ){ item = new IceStone(); }
			else if ( Name == "crystalline obsidian" ){ item = new ObsidianOre(); }
			else if ( Name == "crystalline nepturite" ){ item = new NepturiteOre(); }
			else if ( Name == "crystalline steel" ){ item = new SteelIngot(); }
			else if ( Name == "crystalline brass" ){ item = new BrassIngot(); }
			else if ( Name == "crystalline mithril" ){ item = new MithrilOre(); }
			else if ( Name == "crystalline xormite" ){ item = new XormiteOre(); }

			if ( item == null )
				item = new IronOre();

			item.Amount = ((Item)state).Amount;
			Server.Misc.Cleanup.DoCleanup( (Item)state, item );
		}
	}
}