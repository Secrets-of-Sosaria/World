using System;
using Server.Items;

namespace Server.Items
{
	public class Pestilence: BaseQuiver
	{		
		[Constructable]
		public Pestilence() : base()
        {
			Name = "Pestilence";
			Hue = 1151;
            DamageIncrease = 5;
			Attributes.DefendChance = 5;
			Attributes.AttackChance = 5;
			LowerAmmoCost = 5;
			WeightReduction = 100;
		}

        public override void AddNameProperties(ObjectPropertyList list)
		{
            base.AddNameProperties(list);
			list.Add( 1070722, "Artefact");
        }

		public Pestilence( Serial serial ) : base( serial )
		{
		}

		public override void Serialize( GenericWriter writer )
		{
			base.Serialize( writer );

			writer.Write( (int) 0 ); // version
		}

		private void Cleanup( object state ){ Item item = new Artifact_Pestilence(); Server.Misc.Cleanup.DoCleanup( (Item)state, item ); }

public override void Deserialize( GenericReader reader )
		{
			base.Deserialize( reader ); Timer.DelayCall( TimeSpan.FromSeconds( 1.0 ), new TimerStateCallback( Cleanup ), this );

			int version = reader.ReadInt();
		}
	}
}