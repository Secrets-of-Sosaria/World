using System;
using System.Collections;
using System.Collections.Generic;
using Server;
using Server.Engines.Craft;

namespace Server.Items
{
	public class Arty_BookOfKnowledge : Spellbook
	{
		[Constructable]
		public Arty_BookOfKnowledge() : base()
		{
			Name = "Book Of Knowledge";
			Hue = 0xAFF;
			ArtifactLevel = 1;

			switch ( Utility.Random( 6 ) ) 
			{
				case 0: this.Content = 0xFFFFFFFFFFF;		break;
				case 1: this.Content = 0xFFFFFFFFFFFF;		break;
				case 2: this.Content = 0xFFFFFFFFFFFFF;		break;
				case 3: this.Content = 0xFFFFFFFFFFFFFF;	break;
				case 4: this.Content = 0xFFFFFFFFFFFFFFF;	break;
				case 5: this.Content = 0xFFFFFFFFFFFFFFFF;	break;
			}

			int attributeCount = Utility.RandomMinMax(8,15);
			int min = Utility.RandomMinMax(15,25);
			int max = min + 40;
			BaseRunicTool.ApplyAttributesTo( (Spellbook)this, attributeCount, min, max );

			Attributes.SpellDamage = 25;
			Attributes.LowerManaCost = 5;
			Attributes.LowerRegCost = 5;
			Attributes.CastSpeed = 1;
			Attributes.CastRecovery = 1;

			SkillBonuses.SetValues( 0, SkillName.Psychology, ( 10.0 + (Utility.RandomMinMax(0,2)*5) ) );
			SkillBonuses.SetValues( 1, SkillName.Magery, ( 10.0 + (Utility.RandomMinMax(0,2)*5) ) );
			SkillBonuses.SetValues( 2, SkillName.MagicResist, ( 10.0 + (Utility.RandomMinMax(0,2)*5) ) );
			SkillBonuses.SetValues( 3, SkillName.Meditation, ( 10.0 + (Utility.RandomMinMax(0,2)*5) ) );
		}

		public Arty_BookOfKnowledge( Serial serial ) : base( serial )
		{
		}

		public override void Serialize( GenericWriter writer )
		{
			base.Serialize( writer );
			writer.Write( (int) 0 ); // version
		}

		public override void Deserialize( GenericReader reader )
		{
			base.Deserialize( reader );
			int version = reader.ReadInt();
			ArtifactLevel = 1;
		}
		
	}
}

