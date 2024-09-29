using System;
using Server;
using Server.Gumps;
using Server.Network;

namespace Server.Items
{
	public abstract class SpecialScroll : Item
	{
		private SkillName m_Skill;
		private double m_Value;
		
		#region Old Item Serialization Vars
		/* DO NOT USE! Only used in serialization of special scrolls that originally derived from Item */
		private bool m_InheritsItem;
		
		protected bool InheritsItem
		{ 
			get{ return m_InheritsItem; } 
		}
		#endregion
		
		public abstract int Message{ get; }
		public virtual int Title{ get { return 0; } }
		public abstract string DefaultTitle{ get; }

		public SpecialScroll( SkillName skill, double value ) : base( 0x14F0 )
		{
			Weight = 1.0;
			m_Skill = skill;
			m_Value = value;
			LootType = LootType.Regular;
		}

		public SpecialScroll( Serial serial ) : base( serial )
		{
		}

		[CommandProperty( AccessLevel.GameMaster )]
		public SkillName Skill
		{
			get { return m_Skill; }
			set { m_Skill = value; }
		}

		[CommandProperty( AccessLevel.GameMaster )]
		public double Value
		{
			get { return m_Value; }
			set { m_Value = value; }
		}

		public static SkillName ScrollSkill( int skill )
		{
			// CHANGE THIS RANGE IF YOU EVER ADD SOME NEW SKILLS
			if ( skill < 1 ){ skill = Utility.RandomMinMax( 1, 55 ); }

			if ( skill == 1 ){ return SkillName.Alchemy; }
			else if ( skill == 2 ){ return SkillName.Anatomy; }
			else if ( skill == 3 ){ return SkillName.Druidism; }
			else if ( skill == 4 ){ return SkillName.Mercantile; }
			else if ( skill == 5 ){ return SkillName.ArmsLore; }
			else if ( skill == 6 ){ return SkillName.Parry; }
			else if ( skill == 7 ){ return SkillName.Begging; }
			else if ( skill == 8 ){ return SkillName.Blacksmith; }
			else if ( skill == 9 ){ return SkillName.Bowcraft; }
			else if ( skill == 10 ){ return SkillName.Peacemaking; }
			else if ( skill == 11 ){ return SkillName.Camping; }
			else if ( skill == 12 ){ return SkillName.Carpentry; }
			else if ( skill == 13 ){ return SkillName.Cartography; }
			else if ( skill == 14 ){ return SkillName.Cooking; }
			else if ( skill == 15 ){ return SkillName.Searching; }
			else if ( skill == 16 ){ return SkillName.Discordance; }
			else if ( skill == 17 ){ return SkillName.Psychology; }
			else if ( skill == 18 ){ return SkillName.Healing; }
			else if ( skill == 19 ){ return SkillName.Seafaring; }
			else if ( skill == 20 ){ return SkillName.Forensics; }
			else if ( skill == 21 ){ return SkillName.Herding; }
			else if ( skill == 22 ){ return SkillName.Hiding; }
			else if ( skill == 23 ){ return SkillName.Provocation; }
			else if ( skill == 24 ){ return SkillName.Inscribe; }
			else if ( skill == 25 ){ return SkillName.Lockpicking; }
			else if ( skill == 26 ){ return SkillName.Magery; }
			else if ( skill == 27 ){ return SkillName.MagicResist; }
			else if ( skill == 28 ){ return SkillName.Tactics; }
			else if ( skill == 29 ){ return SkillName.Snooping; }
			else if ( skill == 30 ){ return SkillName.Musicianship; }
			else if ( skill == 31 ){ return SkillName.Poisoning; }
			else if ( skill == 32 ){ return SkillName.Marksmanship; }
			else if ( skill == 33 ){ return SkillName.Spiritualism; }
			else if ( skill == 34 ){ return SkillName.Stealing; }
			else if ( skill == 35 ){ return SkillName.Tailoring; }
			else if ( skill == 36 ){ return SkillName.Taming; }
			else if ( skill == 37 ){ return SkillName.Tasting; }
			else if ( skill == 38 ){ return SkillName.Tinkering; }
			else if ( skill == 39 ){ return SkillName.Tracking; }
			else if ( skill == 40 ){ return SkillName.Veterinary; }
			else if ( skill == 41 ){ return SkillName.Swords; }
			else if ( skill == 42 ){ return SkillName.Bludgeoning; }
			else if ( skill == 43 ){ return SkillName.Fencing; }
			else if ( skill == 44 ){ return SkillName.FistFighting; }
			else if ( skill == 45 ){ return SkillName.Lumberjacking; }
			else if ( skill == 46 ){ return SkillName.Mining; }
			else if ( skill == 47 ){ return SkillName.Meditation; }
			else if ( skill == 48 ){ return SkillName.Stealth; }
			else if ( skill == 49 ){ return SkillName.RemoveTrap; }
			else if ( skill == 50 ){ return SkillName.Necromancy; }
			else if ( skill == 51 ){ return SkillName.Focus; }
			else if ( skill == 52 ){ return SkillName.Knightship; }
			else if ( skill == 53 ){ return SkillName.Bushido; }
			else if ( skill == 54 ){ return SkillName.Ninjitsu; }
			else if ( skill == 55 ){ return SkillName.Elementalism; }
			else if ( skill == 56 ){ return SkillName.Mysticism; }
			else if ( skill == 57 ){ return SkillName.Imbuing; }
			else if ( skill == 58 ){ return SkillName.Throwing; }

			return SkillName.Alchemy;
		}

