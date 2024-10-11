using System;
using System.Collections;
using System.Collections.Generic;
using Server;
using Server.Items;
using Server.Targeting;
using Server.Gumps;
using Server.Mobiles;
using Server.Misc;
using Server.Regions;

namespace Server.Engines.Harvest
{
	public abstract class HarvestSystem
	{
		private List<HarvestDefinition> m_Definitions;

		public List<HarvestDefinition> Definitions { get { return m_Definitions; } }

		public HarvestSystem()
		{
			m_Definitions = new List<HarvestDefinition>();
		}

		public static string HarvestSystemTxt( HarvestSystem system, Item item )
		{
			string harvest = null;

			if ( system is Mining )
				harvest = "Ore";
			else if ( system is Lumberjacking )
				harvest = "Wood";
			else if ( system is Fishing )
				harvest = "Fish";
			else if ( system is Librarian )
				harvest = "Books";
			else if ( system is GraveRobbing )
				harvest = "Graves";

			if ( harvest != null )
				harvest = "Gathering: " + harvest;

			return harvest;
		}

		public virtual bool CheckTool( Mobile from, Item tool )
		{
			bool wornOut = ( tool == null || tool.Deleted || (tool is IUsesRemaining && ((IUsesRemaining)tool).UsesRemaining <= 0) );

			if ( wornOut )
				from.SendLocalizedMessage( 1044038 ); // You have worn out your tool!

			return !wornOut;
		}

		public virtual bool CheckHarvest( Mobile from, Item tool )
		{
			return CheckTool( from, tool );
		}

		public virtual bool CheckHarvest( Mobile from, Item tool, HarvestDefinition def, object toHarvest )
		{
			return CheckTool( from, tool );
		}

		public virtual bool CheckRange( Mobile from, Item tool, HarvestDefinition def, Map map, Point3D loc, bool timed )
		{
			bool inRange = ( from.Map == map && from.InRange( loc, def.MaxRange ) );

			if ( !inRange )
				def.SendMessageTo( from, timed ? def.TimedOutOfRangeMessage : def.OutOfRangeMessage );

			return inRange;
		}

		public virtual bool CheckResources( Mobile from, Item tool, HarvestDefinition def, Map map, Point3D loc, bool timed )
		{
			HarvestBank bank = def.GetBank( map, loc.X, loc.Y );
			bool available = ( bank != null && bank.Current > 0 );

			if ( !available )
				def.SendMessageTo( from, timed ? def.DoubleHarvestMessage : def.NoResourcesMessage );

			return available;
		}

		public virtual void OnBadHarvestTarget( Mobile from, Item tool, object toHarvest )
		{
		}

		public virtual object GetLock( Mobile from, Item tool, HarvestDefinition def, object toHarvest )
		{
			/* Here we prevent multiple harvesting.
			 * 
			 * Some options:
			 *  - 'return tool;' : This will allow the player to harvest more than once concurrently, but only if they use multiple tools. This seems to be as OSI.
			 *  - 'return GetType();' : This will disallow multiple harvesting of the same type. That is, we couldn't mine more than once concurrently, but we could be both mining and lumberjacking.
			 *  - 'return typeof( HarvestSystem );' : This will completely restrict concurrent harvesting.
			 */

			return typeof( HarvestSystem );
		}

		public virtual void OnConcurrentHarvest( Mobile from, Item tool, HarvestDefinition def, object toHarvest )
		{
		}

		public virtual void OnHarvestStarted( Mobile from, Item tool, HarvestDefinition def, object toHarvest )
		{
		}

		public virtual bool BeginHarvesting( Mobile from, Item tool )
		{
			if ( !CheckHarvest( from, tool ) )
				return false;

			if ( MySettings.S_AllowMacroResources )
			{ 
				from.Target = new HarvestTarget( tool, this );
			}
			else
			{
				CaptchaGump.sendCaptcha(from, HarvestSystem.SendHarvestTarget, new object[]{tool, this});
			}

			return true;
		}

        public static void SendHarvestTarget( Mobile from, object o )
        {
            if (!(o is object[]))
                return;
            object[] arglist = (object[])o;
 
            if (arglist.Length != 2)
                return;
 
            if (!(arglist[0] is Item))
                return;
 
            if (!(arglist[1] is HarvestSystem))
                return;
               
            from.Target = new HarvestTarget((Item)arglist[0], (HarvestSystem)arglist[1] );
        }

