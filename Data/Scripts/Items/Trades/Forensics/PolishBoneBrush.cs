using System;
using Server.Items;
using Server.Targeting;

namespace Server.Items
{
	public class PolishBoneBrush : Item
	{
		public override string DefaultDescription{ get{ return "Sometimes, you may find various bones while adventuring in the land. This brush lets you polish those bones so they can be used as bones for crafting."; } }

		[Constructable]
		public PolishBoneBrush() : base( 0x1371 )
		{
			Name = "bone polishing brush";
			Weight = 2.0;
		}

        public override void AddNameProperties(ObjectPropertyList list)
		{
            base.AddNameProperties(list);
			list.Add( 1070722, "Polish Bones For Crafting");
        } 

		public PolishBoneBrush( Serial serial ) : base( serial )
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

		public override void OnDoubleClick( Mobile from )
		{
			if ( IsChildOf( from.Backpack ) )
			{
				from.SendMessage( "Which bones do you want to polish?" );
				from.Target = new PickBones( this );
			}
			else
			{
				from.SendLocalizedMessage( 1042001 ); // That must be in your pack for you to use it.
			}
		}

		private class PickBones : Target
		{
			private PolishBoneBrush m_PolishBoneBrush;

			public PickBones( PolishBoneBrush brush ) : base( 1, false, TargetFlags.None )
			{
				m_PolishBoneBrush = brush;
			}

