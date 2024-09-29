using System;
using Server.Network;
using Server;

namespace Server.Items
{
	public class SuperPotion : BasePotion
	{
		public override string DefaultDescription{ get{ return "Drinking this potion will increase your strength, intelligence, and dexterity by 10 points. The effects last for about 5 minutes."; } }

		[Constructable]
		public SuperPotion() : base( 0x180F, PotionEffect.SuperPotion )
		{
			Hue = 0xBA4;
			Name = "superior potion";
		}

		public SuperPotion( Serial serial ) : base( serial )
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
	  
		public override void Drink( Mobile m )
		{
			if ( m.InRange( this.GetWorldLocation(), 1 ) ) 
			{
				string modName = m.Serial.ToString();
				StatMod smod = m.GetStatMod( "Str" );
				StatMod dmod = m.GetStatMod( "Dex" );
				StatMod imod = m.GetStatMod( "Int" );
				if ( smod != null && imod != null && dmod != null)
				{
					m.SendMessage( "You appear to be under a similar effect!" );
				}
				else if (smod == null && imod == null && dmod == null)
				{
					m.AddStatMod( new StatMod( StatType.Int, modName + "Int", 10, TimeSpan.FromMinutes( 5 ) ) );
					m.AddStatMod( new StatMod( StatType.Dex, modName + "Dex", 10, TimeSpan.FromMinutes( 5 ) ) );
					m.AddStatMod( new StatMod( StatType.Str, modName + "Str", 10, TimeSpan.FromMinutes( 5 ) ) );
					m.Hits = m.HitsMax ;
					m.Mana = m.ManaMax ;
					m.Stam = m.StamMax ;
					BasePotion.PlayDrinkEffect( m );
					this.Consume();
					m.SendMessage( "You feel much more superior!" );

					string args = String.Format("{0}\t{1}\t{2}", 10, 10, 10);

					BuffInfo.RemoveBuff( m, BuffIcon.PotionSuperior );
					BuffInfo.AddBuff( m, new BuffInfo( BuffIcon.PotionSuperior, 1063597, 1063601, TimeSpan.FromMinutes( 5 ), m, args.ToString(), true));
				}
			} 
			else 
			{ 
				m.LocalOverheadMessage( MessageType.Regular, 906, 1019045 ); // I can't reach that. 
			} 
		}
	}
}
