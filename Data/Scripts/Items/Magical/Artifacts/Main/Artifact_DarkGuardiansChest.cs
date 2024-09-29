using System;
using Server;

namespace Server.Items
{
	public class Artifact_DarkGuardiansChest : GiftPlateChest
	{
		public override int InitMinHits{ get{ return 80; } }
		public override int InitMaxHits{ get{ return 160; } }

        public override int BasePhysicalResistance{ get{ return 15; } }
		public override int BaseFireResistance{ get{ return 10; } } 
		public override int BaseColdResistance{ get{ return 10; } }
		public override int BasePoisonResistance{ get{ return 10; } }
		public override int BaseEnergyResistance{ get{ return 10; } }

	 	[Constructable]
	 	public Artifact_DarkGuardiansChest()
	 	{
	 	 	Name = "Dark Guardian's Chest";
	 	 	Hue = 1141;
			ItemID = 0x1415;
	 	 	Attributes.Luck = 150;
	 	 	Attributes.WeaponDamage = 5;
	 	 	ArmorAttributes.MageArmor = 1;
			Attributes.RegenHits = 3;
			Attributes.ReflectPhysical = 15;
	 	 	Attributes.NightSight = 1;
			ArtifactLevel = 2;
			Server.Misc.Arty.ArtySetup( this, 11, "" );
		}

	 	public Artifact_DarkGuardiansChest(Serial serial) : base( serial )
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
			ArtifactLevel = 2;
	 	 	int version = reader.ReadInt();
	 	}
	}
}
