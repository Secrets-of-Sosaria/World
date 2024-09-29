using System;
using Server;

namespace Server.Items
{
	public class Artifact_FangOfRactus : GiftKryss
	{
		public override int InitMinHits{ get{ return 80; } }
		public override int InitMaxHits{ get{ return 160; } }

		public override bool CanFortify{ get{ return false; } }

		[Constructable]
		public Artifact_FangOfRactus()
		{
			Name = "Fang of Ractus";
			Hue = 0x117;

			Attributes.SpellChanneling = 1;
			Attributes.AttackChance = 5;
			Attributes.DefendChance = 5;
			Attributes.WeaponDamage = 35;

			SkillBonuses.SetValues( 0, SkillName.Poisoning, 20 );

			WeaponAttributes.HitPoisonArea = 20;
			WeaponAttributes.ResistPoisonBonus = 15;
			ArtifactLevel = 2;
			Server.Misc.Arty.ArtySetup( this, 9, "" );
		}

		public Artifact_FangOfRactus( Serial serial ) : base( serial )
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