		public virtual void FinishHarvesting( Mobile from, Item tool, HarvestDefinition def, object toHarvest, object locked )
		{
			from.EndAction( locked );

			if ( !CheckHarvest( from, tool ) )
				return;

			int tileID;
			Map map;
			Point3D loc;

			if ( !GetHarvestDetails( from, tool, toHarvest, out tileID, out map, out loc ) )
			{
				OnBadHarvestTarget( from, tool, toHarvest );
				return;
			}
			else if ( !def.Validate( tileID ) )
			{
				OnBadHarvestTarget( from, tool, toHarvest );
				return;
			}
			
			if ( !CheckRange( from, tool, def, map, loc, true ) )
				return;
			else if ( !CheckResources( from, tool, def, map, loc, true ) )
				return;
			else if ( !CheckHarvest( from, tool, def, toHarvest ) )
				return;

			if ( SpecialHarvest( from, tool, def, map, loc ) )
				return;

			HarvestBank bank = def.GetBank( map, loc.X, loc.Y );

			if ( bank == null )
				return;

			HarvestVein vein = bank.Vein;

			if ( vein != null )
				vein = MutateVein( from, tool, def, bank, toHarvest, vein );

			if ( vein == null )
				return;

			HarvestResource primary = vein.PrimaryResource;
			HarvestResource fallback = vein.FallbackResource;
			HarvestResource resource = MutateResource( from, tool, def, map, loc, vein, primary, fallback );

			double skillValue = from.Skills[def.Skill].Value;
			double skillMin = resource.MinSkill;
			double skillMax = resource.MaxSkill;

			Type type = null;

			bool testSkill = false;

			testSkill = from.CheckSkill( def.Skill, skillMin, skillMax );

			if ( skillValue >= resource.ReqSkill && testSkill )
			{
				type = GetResourceType( from, tool, def, map, loc, resource );

				if ( type != null )
					type = MutateType( type, from, tool, def, map, loc, resource );
				if ( type != null )
				{
					Item item = Construct( type, from );

					if ( item == null )
					{
						type = null;
					}
					else
					{
						if ( item.Stackable )
						{
							bool addUp = true;

							if ( tool is FishingPole && !Worlds.IsOnBoat( from ) && from.Skills[def.Skill].Base >= 50 )
							{
								addUp = false;
							}

							if ( addUp )
							{
								int skillCycle = MyServerSettings.Resources() - 1;
								int extra = 0;

								while ( skillCycle > 0 )
								{
									extra++;	if ( extra > MyServerSettings.StatGainDelayNum() ){ extra = 1; }
									Server.Misc.SkillCheck.ResetStatGain( from, extra );
									from.CheckSkill( def.Skill, skillMin, skillMax );
									skillCycle--;
								}
							}

							Region reg = Region.Find( from.Location, from.Map );

							int amount = def.ConsumedPerHarvest;
							int dreadAmount = def.ConsumedPerIslesDreadHarvest;
							bool inIslesDread = (map == Map.IslesDread);

							if ( item is BlankScroll )
							{
								amount = Utility.RandomMinMax( amount, (int)(amount+(from.Skills[SkillName.Inscribe].Value/10)) );
								from.SendMessage( "You find some blank scrolls.");
							}

							if ( from.Land == Land.IslesDread )
								item.Amount = dreadAmount;
							else if ( reg.IsPartOf( "the Mines of Morinia" ) && item is BaseOre && Utility.RandomMinMax( 1, 3 ) > 1 )
								item.Amount = dreadAmount;
							else
								item.Amount = amount;

							bool FindSeaOre = false;
								if ( !( item is IronOre ) && !( item is DullCopperOre ) && !( item is ShadowIronOre ) && !( item is CopperOre ) && !( item is BronzeOre ) && !( item is GoldOre ) && !( item is AgapiteOre ) && !( item is VeriteOre ) && !( item is ValoriteOre ) && Utility.RandomBool() )
									FindSeaOre = true;

							bool FindSeaGranite = false;
								if ( !( item is Granite ) && !( item is DullCopperGranite ) && !( item is ShadowIronGranite ) && !( item is CopperGranite ) && !( item is BronzeGranite ) && !( item is GoldGranite ) && !( item is AgapiteGranite ) && !( item is VeriteGranite ) && !( item is ValoriteGranite ) && Utility.RandomBool() )
									FindSeaGranite = true;

							bool FindSeaLog = false;
								if ( !( item is Log ) && Utility.RandomBool() )
									FindSeaLog = true;

							bool FindSpecialOre = false;
								if ( ( item is AgapiteOre || item is VeriteOre || item is ValoriteOre ) && Utility.RandomMinMax( 1, 2 ) == 1 )
									FindSpecialOre = true;

							bool FindSpecialGranite = false;
								if ( ( item is AgapiteGranite || item is VeriteGranite || item is ValoriteGranite ) && Utility.RandomMinMax( 1, 2 ) == 1 )
									FindSpecialGranite = true;

							bool FindGhostLog = false;
								if ( (item is WalnutLog) || (item is RosewoodLog) || (item is PineLog) || (item is OakLog) )
									FindGhostLog = true;

							bool FindBlackLog = false;
								if ( (item is AshLog) || (item is CherryLog) || (item is GoldenOakLog) || (item is HickoryLog) || (item is MahoganyLog) )
									FindBlackLog = true;

							bool FindToughLog = false;
								if ( !(item is Log) && item is BaseLog )
									FindToughLog = true;

							if ( item is LesserCurePotion )
							{
								item.Delete();
								item = Loot.RandomPotion( Utility.Random(4)+1, true );
							}
							else if ( item is Brimstone )
							{
								item.Delete();
								item = Loot.RandomPossibleReagent();
							}
							else if ( item is HealScroll )
							{
								item.Delete();
								item = Loot.RandomScroll( Utility.Random(4)+1 );
							}
							else if ( ( Worlds.IsExploringSeaAreas( from ) || reg.IsPartOf( "Shipwreck Grotto" ) || reg.IsPartOf( "Barnacled Cavern" ) || Server.Misc.Worlds.IsSeaTown( from.Location, from.Map ) ) && FindSeaOre && item is BaseOre )
							{
								int nepturiteOre = item.Amount;
								item.Delete();
								item = new NepturiteOre( nepturiteOre );
								from.SendMessage( "You dig up some nepturite ore.");
							}
							else if ( ( Worlds.IsExploringSeaAreas( from ) || reg.IsPartOf( "Shipwreck Grotto" ) || reg.IsPartOf( "Barnacled Cavern" ) ) && FindSeaLog && item is BaseLog )
							{
								int driftWood = item.Amount;
								item.Delete();
								item = new DriftwoodLog( driftWood );
								from.SendMessage( "You chop some driftwood logs.");
							}
							else if ( ( Worlds.IsExploringSeaAreas( from ) || reg.IsPartOf( "Shipwreck Grotto" ) || reg.IsPartOf( "Barnacled Cavern" ) || Server.Misc.Worlds.IsSeaTown( from.Location, from.Map ) ) && FindSeaGranite && item is BaseGranite )
							{
								int nepturiteGranite = item.Amount;
								item.Delete();
								item = new NepturiteGranite( nepturiteGranite );
								from.SendMessage( "You dig up nepturite granite.");
							}
							else if ( from.Land == Land.Underworld && FindSpecialOre && item is BaseOre && from.Map == Map.SavagedEmpire )
							{
								int xormiteOre = item.Amount;
								item.Delete();
								item = new XormiteOre( xormiteOre );
								from.SendMessage( "You dig up some xormite ore.");
							}
							else if ( from.Land == Land.Underworld && FindSpecialOre && item is BaseOre )
							{
								int mithrilOre = item.Amount;
								item.Delete();
								item = new MithrilOre( mithrilOre );
								from.SendMessage( "You dig up some mithril ore.");
							}
							else if ( from.Land == Land.Savaged && FindSpecialOre && item is BaseOre )
							{
								int steelOre = item.Amount;
								item.Delete();
								item = new SteelOre( steelOre );
								from.SendMessage( "You dig up some steel ore.");
							}
							else if ( from.Land == Land.UmberVeil && FindSpecialOre && item is BaseOre )
							{
								int brassOre = item.Amount;
								item.Delete();
								item = new BrassOre( brassOre );
								from.SendMessage( "You dig up some brass ore.");
							}
							else if ( from.Land == Land.Serpent && FindSpecialOre && item is BaseOre )
							{
								int obsidianOre = item.Amount;
								item.Delete();
								item = new ObsidianOre( obsidianOre );
								from.SendMessage( "You dig up some obsidian ore.");
							}
							else if ( from.Land == Land.Underworld && FindSpecialGranite && item is BaseGranite && from.Map == Map.SavagedEmpire )
							{
								int xormiteGranite = item.Amount;
								item.Delete();
								item = new XormiteGranite( xormiteGranite );
								from.SendMessage( "You dig up xormite granite.");
							}
							else if ( from.Land == Land.Underworld && FindSpecialGranite && item is BaseGranite )
							{
								int mithrilGranite = item.Amount;
								item.Delete();
								item = new MithrilGranite( mithrilGranite );
								from.SendMessage( "You dig up mithril granite.");
							}
							else if ( from.Land == Land.Savaged && FindSpecialGranite && item is BaseGranite )
							{
								int steelGranite = item.Amount;
								item.Delete();
								item = new SteelGranite( steelGranite );
								from.SendMessage( "You dig up steel granite.");
							}
							else if ( from.Land == Land.UmberVeil && FindSpecialGranite && item is BaseGranite )
							{
								int brassGranite = item.Amount;
								item.Delete();
								item = new BrassGranite( brassGranite );
								from.SendMessage( "You dig up brass granite.");
							}
							else if ( from.Land == Land.Serpent && FindSpecialGranite && item is BaseGranite )
							{
								int obsidianGranite = item.Amount;
								item.Delete();
								item = new ObsidianGranite( obsidianGranite );
								from.SendMessage( "You dig up obsidian granite.");
							}
							else if ( reg.IsPartOf( typeof( NecromancerRegion ) ) && FindBlackLog && item is BaseLog )
							{
								int blackLog = item.Amount;
								item.Delete();
								item = new EbonyLog( blackLog );
								from.SendMessage( "You chop some ebony logs.");
							}
							else if ( reg.IsPartOf( typeof( NecromancerRegion ) ) && FindGhostLog && item is BaseLog )
							{
								int ghostLog = item.Amount;
								item.Delete();
								item = new GhostLog( ghostLog );
								from.SendMessage( "You chop some ghost logs.");
							}
							else if ( from.Land == Land.Underworld && FindToughLog )
							{
								int toughLog = item.Amount;
								item.Delete();
								item = new PetrifiedLog( toughLog );
								from.SendMessage( "You chop some petrified logs.");
							}

							else if ( item is IronOre ){ from.SendMessage( "You dig up some ore."); }
							else if ( item is DullCopperOre ){ from.SendMessage( "You dig up some dull copper ore."); }
							else if ( item is ShadowIronOre ){ from.SendMessage( "You dig up some shadow iron ore."); }
							else if ( item is CopperOre ){ from.SendMessage( "You dig up some copper ore."); }
							else if ( item is BronzeOre ){ from.SendMessage( "You dig up some bronze ore."); }
							else if ( item is GoldOre ){ from.SendMessage( "You dig up some golden ore."); }
							else if ( item is AgapiteOre ){ from.SendMessage( "You dig up some agapite ore."); }
							else if ( item is VeriteOre ){ from.SendMessage( "You dig up some verite ore."); }
							else if ( item is ValoriteOre ){ from.SendMessage( "You dig up some valorite ore."); }
							else if ( item is DwarvenOre ){ from.SendMessage( "You dig up some dwarven ore."); }

							else if ( item is Granite ){ from.SendMessage( "You dig up granite."); }
							else if ( item is DullCopperGranite ){ from.SendMessage( "You dig up dull copper granite."); }
							else if ( item is ShadowIronGranite ){ from.SendMessage( "You dig up shadow iron granite."); }
							else if ( item is CopperGranite ){ from.SendMessage( "You dig up copper granite."); }
							else if ( item is BronzeGranite ){ from.SendMessage( "You dig up bronze granite."); }
							else if ( item is GoldGranite ){ from.SendMessage( "You dig up golden granite."); }
							else if ( item is AgapiteGranite ){ from.SendMessage( "You dig up agapite granite."); }
							else if ( item is VeriteGranite ){ from.SendMessage( "You dig up verite granite."); }
							else if ( item is ValoriteGranite ){ from.SendMessage( "You dig up valorite granite."); }
							else if ( item is DwarvenGranite ){ from.SendMessage( "You dig up dwarven granite."); }

							else if ( item is Log ){ from.SendMessage( "You chop some logs."); }
							else if ( item is AshLog ){ from.SendMessage( "You chop some ash logs."); }
							else if ( item is CherryLog ){ from.SendMessage( "You chop some cherry logs."); }
							else if ( item is EbonyLog ){ from.SendMessage( "You chop some ebony logs."); }
							else if ( item is GoldenOakLog ){ from.SendMessage( "You chop some golden oak logs."); }
							else if ( item is HickoryLog ){ from.SendMessage( "You chop some hickory logs."); }
							else if ( item is MahoganyLog ){ from.SendMessage( "You chop some mahogany logs."); }
							else if ( item is OakLog ){ from.SendMessage( "You chop some oak logs."); }
							else if ( item is PineLog ){ from.SendMessage( "You chop some pine logs."); }
							else if ( item is RosewoodLog ){ from.SendMessage( "You chop some rosewood logs."); }
							else if ( item is WalnutLog ){ from.SendMessage( "You chop some walnut logs."); }
							else if ( item is ElvenLog ){ from.SendMessage( "You chop some elven logs."); }

							if ( tool is FishingPole && Server.Engines.Harvest.Fishing.IsNearHugeShipWreck( from ) && from.Skills[SkillName.Seafaring].Value >= Utility.RandomMinMax( 1, 250 ) )
							{
								Server.Engines.Harvest.Fishing.FishUpFromMajorWreck( from );
							}
							else if ( tool is FishingPole && Server.Engines.Harvest.Fishing.IsNearSpaceCrash( from ) && from.Skills[SkillName.Seafaring].Value >= Utility.RandomMinMax( 1, 250 ) )
							{
								Server.Engines.Harvest.Fishing.FishUpFromSpaceship( from );
							}
							else if ( tool is FishingPole && Server.Engines.Harvest.Fishing.IsNearUnderwaterRuins( from ) && from.Skills[SkillName.Seafaring].Value >= Utility.RandomMinMax( 1, 250 ) )
							{
								Server.Engines.Harvest.Fishing.FishUpFromRuins( from );
							}
						}
						else if ( item is WritingBook || item is LoreBook || item is DDRelicBook || item is Spellbook || item is ArtifactManual )
						{
							from.SendMessage( "You find a book.");
							if ( item is DDRelicBook ){ item.CoinPrice = item.CoinPrice + Utility.RandomMinMax( 1, (int)(from.Skills[SkillName.Inscribe].Value*2) ); }
							else if ( item is WritingBook ){ item.Name = "Book"; item.ItemID = RandomThings.GetRandomBookItemID(); }
							else if ( item is Spellbook ){ item.Delete(); item = Spellbook.MagicBook(); }
						}
						else if ( item is SomeRandomNote || item is ScrollClue || item is SpellScroll || item is DDRelicScrolls )
						{
							if ( item is WeakenScroll ){ item.Delete(); item = Loot.RandomScroll( 1 ); }
							else if ( item is ProtectionScroll ){ item.Delete(); item = Loot.RandomScroll( Utility.RandomMinMax(2,3) ); }
							else if ( item is UnlockScroll ){ item.Delete(); item = Loot.RandomScroll( Utility.RandomMinMax(4,5) ); }
							else if ( item is CurseScroll ){ item.Delete(); item = Loot.RandomScroll( Utility.RandomMinMax(6,7) ); }
							else if ( item is ParalyzeScroll ){ item.Delete(); item = Loot.RandomScroll( Utility.RandomMinMax(8,9) ); }
							else if ( item is ExplosionScroll ){ item.Delete(); item = Loot.RandomScroll( Utility.RandomMinMax(10,12) ); }

							from.SendMessage( "You find a scroll.");
							if ( item is DDRelicScrolls ){ item.CoinPrice = item.CoinPrice + Utility.RandomMinMax( 1, (int)(from.Skills[SkillName.Inscribe].Value*2) ); }
						}

						bank.Consume( item.Amount, from );

						Give( from, item );
						SendSuccessTo( from, item, resource );

						BonusHarvestResource bonus = def.GetBonusResource();

						if ( bonus != null && bonus.Type != null && skillValue >= bonus.ReqSkill )
						{
							Item bonusItem = Construct( bonus.Type, from );

							Give( from, bonusItem );
							bonus.SendSuccessTo( from );
						}

						if ( tool is IUsesRemaining )
						{
							IUsesRemaining toolWithUses = (IUsesRemaining)tool;

							toolWithUses.ShowUsesRemaining = true;

							if ( toolWithUses.UsesRemaining > 0 )
								--toolWithUses.UsesRemaining;

							if ( toolWithUses.UsesRemaining < 1 )
							{
								tool.Delete();
								def.SendMessageTo( from, def.ToolBrokeMessage );
							}
						}
					}
				}
			}

			if ( type == null )
				def.SendMessageTo( from, def.FailMessage );

			OnHarvestFinished( from, tool, def, vein, bank, resource, toHarvest );
		}

