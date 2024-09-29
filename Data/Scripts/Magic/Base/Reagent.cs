using System;
using Server.Items;

namespace Server.Spells
{
	public class Reagent
	{
		private static Type[] m_Types = new Type[46]
			{
				typeof( BlackPearl ),
				typeof( Bloodmoss ),
				typeof( Garlic ),
				typeof( Ginseng ),
				typeof( MandrakeRoot ),
				typeof( Nightshade ),
				typeof( SulfurousAsh ),
				typeof( SpidersSilk ),
				typeof( BatWing ),
				typeof( GraveDust ),
				typeof( DaemonBlood ),
				typeof( NoxCrystal ),
				typeof( PigIron ),
				typeof( BeetleShell ),
				typeof( BitterRoot ),
				typeof( BlackSand ),
				typeof( BloodRose ),
				typeof( Brimstone ),
				typeof( ButterflyWings ),
				typeof( DriedToad ),
				typeof( EyeOfToad ),
				typeof( FairyEgg ),
				typeof( GargoyleEar ),
				typeof( Maggot ),
				typeof( MoonCrystal ),
				typeof( MummyWrap ),
				typeof( PixieSkull ),
				typeof( RedLotus ),
				typeof( SeaSalt ),
				typeof( SilverWidow ),
				typeof( SwampBerries ),
				typeof( VioletFungus ),
				typeof( WerewolfClaw ),
				typeof( Wolfsbane ),
				typeof( UnicornHorn ),
				typeof( PegasusFeather ),
				typeof( GoldenSerpentVenom ),
				typeof( PhoenixFeather ),
				typeof( DemigodBlood ),
				typeof( EnchantedSeaweed ),
				typeof( GhostlyDust ),
				typeof( LichDust ),
				typeof( DragonTooth ),
				typeof( SilverSerpentVenom ),
				typeof( DragonBlood ),
				typeof( DemonClaw )
			};

		public Type[] Types
		{
			get{ return m_Types; }
		}

		public static Type BlackPearl
		{
			get{ return m_Types[0]; }
			set{ m_Types[0] = value; }
		}

		public static Type Bloodmoss
		{
			get{ return m_Types[1]; }
			set{ m_Types[1] = value; }
		}

		public static Type Garlic
		{
			get{ return m_Types[2]; }
			set{ m_Types[2] = value; }
		}

		public static Type Ginseng
		{
			get{ return m_Types[3]; }
			set{ m_Types[3] = value; }
		}

		public static Type MandrakeRoot
		{
			get{ return m_Types[4]; }
			set{ m_Types[4] = value; }
		}

		public static Type Nightshade
		{
			get{ return m_Types[5]; }
			set{ m_Types[5] = value; }
		}

		public static Type SulfurousAsh
		{
			get{ return m_Types[6]; }
			set{ m_Types[6] = value; }
		}

		public static Type SpidersSilk
		{
			get{ return m_Types[7]; }
			set{ m_Types[7] = value; }
		}

		public static Type BatWing
		{
			get{ return m_Types[8]; }
			set{ m_Types[8] = value; }
		}

		public static Type GraveDust
		{
			get{ return m_Types[9]; }
			set{ m_Types[9] = value; }
		}

		public static Type DaemonBlood
		{
			get{ return m_Types[10]; }
			set{ m_Types[10] = value; }
		}

		public static Type NoxCrystal
		{
			get{ return m_Types[11]; }
			set{ m_Types[11] = value; }
		}

		public static Type PigIron
		{
			get{ return m_Types[12]; }
			set{ m_Types[12] = value; }
		}

		public static Type BeetleShell
		{
			get{ return m_Types[13]; }
			set{ m_Types[13] = value; }
		}

		public static Type BitterRoot
		{
			get{ return m_Types[14]; }
			set{ m_Types[14] = value; }
		}

		public static Type BlackSand
		{
			get{ return m_Types[15]; }
			set{ m_Types[15] = value; }
		}

		public static Type BloodRose
		{
			get{ return m_Types[16]; }
			set{ m_Types[16] = value; }
		}

		public static Type Brimstone
		{
			get{ return m_Types[17]; }
			set{ m_Types[17] = value; }
		}

		public static Type ButterflyWings
		{
			get{ return m_Types[18]; }
			set{ m_Types[18] = value; }
		}

		public static Type DriedToad
		{
			get{ return m_Types[19]; }
			set{ m_Types[19] = value; }
		}

		public static Type EyeOfToad
		{
			get{ return m_Types[20]; }
			set{ m_Types[20] = value; }
		}

		public static Type FairyEgg
		{
			get{ return m_Types[21]; }
			set{ m_Types[21] = value; }
		}

		public static Type GargoyleEar
		{
			get{ return m_Types[22]; }
			set{ m_Types[22] = value; }
		}

		public static Type Maggot
		{
			get{ return m_Types[23]; }
			set{ m_Types[23] = value; }
		}

		public static Type MoonCrystal
		{
			get{ return m_Types[24]; }
			set{ m_Types[24] = value; }
		}

		public static Type MummyWrap
		{
			get{ return m_Types[25]; }
			set{ m_Types[25] = value; }
		}

		public static Type PixieSkull
		{
			get{ return m_Types[26]; }
			set{ m_Types[26] = value; }
		}

		public static Type RedLotus
		{
			get{ return m_Types[27]; }
			set{ m_Types[27] = value; }
		}

		public static Type SeaSalt
		{
			get{ return m_Types[28]; }
			set{ m_Types[28] = value; }
		}

		public static Type SilverWidow
		{
			get{ return m_Types[29]; }
			set{ m_Types[29] = value; }
		}

		public static Type SwampBerries
		{
			get{ return m_Types[30]; }
			set{ m_Types[30] = value; }
		}

		public static Type VioletFungus
		{
			get{ return m_Types[31]; }
			set{ m_Types[31] = value; }
		}

		public static Type WerewolfClaw
		{
			get{ return m_Types[32]; }
			set{ m_Types[32] = value; }
		}

		public static Type Wolfsbane
		{
			get{ return m_Types[33]; }
			set{ m_Types[33] = value; }
		}

		public static Type UnicornHorn
		{
			get{ return m_Types[34]; }
			set{ m_Types[34] = value; }
		}

		public static Type PegasusFeather
		{
			get{ return m_Types[35]; }
			set{ m_Types[35] = value; }
		}

		public static Type GoldenSerpentVenom
		{
			get{ return m_Types[36]; }
			set{ m_Types[36] = value; }
		}
		public static Type PhoenixFeather
		{
			get{ return m_Types[37]; }
			set{ m_Types[37] = value; }
		}

		public static Type DemigodBlood
		{
			get{ return m_Types[38]; }
			set{ m_Types[38] = value; }
		}

		public static Type EnchantedSeaweed
		{
			get{ return m_Types[39]; }
			set{ m_Types[39] = value; }
		}

		public static Type GhostlyDust
		{
			get{ return m_Types[40]; }
			set{ m_Types[40] = value; }
		}

		public static Type LichDust
		{
			get{ return m_Types[41]; }
			set{ m_Types[41] = value; }
		}

		public static Type DragonTooth
		{
			get{ return m_Types[42]; }
			set{ m_Types[42] = value; }
		}

		public static Type SilverSerpentVenom
		{
			get{ return m_Types[43]; }
			set{ m_Types[43] = value; }
		}

		public static Type DragonBlood
		{
			get{ return m_Types[44]; }
			set{ m_Types[44] = value; }
		}

		public static Type DemonClaw
		{
			get{ return m_Types[45]; }
			set{ m_Types[45] = value; }
		}
	}
}