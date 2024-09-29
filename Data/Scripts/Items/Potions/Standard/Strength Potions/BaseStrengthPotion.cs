using System;
using Server;

namespace Server.Items
{
	public abstract class BaseStrengthPotion : BasePotion
	{
		public override string DefaultDescription{ get{ return "This potion will give one an extra " + StrOffset.ToString() + " strength for a duration of...<BR><BR>" + Duration.ToString() + " (HH:MM:SS)"; } }

		public abstract int StrOffset{ get; }
		public abstract TimeSpan Duration{ get; }

		//public override int Hue{ get { return 0; } }

		public BaseStrengthPotion( PotionEffect effect ) : base( 0xF09, effect )
		{
		}

		public BaseStrengthPotion( Serial serial ) : base( serial )
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

		public bool DoStrength( Mobile from )
		{
			// TODO: Verify scaled; is it offset, duration, or both?
			if ( Spells.SpellHelper.AddStatOffset( from, StatType.Str, Scale( from, MyServerSettings.PlayerLevelMod( StrOffset, from ) ), Duration ) )
			{
				from.FixedEffect( 0x375A, 10, 15 );
				from.PlaySound( 0x1E7 );

				string args = String.Format("{0}", Scale( from, MyServerSettings.PlayerLevelMod( StrOffset, from ) ));

				BuffInfo.RemoveBuff( from, BuffIcon.PotionStrength );

				if ( ItemID == 0x25F7 )
					BuffInfo.AddBuff( from, new BuffInfo( BuffIcon.PotionStrength, 1063592, 1063604, Duration, from, args.ToString(), true));
				else					
					BuffInfo.AddBuff( from, new BuffInfo( BuffIcon.PotionStrength, 1063591, 1063604, Duration, from, args.ToString(), true));

				return true;
			}

			from.SendLocalizedMessage( 502173 ); // You are already under a similar effect.
			return false;
		}

		public override void Drink( Mobile from )
		{
			if ( DoStrength( from ) )
			{
				BasePotion.PlayDrinkEffect( from );

				this.Consume();
			}
		}
	}
}