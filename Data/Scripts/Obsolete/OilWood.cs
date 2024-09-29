using Server;
using System;
using System.Collections;
using Server.Network;
using Server.Targeting;
using Server.Prompts;
using Server.Misc;

namespace Server.Items
{
	public class OilWood : Item
	{
		[Constructable]
		public OilWood() : this( 1 )
		{
		}

		[Constructable]
		public OilWood( int amount ) : base( 0x1FDD )
		{
			Weight = 0.01;
			Stackable = true;
			Amount = amount;
		}

		public override void AddNameProperties( ObjectPropertyList list )
		{
			base.AddNameProperties( list );
			list.Add( 1070722, "Rub On Wooden Weapons or Armor" );
		}

		public override void OnDoubleClick( Mobile from )
		{
			Target t;

			if ( !IsChildOf( from.Backpack ) )
			{
				from.SendLocalizedMessage( 1060640 ); // The item must be in your backpack to use it.
			}
			else if ( from.Skills[SkillName.Carpentry].Base >= 90 || from.Skills[SkillName.Bowcraft].Base >= 90 )
			{
				from.SendMessage( "What do you want to use the oil on?" );
				t = new OilTarget( this );
				from.Target = t;
			}
			else
			{
				from.SendMessage( "Only a master carpenter or bowcrafting can use this oil." );
			}
		}

		private class OilTarget : Target
		{
			private OilWood m_Oil;

			public OilTarget( OilWood tube ) : base( 1, false, TargetFlags.None )
			{
				m_Oil = tube;
			}

			protected override void OnTarget( Mobile from, object targeted )
			{
				if ( targeted is Item )
				{
					Item iOil = targeted as Item;
				}
			}
		}

		public OilWood( Serial serial ) : base( serial )
		{
		}

		public override void Serialize( GenericWriter writer )
		{
			base.Serialize( writer );
			writer.Write( ( int) 0 ); // version
		}

		public override void Deserialize( GenericReader reader )
		{
			base.Deserialize( reader );
			int version = reader.ReadInt();
			ItemID = 0x1FDD;

			if ( Name == "oil of wood polish ( oak )" ){ Name = "wood polish ( oak )"; }
			else if ( Name == "oil of wood polish ( ash )" ){ Name = "wood polish ( ash )"; }
			else if ( Name == "oil of wood polish ( cherry )" ){ Name = "wood polish ( cherry )"; }
			else if ( Name == "oil of wood polish ( walnut )" ){ Name = "wood polish ( walnut )"; }
			else if ( Name == "oil of wood polish ( golden oak )" ){ Name = "wood polish ( golden oak )"; }
			else if ( Name == "oil of wood polish ( ebony )" ){ Name = "wood polish ( ebony )"; }
			else if ( Name == "oil of wood polish ( hickory )" ){ Name = "wood polish ( hickory )"; }
			else if ( Name == "oil of wood polish ( pine )" ){ Name = "wood polish ( pine )"; }
			else if ( Name == "oil of wood polish ( rosewood )" ){ Name = "wood polish ( rosewood )"; }
			else if ( Name == "oil of wood polish ( mahogany )" ){ Name = "wood polish ( mahogany )"; }
			else if ( Name == "oil of wood polish ( driftwood )" ){ Name = "wood polish ( driftwood )"; }
			Timer.DelayCall( TimeSpan.FromSeconds( 1.0 ), new TimerStateCallback( Cleanup ), this );
		}

		private void Cleanup( object state )
		{
			Item item = new TransmutationPotion();

			if ( (Name).Contains("golden oak") ){ ((TransmutationPotion)item).Resource = CraftResource.GoldenOakTree; }
			else if ( (Name).Contains("oak") ){ ((TransmutationPotion)item).Resource = CraftResource.OakTree; }
			else if ( (Name).Contains("ash") ){ ((TransmutationPotion)item).Resource = CraftResource.AshTree; }
			else if ( (Name).Contains("cherry") ){ ((TransmutationPotion)item).Resource = CraftResource.CherryTree; }
			else if ( (Name).Contains("walnut") ){ ((TransmutationPotion)item).Resource = CraftResource.WalnutTree; }
			else if ( (Name).Contains("ebony") ){ ((TransmutationPotion)item).Resource = CraftResource.EbonyTree; }
			else if ( (Name).Contains("hickory") ){ ((TransmutationPotion)item).Resource = CraftResource.HickoryTree; }
			else if ( (Name).Contains("pine") ){ ((TransmutationPotion)item).Resource = CraftResource.PineTree; }
			else if ( (Name).Contains("rosewood") ){ ((TransmutationPotion)item).Resource = CraftResource.RosewoodTree; }
			else if ( (Name).Contains("mahogany") ){ ((TransmutationPotion)item).Resource = CraftResource.MahoganyTree; }
			else if ( (Name).Contains("driftwood") ){ ((TransmutationPotion)item).Resource = CraftResource.DriftwoodTree; }

			Server.Misc.Cleanup.DoCleanup( (Item)state, item );
		}
	}
}