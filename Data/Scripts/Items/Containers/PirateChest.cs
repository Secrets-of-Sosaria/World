using System;
using System.Collections;
using Server;
using Server.Gumps;
using Server.Multis;
using Server.Network;
using Server.ContextMenus;
using Server.Engines.PartySystem;
using Server.Misc;

namespace Server.Items
{
	public class PirateChest : SkullChest
	{
		public override CraftResource DefaultResource{ get{ return CraftResource.RegularWood; } }

		public string ContainerOwner;

		[CommandProperty(AccessLevel.Owner)]
		public string Container_Owner { get { return ContainerOwner; } set { ContainerOwner = value; InvalidateProperties(); } }

		[Constructable]
		public PirateChest() : this( 0, null )
		{
		}

		[Constructable]
		public PirateChest( int level, string digger ) : base()
		{
			if ( level > 0 )
			{
				Name = "pirate chest";

				ContainerFunctions.LockTheContainer( level, this, 1 );

				if ( digger == "null" ){ digger = "From An Unknown Pirate"; }
				ContainerOwner = digger;

				Weight = 51.0 + (double)level;
				Movable = true;
			}
		}

		public override void Open( Mobile from )
		{
			if ( this.Weight > 50 )
			{
				Movable = true;
				int FillMeUpLevel = (int)(this.Weight - 51);
				this.Weight = 5.0;

				if ( GetPlayerInfo.LuckyPlayer( from.Luck ) )
				{
					FillMeUpLevel = FillMeUpLevel + Utility.RandomMinMax( 1, 2 );
				}

				ContainerFunctions.FillTheContainer( FillMeUpLevel, this, from );
			}

			base.Open( from );
		}

		public override bool OnDragLift( Mobile from )
		{
			if ( this.Weight > 50 )
			{
				Movable = true;
				int FillMeUpLevel = (int)(this.Weight - 51);
				this.Weight = 5.0;

				if ( GetPlayerInfo.LuckyPlayer( from.Luck ) )
				{
					FillMeUpLevel = FillMeUpLevel + Utility.RandomMinMax( 1, 2 );
				}

				ContainerFunctions.FillTheContainer( FillMeUpLevel, this, from );
			}

			return true;
		}

		public PirateChest( Serial serial ) : base( serial )
		{
		}

        public override void AddNameProperties(ObjectPropertyList list)
		{
            base.AddNameProperties(list);
			if ( this.Weight < 10 ){ list.Add( 1070722, ContainerOwner ); }
        }

		public override void Serialize( GenericWriter writer )
		{
			base.Serialize( writer );
			writer.Write( (int) 0 ); // version
            writer.Write( ContainerOwner );
		}

		public override void Deserialize( GenericReader reader )
		{
			base.Deserialize( reader );
			int version = reader.ReadInt();
			ContainerOwner = reader.ReadString();
		}
	}
}