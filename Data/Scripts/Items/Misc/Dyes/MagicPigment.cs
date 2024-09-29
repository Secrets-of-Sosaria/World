using Server;
using System;
using System.Collections;
using Server.Network;
using Server.Targeting;
using Server.Prompts;
using Server.Misc;

namespace Server.Items
{
	public class MagicPigment : Item
	{
		[Constructable]
		public MagicPigment() : base( 0x4C5A )
		{
			string OwnerName = RandomThings.GetRandomName();
			if ( OwnerName.EndsWith( "s" ) )
				OwnerName = OwnerName + "'";
			else
				OwnerName = OwnerName + "'s";

			Weight = 2.0;
			Name = "mystical paints";

			ColorText1 = OwnerName;
			ColorHue1 = "338fff";
			ColorText2 = RandomThings.MagicItemAdj( "start", false, false, ItemID ) + " paints";
			ColorHue2 = "f0f52c";
			ColorText3 = "Paint Almost Anything";
			ColorHue3 = "71e26c";
            ColorText4 = "Needs Color Added By Dyeing It";
			ColorHue4 = "e26c6c";
		}

		public override void OnDoubleClick( Mobile from )
		{
			Target t;

			if ( !IsChildOf( from.Backpack ) )
			{
				from.SendLocalizedMessage( 1060640 ); // The item must be in your backpack to use it.
			}
			else
			{
				from.SendMessage( "What do you want to paint?" );
				t = new DyeTarget( this );
				from.Target = t;
			}
		}

		private class DyeTarget : Target
		{
			private MagicPigment m_Dye;

			public DyeTarget( MagicPigment tube ) : base( 1, false, TargetFlags.None )
			{
				m_Dye = tube;
			}

			protected override void OnTarget( Mobile from, object targeted )
			{
				if ( targeted is Item )
				{
					Item iDye = targeted as Item;

					bool backpack = false;
					if ( iDye is Backpack && from.FindItemOnLayer( Layer.Backpack ) == iDye )
						backpack = true;

					if ( !iDye.IsChildOf( from.Backpack ) && !backpack )
					{
						from.SendMessage( "You can only paint things in your pack." );
					}
					else if ( ( iDye.Stackable == true ) || ( iDye.ItemID == 8702 ) || ( iDye.ItemID == 4011 ) )
					{
						from.SendMessage( "You cannot paint that." );
					}
					else if ( iDye.IsChildOf( from.Backpack ) || backpack )
					{
						iDye.Hue = m_Dye.Hue;
							if ( iDye.Hue == 0x2EF ){ iDye.Hue = 0; }
						from.RevealingAction();
						from.PlaySound( 0x23F );
					}
					else
					{
						from.SendMessage( "You cannot paint that with this." );
					}
				}
				else
				{
					from.SendMessage( "You cannot paint that with this." );
				}
			}
		}

		public MagicPigment( Serial serial ) : base( serial )
		{
		}

		public override void Serialize( GenericWriter writer )
		{
			base.Serialize( writer );
			writer.Write( ( int)1 ); // version
		}

		public override void Deserialize( GenericReader reader )
		{
			base.Deserialize( reader );
			int version = reader.ReadInt();

			if ( version < 1 )
			{
				ColorText3 = "Paint Almost Anything";
				ColorHue3 = "71e26c";
				ColorText4 = "Needs Color Added By Dyeing It";
				ColorHue4 = "e26c6c";
			}
		}
	}
}