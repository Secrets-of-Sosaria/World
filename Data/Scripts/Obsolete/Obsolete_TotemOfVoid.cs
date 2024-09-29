using System;
using Server;
using Server.Mobiles;

namespace Server.Items
{
	public class TotemOfVoid : MagicTalisman
	{
		[Constructable]
		public TotemOfVoid()
		{
			Name = "Totem of the Void";
			ItemID = 0x2F5B;
			Hue = 0x2D0;
			Attributes.RegenHits = 10;
			Attributes.LowerManaCost = 50;
		}

        public override void AddNameProperties(ObjectPropertyList list)
		{
            base.AddNameProperties(list);
			list.Add( 1070722, "Artefact");
        }

		public TotemOfVoid( Serial serial ) :  base( serial )
		{
		}

		public override void Serialize( GenericWriter writer )
		{
			base.Serialize( writer );
			writer.Write( (int) 0 ); // version
		}

		private void Cleanup( object state ){ Item item = new Artifact_TotemOfVoid(); Server.Misc.Cleanup.DoCleanup( (Item)state, item ); }

public override void Deserialize( GenericReader reader )
		{
			base.Deserialize( reader ); Timer.DelayCall( TimeSpan.FromSeconds( 1.0 ), new TimerStateCallback( Cleanup ), this );
			int version = reader.ReadInt();
		}
	}
}