		public virtual void OnHarvestFinished( Mobile from, Item tool, HarvestDefinition def, HarvestVein vein, HarvestBank bank, HarvestResource resource, object harvested )
		{
		}

		public virtual bool SpecialHarvest( Mobile from, Item tool, HarvestDefinition def, Map map, Point3D loc )
		{
			return false;
		}

		public virtual Item Construct( Type type, Mobile from )
		{
			try{ return Activator.CreateInstance( type ) as Item; }
			catch{ return null; }
		}

		public virtual HarvestVein MutateVein( Mobile from, Item tool, HarvestDefinition def, HarvestBank bank, object toHarvest, HarvestVein vein )
		{
			return vein;
		}

		public virtual void SendSuccessTo( Mobile from, Item item, HarvestResource resource )
		{
			resource.SendSuccessTo( from );
		}

		public virtual void SendPackFullTo( Mobile from, Item item, HarvestDefinition def, HarvestResource resource )
		{
			def.SendMessageTo( from, def.PackFullMessage );
		}

		public virtual bool Give( Mobile m, Item item )
		{
			BaseContainer.PutStuffInContainer( m, 3, item );

			if ( item.RootParentEntity == m )
				return true;

			Map map = m.Map;

			if ( map == null )
				return false;

			List<Item> atFeet = new List<Item>();

			foreach ( Item obj in m.GetItemsInRange( 0 ) )
				atFeet.Add( obj );

			for ( int i = 0; i < atFeet.Count; ++i )
			{
				Item check = atFeet[i];

				if ( check.StackWith( m, item, false ) )
					return true;
			}

			item.MoveToWorld( m.Location, map );
			return true;
		}

