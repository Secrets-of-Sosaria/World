using System;
using Server.Network;
using Server.Items;

namespace Server.Items
{
	public class Artifact_AegisOfGrace : GiftDragonHelm
	{
		public override int InitMinHits{ get{ return 80; } }
		public override int InitMaxHits{ get{ return 160; } }

		public override ArmorMaterialType MaterialType{ get{ return ArmorMaterialType.Scaled; } }
		public override CraftResource DefaultResource{ get{ return CraftResource.Iron; } }

		[Constructable]
		public Artifact_AegisOfGrace()
		{
			Name = "Aegis of Grace";
			SkillBonuses.SetValues( 0, SkillName.MagicResist, 15.0 );
			Attributes.DefendChance = 20;
			ArmorAttributes.SelfRepair = 10;
			Attributes.RegenStam = 5;
			Attributes.BonusStam = 4;
			PhysicalBonus = 8;
			FireBonus = 8;
			PoisonBonus = 8;
			ColdBonus = 8;
			EnergyBonus = 8;
			ArtifactLevel = 2;
			Server.Misc.Arty.ArtySetup( this, 10, "" );
		}

		public Artifact_AegisOfGrace( Serial serial ) : base( serial )
		{
		}

		public override void Serialize( GenericWriter writer )
		{
			base.Serialize( writer );
			writer.WriteEncodedInt( 0 ); // version
		}

		public override void Deserialize( GenericReader reader )
		{
			base.Deserialize( reader );
			ArtifactLevel = 2;
			int version = reader.ReadEncodedInt();
		}
	}
}