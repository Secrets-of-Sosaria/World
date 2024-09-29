using System;

namespace Server.Items
{
	public class LevelOniwabanLeggings : LevelLeatherLegs
	{
		[Constructable]
		public LevelOniwabanLeggings()
		{
			ItemID = 0x64BC;
			Name = "oniwaban leggings";
		}

		public LevelOniwabanLeggings( Serial serial ) : base( serial )
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