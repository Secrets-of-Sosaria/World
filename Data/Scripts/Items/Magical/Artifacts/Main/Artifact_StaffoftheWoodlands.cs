using System;
using Server;
using Server.Items;

namespace Server.Items
{
	public class Artifact_StaffoftheWoodlands : GiftShepherdsCrook
	{
		public override int InitMinHits{ get{ return 80; } }
		public override int InitMaxHits{ get{ return 160; } }

		[Constructable]
		public Artifact_StaffoftheWoodlands() : base()
		{
			Name = "Staff of the Woodlands";
			Hue = 0x8A0;
			
			Attributes.SpellChanneling = 1;
			Attributes.RegenMana = 3;
			Attributes.DefendChance = 15;
			SkillBonuses.SetValues(0, SkillName.Druidism,  10);
			SkillBonuses.SetValues(1, SkillName.Taming,  10);
			SkillBonuses.SetValues(2, SkillName.Herding,  10);
			ArtifactLevel = 2;
			Server.Misc.Arty.ArtySetup( this, 10, "" );
		}

		public override void GetDamageTypes( Mobile wielder, out int phys, out int fire, out int cold, out int pois, out int nrgy, out int chaos, out int direct )
		{
			chaos = fire = cold = pois = nrgy = direct = 0;
			phys = 100;
		}

		public Artifact_StaffoftheWoodlands( Serial serial ) : base( serial )
		{
		}

		public override void Serialize( GenericWriter writer )
		{
			base.Serialize( writer );
			writer.WriteEncodedInt( 0 ); // version
		}

		public override void Deserialize( GenericReader reader )
		{
			base.Deserialize( reader );
			ArtifactLevel = 2;
			int version = reader.ReadEncodedInt();
		}
	}
}
