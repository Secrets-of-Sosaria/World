using System;

namespace Server.Items
{
	public class LevelOniwabanGloves : LevelLeatherGloves
	{
		[Constructable]
		public LevelOniwabanGloves()
		{
			ItemID = 0x64B9;
			Name = "oniwaban gloves";
		}

		public LevelOniwabanGloves( Serial serial ) : base( serial )
		{
		}

		public override void Serialize( GenericWriter writer )
		{
			base.Serialize( writer );
			writer.Write( (int) 1 ); // version
		}

		public override void Deserialize( GenericReader reader )
		{
			base.Deserialize( reader );
			int version = reader.ReadInt();
		}
	}
}