using System;
using System.Collections.Generic;
using Server;
using Server.Items;
using Server.Mobiles;
using Server.Spells;
using Server.Network;

namespace Server
{
	public class BuffInfo
	{
		public static bool Enabled { get { return Core.ML; } }

		public static void Initialize()
		{
			if( Enabled )
			{
				EventSink.ClientVersionReceived += new ClientVersionReceivedHandler( delegate( ClientVersionReceivedArgs args )
				{
					PlayerMobile pm = args.State.Mobile as PlayerMobile;
					
					if( pm != null )
						Timer.DelayCall( TimeSpan.Zero, pm.ResendBuffs );
				} );
			}
		}

		#region Properties
		private BuffIcon m_ID;
		public BuffIcon ID { get { return m_ID; } }

		private int m_TitleCliloc;
		public int TitleCliloc { get { return m_TitleCliloc; } }

		private int m_SecondaryCliloc;
		public int SecondaryCliloc { get { return m_SecondaryCliloc; } }

		private TimeSpan m_TimeLength;
		public TimeSpan TimeLength { get { return m_TimeLength; } }

		private DateTime m_TimeStart;
		public DateTime TimeStart { get { return m_TimeStart; } }

		private Timer m_Timer;
		public Timer Timer { get { return m_Timer; } }

		private bool m_RetainThroughDeath;
		public bool RetainThroughDeath { get { return m_RetainThroughDeath; } }

		private TextDefinition m_Args;
		public TextDefinition Args { get { return m_Args; } }

		#endregion

		#region Constructors
		public BuffInfo( BuffIcon iconID, int titleCliloc ): this( iconID, titleCliloc, titleCliloc + 1 )
		{
		}

		public BuffInfo( BuffIcon iconID, int titleCliloc, int secondaryCliloc )
		{
			m_ID = iconID;
			m_TitleCliloc = titleCliloc;
			m_SecondaryCliloc = secondaryCliloc;
		}

		public BuffInfo( BuffIcon iconID, int titleCliloc, TimeSpan length, Mobile m ): this( iconID, titleCliloc, titleCliloc + 1, length, m )
		{
		}

		//Only the timed one needs to Mobile to know when to automagically remove it.
		public BuffInfo( BuffIcon iconID, int titleCliloc, int secondaryCliloc, TimeSpan length, Mobile m ): this( iconID, titleCliloc, secondaryCliloc )
		{
			m_TimeLength = length;
			m_TimeStart = DateTime.Now;

			m_Timer = Timer.DelayCall( length, new TimerCallback(
				delegate
				{
					PlayerMobile pm = m as PlayerMobile;

					if( pm == null )
						return;

					pm.RemoveBuff( this );
				} ) );
		}

		public BuffInfo( BuffIcon iconID, int titleCliloc, TextDefinition args ): this( iconID, titleCliloc, titleCliloc + 1, args )
		{
		}

		public BuffInfo( BuffIcon iconID, int titleCliloc, int secondaryCliloc, TextDefinition args ): this( iconID, titleCliloc, secondaryCliloc )
		{
			m_Args = args;
		}

		public BuffInfo( BuffIcon iconID, int titleCliloc, bool retainThroughDeath ): this( iconID, titleCliloc, titleCliloc + 1, retainThroughDeath )
		{
		}

		public BuffInfo( BuffIcon iconID, int titleCliloc, int secondaryCliloc, bool retainThroughDeath ): this( iconID, titleCliloc, secondaryCliloc )
		{
			m_RetainThroughDeath = retainThroughDeath;
		}

		public BuffInfo( BuffIcon iconID, int titleCliloc, TextDefinition args, bool retainThroughDeath ): this( iconID, titleCliloc, titleCliloc + 1, args, retainThroughDeath )
		{
		}

		public BuffInfo( BuffIcon iconID, int titleCliloc, int secondaryCliloc, TextDefinition args, bool retainThroughDeath ): this( iconID, titleCliloc, secondaryCliloc, args )
		{
			m_RetainThroughDeath = retainThroughDeath;
		}

