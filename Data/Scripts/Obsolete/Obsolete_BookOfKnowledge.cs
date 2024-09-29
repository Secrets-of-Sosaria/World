using System;
using System.Collections;
using System.Collections.Generic;
using Server;
using Server.Engines.Craft;

namespace Server.Items
{
	public class BookOfKnowledge : Spellbook
	{
		[Constructable]
		public BookOfKnowledge() : base()
		{
			Name = "Book Of Knowledge";
			Hue = 0xAFF;
			
			Attributes.SpellDamage = 25;
			Attributes.LowerManaCost = 5;
			Attributes.LowerRegCost = 5;
			Attributes.CastSpeed = 1;
			Attributes.CastRecovery = 1;
			LootType = LootType.Regular;
		}

        public override void AddNameProperties(ObjectPropertyList list)
		{
            base.AddNameProperties(list);
			list.Add( 1070722, "Artefact");
        }

		public BookOfKnowledge( Serial serial ) : base( serial )
		{
		}

		public override void Serialize( GenericWriter writer )
		{
			base.Serialize( writer );
			writer.Write( (int) 0 ); // version
		}

		private void Cleanup( object state ){ Item item = new Arty_BookOfKnowledge(); Server.Misc.Cleanup.DoCleanup( (Item)state, item ); }

public override void Deserialize( GenericReader reader )
		{
			base.Deserialize( reader ); Timer.DelayCall( TimeSpan.FromSeconds( 1.0 ), new TimerStateCallback( Cleanup ), this );
			int version = reader.ReadInt();
		}
		
	}
}

