using System;
using System.Text;
using System.Collections;
using Server.Network;
using Server.Targeting;
using Server.Spells;
using Server.Mobiles;

namespace Server.Items
{
	public enum MagicStaffEffect
	{
		Charges
	}

	public abstract class BaseMagicStaff : BaseBashing
	{
		public override int AosStrengthReq { get { return 5; } }
		public override int AosMinDamage { get { return 7; } }
		public override int AosMaxDamage { get { return 9; } }
		public override int AosSpeed { get { return 40; } }

		public override int InitMinHits { get { return 50; } }
		public override int InitMaxHits { get { return 50; } }

		public override float MlSpeed{ get{ return 2.00f; } }

		private MagicStaffEffect m_MagicStaffEffect;
		private int m_Charges;

		public virtual TimeSpan GetUseDelay{ get{ return TimeSpan.FromSeconds( 4.0 ); } }

		[CommandProperty( AccessLevel.GameMaster )]
		public MagicStaffEffect Effect
		{
			get{ return m_MagicStaffEffect; }
			set{ m_MagicStaffEffect = value; InvalidateProperties(); }
		}

		[CommandProperty( AccessLevel.GameMaster )]
		public int Charges
		{
			get{ return m_Charges; }
			set{ m_Charges = value; InvalidateProperties(); }
		}

		public BaseMagicStaff( MagicStaffEffect effect, int minCharges, int maxCharges ) : base( 0xDF2 )
		{
			Weight = 1.0;
			Effect = effect;
			Charges = Utility.RandomMinMax( minCharges, maxCharges );
			Attributes.SpellChanneling = 0;
			Resource = CraftResource.None;
			ItemID = Utility.RandomList( 0xDF2, 0xDF3, 0xDF4, 0xDF5, 0x639D, 0x639E, 0x639F, 0x63A0 );
		}

		public void ConsumeCharge( Mobile from )
		{
			--Charges;

			if ( Charges == 0 )
			{
				from.SendLocalizedMessage( 1019073 ); // This item is out of charges.
			}
		}

		public BaseMagicStaff( Serial serial ) : base( serial )
		{
		}

		public virtual void ApplyDelayTo( Mobile from )
		{
			from.BeginAction( typeof( BaseMagicStaff ) );
			Timer.DelayCall( GetUseDelay, new TimerStateCallback( ReleaseMagicStaffLock_Callback ), from );
		}

		public virtual void ReleaseMagicStaffLock_Callback( object state )
		{
			((Mobile)state).EndAction( typeof( BaseMagicStaff ) );
		}

		public override bool OnEquip( Mobile from )
		{
			this.Attributes.SpellChanneling = 0;
			return base.OnEquip( from );
		}

		public override void OnDoubleClick( Mobile from )
		{
			this.Attributes.SpellChanneling = 0;

			if ( !from.CanBeginAction( typeof( BaseMagicStaff ) ) )
				return;

			if ( Parent == from )
			{
				if ( Charges > 0 )
				{
					OnMagicStaffUse( from );
				}
			}
			else
			{
				from.SendLocalizedMessage( 502641 ); // You must equip this item to use it.
			}
		}

		public override void Serialize( GenericWriter writer )
		{
			base.Serialize( writer );
			writer.Write( (int) 0 ); // version
			writer.Write( (int) m_MagicStaffEffect );
			writer.Write( (int) m_Charges );
		}

		public override void Deserialize( GenericReader reader )
		{
			base.Deserialize( reader );
			int version = reader.ReadInt();
			switch ( version )
			{
				case 0:
				{
					m_MagicStaffEffect = (MagicStaffEffect)reader.ReadInt();
					m_Charges = (int)reader.ReadInt();

					break;
				}
			}
			Attributes.SpellChanneling = 0;
			Timer.DelayCall( TimeSpan.FromSeconds( 10.0 ), new TimerStateCallback( Cleanup ), this );
		}

		private void Cleanup( object state )
		{
			Item item = Wands( this );
			Server.Misc.Cleanup.DoCleanup( (Item)state, item );
		}

