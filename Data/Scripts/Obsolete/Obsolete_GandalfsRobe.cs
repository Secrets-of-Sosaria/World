using System;
using Server;

namespace Server.Items
{
	public class GandalfsRobe : MagicRobe
	{
		[Constructable]
		public GandalfsRobe()
		{
			Hue = 0xB89;
			ItemID = 0x26AE;
			Name = "Merlin's Mystical Robe";
			Attributes.LowerManaCost = 25;
			Attributes.LowerRegCost = 25;
			SkillBonuses.SetValues( 0, SkillName.Psychology, 10 );
			SkillBonuses.SetValues( 1, SkillName.Magery, 10 );
			SkillBonuses.SetValues( 2, SkillName.MagicResist, 10 );
			SkillBonuses.SetValues( 3, SkillName.Meditation, 10 );
			Attributes.RegenMana = 10;
			Attributes.BonusInt = 10;
		}

        public override void AddNameProperties(ObjectPropertyList list)
		{
            base.AddNameProperties(list);
			list.Add( 1070722, "Artefact");
        }

		public GandalfsRobe( Serial serial ) : base( serial )
		{
		}

		public override void Serialize( GenericWriter writer )
		{
			base.Serialize( writer );
			writer.Write( (int) 0 ); // version
		}

		private void Cleanup( object state ){ Item item = new Artifact_GandalfsRobe(); Server.Misc.Cleanup.DoCleanup( (Item)state, item ); }

public override void Deserialize( GenericReader reader )
		{
			base.Deserialize( reader ); Timer.DelayCall( TimeSpan.FromSeconds( 1.0 ), new TimerStateCallback( Cleanup ), this );
			int version = reader.ReadInt();
		}
	}
}