using System;
using Server.Items;
using Server.Network;
using Server.Targeting;
using Server.Engines.Craft;
using Server.Mobiles;

namespace Server.Items
{
	public abstract class BaseOre : Item
	{
		public override string DefaultDescription{ get{ return "These rocks can be smelted at a forge, which will create metal ingots. The ingots can then be used for crafting."; } }

		public override Catalogs DefaultCatalog{ get{ return Catalogs.Crafting; } }

		public override double DefaultWeight
		{
			get { return 0.5; }
		}

		public abstract Item GetIngot();

		public override void Serialize( GenericWriter writer )
		{
			base.Serialize( writer );
			writer.Write( (int) 2 ); // version
		}

		public override void Deserialize( GenericReader reader )
		{
			base.Deserialize( reader );
			int version = reader.ReadInt();

			if ( version < 2 )
				m_Resource = (CraftResource)reader.ReadInt();

			Hue = CraftResources.GetHue( m_Resource );
			Name = CraftResources.GetTradeItemFullName( this, m_Resource, true, false, null );
			Built = true;
		}

		public BaseOre( CraftResource resource ) : this( resource, 1 )
		{
		}

		public BaseOre( CraftResource resource, int amount ) : base( 0x19B9 )
		{
			Stackable = true;
			Amount = amount;
			m_Resource = resource;
			Hue = CraftResources.GetHue( resource );
			Name = CraftResources.GetTradeItemFullName( this, resource, true, false, null );
			Built = true;
		}

		public BaseOre( Serial serial ) : base( serial )
		{
		}

		public override void OnDoubleClick( Mobile from )
		{
			if ( !Movable )
				return;
			
			if ( RootParent is BaseCreature )
			{
				from.SendLocalizedMessage( 500447 ); // That is not accessible
				return;
			}
			else if ( from.InRange( this.GetWorldLocation(), 2 ) )
			{
				from.SendLocalizedMessage( 501971 ); // Select the forge on which to smelt the ore, or another pile of ore with which to combine it.
				from.Target = new InternalTarget( this );
			}
			else
			{
				from.SendLocalizedMessage( 501976 ); // The ore is too far away.
			}
		}

		private class InternalTarget : Target
		{
			private BaseOre m_Ore;

			public InternalTarget( BaseOre ore ) :  base ( 2, false, TargetFlags.None )
			{
				m_Ore = ore;
			}