		public static Item Wands( Item item )
		{
			Item wand = null;

			if ( item is ClumsyMagicStaff ){ wand = new MagicalWand( 1001 ); }
			else if ( item is CreateFoodMagicStaff ){ wand = new MagicalWand( 1002 ); }
			else if ( item is FeebleMagicStaff ){ wand = new MagicalWand( 1003 ); }
			else if ( item is HealMagicStaff ){ wand = new MagicalWand( 1004 ); }
			else if ( item is MagicArrowMagicStaff ){ wand = new MagicalWand( 1005 ); }
			else if ( item is NightSightMagicStaff ){ wand = new MagicalWand( 1006 ); }
			else if ( item is ReactiveArmorMagicStaff ){ wand = new MagicalWand( 1007 ); }
			else if ( item is WeaknessMagicStaff ){ wand = new MagicalWand( 1008 ); }
			else if ( item is AgilityMagicStaff ){ wand = new MagicalWand( 1009 ); }
			else if ( item is CunningMagicStaff ){ wand = new MagicalWand( 1010 ); }
			else if ( item is CureMagicStaff ){ wand = new MagicalWand( 1011 ); }
			else if ( item is HarmMagicStaff ){ wand = new MagicalWand( 1012 ); }
			else if ( item is MagicTrapMagicStaff ){ wand = new MagicalWand( 1013 ); }
			else if ( item is MagicUntrapMagicStaff ){ wand = new MagicalWand( 1014 ); }
			else if ( item is ProtectionMagicStaff ){ wand = new MagicalWand( 1015 ); }
			else if ( item is StrengthMagicStaff ){ wand = new MagicalWand( 1016 ); }
			else if ( item is BlessMagicStaff ){ wand = new MagicalWand( 1017 ); }
			else if ( item is FireballMagicStaff ){ wand = new MagicalWand( 1018 ); }
			else if ( item is MagicLockMagicStaff ){ wand = new MagicalWand( 1019 ); }
			else if ( item is PoisonMagicStaff ){ wand = new MagicalWand( 1020 ); }
			else if ( item is TelekinesisMagicStaff ){ wand = new MagicalWand( 1021 ); }
			else if ( item is TeleportMagicStaff ){ wand = new MagicalWand( 1022 ); }
			else if ( item is MagicUnlockMagicStaff ){ wand = new MagicalWand( 1023 ); }
			else if ( item is WallofStoneMagicStaff ){ wand = new MagicalWand( 1024 ); }
			else if ( item is ArchCureMagicStaff ){ wand = new MagicalWand( 1025 ); }
			else if ( item is ArchProtectionMagicStaff ){ wand = new MagicalWand( 1026 ); }
			else if ( item is CurseMagicStaff ){ wand = new MagicalWand( 1027 ); }
			else if ( item is FireFieldMagicStaff ){ wand = new MagicalWand( 1028 ); }
			else if ( item is GreaterHealMagicStaff ){ wand = new MagicalWand( 1029 ); }
			else if ( item is LightningMagicStaff ){ wand = new MagicalWand( 1030 ); }
			else if ( item is ManaDrainMagicStaff ){ wand = new MagicalWand( 1031 ); }
			else if ( item is RecallMagicStaff ){ wand = new MagicalWand( 1032 ); }
			else if ( item is BladeSpiritsMagicStaff ){ wand = new MagicalWand( 1033 ); }
			else if ( item is DispelFieldMagicStaff ){ wand = new MagicalWand( 1034 ); }
			else if ( item is IncognitoMagicStaff ){ wand = new MagicalWand( 1035 ); }
			else if ( item is MagicReflectionMagicStaff ){ wand = new MagicalWand( 1036 ); }
			else if ( item is MindBlastMagicStaff ){ wand = new MagicalWand( 1037 ); }
			else if ( item is ParalyzeMagicStaff ){ wand = new MagicalWand( 1038 ); }
			else if ( item is PoisonFieldMagicStaff ){ wand = new MagicalWand( 1039 ); }
			else if ( item is SummonCreatureMagicStaff ){ wand = new MagicalWand( 1040 ); }
			else if ( item is DispelMagicStaff ){ wand = new MagicalWand( 1041 ); }
			else if ( item is EnergyBoltMagicStaff ){ wand = new MagicalWand( 1042 ); }
			else if ( item is ExplosionMagicStaff ){ wand = new MagicalWand( 1043 ); }
			else if ( item is InvisibilityMagicStaff ){ wand = new MagicalWand( 1044 ); }
			else if ( item is MarkMagicStaff ){ wand = new MagicalWand( 1045 ); }
			else if ( item is MassCurseMagicStaff ){ wand = new MagicalWand( 1046 ); }
			else if ( item is ParalyzeFieldMagicStaff ){ wand = new MagicalWand( 1047 ); }
			else if ( item is RevealMagicStaff ){ wand = new MagicalWand( 1048 ); }
			else if ( item is ChainLightningMagicStaff ){ wand = new MagicalWand( 1049 ); }
			else if ( item is EnergyFieldMagicStaff ){ wand = new MagicalWand( 1050 ); }
			else if ( item is FlameStrikeMagicStaff ){ wand = new MagicalWand( 1051 ); }
			else if ( item is GateTravelMagicStaff ){ wand = new MagicalWand( 1052 ); }
			else if ( item is ManaVampireMagicStaff ){ wand = new MagicalWand( 1053 ); }
			else if ( item is MassDispelMagicStaff ){ wand = new MagicalWand( 1054 ); }
			else if ( item is MeteorSwarmMagicStaff ){ wand = new MagicalWand( 1055 ); }
			else if ( item is PolymorphMagicStaff ){ wand = new MagicalWand( 1056 ); }
			else if ( item is EarthquakeMagicStaff ){ wand = new MagicalWand( 1057 ); }
			else if ( item is EnergyVortexMagicStaff ){ wand = new MagicalWand( 1058 ); }
			else if ( item is ResurrectionMagicStaff ){ wand = new MagicalWand( 1059 ); }
			else if ( item is AirElementalMagicStaff ){ wand = new MagicalWand( 1060 ); }
			else if ( item is SummonDaemonMagicStaff ){ wand = new MagicalWand( 1061 ); }
			else if ( item is EarthElementalMagicStaff ){ wand = new MagicalWand( 1062 ); }
			else if ( item is FireElementalMagicStaff ){ wand = new MagicalWand( 1063 ); }
			else { wand = new MagicalWand( 1064 ); }

			return wand;
		}

