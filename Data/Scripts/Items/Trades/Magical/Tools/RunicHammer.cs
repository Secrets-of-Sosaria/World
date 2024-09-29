using System;
using Server;
using Server.Engines.Craft;

namespace Server.Items
{
	public class RunicHammer : BaseRunicTool
	{
		public override CraftSystem CraftSystem{ get{ return DefBlacksmithy.CraftSystem; } }

		[Constructable]
		public RunicHammer() : base()
		{
			ItemID = 0x267E;
			Name = "smith hammer";
			Weight = 8.0;
			Layer = Layer.OneHanded;
		}

		public RunicHammer( Serial serial ) : base( serial )
		{
		}

		public override void Serialize( GenericWriter writer )
		{
			base.Serialize( writer );
			writer.Write( (int) 0 ); // version
		}

		public override int isWeapon()
		{
			return 25744;
		}

		public override void Deserialize( GenericReader reader )
		{
			base.Deserialize( reader );
			int version = reader.ReadInt();
			ItemID = 0x267E;
		}
	}
}