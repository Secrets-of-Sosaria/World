using System;
using Server;

namespace Server.Items
{
	public class Artifact_ArcaneLeggings : GiftLeatherLegs
	{
		public override int InitMinHits{ get{ return 80; } }
		public override int InitMaxHits{ get{ return 160; } }

		[Constructable]
		public Artifact_ArcaneLeggings()
		{
			Name = "Arcane Leggings";
			Hue = 0x556;
			ItemID = 0x13cb;
			Attributes.DefendChance = 14;
			Attributes.CastSpeed = 1;
			Attributes.LowerManaCost = 5;
			Attributes.LowerRegCost = 6;
			Attributes.SpellDamage = 5;
			Attributes.BonusMana = 5;
			Attributes.Luck = 31;
			ArmorAttributes.SelfRepair = 2;
			Attributes.NightSight = 1;
			ArtifactLevel = 2;
			Server.Misc.Arty.ArtySetup( this, 10, "" );
		}

		public Artifact_ArcaneLeggings( Serial serial ) : base( serial )
		{
		}

		public override void Serialize( GenericWriter writer )
		{
			base.Serialize( writer );
			writer.Write( (int) 0 );
		}
		
		public override void Deserialize(GenericReader reader)
		{
			base.Deserialize( reader );
			ArtifactLevel = 2;
			int version = reader.ReadInt();
		}
	}
}