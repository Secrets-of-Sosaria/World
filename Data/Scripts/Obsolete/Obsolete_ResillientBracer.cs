using System;

namespace Server.Items
{
	public class ResilientBracer : GoldBracelet
	{
		public override int LabelNumber{ get{ return 1072933; } } // Resillient Bracer

		public override int PhysicalResistance{ get { return 20; } }

		[Constructable]
		public ResilientBracer()
		{
			Hue = 0x488;

			SkillBonuses.SetValues( 0, SkillName.MagicResist, 15.0 );

			Attributes.BonusHits = 5;
			Attributes.RegenHits = 2;
			Attributes.DefendChance = 10;
		}

        public override void AddNameProperties(ObjectPropertyList list)
		{
            base.AddNameProperties(list);
			list.Add( 1070722, "Artefact");
        }

		public ResilientBracer( Serial serial ) : base( serial )
		{
		}

		public override void Serialize( GenericWriter writer )
		{
			base.Serialize( writer );

			writer.WriteEncodedInt( 0 ); // version
		}

		private void Cleanup( object state ){ Item item = new Artifact_ResilientBracer(); Server.Misc.Cleanup.DoCleanup( (Item)state, item ); }

public override void Deserialize( GenericReader reader )
		{
			base.Deserialize( reader ); Timer.DelayCall( TimeSpan.FromSeconds( 1.0 ), new TimerStateCallback( Cleanup ), this );

			int version = reader.ReadEncodedInt();
		}
	}
}
