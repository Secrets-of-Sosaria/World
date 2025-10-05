using System;
using Server;

namespace Server.Items
{
	public class Artifact_BladeOfTheWilds : GiftLongsword
	{
		public override int InitMinHits{ get{ return 80; } }
		public override int InitMaxHits{ get{ return 160; } }

		[Constructable]
		public Artifact_BladeOfTheWilds()
		{
			Hue = 0x21F;
			Name = "Blade of the Wilds";
			Slayer = SlayerName.Repond;
			WeaponAttributes.HitLeechHits = 20;
			WeaponAttributes.HitDispel = 20;
			Attributes.BonusHits = 10;
			Attributes.WeaponDamage = 12;
            SkillBonuses.SetValues(0, SkillName.Tactics, 10);
			SkillBonuses.SetValues(2, SkillName.Druidism, 5);
			ArtifactLevel = 2;
			Server.Misc.Arty.ArtySetup( this, 10, "" );
		}

		public Artifact_BladeOfTheWilds( Serial serial ) : base( serial )
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