using System;
using Server;

namespace Server.Items
{
	public class Stormbringer : VikingSword
	{
		public override int InitMinHits{ get{ return 80; } }
		public override int InitMaxHits{ get{ return 160; } }

		[Constructable]
		public Stormbringer()
		{
			Hue = 0x76B;
			Name = "Stormbringer";
			ItemID = 0x2D00;
			WeaponAttributes.HitLeechHits = 10;
			WeaponAttributes.HitLeechStam = 10;
			Attributes.BonusStr = 10;
			DamageLevel = WeaponDamageLevel.Vanq;
            Slayer = SlayerName.Repond;
		}

        public override void AddNameProperties(ObjectPropertyList list)
		{
            base.AddNameProperties(list);
			list.Add( 1070722, "Artefact");
			list.Add( 1049644, "Elric's Lost Sword" );
        }

		public Stormbringer( Serial serial ) : base( serial )
		{
		}

		public override void Serialize( GenericWriter writer )
		{
			base.Serialize( writer );
			writer.Write( (int) 0 ); // version
		}

		private void Cleanup( object state ){ Item item = new Artifact_Stormbringer(); Server.Misc.Cleanup.DoCleanup( (Item)state, item ); }

public override void Deserialize( GenericReader reader )
		{
			base.Deserialize( reader ); Timer.DelayCall( TimeSpan.FromSeconds( 1.0 ), new TimerStateCallback( Cleanup ), this );
			int version = reader.ReadInt();
		}
	}
}