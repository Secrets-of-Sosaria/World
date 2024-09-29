using System;
using Server;

namespace Server.Items
{
	public class BeggarsRobe : Robe
	{
      [Constructable]
		public BeggarsRobe()
		{
			Name = "Beggar's Robe";
			Hue = 0x978;
			ItemID = 0x2687;
			Attributes.Luck = 100;
			SkillBonuses.SetValues( 0, SkillName.Begging, 30 );
		}

        public override void AddNameProperties(ObjectPropertyList list)
		{
            base.AddNameProperties(list);
			list.Add( 1070722, "Artefact");
        }

		public BeggarsRobe( Serial serial ) : base( serial )
		{
		}

		public override void Serialize( GenericWriter writer )
		{
			base.Serialize( writer );
			writer.Write( (int) 0 ); // version
		}

		private void Cleanup( object state ){ Item item = new Artifact_BeggarsRobe(); Server.Misc.Cleanup.DoCleanup( (Item)state, item ); }

public override void Deserialize( GenericReader reader )
		{
			base.Deserialize( reader ); Timer.DelayCall( TimeSpan.FromSeconds( 1.0 ), new TimerStateCallback( Cleanup ), this );
			int version = reader.ReadInt();
		}
	}
}