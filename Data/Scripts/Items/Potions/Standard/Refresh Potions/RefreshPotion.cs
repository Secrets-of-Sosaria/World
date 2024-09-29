using System;
using Server;

namespace Server.Items
{
	public class RefreshPotion : BaseRefreshPotion
	{
		public override string DefaultDescription{ get{ return "These potions will recover about 25 percent of your stamina."; } }

		public override double Refresh{ get{ return 0.25; } }

		[Constructable]
		public RefreshPotion() : base( PotionEffect.Refresh )
		{
			Name = "refresh potion";
		}

		public RefreshPotion( Serial serial ) : base( serial )
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
			Name = "refresh potion";
		}
	}
}
