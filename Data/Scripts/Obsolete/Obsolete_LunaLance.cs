using System;
using Server;

namespace Server.Items
{
	public class LunaLance : Lance
	{
		public override int InitMinHits{ get{ return 80; } }
		public override int InitMaxHits{ get{ return 160; } }

		[Constructable]
		public LunaLance()
		{
			Name = "Holy Lance";
			Hue = 0x47E;
			SkillBonuses.SetValues( 0, SkillName.Knightship, 10.0 );
			Attributes.BonusStr = 5;
			Attributes.WeaponSpeed = 20;
			Attributes.WeaponDamage = 35;
			WeaponAttributes.UseBestSkill = 1;
		}

        public override void AddNameProperties(ObjectPropertyList list)
		{
            base.AddNameProperties(list);
			list.Add( 1070722, "Artefact");
        }

		public LunaLance( Serial serial ) : base( serial )
		{
		}

		public override void Serialize( GenericWriter writer )
		{
			base.Serialize( writer );

			writer.Write( (int) 0 );
		}
		
		private void Cleanup( object state ){ Item item = new Artifact_LunaLance(); Server.Misc.Cleanup.DoCleanup( (Item)state, item ); }

public override void Deserialize(GenericReader reader)
		{
			base.Deserialize( reader ); Timer.DelayCall( TimeSpan.FromSeconds( 1.0 ), new TimerStateCallback( Cleanup ), this );

			int version = reader.ReadInt();
		}
	}
}