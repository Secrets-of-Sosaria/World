using System;
using Server;

namespace Server.Items
{
	public class SamaritanRobe : MagicRobe
	{
		[Constructable]
		public SamaritanRobe()
		{
			Name = "Good Samaritan Robe";
			Hue = 0x2a3;
			Attributes.Luck = 400;
			Resistances.Physical = 10;
			SkillBonuses.SetValues(0, SkillName.Knightship, 20);
			Attributes.ReflectPhysical = 10;
		}

        public override void AddNameProperties(ObjectPropertyList list)
		{
            base.AddNameProperties(list);
			list.Add( 1070722, "Artefact");
        }

		public SamaritanRobe( Serial serial ) : base( serial )
		{
		}
		
		public override void Serialize( GenericWriter writer )
		{
			base.Serialize( writer );

			writer.Write( (int) 0 );
		}
		
		private void Cleanup( object state ){ Item item = new Artifact_SamaritanRobe(); Server.Misc.Cleanup.DoCleanup( (Item)state, item ); }

public override void Deserialize(GenericReader reader)
		{
			base.Deserialize( reader ); Timer.DelayCall( TimeSpan.FromSeconds( 1.0 ), new TimerStateCallback( Cleanup ), this );

			int version = reader.ReadInt();
		}
	}
}
