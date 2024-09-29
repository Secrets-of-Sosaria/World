using System;
using Server;

namespace Server.Items
{
	public class Artifact_TitansHammer : GiftWarHammer
	{
		public override int InitMinHits{ get{ return 80; } }
		public override int InitMaxHits{ get{ return 160; } }

		[Constructable]
		public Artifact_TitansHammer()
		{
			Name = "Titan's Hammer";
			Hue = 0x482;
			ItemID = 0x267C;
			WeaponAttributes.HitEnergyArea = 100;
			Attributes.BonusStr = 15;
			Attributes.AttackChance = 15;
			Attributes.WeaponDamage = 50;
			ArtifactLevel = 2;
			Server.Misc.Arty.ArtySetup( this, 10, "" );
		}

		public Artifact_TitansHammer( Serial serial ) : base( serial )
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