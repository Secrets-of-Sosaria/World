using System;
using Server.Network;
using Server.Items;
using Server;
using Server.Mobiles;
using Server.Targeting;
using Server.Misc;

namespace Server.Items
{
	public class SurgeonsKnife : SkinningKnife
	{
		public override int Hue{ get { return 0xABD; } }

		[Constructable]
		public SurgeonsKnife() : base()
		{
			Name = "surgeons knife";
			ItemID = 0x2677;
		}

		public override void OnDoubleClick( Mobile from )
		{
			from.SendLocalizedMessage( 1010018 ); // What do you want to use this item on?
			from.Target = new CorpseTarget( this );
		}

		public SurgeonsKnife( Serial serial ) : base( serial )
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
			Timer.DelayCall( TimeSpan.FromSeconds( 15.0 ), new TimerCallback( Delete ) );
		}

		private class CorpseTarget : Target
		{
			private SurgeonsKnife m_Knife;

			public CorpseTarget( SurgeonsKnife blade ) : base( 3, false, TargetFlags.None )
			{
				m_Knife = blade;
			}

			protected override void OnTarget( Mobile from, object targeted )
			{
				bool cut = false;

				if ( m_Knife.Deleted )
					return;

				if ( !(targeted is Corpse) )
				{
					from.SendLocalizedMessage( 1042600 ); // That is not a corpse!
                    return;
				}
				else
				{
					object obj = targeted;

					if ( obj is Corpse )
						obj = ((Corpse)obj).Owner;

                    if ( obj != null )
                    {
						Corpse c = (Corpse)targeted;
						Mobile m = c.m_Owner;

						SlayerEntry giant = SlayerGroup.GetEntryByName( SlayerName.GiantKiller );

						if ( from.Backpack.FindItemByType( typeof ( FrankenJournal ) ) != null && m_Knife.HitPoints > 0 && !(c.VisitedByTaxidermist) && from.Skills[SkillName.Forensics].Value >= Utility.RandomMinMax( 30, 250 ) && giant.Slays(m) )
						{
							Item piece = new FrankenLegLeft(); piece.Delete();

							switch ( Utility.Random( 7 ) )
							{
								case 0: piece = new FrankenLegLeft(); from.SendMessage("You sever off the giant's left leg."); break;
								case 1: piece = new FrankenLegRight(); from.SendMessage("You sever off the giant's right leg."); break;
								case 2: piece = new FrankenArmLeft(); from.SendMessage("You sever off the giant's left arm."); break;
								case 3: piece = new FrankenArmRight(); from.SendMessage("You sever off the giant's right arm."); break;
								case 4: piece = new FrankenHead(); from.SendMessage("You sever off the giant's head."); break;
								case 5: piece = new FrankenTorso(); from.SendMessage("You sever apart the giant's torso."); break;
								case 6: piece = new FrankenBrain(); from.SendMessage("You remove the giant's fresh brain."); break;
							}

							if ( piece is FrankenBrain )
							{
								FrankenBrain brain = (FrankenBrain)piece;

								string brainName = m.Name;
									if ( m.Title != "" ){ brainName = brainName + " " + m.Title; }

								brain.BrainSource = brainName;
								brain.BrainLevel = ( IntelligentAction.GetCreatureLevel( m ) + 5 ); // TITAN LICHES SEEM TO HAVE LEVEL 96 BRAINS
									if ( brain.BrainLevel > 100 ){ brain.BrainLevel = 100; }
							}

							from.AddToBackpack( piece );
							cut = true;
						}

						if ( m_Knife.HitPoints < 1 )
						{
							from.SendMessage("This knife is too dull and needs to be replaced or repaired.");
						}
						else if ( c.VisitedByTaxidermist )
						{
							from.SendMessage("This corpse has already been cut up.");
						}
						else if ( !( (from.Backpack).ConsumeTotal( typeof( Jar ), 1 ) ) )
						{
							from.SendMessage("You forgot a jar, losing your chance to get anything extra from the corpse.");
						}
						else if ( from.CheckSkill( SkillName.Forensics, -5, 120 ) )
						{
							int jarsFill = MyServerSettings.Resources();

							if ( m_Knife.HitPoints > 0 && Utility.RandomMinMax( 1, 4 ) == 1 ){ m_Knife.HitPoints--; }

							BottleOfParts guts = new BottleOfParts();
								guts.Delete();

							string sName = "";

							if ( sName != "" )
							{
								string quantity = "";
								int qtyVal = 0;
								bool noCheck = true;
								while ( jarsFill > 0 )
								{
									if ( noCheck )
									{
										guts = new BottleOfParts();
										Server.Items.BottleOfParts.FillJar( sName, 0, guts );
										from.CheckSkill( SkillName.Anatomy, 0, 120 );
										from.AddToBackpack( guts );
										qtyVal++;
									}
									else if ( (from.Backpack).ConsumeTotal( typeof( Jar ), 1 ) )
									{
										guts = new BottleOfParts();
										Server.Items.BottleOfParts.FillJar( sName, 0, guts );
										from.CheckSkill( SkillName.Forensics, -5, 120 );
										from.AddToBackpack( guts );
										qtyVal++;
									}
									else
									{
										jarsFill = 0;
									}
									jarsFill = jarsFill - 1;
									noCheck = false;
								}
								if ( from.Skills[SkillName.Forensics].Value < Utility.RandomMinMax( 1, 110 ) ) { m_Knife.HitPoints = m_Knife.HitPoints - 1; }

							
								if ( qtyVal > 1 ){ quantity = " (" + qtyVal + "ea)"; }
								from.SendMessage("You get a " + guts.Name + " from the corpse" + quantity + ".");
							}
							else
							{
								from.AddToBackpack( new Jar() );
								from.SendMessage("These corpses never have anything extra of value.");
							}
							cut = true;
						}
						else
						{
							from.AddToBackpack( new Jar() );
							from.SendLocalizedMessage( 500485 ); // You see nothing useful to carve from the corpse.
							if ( from.Skills[SkillName.Forensics].Value < Utility.RandomMinMax( 1, 110 ) ) { m_Knife.HitPoints = m_Knife.HitPoints - 1; }
							cut = true;
						}

						if ( cut ){ c.VisitedByTaxidermist = true; }
					}
					else
					{
						from.SendLocalizedMessage( 500485 ); // You see nothing useful to carve from the corpse.
					}
				}
			}
		}
	}
}

