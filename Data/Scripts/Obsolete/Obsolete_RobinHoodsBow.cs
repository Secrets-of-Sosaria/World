using System;
using Server;

namespace Server.Items
{
	public class RobinHoodsBow : CompositeBow
	{
		public override int InitMinHits{ get{ return 80; } }
		public override int InitMaxHits{ get{ return 160; } }

		[Constructable]
		public RobinHoodsBow()
		{
			Hue = 0x483;
			Name = "Robin Hood's Bow";
			SkillBonuses.SetValues( 0, SkillName.Marksmanship, 20 );
			AccuracyLevel = WeaponAccuracyLevel.Supremely;
			Attributes.AttackChance = 5;
			Attributes.Luck = 20;
			ItemID = 0x13B2;
		}

        public override void AddNameProperties(ObjectPropertyList list)
		{
            base.AddNameProperties(list);
			list.Add( 1070722, "Artefact");
        }

		public RobinHoodsBow( Serial serial ) : base( serial )
		{
		}

		public override void Serialize( GenericWriter writer )
		{
			base.Serialize( writer );
			writer.Write( (int) 0 ); // version
		}

		private void Cleanup( object state ){ Item item = new Artifact_RobinHoodsBow(); Server.Misc.Cleanup.DoCleanup( (Item)state, item ); }

public override void Deserialize( GenericReader reader )
		{
			base.Deserialize( reader ); Timer.DelayCall( TimeSpan.FromSeconds( 1.0 ), new TimerStateCallback( Cleanup ), this );
			int version = reader.ReadInt();
		}
	}
}