		public virtual Type MutateType( Type type, Mobile from, Item tool, HarvestDefinition def, Map map, Point3D loc, HarvestResource resource )
		{
			return from.Region.GetResource( type );
		}

		public virtual Type GetResourceType( Mobile from, Item tool, HarvestDefinition def, Map map, Point3D loc, HarvestResource resource )
		{
			if ( resource.Types.Length > 0 )
				return resource.Types[Utility.Random( resource.Types.Length )];

			return null;
		}

		public virtual HarvestResource MutateResource( Mobile from, Item tool, HarvestDefinition def, Map map, Point3D loc, HarvestVein vein, HarvestResource primary, HarvestResource fallback )
		{
			bool racialBonus = (def.RaceBonus && from.Race == Race.Elf );

			if( vein.ChanceToFallback > (Utility.RandomDouble() + (racialBonus ? .20 : 0)) )
				return fallback;

			double skillValue = from.Skills[def.Skill].Value;

			if ( fallback != null && (skillValue < primary.ReqSkill || skillValue < primary.MinSkill) )
				return fallback;

			return primary;
		}

		public virtual bool OnHarvesting( Mobile from, Item tool, HarvestDefinition def, object toHarvest, object locked, bool last )
		{
			if ( !CheckHarvest( from, tool ) )
			{
				from.EndAction( locked );
				return false;
			}

			int tileID;
			Map map;
			Point3D loc;

			if ( !GetHarvestDetails( from, tool, toHarvest, out tileID, out map, out loc ) )
			{
				from.EndAction( locked );
				OnBadHarvestTarget( from, tool, toHarvest );
				return false;
			}
			else if ( !def.Validate( tileID ) )
			{
				from.EndAction( locked );
				OnBadHarvestTarget( from, tool, toHarvest );
				return false;
			}
			else if ( !CheckRange( from, tool, def, map, loc, true ) )
			{
				from.EndAction( locked );
				return false;
			}
			else if ( !CheckResources( from, tool, def, map, loc, true ) )
			{
				from.EndAction( locked );
				return false;
			}
			else if ( !CheckHarvest( from, tool, def, toHarvest ) )
			{
				from.EndAction( locked );
				return false;
			}

			DoHarvestingEffect( from, tool, def, map, loc );

			new HarvestSoundTimer( from, tool, this, def, toHarvest, locked, last ).Start();

			return !last;
		}

