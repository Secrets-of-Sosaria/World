using System;
using Server.Network;
using Server.Items;

namespace Server.Items
{
	public class RuneCarvingKnife : AssassinSpike
	{
		public override int LabelNumber{ get{ return 1072915; } } // Rune Carving Knife

		[Constructable]
		public RuneCarvingKnife()
		{
			Hue = 0x48D;
			Name = "Rune Carving Knife";

			WeaponAttributes.HitLeechMana = 40;
			Attributes.RegenStam = 2;
			Attributes.LowerManaCost = 10;
			Attributes.WeaponSpeed = 35;
			Attributes.WeaponDamage = 30;
		}

        public override void AddNameProperties(ObjectPropertyList list)
		{
            base.AddNameProperties(list);
			list.Add( 1070722, "Artefact");
        }

		public RuneCarvingKnife( Serial serial ) : base( serial )
		{
		}

		public override void Serialize( GenericWriter writer )
		{
			base.Serialize( writer );

			writer.WriteEncodedInt( 0 ); // version
		}

		private void Cleanup( object state ){ Item item = new Artifact_RuneCarvingKnife(); Server.Misc.Cleanup.DoCleanup( (Item)state, item ); }

public override void Deserialize( GenericReader reader )
		{
			base.Deserialize( reader ); Timer.DelayCall( TimeSpan.FromSeconds( 1.0 ), new TimerStateCallback( Cleanup ), this );

			int version = reader.ReadEncodedInt();
		}
	}
}