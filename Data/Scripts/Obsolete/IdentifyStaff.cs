using System;
using Server;
using Server.Spells.Magical;
using Server.Targeting;

namespace Server.Items
{
	public class IdentifyStaff : BaseMagicStaff
	{
		[Constructable]
		public IdentifyStaff() : base( MagicStaffEffect.Charges, 5, 10 )
		{
			IntRequirement = 0;			Name = "wand of identification";
		}

		public IdentifyStaff( Serial serial ) : base( serial )
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
			Timer.DelayCall( TimeSpan.FromSeconds( 1.0 ), new TimerStateCallback( Cleanup ), this );
		}

		private void Cleanup( object state )
		{
			Item item = new ArtifactManual();
			Server.Misc.Cleanup.DoCleanup( (Item)state, item );
		}

		public override void OnMagicStaffUse( Mobile from )
		{
			Cast( new IdentifySpell( from, this ) );
		}
	}
}