		public BuffInfo( BuffIcon iconID, int titleCliloc, TimeSpan length, Mobile m, TextDefinition args ): this( iconID, titleCliloc, titleCliloc + 1, length, m, args )
		{
		}

		public BuffInfo( BuffIcon iconID, int titleCliloc, int secondaryCliloc, TimeSpan length, Mobile m, TextDefinition args ): this( iconID, titleCliloc, secondaryCliloc, length, m )
		{
			m_Args = args;
		}

		public BuffInfo( BuffIcon iconID, int titleCliloc, TimeSpan length, Mobile m, TextDefinition args, bool retainThroughDeath ): this( iconID, titleCliloc, titleCliloc + 1, length, m, args, retainThroughDeath )
		{
		}

		public BuffInfo( BuffIcon iconID, int titleCliloc, int secondaryCliloc, TimeSpan length, Mobile m, TextDefinition args, bool retainThroughDeath ): this( iconID, titleCliloc, secondaryCliloc, length, m )
		{
			m_Args = args;
			m_RetainThroughDeath = retainThroughDeath;
		}

		#endregion

		#region Convenience Methods
		public static void AddBuff( Mobile m, BuffInfo b )
		{
			PlayerMobile pm = m as PlayerMobile;

			if( pm != null )
				pm.AddBuff( b );
		}

		public static void RemoveBuff( Mobile m, BuffInfo b )
		{
			PlayerMobile pm = m as PlayerMobile;

			if( pm != null )
				pm.RemoveBuff( b );
		}

		public static void RemoveBuff( Mobile m, BuffIcon b )
		{
			PlayerMobile pm = m as PlayerMobile;

			if( pm != null )
				pm.RemoveBuff( b );
		}


		public static void CleanupIcons( Mobile m, bool onlyParalyzed )
		{
			if( m != null ) 
			{
				if ( !onlyParalyzed )
				{
					if (m.Backpack != null)
					{
						Item orb = m.Backpack.FindItemByType( typeof ( SoulOrb ) );
						if ( orb == null )
							BuffInfo.RemoveBuff( m, BuffIcon.Resurrection );
						else
							BuffInfo.AddBuff( m, new BuffInfo( BuffIcon.Resurrection, 1063626, true ) );

						Item gem = m.Backpack.FindItemByType( typeof ( GemImmortality ) );
						if ( gem == null )
							BuffInfo.RemoveBuff( m, BuffIcon.GemImmortality );
						else
							BuffInfo.AddBuff( m, new BuffInfo( BuffIcon.GemImmortality, 1063658, true ) );

						Item shard = m.Backpack.FindItemByType( typeof ( JewelImmortality ) );
						if ( shard == null )
							BuffInfo.RemoveBuff( m, BuffIcon.WithstandDeath );
						else
							BuffInfo.AddBuff( m, new BuffInfo( BuffIcon.WithstandDeath, 1063656, true ) );

						Item enchant = m.Backpack.FindItemByType( typeof ( EnchantSpellStone ) );
						if ( enchant == null )
							BuffInfo.RemoveBuff( m, BuffIcon.Enchant );

						Item enchanted = m.Backpack.FindItemByType( typeof ( ResearchEnchantStone ) );
						if ( enchanted == null )
							BuffInfo.RemoveBuff( m, BuffIcon.EnchantWeapon );
					}

					if ( !TransformationSpellHelper.UnderTransformation( m ) )
					{
						BuffInfo.RemoveBuff( m, BuffIcon.WraithForm );
						BuffInfo.RemoveBuff( m, BuffIcon.HorrificBeast );
						BuffInfo.RemoveBuff( m, BuffIcon.LichForm );
						BuffInfo.RemoveBuff( m, BuffIcon.VampiricEmbrace );
					}

					if ( m.MagicDamageAbsorb < 1 )
					{
						BuffInfo.RemoveBuff( m, BuffIcon.Absorption );
						BuffInfo.RemoveBuff( m, BuffIcon.PsychicWall );
						BuffInfo.RemoveBuff( m, BuffIcon.Deflection );
						BuffInfo.RemoveBuff( m, BuffIcon.TrialByFire );
						BuffInfo.RemoveBuff( m, BuffIcon.OrbOfOrcus );
						BuffInfo.RemoveBuff( m, BuffIcon.MagicReflection );
						BuffInfo.RemoveBuff( m, BuffIcon.ElementalEcho );
					}
					if ( !m.Poisoned )
					{
						BuffInfo.RemoveBuff( m, BuffIcon.Poisoned );
					}
				}
				else if ( !m.Paralyzed )
				{
						BuffInfo.RemoveBuff( m, BuffIcon.ElementalHold );
						BuffInfo.RemoveBuff( m, BuffIcon.StasisField );
						BuffInfo.RemoveBuff( m, BuffIcon.Hilarity );
						BuffInfo.RemoveBuff( m, BuffIcon.Paralyze );
						BuffInfo.RemoveBuff( m, BuffIcon.SleepField );
						BuffInfo.RemoveBuff( m, BuffIcon.Sleep );
						BuffInfo.RemoveBuff( m, BuffIcon.MassSleep );
						BuffInfo.RemoveBuff( m, BuffIcon.ParalyzeField );
						BuffInfo.RemoveBuff( m, BuffIcon.GraspingRoots );
						BuffInfo.RemoveBuff( m, BuffIcon.PeaceMaking );
						BuffInfo.RemoveBuff( m, BuffIcon.Firefly );
						BuffInfo.RemoveBuff( m, BuffIcon.Begging );
						BuffInfo.RemoveBuff( m, BuffIcon.Confusion );
						BuffInfo.RemoveBuff( m, BuffIcon.Charm );
						BuffInfo.RemoveBuff( m, BuffIcon.Fear );
				}
			}
		}
		#endregion
	}

