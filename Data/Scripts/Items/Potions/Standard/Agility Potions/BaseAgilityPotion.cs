using System;
using Server;

namespace Server.Items
{
	public abstract class BaseAgilityPotion : BasePotion
	{
		public abstract int DexOffset{ get; }
		public abstract TimeSpan Duration{ get; }

		public override string DefaultDescription{ get{ return "This potion will give one an extra " + DexOffset.ToString() + " dexterity for a duration of...<BR><BR>" + Duration.ToString() + " (HH:MM:SS)"; } }

		public BaseAgilityPotion( PotionEffect effect ) : base( 0xF08, effect )
		{
		}

		public BaseAgilityPotion( Serial serial ) : base( serial )
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

		public bool DoAgility( Mobile from )
		{
			// TODO: Verify scaled; is it offset, duration, or both?
			if ( Spells.SpellHelper.AddStatOffset( from, StatType.Dex, Scale( from, MyServerSettings.PlayerLevelMod( DexOffset, from ) ), Duration ) )
			{
				from.FixedEffect( 0x375A, 10, 15 );
				from.PlaySound( 0x1E7 );

				string args = String.Format("{0}", Scale( from, MyServerSettings.PlayerLevelMod( DexOffset, from ) ));

				BuffInfo.RemoveBuff( from, BuffIcon.PotionAgility );

				if ( ItemID == 0x256A )
					BuffInfo.AddBuff( from, new BuffInfo( BuffIcon.PotionAgility, 1063590, 1063603, Duration, from, args.ToString(), true));
				else
					BuffInfo.AddBuff( from, new BuffInfo( BuffIcon.PotionAgility, 1063589, 1063603, Duration, from, args.ToString(), true));

				return true;
			}

			from.SendLocalizedMessage( 502173 ); // You are already under a similar effect.
			return false;
		}

		public override void Drink( Mobile from )
		{
			if ( DoAgility( from ) )
			{
				BasePotion.PlayDrinkEffect( from );

				this.Consume();
			}
		}
	}
}