using System;
using Server;
using Server.Gumps;
using Server.Network;
using System.Collections;
using System.Collections.Generic;
using Server.Regions;

namespace Server.Items
{
	public class PowerScroll : SpecialScroll
	{
		public override int Message { get { return 1049469; } } /* using a scroll increases the maximum amount of a specific skill or your maximum statistics.
																* When used, the effect is not immediately seen without a gain of points with that skill or statistics.
																* You can view your maximum skill values in your skills window.
																* You can view your maximum statistic value in your statistics window. */
		public override string GetNameLocalized()
		{
			return Name;
		}

		public override string GetName()
		{			
			return Name;
		}

		public override string DefaultTitle{ get{ return Name; } }
		public override int Title{ get { return 0; } }

		private static SkillName[] m_Skills = new SkillName[]
			{
				SkillName.Blacksmith,
				SkillName.Tailoring,
				SkillName.Swords,
				SkillName.Fencing,
				SkillName.Bludgeoning,
				SkillName.Marksmanship,
				SkillName.FistFighting,
				SkillName.Parry,
				SkillName.Tactics,
				SkillName.Anatomy,
				SkillName.Healing,
				SkillName.Herding,
				SkillName.Magery,
				SkillName.Meditation,
				SkillName.Psychology,
				SkillName.MagicResist,
				SkillName.Taming,
				SkillName.Druidism,
				SkillName.Veterinary,
				SkillName.Musicianship,
				SkillName.Provocation,
				SkillName.Discordance,
				SkillName.Peacemaking
			};

		private static SkillName[] m_AOSSkills = new SkillName[]
			{
				SkillName.Knightship,
				SkillName.Focus,
				SkillName.Necromancy,
				SkillName.Stealing,
				SkillName.Stealth,
				SkillName.Spiritualism
			};

		private static SkillName[] m_SESkills = new SkillName[]
			{
				SkillName.Ninjitsu,
				SkillName.Bushido
			};
		
		private static List<SkillName> _Skills = new List<SkillName>();

		public static List<SkillName> Skills
		{ 
			get
			{
				if ( _Skills.Count == 0 )
				{
					_Skills.AddRange( m_Skills );
					if (Core.AOS)
					{
						_Skills.AddRange( m_AOSSkills );
						if (Core.SE)
						{
							_Skills.AddRange( m_SESkills );
							if (Core.ML)
								_Skills.Add( SkillName.Elementalism );
						}
					}
				}
				return _Skills;
			} 
		}

		public static PowerScroll CreateRandom( int min, int max )
		{
			min /= 5;
			max /= 5;
			
			return new PowerScroll( Skills[Utility.Random( Skills.Count )], 100 + ( Utility.RandomMinMax( min, max ) * 5 ) );
		}

		public static PowerScroll CreateRandomNoCraft( int min, int max )
		{
			min /= 5;
			max /= 5;
			
			SkillName skillName;

			do
			{
				skillName = Skills[Utility.Random( Skills.Count )];
			} while ( skillName == SkillName.Blacksmith || skillName == SkillName.Tailoring );

			return new PowerScroll( skillName, 100 + (Utility.RandomMinMax( min, max ) * 5));
		}

		public PowerScroll() : this( SkillName.Alchemy, 0.0 )
		{
		}
		
		[Constructable]
		public PowerScroll( SkillName skill, double value ) : base( skill, value )
		{
			Name = thisName( skill );
			LootType = LootType.Regular;
			Weight = 0;
			Hue = 0x481;
		}

		public PowerScroll( Serial serial ) : base( serial )
		{
		}

        public override void AddNameProperties(ObjectPropertyList list)
		{
            base.AddNameProperties(list);

			if ( GetPower() == 105 )
			{
				list.Add( 1070722, "105 Skill");
				list.Add( 1049644, "Wondrous Scroll");
			}
			else if ( GetPower() == 110 )
			{
				list.Add( 1070722, "110 Skill");
				list.Add( 1049644, "Exalted Scroll");
			}
			else if ( GetPower() == 115 )
			{
				list.Add( 1070722, "115 Skill");
				list.Add( 1049644, "Mythical Scroll");
			}
			else if ( GetPower() == 120 )
			{
				list.Add( 1070722, "120 Skill");
				list.Add( 1049644, "Legendary Scroll");
			}
			else if ( GetPower() == 125 )
			{
				list.Add( 1070722, "125 Skill");
				list.Add( 1049644, "Power Scroll");
			}
        }

