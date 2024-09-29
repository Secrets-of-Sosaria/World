using System;
using Server;
using Server.Spells.Magical;
using Server.Targeting;

namespace Server.Items
{
	public class Artifact_StaffofSnakes : GiftQuarterStaff
	{
		public DateTime TimeUsed;

		[CommandProperty(AccessLevel.Owner)]
		public DateTime Time_Used { get { return TimeUsed; } set { TimeUsed = value; InvalidateProperties(); } }

		public override int InitMinHits{ get{ return 80; } }
		public override int InitMaxHits{ get{ return 160; } }

		[Constructable]
		public Artifact_StaffofSnakes()
		{
			Hue = 0x304;
			Name = "Staff of the Serpent";
			AosElementDamages.Poison = 100;
			Attributes.SpellChanneling = 1;
			Slayer = SlayerName.SnakesBane;
			WeaponAttributes.HitPoisonArea = 50;
			ArtifactLevel = 2;
			Server.Misc.Arty.ArtySetup( this, 12, "(Summons Snakes) " );
		}

		public override void OnDoubleClick( Mobile from )
		{
			DateTime TimeNow = DateTime.Now;
			long ticksThen = TimeUsed.Ticks;
			long ticksNow = TimeNow.Ticks;
			int minsThen = (int)TimeSpan.FromTicks(ticksThen).TotalMinutes;
			int minsNow = (int)TimeSpan.FromTicks(ticksNow).TotalMinutes;
			int CanUseMagic = 60 - ( minsNow - minsThen );

			if ( Parent != from )
			{
				from.SendMessage( "You must be holding the staff to summon snakes." );
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
				new SummonSnakesSpell( from, this ).Cast();
				TimeUsed = DateTime.Now;
			}
		}

		public Artifact_StaffofSnakes( Serial serial ) : base( serial )
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