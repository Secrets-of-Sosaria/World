using System;

namespace Server.Items
{
	public class EssenceOfBattle : GoldRing
	{
		public override int LabelNumber{ get{ return 1072935; } } // Essence of Battle

		[Constructable]
		public EssenceOfBattle()
		{
			Hue = 0x550;
			ItemID = 0x4CF6;
			Attributes.BonusDex = 7;
			Attributes.BonusStr = 7;
			Attributes.WeaponDamage = 30;
		}

        public override void AddNameProperties(ObjectPropertyList list)
		{
            base.AddNameProperties(list);
			list.Add( 1070722, "Artefact");
        }

		public EssenceOfBattle( Serial serial ) : base( serial )
		{
		}

		public override void Serialize( GenericWriter writer )
		{
			base.Serialize( writer );

			writer.WriteEncodedInt( 0 ); // version
		}

		private void Cleanup( object state ){ Item item = new Artifact_EssenceOfBattle(); Server.Misc.Cleanup.DoCleanup( (Item)state, item ); }

public override void Deserialize( GenericReader reader )
		{
			base.Deserialize( reader ); Timer.DelayCall( TimeSpan.FromSeconds( 1.0 ), new TimerStateCallback( Cleanup ), this );

			int version = reader.ReadEncodedInt();
		}
	}
}
