using System;
using Server;

namespace Server.Items
{
	public class EmbroideredOakLeafCloak : BaseOuterTorso
	{
		public override int InitMinHits{ get{ return 150; } }
		public override int InitMaxHits{ get{ return 150; } }

		public override bool CanFortify{ get{ return false; } }

		[Constructable]
		public EmbroideredOakLeafCloak() : base( 0x2684 )
		{
			Name = "Embroidered Oak Leaf Cloak";
			Hue = 0x483;
			StrRequirement = 0;

			SkillBonuses.Skill_1_Name = SkillName.Stealth;
			SkillBonuses.Skill_1_Value = 5;
		}

        public override void AddNameProperties(ObjectPropertyList list)
		{
            base.AddNameProperties(list);
			list.Add( 1070722, "Artefact");
        }

		public EmbroideredOakLeafCloak( Serial serial ) : base( serial )
		{
		}
		
		public override void Serialize( GenericWriter writer )
		{
			base.Serialize( writer );

			writer.Write( (int) 0 );
		}
		
		private void Cleanup( object state ){ Item item = new Artifact_EmbroideredOakLeafCloak(); Server.Misc.Cleanup.DoCleanup( (Item)state, item ); }

public override void Deserialize(GenericReader reader)
		{
			base.Deserialize( reader ); Timer.DelayCall( TimeSpan.FromSeconds( 1.0 ), new TimerStateCallback( Cleanup ), this );

			int version = reader.ReadInt();
		}
	}
}
