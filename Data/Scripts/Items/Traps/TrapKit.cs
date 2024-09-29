using System;
using Server;
using Server.Items;
using System.Text;
using Server.Mobiles;
using Server.Gumps;
using System.IO;
using System.Collections;
using System.Collections.Generic;
using Server.Network;
using Server.Engines.Craft;

namespace Server.Items
{
	public class TrapKit : Item
	{
		public override void ResourceChanged( CraftResource resource )
		{
			if ( !ResourceCanChange() )
				return;

			m_Resource = resource;
			Hue = CraftResources.GetHue(m_Resource);
			Name = CraftResources.GetTradeItemFullName( this, m_Resource, false, false, "trapping tools" );

			if ( CraftResources.GetBonus( m_Resource ) > 0 )
				InfoText1 = "Trap Power +" + CraftResources.GetBonus( m_Resource );
			else
				InfoText1 = null;

			InvalidateProperties();
		}

		[Constructable]
		public TrapKit( ) : base( 0x1EBB )
		{
			Hue = 0;
			Resource = CraftResource.Iron;
			Limits = 25;
			LimitsMax = 25;
			LimitsName = "Uses";
			LimitsDelete = true;
			Weight = 5.0;
			Name = "trapping tools";
		}

		public override void OnDoubleClick( Mobile from )
		{
			if ( !IsChildOf( from.Backpack ) ) 
			{
				from.SendMessage( "These tools must be in your backpack to use." );
				return;
			}
			else if ( Limits > 0 )
			{
				int traps = 0;

				foreach ( Item m in from.GetItemsInRange( 10 ) )
				{
					if ( m is SetTrap )
						++traps;
				}

				if ( traps > 2 )
				{
					from.SendMessage( "There are too many traps in the area!" );
				}
				else if ( !from.Region.AllowHarmful( from, from ) )
				{
					from.SendMessage( "That doesn't feel like a good idea." ); 
					return;
				}
				else if ( from.Skills[SkillName.RemoveTrap].Value > 0 )
				{
					ConsumeLimits( 1 );

					int Power = (int)(from.Skills[SkillName.RemoveTrap].Value / 2) + 1;

					from.SendSound( 0x55 );

					Power = Power + CraftResources.GetBonus( Resource );

					SetTrap trap = new SetTrap( from, Power ); 
					trap.Map = from.Map; 
					trap.Hue = this.Hue;
					trap.Location = from.Location;
				}
				else
				{
					from.SendMessage( "You cannot figure out how these tools work!" );
					return;
				}
			}
		}

		public TrapKit( Serial serial ) : base( serial )
		{
		}

		public override void Serialize( GenericWriter writer )
		{
			base.Serialize( writer );
			writer.Write( (int) 1 );
		}

		public override void Deserialize( GenericReader reader )
		{
			base.Deserialize( reader );
			int version = reader.ReadInt();

			if ( version < 1 )
			{
				string trp = reader.ReadString();

				if ( trp == "Dull Copper" ){ Resource = CraftResource.DullCopper; }
				else if ( trp == "Shadow Iron" ){ Resource = CraftResource.ShadowIron; }
				else if ( trp == "Copper" ){ Resource = CraftResource.Copper; }
				else if ( trp == "Bronze" ){ Resource = CraftResource.Bronze; }
				else if ( trp == "Gold" ){ Resource = CraftResource.Gold; }
				else if ( trp == "Agapite" ){ Resource = CraftResource.Agapite; }
				else if ( trp == "Verite" ){ Resource = CraftResource.Verite; }
				else if ( trp == "Valorite" ){ Resource = CraftResource.Valorite; }
				else if ( trp == "Nepturite" ){ Resource = CraftResource.Nepturite; }
				else if ( trp == "Obsidian" ){ Resource = CraftResource.Obsidian; }
				else if ( trp == "Steel" ){ Resource = CraftResource.Steel; }
				else if ( trp == "Brass" ){ Resource = CraftResource.Brass; }
				else if ( trp == "Mithril" ){ Resource = CraftResource.Mithril; }
				else if ( trp == "Xormite" ){ Resource = CraftResource.Xormite; }
				else if ( trp == "Dwarven" ){ Resource = CraftResource.Dwarven; }

				LimitsMax = 25;
				Limits = (int)reader.ReadInt();
				LimitsName = "Uses";
				LimitsDelete = true;
			}
		}
	}
}