		public virtual string GetNameLocalized()
		{
			return String.Concat( "#", (1044060 + (int)m_Skill).ToString() );
		}

		public virtual string GetName()
		{			
			int index = (int)m_Skill;
			SkillInfo[] table = SkillInfo.Table;

			if ( index >= 0 && index < table.Length )
				return table[index].Name.ToLower();
			else
				return "???";
		}
		
		public virtual bool CanUse( Mobile from )
		{
			if ( Deleted )
				return false;
			
			if ( !IsChildOf( from.Backpack ) )
			{
				from.SendLocalizedMessage(1042001); // That must be in your pack for you to use it.
				return false;
			}
			
			return true;
		}

		public virtual void Use( Mobile from )
		{
		}

		public override void OnDoubleClick( Mobile from )
		{
			if ( !CanUse( from ) )
				return;
			
			from.CloseGump( typeof( SpecialScroll.InternalGump ) );
			from.SendGump( new InternalGump( from, this ) );
		}

		public override void Serialize( GenericWriter writer )
		{
			base.Serialize( writer );

			writer.Write( (int) 1 ); // version

			writer.Write( (int) m_Skill );
			writer.Write( (double) m_Value );
		}

		public override void Deserialize( GenericReader reader )
		{
			base.Deserialize( reader );

			int version = reader.ReadInt();

			switch ( version )
			{
				case 1:
				{
					m_Skill = (SkillName)reader.ReadInt();
					m_Value = reader.ReadDouble();
					break;
				}
				case 0:
				{
					m_InheritsItem = true;
					m_Skill = (SkillName)reader.ReadInt();
					m_Value = reader.ReadDouble();

					break;
				}
			}
		}

		public class InternalGump : Gump
		{
			private Mobile m_Mobile;
			private SpecialScroll m_Scroll;

			public InternalGump( Mobile mobile, SpecialScroll scroll ) : base( 50, 50 )
			{
				string color = "#FFFFFF";
				m_Mobile = mobile;
				m_Scroll = scroll;
				int o = 70;
				int i = 157;

				if ( scroll is PowerScroll ){ o = 40; i = 197; }

				AddPage( 0 );

				AddImage(0, 0, 9577, Server.Misc.PlayerSettings.GetGumpHue( mobile ));

				AddHtmlLocalized( 11, o, 286, i, m_Scroll.Message, 0xFFFFFF, false, false );

				if ( m_Scroll.Title != 0 )
					AddHtmlLocalized( 11, 10, 286, 20, m_Scroll.Title, 0xFFFFFF, false, false );
				else
					AddHtml( 11, 10, 286, 20, "<BODY><BASEFONT Color=" + color + ">" + m_Scroll.DefaultTitle + "</BASEFONT></BODY>", false, false );

				AddHtml( 49, 237, 210, 20, @"<BODY><BASEFONT Color=" + color + "><CENTER>Do you want to use this?</CENTER></BASEFONT></BODY>", (bool)false, (bool)false);

				if ( !(scroll is PowerScroll ) ){ AddHtmlLocalized( 11, 40, 286, 20, 1044060 + (int)m_Scroll.Skill, 0xFFFFFF, false, false ); }

				AddButton(10, 236, 4023, 4023, 1, GumpButtonType.Reply, 0);
				AddButton(268, 236, 4020, 4020, 0, GumpButtonType.Reply, 0);
			}

			public override void OnResponse( NetState state, RelayInfo info )
			{
				if ( info.ButtonID == 1 )
					m_Scroll.Use( m_Mobile );
			}
		}
	}
}
