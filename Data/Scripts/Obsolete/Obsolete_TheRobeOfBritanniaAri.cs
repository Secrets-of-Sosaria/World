using System;
using Server;

namespace Server.Items
{
	public class TheRobeOfBritanniaAri : MagicRobe
	{
		[Constructable]
		public TheRobeOfBritanniaAri()
		{
			Name = "Robe of Sosaria";
			Hue = 0x48b;
			Resistances.Physical = 10;
			Resistances.Cold = 10;
			Resistances.Fire = 10;
			Resistances.Energy = 10;
			Resistances.Poison = 10;
		}

        public override void AddNameProperties(ObjectPropertyList list)
		{
            base.AddNameProperties(list);
			list.Add( 1070722, "Artefact");
        }

		public TheRobeOfBritanniaAri( Serial serial ) : base( serial )
		{
		}
		
		public override void Serialize( GenericWriter writer )
		{
			base.Serialize( writer );
			writer.Write( (int) 0 );
		}
		
		private void Cleanup( object state ){ Item item = new Artifact_TheRobeOfBritanniaAri(); Server.Misc.Cleanup.DoCleanup( (Item)state, item ); }

public override void Deserialize(GenericReader reader)
		{
			base.Deserialize( reader ); Timer.DelayCall( TimeSpan.FromSeconds( 1.0 ), new TimerStateCallback( Cleanup ), this );
			int version = reader.ReadInt();
		}
	}
}
