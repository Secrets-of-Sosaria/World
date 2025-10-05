using System;
using Server;

namespace Server.Items
{
	public class Artifact_Aegis : GiftHeaterShield
	{
		[Constructable]
		public Artifact_Aegis()
		{
			Name = "Aegis";
			Hue = 0x47E;
			SkillBonuses.SetValues( 0, SkillName.Parry, 20 );
			ArmorAttributes.SelfRepair = 10;
			Attributes.ReflectPhysical = 15;
			Attributes.DefendChance = 15;
			Attributes.LowerManaCost = 10;
			PhysicalBonus = 15;
			ArtifactLevel = 2;
			Server.Misc.Arty.ArtySetup( this, 10, "" );
		}

		public Artifact_Aegis( Serial serial ) : base( serial )
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