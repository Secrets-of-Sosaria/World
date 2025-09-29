using System;
using Server.Network;
using Server.Items;
using Server.Targeting;

namespace Server.Items
{
	public class Artifact_GeishasObi : GiftObi
	{
		public override int InitMinHits{ get{ return 80; } }
		public override int InitMaxHits{ get{ return 160; } }

		public override int BasePhysicalResistance{ get{ return 5; } } 
      
		[Constructable]
		public Artifact_GeishasObi()
		{
			Name = "Geishas Obi";
			Hue = 31;
			SkillBonuses.SetValues( 0, SkillName.Mercantile, 10 );
			Attributes.BonusInt = 5;
			Attributes.BonusDex = 5;
			Attributes.DefendChance = 5;
			Attributes.ReflectPhysical = 20;
			Attributes.RegenHits = 7;
			Attributes.RegenStam = 7;
			ArtifactLevel = 2;
			Server.Misc.Arty.ArtySetup( this, 10, "" );
		}

		public Artifact_GeishasObi( Serial serial ) : base( serial )
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
			ArtifactLevel = 2;

			int version = reader.ReadInt();
		}
	}
}
