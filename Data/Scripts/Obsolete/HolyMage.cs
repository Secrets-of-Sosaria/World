using System;
using System.Collections.Generic;
using Server;
using Server.Targeting;
using Server.Items;
using Server.Network;
using Server.ContextMenus;
using Server.Gumps;
using Server.Misc;
using Server.Mobiles;

namespace Server.Mobiles
{
	public class HolyMage : BaseVendor
	{
		private List<SBInfo> m_SBInfos = new List<SBInfo>();
		protected override List<SBInfo> SBInfos{ get { return m_SBInfos; } }

		public override NpcGuild NpcGuild{ get{ return NpcGuild.MagesGuild; } }

		[Constructable]
		public HolyMage() : base( "the holy mage" )
		{
			SetSkill( SkillName.Psychology, 65.0, 88.0 );
			SetSkill( SkillName.Inscribe, 60.0, 83.0 );
			SetSkill( SkillName.Magery, 64.0, 100.0 );
			SetSkill( SkillName.Meditation, 60.0, 83.0 );
			SetSkill( SkillName.MagicResist, 65.0, 88.0 );
			SetSkill( SkillName.FistFighting, 36.0, 68.0 );
		}

		public override void InitSBInfo( Mobile m )
		{
		}

		public override void InitOutfit()
		{
			base.InitOutfit();

			if ( Utility.RandomBool() )
			{
				switch ( Utility.RandomMinMax( 0, 4 ) )
				{
					case 1: AddItem( new Server.Items.GnarledStaff() ); break;
					case 2: AddItem( new Server.Items.BlackStaff() ); break;
					case 3: AddItem( new Server.Items.WildStaff() ); break;
					case 4: AddItem( new Server.Items.QuarterStaff() ); break;
				}
			}
		}

		///////////////////////////////////////////////////////////////////////////
		public override void GetContextMenuEntries( Mobile from, List<ContextMenuEntry> list ) 
		{ 
			base.GetContextMenuEntries( from, list ); 
			list.Add( new SpeechGumpEntry( from, this ) ); 
		} 

		public class SpeechGumpEntry : ContextMenuEntry
		{
			private Mobile m_Mobile;
			private Mobile m_Giver;
			
			public SpeechGumpEntry( Mobile from, Mobile giver ) : base( 6146, 3 )
			{
				m_Mobile = from;
				m_Giver = giver;
			}

			public override void OnClick()
			{
			    if( !( m_Mobile is PlayerMobile ) )
				return;
				
				PlayerMobile mobile = (PlayerMobile) m_Mobile;
				{
					if ( ! mobile.HasGump( typeof( SpeechGump ) ) )
					{
						Server.Misc.IntelligentAction.SayHey( m_Giver );
						mobile.SendGump(new SpeechGump( mobile, "The Mystical Art Of Wizardry", SpeechFunctions.SpeechText( m_Giver, m_Mobile, "Mage" ) ));
					}
				}
            }
        }
		///////////////////////////////////////////////////////////////////////////

		private class FixEntry : ContextMenuEntry
		{
			private HolyMage m_HolyMage;
			private Mobile m_From;

			public FixEntry( HolyMage HolyMage, Mobile from ) : base( 6120, 12 )
			{
				m_HolyMage = HolyMage;
				m_From = from;
			}

			public override void OnClick()
			{
				m_HolyMage.BeginServices( m_From );
			}
		}

		public override void AddCustomContextEntries( Mobile from, List<ContextMenuEntry> list )
		{
			if ( from.Alive && !from.Blessed )
			{
				list.Add( new FixEntry( this, from ) );
			}

			base.AddCustomContextEntries( from, list );
		}

        public void BeginServices(Mobile from)
        {
            if ( Deleted || !from.Alive )
                return;

			int nCost = 100;

			if ( BeggingPose(from) > 0 ) // LET US SEE IF THEY ARE BEGGING
			{
				nCost = nCost - (int)( ( from.Skills[SkillName.Begging].Value * 0.005 ) * nCost ); if ( nCost < 1 ){ nCost = 1; }
				SayTo(from, "Since you are begging, do you still want me to charge a magic wand with 5 charges, you will need to donate " + nCost.ToString() + " gold per spell circle of the wand?");
			}
			else { SayTo(from, "If you want me to charge a magic wand with 5 charges, you will need to donate " + nCost.ToString() + " gold per spell circle of the wand."); }

            from.Target = new RepairTarget(this);
        }

        private class RepairTarget : Target
        {
            private HolyMage m_HolyMage;

            public RepairTarget(HolyMage holymage) : base(12, false, TargetFlags.None)
            {
                m_HolyMage = holymage;
            }

            protected override void OnTarget(Mobile from, object targeted)
            {
                m_HolyMage.SayTo(from, "That does not need my services.");
            }
        }

		public HolyMage( Serial serial ) : base( serial )
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
			this.Delete();
		}
	}
}