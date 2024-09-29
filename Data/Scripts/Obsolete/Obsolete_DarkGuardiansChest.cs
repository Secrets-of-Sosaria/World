using System;
using Server;

namespace Server.Items
{
	public class DarkGuardiansChest : PlateChest
	{
		public override int InitMinHits{ get{ return 80; } }
		public override int InitMaxHits{ get{ return 160; } }

        public override int BasePhysicalResistance{ get{ return 15; } }
		public override int BaseFireResistance{ get{ return 10; } } 
		public override int BaseColdResistance{ get{ return 10; } }
		public override int BasePoisonResistance{ get{ return 10; } }
		public override int BaseEnergyResistance{ get{ return 10; } }

	 	[Constructable]
	 	public DarkGuardiansChest()
	 	{
	 	 	Name = "Dark Guardian's Chest";
	 	 	Hue = 1141;
	 	 	Attributes.Luck = 150;
	 	 	Attributes.WeaponDamage = 5;
	 	 	ArmorAttributes.MageArmor = 1;
			Attributes.RegenHits = 3;
			Attributes.ReflectPhysical = 15;
	 	 	Attributes.NightSight = 1;
		}

        public override void AddNameProperties(ObjectPropertyList list)
		{
            base.AddNameProperties(list);
			list.Add( 1070722, "Artefact");
        }

	 	public DarkGuardiansChest(Serial serial) : base( serial )
	 	{
	 	}
	 	public override void Serialize( GenericWriter writer )
	 	{
	 	 	base.Serialize( writer );

	 	 	writer.Write( (int) 0 );
	 	}
	 	private void Cleanup( object state ){ Item item = new Artifact_DarkGuardiansChest(); Server.Misc.Cleanup.DoCleanup( (Item)state, item ); }

public override void Deserialize(GenericReader reader)
	 	{
	 	 	base.Deserialize( reader ); Timer.DelayCall( TimeSpan.FromSeconds( 1.0 ), new TimerStateCallback( Cleanup ), this );

	 	 	int version = reader.ReadInt();
	 	}
	}
}
