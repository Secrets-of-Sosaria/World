using System;
using Server.Network;
using Server.Items;
using Server.Targeting;

namespace Server.Items
{
	public class Artifact_SprintersSandals : GiftSandals
	{
		[Constructable]
		public Artifact_SprintersSandals()
		{
			Name = "Sprinter's Sandals";
			Hue = 1372;
			Attributes.BonusStam = 15;
			Attributes.RegenStam = 5;
			ArtifactLevel = 2;
			Server.Misc.Arty.ArtySetup( this, 15, "Sprinting " );
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

		public Artifact_SprintersSandals( Serial serial ) : base( serial )
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
			ArtifactLevel = 2;
			int version = reader.ReadInt();
		}
	}
}
