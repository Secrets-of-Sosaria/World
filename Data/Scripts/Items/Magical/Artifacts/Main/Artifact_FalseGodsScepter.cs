using System;
using Server.Network;
using Server.Items;
using Server.Targeting;

namespace Server.Items
{
	public class Artifact_FalseGodsScepter : GiftScepter
	{
		public override int InitMinHits{ get{ return 80; } }
		public override int InitMaxHits{ get{ return 160; } }

		[Constructable]
		public Artifact_FalseGodsScepter()
		{
			Name = "Scepter Of The False Goddess";
			Hue = 1107;
			WeaponAttributes.HitLeechHits = 20;
			WeaponAttributes.HitLeechMana = 25;
			WeaponAttributes.HitLeechStam = 30;
			Attributes.AttackChance = 15;
			Attributes.CastSpeed = 1;
			Attributes.DefendChance = 5;
			Attributes.SpellChanneling = 1;
			Attributes.SpellDamage = 10;
			ArtifactLevel = 2;
			Server.Misc.Arty.ArtySetup( this, 11, "" );
		}

		public Artifact_FalseGodsScepter( Serial serial ) : base( serial )
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