			protected override void OnTarget( Mobile from, object targeted )
			{
				if ( m_Ore.Deleted )
					return;

				if ( !from.InRange( m_Ore.GetWorldLocation(), 2 ) )
				{
					from.SendLocalizedMessage( 501976 ); // The ore is too far away.
					return;
				}
				
				#region Combine Ore
				if ( targeted is BaseOre )
				{
					BaseOre ore = (BaseOre)targeted;
					if ( !ore.Movable )
						return;
					else if ( m_Ore == ore )
					{
						from.SendLocalizedMessage( 501972 ); // Select another pile or ore with which to combine this.
						from.Target = new InternalTarget( ore );
						return;
					}
					else if ( ore.Resource != m_Ore.Resource )
					{
						from.SendLocalizedMessage( 501979 ); // You cannot combine ores of different metals.
						return;
					}

					int worth = ore.Amount;
					if ( ore.ItemID == 0x19B9 )
						worth *= 8;
					else if ( ore.ItemID == 0x19B7 )
						worth *= 2;
					else 
						worth *= 4;
					int sourceWorth = m_Ore.Amount;
					if ( m_Ore.ItemID == 0x19B9 )
						sourceWorth *= 8;
					else if ( m_Ore.ItemID == 0x19B7 )
						sourceWorth *= 2;
					else
						sourceWorth *= 4;
					worth += sourceWorth;

					int plusWeight = 0;
					int newID = ore.ItemID;
					if ( ore.DefaultWeight != m_Ore.DefaultWeight )
					{
						if ( ore.ItemID == 0x19B7 || m_Ore.ItemID == 0x19B7 )
						{
							newID = 0x19B7;
						}
						else if ( ore.ItemID == 0x19B9 )
						{
							newID = m_Ore.ItemID;
							plusWeight = (int)(ore.Amount * 0.5);
						}
						else
						{
							plusWeight = (int)(ore.Amount * 0.5);
						}
					}

					if ( (ore.ItemID == 0x19B9 && worth > 120000) || (( ore.ItemID == 0x19B8 || ore.ItemID == 0x19BA ) && worth > 60000) || (ore.ItemID == 0x19B7 && worth > 30000))
					{
						from.SendLocalizedMessage( 1062844 ); // There is too much ore to combine.
						return;
					}
					else if ( ore.RootParent is Mobile && (plusWeight + ((Mobile)ore.RootParent).Backpack.TotalWeight) > ((Mobile)ore.RootParent).Backpack.MaxWeight )
					{ 
						from.SendLocalizedMessage( 501978 ); // The weight is too great to combine in a container.
						return;
					}

					ore.ItemID = newID;
					if ( ore.ItemID == 0x19B9 )
					{
						ore.Amount = worth / 8;
						m_Ore.Delete();
					}
					else if ( ore.ItemID == 0x19B7 )
					{
						ore.Amount = worth / 2;
						m_Ore.Delete();
					}
					else
					{
						ore.Amount = worth / 4;
						m_Ore.Delete();
					}	
					return;
				}
				#endregion

				if ( Server.Engines.Craft.DefBlacksmithy.IsForge( targeted ) )
				{
					double difficulty = CraftResources.GetSkill( m_Ore.Resource );

					if ( difficulty < 50.0 )
						difficulty = 50.0;

					double minSkill = difficulty - 25.0;
					double maxSkill = difficulty + 25.0;
					
					if ( difficulty > 50.0 && difficulty > from.Skills[SkillName.Mining].Value )
					{
						from.SendLocalizedMessage( 501986 ); // You have no idea how to smelt this strange ore!
						return;
					}
					
					if ( m_Ore.Amount <= 1 && m_Ore.ItemID == 0x19B7 )
					{
						from.SendLocalizedMessage( 501987 ); // There is not enough metal-bearing ore in this pile to make an ingot.
						return;
					}

					if ( from.CheckTargetSkill( SkillName.Mining, targeted, minSkill, maxSkill ) )
					{
						if ( m_Ore.Amount <= 0 )
						{
							from.SendLocalizedMessage( 501987 ); // There is not enough metal-bearing ore in this pile to make an ingot.
						}
						else
						{
							int amount = m_Ore.Amount;
							if ( m_Ore.Amount > 30000 )
								amount = 30000;

							Item ingot = m_Ore.GetIngot();
							
							if ( m_Ore.ItemID == 0x19B7 )
							{
								if ( m_Ore.Amount % 2 == 0 )
								{
									amount /= 2;
									m_Ore.Delete();
								}
								else
								{
									amount /= 2;
									m_Ore.Amount = 1;
								}
							}
								
							else if ( m_Ore.ItemID == 0x19B9 )
							{
								amount *= 2;
								m_Ore.Delete();
							}
							
							else
							{
								amount /= 1;
								m_Ore.Delete();
							}

							ingot.Amount = amount;
							from.AddToBackpack( ingot );
							from.PlaySound( 0x208 );

							from.SendLocalizedMessage( 501988 ); // You smelt the ore removing the impurities and put the metal in your backpack.
						}
					}
					else if ( m_Ore.Amount < 2 && m_Ore.ItemID == 0x19B9 )
					{
						from.SendLocalizedMessage( 501990 ); // You burn away the impurities but are left with less useable metal.
						m_Ore.ItemID = 0x19B8;
						from.PlaySound( 0x208 );
					}
					else if ( m_Ore.Amount < 2 && m_Ore.ItemID == 0x19B8 || m_Ore.ItemID == 0x19BA )
					{
						from.SendLocalizedMessage( 501990 ); // You burn away the impurities but are left with less useable metal.
						m_Ore.ItemID = 0x19B7;
						from.PlaySound( 0x208 );
					}
					else
					{
						from.SendLocalizedMessage( 501990 ); // You burn away the impurities but are left with less useable metal.
						m_Ore.Amount /= 2;
						from.PlaySound( 0x208 );
					}
				}
			}
		}
	}

