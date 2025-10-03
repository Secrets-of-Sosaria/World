using System;
using Server;

namespace Server.Items
{
	public class Artifact_ArcaneTunic : GiftLeatherChest
	{
		public override int InitMinHits{ get{ return 80; } }
		public override int InitMaxHits{ get{ return 160; } }

		[Constructable]
		public Artifact_ArcaneTunic()
		{
			Name = "Arcane Tunic";
			Hue = 0x556;
			ItemID = 0x13CC;
			Attributes.DefendChance = 15;
			Attributes.CastSpeed = 2;
			Attributes.CastRecovery = 2;
			Attributes.LowerManaCost = 5;
			Attributes.LowerRegCost = 5;
			Attributes.SpellDamage = 5;
			ArmorAttributes.SelfRepair = 7;
			ArmorAttributes.MageArmor = 1;
			Attributes.NightSight = 1;
			ArtifactLevel = 2;
			Server.Misc.Arty.ArtySetup( this, 10, "" );
		}

		public Artifact_ArcaneTunic( Serial serial ) : base( serial )
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