	public enum BuffIcon : short
	{
		CheetahPaws=0x3E9,
		Deception=0x3EA,
		NightSight=0x3ED,
		DeathStrike,
		EvilOmen,
		Poisoned,
		EyesOfTheDead,
		DivineFury,
		EnemyOfOne,
		HidingAndOrStealth,
		ActiveMeditation,
		BloodOathCaster,
		BloodOathCurse,
		CorpseSkin,
		Mindrot,
		PainSpike,
		Strangle,
		GhostlyImages,
		SpectralShadow,
		DrainLifeGood,
		DrainLifeBad,
		Projection,
		Absorption,
		Speed,
		ShieldOfHate,
		ReactiveArmor,
		Protection,
		ParalyzeField,
		MagicReflection,
		Incognito,
		ElementalArmor,
		AstralProjection,
		Polymorph,
		Invisibility,
		Paralyze,
		MassCurse,
		RemoveTrap,
		Clumsy,
		FeebleMind,
		Weaken,
		Curse,
		Resurrection,
		Agility,
		Cunning,
		Strength,
		Bless,
		CheetahPawss, 
		Deceptions, 
		PsychicWall, 
		WindRunner, 
		NotUsed1, 
		Insult, 
		Hilarity,
		Deflection, 
		Celerity, 
		Mirage, 
		PsychicAura, 
		StasisField,
		NotUsed2, 
		HammerOfFaith, 
		SacredBoon, 
		Sanctify, 
		Seance, 
		TrialByFire,
		Enchant, 
		BlendWithForest, 
		GrimReaper, 
		GraspingRoots,
		WoodlandProtection,
		OrbOfOrcus,
		ArmysPaeon,
		SoulReaper, 
		StrengthOfSteel, 
		SuccubusSkin, 
		EnchantingEtude, 
		EnergyCarol, 
		EnergyThrenody, 
		FireCarol, 
		FireThrenody, 
		IceCarol, 
		IceThrenody, 
		KnightsMinne, 
		MagesBallad, 
		PoisonCarol, 
		PoisonThrenody, 
		ShephardsDance, 
		SinewyEtude, 
		PotionAgility, 
		WraithForm, 
		ConsecrateWeapon,
		PotionInvisible, 
		HorrificBeast, 
		LichForm, 
		PotionInvulnerable,
		PotionNightSight, 
		PotionStrength, 
		VampiricEmbrace, 
		PotionSuperior,
		CurseWeapon, 
		ElementalEcho, 
		ElementalHold, 
		ElementalProtect, 
		AirWalk, 
		ConfusionBlast,
		EnchantWeapon,
		EndureCold,
		EndureHeat,
		MaskDeath, 
		MassMight, 
		MassSleep, 
		RockFlesh, 
		Sleep, 
		SleepField,
		Sneak,
		WithstandDeath,
		GemImmortality,
		Intervention, 
		PeaceMaking, 
		Discordance, 
		Begging, 
		Firefly,
		FishStr,
		Skip,
		Bandage,
		Confusion,
		Charm,
		Fear,
		FishDex,
		FishInt,
		Spyglass,
		Confidence,
		Counter,
		Evasion,
		Honorable
	}

