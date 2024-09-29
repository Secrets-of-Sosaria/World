using System;

namespace Server.Items
{
	public class BarkFragment : Item
	{
		public override string DefaultDescription{ get{ return "These pieces of bark are used to make paper for blank scrolls."; } }

		[Constructable]
		public BarkFragment(): this( 1 )
		{
		}

		[Constructable]
		public BarkFragment( int amountFrom, int amountTo ): this( Utility.RandomMinMax( amountFrom, amountTo ) )
		{
		}

		[Constructable]
		public BarkFragment( int amount ): base( 0x318F )
		{
			Stackable = true;
			Amount = amount;
		}

		public BarkFragment( Serial serial ): base( serial )
		{
		}

		public override void Serialize( GenericWriter writer )
		{
			base.Serialize( writer );
			writer.Write( (int)0 ); // version
		}

		public override void Deserialize( GenericReader reader )
		{
			base.Deserialize( reader );
			int version = reader.ReadInt();
		}
	}
}