		public override bool CanUse( Mobile from )
		{
			if ( !base.CanUse( from ) )
				return false;
			
			Skill skill = from.Skills[Skill];

			if ( skill == null )
				return false;
			
			if ( skill.Cap >= Value )
			{
				from.SendLocalizedMessage( 1049511, GetNameLocalized() ); // Your ~1_type~ is too high for this power scroll.
				return false;
			}

			if ( (
				( Skill == SkillName.FistFighting ) || 
				( Skill == SkillName.Bushido ) || 
				( Skill == SkillName.Swords ) || 
				( Skill == SkillName.Lumberjacking ) || 
				( Skill == SkillName.Mining ) || 
				( Skill == SkillName.Blacksmith ) || 
				( Skill == SkillName.Carpentry ) || 
				( Skill == SkillName.Bowcraft ) || 
				( Skill == SkillName.Bludgeoning ) || 
				( Skill == SkillName.Tactics ) || 
				( Skill == SkillName.Parry ) || 
				( Skill == SkillName.Fencing )
				) && ( !from.Region.IsPartOf( "Shrine of Strength" ) ) )
			{
				from.SendMessage( "This magic can only be unleashed at the Shrine of Strength." );
				return false;
			}

			if ( (
				( Skill == SkillName.Magery ) || 
				( Skill == SkillName.Elementalism ) || 
				( Skill == SkillName.MagicResist ) || 
				( Skill == SkillName.Meditation ) || 
				( Skill == SkillName.Necromancy ) || 
				( Skill == SkillName.ArmsLore ) || 
				( Skill == SkillName.Cartography ) || 
				( Skill == SkillName.Cooking ) || 
				( Skill == SkillName.Psychology ) || 
				( Skill == SkillName.Anatomy ) || 
				( Skill == SkillName.Alchemy ) || 
				( Skill == SkillName.Tailoring ) || 
				( Skill == SkillName.Tinkering ) || 
				( Skill == SkillName.Inscribe )
				) && ( !from.Region.IsPartOf( "Shrine of Intelligence" ) ) )
			{
				from.SendMessage( "This magic can only be unleashed at the Shrine of Intelligence." );
				return false;
			}

			if ( (
				( Skill == SkillName.Discordance ) || 
				( Skill == SkillName.Provocation ) || 
				( Skill == SkillName.Musicianship ) || 
				( Skill == SkillName.Marksmanship ) || 
				( Skill == SkillName.Hiding ) || 
				( Skill == SkillName.Stealing ) || 
				( Skill == SkillName.Stealth ) || 
				( Skill == SkillName.RemoveTrap ) || 
				( Skill == SkillName.Snooping ) || 
				( Skill == SkillName.Searching ) || 
				( Skill == SkillName.Ninjitsu ) || 
				( Skill == SkillName.Lockpicking )
				) && ( !from.Region.IsPartOf( "Shrine of Dexterity" ) ) )
			{
				from.SendMessage( "This magic can only be unleashed at the Shrine of Dexterity." );
				return false;
			}

			if ( (
				( Skill == SkillName.Spiritualism ) || 
				( Skill == SkillName.Knightship ) || 
				( Skill == SkillName.Peacemaking ) || 
				( Skill == SkillName.Tracking ) || 
				( Skill == SkillName.Veterinary ) || 
				( Skill == SkillName.Druidism ) || 
				( Skill == SkillName.Herding ) || 
				( Skill == SkillName.Taming ) || 
				( Skill == SkillName.Poisoning ) || 
				( Skill == SkillName.Focus ) || 
				( Skill == SkillName.Seafaring ) || 
				( Skill == SkillName.Healing )
				) && ( !from.Region.IsPartOf( "Shrine of Wisdom" ) ) )
			{
				from.SendMessage( "This magic can only be unleashed at the Shrine of Wisdom." );
				return false;
			}

			return true;
		}

		public override void Use( Mobile from )
		{
			if ( !CanUse( from ) )
				return;
			
			from.SendLocalizedMessage( 1049513, GetNameLocalized() ); // You feel a surge of magic as the scroll enhances your ~1_type~!

			from.Skills[Skill].Cap = Value;

			Effects.SendLocationParticles( EffectItem.Create( from.Location, from.Map, EffectItem.DefaultDuration ), 0, 0, 0, 0, 0, 5060, 0 );
			Effects.PlaySound( from.Location, from.Map, 0x243 );

			Effects.SendMovingParticles( new Entity( Serial.Zero, new Point3D( from.X - 6, from.Y - 6, from.Z + 15 ), from.Map ), from, 0x36D4, 7, 0, false, true, 0x497, 0, 9502, 1, 0, (EffectLayer)255, 0x100 );
			Effects.SendMovingParticles( new Entity( Serial.Zero, new Point3D( from.X - 4, from.Y - 6, from.Z + 15 ), from.Map ), from, 0x36D4, 7, 0, false, true, 0x497, 0, 9502, 1, 0, (EffectLayer)255, 0x100 );
			Effects.SendMovingParticles( new Entity( Serial.Zero, new Point3D( from.X - 6, from.Y - 4, from.Z + 15 ), from.Map ), from, 0x36D4, 7, 0, false, true, 0x497, 0, 9502, 1, 0, (EffectLayer)255, 0x100 );

			Effects.SendTargetParticles( from, 0x375A, 35, 90, 0x00, 0x00, 9502, (EffectLayer)255, 0x100 );

			Delete();
		}

		public override void Serialize( GenericWriter writer )
		{
			base.Serialize( writer );
			writer.Write( (int) 0 ); // version
		}

		public override void Deserialize( GenericReader reader )
		{
			base.Deserialize( reader );
			int version = ( InheritsItem ? 0 : reader.ReadInt() ); //Required for SpecialScroll insertion
		}

