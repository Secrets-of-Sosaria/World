using System;
using System.Collections;
using Server.Items;
using Server.Targeting;
using Server.Misc;

namespace Server.Mobiles
{
	[CorpseName( "a gargoyle corpse" )]
	public class StoneGargoyle : BaseCreature
	{
		[Constructable]
		public StoneGargoyle() : base( AIType.AI_Melee, FightMode.Closest, 10, 1, 0.2, 0.4 )
		{
			Name = "a stone gargoyle";
			Body = 4;
			Hue = 0x430;
			BaseSoundID = 0x174;

			SetStr( 246, 275 );
			SetDex( 76, 95 );
			SetInt( 81, 105 );

			SetHits( 148, 165 );

			SetDamage( 11, 17 );

			SetDamageType( ResistanceType.Physical, 100 );

			SetResistance( ResistanceType.Physical, 45, 55 );
			SetResistance( ResistanceType.Fire, 20, 30 );
			SetResistance( ResistanceType.Cold, 10, 20 );
			SetResistance( ResistanceType.Poison, 30, 40 );
			SetResistance( ResistanceType.Energy, 30, 40 );

			SetSkill( SkillName.MagicResist, 85.1, 100.0 );
			SetSkill( SkillName.Tactics, 80.1, 100.0 );
			SetSkill( SkillName.FistFighting, 60.1, 100.0 );

			Fame = 4000;
			Karma = -4000;

			VirtualArmor = 50;

			if ( 0.05 > Utility.RandomDouble() )
			{
				Pickaxe axe = new Pickaxe();
				axe.Resource = CraftResource.Dwarven;
				axe.Name = "gargoyle pickaxe";
				PackItem( axe );
			}
		}

		public override void OnAfterSpawn()
		{
			Hue = 0x430; // Iron

			switch ( Utility.RandomMinMax( 0, 10 ) )
			{
				case 0: Resource = CraftResource.Iron; break;
				case 1: Resource = CraftResource.DullCopper; break;
				case 2: Resource = CraftResource.ShadowIron; break;
				case 3: Resource = CraftResource.Copper; break;
				case 4: Resource = CraftResource.Bronze; break;
				case 5: Resource = CraftResource.Gold; break;
				case 6: Resource = CraftResource.Agapite; break;
				case 7: Resource = CraftResource.Verite; break;
				case 8: Resource = CraftResource.Valorite; break;
				case 9: Resource = CraftResource.Dwarven; break;
				case 10:
					if ( Worlds.IsExploringSeaAreas( this ) == true ){ Resource = CraftResource.Nepturite; }
					else if ( Land == Land.Serpent ){ Resource = CraftResource.Obsidian; }
					else if ( Land == Land.Underworld && this.Map == Map.SavagedEmpire ){ Resource = CraftResource.Xormite; }
					else if ( Land == Land.Underworld ){ Resource = CraftResource.Mithril; }
					break; // Special
			}

			if ( Resource != CraftResource.Iron )
				Hue = CraftResources.GetClr( Resource );

			base.OnAfterSpawn();
		}

		public override void GenerateLoot()
		{
			AddLoot( LootPack.Average, 2 );
			AddLoot( LootPack.Gems, 1 );
			AddLoot( LootPack.MedPotions );
		}

		public override int TreasureMapLevel{ get{ return 2; } }
		public override int Skeletal{ get{ return Utility.Random(3); } }
		public override SkeletalType SkeletalType{ get{ return SkeletalType.Gargoyle; } }
		public override int Granite{ get{ return 2; } }
		public override GraniteType GraniteType{ get{ return ResourceGranite(); } }

		public StoneGargoyle( Serial serial ) : base( serial )
		{
		}

		public override void Serialize( GenericWriter writer )
		{
			base.Serialize( writer );
			writer.Write( (int) 0 );
		}

		public override void Deserialize( GenericReader reader )
		{
			base.Deserialize( reader );
			int version = reader.ReadInt();
		}
	}
}