		public override void GetProperties( ObjectPropertyList list )
		{
			base.GetProperties( list );
			list.Add( 1060741, m_Charges.ToString() );
		}

		public override void OnSingleClick( Mobile from )
		{
			ArrayList attrs = new ArrayList();

			if ( DisplayLootType )
			{
				if ( LootType == LootType.Blessed )
					attrs.Add( new EquipInfoAttribute( 1038021 ) ); // blessed
				else if ( LootType == LootType.Cursed )
					attrs.Add( new EquipInfoAttribute( 1049643 ) ); // cursed
			}

			if ( !Identified )
			{
				attrs.Add( new EquipInfoAttribute( 1038000 ) ); // Unidentified
			}
			else
			{
				int num = 0;
				num = 1011296;
				if ( num > 0 )
					attrs.Add( new EquipInfoAttribute( num, m_Charges ) );
			}

			int number;

			if ( Name == null )
			{
				number = 1017085;
			}
			else
			{
				this.LabelTo( from, Name );
				number = 1041000;
			}

			if ( attrs.Count == 0 && BuiltBy == null && Name != null )
				return;

			EquipmentInfo eqInfo = new EquipmentInfo( number, BuiltBy, false, (EquipInfoAttribute[])attrs.ToArray( typeof( EquipInfoAttribute ) ) );

			from.Send( new DisplayEquipmentInfo( this, eqInfo ) );
		}

		public override bool OnDragLift( Mobile from )
		{
			if ( from is PlayerMobile )
			{
				from.SendMessage( "You cannot use a wand with a weapon equipped or while wearing pugilist gloves." );
			}

			return true;
		}

		public void Cast( Spell spell )
		{
			bool m = Movable;

			Movable = false;
			spell.Cast();
			Movable = m;
		}

		public virtual void OnMagicStaffUse( Mobile from )
		{
			from.Target = new MagicStaffTarget( this );
		}

		public virtual void DoMagicStaffTarget( Mobile from, object o )
		{
			if ( Deleted || Charges <= 0 || Parent != from || o is StaticTarget || o is LandTarget )
				return;
		}

		public virtual bool OnMagicStaffTarget( Mobile from, object o )
		{
			return true;
		}
	}
}