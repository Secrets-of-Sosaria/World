using System;
using Server;

namespace Server.Items
{
	public class BraceletOfTheElements : GoldBracelet
	{
		public override int LabelNumber{ get{ return 1061104; } } // Bracelet of the Elements

		[Constructable]
		public BraceletOfTheElements()
		{
			Name = "Bracelet of the Elements";
			Hue = 0x4E9;
			Attributes.Luck = 125;
			Resistances.Fire = 18;
			Resistances.Cold = 18;
			Resistances.Poison = 18;
			Resistances.Energy = 18;
		}

        public override void AddNameProperties(ObjectPropertyList list)
		{
            base.AddNameProperties(list);
			list.Add( 1070722, "Artefact");
        }

		public BraceletOfTheElements( Serial serial ) : base( serial )
		{
		}

		public override void Serialize( GenericWriter writer )
		{
			base.Serialize( writer );

			writer.Write( (int) 0 );
		}
		
		private void Cleanup( object state ){ Item item = new Artifact_BraceletOfTheElements(); Server.Misc.Cleanup.DoCleanup( (Item)state, item ); }

public override void Deserialize(GenericReader reader)
		{
			base.Deserialize( reader ); Timer.DelayCall( TimeSpan.FromSeconds( 1.0 ), new TimerStateCallback( Cleanup ), this );

			int version = reader.ReadInt();
		}
	}
}