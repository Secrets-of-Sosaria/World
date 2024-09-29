using System;
using Server.Network;
using Server.Items;

namespace Server.Items
{
	public class TheNightReaper : RepeatingCrossbow
	{
		public override int LabelNumber{ get{ return 1072912; } } // The Night Reaper

		[Constructable]
		public TheNightReaper()
		{
			Name = "Night Reaper";
			ItemID = 0x26CD;
			Hue = 0x41C;

			Slayer = SlayerName.Exorcism;
			Attributes.NightSight = 1;
			Attributes.WeaponSpeed = 25;
			Attributes.WeaponDamage = 55;
		}

        public override void AddNameProperties(ObjectPropertyList list)
		{
            base.AddNameProperties(list);
			list.Add( 1070722, "Artefact");
        }

		public TheNightReaper( Serial serial ) : base( serial )
		{
		}

		public override void Serialize( GenericWriter writer )
		{
			base.Serialize( writer );

			writer.Write( (int) 0 ); // version
		}

		private void Cleanup( object state ){ Item item = new Artifact_TheNightReaper(); Server.Misc.Cleanup.DoCleanup( (Item)state, item ); }

public override void Deserialize( GenericReader reader )
		{
			base.Deserialize( reader ); Timer.DelayCall( TimeSpan.FromSeconds( 1.0 ), new TimerStateCallback( Cleanup ), this );

			int version = reader.ReadInt();
		}
	}
}