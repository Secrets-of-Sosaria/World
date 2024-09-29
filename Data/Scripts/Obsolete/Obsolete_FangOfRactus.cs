using System;
using Server;

namespace Server.Items
{
	public class FangOfRactus : Kryss
	{
		public override int InitMinHits{ get{ return 80; } }
		public override int InitMaxHits{ get{ return 160; } }

		public override bool CanFortify{ get{ return false; } }

		[Constructable]
		public FangOfRactus()
		{
			Name = "Fang of Ractus";
			Hue = 0x117;

			Attributes.SpellChanneling = 1;
			Attributes.AttackChance = 5;
			Attributes.DefendChance = 5;
			Attributes.WeaponDamage = 35;

			SkillBonuses.SetValues( 0, SkillName.Poisoning, 20 );

			WeaponAttributes.HitPoisonArea = 20;
			WeaponAttributes.ResistPoisonBonus = 15;
		}

        public override void AddNameProperties(ObjectPropertyList list)
		{
            base.AddNameProperties(list);
			list.Add( 1070722, "Artefact");
        }

		public FangOfRactus( Serial serial ) : base( serial )
		{
		}

		public override void Serialize( GenericWriter writer )
		{
			base.Serialize( writer );

			writer.Write( (int) 0 );
		}
		
		private void Cleanup( object state ){ Item item = new Artifact_FangOfRactus(); Server.Misc.Cleanup.DoCleanup( (Item)state, item ); }

public override void Deserialize(GenericReader reader)
		{
			base.Deserialize( reader ); Timer.DelayCall( TimeSpan.FromSeconds( 1.0 ), new TimerStateCallback( Cleanup ), this );

			int version = reader.ReadInt();
		}
	}
}