			protected override void OnTarget( Mobile from, object targeted )
			{
				if ( targeted is Item )
				{
					Item bone = targeted as Item;

					int boneCount = 0;

					if ( !bone.IsChildOf( from.Backpack ) )
					{
						from.SendMessage( "You can only polish bones that are in your pack." );
					}
					else if ( bone is Container )
					{
						from.SendMessage( "You cannot polish containers." );
					}
					else if ( bone.ItemID == 0xECA ){ boneCount = 4; }
					else if ( bone.ItemID == 0xECB ){ boneCount = 4; }
					else if ( bone.ItemID == 0xECC ){ boneCount = 4; }
					else if ( bone.ItemID == 0xECD ){ boneCount = 4; }
					else if ( bone.ItemID == 0xECE ){ boneCount = 4; }
					else if ( bone.ItemID == 0xECF ){ boneCount = 4; }
					else if ( bone.ItemID == 0xED0 ){ boneCount = 4; }
					else if ( bone.ItemID == 0xED1 ){ boneCount = 4; }
					else if ( bone.ItemID == 0xED2 ){ boneCount = 4; }
					else if ( bone.ItemID == 0xF7E ){ boneCount = bone.Amount; }
					else if ( bone.ItemID == 0xF80 ){ boneCount = 1; }
					else if ( bone.ItemID == 0x1B09 ){ boneCount = 3; }
					else if ( bone.ItemID == 0x1B0A ){ boneCount = 3; }
					else if ( bone.ItemID == 0x1B0B ){ boneCount = 4; }
					else if ( bone.ItemID == 0x1B0C ){ boneCount = 4; }
					else if ( bone.ItemID == 0x1B0D ){ boneCount = 3; }
					else if ( bone.ItemID == 0x1B0E ){ boneCount = 3; }
					else if ( bone.ItemID == 0x1B0F ){ boneCount = 4; }
					else if ( bone.ItemID == 0x1B10 ){ boneCount = 4; }
					else if ( bone.ItemID == 0x1B11 ){ boneCount = 1; }
					else if ( bone.ItemID == 0x1B12 ){ boneCount = 1; }
					else if ( bone.ItemID == 0x1B13 ){ boneCount = 1; }
					else if ( bone.ItemID == 0x1B14 ){ boneCount = 1; }
					else if ( bone.ItemID == 0x1B16 ){ boneCount = 1; }
					else if ( bone.ItemID == 0x1B19 ){ boneCount = 2; }
					else if ( bone.ItemID == 0x2C99 ){ boneCount = 1; }
					else if ( bone.ItemID == 0x1B17 ){ boneCount = 2; }
					else if ( bone.ItemID == 0x1B18 ){ boneCount = 2; }
					else if ( bone.ItemID == 0x1B19 ){ boneCount = 2; }
					else if ( bone.ItemID == 0x1B1A ){ boneCount = 2; }
					else if ( bone.ItemID == 0x1B1B ){ boneCount = 1; }
					else if ( bone.ItemID == 0x1B1C ){ boneCount = 1; }
					else if ( bone.ItemID == 0x1AE0 ){ boneCount = 1; }
					else if ( bone.ItemID == 0x1AE1 ){ boneCount = 1; }
					else if ( bone.ItemID == 0x1AE2 ){ boneCount = 1; }
					else if ( bone.ItemID == 0x1AE3 ){ boneCount = 1; }
					else if ( bone.ItemID == 0x1AE4 ){ boneCount = 1; }
					else if ( bone.ItemID == 0x224 ){ boneCount = 1; }
					else if ( bone.ItemID == 0x224 ){ boneCount = 1; }
					else if ( bone.ItemID == 0x1853 ){ boneCount = 1; }
					else if ( bone.ItemID == 0x1854 ){ boneCount = 1; }
					else if ( bone.ItemID == 0x1855 ){ boneCount = 1; }
					else if ( bone.ItemID == 0x1856 ){ boneCount = 1; }
					else if ( bone.ItemID == 0x1857 ){ boneCount = 1; }
					else if ( bone.ItemID == 0x1858 ){ boneCount = 1; }
					else if ( bone.ItemID == 0x1859 ){ boneCount = 1; }
					else if ( bone.ItemID == 0x185A ){ boneCount = 1; }
					else if ( bone.ItemID == 0x1AEE ){ boneCount = 1; }
					else if ( bone.ItemID == 0x1AEF ){ boneCount = 1; }
					else if ( bone.ItemID == 0x2203 ){ boneCount = 1; }
					else if ( bone.ItemID == 0x2204 ){ boneCount = 10; }
					else if ( bone.ItemID == 0x224E ){ boneCount = 1; }
					else if ( bone.ItemID == 0x224F ){ boneCount = 1; }
					else if ( bone.ItemID == 0x2250 ){ boneCount = 1; }
					else if ( bone.ItemID == 0x2251 ){ boneCount = 1; }
					else if ( bone.ItemID == 0x2C95 ){ boneCount = 1; }
					else if ( bone.ItemID == 0x3DCC ){ boneCount = 1; }
					else if ( bone.ItemID == 0x3DCD ){ boneCount = 1; }
					else if ( bone.ItemID == 0x3DE0 ){ boneCount = 1; }
					else if ( bone.ItemID == 0x3DE1 ){ boneCount = 1; }
					else if ( bone.ItemID == 0x42B5 ){ boneCount = 3; }
					else if ( bone.ItemID == 0x1b15 ){ boneCount = 1; }
					else
					{
						from.SendMessage( "You cannot polish that." );
					}

					if ( boneCount > 0 )
					{
						from.AddToBackpack( new BrittleSkeletal(boneCount) );

						int skill = (int)( from.Skills[SkillName.Forensics].Base / 10 ) + 7;
						bool drop = false;

						switch ( Utility.Random( skill ) )
						{
							case 0: from.AddToBackpack( new BrittleSkeletal(boneCount) ); drop = true; break;
							case 1: from.AddToBackpack( new DrowSkeletal(boneCount) ); drop = true; break;
							case 2: from.AddToBackpack( new OrcSkeletal(boneCount) ); drop = true; break;
							case 3: from.AddToBackpack( new ReptileSkeletal(boneCount) ); drop = true; break;
							case 4: from.AddToBackpack( new OgreSkeletal(boneCount) ); drop = true; break;
							case 5: from.AddToBackpack( new TrollSkeletal(boneCount) ); drop = true; break;
							case 6: from.AddToBackpack( new GargoyleSkeletal(boneCount) ); drop = true; break;
							case 7: from.AddToBackpack( new MinotaurSkeletal(boneCount) ); drop = true; break;
							case 8: from.AddToBackpack( new LycanSkeletal(boneCount) ); drop = true; break;
							case 9: from.AddToBackpack( new SharkSkeletal(boneCount) ); drop = true; break;
							case 10: from.AddToBackpack( new ColossalSkeletal(boneCount) ); drop = true; break;
							case 11: from.AddToBackpack( new MysticalSkeletal(boneCount) ); drop = true; break;
							case 12: from.AddToBackpack( new VampireSkeletal(boneCount) ); drop = true; break;
							case 13: from.AddToBackpack( new LichSkeletal(boneCount) ); drop = true; break;
							case 14: from.AddToBackpack( new SphinxSkeletal(boneCount) ); drop = true; break;
							case 15: from.AddToBackpack( new DevilSkeletal(boneCount) ); drop = true; break;
							case 16: from.AddToBackpack( new DracoSkeletal(boneCount) ); drop = true; break;
						}

						if ( !drop )
							from.AddToBackpack( new BrittleSkeletal(boneCount) );

						from.SendMessage( "You polish the bones so they can be used for crafting." );
						from.RevealingAction();
						from.PlaySound( 0x04F );
						bone.Delete();
					}
				}
				else
				{
					from.SendMessage( "You cannot polish that." );
				}
			}
		}
	}
}