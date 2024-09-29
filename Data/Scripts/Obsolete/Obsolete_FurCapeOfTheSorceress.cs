using System;
using Server.Network;
using Server.Items;
using Server.Targeting;

namespace Server.Items
{
	public class FurCapeOfTheSorceress : FurCape
	{
		[Constructable]
		public FurCapeOfTheSorceress()
		{
          Name = "Fur Cape Of The Sorceress";
          Hue = 1266;
		  Attributes.BonusInt = 5;
		  Attributes.BonusMana = 10;
		  Attributes.LowerManaCost = 5;
		  Attributes.LowerRegCost = 10;
		  Attributes.SpellDamage = 15;
		  Attributes.BonusMana = 10;
		}

        public override void AddNameProperties(ObjectPropertyList list)
		{
            base.AddNameProperties(list);
			list.Add( 1070722, "Artefact");
        }

		public FurCapeOfTheSorceress( Serial serial ) : base( serial )
		{
		}

		public override void Serialize( GenericWriter writer )
		{
			base.Serialize( writer );
			writer.Write( (int) 0 ); // version
		}

		private void Cleanup( object state ){ Item item = new Artifact_FurCapeOfTheSorceress(); Server.Misc.Cleanup.DoCleanup( (Item)state, item ); }

public override void Deserialize( GenericReader reader )
		{
			base.Deserialize( reader ); Timer.DelayCall( TimeSpan.FromSeconds( 1.0 ), new TimerStateCallback( Cleanup ), this );

			int version = reader.ReadInt();
		}
	}
}
