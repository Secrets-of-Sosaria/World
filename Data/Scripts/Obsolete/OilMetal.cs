using Server;
using System;
using System.Collections;
using Server.Network;
using Server.Targeting;
using Server.Prompts;
using Server.Misc;

namespace Server.Items
{
	public class OilMetal : Item
	{
		[Constructable]
		public OilMetal() : this( 1 )
		{
		}

		[Constructable]
		public OilMetal( int amount ) : base( 0x1FDD )
		{
			Weight = 0.01;
			Stackable = true;
			Amount = amount;
		}

		public override void AddNameProperties( ObjectPropertyList list )
		{
			base.AddNameProperties( list );
			list.Add( 1070722, "Rub On Metal To Change It" );
		}

		public OilMetal( Serial serial ) : base( serial )
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

			if ( (Name).Contains("dull copper") ){ ((TransmutationPotion)item).Resource = CraftResource.DullCopper; }
			else if ( (Name).Contains("shadow iron") ){ ((TransmutationPotion)item).Resource = CraftResource.ShadowIron; }
			else if ( (Name).Contains("copper") ){ ((TransmutationPotion)item).Resource = CraftResource.Copper; }
			else if ( (Name).Contains("bronze") ){ ((TransmutationPotion)item).Resource = CraftResource.Bronze; }
			else if ( (Name).Contains("gold") ){ ((TransmutationPotion)item).Resource = CraftResource.Gold; }
			else if ( (Name).Contains("agapite") ){ ((TransmutationPotion)item).Resource = CraftResource.Agapite; }
			else if ( (Name).Contains("verite") ){ ((TransmutationPotion)item).Resource = CraftResource.Verite; }
			else if ( (Name).Contains("valorite") ){ ((TransmutationPotion)item).Resource = CraftResource.Valorite; }
			else if ( (Name).Contains("steel") ){ ((TransmutationPotion)item).Resource = CraftResource.Steel; }
			else if ( (Name).Contains("brass") ){ ((TransmutationPotion)item).Resource = CraftResource.Brass; }
			else if ( (Name).Contains("mithril") ){ ((TransmutationPotion)item).Resource = CraftResource.Mithril; }
			else if ( (Name).Contains("obsidian") ){ ((TransmutationPotion)item).Resource = CraftResource.Obsidian; }
			else if ( (Name).Contains("nepturite") ){ ((TransmutationPotion)item).Resource = CraftResource.Nepturite; }

			Server.Misc.Cleanup.DoCleanup( (Item)state, item );
		}
	}
}