using System;
using Server;

namespace Server.Items
{
	public class Artifact_MidnightTunic : GiftBoneChest
	{
		public override int InitMinHits{ get{ return 80; } }
		public override int InitMaxHits{ get{ return 160; } }

		public override int BasePhysicalResistance{ get{ return 25; } }

		[Constructable]
		public Artifact_MidnightTunic()
		{
			Name = "Midnight Tunic";
			Hue = 0x455;
			SkillBonuses.SetValues( 0, SkillName.Necromancy, 15.0 );
			SkillBonuses.SetValues( 1, SkillName.Spiritualism, 15.0 );
			Attributes.SpellDamage = 10;
			ArmorAttributes.MageArmor = 1;
			Attributes.LowerManaCost = 12;
			Attributes.LowerManaCost = 12;
			ArtifactLevel = 2;
			Server.Misc.Arty.ArtySetup( this, 10, "" );
		}

		public Artifact_MidnightTunic( Serial serial ) : base( serial )
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