using System;
using Server;

namespace Server.Items
{
	public class Artifact_TorchOfTrapFinding : GiftTorch
	{
		[Constructable]
		public Artifact_TorchOfTrapFinding()
		{
			Hue = 0;
			Name = "Torch of Trap Burning";
			SkillBonuses.SetValues(0, SkillName.RemoveTrap, 100);
			ArtifactLevel = 2;
			Server.Misc.Arty.ArtySetup( this, 10, "" );
		}

		public Artifact_TorchOfTrapFinding( Serial serial ) : base( serial )
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