		public static Item RandomPowerScroll()
		{
			Item scroll = new DJ_SW_Alchemy(); scroll.Delete();

			int roll = Utility.RandomMinMax( 1, 100 );
			int choice = Utility.RandomMinMax( 1, 50 );
			int category = 1;

			if ( roll >= 95 ){ 		category = 5; }
			else if ( roll >= 85 ){ category = 4; }
			else if ( roll >= 70 ){ category = 3; }
			else if ( roll >= 50 ){ category = 2; }

			if ( category == 1 )
			{
				switch ( choice )
				{
					case 1: scroll = new DJ_SW_Alchemy(); break;
					case 2: scroll = new DJ_SW_Anatomy(); break;
					case 3: scroll = new DJ_SW_AnimalLore(); break;
					case 4: scroll = new DJ_SW_AnimalTaming(); break;
					case 5: scroll = new DJ_SW_Archery(); break;
					case 6: scroll = new DJ_SW_ArmsLore(); break;
					case 7: scroll = new DJ_SW_Blacksmith(); break;
					case 8: scroll = new DJ_SW_Bushido(); break;
					case 9: scroll = new DJ_SW_Carpentry(); break;
					case 10: scroll = new DJ_SW_Cartography(); break;
					case 11: scroll = new DJ_SW_Chivalry(); break;
					case 12: scroll = new DJ_SW_Cooking(); break;
					case 13: scroll = new DJ_SW_DetectHidden(); break;
					case 14: scroll = new DJ_SW_Discordance(); break;
					case 15: scroll = new DJ_SW_EvalInt(); break;
					case 16: scroll = new DJ_SW_Fencing(); break;
					case 17: scroll = new DJ_SW_Fishing(); break;
					case 18: scroll = new DJ_SW_Fletching(); break;
					case 19: scroll = new DJ_SW_Focus(); break;
					case 20: scroll = new DJ_SW_Healing(); break;
					case 21: scroll = new DJ_SW_Hiding(); break;
					case 22: scroll = new DJ_SW_Inscribe(); break;
					case 23: scroll = new DJ_SW_Lockpicking(); break;
					case 24: scroll = new DJ_SW_Lumberjacking(); break;
					case 25: scroll = new DJ_SW_Macing(); break;
					case 26: scroll = new DJ_SW_Magery(); break;
					case 27: scroll = new DJ_SW_MagicResist(); break;
					case 28: scroll = new DJ_SW_Meditation(); break;
					case 29: scroll = new DJ_SW_Mining(); break;
					case 30: scroll = new DJ_SW_Musicianship(); break;
					case 31: scroll = new DJ_SW_Necromancy(); break;
					case 32: scroll = new DJ_SW_Ninjitsu(); break;
					case 33: scroll = new DJ_SW_Parry(); break;
					case 34: scroll = new DJ_SW_Peacemaking(); break;
					case 35: scroll = new DJ_SW_Poisoning(); break;
					case 36: scroll = new DJ_SW_Provocation(); break;
					case 37: scroll = new DJ_SW_RemoveTrap(); break;
					case 38: scroll = new DJ_SW_Snooping(); break;
					case 39: scroll = new DJ_SW_Elementalism(); break;
					case 40: scroll = new DJ_SW_SpiritSpeak(); break;
					case 41: scroll = new DJ_SW_Stealing(); break;
					case 42: scroll = new DJ_SW_Stealth(); break;
					case 43: scroll = new DJ_SW_Swords(); break;
					case 44: scroll = new DJ_SW_Tactics(); break;
					case 45: scroll = new DJ_SW_Tailoring(); break;
					case 46: scroll = new DJ_SW_Tinkering(); break;
					case 47: scroll = new DJ_SW_Tracking(); break;
					case 48: scroll = new DJ_SW_Veterinary(); break;
					case 49: scroll = new DJ_SW_Wrestling(); break;
					case 50: scroll = new DJ_SW_Herding(); break;
				}
			}
			else if ( category == 2 )
			{
				switch ( choice )
				{
					case 1: scroll = new DJ_SE_Alchemy(); break;
					case 2: scroll = new DJ_SE_Anatomy(); break;
					case 3: scroll = new DJ_SE_AnimalLore(); break;
					case 4: scroll = new DJ_SE_AnimalTaming(); break;
					case 5: scroll = new DJ_SE_Archery(); break;
					case 6: scroll = new DJ_SE_ArmsLore(); break;
					case 7: scroll = new DJ_SE_Blacksmith(); break;
					case 8: scroll = new DJ_SE_Bushido(); break;
					case 9: scroll = new DJ_SE_Carpentry(); break;
					case 10: scroll = new DJ_SE_Cartography(); break;
					case 11: scroll = new DJ_SE_Chivalry(); break;
					case 12: scroll = new DJ_SE_Cooking(); break;
					case 13: scroll = new DJ_SE_DetectHidden(); break;
					case 14: scroll = new DJ_SE_Discordance(); break;
					case 15: scroll = new DJ_SE_EvalInt(); break;
					case 16: scroll = new DJ_SE_Fencing(); break;
					case 17: scroll = new DJ_SE_Fishing(); break;
					case 18: scroll = new DJ_SE_Fletching(); break;
					case 19: scroll = new DJ_SE_Focus(); break;
					case 20: scroll = new DJ_SE_Healing(); break;
					case 21: scroll = new DJ_SE_Hiding(); break;
					case 22: scroll = new DJ_SE_Inscribe(); break;
					case 23: scroll = new DJ_SE_Lockpicking(); break;
					case 24: scroll = new DJ_SE_Lumberjacking(); break;
					case 25: scroll = new DJ_SE_Macing(); break;
					case 26: scroll = new DJ_SE_Magery(); break;
					case 27: scroll = new DJ_SE_MagicResist(); break;
					case 28: scroll = new DJ_SE_Meditation(); break;
					case 29: scroll = new DJ_SE_Mining(); break;
					case 30: scroll = new DJ_SE_Musicianship(); break;
					case 31: scroll = new DJ_SE_Necromancy(); break;
					case 32: scroll = new DJ_SE_Ninjitsu(); break;
					case 33: scroll = new DJ_SE_Parry(); break;
					case 34: scroll = new DJ_SE_Peacemaking(); break;
					case 35: scroll = new DJ_SE_Poisoning(); break;
					case 36: scroll = new DJ_SE_Provocation(); break;
					case 37: scroll = new DJ_SE_RemoveTrap(); break;
					case 38: scroll = new DJ_SE_Snooping(); break;
					case 39: scroll = new DJ_SE_Elementalism(); break;
					case 40: scroll = new DJ_SE_SpiritSpeak(); break;
					case 41: scroll = new DJ_SE_Stealing(); break;
					case 42: scroll = new DJ_SE_Stealth(); break;
					case 43: scroll = new DJ_SE_Swords(); break;
					case 44: scroll = new DJ_SE_Tactics(); break;
					case 45: scroll = new DJ_SE_Tailoring(); break;
					case 46: scroll = new DJ_SE_Tinkering(); break;
					case 47: scroll = new DJ_SE_Tracking(); break;
					case 48: scroll = new DJ_SE_Veterinary(); break;
					case 49: scroll = new DJ_SE_Wrestling(); break;
					case 50: scroll = new DJ_SE_Herding(); break;
				}
			}
			else if ( category == 3 )
			{
				switch ( choice )
				{
					case 1: scroll = new DJ_SM_Alchemy(); break;
					case 2: scroll = new DJ_SM_Anatomy(); break;
					case 3: scroll = new DJ_SM_AnimalLore(); break;
					case 4: scroll = new DJ_SM_AnimalTaming(); break;
					case 5: scroll = new DJ_SM_Archery(); break;
					case 6: scroll = new DJ_SM_ArmsLore(); break;
					case 7: scroll = new DJ_SM_Blacksmith(); break;
					case 8: scroll = new DJ_SM_Bushido(); break;
					case 9: scroll = new DJ_SM_Carpentry(); break;
					case 10: scroll = new DJ_SM_Cartography(); break;
					case 11: scroll = new DJ_SM_Chivalry(); break;
					case 12: scroll = new DJ_SM_Cooking(); break;
					case 13: scroll = new DJ_SM_DetectHidden(); break;
					case 14: scroll = new DJ_SM_Discordance(); break;
					case 15: scroll = new DJ_SM_EvalInt(); break;
					case 16: scroll = new DJ_SM_Fencing(); break;
					case 17: scroll = new DJ_SM_Focus(); break;
					case 18: scroll = new DJ_SM_Fishing(); break;
					case 19: scroll = new DJ_SM_Fletching(); break;
					case 20: scroll = new DJ_SM_Healing(); break;
					case 21: scroll = new DJ_SM_Hiding(); break;
					case 22: scroll = new DJ_SM_Inscribe(); break;
					case 23: scroll = new DJ_SM_Lockpicking(); break;
					case 24: scroll = new DJ_SM_Lumberjacking(); break;
					case 25: scroll = new DJ_SM_Macing(); break;
					case 26: scroll = new DJ_SM_Magery(); break;
					case 27: scroll = new DJ_SM_MagicResist(); break;
					case 28: scroll = new DJ_SM_Meditation(); break;
					case 29: scroll = new DJ_SM_Mining(); break;
					case 30: scroll = new DJ_SM_Musicianship(); break;
					case 31: scroll = new DJ_SM_Necromancy(); break;
					case 32: scroll = new DJ_SM_Ninjitsu(); break;
					case 33: scroll = new DJ_SM_Parry(); break;
					case 34: scroll = new DJ_SM_Peacemaking(); break;
					case 35: scroll = new DJ_SM_Poisoning(); break;
					case 36: scroll = new DJ_SM_Provocation(); break;
					case 37: scroll = new DJ_SM_RemoveTrap(); break;
					case 38: scroll = new DJ_SM_Snooping(); break;
					case 39: scroll = new DJ_SM_Elementalism(); break;
					case 40: scroll = new DJ_SM_SpiritSpeak(); break;
					case 41: scroll = new DJ_SM_Stealing(); break;
					case 42: scroll = new DJ_SM_Stealth(); break;
					case 43: scroll = new DJ_SM_Swords(); break;
					case 44: scroll = new DJ_SM_Tactics(); break;
					case 45: scroll = new DJ_SM_Tailoring(); break;
					case 46: scroll = new DJ_SM_Tinkering(); break;
					case 47: scroll = new DJ_SM_Tracking(); break;
					case 48: scroll = new DJ_SM_Veterinary(); break;
					case 49: scroll = new DJ_SM_Wrestling(); break;
					case 50: scroll = new DJ_SM_Herding(); break;
				}
			}
			else if ( category == 4 )
			{
				switch ( choice )
				{
					case 1: scroll = new DJ_SL_Alchemy(); break;
					case 2: scroll = new DJ_SL_Anatomy(); break;
					case 3: scroll = new DJ_SL_AnimalLore(); break;
					case 4: scroll = new DJ_SL_AnimalTaming(); break;
					case 5: scroll = new DJ_SL_Archery(); break;
					case 6: scroll = new DJ_SL_ArmsLore(); break;
					case 7: scroll = new DJ_SL_Blacksmith(); break;
					case 8: scroll = new DJ_SL_Bushido(); break;
					case 9: scroll = new DJ_SL_Carpentry(); break;
					case 10: scroll = new DJ_SL_Cartography(); break;
					case 11: scroll = new DJ_SL_Chivalry(); break;
					case 12: scroll = new DJ_SL_Cooking(); break;
					case 13: scroll = new DJ_SL_DetectHidden(); break;
					case 14: scroll = new DJ_SL_Discordance(); break;
					case 15: scroll = new DJ_SL_EvalInt(); break;
					case 16: scroll = new DJ_SL_Fencing(); break;
					case 17: scroll = new DJ_SL_Fishing(); break;
					case 18: scroll = new DJ_SL_Fletching(); break;
					case 19: scroll = new DJ_SL_Focus(); break;
					case 20: scroll = new DJ_SL_Healing(); break;
					case 21: scroll = new DJ_SL_Hiding(); break;
					case 22: scroll = new DJ_SL_Inscribe(); break;
					case 23: scroll = new DJ_SL_Lockpicking(); break;
					case 24: scroll = new DJ_SL_Lumberjacking(); break;
					case 25: scroll = new DJ_SL_Macing(); break;
					case 26: scroll = new DJ_SL_Magery(); break;
					case 27: scroll = new DJ_SL_MagicResist(); break;
					case 28: scroll = new DJ_SL_Meditation(); break;
					case 29: scroll = new DJ_SL_Mining(); break;
					case 30: scroll = new DJ_SL_Musicianship(); break;
					case 31: scroll = new DJ_SL_Necromancy(); break;
					case 32: scroll = new DJ_SL_Ninjitsu(); break;
					case 33: scroll = new DJ_SL_Parry(); break;
					case 34: scroll = new DJ_SL_Peacemaking(); break;
					case 35: scroll = new DJ_SL_Poisoning(); break;
					case 36: scroll = new DJ_SL_Provocation(); break;
					case 37: scroll = new DJ_SL_RemoveTrap(); break;
					case 38: scroll = new DJ_SL_Snooping(); break;
					case 39: scroll = new DJ_SL_Elementalism(); break;
					case 40: scroll = new DJ_SL_SpiritSpeak(); break;
					case 41: scroll = new DJ_SL_Stealing(); break;
					case 42: scroll = new DJ_SL_Stealth(); break;
					case 43: scroll = new DJ_SL_Swords(); break;
					case 44: scroll = new DJ_SL_Tactics(); break;
					case 45: scroll = new DJ_SL_Tailoring(); break;
					case 46: scroll = new DJ_SL_Tinkering(); break;
					case 47: scroll = new DJ_SL_Tracking(); break;
					case 48: scroll = new DJ_SL_Veterinary(); break;
					case 49: scroll = new DJ_SL_Wrestling(); break;
					case 50: scroll = new DJ_SL_Herding(); break;
				}
			}
			else
			{
				switch ( choice )
				{
					case 1: scroll = new DJ_SP_Alchemy(); break;
					case 2: scroll = new DJ_SP_Anatomy(); break;
					case 3: scroll = new DJ_SP_AnimalLore(); break;
					case 4: scroll = new DJ_SP_AnimalTaming(); break;
					case 5: scroll = new DJ_SP_Archery(); break;
					case 6: scroll = new DJ_SP_ArmsLore(); break;
					case 7: scroll = new DJ_SP_Blacksmith(); break;
					case 8: scroll = new DJ_SP_Bushido(); break;
					case 9: scroll = new DJ_SP_Carpentry(); break;
					case 10: scroll = new DJ_SP_Cartography(); break;
					case 11: scroll = new DJ_SP_Chivalry(); break;
					case 12: scroll = new DJ_SP_Cooking(); break;
					case 13: scroll = new DJ_SP_DetectHidden(); break;
					case 14: scroll = new DJ_SP_Discordance(); break;
					case 15: scroll = new DJ_SP_EvalInt(); break;
					case 16: scroll = new DJ_SP_Fencing(); break;
					case 17: scroll = new DJ_SP_Fishing(); break;
					case 18: scroll = new DJ_SP_Fletching(); break;
					case 19: scroll = new DJ_SP_Focus(); break;
					case 20: scroll = new DJ_SP_Healing(); break;
					case 21: scroll = new DJ_SP_Hiding(); break;
					case 22: scroll = new DJ_SP_Inscribe(); break;
					case 23: scroll = new DJ_SP_Lockpicking(); break;
					case 24: scroll = new DJ_SP_Lumberjacking(); break;
					case 25: scroll = new DJ_SP_Macing(); break;
					case 26: scroll = new DJ_SP_Magery(); break;
					case 27: scroll = new DJ_SP_MagicResist(); break;
					case 28: scroll = new DJ_SP_Meditation(); break;
					case 29: scroll = new DJ_SP_Mining(); break;
					case 30: scroll = new DJ_SP_Musicianship(); break;
					case 31: scroll = new DJ_SP_Necromancy(); break;
					case 32: scroll = new DJ_SP_Ninjitsu(); break;
					case 33: scroll = new DJ_SP_Parry(); break;
					case 34: scroll = new DJ_SP_Peacemaking(); break;
					case 35: scroll = new DJ_SP_Poisoning(); break;
					case 36: scroll = new DJ_SP_Provocation(); break;
					case 37: scroll = new DJ_SP_RemoveTrap(); break;
					case 38: scroll = new DJ_SP_Snooping(); break;
					case 39: scroll = new DJ_SP_Elementalism(); break;
					case 40: scroll = new DJ_SP_SpiritSpeak(); break;
					case 41: scroll = new DJ_SP_Stealing(); break;
					case 42: scroll = new DJ_SP_Stealth(); break;
					case 43: scroll = new DJ_SP_Swords(); break;
					case 44: scroll = new DJ_SP_Tactics(); break;
					case 45: scroll = new DJ_SP_Tailoring(); break;
					case 46: scroll = new DJ_SP_Tinkering(); break;
					case 47: scroll = new DJ_SP_Tracking(); break;
					case 48: scroll = new DJ_SP_Veterinary(); break;
					case 49: scroll = new DJ_SP_Wrestling(); break;
					case 50: scroll = new DJ_SP_Herding(); break;
				}
			}
			return scroll;
		}


