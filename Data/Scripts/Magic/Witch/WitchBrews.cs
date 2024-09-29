using System;
using Server;
using Server.Items;
using System.Collections;
using System.Collections.Generic;

namespace Server.Items
{
	public class BloodPactScroll : SpellScroll
	{
		public override Catalogs DefaultCatalog{ get{ return Catalogs.Potion; } }

		[Constructable]
		public BloodPactScroll() : this( 1 )
		{
		}

		public override string DefaultDescription{ get{ return BookWitchBrewing.BookGump.potionDesc( 10 ); } }
		
		[Constructable]
		public BloodPactScroll( int amount ) : base( 140, 0x282F, amount )
		{
			Name = "blood pact elixir";
			Hue = 0x5B5;
		}

		public BloodPactScroll( Serial serial ) : base( serial )
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
			ItemID = 0x282F;
		}
	}

	public class GhostlyImagesScroll : SpellScroll
	{
		public override Catalogs DefaultCatalog{ get{ return Catalogs.Potion; } }

		[Constructable]
		public GhostlyImagesScroll() : this( 1 )
		{
		}

		public override string DefaultDescription{ get{ return BookWitchBrewing.BookGump.potionDesc( 14 ); } }

		[Constructable]
		public GhostlyImagesScroll( int amount ) : base( 143, 0x282F, amount )
		{
			Name = "ghostly images draught";
			Hue = 0xBF;
		}

		public GhostlyImagesScroll( Serial serial ) : base( serial )
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
			ItemID = 0x282F;
		}
	}

	public class GhostPhaseScroll : SpellScroll
	{
		public override Catalogs DefaultCatalog{ get{ return Catalogs.Potion; } }

		[Constructable]
		public GhostPhaseScroll() : this( 1 )
		{
		}

		public override string DefaultDescription{ get{ return BookWitchBrewing.BookGump.potionDesc( 12 ); } }
		
		[Constructable]
		public GhostPhaseScroll( int amount ) : base( 144, 0x282F, amount )
		{
			Name = "ghost phase concoction";
			Hue = 0x47E;
		}

		public GhostPhaseScroll( Serial serial ) : base( serial )
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
			ItemID = 0x282F;
		}
	}

	public class GraveyardGatewayScroll : SpellScroll
	{
		public override Catalogs DefaultCatalog{ get{ return Catalogs.Potion; } }

		[Constructable]
		public GraveyardGatewayScroll() : this( 1 )
		{
		}

		public override string DefaultDescription{ get{ return BookWitchBrewing.BookGump.potionDesc( 16 ); } }
		
		[Constructable]
		public GraveyardGatewayScroll( int amount ) : base( 135, 0x282F, amount )
		{
			Name = "black gate draught";
			Hue = 0x2EA;
		}

		public GraveyardGatewayScroll( Serial serial ) : base( serial )
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
			ItemID = 0x282F;
		}
	}

	public class HellsBrandScroll : SpellScroll
	{
		public override Catalogs DefaultCatalog{ get{ return Catalogs.Potion; } }

		[Constructable]
		public HellsBrandScroll() : this( 1 )
		{
		}

		public override string DefaultDescription{ get{ return BookWitchBrewing.BookGump.potionDesc( 15 ); } }

		[Constructable]
		public HellsBrandScroll( int amount ) : base( 134, 0x282F, amount )
		{
			Name = "hellish branding ooze";
			Hue = 0x54C;
		}

		public HellsBrandScroll( Serial serial ) : base( serial )
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
			ItemID = 0x282F;
		}
	}

	public class HellsGateScroll : SpellScroll
	{
		public override Catalogs DefaultCatalog{ get{ return Catalogs.Potion; } }

		[Constructable]
		public HellsGateScroll() : this( 1 )
		{
		}

		public override string DefaultDescription{ get{ return BookWitchBrewing.BookGump.potionDesc( 13 ); } }
		
		[Constructable]
		public HellsGateScroll( int amount ) : base( 142, 0x282F, amount )
		{
			Name = "demonic fire ooze";
			Hue = 0x54F;
		}

		public HellsGateScroll( Serial serial ) : base( serial )
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
			ItemID = 0x282F;
		}
	}

	public class ManaLeechScroll : SpellScroll
	{
		public override Catalogs DefaultCatalog{ get{ return Catalogs.Potion; } }

		[Constructable]
		public ManaLeechScroll() : this( 1 )
		{
		}

		public override string DefaultDescription{ get{ return BookWitchBrewing.BookGump.potionDesc( 7 ); } }
		
		[Constructable]
		public ManaLeechScroll( int amount ) : base( 132, 0x282F, amount )
		{
			Name = "lich leech mixture";
			Hue = 0xB87;
		}

		public ManaLeechScroll( Serial serial ) : base( serial )
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
			ItemID = 0x282F;
		}
	}

	public class NecroCurePoisonScroll : SpellScroll
	{
		public override Catalogs DefaultCatalog{ get{ return Catalogs.Potion; } }

		[Constructable]
		public NecroCurePoisonScroll() : this( 1 )
		{
		}

		public override string DefaultDescription{ get{ return BookWitchBrewing.BookGump.potionDesc( 9 ); } }
		
		[Constructable]
		public NecroCurePoisonScroll( int amount ) : base( 133, 0x282F, amount )
		{
			Name = "disease curing concoction";
			Hue = 0x8A2;
		}

		public NecroCurePoisonScroll( Serial serial ) : base( serial )
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
			ItemID = 0x282F;
		}
	}

	public class NecroPoisonScroll : SpellScroll
	{
		public override Catalogs DefaultCatalog{ get{ return Catalogs.Potion; } }

		[Constructable]
		public NecroPoisonScroll() : this( 1 )
		{
		}

		public override string DefaultDescription{ get{ return BookWitchBrewing.BookGump.potionDesc( 4 ); } }
		
		[Constructable]
		public NecroPoisonScroll( int amount ) : base( 141, 0x282F, amount )
		{
			Name = "disease draught";
			Hue = 0x4F8;
		}

		public NecroPoisonScroll( Serial serial ) : base( serial )
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
			ItemID = 0x282F;
		}
	}

	public class NecroUnlockScroll : SpellScroll
	{
		public override Catalogs DefaultCatalog{ get{ return Catalogs.Potion; } }

		[Constructable]
		public NecroUnlockScroll() : this( 1 )
		{
		}

		public override string DefaultDescription{ get{ return BookWitchBrewing.BookGump.potionDesc( 3 ); } }
		
		[Constructable]
		public NecroUnlockScroll( int amount ) : base( 145, 0x282F, amount )
		{
			Name = "tomb raiding concoction";
			Hue = 0x493;
		}

		public NecroUnlockScroll( Serial serial ) : base( serial )
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
			ItemID = 0x282F;
		}
	}

	public class PhantasmScroll : SpellScroll
	{
		public override Catalogs DefaultCatalog{ get{ return Catalogs.Potion; } }

		[Constructable]
		public PhantasmScroll() : this( 1 )
		{
		}

		public override string DefaultDescription{ get{ return BookWitchBrewing.BookGump.potionDesc( 5 ); } }
		
		[Constructable]
		public PhantasmScroll( int amount ) : base( 146, 0x282F, amount )
		{
			Name = "phantasm elixir";
			Hue = 0x6DE;
		}

		public PhantasmScroll( Serial serial ) : base( serial )
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
			ItemID = 0x282F;
		}
	}

	public class RetchedAirScroll : SpellScroll
	{
		public override Catalogs DefaultCatalog{ get{ return Catalogs.Potion; } }

		[Constructable]
		public RetchedAirScroll() : this( 1 )
		{
		}

		public override string DefaultDescription{ get{ return BookWitchBrewing.BookGump.potionDesc( 6 ); } }
		
		[Constructable]
		public RetchedAirScroll( int amount ) : base( 136, 0x282F, amount )
		{
			Name = "retched air elixir";
			Hue = 0xA97;
		}

		public RetchedAirScroll( Serial serial ) : base( serial )
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
			ItemID = 0x282F;
		}
	}

	public class SpectreShadowScroll : SpellScroll
	{
		public override Catalogs DefaultCatalog{ get{ return Catalogs.Potion; } }

		[Constructable]
		public SpectreShadowScroll() : this( 1 )
		{
		}

		public override string DefaultDescription{ get{ return BookWitchBrewing.BookGump.potionDesc( 11 ); } }
		
		[Constructable]
		public SpectreShadowScroll( int amount ) : base( 131, 0x282F, amount )
		{
			Name = "spectre shadow elixir";
			Hue = 0x17E;
		}

		public SpectreShadowScroll( Serial serial ) : base( serial )
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
			ItemID = 0x282F;
		}
	}

	public class UndeadEyesScroll : SpellScroll
	{
		public override Catalogs DefaultCatalog{ get{ return Catalogs.Potion; } }

		[Constructable]
		public UndeadEyesScroll() : this( 1 )
		{
		}

		public override string DefaultDescription{ get{ return BookWitchBrewing.BookGump.potionDesc( 2 ); } }
		
		[Constructable]
		public UndeadEyesScroll( int amount ) : base( 137, 0x282F, amount )
		{
			Name = "eyes of the dead mixture";
			Hue = 0x491;
		}

		public UndeadEyesScroll( Serial ser ) : base(ser)
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
			ItemID = 0x282F;
		}
	}

	public class VampireGiftScroll : SpellScroll
	{
		public override Catalogs DefaultCatalog{ get{ return Catalogs.Potion; } }

		[Constructable]
		public VampireGiftScroll() : this( 1 )
		{
		}

		public override string DefaultDescription{ get{ return BookWitchBrewing.BookGump.potionDesc( 17 ); } }

		[Constructable]
		public VampireGiftScroll( int amount ) : base( 139, 0x282F, amount )
		{
			Name = "vampire blood draught";
			Hue = 0xB85;
		}

		public VampireGiftScroll( Serial serial ) : base( serial )
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
			ItemID = 0x282F;
		}
	}

	public class WallOfSpikesScroll : SpellScroll
	{
		public override Catalogs DefaultCatalog{ get{ return Catalogs.Potion; } }

		[Constructable]
		public WallOfSpikesScroll() : this( 1 )
		{
		}

		public override string DefaultDescription{ get{ return BookWitchBrewing.BookGump.potionDesc( 8 ); } }
		
		[Constructable]
		public WallOfSpikesScroll( int amount ) : base( 138, 0x282F, amount )
		{
			Name = "wall of spikes draught";
			Hue = 0xB8F;
		}

		public WallOfSpikesScroll( Serial serial ) : base( serial )
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
			ItemID = 0x282F;
		}
	}
}