	public class IronOre : BaseOre
	{
		[Constructable]
		public IronOre() : this( 1 )
		{
		}

		[Constructable]
		public IronOre( int amount ) : base( CraftResource.Iron, amount )
		{
		}

		public IronOre( Serial serial ) : base( serial )
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
		}

		public override Item GetIngot()
		{
			return new IronIngot();
		}
	}

	public class DullCopperOre : BaseOre
	{
		[Constructable]
		public DullCopperOre() : this( 1 )
		{
		}

		[Constructable]
		public DullCopperOre( int amount ) : base( CraftResource.DullCopper, amount )
		{
		}

		public DullCopperOre( Serial serial ) : base( serial )
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
		}

		public override Item GetIngot()
		{
			return new DullCopperIngot();
		}
	}

	public class ShadowIronOre : BaseOre
	{
		[Constructable]
		public ShadowIronOre() : this( 1 )
		{
		}

		[Constructable]
		public ShadowIronOre( int amount ) : base( CraftResource.ShadowIron, amount )
		{
		}

		public ShadowIronOre( Serial serial ) : base( serial )
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
		}

		public override Item GetIngot()
		{
			return new ShadowIronIngot();
		}
	}

	public class CopperOre : BaseOre
	{
		[Constructable]
		public CopperOre() : this( 1 )
		{
		}

		[Constructable]
		public CopperOre( int amount ) : base( CraftResource.Copper, amount )
		{
		}

		public CopperOre( Serial serial ) : base( serial )
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
		}

		public override Item GetIngot()
		{
			return new CopperIngot();
		}
	}

	public class BronzeOre : BaseOre
	{
		[Constructable]
		public BronzeOre() : this( 1 )
		{
		}

		[Constructable]
		public BronzeOre( int amount ) : base( CraftResource.Bronze, amount )
		{
		}

		public BronzeOre( Serial serial ) : base( serial )
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
		}

		public override Item GetIngot()
		{
			return new BronzeIngot();
		}
	}

	public class GoldOre : BaseOre
	{
		[Constructable]
		public GoldOre() : this( 1 )
		{
		}

		[Constructable]
		public GoldOre( int amount ) : base( CraftResource.Gold, amount )
		{
		}

		public GoldOre( Serial serial ) : base( serial )
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
		}

		public override Item GetIngot()
		{
			return new GoldIngot();
		}
	}

	public class AgapiteOre : BaseOre
	{
		[Constructable]
		public AgapiteOre() : this( 1 )
		{
		}

		[Constructable]
		public AgapiteOre( int amount ) : base( CraftResource.Agapite, amount )
		{
		}

		public AgapiteOre( Serial serial ) : base( serial )
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
		}

		public override Item GetIngot()
		{
			return new AgapiteIngot();
		}
	}

	public class VeriteOre : BaseOre
	{
		[Constructable]
		public VeriteOre() : this( 1 )
		{
		}

		[Constructable]
		public VeriteOre( int amount ) : base( CraftResource.Verite, amount )
		{
		}

		public VeriteOre( Serial serial ) : base( serial )
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
		}

		public override Item GetIngot()
		{
			return new VeriteIngot();
		}
	}

	public class ValoriteOre : BaseOre
	{
		[Constructable]
		public ValoriteOre() : this( 1 )
		{
		}

		[Constructable]
		public ValoriteOre( int amount ) : base( CraftResource.Valorite, amount )
		{
		}

		public ValoriteOre( Serial serial ) : base( serial )
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
		}

		public override Item GetIngot()
		{
			return new ValoriteIngot();
		}
	}

	public class ObsidianOre : BaseOre
	{
		[Constructable]
		public ObsidianOre() : this( 1 )
		{
		}

		[Constructable]
		public ObsidianOre( int amount ) : base( CraftResource.Obsidian, amount )
		{
		}

		public ObsidianOre( Serial serial ) : base( serial )
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
		}

		public override Item GetIngot()
		{
			return new ObsidianIngot();
		}
	}

	public class MithrilOre : BaseOre
	{
		[Constructable]
		public MithrilOre() : this( 1 )
		{
		}

		[Constructable]
		public MithrilOre( int amount ) : base( CraftResource.Mithril, amount )
		{
		}

		public MithrilOre( Serial serial ) : base( serial )
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
		}

		public override Item GetIngot()
		{
			return new MithrilIngot();
		}
	}

	public class DwarvenOre : BaseOre
	{
		[Constructable]
		public DwarvenOre() : this( 1 )
		{
		}

		[Constructable]
		public DwarvenOre( int amount ) : base( CraftResource.Dwarven, amount )
		{
		}

		public DwarvenOre( Serial serial ) : base( serial )
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
		}

		public override Item GetIngot()
		{
			return new DwarvenIngot();
		}
	}

	public class XormiteOre : BaseOre
	{
		[Constructable]
		public XormiteOre() : this( 1 )
		{
		}

		[Constructable]
		public XormiteOre( int amount ) : base( CraftResource.Xormite, amount )
		{
		}

		public XormiteOre( Serial serial ) : base( serial )
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
		}

		public override Item GetIngot()
		{
			return new XormiteIngot();
		}
	}

	public class NepturiteOre : BaseOre
	{
		[Constructable]
		public NepturiteOre() : this( 1 )
		{
		}

		[Constructable]
		public NepturiteOre( int amount ) : base( CraftResource.Nepturite, amount )
		{
		}

		public NepturiteOre( Serial serial ) : base( serial )
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
		}

		public override Item GetIngot()
		{
			return new NepturiteIngot();
		}
	}

	public class SteelOre : BaseOre
	{
		[Constructable]
		public SteelOre() : this( 1 )
		{
		}

		[Constructable]
		public SteelOre( int amount ) : base( CraftResource.Steel, amount )
		{
		}

		public SteelOre( Serial serial ) : base( serial )
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
		}

		public override Item GetIngot()
		{
			return new SteelIngot();
		}
	}

	public class BrassOre : BaseOre
	{
		[Constructable]
		public BrassOre() : this( 1 )
		{
		}

		[Constructable]
		public BrassOre( int amount ) : base( CraftResource.Brass, amount )
		{
		}

		public BrassOre( Serial serial ) : base( serial )
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
		}

		public override Item GetIngot()
		{
			return new BrassIngot();
		}
	}

	public class AmethystStone : BaseOre
	{
		[Constructable]
		public AmethystStone() : this( 1 )
		{
		}

		[Constructable]
		public AmethystStone( int amount ) : base( CraftResource.AmethystBlock, amount )
		{
		}

		public AmethystStone( Serial serial ) : base( serial )
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
		}

		public override Item GetIngot()
		{
			return new AmethystBlocks();
		}
	}

	public class EmeraldStone : BaseOre
	{
		[Constructable]
		public EmeraldStone() : this( 1 )
		{
		}

		[Constructable]
		public EmeraldStone( int amount ) : base( CraftResource.EmeraldBlock, amount )
		{
		}

		public EmeraldStone( Serial serial ) : base( serial )
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
		}

		public override Item GetIngot()
		{
			return new EmeraldBlocks();
		}
	}

	public class GarnetStone : BaseOre
	{
		[Constructable]
		public GarnetStone() : this( 1 )
		{
		}

		[Constructable]
		public GarnetStone( int amount ) : base( CraftResource.GarnetBlock, amount )
		{
		}

		public GarnetStone( Serial serial ) : base( serial )
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
		}

		public override Item GetIngot()
		{
			return new GarnetBlocks();
		}
	}

	public class IceStone : BaseOre
	{
		[Constructable]
		public IceStone() : this( 1 )
		{
		}

		[Constructable]
		public IceStone( int amount ) : base( CraftResource.IceBlock, amount )
		{
		}

		public IceStone( Serial serial ) : base( serial )
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
		}

		public override Item GetIngot()
		{
			return new IceBlocks();
		}
	}

	public class JadeStone : BaseOre
	{
		[Constructable]
		public JadeStone() : this( 1 )
		{
		}

		[Constructable]
		public JadeStone( int amount ) : base( CraftResource.JadeBlock, amount )
		{
		}

		public JadeStone( Serial serial ) : base( serial )
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
		}

		public override Item GetIngot()
		{
			return new JadeBlocks();
		}
	}

	public class MarbleStone : BaseOre
	{
		[Constructable]
		public MarbleStone() : this( 1 )
		{
		}

		[Constructable]
		public MarbleStone( int amount ) : base( CraftResource.MarbleBlock, amount )
		{
		}

		public MarbleStone( Serial serial ) : base( serial )
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
		}

		public override Item GetIngot()
		{
			return new MarbleBlocks();
		}
	}

	public class OnyxStone : BaseOre
	{
		[Constructable]
		public OnyxStone() : this( 1 )
		{
		}

		[Constructable]
		public OnyxStone( int amount ) : base( CraftResource.OnyxBlock, amount )
		{
		}

		public OnyxStone( Serial serial ) : base( serial )
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
		}

		public override Item GetIngot()
		{
			return new OnyxBlocks();
		}
	}

	public class QuartzStone : BaseOre
	{
		[Constructable]
		public QuartzStone() : this( 1 )
		{
		}

		[Constructable]
		public QuartzStone( int amount ) : base( CraftResource.QuartzBlock, amount )
		{
		}

		public QuartzStone( Serial serial ) : base( serial )
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
		}

		public override Item GetIngot()
		{
			return new QuartzBlocks();
		}
	}

	public class RubyStone : BaseOre
	{
		[Constructable]
		public RubyStone() : this( 1 )
		{
		}

		[Constructable]
		public RubyStone( int amount ) : base( CraftResource.RubyBlock, amount )
		{
		}

		public RubyStone( Serial serial ) : base( serial )
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
		}

		public override Item GetIngot()
		{
			return new RubyBlocks();
		}
	}

	public class SapphireStone : BaseOre
	{
		[Constructable]
		public SapphireStone() : this( 1 )
		{
		}

		[Constructable]
		public SapphireStone( int amount ) : base( CraftResource.SapphireBlock, amount )
		{
		}

		public SapphireStone( Serial serial ) : base( serial )
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
		}

		public override Item GetIngot()
		{
			return new SapphireBlocks();
		}
	}

	public class SilverStone : BaseOre
	{
		[Constructable]
		public SilverStone() : this( 1 )
		{
		}

		[Constructable]
		public SilverStone( int amount ) : base( CraftResource.SilverBlock, amount )
		{
		}

		public SilverStone( Serial serial ) : base( serial )
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
		}

		public override Item GetIngot()
		{
			return new SilverBlocks();
		}
	}

	public class SpinelStone : BaseOre
	{
		[Constructable]
		public SpinelStone() : this( 1 )
		{
		}

		[Constructable]
		public SpinelStone( int amount ) : base( CraftResource.SpinelBlock, amount )
		{
		}

		public SpinelStone( Serial serial ) : base( serial )
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
		}

		public override Item GetIngot()
		{
			return new SpinelBlocks();
		}
	}

	public class StarRubyStone : BaseOre
	{
		[Constructable]
		public StarRubyStone() : this( 1 )
		{
		}

		[Constructable]
		public StarRubyStone( int amount ) : base( CraftResource.StarRubyBlock, amount )
		{
		}

		public StarRubyStone( Serial serial ) : base( serial )
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
		}

		public override Item GetIngot()
		{
			return new StarRubyBlocks();
		}
	}

	public class TopazStone : BaseOre
	{
		[Constructable]
		public TopazStone() : this( 1 )
		{
		}

		[Constructable]
		public TopazStone( int amount ) : base( CraftResource.TopazBlock, amount )
		{
		}

		public TopazStone( Serial serial ) : base( serial )
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
		}

		public override Item GetIngot()
		{
			return new TopazBlocks();
		}
	}

	public class CaddelliteStone : BaseOre
	{
		[Constructable]
		public CaddelliteStone() : this( 1 )
		{
		}

		[Constructable]
		public CaddelliteStone( int amount ) : base( CraftResource.CaddelliteBlock, amount )
		{
		}

		public CaddelliteStone( Serial serial ) : base( serial )
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
		}

		public override Item GetIngot()
		{
			return new CaddelliteBlocks();
		}
	}
}