using System;
using System.Collections;
using Server;
using Server.Network;

namespace Server.Items
{
	public class BootsofHermes : MagicBoots
	{
		[Constructable]
		public BootsofHermes()
		{
			Hue = 0xBAD;
			ItemID = 0x2FC4;
			Name = "Boots of Hermes";
			Attributes.BonusDex = 10;
		}

		public override void AddNameProperties( ObjectPropertyList list )
		{
			base.AddNameProperties( list );
			list.Add( 1070722, "Artefact" );
		}

		public override bool OnEquip( Mobile from )
		{
			if ( MySettings.S_NoMountsInCertainRegions && Server.Mobiles.AnimalTrainer.IsNoMountRegion( from, Region.Find( from.Location, from.Map ) ) )
			{
				from.Send(SpeedControl.Disable);
				Weight = 5.0;
				from.SendMessage( "These shoes seem to have their magic diminished here." );
			}
			else
			{
				Weight = 3.0;
				from.Send(SpeedControl.MountSpeed);
			}

			return base.OnEquip(from);
		}

		public override void OnRemoved( object parent )
		{
			if ( parent is Mobile )
			{
				Mobile from = (Mobile)parent;
				from.Send(SpeedControl.Disable);
			}
			base.OnRemoved(parent);
		}

		public BootsofHermes( Serial serial ) : base( serial )
		{
		}

		public override void Serialize( GenericWriter writer )
		{
			base.Serialize( writer );
			writer.Write( (int) 0 ); // version
		}

		private void Cleanup( object state ){ Item item = new Artifact_BootsofHermes(); Server.Misc.Cleanup.DoCleanup( (Item)state, item ); }

public override void Deserialize( GenericReader reader )
		{
			base.Deserialize( reader ); Timer.DelayCall( TimeSpan.FromSeconds( 1.0 ), new TimerStateCallback( Cleanup ), this );
			int version = reader.ReadInt();
		}
	}
}