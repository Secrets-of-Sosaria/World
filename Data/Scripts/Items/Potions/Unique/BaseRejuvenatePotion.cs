using System;
using Server;
using Server.Network;

namespace Server.Items
{
	public abstract class BaseRejuvenatePotion : BasePotion
	{
		public override string DefaultDescription{ get{ return "These potions will recover around " + (int)(MinRejuv * MySettings.S_PlayerLevelMod) + " and " + (int)(MaxRejuv * MySettings.S_PlayerLevelMod) + " of your mana, stamina, and health. You must wait 10 seconds before drinking another."; } }

		public abstract int MinRejuv { get; }
		public abstract int MaxRejuv { get; }
		public abstract double Delay { get; }

		public BaseRejuvenatePotion( PotionEffect effect ) : base( 0x180F, effect )
		{
		}

		public BaseRejuvenatePotion( Serial serial ) : base( serial )
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
		}

		public void DoRejuv( Mobile from )
		{
			int min = Scale( from, MyServerSettings.PlayerLevelMod( MinRejuv, from ) );
			int max = Scale( from, MyServerSettings.PlayerLevelMod( MaxRejuv, from ) );

			from.Mana = from.Mana + ( Utility.RandomMinMax( min, max ) );
			from.Hits = from.Hits + ( Utility.RandomMinMax( min, max ) );
			from.Stam = from.Stam + ( Utility.RandomMinMax( min, max ) );
		}

		public override void Drink( Mobile from )
		{
			if ( from.BeginAction( typeof( BaseRejuvenatePotion ) ) )
			{
				DoRejuv( from );

				BasePotion.PlayDrinkEffect( from );

				this.Consume();

				Timer.DelayCall( TimeSpan.FromSeconds( Delay ), new TimerStateCallback( ReleaseRejuvenateLock ), from );
			}
			else
				from.LocalOverheadMessage( MessageType.Regular, 0x22, true, "You must wait 10 seconds before using another rejuvenation potion." );
		}

		private static void ReleaseRejuvenateLock( object state )
		{
			((Mobile)state).EndAction( typeof( BaseRejuvenatePotion ) );
		}
	}
}
