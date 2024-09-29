using System;
using Server.Network;
using Server.Items;

namespace Server.Items
{
	public class WindSpirit : Item
	{
		[Constructable]
		public WindSpirit() : base( 0x1F1F )
		{
			Name = "wind spirit";
			ArtifactLevel = 2;
		}

		public WindSpirit( Serial serial ) : base( serial )
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
			ArtifactLevel = 2;
		}
	}
}
