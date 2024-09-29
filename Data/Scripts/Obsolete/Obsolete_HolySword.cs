using System;
using Server;

namespace Server.Items
{
	public class HolySword : Longsword
	{
		public override int LabelNumber{ get{ return 1062921; } } // The Holy Sword

		[Constructable]
		public HolySword()
		{
			Hue = 0x482;
			Slayer = SlayerName.Silver;
			Attributes.WeaponDamage = 40;
			WeaponAttributes.SelfRepair = 10;
			WeaponAttributes.LowerStatReq = 100;
			WeaponAttributes.UseBestSkill = 1;
		}

		public HolySword( Serial serial ) : base( serial )
		{
		}

		public override void Serialize( GenericWriter writer )
		{
			base.Serialize( writer );

			writer.WriteEncodedInt( (int) 0 ); // version
		}

		private void Cleanup( object state ){ Item item = new Artifact_HolySword(); Server.Misc.Cleanup.DoCleanup( (Item)state, item ); }

public override void Deserialize(GenericReader reader)
		{
			base.Deserialize( reader ); Timer.DelayCall( TimeSpan.FromSeconds( 1.0 ), new TimerStateCallback( Cleanup ), this );

			int version = reader.ReadEncodedInt();
		}
	}
}