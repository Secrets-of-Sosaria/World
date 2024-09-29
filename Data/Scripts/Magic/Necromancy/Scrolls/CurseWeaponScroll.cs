using System;
using Server;
using Server.Items;

namespace Server.Items
{
	public class CurseWeaponScroll : SpellScroll
	{
		public override string DefaultDescription{ get{ return NecromancerSpellbook.SpellDescription( 103 ); } }

		[Constructable]
		public CurseWeaponScroll() : this( 1 )
		{
		}

		[Constructable]
		public CurseWeaponScroll( int amount ) : base( 103, 0x2263, amount )
		{
			Name = "curse weapon scroll";
		}

		public CurseWeaponScroll( Serial serial ) : base( serial )
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
			Name = "curse weapon scroll";
		}
	}
}