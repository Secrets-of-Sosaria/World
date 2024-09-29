using System;
using Server;

namespace Server.Items
{
	public class Artifact_MidnightGloves : GiftBoneGloves
	{
		public override int InitMinHits{ get{ return 80; } }
		public override int InitMaxHits{ get{ return 160; } }

		public override int BasePhysicalResistance{ get{ return 19; } }

		[Constructable]
		public Artifact_MidnightGloves()
		{
			Name = "Midnight Gloves";
			Hue = 0x455;
			SkillBonuses.SetValues( 0, SkillName.Necromancy, 5.0 );
			Attributes.SpellDamage = 10;
			ArmorAttributes.MageArmor = 1;
			ArtifactLevel = 2;
			Server.Misc.Arty.ArtySetup( this, 4, "" );
		}

		public Artifact_MidnightGloves( Serial serial ) : base( serial )
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