	public sealed class AddBuffPacket : Packet
	{
		public AddBuffPacket( Mobile m, BuffInfo info ): this( m, info.ID, info.TitleCliloc, info.SecondaryCliloc, info.Args, (info.TimeStart != DateTime.MinValue) ? ((info.TimeStart + info.TimeLength) - DateTime.Now) : TimeSpan.Zero )
		{
		}

		public AddBuffPacket( Mobile mob, BuffIcon iconID, int titleCliloc, int secondaryCliloc, TextDefinition args, TimeSpan length ): base( 0xDF )
		{
			bool hasArgs = (args != null);

			this.EnsureCapacity( (hasArgs ? (48 + args.ToString().Length * 2): 44) );
			m_Stream.Write( (int)mob.Serial );

			m_Stream.Write( (short)iconID );	// ID
			m_Stream.Write( (short)0x1 );		// Type 0 for removal. 1 for add 2 for Data

			m_Stream.Fill( 4 );

			m_Stream.Write( (short)iconID );	// ID
			m_Stream.Write( (short)0x01 );		// Type 0 for removal. 1 for add 2 for Data

			m_Stream.Fill( 4 );

			if( length < TimeSpan.Zero )
				length = TimeSpan.Zero;

			m_Stream.Write( (short)length.TotalSeconds );	//Time in seconds

			m_Stream.Fill( 3 );
			m_Stream.Write( (int)titleCliloc );
			m_Stream.Write( (int)secondaryCliloc );

			if( !hasArgs )
			{
				m_Stream.Fill( 10 );
			}
			else
			{
				m_Stream.Fill( 4 );
				m_Stream.Write( (short)0x1 );	//Unknown -> Possibly something saying 'hey, I have more data!'?
				m_Stream.Fill( 2 );

				m_Stream.WriteLittleUniNull( String.Format( "\t{0}", args.ToString() ) );

				m_Stream.Write( (short)0x1 );	//Even more Unknown -> Possibly something saying 'hey, I have more data!'?
				m_Stream.Fill( 2 );
			}
		}
	}

	public sealed class RemoveBuffPacket : Packet
	{
		public RemoveBuffPacket( Mobile mob, BuffInfo info ): this( mob, info.ID )
		{
		}

		public RemoveBuffPacket( Mobile mob, BuffIcon iconID ): base( 0xDF )
		{
			this.EnsureCapacity( 13 );
			m_Stream.Write( (int)mob.Serial );

			m_Stream.Write( (short)iconID );	// ID
			m_Stream.Write( (short)0x0 );		// Type 0 for removal. 1 for add 2 for Data

			m_Stream.Fill( 4 );

			mob.Str = mob.Str;
			mob.Int = mob.Int;
			mob.Dex = mob.Dex;
		}
	}
}
