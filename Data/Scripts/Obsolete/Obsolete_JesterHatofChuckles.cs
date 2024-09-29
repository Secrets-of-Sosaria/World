using System;
using System.Collections.Generic;
using System.Text;

namespace Server.Items
{
	public class JesterHatofChuckles : MagicHat
	{
		[Constructable]
		public JesterHatofChuckles()
		{
			Name = "Jester Hat of Chuckles";
			ItemID = 5916;
			Hue = Utility.RandomList( 0x13e, 0x03, 0x172, 0x3f );
			Attributes.Luck = 300;
			Resistances.Physical = 12;
			Resistances.Cold = 12;
			Resistances.Energy = 12;
			Resistances.Fire = 12;
			Resistances.Poison = 12;
		}

		public JesterHatofChuckles( Serial serial ) : base( serial )
		{
		}

		public override void Serialize( GenericWriter writer )
		{
			base.Serialize( writer );
			writer.Write( (int) 0 ); // version
		}

		private void Cleanup( object state ){ Item item = new Artifact_JesterHatofChuckles(); Server.Misc.Cleanup.DoCleanup( (Item)state, item ); }

public override void Deserialize( GenericReader reader )
		{
			base.Deserialize( reader ); Timer.DelayCall( TimeSpan.FromSeconds( 1.0 ), new TimerStateCallback( Cleanup ), this );
			int version = reader.ReadInt();
		}
	}
}