		public virtual void DoHarvestingSound( Mobile from, Item tool, HarvestDefinition def, object toHarvest )
		{
			if ( def.EffectSounds.Length > 0 )
				from.PlaySound( Utility.RandomList( def.EffectSounds ) );
		}

		public virtual void DoHarvestingEffect( Mobile from, Item tool, HarvestDefinition def, Map map, Point3D loc )
		{
			from.Direction = from.GetDirectionTo( loc );

			int actions = Utility.RandomList( def.EffectActions );
				if ( tool is Spade || tool is GraveSpade )
				{
					actions = 14;

					if ( from.RaceID > 0 )
						actions = 5;
				}

			if ( !from.Mounted )
				from.Animate( actions, 5, 1, true, false, 0 );
		}

		public virtual HarvestDefinition GetDefinition( int tileID )
		{
			HarvestDefinition def = null;

			for ( int i = 0; def == null && i < m_Definitions.Count; ++i )
			{
				HarvestDefinition check = m_Definitions[i];

				if ( check.Validate( tileID ) )
					def = check;
			}

			return def;
		}

		public virtual void StartHarvesting( Mobile from, Item tool, object toHarvest )
		{
			if ( !CheckHarvest( from, tool ) )
				return;

			int tileID;
			Map map;
			Point3D loc;

			if ( !GetHarvestDetails( from, tool, toHarvest, out tileID, out map, out loc ) )
			{
				OnBadHarvestTarget( from, tool, toHarvest );
				return;
			}

			HarvestDefinition def = GetDefinition( tileID );

			if ( def == null )
			{
				OnBadHarvestTarget( from, tool, toHarvest );
				return;
			}

			if ( !CheckRange( from, tool, def, map, loc, false ) )
				return;
			else if ( !CheckResources( from, tool, def, map, loc, false ) )
				return;
			else if ( !CheckHarvest( from, tool, def, toHarvest ) )
				return;

			object toLock = GetLock( from, tool, def, toHarvest );

			if ( !from.BeginAction( toLock ) )
			{
				OnConcurrentHarvest( from, tool, def, toHarvest );
				return;
			}

			new HarvestTimer( from, tool, this, def, toHarvest, toLock ).Start();
			OnHarvestStarted( from, tool, def, toHarvest );
		}

