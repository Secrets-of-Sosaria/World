using System;
using Server;

namespace Server.Items
{
	public class AchillesShield : BronzeShield
	{
		public override int InitMinHits{ get{ return 80; } }
		public override int InitMaxHits{ get{ return 160; } }

		[Constructable]
		public AchillesShield()
		{
			Hue = 0x491;
			Name = "Achille's Shield";
			SkillBonuses.SetValues( 0, SkillName.Parry, 25 );
			ArmorAttributes.DurabilityBonus = 30;
			ArmorAttributes.LowerStatReq = 10;
			Attributes.DefendChance = 10;
			Attributes.ReflectPhysical = 5;
			PhysicalBonus = 25;
			Attributes.NightSight = 1;
		}

        public override void AddNameProperties(ObjectPropertyList list)
		{
            base.AddNameProperties(list);
			list.Add( 1070722, "Artefact");
        }

		public AchillesShield( Serial serial ) : base( serial )
		{
		}

		public override void Serialize( GenericWriter writer )
		{
			base.Serialize( writer );
			writer.Write( (int) 0 ); // version
		}

		private void Cleanup( object state ){ Item item = new Artifact_AchillesShield(); Server.Misc.Cleanup.DoCleanup( (Item)state, item ); }

public override void Deserialize( GenericReader reader )
		{
			base.Deserialize( reader ); Timer.DelayCall( TimeSpan.FromSeconds( 1.0 ), new TimerStateCallback( Cleanup ), this );
			int version = reader.ReadInt();
		}
	}
}