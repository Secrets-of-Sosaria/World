using System;
using Server;

namespace Server.Items
{
	public class AbysmalGloves : LeatherGloves
	{
		public override int InitMinHits{ get{ return 80; } }
		public override int InitMaxHits{ get{ return 160; } }

		[Constructable]
		public AbysmalGloves()
		{
			Hue = 1172;
			Name = "Abysmal Gloves";
			ColdBonus = 3;
			EnergyBonus = 9;
			PhysicalBonus = 7;
			PoisonBonus = 7;
			FireBonus = 10;
			ArmorAttributes.SelfRepair = 10;
			Attributes.BonusInt = 5;
			Attributes.LowerManaCost = 5;
			Attributes.LowerRegCost = 10;
			Attributes.SpellDamage = 35;
			Attributes.RegenMana = 5;
		}

        public override void AddNameProperties(ObjectPropertyList list)
		{
            base.AddNameProperties(list);
			list.Add( 1070722, "Artefact");
        }

		public AbysmalGloves( Serial serial ) : base( serial )
		{
		}

		public override void Serialize( GenericWriter writer )
		{
			base.Serialize( writer );
			writer.Write( (int) 0 );
		}

		private void Cleanup( object state ){ Item item = new Artifact_AbysmalGloves(); Server.Misc.Cleanup.DoCleanup( (Item)state, item ); }

public override void Deserialize(GenericReader reader)
		{
			base.Deserialize( reader ); Timer.DelayCall( TimeSpan.FromSeconds( 1.0 ), new TimerStateCallback( Cleanup ), this );
			int version = reader.ReadInt();
		}
	}
}
