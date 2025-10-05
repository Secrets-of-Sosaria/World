using System;
using Server;

namespace Server.Items
{
	public class Artifact_InquisitorsLeggings : GiftPlateLegs
	{
		public override int InitMinHits{ get{ return 80; } }
		public override int InitMaxHits{ get{ return 160; } }

		public override int BaseColdResistance{ get{ return 24; } }
		public override int BaseEnergyResistance{ get{ return 19; } }

		[Constructable]
		public Artifact_InquisitorsLeggings()
		{
			Name = "Inquisitor's Leggings";
			Hue = 0x4F2;
			ItemID = 0x46AA;
			SkillBonuses.SetValues( 0, SkillName.MagicResist, 10 );
			Attributes.CastRecovery = 1;
			Attributes.LowerManaCost = 10;
			Attributes.LowerRegCost = 10;
			Attributes.Luck = 40;
			ArmorAttributes.MageArmor = 1;
			ArtifactLevel = 2;
			Server.Misc.Arty.ArtySetup( this, 10, "" );
		}

		public Artifact_InquisitorsLeggings( Serial serial ) : base( serial )
		{
		}

		public override void Serialize( GenericWriter writer )
		{
			base.Serialize( writer );
			writer.Write( (int) 1 );
		}
		
		public override void Deserialize(GenericReader reader)
		{
			base.Deserialize( reader );
			ArtifactLevel = 2;
			int version = reader.ReadInt();
		}
	}
}