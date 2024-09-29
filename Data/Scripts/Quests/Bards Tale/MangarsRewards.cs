using System;
using Server;

namespace Server.Items
{
	public class MangarRobe : Robe
	{
		[Constructable]
		public MangarRobe()
		{
			Hue = 0x497;
			ItemID = 0x26AE;
			Name = "Mangar's Robe";
			Attributes.LowerManaCost = 25;
			Attributes.LowerRegCost = 25;
			SkillBonuses.SetValues( 0, SkillName.Psychology, 10 );
			SkillBonuses.SetValues( 1, SkillName.Magery, 10 );
			SkillBonuses.SetValues( 2, SkillName.MagicResist, 10 );
			SkillBonuses.SetValues( 3, SkillName.Meditation, 10 );
			Attributes.RegenMana = 10;
			Attributes.BonusInt = 10;
			ArtifactLevel = 2;
		}

		public MangarRobe( Serial serial ) : base( serial )
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
			int version = reader.ReadInt();
			ArtifactLevel = 2;
		}
	}

	public class MangarNecroRobe : Robe
	{
		[Constructable]
		public MangarNecroRobe()
		{
			Hue = 0x497;
			ItemID = 0x26AE;
			Name = "Mangar's Robe";
			Attributes.LowerManaCost = 25;
			Attributes.LowerRegCost = 25;
			SkillBonuses.SetValues( 0, SkillName.Spiritualism, 10 );
			SkillBonuses.SetValues( 1, SkillName.Necromancy, 10 );
			SkillBonuses.SetValues( 2, SkillName.MagicResist, 10 );
			SkillBonuses.SetValues( 3, SkillName.Meditation, 10 );
			Attributes.RegenMana = 10;
			Attributes.BonusInt = 10;
			ArtifactLevel = 2;
		}

		public MangarNecroRobe( Serial serial ) : base( serial )
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
			int version = reader.ReadInt();
			ArtifactLevel = 2;
		}
	}

	public class MangarElementalistRobe : Robe
	{
		[Constructable]
		public MangarElementalistRobe()
		{
			Hue = 0x497;
			ItemID = 0x26AE;
			Name = "Mangar's Robe";
			Attributes.LowerManaCost = 25;
			Attributes.LowerRegCost = 25;
			SkillBonuses.SetValues( 0, SkillName.Elementalism, 10 );
			SkillBonuses.SetValues( 1, SkillName.Focus, 10 );
			SkillBonuses.SetValues( 2, SkillName.MagicResist, 10 );
			SkillBonuses.SetValues( 3, SkillName.Meditation, 10 );
			Attributes.RegenMana = 10;
			Attributes.BonusInt = 10;
			ArtifactLevel = 2;
		}

		public MangarElementalistRobe( Serial serial ) : base( serial )
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
			int version = reader.ReadInt();
			ArtifactLevel = 2;
		}
	}

	public class BardicFeatheredCap : FeatheredHat
	{
		[Constructable]
		public BardicFeatheredCap()
		{
			Hue = 0x300;
			ItemID = 5914;
			Name = "Bardic Feathered Cap";
			SkillBonuses.SetValues( 0, SkillName.Musicianship, 10 );
			SkillBonuses.SetValues( 1, SkillName.Provocation, 10 );
			SkillBonuses.SetValues( 2, SkillName.Discordance, 10 );
			SkillBonuses.SetValues( 3, SkillName.Peacemaking, 10 );
			Attributes.RegenMana = 10;
			Attributes.BonusDex = 10;
			ArtifactLevel = 2;
		}

		public BardicFeatheredCap( Serial serial ) : base( serial )
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
			int version = reader.ReadInt();
			ArtifactLevel = 2;
		}
	}
}