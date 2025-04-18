using System;
using Server;
using Server.Mobiles;

namespace Server.Items
{
	public class Artifact_AcidProofRobe : GiftRobe
	{
		public DateTime TimeUsed;

		[CommandProperty(AccessLevel.Owner)]
		public DateTime Time_Used { get { return TimeUsed; } set { TimeUsed = value; InvalidateProperties(); } }

		[Constructable]
		public Artifact_AcidProofRobe()
		{
			Name = "Acidic Robe";
			Hue = 1167;
			Resistances.Fire = 20;
			Resistances.Poison = 20;
			ArtifactLevel = 2;
			Server.Misc.Arty.ArtySetup( this, 10, "Acid Soaked " );
		}

		public override void OnDoubleClick( Mobile from )
		{
			DateTime TimeNow = DateTime.Now;
			long ticksThen = TimeUsed.Ticks;
			long ticksNow = TimeNow.Ticks;
			int minsThen = (int)TimeSpan.FromTicks(ticksThen).TotalMinutes;
			int minsNow = (int)TimeSpan.FromTicks(ticksNow).TotalMinutes;
			int CanFillBottle = 30 - ( minsNow - minsThen );

			if ( CanFillBottle > 0 )
			{
				from.SendMessage( "You can squeeze out acid in " + CanFillBottle + " minutes." );
			}
			else
			{
				if (!from.Backpack.ConsumeTotal(typeof(Bottle), 1))
				{
					from.SendMessage("You need an empty bottle to squeeze the acid into.");
				}
				else
				{
					from.PlaySound( 0x240 );
					from.AddToBackpack( new BottleOfAcid() );
					from.SendMessage( "You squeeze some acid from the cloth of the robe." );
					TimeUsed = DateTime.Now;
				}
			}
		}

		public override bool OnDragLift( Mobile from )
		{
			if ( from is PlayerMobile )
			{
				from.SendMessage( "You can use this robe to sqeeze acid out from its cloth." );
			}

			return true;
		}

		public Artifact_AcidProofRobe( Serial serial ) : base( serial )
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
