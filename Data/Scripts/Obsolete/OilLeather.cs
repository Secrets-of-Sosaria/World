using Server;
using System;
using System.Collections;
using Server.Network;
using Server.Targeting;
using Server.Prompts;
using Server.Misc;

namespace Server.Items
{
	public class OilLeather : Item
	{
		[Constructable]
		public OilLeather() : this( 1 )
		{
		}

		[Constructable]
		public OilLeather( int amount ) : base( 0x1FDD )
		{
			Weight = 0.01;
			Stackable = true;
			Amount = amount;
		}

		public override void AddNameProperties( ObjectPropertyList list )
		{
			base.AddNameProperties( list );
			list.Add( 1070722, "Rub On Leather To Change It" );
		}

		public override void OnDoubleClick( Mobile from )
		{
			Target t;

			if ( !IsChildOf( from.Backpack ) )
			{
				from.SendLocalizedMessage( 1060640 ); // The item must be in your backpack to use it.
			}
			else if ( from.Skills[SkillName.Tailoring].Base >= 90 )
			{
				from.SendMessage( "What do you want to use the oil on?" );
				t = new OilTarget( this );
				from.Target = t;
			}
			else
			{
				from.SendMessage( "Only a master tailor can use this oil." );
			}
		}

		private class OilTarget : Target
		{
			private OilLeather m_Oil;

			public OilTarget( OilLeather tube ) : base( 1, false, TargetFlags.None )
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

		public OilLeather( Serial serial ) : base( serial )
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
			Timer.DelayCall( TimeSpan.FromSeconds( 1.0 ), new TimerStateCallback( Cleanup ), this );
		}

		private void Cleanup( object state )
		{
			Item item = new TransmutationPotion();

			if ( (Name).Contains("deep sea") ){ ((TransmutationPotion)item).Resource = CraftResource.SpinedLeather; }
			else if ( (Name).Contains("lizard") ){ ((TransmutationPotion)item).Resource = CraftResource.HornedLeather; }
			else if ( (Name).Contains("serpent") ){ ((TransmutationPotion)item).Resource = CraftResource.BarbedLeather; }
			else if ( (Name).Contains("necrotic") ){ ((TransmutationPotion)item).Resource = CraftResource.NecroticLeather; }
			else if ( (Name).Contains("volcanic") ){ ((TransmutationPotion)item).Resource = CraftResource.VolcanicLeather; }
			else if ( (Name).Contains("frozen") ){ ((TransmutationPotion)item).Resource = CraftResource.FrozenLeather; }
			else if ( (Name).Contains("goliath") ){ ((TransmutationPotion)item).Resource = CraftResource.GoliathLeather; }
			else if ( (Name).Contains("draconic") ){ ((TransmutationPotion)item).Resource = CraftResource.DraconicLeather; }
			else if ( (Name).Contains("hellish") ){ ((TransmutationPotion)item).Resource = CraftResource.HellishLeather; }
			else if ( (Name).Contains("dinosaur") ){ ((TransmutationPotion)item).Resource = CraftResource.DinosaurLeather; }

			Server.Misc.Cleanup.DoCleanup( (Item)state, item );
		}
	}
}