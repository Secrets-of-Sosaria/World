using System;
using Server.Network;
using Server.Items;

namespace Server.Items
{
	public class Artifact_ShadowBlade : GiftLongsword
	{
		public override int InitMinHits{ get{ return 80; } }
		public override int InitMaxHits{ get{ return 160; } }

		[Constructable]
		public Artifact_ShadowBlade()
		{
			Name = "Blade of the Shadows";
			ItemID = 0xF61;
			Attributes.AttackChance = 20;
            Attributes.BonusDex = 2;
		    Attributes.CastSpeed = 1;
            Attributes.ReflectPhysical = 5;
            Attributes.RegenHits = 1;
            Attributes.SpellChanneling = 1;
            Attributes.SpellDamage = 20;
			Attributes.WeaponDamage = 45;
			Attributes.WeaponSpeed = 30;
			WeaponAttributes.HitFireball = 10;
            WeaponAttributes.HitLeechMana = 10;
            WeaponAttributes.HitLeechStam = 10;
			WeaponAttributes.SelfRepair = 1;
			Hue = 1899;
			ArtifactLevel = 2;
			Server.Misc.Arty.ArtySetup( this, 15, "" );
		}

		public Artifact_ShadowBlade( Serial serial ) : base( serial )
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
