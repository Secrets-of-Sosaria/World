using System;
using Server.Items;

namespace Server.Items
{
	[FlipableAttribute( 0x1F03, 0x1F04 )]
	public class LevelLeatherRobe : BaseLevelArmor
	{
		public override int BasePhysicalResistance{ get{ return 3; } }
		public override int BaseFireResistance{ get{ return 4; } }
		public override int BaseColdResistance{ get{ return 4; } }
		public override int BasePoisonResistance{ get{ return 4; } }
		public override int BaseEnergyResistance{ get{ return 4; } }

		public override int InitMinHits{ get{ return 30; } }
		public override int InitMaxHits{ get{ return 40; } }

		public override int AosStrReq{ get{ return 15; } }
		public override int OldStrReq{ get{ return 10; } }

		public override int ArmorBase{ get{ return 14; } }

		public override ArmorMaterialType MaterialType{ get{ return ArmorMaterialType.Leather; } }
		public override CraftResource DefaultResource{ get{ return CraftResource.RegularLeather; } }

		public override ArmorMeditationAllowance DefMedAllowance{ get{ return ArmorMeditationAllowance.All; } }

		[Constructable]
		public LevelLeatherRobe() : base( 0x1F03 )
		{
			Name = "leather robe";
			Weight = 6.0;
			Layer = Layer.OuterTorso;
			ResourceMods.DefaultItemHue( this );
		}

		public LevelLeatherRobe( Serial serial ) : base( serial )
		{
		}
		
		public override void Serialize( GenericWriter writer )
		{
			base.Serialize( writer );
			writer.Write( (int) 0 );
		}
		
		public override void Deserialize(GenericReader reader)
		{
			base.Deserialize( reader );
			int version = reader.ReadInt();
		}
	}
}