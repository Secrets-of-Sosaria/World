using System;
using Server.Network;
using Server.Items;
using Server.Targeting;

namespace Server.Items
{
	public class FalseGodsScepter : Scepter
	{
		public override int InitMinHits{ get{ return 80; } }
		public override int InitMaxHits{ get{ return 160; } }

		[Constructable]
		public FalseGodsScepter()
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
		}

        public override void AddNameProperties(ObjectPropertyList list)
		{
            base.AddNameProperties(list);
			list.Add( 1070722, "Artefact");
        }

		public FalseGodsScepter( Serial serial ) : base( serial )
		{
		}

		public override void Serialize( GenericWriter writer )
		{
			base.Serialize( writer );
			writer.Write( (int) 0 ); // version
		}

		private void Cleanup( object state ){ Item item = new Artifact_FalseGodsScepter(); Server.Misc.Cleanup.DoCleanup( (Item)state, item ); }

public override void Deserialize( GenericReader reader )
		{
			base.Deserialize( reader ); Timer.DelayCall( TimeSpan.FromSeconds( 1.0 ), new TimerStateCallback( Cleanup ), this );

			int version = reader.ReadInt();
		}
	}
}
