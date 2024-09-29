using System;
using Server;
using Server.Misc;

namespace Server.Items
{
	public class GrimReapersRobe : MagicRobe
	{
		[Constructable]
		public GrimReapersRobe()
		{
			ItemID = 0x1F03;
			Name = "Grim Reaper's Robe";
			Hue = 1;
			Attributes.ReflectPhysical = 25;
			SkillBonuses.SetValues( 0, SkillName.Necromancy, 10 );
			SkillBonuses.SetValues( 1, SkillName.Spiritualism, 10 );
		}

        public override void AddNameProperties(ObjectPropertyList list)
		{
            base.AddNameProperties(list);
			list.Add( 1070722, "Artefact");
        }

		public GrimReapersRobe( Serial serial ) : base( serial )
		{
		}

		public override void Serialize( GenericWriter writer )
		{
			base.Serialize( writer );
			writer.Write( (int) 1 ); // version
		}

		private void Cleanup( object state ){ Item item = new Artifact_GrimReapersRobe(); Server.Misc.Cleanup.DoCleanup( (Item)state, item ); }

public override void Deserialize( GenericReader reader )
		{
			base.Deserialize( reader ); Timer.DelayCall( TimeSpan.FromSeconds( 1.0 ), new TimerStateCallback( Cleanup ), this );
			int version = reader.ReadInt();
		}
	}
}