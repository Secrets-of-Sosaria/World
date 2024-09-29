using System;
using Server;

namespace Server.Items
{
	public class NightSightPotion : BasePotion
	{
		public override string DefaultDescription{ get{ return "These potions allow you to see better in darkness. The effect last between 15 and 25 minutes."; } }

		[Constructable]
		public NightSightPotion() : base( 0xF06, PotionEffect.Nightsight )
		{
			Name = "nightsight potion";
		}

		public NightSightPotion( Serial serial ) : base( serial )
		{
		}

		public override void Serialize( GenericWriter writer )
		{
			base.Serialize( writer );
			writer.Write( (int) 0 ); // version
		}

		public override void Deserialize( GenericReader reader )
		{
			base.Deserialize( reader );
			int version = reader.ReadInt();
			Name = "nightsight potion";
		}

		public override void Drink( Mobile from )
		{
			if ( from.BeginAction( typeof( LightCycle ) ) )
			{
				new LightCycle.NightSightTimer( from ).Start();
				from.LightLevel = LightCycle.DungeonLevel / 2;

				from.FixedParticles( 0x376A, 9, 32, 5007, EffectLayer.Waist );
				from.PlaySound( 0x1E3 );

				BasePotion.PlayDrinkEffect( from );

				BuffInfo.AddBuff( from, new BuffInfo( BuffIcon.PotionNightSight, 1063593, 1063598 ) );

				this.Consume();
			}
			else
			{
				from.SendMessage( "You already have nightsight." );
			}
		}
	}
}
