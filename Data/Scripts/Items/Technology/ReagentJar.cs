using System;
using Server;
using Server.Network;
using System.Text;
using Server.Items;
using Server.Mobiles;
using Server.Misc;
using System.Collections.Generic;
using System.Collections;
using Server.Targeting;

namespace Server.Items
{
	public class ReagentJar : LockableContainer
	{
		public override bool DisplayLootType{ get{ return false; } }
		public override bool DisplaysContent{ get{ return false; } }

		[Constructable]
		public ReagentJar() : base( 0x1FDB )
		{
			Name = "jar";
			Locked = true;
			LockLevel = 1000;
			MaxLockLevel = 1000;
			RequiredSkill = 1000;
			Weight = 0.01;
			VirtualContainer = true;
		}

		public override void OnDoubleClick( Mobile from )
		{
			Container pack = this;
			List<Item> items = new List<Item>();
			foreach (Item item in pack.Items)
			{
				items.Add(item);
			}
			foreach (Item item in items)
			{
				from.AddToBackpack ( item );
			}

			from.SendMessage("You empty the jar.");
			this.Delete();
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

		public static void ConfigureItem( Item item, Container cont, Mobile m )
		{
			if ( Worlds.isSciFiRegion( m ) && item.Catalog == Catalogs.Reagent && !(item is Container) )
			{
				Container unk = new ReagentJar();
				unk.Hue = Utility.RandomColor(0);
				unk.Name = "jar of " + item.Name;
				unk.Weight = item.Weight;
				unk.InfoText1 = "open to dump";
				unk.InfoText2 = "them out";
				unk.CoinPrice = item.Amount * 3;

				if ( item.Amount > 1 )
				{
					unk.ColorText3 = "Amount: " + item.Amount + "";
					unk.ColorHue3 = "87E15A";
				}

				unk.DropItem(item);
				cont.DropItem(unk);
			}
		}

		public ReagentJar( Serial serial ) : base( serial )
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