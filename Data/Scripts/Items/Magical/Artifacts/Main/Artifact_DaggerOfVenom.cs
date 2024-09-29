using System;
using Server.Network;
using Server.Items;
using Server.Targeting;

namespace Server.Items
{
	public class Artifact_DaggerOfVenom : GiftDagger
	{
		public override int InitMinHits{ get{ return 80; } }
		public override int InitMaxHits{ get{ return 160; } }

		[Constructable]
		public Artifact_DaggerOfVenom()
		{
			Name = "Dagger of Venom";
			Hue = 0x4F6;
			ItemID = 0x2677;
			AosElementDamages.Physical = 50;
			AosElementDamages.Poison = 50;
			ArtifactLevel = 2;
			Server.Misc.Arty.ArtySetup( this, 10, "Dripping With Venom " );
		}

		public override void OnHit( Mobile attacker, Mobile defender, double damageBonus )
		{
			base.OnHit( attacker, defender, damageBonus );

			switch ( Utility.RandomMinMax( 0, 12 ) ) 
			{
				case 0: defender.ApplyPoison( attacker, Poison.Lesser ); Misc.Titles.AwardKarma( attacker, -50, true ); break;
				case 1: defender.ApplyPoison( attacker, Poison.Regular ); Misc.Titles.AwardKarma( attacker, -60, true ); break;
				case 2: defender.ApplyPoison( attacker, Poison.Greater ); Misc.Titles.AwardKarma( attacker, -70, true ); break;
				case 3: defender.ApplyPoison( attacker, Poison.Deadly ); Misc.Titles.AwardKarma( attacker, -80, true ); break;
				case 4: defender.ApplyPoison( attacker, Poison.Deadly ); Misc.Titles.AwardKarma( attacker, -90, true ); break;
			}
		}

		public Artifact_DaggerOfVenom( Serial serial ) : base( serial )
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
