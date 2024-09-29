using System;
using Server;
using Server.Mobiles;

namespace Server.Items
{
    public class ShimmeringTalisman : MagicTalisman
	{
		[Constructable]
		public ShimmeringTalisman()
		{
			Name = "Shimmering Talisman";
			ItemID = 0x2C7F;
			Hue = 1266;
			Attributes.RegenMana = 10;
			Attributes.LowerRegCost = 50;
		}

        public override void AddNameProperties(ObjectPropertyList list)
		{
            base.AddNameProperties(list);
			list.Add( 1070722, "Artefact");
        }
		
		public ShimmeringTalisman( Serial serial ) :  base( serial )
		{
		}

		public override void Serialize( GenericWriter writer )
		{
			base.Serialize( writer );
			writer.Write( (int) 0 ); // version
		}

		private void Cleanup( object state ){ Item item = new Artifact_ShimmeringTalisman(); Server.Misc.Cleanup.DoCleanup( (Item)state, item ); }

public override void Deserialize( GenericReader reader )
		{
			base.Deserialize( reader ); Timer.DelayCall( TimeSpan.FromSeconds( 1.0 ), new TimerStateCallback( Cleanup ), this );
			int version = reader.ReadInt();
		}
	}
}