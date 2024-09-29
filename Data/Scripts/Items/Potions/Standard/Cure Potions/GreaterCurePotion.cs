using System;
using Server;

namespace Server.Items
{
	public class GreaterCurePotion : BaseCurePotion
	{
		private static CureLevelInfo[] m_LevelInfo = new CureLevelInfo[]
			{
				new CureLevelInfo( Poison.Lesser,  1.00 ),
				new CureLevelInfo( Poison.Regular, 1.00 ),
				new CureLevelInfo( Poison.Greater, 1.00 ),
				new CureLevelInfo( Poison.Deadly,  0.95 ),
				new CureLevelInfo( Poison.Lethal,  0.75 )
			};

		public override CureLevelInfo[] LevelInfo{ get{ return m_LevelInfo; } }

		[Constructable]
		public GreaterCurePotion() : base( PotionEffect.CureGreater )
		{
			Name = "greater cure potion";
			ItemID = 0x24EA;
		}

		public GreaterCurePotion( Serial serial ) : base( serial )
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
			Name = "greater cure potion";
		}
	}
}
