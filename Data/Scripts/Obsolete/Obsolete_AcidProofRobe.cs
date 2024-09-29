using System;
using Server;

namespace Server.Items
{
	public class AcidProofRobe : MagicRobe
	{
		public DateTime TimeUsed;

		[CommandProperty(AccessLevel.Owner)]
		public DateTime Time_Used { get { return TimeUsed; } set { TimeUsed = value; InvalidateProperties(); } }

		[Constructable]
		public AcidProofRobe()
		{
			Name = "Acidic Robe";
			Hue = 1167;
			Resistances.Fire = 20;
			Resistances.Poison = 20;
			ItemID = 0x1F03;
		}

        public override void AddNameProperties(ObjectPropertyList list)
		{
            base.AddNameProperties(list);
			list.Add( 1070722, "Artefact");
            list.Add( 1049644, "Use To Fill Bottles With Acid");
        }

		public override void OnDoubleClick( Mobile from )
		{
			DateTime TimeNow = DateTime.Now;
			long ticksThen = TimeUsed.Ticks;
			long ticksNow = TimeNow.Ticks;
			int minsThen = (int)TimeSpan.FromTicks(ticksThen).TotalMinutes;
			int minsNow = (int)TimeSpan.FromTicks(ticksNow).TotalMinutes;
			int CanFillBottle = 180 - ( minsNow - minsThen );

			if ( Parent != from )
			{
				from.SendMessage( "You must be wearing the robe to use it." );
			}
			else if ( CanFillBottle > 0 )
			{
				TimeSpan t = TimeSpan.FromMinutes( CanFillBottle );
				string wait = string.Format("{0:D1} hours and {1:D2} minutes", 
								t.Hours, 
								t.Minutes);
				from.SendMessage( "You can squeeze out acid in " + wait + "." );
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

		public AcidProofRobe( Serial serial ) : base( serial )
		{
		}
		
		public override void Serialize( GenericWriter writer )
		{
			base.Serialize( writer );
			writer.Write( (int) 1 );
            writer.Write( TimeUsed );
		}
		
		private void Cleanup( object state ){ Item item = new Artifact_AcidProofRobe(); Server.Misc.Cleanup.DoCleanup( (Item)state, item ); }

public override void Deserialize(GenericReader reader)
		{
			base.Deserialize( reader ); Timer.DelayCall( TimeSpan.FromSeconds( 1.0 ), new TimerStateCallback( Cleanup ), this );
			int version = reader.ReadInt();
			TimeUsed = reader.ReadDateTime();
		}
	}
}
