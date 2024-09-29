using System;
using Server;
using Server.Spells.Magical;
using Server.Targeting;

namespace Server.Items
{
	public class Artifact_GandalfsStaff : GiftQuarterStaff
	{
		public DateTime TimeUsed;

		[CommandProperty(AccessLevel.Owner)]
		public DateTime Time_Used { get { return TimeUsed; } set { TimeUsed = value; InvalidateProperties(); } }

		public override int InitMinHits{ get{ return 80; } }
		public override int InitMaxHits{ get{ return 160; } }

		[Constructable]
		public Artifact_GandalfsStaff()
		{
			Hue = 0xB85;
			Name = "Merlin's Mystical Staff";
			Attributes.LowerManaCost = 25;
			Attributes.LowerRegCost = 25;
			SkillBonuses.SetValues( 0, SkillName.Psychology, 10 );
			SkillBonuses.SetValues( 1, SkillName.Magery, 10 );
			SkillBonuses.SetValues( 2, SkillName.MagicResist, 10 );
			SkillBonuses.SetValues( 3, SkillName.Meditation, 10 );
			Attributes.RegenMana = 10;
			Attributes.BonusInt = 10;
			Attributes.SpellChanneling = 1;
			ArtifactLevel = 2;
			Server.Misc.Arty.ArtySetup( this, 15, "(Calls Dragons) " );
		}

		public override void OnDoubleClick( Mobile from )
		{
			DateTime TimeNow = DateTime.Now;
			long ticksThen = TimeUsed.Ticks;
			long ticksNow = TimeNow.Ticks;
			int minsThen = (int)TimeSpan.FromTicks(ticksThen).TotalMinutes;
			int minsNow = (int)TimeSpan.FromTicks(ticksNow).TotalMinutes;
			int CanUseMagic = 120 - ( minsNow - minsThen );

			if ( Parent != from )
			{
				from.SendMessage( "You must be holding the staff to call dragons." );
			}
			else if ( CanUseMagic > 0 )
			{
				TimeSpan t = TimeSpan.FromMinutes( CanUseMagic );
				string wait = string.Format("{0:D1} hours and {1:D2} minutes", 
								t.Hours, 
								t.Minutes);
				from.SendMessage( "You can use the magic in " + wait + "." );
			}
			else
			{
				new SummonDragonSpell( from, this ).Cast();
				TimeUsed = DateTime.Now;
			}
		}

		public Artifact_GandalfsStaff( Serial serial ) : base( serial )
		{
		}
		
		public override void Serialize( GenericWriter writer )
		{
			base.Serialize( writer );
			writer.Write( (int) 1 );
            writer.Write( TimeUsed );
		}
		
		public override void Deserialize(GenericReader reader)
		{
			base.Deserialize( reader );
			ArtifactLevel = 2;
			int version = reader.ReadInt();
			TimeUsed = reader.ReadDateTime();
		}
	}
}