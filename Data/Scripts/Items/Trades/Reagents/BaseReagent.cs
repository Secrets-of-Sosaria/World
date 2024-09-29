using System;
using Server;

namespace Server.Items
{
	public abstract class BaseReagent : Item
	{
		public override Catalogs DefaultCatalog{ get{ return Catalogs.Reagent; } }
		public override string DefaultDescription{ get{ return "Reagents are ingredients used in both alchemical recipes and the casting of some spells. Potions using reagents are mostly created by alchemists, druids, and witches. The magical schools, such as magery and necromancy, require the caster to have these items as well."; } }

		public override double DefaultWeight
		{
			get { return 0.1; }
		}

		public BaseReagent( int itemID ) : this( itemID, 1 )
		{
		}

		public BaseReagent( int itemID, int amount ) : base( itemID )
		{
			Stackable = true;
			Amount = amount;
			InfoText1 = "Reagent";
		}

		public BaseReagent( Serial serial ) : base( serial )
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
			InfoText1 = "Reagent";
		}
	}
}