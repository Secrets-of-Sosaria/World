using System;
using Server.Network;
using Server.Items;
using Server.Targeting;

namespace Server.Items
{
	public class MaulOfTheTitans : Maul
	{
		public override int InitMinHits{ get{ return 80; } }
		public override int InitMaxHits{ get{ return 160; } }

      [Constructable]
		public MaulOfTheTitans()
		{
			Name = "Maul of the Titans";
			Hue = 0xB89;
			DamageLevel = WeaponDamageLevel.Vanq;
			AccuracyLevel = WeaponAccuracyLevel.Supremely;
			SkillBonuses.SetValues(1, SkillName.Bludgeoning, 20);
			MinDamage = MinDamage + 5;
			MaxDamage = MaxDamage + 10;
			Attributes.BonusStr = 10;
		}

        public override void AddNameProperties(ObjectPropertyList list)
		{
            base.AddNameProperties(list);
			list.Add( 1070722, "Artefact");
        }

		public MaulOfTheTitans( Serial serial ) : base( serial )
		{
		}

		public override void Serialize( GenericWriter writer )
		{
			base.Serialize( writer );
			writer.Write( (int) 0 ); // version
		}

		private void Cleanup( object state ){ Item item = new Artifact_MaulOfTheTitans(); Server.Misc.Cleanup.DoCleanup( (Item)state, item ); }

public override void Deserialize( GenericReader reader )
		{
			base.Deserialize( reader ); Timer.DelayCall( TimeSpan.FromSeconds( 1.0 ), new TimerStateCallback( Cleanup ), this );

			int version = reader.ReadInt();
		}
	}
}
