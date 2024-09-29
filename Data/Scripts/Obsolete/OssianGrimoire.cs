using System;

namespace Server.Items
{
	public interface IIslesDreadDyable
	{
	}

	public class Artifact_OssianGrimoire : MyNecromancerSpellbook, IIslesDreadDyable
	{
		[Constructable]
		public Artifact_OssianGrimoire() : base()
		{
			Hue = 0xA99;
			Name = "Ossian Grimoire";
			Attributes.RegenMana = 1;
			Attributes.CastSpeed = 1;

			this.Content = (ulong)( (int)(ulong)0x1FFFF );

			SkillBonuses.SetValues( 0, SkillName.MagicResist, ( 10.0 + (Utility.RandomMinMax(0,2)*5) ) );
			SkillBonuses.SetValues( 1, SkillName.Spiritualism, ( 10.0 + (Utility.RandomMinMax(0,2)*5) ) );
			SkillBonuses.SetValues( 2, SkillName.Necromancy, ( 10.0 + (Utility.RandomMinMax(0,2)*5) ) );
			SkillBonuses.SetValues( 3, SkillName.Meditation, ( 10.0 + (Utility.RandomMinMax(0,2)*5) ) );
		}

        public override void AddNameProperties(ObjectPropertyList list)
		{
            base.AddNameProperties(list);
			list.Add( 1070722, "Artifact");
        }

		public Artifact_OssianGrimoire( Serial serial ) : base( serial )
		{
		}

		public override void Serialize( GenericWriter writer )
		{
			base.Serialize( writer );
			writer.WriteEncodedInt( 0 ); //version
		}

		public override void Deserialize( GenericReader reader )
		{
			base.Deserialize( reader );
			int version = reader.ReadEncodedInt();
			Timer.DelayCall( TimeSpan.FromSeconds( 30.0 ), new TimerStateCallback( Cleanup ), this );
		}

		private void Cleanup( object state )
		{
			Item item = new Arty_OssianGrimoire();
			Server.Misc.Cleanup.DoCleanup( (Item)state, item );
		}
	}
}
