using System;
using Server;

namespace Server.Items
{
	public class Artifact_AchillesShield : GiftBronzeShield
	{
		public override int InitMinHits{ get{ return 80; } }
		public override int InitMaxHits{ get{ return 160; } }

		[Constructable]
		public Artifact_AchillesShield()
		{
			Hue = 0xB1B;
			Name = "Achille's Shield";
			SkillBonuses.SetValues( 0, SkillName.Parry, 25 );
			ArmorAttributes.SelfRepair = 5;
			ArmorAttributes.DurabilityBonus = 31;
			ArmorAttributes.LowerStatReq = 10;
			Attributes.DefendChance = 8;
			Attributes.ReflectPhysical = 5;
			Attributes.WeaponDamage = 8;
			PhysicalBonus = 20;
			ArtifactLevel = 2;
			Server.Misc.Arty.ArtySetup( this, 10, "" );
		}

		public Artifact_AchillesShield( Serial serial ) : base( serial )
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