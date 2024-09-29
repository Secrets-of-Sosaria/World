using System;
using Server.Items;
using Server.Network;

namespace Server.Items
{
	public abstract class BaseSkeletal : Item
	{
		public override string DefaultDescription{ get{ return "Undertakers use these bones to create morbid looking armor."; } }

		public override Catalogs DefaultCatalog{ get{ return Catalogs.Crafting; } }

		public override double DefaultWeight
		{
			get { return 0.1; }
		}

		public override void Serialize( GenericWriter writer )
		{
			base.Serialize( writer );
			writer.Write( (int) 1 ); // version
		}

		public override void Deserialize( GenericReader reader )
		{
			base.Deserialize( reader );
			int version = reader.ReadInt();
			Name = CraftResources.GetTradeItemFullName( this, m_Resource, false, false, null );
			Built = true;
		}

		public BaseSkeletal( CraftResource resource ) : this( resource, 1 )
		{
		}

		public BaseSkeletal( CraftResource resource, int amount ) : base( 0x22C3 )
		{
			Stackable = true;
			Amount = amount;
			m_Resource = resource;
			Hue = CraftResources.GetHue( resource );
			Name = CraftResources.GetTradeItemFullName( this, m_Resource, false, false, null );
			Built = true;
		}

		public BaseSkeletal( Serial serial ) : base( serial )
		{
		}
	}

	public class BrittleSkeletal : BaseSkeletal
	{
		[Constructable]
		public BrittleSkeletal() : this( 1 )
		{
		}

		[Constructable]
		public BrittleSkeletal( int amount ) : base( CraftResource.BrittleSkeletal, amount )
		{
		}

		public BrittleSkeletal( Serial serial ) : base( serial )
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
	}

	public class DrowSkeletal : BaseSkeletal
	{
		[Constructable]
		public DrowSkeletal() : this( 1 )
		{
		}

		[Constructable]
		public DrowSkeletal( int amount ) : base( CraftResource.DrowSkeletal, amount )
		{
		}

		public DrowSkeletal( Serial serial ) : base( serial )
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
	}

	public class OrcSkeletal : BaseSkeletal
	{
		[Constructable]
		public OrcSkeletal() : this( 1 )
		{
		}

		[Constructable]
		public OrcSkeletal( int amount ) : base( CraftResource.OrcSkeletal, amount )
		{
		}

		public OrcSkeletal( Serial serial ) : base( serial )
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
	}

	public class ReptileSkeletal : BaseSkeletal
	{
		[Constructable]
		public ReptileSkeletal() : this( 1 )
		{
		}

		[Constructable]
		public ReptileSkeletal( int amount ) : base( CraftResource.ReptileSkeletal, amount )
		{
		}

		public ReptileSkeletal( Serial serial ) : base( serial )
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
	}

	public class OgreSkeletal : BaseSkeletal
	{
		[Constructable]
		public OgreSkeletal() : this( 1 )
		{
		}

		[Constructable]
		public OgreSkeletal( int amount ) : base( CraftResource.OgreSkeletal, amount )
		{
		}

		public OgreSkeletal( Serial serial ) : base( serial )
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
	}

	public class TrollSkeletal : BaseSkeletal
	{
		[Constructable]
		public TrollSkeletal() : this( 1 )
		{
		}

		[Constructable]
		public TrollSkeletal( int amount ) : base( CraftResource.TrollSkeletal, amount )
		{
		}

		public TrollSkeletal( Serial serial ) : base( serial )
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
	}

	public class GargoyleSkeletal : BaseSkeletal
	{
		[Constructable]
		public GargoyleSkeletal() : this( 1 )
		{
		}

		[Constructable]
		public GargoyleSkeletal( int amount ) : base( CraftResource.GargoyleSkeletal, amount )
		{
		}

		public GargoyleSkeletal( Serial serial ) : base( serial )
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
	}

	public class MinotaurSkeletal : BaseSkeletal
	{
		[Constructable]
		public MinotaurSkeletal() : this( 1 )
		{
		}

		[Constructable]
		public MinotaurSkeletal( int amount ) : base( CraftResource.MinotaurSkeletal, amount )
		{
		}

		public MinotaurSkeletal( Serial serial ) : base( serial )
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
	}

	public class LycanSkeletal : BaseSkeletal
	{
		[Constructable]
		public LycanSkeletal() : this( 1 )
		{
		}

		[Constructable]
		public LycanSkeletal( int amount ) : base( CraftResource.LycanSkeletal, amount )
		{
		}

		public LycanSkeletal( Serial serial ) : base( serial )
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
	}

	public class SharkSkeletal : BaseSkeletal
	{
		[Constructable]
		public SharkSkeletal() : this( 1 )
		{
		}

		[Constructable]
		public SharkSkeletal( int amount ) : base( CraftResource.SharkSkeletal, amount )
		{
		}

		public SharkSkeletal( Serial serial ) : base( serial )
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
	}

	public class ColossalSkeletal : BaseSkeletal
	{
		[Constructable]
		public ColossalSkeletal() : this( 1 )
		{
		}

		[Constructable]
		public ColossalSkeletal( int amount ) : base( CraftResource.ColossalSkeletal, amount )
		{
		}

		public ColossalSkeletal( Serial serial ) : base( serial )
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
	}

