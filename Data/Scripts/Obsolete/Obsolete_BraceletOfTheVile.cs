using System;
using Server;

namespace Server.Items
{
	public class BraceletOfTheVile : GoldBracelet
	{
		public override int LabelNumber{ get{ return 1061102; } } // Bracelet of the Vile

		[Constructable]
		public BraceletOfTheVile()
		{
			Name = "Bracelet of the Vile";
			Hue = 0x4F7;
			Attributes.BonusDex = 10;
			Attributes.RegenStam = 8;
			Attributes.AttackChance = 18;
			Resistances.Poison = 20;
		}

        public override void AddNameProperties(ObjectPropertyList list)
		{
            base.AddNameProperties(list);
			list.Add( 1070722, "Artefact");
        }

		public BraceletOfTheVile( Serial serial ) : base( serial )
		{
		}

		public override void Serialize( GenericWriter writer )
		{
			base.Serialize( writer );

			writer.Write( (int) 0 );
		}
		
		private void Cleanup( object state ){ Item item = new Artifact_BraceletOfTheVile(); Server.Misc.Cleanup.DoCleanup( (Item)state, item ); }

public override void Deserialize(GenericReader reader)
		{
			base.Deserialize( reader ); Timer.DelayCall( TimeSpan.FromSeconds( 1.0 ), new TimerStateCallback( Cleanup ), this );

			int version = reader.ReadInt();

			if ( Hue == 0x4F4 )
				Hue = 0x4F7;
		}
	}
}