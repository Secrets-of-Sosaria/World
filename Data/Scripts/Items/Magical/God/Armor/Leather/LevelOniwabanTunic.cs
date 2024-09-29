using System;

namespace Server.Items
{
	public class LevelOniwabanTunic : LevelLeatherChest
	{
		[Constructable]
		public LevelOniwabanTunic()
		{
			ItemID = 0x64BD;
			Name = "oniwaban tunic";
		}

		public LevelOniwabanTunic( Serial serial ) : base( serial )
		{
		}
		
		public override void Serialize( GenericWriter writer )
		{
			base.Serialize( writer );
			writer.Write( (int) 0 );
		}
		
		public override void Deserialize(GenericReader reader)
		{
			base.Deserialize( reader );
			int version = reader.ReadInt();
		}
	}
}