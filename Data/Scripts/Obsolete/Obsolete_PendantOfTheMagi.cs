using System;

namespace Server.Items
{
	public class PendantOfTheMagi : GoldNecklace
	{
		public override int LabelNumber{ get{ return 1072937; } } // Pendant of the Magi

		[Constructable]
		public PendantOfTheMagi()
		{
			Hue = 0x48D;
			Attributes.BonusInt = 10;
			Attributes.RegenMana = 3;
			Attributes.SpellDamage = 5;
			Attributes.LowerManaCost = 10;
			Attributes.LowerRegCost = 30;
		}

        public override void AddNameProperties(ObjectPropertyList list)
		{
            base.AddNameProperties(list);
			list.Add( 1070722, "Artefact");
        }

		public PendantOfTheMagi( Serial serial ) : base( serial )
		{
		}

		public override void Serialize( GenericWriter writer )
		{
			base.Serialize( writer );

			writer.WriteEncodedInt( 0 ); // version
		}

		private void Cleanup( object state ){ Item item = new Artifact_PendantOfTheMagi(); Server.Misc.Cleanup.DoCleanup( (Item)state, item ); }

public override void Deserialize( GenericReader reader )
		{
			base.Deserialize( reader ); Timer.DelayCall( TimeSpan.FromSeconds( 1.0 ), new TimerStateCallback( Cleanup ), this );

			int version = reader.ReadEncodedInt();
		}
	}
}
