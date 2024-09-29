using System;
using Server;

namespace Server.Items
{
	public class Artifact_MidnightLegs : GiftBoneLegs
	{
		public override int InitMinHits{ get{ return 80; } }
		public override int InitMaxHits{ get{ return 160; } }

		public override int BasePhysicalResistance{ get{ return 21; } }

		[Constructable]
		public Artifact_MidnightLegs()
		{
			Name = "Midnight Leggings";
			Hue = 0x455;
			SkillBonuses.SetValues( 0, SkillName.Necromancy, 10.0 );
			Attributes.SpellDamage = 10;
			ArmorAttributes.MageArmor = 1;
			ArtifactLevel = 2;
			Server.Misc.Arty.ArtySetup( this, 5, "" );
		}

		public Artifact_MidnightLegs( Serial serial ) : base( serial )
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

			if ( version < 1 )
				PhysicalBonus = 0;
		}
	}
}