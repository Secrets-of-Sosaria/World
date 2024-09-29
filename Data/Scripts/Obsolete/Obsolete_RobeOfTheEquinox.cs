using System;
using Server;

namespace Server.Items
{
	public class RobeOfTheEquinox : MagicRobe
	{
		[Constructable]
		public RobeOfTheEquinox()
		{
			ItemID = 0x1F04;
			Name = "Robe of the Equinox";
			Hue = 0xD6;
			Attributes.Luck = 200;
			Resistances.Physical = 10;
			Attributes.CastRecovery = 1;
			Attributes.CastSpeed = 1;
			Attributes.LowerManaCost = 25;
			SkillBonuses.SetValues(0, SkillName.Magery, 20);
			SkillBonuses.SetValues(1, SkillName.Psychology, 10);
		}

        public override void AddNameProperties(ObjectPropertyList list)
		{
            base.AddNameProperties(list);
			list.Add( 1070722, "Artefact");
        }

		public RobeOfTheEquinox( Serial serial ) : base( serial )
		{
		}

		public override void Serialize( GenericWriter writer )
		{
			base.Serialize( writer );
			writer.Write( (int) 0 ); // version
		}

		private void Cleanup( object state ){ Item item = new Artifact_RobeOfTheEquinox(); Server.Misc.Cleanup.DoCleanup( (Item)state, item ); }

public override void Deserialize( GenericReader reader )
		{
			base.Deserialize( reader ); Timer.DelayCall( TimeSpan.FromSeconds( 1.0 ), new TimerStateCallback( Cleanup ), this );
			int version = reader.ReadInt();
		}
	}
}