using System;
using Server.Network;
using Server.Items;
using Server.Targeting;

namespace Server.Items
{
	public class Artifact_VampiricDaisho : GiftDaisho
	{
		public override int InitMinHits{ get{ return 80; } }
		public override int InitMaxHits{ get{ return 160; } }

      [Constructable]
		public Artifact_VampiricDaisho()
		{
			Name = "Vampiric Daisho";
			Hue = 1153;
			WeaponAttributes.HitHarm = 40;
			WeaponAttributes.HitLeechHits = 40;
			WeaponAttributes.HitLeechStam = 40;
			Attributes.SpellChanneling = 1;
			Slayer = SlayerName.BloodDrinking ;
			ArtifactLevel = 2;
			Server.Misc.Arty.ArtySetup( this, 10, "" );
		}

		public Artifact_VampiricDaisho( Serial serial ) : base( serial )
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