		public int GetPower()
		{
			if ( 
			this is DJ_SW_Alchemy || 
			this is DJ_SW_Anatomy || 
			this is DJ_SW_AnimalLore || 
			this is DJ_SW_AnimalTaming || 
			this is DJ_SW_Archery || 
			this is DJ_SW_ArmsLore || 
			this is DJ_SW_Blacksmith || 
			this is DJ_SW_Bushido || 
			this is DJ_SW_Carpentry || 
			this is DJ_SW_Cartography || 
			this is DJ_SW_Chivalry || 
			this is DJ_SW_Cooking || 
			this is DJ_SW_DetectHidden || 
			this is DJ_SW_Discordance || 
			this is DJ_SW_EvalInt || 
			this is DJ_SW_Fencing || 
			this is DJ_SW_Fishing || 
			this is DJ_SW_Fletching || 
			this is DJ_SW_Focus || 
			this is DJ_SW_Healing || 
			this is DJ_SW_Hiding || 
			this is DJ_SW_Inscribe || 
			this is DJ_SW_Lockpicking || 
			this is DJ_SW_Lumberjacking || 
			this is DJ_SW_Macing || 
			this is DJ_SW_Magery || 
			this is DJ_SW_MagicResist || 
			this is DJ_SW_Meditation || 
			this is DJ_SW_Mining || 
			this is DJ_SW_Musicianship || 
			this is DJ_SW_Necromancy || 
			this is DJ_SW_Ninjitsu || 
			this is DJ_SW_Parry || 
			this is DJ_SW_Peacemaking || 
			this is DJ_SW_Poisoning || 
			this is DJ_SW_Provocation || 
			this is DJ_SW_RemoveTrap || 
			this is DJ_SW_Snooping || 
			this is DJ_SW_Elementalism || 
			this is DJ_SW_SpiritSpeak || 
			this is DJ_SW_Stealing || 
			this is DJ_SW_Stealth || 
			this is DJ_SW_Swords || 
			this is DJ_SW_Tactics || 
			this is DJ_SW_Tailoring || 
			this is DJ_SW_Tinkering || 
			this is DJ_SW_Tracking || 
			this is DJ_SW_Veterinary || 
			this is DJ_SW_Wrestling || 
			this is DJ_SW_Herding ){ return 105; }
			else if ( 
			this is DJ_SE_Alchemy || 
			this is DJ_SE_Anatomy || 
			this is DJ_SE_AnimalLore || 
			this is DJ_SE_AnimalTaming || 
			this is DJ_SE_Archery || 
			this is DJ_SE_ArmsLore || 
			this is DJ_SE_Blacksmith || 
			this is DJ_SE_Bushido || 
			this is DJ_SE_Carpentry || 
			this is DJ_SE_Cartography || 
			this is DJ_SE_Chivalry || 
			this is DJ_SE_Cooking || 
			this is DJ_SE_DetectHidden || 
			this is DJ_SE_Discordance || 
			this is DJ_SE_EvalInt || 
			this is DJ_SE_Fencing || 
			this is DJ_SE_Fishing || 
			this is DJ_SE_Fletching || 
			this is DJ_SE_Focus || 
			this is DJ_SE_Healing || 
			this is DJ_SE_Hiding || 
			this is DJ_SE_Inscribe || 
			this is DJ_SE_Lockpicking || 
			this is DJ_SE_Lumberjacking || 
			this is DJ_SE_Macing || 
			this is DJ_SE_Magery || 
			this is DJ_SE_MagicResist || 
			this is DJ_SE_Meditation || 
			this is DJ_SE_Mining || 
			this is DJ_SE_Musicianship || 
			this is DJ_SE_Necromancy || 
			this is DJ_SE_Ninjitsu || 
			this is DJ_SE_Parry || 
			this is DJ_SE_Peacemaking || 
			this is DJ_SE_Poisoning || 
			this is DJ_SE_Provocation || 
			this is DJ_SE_RemoveTrap || 
			this is DJ_SE_Snooping || 
			this is DJ_SE_Elementalism || 
			this is DJ_SE_SpiritSpeak || 
			this is DJ_SE_Stealing || 
			this is DJ_SE_Stealth || 
			this is DJ_SE_Swords || 
			this is DJ_SE_Tactics || 
			this is DJ_SE_Tailoring || 
			this is DJ_SE_Tinkering || 
			this is DJ_SE_Tracking || 
			this is DJ_SE_Veterinary || 
			this is DJ_SE_Wrestling || 
			this is DJ_SE_Herding ){ return 110; }
			else if ( 
			this is DJ_SM_Alchemy || 
			this is DJ_SM_Anatomy || 
			this is DJ_SM_AnimalLore || 
			this is DJ_SM_AnimalTaming || 
			this is DJ_SM_Archery || 
			this is DJ_SM_ArmsLore || 
			this is DJ_SM_Blacksmith || 
			this is DJ_SM_Bushido || 
			this is DJ_SM_Carpentry || 
			this is DJ_SM_Cartography || 
			this is DJ_SM_Chivalry || 
			this is DJ_SM_Cooking || 
			this is DJ_SM_DetectHidden || 
			this is DJ_SM_Discordance || 
			this is DJ_SM_EvalInt || 
			this is DJ_SM_Fencing || 
			this is DJ_SM_Focus || 
			this is DJ_SM_Fishing || 
			this is DJ_SM_Fletching || 
			this is DJ_SM_Healing || 
			this is DJ_SM_Hiding || 
			this is DJ_SM_Inscribe || 
			this is DJ_SM_Lockpicking || 
			this is DJ_SM_Lumberjacking || 
			this is DJ_SM_Macing || 
			this is DJ_SM_Magery || 
			this is DJ_SM_MagicResist || 
			this is DJ_SM_Meditation || 
			this is DJ_SM_Mining || 
			this is DJ_SM_Musicianship || 
			this is DJ_SM_Necromancy || 
			this is DJ_SM_Ninjitsu || 
			this is DJ_SM_Parry || 
			this is DJ_SM_Peacemaking || 
			this is DJ_SM_Poisoning || 
			this is DJ_SM_Provocation || 
			this is DJ_SM_RemoveTrap || 
			this is DJ_SM_Snooping || 
			this is DJ_SM_Elementalism || 
			this is DJ_SM_SpiritSpeak || 
			this is DJ_SM_Stealing || 
			this is DJ_SM_Stealth || 
			this is DJ_SM_Swords || 
			this is DJ_SM_Tactics || 
			this is DJ_SM_Tailoring || 
			this is DJ_SM_Tinkering || 
			this is DJ_SM_Tracking || 
			this is DJ_SM_Veterinary || 
			this is DJ_SM_Wrestling || 
			this is DJ_SM_Herding ){ return 115; }
			else if ( 
			this is DJ_SL_Alchemy || 
			this is DJ_SL_Anatomy || 
			this is DJ_SL_AnimalLore || 
			this is DJ_SL_AnimalTaming || 
			this is DJ_SL_Archery || 
			this is DJ_SL_ArmsLore || 
			this is DJ_SL_Blacksmith || 
			this is DJ_SL_Bushido || 
			this is DJ_SL_Carpentry || 
			this is DJ_SL_Cartography || 
			this is DJ_SL_Chivalry || 
			this is DJ_SL_Cooking || 
			this is DJ_SL_DetectHidden || 
			this is DJ_SL_Discordance || 
			this is DJ_SL_EvalInt || 
			this is DJ_SL_Fencing || 
			this is DJ_SL_Fishing || 
			this is DJ_SL_Fletching || 
			this is DJ_SL_Focus || 
			this is DJ_SL_Healing || 
			this is DJ_SL_Hiding || 
			this is DJ_SL_Inscribe || 
			this is DJ_SL_Lockpicking || 
			this is DJ_SL_Lumberjacking || 
			this is DJ_SL_Macing || 
			this is DJ_SL_Magery || 
			this is DJ_SL_MagicResist || 
			this is DJ_SL_Meditation || 
			this is DJ_SL_Mining || 
			this is DJ_SL_Musicianship || 
			this is DJ_SL_Necromancy || 
			this is DJ_SL_Ninjitsu || 
			this is DJ_SL_Parry || 
			this is DJ_SL_Peacemaking || 
			this is DJ_SL_Poisoning || 
			this is DJ_SL_Provocation || 
			this is DJ_SL_RemoveTrap || 
			this is DJ_SL_Snooping || 
			this is DJ_SL_Elementalism || 
			this is DJ_SL_SpiritSpeak || 
			this is DJ_SL_Stealing || 
			this is DJ_SL_Stealth || 
			this is DJ_SL_Swords || 
			this is DJ_SL_Tactics || 
			this is DJ_SL_Tailoring || 
			this is DJ_SL_Tinkering || 
			this is DJ_SL_Tracking || 
			this is DJ_SL_Veterinary || 
			this is DJ_SL_Wrestling || 
			this is DJ_SL_Herding ){ return 120; }
			else if ( 
			this is DJ_SP_Alchemy || 
			this is DJ_SP_Anatomy || 
			this is DJ_SP_AnimalLore || 
			this is DJ_SP_AnimalTaming || 
			this is DJ_SP_Archery || 
			this is DJ_SP_ArmsLore || 
			this is DJ_SP_Blacksmith || 
			this is DJ_SP_Bushido || 
			this is DJ_SP_Carpentry || 
			this is DJ_SP_Cartography || 
			this is DJ_SP_Chivalry || 
			this is DJ_SP_Cooking || 
			this is DJ_SP_DetectHidden || 
			this is DJ_SP_Discordance || 
			this is DJ_SP_EvalInt || 
			this is DJ_SP_Fencing || 
			this is DJ_SP_Fishing || 
			this is DJ_SP_Fletching || 
			this is DJ_SP_Focus || 
			this is DJ_SP_Healing || 
			this is DJ_SP_Hiding || 
			this is DJ_SP_Inscribe || 
			this is DJ_SP_Lockpicking || 
			this is DJ_SP_Lumberjacking || 
			this is DJ_SP_Macing || 
			this is DJ_SP_Magery || 
			this is DJ_SP_MagicResist || 
			this is DJ_SP_Meditation || 
			this is DJ_SP_Mining || 
			this is DJ_SP_Musicianship || 
			this is DJ_SP_Necromancy || 
			this is DJ_SP_Ninjitsu || 
			this is DJ_SP_Parry || 
			this is DJ_SP_Peacemaking || 
			this is DJ_SP_Poisoning || 
			this is DJ_SP_Provocation || 
			this is DJ_SP_RemoveTrap || 
			this is DJ_SP_Snooping || 
			this is DJ_SP_Elementalism || 
			this is DJ_SP_SpiritSpeak || 
			this is DJ_SP_Stealing || 
			this is DJ_SP_Stealth || 
			this is DJ_SP_Swords || 
			this is DJ_SP_Tactics || 
			this is DJ_SP_Tailoring || 
			this is DJ_SP_Tinkering || 
			this is DJ_SP_Tracking || 
			this is DJ_SP_Veterinary || 
			this is DJ_SP_Wrestling || 
			this is DJ_SP_Herding ){ return 125; }

			return (int)Value;
		}

