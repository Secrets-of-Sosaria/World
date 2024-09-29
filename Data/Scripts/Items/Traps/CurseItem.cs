using System;
using System.Collections;
using Server;
using Server.Gumps;
using Server.Network;

namespace Server.Items
{
	public class CurseItem : LockableContainer
	{
		public override bool DisplayLootType{ get{ return false; } }
		public override bool DisplaysContent{ get{ return false; } }
		public override bool DisplayWeight{ get{ return false; } }

		[Constructable]
		public CurseItem() : base( 0x9A8 )
		{
			Name = "cursed item";
			Locked = true;
			LockLevel = 1000;
			MaxLockLevel = 1000;
			RequiredSkill = 1000;
			Weight = 40.0;
			VirtualContainer = true;
			ColorText1 = "CURSED!";
			ColorText3 = "Give to a Wizard or Knight";
			ColorText4 = "To Remove the Curse";
			ColorText5 = "Or Use Curse Removing Magic";
			ColorHue1 = ColorHue3 = ColorHue4 = ColorHue5 = "E15656";
		}

		public override void OnDoubleClick( Mobile from )
		{
		}

		public override bool TryDropItem( Mobile from, Item dropped, bool sendFullMessage )
		{
			return false;
		}

		public override bool CheckLocked( Mobile from )
		{
			return true;
		}

		public override bool OnDragDropInto( Mobile from, Item item, Point3D p )
		{
			return false;
		}

		public override int GetTotal(TotalType type)
        {
			return 0;
        }

		public CurseItem( Serial serial ) : base( serial )
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