using System;

namespace Server.Items
{
	public class OssianGrimoire : NecromancerSpellbook
	{
		[Constructable]
		public OssianGrimoire() : base()
		{
			Name = "Ossian Grimoire";
			SkillBonuses.SetValues( 0, SkillName.Necromancy, 10.0 );
			Attributes.RegenMana = 1;
			Attributes.CastSpeed = 1;
		}

		public OssianGrimoire( Serial serial ) : base( serial )
		{
		}

		public override void Serialize( GenericWriter writer )
		{
			base.Serialize( writer );

			writer.WriteEncodedInt( 0 ); //version
		}

		private void Cleanup( object state ){ Item item = new Arty_OssianGrimoire(); Server.Misc.Cleanup.DoCleanup( (Item)state, item ); }

public override void Deserialize( GenericReader reader )
		{
			base.Deserialize( reader ); Timer.DelayCall( TimeSpan.FromSeconds( 1.0 ), new TimerStateCallback( Cleanup ), this );

			int version = reader.ReadEncodedInt();
		}
	}
}