		public virtual bool GetHarvestDetails( Mobile from, Item tool, object toHarvest, out int tileID, out Map map, out Point3D loc )
		{
			if ( toHarvest is Static && !((Static)toHarvest).Movable )
			{
				Static obj = (Static)toHarvest;
				tileID = (obj.ItemID & 0x3FFF) | 0x4000;
				map = obj.Map;
				loc = obj.GetWorldLocation();
			}
			else if ( toHarvest is StaticTarget )
			{
				StaticTarget obj = (StaticTarget)toHarvest;
				tileID = (obj.ItemID & 0x3FFF) | 0x4000;
				map = from.Map;
				loc = obj.Location;
			}
			else if ( toHarvest is LandTarget )
			{
				LandTarget obj = (LandTarget)toHarvest;
				tileID = obj.TileID;
				map = from.Map;
				loc = obj.Location;
			}
			else
			{
				tileID = 0;
				map = null;
				loc = Point3D.Zero;
				return false;
			}

			return ( map != null && map != Map.Internal );
		}
	}
}

namespace Server
{
	public interface IChopable
	{
		void OnChop( Mobile from );
	}

	[AttributeUsage( AttributeTargets.Class )]
	public class FurnitureAttribute : Attribute
	{
		public static bool Check( Item item )
		{
			return ( item != null && item.GetType().IsDefined( typeof( FurnitureAttribute ), false ) );
		}

		public FurnitureAttribute()
		{
		}
	}
}