using System;
using Server;
using Server.Network;
using System.Text;
using Server.Items;
using Server.Misc;
using Server.Mobiles;
using System.Globalization;

namespace Server.Items
{
	public class UnknownReagent : Item
	{
		public int RegAmount;

		[CommandProperty(AccessLevel.Owner)]
		public int Reg_Amount { get { return RegAmount; } set { RegAmount = value; InvalidateProperties(); } }

		[Constructable]
		public UnknownReagent() : base( 0x0EFC )
		{
			RegAmount = Utility.RandomMinMax( 1, 10 );
			string sContainer = "jar of reagents";

			switch( Utility.RandomMinMax( 0, 3 ) )
			{
				case 0: ItemID = 0x1005; sContainer = "jar of reagents"; break;
				case 1: ItemID = 0x1006; sContainer = "jar of reagents"; break;
				case 2: ItemID = 0x1007; sContainer = "jar of reagents"; break;
				case 3: ItemID = 0x9C8; sContainer = "jug of reagents"; break;
			}

			string sLiquid = "a strange";
			switch( Utility.RandomMinMax( 0, 6 ) )
			{
				case 0: sLiquid = "an odd"; break;
				case 1: sLiquid = "an unusual"; break;
				case 2: sLiquid = "a bizarre"; break;
				case 3: sLiquid = "a curious"; break;
				case 4: sLiquid = "a peculiar"; break;
				case 5: sLiquid = "a strange"; break;
				case 6: sLiquid = "a weird"; break;
			}
			Name = sLiquid + " " + sContainer;
			Hue = Utility.RandomColor(0);
			Weight = 1.0;
			Amount = 1;
			Stackable = false;
		}

		public UnknownReagent( Serial serial ) : base( serial )
		{
		}

		public override void OnDoubleClick( Mobile from )
		{
			if ( !Movable )
			{
				from.SendMessage( "That cannot move so you cannot identify it." );
				return;
			}
			else if ( !from.InRange( this.GetWorldLocation(), 3 ) )
			{
				from.SendMessage( "You will need to get closer to identify that." );
				return;
			}
			else if ( !IsChildOf( from.Backpack ) && MySettings.S_IdentifyItemsOnlyInPack ) 
			{
				from.SendMessage( "This must be in your backpack to identify." );
				return;
			}
			else
			{
				if ( from.CheckSkill( SkillName.Tasting, -5, 125 ) )
				{
					int QtyBonus = 0;
					if ( from.Skills[SkillName.Cooking].Value >= 25.0 )
					{
						QtyBonus = (int)( from.Skills[SkillName.Cooking].Value / 5 );
					}

					from.PlaySound( Utility.Random( 0x3A, 3 ) );

					if ( from.Body.IsHuman && !from.Mounted )
						from.Animate( 34, 5, 1, true, false, 0 );

					int RegCount = this.RegAmount + QtyBonus;
					if ( RegCount < 1 ){ RegCount = 1; }

					Server.Items.UnknownReagent.GiveReagent( from, RegCount );
				}
				else
				{
					int nReaction = Utility.RandomMinMax( 0, 10 );

					if ( nReaction < 3 )
					{
						from.PlaySound( from.Female ? 813 : 1087 );
						from.Say( "*vomits*" );
						if ( !from.Mounted ) 
							from.Animate( 32, 5, 1, true, false, 0 );                     
						Vomit puke = new Vomit(); 
						puke.Map = from.Map; 
						puke.Location = from.Location;
						from.SendMessage("Making you sick to your stomach, you toss it out.");
					}
					else if ( nReaction > 6 )
					{
						int nPoison = Utility.RandomMinMax( 0, 10 );
						from.Say( "Poison!" );
						from.PlaySound( Utility.Random( 0x3A, 3 ) );
							if ( nPoison > 9 ) { from.ApplyPoison( from, Poison.Deadly ); }
							else if ( nPoison > 7 ) { from.ApplyPoison( from, Poison.Greater ); }
							else if ( nPoison > 4 ) { from.ApplyPoison( from, Poison.Regular ); }
							else { from.ApplyPoison( from, Poison.Lesser ); }
						from.SendMessage( "Poison!");
					}
					else
					{
						from.PlaySound( Utility.Random( 0x3A, 3 ) );
						if ( from.Body.IsHuman && !from.Mounted )
							from.Animate( 34, 5, 1, true, false, 0 );
						from.SendMessage("Failing to identify the reagent, you toss it out.");
					}
				}

				this.Delete();
			}
		}

		public static void MakeSpaceAceReagent( Item item )
		{
			item.ItemID = 0x1FDC;
			item.Hue = Utility.RandomColor(0);

			string sLiquid = "a strange";
			switch( Utility.RandomMinMax( 0, 6 ) )
			{
				case 0: sLiquid = "an odd"; break;
				case 1: sLiquid = "an unusual"; break;
				case 2: sLiquid = "a bizarre"; break;
				case 3: sLiquid = "a curious"; break;
				case 4: sLiquid = "a peculiar"; break;
				case 5: sLiquid = "a strange"; break;
				case 6: sLiquid = "a weird"; break;
			}
			item.Name = sLiquid + " flask of reagents";
		}

		public static void GiveReagent( Mobile from, int qty )
		{
			string regs = "";

			Item ingredient = Loot.RandomPossibleReagent();
			ingredient.Amount = qty;
			from.AddToBackpack( ingredient );

			regs = ingredient.Name;

			if ( regs == null || regs == "" )
				ingredient.SyncName(); regs = ingredient.Name; 

			if ( qty < 2 ){ from.SendMessage("This seems to be " + regs + "."); }
			else { from.SendMessage("This seems to be " + qty + " " + regs + "."); }
		}

        public override void AddNameProperties(ObjectPropertyList list)
		{
            base.AddNameProperties(list);
			list.Add( 1070722, RegAmount + " of this Unknown Reagent in Here");
			list.Add( 1049644, "Unidentified"); // PARENTHESIS
        }

		public override void Serialize( GenericWriter writer )
		{
			base.Serialize( writer );
			writer.Write( (int) 0 ); // version
            writer.Write( RegAmount );
		}

		public override void Deserialize( GenericReader reader )
		{
			base.Deserialize( reader );
			int version = reader.ReadInt();
			this.Stackable = true;
			this.Amount = reader.ReadInt();
			Timer.DelayCall( TimeSpan.FromSeconds( 1.0 ), new TimerStateCallback( Cleanup ), this );
		}

		private void Cleanup( object state )
		{
			Item item = Loot.RandomPossibleReagent();
			Server.Misc.Cleanup.DoCleanup( (Item)state, item );
		}
	}
}