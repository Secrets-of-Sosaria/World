using System;
using Server;

namespace Server.Items
{
	public class CandleCold : MagicCandle
	{
		[Constructable]
		public CandleCold()
		{
			Hue = 0x48D;
			Name = "Candle of Cold Light";
			Resistances.Cold = 50;
			Attributes.BonusHits = 20;
			Attributes.BonusStam = 20;
			Attributes.BonusMana = 20;
			Attributes.Luck = 400;
		}

        public override void AddNameProperties(ObjectPropertyList list)
		{
            base.AddNameProperties(list);
			list.Add( 1070722, "Artefact");
        } 

		public CandleCold( Serial serial ) : base( serial )
		{
		}

		public override void Serialize( GenericWriter writer )
		{
			base.Serialize( writer );
			writer.Write( (int) 0 ); // version
		}

		private void Cleanup( object state ){ Item item = new Artifact_CandleCold(); Server.Misc.Cleanup.DoCleanup( (Item)state, item ); }

public override void Deserialize( GenericReader reader )
		{
			base.Deserialize( reader ); Timer.DelayCall( TimeSpan.FromSeconds( 1.0 ), new TimerStateCallback( Cleanup ), this );
			int version = reader.ReadInt();
		}
	}
	///////////////////////////////////////////////////////////////////////////////////////////////
	public class CandleFire : MagicCandle
	{
		[Constructable]
		public CandleFire()
		{
			Hue = 0x48E;
			Name = "Candle of Fire Light";
			Resistances.Fire = 50;
			Attributes.BonusHits = 20;
			Attributes.BonusStam = 20;
			Attributes.BonusMana = 20;
			Attributes.Luck = 400;
		}

        public override void AddNameProperties(ObjectPropertyList list)
		{
            base.AddNameProperties(list);
			list.Add( 1070722, "Artefact");
        } 

		public CandleFire( Serial serial ) : base( serial )
		{
		}

		public override void Serialize( GenericWriter writer )
		{
			base.Serialize( writer );
			writer.Write( (int) 0 ); // version
		}

		private void Cleanup( object state ){ Item item = new Artifact_CandleFire(); Server.Misc.Cleanup.DoCleanup( (Item)state, item ); }

public override void Deserialize( GenericReader reader )
		{
			base.Deserialize( reader ); Timer.DelayCall( TimeSpan.FromSeconds( 1.0 ), new TimerStateCallback( Cleanup ), this );
			int version = reader.ReadInt();
		}
	}
	///////////////////////////////////////////////////////////////////////////////////////////////
	public class CandlePoison : MagicCandle
	{
		[Constructable]
		public CandlePoison()
		{
			Hue = 0x48F;
			Name = "Candle of Poisonous Light";
			Resistances.Poison = 50;
			Attributes.BonusHits = 20;
			Attributes.BonusStam = 20;
			Attributes.BonusMana = 20;
			Attributes.Luck = 400;
		}

        public override void AddNameProperties(ObjectPropertyList list)
		{
            base.AddNameProperties(list);
			list.Add( 1070722, "Artefact");
        } 

		public CandlePoison( Serial serial ) : base( serial )
		{
		}

		public override void Serialize( GenericWriter writer )
		{
			base.Serialize( writer );
			writer.Write( (int) 0 ); // version
		}

		private void Cleanup( object state ){ Item item = new Artifact_CandlePoison(); Server.Misc.Cleanup.DoCleanup( (Item)state, item ); }

public override void Deserialize( GenericReader reader )
		{
			base.Deserialize( reader ); Timer.DelayCall( TimeSpan.FromSeconds( 1.0 ), new TimerStateCallback( Cleanup ), this );
			int version = reader.ReadInt();
		}
	}
	///////////////////////////////////////////////////////////////////////////////////////////////
	public class CandleEnergy : MagicCandle
	{
		[Constructable]
		public CandleEnergy()
		{
			Hue = 0x490;
			Name = "Candle of Energized Light";
			Resistances.Energy = 50;
			Attributes.BonusHits = 20;
			Attributes.BonusStam = 20;
			Attributes.BonusMana = 20;
			Attributes.Luck = 400;
		}

        public override void AddNameProperties(ObjectPropertyList list)
		{
            base.AddNameProperties(list);
			list.Add( 1070722, "Artefact");
        } 

		public CandleEnergy( Serial serial ) : base( serial )
		{
		}

		public override void Serialize( GenericWriter writer )
		{
			base.Serialize( writer );
			writer.Write( (int) 0 ); // version
		}

		private void Cleanup( object state ){ Item item = new Artifact_CandleEnergy(); Server.Misc.Cleanup.DoCleanup( (Item)state, item ); }

public override void Deserialize( GenericReader reader )
		{
			base.Deserialize( reader ); Timer.DelayCall( TimeSpan.FromSeconds( 1.0 ), new TimerStateCallback( Cleanup ), this );
			int version = reader.ReadInt();
		}
	}
	///////////////////////////////////////////////////////////////////////////////////////////////
	public class CandleWizard : MagicCandle
	{
		[Constructable]
		public CandleWizard()
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
		}

        public override void AddNameProperties(ObjectPropertyList list)
		{
            base.AddNameProperties(list);
			list.Add( 1070722, "Artefact");
        } 

		public CandleWizard( Serial serial ) : base( serial )
		{
		}

		public override void Serialize( GenericWriter writer )
		{
			base.Serialize( writer );
			writer.Write( (int) 0 ); // version
		}

		private void Cleanup( object state ){ Item item = new Artifact_CandleWizard(); Server.Misc.Cleanup.DoCleanup( (Item)state, item ); }

public override void Deserialize( GenericReader reader )
		{
			base.Deserialize( reader ); Timer.DelayCall( TimeSpan.FromSeconds( 1.0 ), new TimerStateCallback( Cleanup ), this );
			int version = reader.ReadInt();
		}
	}
	///////////////////////////////////////////////////////////////////////////////////////////////
	public class CandleNecromancer : MagicCandle
	{
		[Constructable]
		public CandleNecromancer()
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
		}

        public override void AddNameProperties(ObjectPropertyList list)
		{
            base.AddNameProperties(list);
			list.Add( 1070722, "Artefact");
        } 

		public CandleNecromancer( Serial serial ) : base( serial )
		{
		}

		public override void Serialize( GenericWriter writer )
		{
			base.Serialize( writer );
			writer.Write( (int) 0 ); // version
		}

		private void Cleanup( object state ){ Item item = new Artifact_CandleNecromancer(); Server.Misc.Cleanup.DoCleanup( (Item)state, item ); }

public override void Deserialize( GenericReader reader )
		{
			base.Deserialize( reader ); Timer.DelayCall( TimeSpan.FromSeconds( 1.0 ), new TimerStateCallback( Cleanup ), this );
			int version = reader.ReadInt();
		}
	}
}