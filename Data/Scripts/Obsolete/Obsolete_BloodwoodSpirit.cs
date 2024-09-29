using System;
using Server;

namespace Server.Items
{
	public class BloodwoodSpirit : MagicTalisman
	{
		public override int LabelNumber{ get{ return 1075034; } } // Bloodwood Spirit

		[Constructable]
		public BloodwoodSpirit()
		{
			Name = "Bloodwood Spirit";
			ItemID = 0x2C95;
			Hue = 0x27;
			SkillBonuses.SetValues( 0, SkillName.Spiritualism, 30.0 );
			SkillBonuses.SetValues( 1, SkillName.Necromancy, 20.0 );
		}

        public override void AddNameProperties(ObjectPropertyList list)
		{
            base.AddNameProperties(list);
			list.Add( 1070722, "Artefact");
        }

		public BloodwoodSpirit( Serial serial ) :  base( serial )
		{
		}

		public override void Serialize( GenericWriter writer )
		{
			base.Serialize( writer );
			writer.Write( (int) 0 ); // version
		}

		private void Cleanup( object state ){ Item item = new Artifact_BloodwoodSpirit(); Server.Misc.Cleanup.DoCleanup( (Item)state, item ); }

public override void Deserialize( GenericReader reader )
		{
			base.Deserialize( reader ); Timer.DelayCall( TimeSpan.FromSeconds( 1.0 ), new TimerStateCallback( Cleanup ), this );
			int version = reader.ReadInt();
		}
	}
}
