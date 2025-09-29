using System;
using Server;

namespace Server.Items
{
	public class Artifact_SpiritOfTheTotem : GiftBearMask
	{
		public override int BasePhysicalResistance{ get{ return 20; } }

		[Constructable]
		public Artifact_SpiritOfTheTotem()
		{
			Hue = 0x455;
			Name = "Spirit of the Totem";
			Attributes.BonusStr = 20;
			Attributes.AttackChance = 10;
			ArtifactLevel = 2;
			Server.Misc.Arty.ArtySetup( this, 10, "" );
		}

		public Artifact_SpiritOfTheTotem( Serial serial ) : base( serial )
		{
		}
		
		public override void Serialize( GenericWriter writer )
		{
			base.Serialize( writer );

			writer.Write( (int) 1 );
		}
		
		public override void Deserialize(GenericReader reader)
		{
			base.Deserialize( reader );
			ArtifactLevel = 2;

			int version = reader.ReadInt();

			switch ( version )
			{
				case 0:
				{
					Resistances.Physical = 0;
					break;
				}
			}
		}
	}
}