namespace Server.Items
{
	public class BottleOfParts : Item
	{
		public override double DefaultWeight
		{
			get { return 1.0; }
		}

		[Constructable]
		public BottleOfParts() : base( 0x1007 )
		{
			Name = "jar of parts";
			Stackable = true;
		}

		public BottleOfParts( Serial serial ) : base( serial )
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
			Timer.DelayCall( TimeSpan.FromSeconds( 15.0 ), new TimerCallback( Delete ) );
		}

		public static void FillJar( string guts, int value, Item jar )
		{
			if ( guts == "abysmal essence" || value == 61 ){ jar.Hue = 0xA97; jar.Name = "jar of abysmal essence"; }
			else if ( guts == "angelic feathers" || value == 43 ){ jar.Hue = 0xB92; jar.Name = "jar of angelic feathers"; }
			else if ( guts == "animal tongues" || value == 45 ){ jar.Hue = 0xF1; jar.Name = "jar of animal tongues"; }
			else if ( guts == "ape ears" || value == 58 ){ jar.Hue = 0x3CC; jar.Name = "jar of ape ears"; }
			else if ( guts == "bat ears" || value == 53 ){ jar.Hue = 0x723; jar.Name = "jar of bat ears"; }
			else if ( guts == "bear hairs" || value == 16 ){ jar.Hue = 0x906; jar.Name = "jar of bear hairs"; }
			else if ( guts == "bird beaks" || value == 15 ){ jar.Hue = 0x38; jar.Name = "jar of bird beaks"; }
			else if ( guts == "bone powder" || value == 5 ){ jar.Hue = 0x482; jar.Name = "jar of bone powder"; }
			else if ( guts == "bony horns" || value == 49 ){ jar.Hue = 0x60B; jar.Name = "jar of bony horns"; }
			else if ( guts == "cat whiskers" || value == 24 ){ jar.Hue = 0x38A; jar.Name = "jar of cat whiskers"; }
			else if ( guts == "centaur fingers" || value == 25 ){ jar.Hue = 0x27B; jar.Name = "jar of centaur fingers"; }
			else if ( guts == "cow eyes" || value == 22 ){ jar.Hue = 0x367; jar.Name = "jar of cow eyes"; }
			else if ( guts == "crab meat" || value == 54 ){ jar.Hue = 0x5E6; jar.Name = "jar of crab meat"; }
			else if ( guts == "crushed gems" || value == 51 ){ jar.Hue = 0x495; jar.Name = "jar of crushed gems"; }
			else if ( guts == "crushed stone" || value == 2 ){ jar.Hue = 0x3CD; jar.Name = "jar of crushed stone"; }
			else if ( guts == "crystal shards" || value == 28 ){ jar.Hue = 0xA5C; jar.Name = "jar of crystal shards"; }
			else if ( guts == "cursed leaves" || value == 27 ){ jar.Hue = 0x2F6; jar.Name = "jar of cursed leaves"; }
			else if ( guts == "darkness" || value == 84 ){ jar.Hue = 0x497; jar.Name = "jar of darkness"; }
			else if ( guts == "dead skin" || value == 48 ){ jar.Hue = 0xB97; jar.Name = "jar of dead skin"; }
			else if ( guts == "demonic hellfire" || value == 12 ){ jar.Hue = 0x4EC; jar.Name = "jar of demonic hellfire"; }
			else if ( guts == "dog hairs" || value == 11 ){ jar.Hue = 0x908; jar.Name = "jar of dog hairs"; }
			else if ( guts == "dolphin teeth" || value == 36 ){ jar.Hue = 0xC4; jar.Name = "jar of dolphin teeth"; }
			else if ( guts == "dragon smoke" || value == 10 ){ jar.Hue = 0x963; jar.Name = "jar of dragon smoke"; }
			else if ( guts == "dried blood" || value == 18 ){ jar.Hue = 0x5B5; jar.Name = "jar of dried blood"; }
			else if ( guts == "dryad tears" || value == 73 ){ jar.Hue = 0x17D; jar.Name = "jar of dryad tears"; }
			else if ( guts == "electricity" || value == 41 ){ jar.Hue = 0x800; jar.Name = "jar of electricity"; }
			else if ( guts == "elemental powder" || value == 64 ){ jar.Hue = 0xB8F; jar.Name = "jar of elemental powder"; }
			else if ( guts == "elven blood" || value == 42 ){ jar.Hue = 0x5B5; jar.Name = "jar of elven blood"; }
			else if ( guts == "enchanted frost" || value == 46 ){ jar.Hue = 0x47E; jar.Name = "jar of enchanted frost"; }
			else if ( guts == "enchanted sap" || value == 30 ){ jar.Hue = 0x477; jar.Name = "jar of enchanted sap"; }
			else if ( guts == "entrails" || value == 1 ){ jar.Hue = 0x845; jar.Name = "jar of entrails"; }
			else if ( guts == "fish scales" || value == 87 ){ jar.Hue = 0x315; jar.Name = "jar of fish scales"; }
			else if ( guts == "frog tongues" || value == 23 ){ jar.Hue = 0x29; jar.Name = "jar of frog tongues"; }
			else if ( guts == "gargoyle horns" || value == 50 ){ jar.Hue = 0x14F; jar.Name = "jar of gargoyle horns"; }
			else if ( guts == "gazing eyes" || value == 14 ){ jar.Hue = 0x8BE; jar.Name = "jar of gazing eyes"; }
			else if ( guts == "ghostly mist" || value == 52 ){ jar.Hue = 0x481; jar.Name = "jar of ghostly mist"; }
			else if ( guts == "giant blood" || value == 29 ){ jar.Hue = 0x5B5; jar.Name = "jar of giant blood"; }
			else if ( guts == "gore" || value == 82 ){ jar.Hue = 0xA19; jar.Name = "jar of gore"; }
			else if ( guts == "hellish smoke" || value == 40 ){ jar.Hue = 0x963; jar.Name = "jar of hellish smoke"; }
			else if ( guts == "horrid breath" || value == 13 ){ jar.Hue = 0x3BC; jar.Name = "jar of horrid breath"; }
			else if ( guts == "human blood" || value == 8 ){ jar.Hue = 0x5B5; jar.Name = "jar of human blood"; }
			else if ( guts == "hydra urine" || value == 62 ){ jar.Hue = 0xFF; jar.Name = "jar of hydra urine"; }
			else if ( guts == "illithid brains" || value == 71 ){ jar.Hue = 0x1F; jar.Name = "jar of illithid brains"; }
			else if ( guts == "imp tails" || value == 63 ){ jar.Hue = 0x6E9; jar.Name = "jar of imp tails"; }
			else if ( guts == "ink" || value == 66 ){ jar.Hue = 0x497; jar.Name = "jar of ink"; }
			else if ( guts == "insect ichor" || value == 7 ){ jar.Hue = 0x291; jar.Name = "jar of insect ichor"; }
			else if ( guts == "ivory pieces" || value == 89 ){ jar.Hue = 0xB89; jar.Name = "jar of ivory pieces"; }
			else if ( guts == "jade chunks" || value == 67 ){ jar.Hue = 0xB93; jar.Name = "jar of jade chunks"; }
			else if ( guts == "large teeth" || value == 77 ){ jar.Hue = 0x30D; jar.Name = "jar of large teeth"; }
			else if ( guts == "leech spit" || value == 55 ){ jar.Hue = 0x4F8; jar.Name = "jar of leech spit"; }
			else if ( guts == "liquid fire" || value == 60 ){ jar.Hue = 0x48E; jar.Name = "jar of liquid fire"; }
			else if ( guts == "magical ashes" || value == 26 ){ jar.Hue = 0xB85; jar.Name = "jar of magical ashes"; }
			else if ( guts == "magical dust" || value == 38 ){ jar.Hue = 0x8A5; jar.Name = "jar of magical dust"; }
			else if ( guts == "minotaur hooves" || value == 72 ){ jar.Hue = 0x27D; jar.Name = "jar of minotaur hooves"; }
			else if ( guts == "mummy wraps" || value == 76 ){ jar.Hue = 0x399; jar.Name = "jar of mummy wraps"; }
			else if ( guts == "mystical air" || value == 3 ){ jar.Hue = 0x430; jar.Name = "jar of mystical air"; }
			else if ( guts == "mystical dirt" || value == 39 ){ jar.Hue = 0x8AA; jar.Name = "jar of mystical dirt"; }
			else if ( guts == "mystical mud" || value == 75 ){ jar.Hue = 542; jar.Name = "jar of mystical mud"; }
			else if ( guts == "ogre thumbs" || value == 9 ){ jar.Hue = 0x841; jar.Name = "jar of ogre thumbs"; }
			else if ( guts == "oil" || value == 44 ){ jar.Hue = 0x497; jar.Name = "jar of oil"; }
			else if ( guts == "oni fur" || value == 78 ){ jar.Hue = 0x906; jar.Name = "jar of oni fur"; }
			else if ( guts == "orcish bile" || value == 79 ){ jar.Hue = 0x2F1; jar.Name = "jar of orcish bile"; }
			else if ( guts == "ostard scales" || value == 35 ){ jar.Hue = 0x173; jar.Name = "jar of ostard scales"; }
			else if ( guts == "pig snouts" || value == 20 ){ jar.Hue = 0x15F; jar.Name = "jar of pig snouts"; }
			else if ( guts == "pixie sparkles" || value == 80 ){ jar.Hue = 0x68A; jar.Name = "jar of pixie sparkles"; }
			else if ( guts == "poisonous gas" || value == 81 ){ jar.Hue = 0x559; jar.Name = "jar of poisonous gas"; }
			else if ( guts == "quills" || value == 59 ){ jar.Hue = 0x6C0; jar.Name = "jar of quills"; }
			else if ( guts == "rat tails" || value == 56 ){ jar.Hue = 0x709; jar.Name = "jar of rat tails"; }
			else if ( guts == "reptile scales" || value == 4 ){ jar.Hue = 0x29C; jar.Name = "jar of reptile scales"; }
			else if ( guts == "scaly fingers" || value == 65 ){ jar.Hue = 0x14E; jar.Name = "jar of scaly fingers"; }
			else if ( guts == "scorpion stingers" || value == 33 ){ jar.Hue = 0x4F5; jar.Name = "jar of scorpion stingers"; }
			else if ( guts == "sea water" || value == 34 ){ jar.Hue = 0x65; jar.Name = "jar of sea water"; }
			else if ( guts == "silver shavings" || value == 68 ){ jar.Hue = 0x835; jar.Name = "jar of silver shavings"; }
			else if ( guts == "slime" || value == 17 ){ jar.Hue = 0xB93; jar.Name = "jar of slime"; }
			else if ( guts == "sphinx fur" || value == 85 ){ jar.Hue = 0x6E9; jar.Name = "jar of sphinx fur"; }
			else if ( guts == "spider legs" || value == 37 ){ jar.Hue = 0x259; jar.Name = "jar of spider legs"; }
			else if ( guts == "sprite teeth" || value == 74 ){ jar.Hue = 0x48D; jar.Name = "jar of sprite teeth"; }
			else if ( guts == "succubus pheromones" || value == 86 ){ jar.Hue = 0xEC; jar.Name = "jar of succubus pheromones"; }
			else if ( guts == "swamp gas" || value == 21 ){ jar.Hue = 0x5A6; jar.Name = "jar of swamp gas"; }
			else if ( guts == "troll claws" || value == 47 ){ jar.Hue = 0x168; jar.Name = "jar of troll claws"; }
			else if ( guts == "unicorn teeth" || value == 31 ){ jar.Hue = 0x430; jar.Name = "jar of unicorn teeth"; }
			else if ( guts == "vampire fangs" || value == 88 ){ jar.Hue = 0xB89; jar.Name = "jar of vampire fangs"; }
			else if ( guts == "wax shavings" || value == 69 ){ jar.Hue = 0x47E; jar.Name = "jar of wax shavings"; }
			else if ( guts == "wisp light" || value == 32 ){ jar.Hue = 0x491; jar.Name = "jar of wisp light"; }
			else if ( guts == "wood splinters" || value == 90 ){ jar.Hue = 0x7DA; jar.Name = "jar of wood splinters"; }
			else if ( guts == "worm guts" || value == 19 ){ jar.Hue = 0x709; jar.Name = "jar of worm guts"; }
			else if ( guts == "wyrm spit" || value == 6 ){ jar.Hue = 0x487; jar.Name = "jar of wyrm spit"; }
			else if ( guts == "wyvern poison" || value == 91 ){ jar.Hue = 0x5AA; jar.Name = "jar of wyvern poison"; }
			else if ( guts == "yeti claws" || value == 93 ){ jar.Hue = 0x3D5; jar.Name = "jar of yeti claws"; }
		}
	}
}