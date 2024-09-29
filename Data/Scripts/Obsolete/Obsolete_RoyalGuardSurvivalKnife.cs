using System;
using Server;

namespace Server.Items
{
	public class RoyalGuardSurvivalKnife : SkinningKnife
	{
		public override int InitMinHits{ get{ return 150; } }
		public override int InitMaxHits{ get{ return 150; } }

		public override bool CanFortify{ get{ return false; } }

		[Constructable]
		public RoyalGuardSurvivalKnife()
		{
			Name = "Royal Guard Survival Knife";
			Attributes.SpellChanneling = 1;
			Attributes.Luck = 140;
			Attributes.EnhancePotions = 25;

			WeaponAttributes.UseBestSkill = 1;
			WeaponAttributes.LowerStatReq = 50;
		}

        public override void AddNameProperties(ObjectPropertyList list)
		{
            base.AddNameProperties(list);
			list.Add( 1070722, "Artefact");
        }

		public RoyalGuardSurvivalKnife( Serial serial ) : base( serial )
		{
		}

		public override void Serialize( GenericWriter writer )
		{
			base.Serialize( writer );

			writer.Write( (int) 0 );
		}
		
		private void Cleanup( object state ){ Item item = new Artifact_RoyalGuardSurvivalKnife(); Server.Misc.Cleanup.DoCleanup( (Item)state, item ); }

public override void Deserialize(GenericReader reader)
		{
			base.Deserialize( reader ); Timer.DelayCall( TimeSpan.FromSeconds( 1.0 ), new TimerStateCallback( Cleanup ), this );

			int version = reader.ReadInt();
		}
	}
}
