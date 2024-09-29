using System;
using Server;

namespace Server.Items
{
	public class Artifact_SerpentsFang : GiftKryss
	{
		public override int InitMinHits{ get{ return 80; } }
		public override int InitMaxHits{ get{ return 160; } }

		[Constructable]
		public Artifact_SerpentsFang()
		{
			Name = "Serpent's Fang";
			ItemID = 0x1400;
			Hue = 0x488;
			WeaponAttributes.HitPoisonArea = 100;
			WeaponAttributes.ResistPoisonBonus = 20;
			Attributes.AttackChance = 15;
			Attributes.WeaponDamage = 50;
			SkillBonuses.SetValues(0, SkillName.Poisoning, 10);
			AosElementDamages.Physical = 50;
			AosElementDamages.Poison = 50;
			ArtifactLevel = 2;
			Server.Misc.Arty.ArtySetup( this, 10, "" );
		}

		public override void GetDamageTypes( Mobile wielder, out int phys, out int fire, out int cold, out int pois, out int nrgy, out int chaos, out int direct )
		{
			fire = cold = nrgy = chaos = direct = 0;
			phys = 25;
			pois = 75;
		}

		public Artifact_SerpentsFang( Serial serial ) : base( serial )
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