	public class MysticalSkeletal : BaseSkeletal
	{
		[Constructable]
		public MysticalSkeletal() : this( 1 )
		{
		}

		[Constructable]
		public MysticalSkeletal( int amount ) : base( CraftResource.MysticalSkeletal, amount )
		{
		}

		public MysticalSkeletal( Serial serial ) : base( serial )
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
	}

	public class VampireSkeletal : BaseSkeletal
	{
		[Constructable]
		public VampireSkeletal() : this( 1 )
		{
		}

		[Constructable]
		public VampireSkeletal( int amount ) : base( CraftResource.VampireSkeletal, amount )
		{
		}

		public VampireSkeletal( Serial serial ) : base( serial )
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
	}

	public class LichSkeletal : BaseSkeletal
	{
		[Constructable]
		public LichSkeletal() : this( 1 )
		{
		}

		[Constructable]
		public LichSkeletal( int amount ) : base( CraftResource.LichSkeletal, amount )
		{
		}

		public LichSkeletal( Serial serial ) : base( serial )
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
	}

	public class SphinxSkeletal : BaseSkeletal
	{
		[Constructable]
		public SphinxSkeletal() : this( 1 )
		{
		}

		[Constructable]
		public SphinxSkeletal( int amount ) : base( CraftResource.SphinxSkeletal, amount )
		{
		}

		public SphinxSkeletal( Serial serial ) : base( serial )
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
	}

	public class DevilSkeletal : BaseSkeletal
	{
		[Constructable]
		public DevilSkeletal() : this( 1 )
		{
		}

		[Constructable]
		public DevilSkeletal( int amount ) : base( CraftResource.DevilSkeletal, amount )
		{
			ItemID = 0x661A;
		}

		public DevilSkeletal( Serial serial ) : base( serial )
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
	}

	public class DracoSkeletal : BaseSkeletal
	{
		[Constructable]
		public DracoSkeletal() : this( 1 )
		{
		}

		[Constructable]
		public DracoSkeletal( int amount ) : base( CraftResource.DracoSkeletal, amount )
		{
			ItemID = 0x661A;
		}

		public DracoSkeletal( Serial serial ) : base( serial )
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
	}

	public class XenoSkeletal : BaseSkeletal
	{
		[Constructable]
		public XenoSkeletal() : this( 1 )
		{
		}

		[Constructable]
		public XenoSkeletal( int amount ) : base( CraftResource.XenoSkeletal, amount )
		{
		}

		public XenoSkeletal( Serial serial ) : base( serial )
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
	}

	public class AndorianSkeletal : BaseSkeletal
	{
		[Constructable]
		public AndorianSkeletal() : this( 1 )
		{
		}

		[Constructable]
		public AndorianSkeletal( int amount ) : base( CraftResource.AndorianSkeletal, amount )
		{
		}

		public AndorianSkeletal( Serial serial ) : base( serial )
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
	}

	public class CardassianSkeletal : BaseSkeletal
	{
		[Constructable]
		public CardassianSkeletal() : this( 1 )
		{
		}

		[Constructable]
		public CardassianSkeletal( int amount ) : base( CraftResource.CardassianSkeletal, amount )
		{
		}

		public CardassianSkeletal( Serial serial ) : base( serial )
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
	}

	public class MartianSkeletal : BaseSkeletal
	{
		[Constructable]
		public MartianSkeletal() : this( 1 )
		{
		}

		[Constructable]
		public MartianSkeletal( int amount ) : base( CraftResource.MartianSkeletal, amount )
		{
		}

		public MartianSkeletal( Serial serial ) : base( serial )
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
	}

	public class RodianSkeletal : BaseSkeletal
	{
		[Constructable]
		public RodianSkeletal() : this( 1 )
		{
		}

		[Constructable]
		public RodianSkeletal( int amount ) : base( CraftResource.RodianSkeletal, amount )
		{
		}

		public RodianSkeletal( Serial serial ) : base( serial )
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
	}

	public class TuskenSkeletal : BaseSkeletal
	{
		[Constructable]
		public TuskenSkeletal() : this( 1 )
		{
		}

		[Constructable]
		public TuskenSkeletal( int amount ) : base( CraftResource.TuskenSkeletal, amount )
		{
		}

		public TuskenSkeletal( Serial serial ) : base( serial )
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
	}

	public class TwilekSkeletal : BaseSkeletal
	{
		[Constructable]
		public TwilekSkeletal() : this( 1 )
		{
		}

		[Constructable]
		public TwilekSkeletal( int amount ) : base( CraftResource.TwilekSkeletal, amount )
		{
		}

		public TwilekSkeletal( Serial serial ) : base( serial )
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
	}

	public class XindiSkeletal : BaseSkeletal
	{
		[Constructable]
		public XindiSkeletal() : this( 1 )
		{
		}

		[Constructable]
		public XindiSkeletal( int amount ) : base( CraftResource.XindiSkeletal, amount )
		{
		}

		public XindiSkeletal( Serial serial ) : base( serial )
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
	}

	public class ZabrakSkeletal : BaseSkeletal
	{
		[Constructable]
		public ZabrakSkeletal() : this( 1 )
		{
		}

		[Constructable]
		public ZabrakSkeletal( int amount ) : base( CraftResource.ZabrakSkeletal, amount )
		{
		}

		public ZabrakSkeletal( Serial serial ) : base( serial )
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
	}
}