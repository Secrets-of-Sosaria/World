using System;

namespace Server.Items
{
	public abstract class BaseShirt : BaseClothing
	{
		public BaseShirt( int itemID ) : this( itemID, 0 )
		{
		}

		public BaseShirt( int itemID, int hue ) : base( itemID, Layer.Shirt, hue )
		{
		}

		public BaseShirt( Serial serial ) : base( serial )
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

	[FlipableAttribute( 0x1efd, 0x1efe )]
	public class FancyShirt : BaseShirt
	{
		[Constructable]
		public FancyShirt() : this( 0 )
		{
		}

		[Constructable]
		public FancyShirt( int hue ) : base( 0x1EFD, hue )
		{
			Weight = 2.0;
		}

		public FancyShirt( Serial serial ) : base( serial )
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

	public class RoyalCoat : BaseShirt
	{
		[Constructable]
		public RoyalCoat() : this( 0 )
		{
		}

		[Constructable]
		public RoyalCoat( int hue ) : base( 0x307, hue )
		{
			Name = "royal coat";
			Weight = 2.0;
		}

		public RoyalCoat( Serial serial ) : base( serial )
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

	public class SquireShirt : BaseShirt
	{
		[Constructable]
		public SquireShirt() : this( 0 )
		{
		}

		[Constructable]
		public SquireShirt( int hue ) : base( 0x311, hue )
		{
			Name = "squire shirt";
			Weight = 2.0;
		}

		public SquireShirt( Serial serial ) : base( serial )
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

	public class FormalCoat : BaseShirt
	{
		[Constructable]
		public FormalCoat() : this( 0 )
		{
		}

		[Constructable]
		public FormalCoat( int hue ) : base( 0x403, hue )
		{
			Name = "formal coat";
			Weight = 2.0;
		}

		public FormalCoat( Serial serial ) : base( serial )
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

	public class WizardShirt : BaseShirt
	{
		[Constructable]
		public WizardShirt() : this( 0 )
		{
		}

		[Constructable]
		public WizardShirt( int hue ) : base( 0x407, hue )
		{
			Name = "wizard shirt";
			Weight = 2.0;
		}

		public WizardShirt( Serial serial ) : base( serial )
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

	public class Shirt : BaseShirt
	{
		[Constructable]
		public Shirt() : this( 0 )
		{
		}

		[Constructable]
		public Shirt( int hue ) : base( 0x1517, hue )
		{
			Weight = 1.0;
			Name = "shirt";
			Utility.RandomList( 0x63B5, 0x1517, 0x1518 );
		}

		public Shirt( Serial serial ) : base( serial )
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

	public class BeggarVest : BaseShirt
	{
		[Constructable]
		public BeggarVest() : this( 0 )
		{
		}

		[Constructable]
		public BeggarVest( int hue ) : base( 0x308, hue )
		{
			Name = "beggar vest";
			Weight = 1.0;
		}

		public BeggarVest( Serial serial ) : base( serial )
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

	public class RoyalVest : BaseShirt
	{
		[Constructable]
		public RoyalVest() : this( 0 )
		{
		}

		[Constructable]
		public RoyalVest( int hue ) : base( 0x30C, hue )
		{
			Name = "royal vest";
			Weight = 1.0;
		}

		public RoyalVest( Serial serial ) : base( serial )
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

	public class RusticVest : BaseShirt
	{
		[Constructable]
		public RusticVest() : this( 0 )
		{
		}

		[Constructable]
		public RusticVest( int hue ) : base( 0x30E, hue )
		{
			Name = "rustic vest";
			Weight = 1.0;
		}

		public RusticVest( Serial serial ) : base( serial )
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

	[Flipable( 0x2794, 0x27DF )]
	public class ClothNinjaJacket : BaseShirt
	{
		[Constructable]
		public ClothNinjaJacket() : this( 0 )
		{
		}

		[Constructable]
		public ClothNinjaJacket( int hue ) : base( 0x2794, hue )
		{
			Weight = 5.0;
			Layer = Layer.InnerTorso;
		}

		public ClothNinjaJacket( Serial serial ) : base( serial )
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