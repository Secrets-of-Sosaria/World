using System;
using Server;

namespace Server.Items
{
	public class DarkNeck : PlateGorget
	{
		public override int InitMinHits{ get{ return 80; } }
		public override int InitMaxHits{ get{ return 160; } }

        public override int BasePhysicalResistance{ get{ return 10; } }
		public override int BaseFireResistance{ get{ return 6; } } 
		public override int BaseColdResistance{ get{ return 8; } }
		public override int BasePoisonResistance{ get{ return 7; } }
		public override int BaseEnergyResistance{ get{ return 10; } }

	 	[Constructable]
	 	public DarkNeck()
	 	{
	 	 	Name = "Dark Neck";
	 	 	Hue = 2025;
	 	 	Attributes.AttackChance = 10;
			Attributes.DefendChance = 10;
	 	 	ArmorAttributes.MageArmor = 1;
			Attributes.SpellDamage = 5;
	 	 	Attributes.NightSight = 1;
		}

        public override void AddNameProperties(ObjectPropertyList list)
		{
            base.AddNameProperties(list);
			list.Add( 1070722, "Artefact");
        }

	 	public DarkNeck(Serial serial) : base( serial )
	 	{
	 	}
	 	public override void Serialize( GenericWriter writer )
	 	{
	 	 	base.Serialize( writer );

	 	 	writer.Write( (int) 0 );
	 	}
	 	private void Cleanup( object state ){ Item item = new Artifact_DarkNeck(); Server.Misc.Cleanup.DoCleanup( (Item)state, item ); }

public override void Deserialize(GenericReader reader)
	 	{
	 	 	base.Deserialize( reader ); Timer.DelayCall( TimeSpan.FromSeconds( 1.0 ), new TimerStateCallback( Cleanup ), this );

	 	 	int version = reader.ReadInt();
	 	}
	}
}
