using System;
using Server;

namespace Server.Items
{
	public class LeggingsOfBane : ChainLegs
	{
		public override int LabelNumber{ get{ return 1061100; } } // Leggings of Bane

		public override int BasePoisonResistance{ get{ return 36; } }

		[Constructable]
		public LeggingsOfBane()
		{
			Hue = 0x4F5;
			ArmorAttributes.DurabilityBonus = 100;
			this.HitPoints = this.MaxHitPoints = 255;	//Cause the Durability bonus and such and the min/max hits as well as all other hits being whole #'s...
			Attributes.BonusStam = 8;
			Attributes.AttackChance = 20;
		}

        public override void AddNameProperties(ObjectPropertyList list)
		{
            base.AddNameProperties(list);
			list.Add( 1070722, "Artefact");
        }

		public LeggingsOfBane( Serial serial ) : base( serial )
		{
		}

		public override void Serialize( GenericWriter writer )
		{
			base.Serialize( writer );

			writer.Write( (int) 2 );
		}
		
		private void Cleanup( object state ){ Item item = new Artifact_LeggingsOfBane(); Server.Misc.Cleanup.DoCleanup( (Item)state, item ); }

public override void Deserialize(GenericReader reader)
		{
			base.Deserialize( reader ); Timer.DelayCall( TimeSpan.FromSeconds( 1.0 ), new TimerStateCallback( Cleanup ), this );

			int version = reader.ReadInt();

			if( version <= 1 )
			{
				if( this.HitPoints > 100 || this.MaxHitPoints > 100 )
					this.HitPoints = this.MaxHitPoints = 100;
			}

			if ( version < 1 )
			{
				if ( Hue == 0x559 )
					Hue = 0x4F5;

				if ( ArmorAttributes.DurabilityBonus == 0 )
					ArmorAttributes.DurabilityBonus = 100;

				PoisonBonus = 0;
			}
		}
	}
}