		public string thisName( SkillName skill )
		{
			string txt = "";

			if ( skill == SkillName.Alchemy ){ txt = "Alchemy"; }
			else if ( skill == SkillName.Anatomy ){ txt = "Anatomy"; }
			else if ( skill == SkillName.Druidism ){ txt = "Druidism"; }
			else if ( skill == SkillName.Mercantile ){ txt = "Mercantile"; }
			else if ( skill == SkillName.ArmsLore ){ txt = "Arms Lore"; }
			else if ( skill == SkillName.Parry ){ txt = "Parrying"; }
			else if ( skill == SkillName.Begging ){ txt = "Begging"; }
			else if ( skill == SkillName.Blacksmith ){ txt = "Blacksmithing"; }
			else if ( skill == SkillName.Bowcraft ){ txt = "Bowcrafting"; }
			else if ( skill == SkillName.Peacemaking ){ txt = "Peacemaking"; }
			else if ( skill == SkillName.Camping ){ txt = "Camping"; }
			else if ( skill == SkillName.Carpentry ){ txt = "Carpentry"; }
			else if ( skill == SkillName.Cartography ){ txt = "Cartography"; }
			else if ( skill == SkillName.Cooking ){ txt = "Cooking"; }
			else if ( skill == SkillName.Searching ){ txt = "Searching"; }
			else if ( skill == SkillName.Discordance ){ txt = "Discordance"; }
			else if ( skill == SkillName.Psychology ){ txt = "Psychology"; }
			else if ( skill == SkillName.Healing ){ txt = "Healing"; }
			else if ( skill == SkillName.Seafaring ){ txt = "Seafaring"; }
			else if ( skill == SkillName.Forensics ){ txt = "Forensics"; }
			else if ( skill == SkillName.Herding ){ txt = "Herding"; }
			else if ( skill == SkillName.Hiding ){ txt = "Hiding"; }
			else if ( skill == SkillName.Provocation ){ txt = "Provocation"; }
			else if ( skill == SkillName.Inscribe ){ txt = "Inscription"; }
			else if ( skill == SkillName.Lockpicking ){ txt = "Lockpicking"; }
			else if ( skill == SkillName.Magery ){ txt = "Magery"; }
			else if ( skill == SkillName.MagicResist ){ txt = "Magic Resist"; }
			else if ( skill == SkillName.Tactics ){ txt = "Tactics"; }
			else if ( skill == SkillName.Snooping ){ txt = "Snooping"; }
			else if ( skill == SkillName.Musicianship ){ txt = "Musicianship"; }
			else if ( skill == SkillName.Poisoning ){ txt = "Poisoning"; }
			else if ( skill == SkillName.Marksmanship ){ txt = "Marksmanship"; }
			else if ( skill == SkillName.Spiritualism ){ txt = "Spiritualism"; }
			else if ( skill == SkillName.Stealing ){ txt = "Stealing"; }
			else if ( skill == SkillName.Tailoring ){ txt = "Tailoring"; }
			else if ( skill == SkillName.Taming ){ txt = "Taming"; }
			else if ( skill == SkillName.Tasting ){ txt = "Tasting"; }
			else if ( skill == SkillName.Tinkering ){ txt = "Tinkering"; }
			else if ( skill == SkillName.Tracking ){ txt = "Tracking"; }
			else if ( skill == SkillName.Veterinary ){ txt = "Veterinary"; }
			else if ( skill == SkillName.Swords ){ txt = "Swords"; }
			else if ( skill == SkillName.Bludgeoning ){ txt = "Macing"; }
			else if ( skill == SkillName.Fencing ){ txt = "Fencing"; }
			else if ( skill == SkillName.FistFighting ){ txt = "Fist Fighting"; }
			else if ( skill == SkillName.Lumberjacking ){ txt = "Lumberjacking"; }
			else if ( skill == SkillName.Mining ){ txt = "Mining"; }
			else if ( skill == SkillName.Meditation ){ txt = "Meditation"; }
			else if ( skill == SkillName.Stealth ){ txt = "Stealth"; }
			else if ( skill == SkillName.RemoveTrap ){ txt = "Remove Traps"; }
			else if ( skill == SkillName.Necromancy ){ txt = "Necromancy"; }
			else if ( skill == SkillName.Focus ){ txt = "Focus"; }
			else if ( skill == SkillName.Knightship ){ txt = "Knightship"; }
			else if ( skill == SkillName.Bushido ){ txt = "Bushido"; }
			else if ( skill == SkillName.Ninjitsu ){ txt = "Ninjitsu"; }
			else if ( skill == SkillName.Elementalism ){ txt = "Elementalism"; }
			else if ( skill == SkillName.Mysticism ){ txt = "Mysticism"; }
			else if ( skill == SkillName.Imbuing ){ txt = "Imbuing"; }
			else if ( skill == SkillName.Throwing ){ txt = "Throwing"; }

			return txt;
		}
	}
}