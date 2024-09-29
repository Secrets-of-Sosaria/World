using Server;
using System;
using System.Collections;
using Server.Network;
using Server.Targeting;
using Server.Prompts;
using Server.Misc;
using Server.Mobiles;
using Server.Spells;

namespace Server.Items
{
	public class LiquidRot : BaseLiquid
	{
		public override string DefaultDescription{ get{ return "Dumping this on the ground will produce puddles of liquid, causing mostly poison damage to those that walk over it. The liquid can be more effective from alchemists that are also skilled in tasting and cooking. The liquid will dry up after about 30 seconds."; } }

		[Constructable]
		public LiquidRot() : base( PotionEffect.LiquidRot )
		{
			LiquidGlow = 0;
			Name = "liquid rot";
		}

		public override void AddNameProperties( ObjectPropertyList list )
		{
			base.AddNameProperties( list );
			list.Add( 1070722, "Poison Damage" );
		}

		public LiquidRot( Serial serial ) : base( serial )
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