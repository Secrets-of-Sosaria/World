using System;
using Server;

namespace Server.Items
{
	public class Artifact_CandleCold : GiftCandle
	{
		[Constructable]
		public Artifact_CandleCold()
		{
			Hue = 0x48D;
			Name = "Candle of Cold Light";
			Resistances.Cold = 50;
			Attributes.BonusHits = 20;
			Attributes.BonusStam = 20;
			Attributes.BonusMana = 20;
			Attributes.Luck = 400;
			ArtifactLevel = 2;
			Server.Misc.Arty.ArtySetup( this, 13, "" );
		}

		public Artifact_CandleCold( Serial serial ) : base( serial )
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
	///////////////////////////////////////////////////////////////////////////////////////////////
	public class Artifact_CandleFire : GiftCandle
	{
		[Constructable]
		public Artifact_CandleFire()
		{
			Hue = 0x48E;
			Name = "Candle of Fire Light";
			Resistances.Fire = 50;
			Attributes.BonusHits = 20;
			Attributes.BonusStam = 20;
			Attributes.BonusMana = 20;
			Attributes.Luck = 400;
			ArtifactLevel = 2;
			Server.Misc.Arty.ArtySetup( this, 13, "" );
		}

		public Artifact_CandleFire( Serial serial ) : base( serial )
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
	///////////////////////////////////////////////////////////////////////////////////////////////
	public class Artifact_CandlePoison : GiftCandle
	{
		[Constructable]
		public Artifact_CandlePoison()
		{
			Hue = 0x48F;
			Name = "Candle of Poisonous Light";
			Resistances.Poison = 50;
			Attributes.BonusHits = 20;
			Attributes.BonusStam = 20;
			Attributes.BonusMana = 20;
			Attributes.Luck = 400;
			ArtifactLevel = 2;
			Server.Misc.Arty.ArtySetup( this, 13, "" );
		}

		public Artifact_CandlePoison( Serial serial ) : base( serial )
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
	///////////////////////////////////////////////////////////////////////////////////////////////
	public class Artifact_CandleEnergy : GiftCandle
	{
		[Constructable]
		public Artifact_CandleEnergy()
		{
			Hue = 0x490;
			Name = "Candle of Energized Light";
			Resistances.Energy = 50;
			Attributes.BonusHits = 20;
			Attributes.BonusStam = 20;
			Attributes.BonusMana = 20;
			Attributes.Luck = 400;
			ArtifactLevel = 2;
			Server.Misc.Arty.ArtySetup( this, 13, "" );
		}

		public Artifact_CandleEnergy( Serial serial ) : base( serial )
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
	///////////////////////////////////////////////////////////////////////////////////////////////
	public class Artifact_CandleWizard : GiftCandle
	{
		[Constructable]
		public Artifact_CandleWizard()
		{
			Hue = 0xB96;
			Name = "Candle of Wizardly Light";
			SkillBonuses.SetValues( 0, SkillName.Magery, 10 );
			SkillBonuses.SetValues( 1, SkillName.Meditation, 10 );
			SkillBonuses.SetValues( 2, SkillName.Psychology, 10 );
			Attributes.CastRecovery = 1;
			Attributes.CastSpeed = 1;
			Attributes.LowerManaCost = 25;
			Attributes.LowerRegCost = 25;
			ArtifactLevel = 2;
			Server.Misc.Arty.ArtySetup( this, 12, "" );
		}

		public Artifact_CandleWizard( Serial serial ) : base( serial )
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
	///////////////////////////////////////////////////////////////////////////////////////////////
	public class Artifact_CandleNecromancer : GiftCandle
	{
		[Constructable]
		public Artifact_CandleNecromancer()
		{
			Hue = 0x47E;
			Name = "Candle of Ghostly Light";
			SkillBonuses.SetValues( 0, SkillName.Necromancy, 10 );
			SkillBonuses.SetValues( 1, SkillName.Meditation, 10 );
			SkillBonuses.SetValues( 2, SkillName.Spiritualism, 10 );
			Attributes.CastRecovery = 1;
			Attributes.CastSpeed = 1;
			Attributes.LowerManaCost = 25;
			Attributes.LowerRegCost = 25;
			ArtifactLevel = 2;
			Server.Misc.Arty.ArtySetup( this, 12, "" );
		}

		public Artifact_CandleNecromancer( Serial serial ) : base( serial )
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