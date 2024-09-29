using System;
using Server.Network;
using Server.Items;
using Server.Targeting;

namespace Server.Items
{
	public class JadeScimitar : RadiantScimitar
	{
		public override int InitMinHits{ get{ return 80; } }
		public override int InitMaxHits{ get{ return 160; } }

		[Constructable]
		public JadeScimitar()
		{
          Name = "Jade Scimitar";
          Hue = 2964;
		  WeaponAttributes.HitColdArea = 30;
		  WeaponAttributes.HitEnergyArea = 25;
		  WeaponAttributes.HitFireArea = 30;
		  WeaponAttributes.HitPhysicalArea = 50;
		  WeaponAttributes.HitPoisonArea = 20;
		  WeaponAttributes.UseBestSkill = 1;
		  Attributes.AttackChance = 15;
		  Attributes.WeaponDamage = 50;
		  Attributes.WeaponSpeed = 30;
		}

        public override void AddNameProperties(ObjectPropertyList list)
		{
            base.AddNameProperties(list);
			list.Add( 1070722, "Artefact");
        }

		public JadeScimitar( Serial serial ) : base( serial )
		{
		}

		public override void Serialize( GenericWriter writer )
		{
			base.Serialize( writer );
			writer.Write( (int) 0 ); // version
		}

		private void Cleanup( object state ){ Item item = new Artifact_JadeScimitar(); Server.Misc.Cleanup.DoCleanup( (Item)state, item ); }

public override void Deserialize( GenericReader reader )
		{
			base.Deserialize( reader ); Timer.DelayCall( TimeSpan.FromSeconds( 1.0 ), new TimerStateCallback( Cleanup ), this );

			int version = reader.ReadInt();
		}
	}
}
