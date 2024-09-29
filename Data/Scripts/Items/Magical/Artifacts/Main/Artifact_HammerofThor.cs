using System;
using Server.Network;
using Server.Items;
using Server.Targeting;
using Server.Spells.Fourth;
using Server.Spells;
using Server.Misc;

namespace Server.Items
{
	public class Artifact_HammerofThor : GiftWarHammer
	{
		public override int InitMinHits{ get{ return 80; } }
		public override int InitMaxHits{ get{ return 160; } }

		[Constructable]
		public Artifact_HammerofThor()
		{
			Hue = 0x430;
			Weight = 10.0;
			ItemID = 0x267E;			Name = "Hammer of Thor";
			AosElementDamages.Energy = 50;
			AosElementDamages.Physical = 50;
			WeaponAttributes.HitLightning = 50;
			DamageLevel = WeaponDamageLevel.Vanq;
			ArtifactLevel = 2;
			Server.Misc.Arty.ArtySetup( this, 8, "(Casts Lightning) " );
		}

		public override void OnDoubleClick( Mobile from )
		{
			if ( Parent != from )
			{
				from.SendMessage( "You must be holding the hammer to unleash a lightning bolt." );
			}
			else
			{
				new LightningSpell( from, this ).Cast();
			}
			return;
		}

		public Artifact_HammerofThor( Serial serial ) : base( serial )
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