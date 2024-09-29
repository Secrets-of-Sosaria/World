using System;
using Server.Network;
using Server.Items;

namespace Server.Items
{
	public class GlacialStaff : BlackStaff
	{
		public override int Hue{ get { return 0xB78; } }

		[Constructable]
		public GlacialStaff()
		{
			Name = "glacial staff";
			WeaponAttributes.HitHarm = 5 * Utility.RandomMinMax( 1, 5 );
			WeaponAttributes.MageWeapon = Utility.RandomMinMax( 5, 10 );
			ItemID = 0x2AAC;
			AosElementDamages[AosElementAttribute.Cold] = 20 + (5 * Utility.RandomMinMax( 0, 6 ));
			Attributes.SpellChanneling = 1;
		}

		public GlacialStaff( Serial serial ) : base( serial )
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
		}
	}
}
