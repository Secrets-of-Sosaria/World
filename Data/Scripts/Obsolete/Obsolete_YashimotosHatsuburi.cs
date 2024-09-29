using System;
using Server.Network;
using Server.Items;
using Server.Targeting;

namespace Server.Items
{
	public class YashimotosHatsuburi : ChainHatsuburi
	{
		public override int InitMinHits{ get{ return 80; } }
		public override int InitMaxHits{ get{ return 160; } }

		public override int BaseColdResistance{ get{ return 5; } } 
		public override int BaseEnergyResistance{ get{ return 2; } } 
		public override int BasePhysicalResistance{ get{ return 7; } } 
		public override int BasePoisonResistance{ get{ return 3; } } 
		public override int BaseFireResistance{ get{ return 7; } } 
      
		[Constructable]
		public YashimotosHatsuburi()
		{
          Name = "Yashimoto's Hatsuburi";
          Hue = 1157;
		  ArmorAttributes.LowerStatReq = 50;
		  ArmorAttributes.SelfRepair = 5;
		  Attributes.AttackChance = 15;
		  Attributes.DefendChance = 15;
		  Attributes.RegenHits = 10;
		  Attributes.WeaponDamage = 15;
		}

        public override void AddNameProperties(ObjectPropertyList list)
		{
            base.AddNameProperties(list);
			list.Add( 1070722, "Artefact");
        }

		public YashimotosHatsuburi( Serial serial ) : base( serial )
		{
		}

		public override void Serialize( GenericWriter writer )
		{
			base.Serialize( writer );
			writer.Write( (int) 0 ); // version
		}

		private void Cleanup( object state ){ Item item = new Artifact_YashimotosHatsuburi(); Server.Misc.Cleanup.DoCleanup( (Item)state, item ); }

public override void Deserialize( GenericReader reader )
		{
			base.Deserialize( reader ); Timer.DelayCall( TimeSpan.FromSeconds( 1.0 ), new TimerStateCallback( Cleanup ), this );

			int version = reader.ReadInt();
		}
	}
}
