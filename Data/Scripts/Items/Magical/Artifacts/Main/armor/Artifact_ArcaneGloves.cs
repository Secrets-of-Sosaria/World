using System;
using Server;

namespace Server.Items
{
	public class Artifact_ArcaneGloves : GiftLeatherGloves
	{
		public override int InitMinHits{ get{ return 80; } }
		public override int InitMaxHits{ get{ return 160; } }

		[Constructable]
		public Artifact_ArcaneGloves()
		{
			Name = "Arcane Gloves";
			Hue = 0x556;
			ItemID = 0x13C6;
			Attributes.DefendChance = 10;
			Attributes.CastSpeed = 1;
			Attributes.LowerManaCost = 3;
			Attributes.LowerRegCost = 3;
			Attributes.SpellDamage = 5;
			Attributes.BonusMana = 8;
			Attributes.Luck = 50;
			ArmorAttributes.SelfRepair = 2;
			Attributes.NightSight = 1;
			ArmorAttributes.MageArmor = 1;
			ArtifactLevel = 2;
			Server.Misc.Arty.ArtySetup( this, 10, "" );
		}

		public Artifact_ArcaneGloves( Serial serial ) : base( serial )
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