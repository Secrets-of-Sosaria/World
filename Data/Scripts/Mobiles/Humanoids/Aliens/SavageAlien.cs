using System;
using Server;
using Server.Misc;
using Server.Items;

namespace Server.Mobiles
{
	[CorpseName( "a savage corpse" )]
	public class SavageAlien : BaseCreature
	{
		[Constructable]
		public SavageAlien() : base( AIType.AI_Melee, FightMode.Closest, 10, 1, 0.2, 0.4 )
		{
			Name = "an alien savage";

			Hue = Utility.RandomList( 0x6F6, 0x97F, 0x99B, 0x6E4, 0x5E0, 0xB38, 0xB2B );

			if ( Female = Utility.RandomBool() )
			{
				Body = 401;
			}
			else
			{
				Body = 400;
			}

			SetStr( 336, 385 );
			SetDex( 281, 305 );
			SetInt( 96, 115 );

			SetHits( 202, 231 );
			SetMana( 0 );

			SetDamage( 7, 23 );

			SetDamageType( ResistanceType.Physical, 100 );

			SetResistance( ResistanceType.Physical, 45, 55 );
			SetResistance( ResistanceType.Fire, 30, 40 );
			SetResistance( ResistanceType.Cold, 30, 40 );
			SetResistance( ResistanceType.Poison, 40, 50 );
			SetResistance( ResistanceType.Energy, 40, 50 );

			SetSkill( SkillName.MagicResist, 125.1, 140.0 );
			SetSkill( SkillName.Tactics, 90.1, 100.0 );
			SetSkill( SkillName.FistFighting, 90.1, 100.0 );

			SetSkill( SkillName.Fencing, 125.1, 140.0 );
			SetSkill( SkillName.Bludgeoning, 125.1, 140.0 );
			SetSkill( SkillName.FistFighting, 125.1, 140.0 );
			SetSkill( SkillName.MagicResist, 67.5, 100.0 );
			SetSkill( SkillName.Swords, 125.1, 140.0 );
			SetSkill( SkillName.Tactics, 125.1, 140.0 );

			Fame = 10000;
			Karma = -10000;

			VirtualArmor = 50;
		}

		public override void OnAfterSpawn()
		{
			Item cloth1 = new SavageArms();
			ResourceMods.SetRandomResource( false, true, cloth1, CraftResource.BrittleSkeletal, true, this );
			CraftResource resource = cloth1.Resource;
			  	AddItem( cloth1 );

			Item cloth2 = new SavageLegs();
				ResourceMods.SetResource( cloth2, resource );
			  	AddItem( cloth2 );

			Item cloth3 = new LeatherSkirt();
				cloth3.Name = "skin skirt";
				ResourceMods.SetResource( cloth3, resource );
			  	cloth3.Layer = Layer.Waist;
			  	AddItem( cloth3 );

			switch ( Utility.RandomMinMax( 0, 3 ) )
			{
				case 0: Item cloth4 = new OrcHelm();		ResourceMods.SetResource( cloth4, resource );		AddItem( cloth4 ); break;
				case 1: Item cloth5 = new SavageHelm();		ResourceMods.SetResource( cloth5, resource );		AddItem( cloth5 ); break;
				case 2: Item cloth6 = new TribalMask(); 	cloth6.Name = "skin mask"; 		cloth6.Hue = CraftResources.GetHue(resource);	AddItem( cloth6 ); break;
			}

			if ( Utility.RandomMinMax( 1, 10 ) == 1 )
			{
				Item cloth7 = new SavageChest();
					ResourceMods.SetResource( cloth7, resource );
					AddItem( cloth7 );
			}
			else if ( Female )
			{
				Item cloth8 = new FemaleLeatherChest();
					cloth8.Name = "skin tunic";
					ResourceMods.SetResource( cloth8, resource );
					AddItem( cloth8 );
			}

			IntelligentAction.GiveBasicWepShld( this );

			if ( this.FindItemOnLayer( Layer.OneHanded ) != null && ResourceMods.SearchResource( this.FindItemOnLayer( Layer.OneHanded ) ) != CraftResource.None )
			{
				Item oneHand = this.FindItemOnLayer( Layer.OneHanded );
				ResourceMods.SetRandomResource( true, true, oneHand, oneHand.Resource, false, this );
			}

			if ( this.FindItemOnLayer( Layer.TwoHanded ) != null && ResourceMods.SearchResource( this.FindItemOnLayer( Layer.TwoHanded ) ) != CraftResource.None )
			{
				Item twoHand = this.FindItemOnLayer( Layer.TwoHanded );
				ResourceMods.SetRandomResource( true, true, twoHand, twoHand.Resource, false, this );

				if ( twoHand is BaseShield )
				{
					switch( Utility.RandomMinMax( 1, 4 ) )
					{
						case 1: twoHand.ItemID = 0x1B76; twoHand.Name = "hull plate";	break;
						case 2: twoHand.ItemID = 0x1B76; twoHand.Name = "deck plate";	break;
						case 3: twoHand.ItemID = 0x1B72; twoHand.Name = "hatch door";	break;
						case 4: twoHand.ItemID = 0x1B7B; twoHand.Name = "hatch cover";	break;
					}
				}
			}

			MorphingTime.BlessMyClothes( this );
			base.OnAfterSpawn();
		}

		public override void GenerateLoot()
		{
			AddLoot( LootPack.Average );
			AddLoot( LootPack.Average );
			AddLoot( LootPack.Meager );
		}

		public override int Meat{ get{ return 1; } }
		public override bool ClickTitle{ get{ return false; } }
		public override bool ShowFameTitle{ get{ return false; } }
		public override bool AlwaysAttackable{ get{ return true; } }
		public override bool CanRummageCorpses{ get{ return true; } }
		public override int Skeletal{ get{ return Utility.Random(3); } }
		public override SkeletalType SkeletalType{ get{ return SkeletalType.SciFi; } }
		public override int Hides{ get{ return Utility.Random(3); } }
		public override HideType HideType{ get{ return HideType.Alien; } }

		public SavageAlien( Serial serial ) : base( serial )
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