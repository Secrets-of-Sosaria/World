using System;
using Server;

namespace Server.Items
{
	public class RobeOfTheEclipse : MagicRobe
	{
		[Constructable]
		public RobeOfTheEclipse()
		{
			ItemID = 0x1F04;
			Name = "Robe of the Eclipse";
			Hue = 0x486;
			Attributes.Luck = 200;
			Resistances.Physical = 10;
			Attributes.CastRecovery = 1;
			Attributes.CastSpeed = 1;
			Attributes.LowerManaCost = 25;
			SkillBonuses.SetValues(0, SkillName.Necromancy, 20);
			SkillBonuses.SetValues(1, SkillName.Spiritualism, 10);
		}

        public override void AddNameProperties(ObjectPropertyList list)
		{
            base.AddNameProperties(list);
			list.Add( 1070722, "Artefact");
        }

		public RobeOfTheEclipse( Serial serial ) : base( serial )
		{
		}

		public override void Serialize( GenericWriter writer )
		{
			base.Serialize( writer );
			writer.Write( (int) 0 ); // version
		}

		private void Cleanup( object state ){ Item item = new Artifact_RobeOfTheEclipse(); Server.Misc.Cleanup.DoCleanup( (Item)state, item ); }

public override void Deserialize( GenericReader reader )
		{
			base.Deserialize( reader ); Timer.DelayCall( TimeSpan.FromSeconds( 1.0 ), new TimerStateCallback( Cleanup ), this );
			int version = reader.ReadInt();
		}
	}
}