using Server;
using System;
using System.Text;
using System.Collections;
using Server.Network;
using Server.Targeting;
using Server.Mobiles;
using Server.Spells;
using Server.Items;

namespace Server.Items
{
	public class MagicalWand : BaseTrinket
	{
		public override Catalogs DefaultCatalog{ get{ return Catalogs.Trinket; } }
		public override CraftResource DefaultResource{ get{ return CraftResource.None; } }

		[Constructable]
		public MagicalWand() : this( Utility.RandomList( 0x4CEB, 0x4CEC, 0x4CED, 0x4CEE ), Layer.Trinket, 1 )
		{
		}

		[Constructable]
		public MagicalWand( int level ) : this( Utility.RandomList( 0x4CEB, 0x4CEC, 0x4CED, 0x4CEE ), Layer.Trinket, level )
		{
		}

		[Constructable]
		public MagicalWand( int itemID, Layer layer, int level ) : base( itemID )
		{
			SpellItems.setSpell( level, this );
			Weight = 1.0;
			Layer = Layer.Trinket;
			NotIDSkill = IDSkill.Mercantile;
			NotIDSource = Identity.Wand;
			ColorText1 = "Magic Wand";
			ColorHue1 = "0080FF";
		}

		public override void MagicSpellChanged( MagicSpell spell )
		{
			int level = SpellItems.GetLevel( (int)spell );
			SpellItems.ChangeMagicSpell( spell, this, true );
			InfoData = "This wand can cast the " + SpellItems.GetName( Enchanted ) + " spell. " + SpellItems.GetData( Enchanted ) + " Wands must be equipped to cast spells, where mana is usually required. If your wand runs out of charges, try visiting a wizard to see if they will recharge it for you.";
			InfoText2 = SpellItems.GetCircle( Enchanted );
			Name = "Magic Wand of " + SpellItems.GetNameUpper( Enchanted );
			CoinPrice = level * 100;
		}

		public override void CastEnchantment( Mobile from )
		{
			Server.Items.SpellItems.CastEnchantment( from, this );
		}

		public override void OnDoubleClick( Mobile from )
		{
			CastEnchantment( from );
		}

		public MagicalWand( Serial serial ) : base( serial )
		{
		}

		public override void Serialize( GenericWriter writer )
		{
			base.Serialize( writer );
			writer.Write( (int) 1 ); // version
		}

		public override void Deserialize( GenericReader reader )
		{
			base.Deserialize( reader );
			int version = reader.ReadInt();
		}
	}
}