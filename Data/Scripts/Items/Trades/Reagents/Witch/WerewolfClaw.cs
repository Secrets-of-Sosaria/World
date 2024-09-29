using System;
using Server;
using Server.Items;

namespace Server.Items
{
	public class WerewolfClaw : BaseReagent
	{
		[Constructable]
		public WerewolfClaw() : this( 1 )
		{
		}

		[Constructable]
		public WerewolfClaw( int amount ) : base( 0x6413, amount )
		{
			Name = "werewolf claw";
		}

		public WerewolfClaw( Serial serial ) : base( serial )
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