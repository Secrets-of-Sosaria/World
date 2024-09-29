using System;
using Server;

namespace Server.Items
{
	public class ArcaneGloves : LeatherGloves
	{
		public override int InitMinHits{ get{ return 80; } }
		public override int InitMaxHits{ get{ return 160; } }

		public override int LabelNumber{ get{ return 1061101; } } // Arcane Gloves 

		[Constructable]
		public ArcaneGloves()
		{
			Name = "Arcane Gloves";
			Hue = 0x556;
			Attributes.NightSight = 1;
			Attributes.DefendChance = 10;
			Attributes.CastSpeed = 1;
			Attributes.LowerManaCost = 3;
			Attributes.LowerRegCost = 3;
			Attributes.SpellDamage = 3;
		}

        public override void AddNameProperties(ObjectPropertyList list)
		{
            base.AddNameProperties(list);
			list.Add( 1070722, "Artefact");
        }

		public ArcaneGloves( Serial serial ) : base( serial )
		{
		}

		public override void Serialize( GenericWriter writer )
		{
			base.Serialize( writer );

			writer.Write( (int) 0 );
		}
		
		private void Cleanup( object state ){ Item item = new Artifact_ArcaneGloves(); Server.Misc.Cleanup.DoCleanup( (Item)state, item ); }

public override void Deserialize(GenericReader reader)
		{
			base.Deserialize( reader ); Timer.DelayCall( TimeSpan.FromSeconds( 1.0 ), new TimerStateCallback( Cleanup ), this );

			int version = reader.ReadInt();

			if ( Attributes.NightSight == 0 )
				Attributes.NightSight = 1;
		}
	}
}