using System;
using Server.Network;
using Server.Items;
using Server.Targeting;

namespace Server.Items
{
	public class MagiciansMempo : PlateMempo
	{
		public override int InitMinHits{ get{ return 80; } }
		public override int InitMaxHits{ get{ return 160; } }

		public override int BaseColdResistance{ get{ return 8; } } 
		public override int BaseEnergyResistance{ get{ return 7; } } 
		public override int BasePhysicalResistance{ get{ return 5; } } 
		public override int BasePoisonResistance{ get{ return 6; } } 
		public override int BaseFireResistance{ get{ return 10; } } 
      
      [Constructable]
		public MagiciansMempo()
		{
          Name = "Magician's Mempo";
          Hue = 1151;
		  ArmorAttributes.MageArmor = 1;
		  Attributes.BonusInt = 3;
		  Attributes.BonusMana = 10;
		  Attributes.EnhancePotions = 25;
		  Attributes.LowerManaCost = 5;
		  Attributes.LowerRegCost = 15;
		  Attributes.RegenMana = 3;
		  Attributes.SpellDamage = 20;
		}

        public override void AddNameProperties(ObjectPropertyList list)
		{
            base.AddNameProperties(list);
			list.Add( 1070722, "Artefact");
        }

		public MagiciansMempo( Serial serial ) : base( serial )
		{
		}

		public override void Serialize( GenericWriter writer )
		{
			base.Serialize( writer );
			writer.Write( (int) 0 ); // version
		}

		private void Cleanup( object state ){ Item item = new Artifact_MagiciansMempo(); Server.Misc.Cleanup.DoCleanup( (Item)state, item ); }

public override void Deserialize( GenericReader reader )
		{
			base.Deserialize( reader ); Timer.DelayCall( TimeSpan.FromSeconds( 1.0 ), new TimerStateCallback( Cleanup ), this );

			int version = reader.ReadInt();
		}
	}
}
