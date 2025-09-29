using System;
using Server;

namespace Server.Items
{
	public class Artifact_ArcaneGorget : GiftLeatherGorget
	{
		public override int InitMinHits{ get{ return 80; } }
		public override int InitMaxHits{ get{ return 160; } }

		[Constructable]
		public Artifact_ArcaneGorget()
		{
			Name = "Arcane Gorget";
			Hue = 0x556;
			ItemID = 0x13C7;
			Attributes.DefendChance = 8;
			Attributes.CastSpeed = 1;
			Attributes.LowerManaCost = 2;
			Attributes.LowerRegCost = 3;
			Attributes.SpellDamage = 5;
			Attributes.BonusInt = 5;
			Attributes.Luck = 45;
			ArmorAttributes.SelfRepair = 2;
			Attributes.NightSight = 1;
			ArtifactLevel = 2;
			Server.Misc.Arty.ArtySetup( this, 10, "" );
		}

		public Artifact_ArcaneGorget( Serial serial ) : base( serial )
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