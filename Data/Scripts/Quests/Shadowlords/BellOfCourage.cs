using System;
using System.Collections;
using Server.Network;
using Server.Targeting;
using Server.Prompts;
using Server.Mobiles;

namespace Server.Items
{
	public class BellOfCourage : Item
	{
		public Mobile Owner;

		[Constructable]
		public BellOfCourage() : base( 0x1C12 )
		{
			Name = "Bell of Courage";
			Weight = 1.0;
		}

		private static int[] m_Sounds = new int[] { 0x505, 0x506, 0x507 };

		public override void OnDoubleClick( Mobile from )
		{
			if ( !IsChildOf( from.Backpack ) ) 
			{
				from.SendMessage( "This must be in your backpack to use." );
				return;
			}
			else
			{
				from.PlaySound( m_Sounds[Utility.Random( m_Sounds.Length )] );
				from.SendMessage( "You ring the bell, producing a courageous melody." );
			}
		}

        public override void AddNameProperties(ObjectPropertyList list)
		{
            base.AddNameProperties(list);
			if ( Owner != null ){ list.Add( 1049644, "Belongs to " + Owner.Name + "" ); }
        }

		public override bool OnDragLift( Mobile from )
		{
			if ( from is PlayerMobile && Owner == null )
			{
				ArrayList targets = new ArrayList();
				foreach ( Item item in World.Items.Values )
				if ( item is BellOfCourage && ((BellOfCourage)item).Owner == from && item != this )
				{
					targets.Add( item );
				}
				for ( int i = 0; i < targets.Count; ++i )
				{
					Item item = ( Item )targets[ i ];
					item.Delete();
				}
				this.Owner = from;
			}

			return base.OnDragLift( from );
		}

		public BellOfCourage(Serial serial) : base(serial)
		{
		}

		public override void Serialize(GenericWriter writer)
		{
			base.Serialize(writer);
			writer.Write((int)1);
			writer.Write( (Mobile)Owner );
		}

		public override void Deserialize(GenericReader reader)
		{
			base.Deserialize(reader);
			int version = reader.ReadInt();

			if ( version > 0 )
				Owner = reader.ReadMobile();
		}
	}
}