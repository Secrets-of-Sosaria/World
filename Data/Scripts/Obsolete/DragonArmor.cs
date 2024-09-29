using System;
using Server;
using Server.Misc;

namespace Server.Items
{
	public class MagicDragonLegs : DragonLegs /////////////////////////////////////////////////////////
	{
		public string DragonFrom;
		public string DragonKiller;

		[CommandProperty(AccessLevel.Owner)]
		public string Dragon_From { get { return DragonFrom; } set { DragonFrom = value; InvalidateProperties(); } }

		[CommandProperty(AccessLevel.Owner)]
		public string Dragon_Killer { get { return DragonKiller; } set { DragonKiller = value; InvalidateProperties(); } }

		[Constructable]
		public MagicDragonLegs()
		{
			Name = "scalemail leggings";
		}

		public MagicDragonLegs( Serial serial ) : base( serial )
		{
		}

        public override void AddNameProperties(ObjectPropertyList list)
		{
            base.AddNameProperties(list);
			list.Add( 1070722, DragonFrom );
            list.Add( 1049644, DragonKiller );
        }

		public override void Serialize( GenericWriter writer )
		{
			base.Serialize( writer );
			writer.Write( (int) 0 );
            writer.Write( DragonFrom );
            writer.Write( DragonKiller );
		}
		
		public override void Deserialize(GenericReader reader)
		{
			base.Deserialize( reader );
			int version = reader.ReadInt();
            DragonFrom = reader.ReadString();
            DragonKiller = reader.ReadString();
			Timer.DelayCall( TimeSpan.FromSeconds( 10.0 ), new TimerStateCallback( Cleanup ), this );
		}

		private void Cleanup( object state )
		{
			Item item = new DragonLegs();
			((BaseArmor)item).Resource = this.Resource;
			item.InfoText1 = DragonFrom;
			item.InfoText2 = DragonKiller;
			Server.Misc.Cleanup.DoCleanup( (Item)state, item );
		}
	}
	public class MagicDragonGloves : DragonGloves /////////////////////////////////////////////////////
	{
		public string DragonFrom;
		public string DragonKiller;

		[CommandProperty(AccessLevel.Owner)]
		public string Dragon_From { get { return DragonFrom; } set { DragonFrom = value; InvalidateProperties(); } }

		[CommandProperty(AccessLevel.Owner)]
		public string Dragon_Killer { get { return DragonKiller; } set { DragonKiller = value; InvalidateProperties(); } }

		[Constructable]
		public MagicDragonGloves()
		{
			Name = "scalemail gloves";
		}

        public override void AddNameProperties(ObjectPropertyList list)
		{
            base.AddNameProperties(list);
			list.Add( 1070722, DragonFrom );
            list.Add( 1049644, DragonKiller );
        }

		public MagicDragonGloves( Serial serial ) : base( serial )
		{
		}

		public override void Serialize( GenericWriter writer )
		{
			base.Serialize( writer );
			writer.Write( (int) 0 );
            writer.Write( DragonFrom );
            writer.Write( DragonKiller );
		}
		
		public override void Deserialize(GenericReader reader)
		{
			base.Deserialize( reader );
			int version = reader.ReadInt();
            DragonFrom = reader.ReadString();
            DragonKiller = reader.ReadString();
			Timer.DelayCall( TimeSpan.FromSeconds( 10.0 ), new TimerStateCallback( Cleanup ), this );
		}

		private void Cleanup( object state )
		{
			Item item = new DragonGloves();
			((BaseArmor)item).Resource = this.Resource;
			item.InfoText1 = DragonFrom;
			item.InfoText2 = DragonKiller;
			Server.Misc.Cleanup.DoCleanup( (Item)state, item );
		}
	}
	public class MagicDragonArms : DragonArms /////////////////////////////////////////////////////////
	{
		public string DragonFrom;
		public string DragonKiller;

		[CommandProperty(AccessLevel.Owner)]
		public string Dragon_From { get { return DragonFrom; } set { DragonFrom = value; InvalidateProperties(); } }

		[CommandProperty(AccessLevel.Owner)]
		public string Dragon_Killer { get { return DragonKiller; } set { DragonKiller = value; InvalidateProperties(); } }

		[Constructable]
		public MagicDragonArms()
		{
			Name = "scalemail arms";
		}

        public override void AddNameProperties(ObjectPropertyList list)
		{
            base.AddNameProperties(list);
			list.Add( 1070722, DragonFrom );
            list.Add( 1049644, DragonKiller );
        }

		public MagicDragonArms( Serial serial ) : base( serial )
		{
		}

		public override void Serialize( GenericWriter writer )
		{
			base.Serialize( writer );
			writer.Write( (int) 0 );
            writer.Write( DragonFrom );
            writer.Write( DragonKiller );
		}
		
		public override void Deserialize(GenericReader reader)
		{
			base.Deserialize( reader );
			int version = reader.ReadInt();
            DragonFrom = reader.ReadString();
            DragonKiller = reader.ReadString();
			Timer.DelayCall( TimeSpan.FromSeconds( 10.0 ), new TimerStateCallback( Cleanup ), this );
		}

		private void Cleanup( object state )
		{
			Item item = new DragonArms();
			((BaseArmor)item).Resource = this.Resource;
			item.InfoText1 = DragonFrom;
			item.InfoText2 = DragonKiller;
			Server.Misc.Cleanup.DoCleanup( (Item)state, item );
		}
	}
	public class MagicDragonChest : DragonChest ///////////////////////////////////////////////////////
	{
		public string DragonFrom;
		public string DragonKiller;

		[CommandProperty(AccessLevel.Owner)]
		public string Dragon_From { get { return DragonFrom; } set { DragonFrom = value; InvalidateProperties(); } }

		[CommandProperty(AccessLevel.Owner)]
		public string Dragon_Killer { get { return DragonKiller; } set { DragonKiller = value; InvalidateProperties(); } }

		[Constructable]
		public MagicDragonChest()
		{
			Name = "scalemail tunic";
		}

        public override void AddNameProperties(ObjectPropertyList list)
		{
            base.AddNameProperties(list);
			list.Add( 1070722, DragonFrom );
            list.Add( 1049644, DragonKiller );
        }

		public MagicDragonChest( Serial serial ) : base( serial )
		{
		}

		public override void Serialize( GenericWriter writer )
		{
			base.Serialize( writer );
			writer.Write( (int) 0 );
            writer.Write( DragonFrom );
            writer.Write( DragonKiller );
		}
		
		public override void Deserialize(GenericReader reader)
		{
			base.Deserialize( reader );
			int version = reader.ReadInt();
            DragonFrom = reader.ReadString();
            DragonKiller = reader.ReadString();
			Timer.DelayCall( TimeSpan.FromSeconds( 10.0 ), new TimerStateCallback( Cleanup ), this );
		}

		private void Cleanup( object state )
		{
			Item item = new DragonChest();
			((BaseArmor)item).Resource = this.Resource;
			item.InfoText1 = DragonFrom;
			item.InfoText2 = DragonKiller;
			Server.Misc.Cleanup.DoCleanup( (Item)state, item );
		}
	}
	public class MagicDragonHelm : DragonHelm /////////////////////////////////////////////////////////
	{
		public string DragonFrom;
		public string DragonKiller;

		[CommandProperty(AccessLevel.Owner)]
		public string Dragon_From { get { return DragonFrom; } set { DragonFrom = value; InvalidateProperties(); } }

		[CommandProperty(AccessLevel.Owner)]
		public string Dragon_Killer { get { return DragonKiller; } set { DragonKiller = value; InvalidateProperties(); } }

		[Constructable]
		public MagicDragonHelm()
		{
			Name = "scalemail helm";
		}

        public override void AddNameProperties(ObjectPropertyList list)
		{
            base.AddNameProperties(list);
			list.Add( 1070722, DragonFrom );
            list.Add( 1049644, DragonKiller );
        }

		public MagicDragonHelm( Serial serial ) : base( serial )
		{
		}

		public override void Serialize( GenericWriter writer )
		{
			base.Serialize( writer );
			writer.Write( (int) 0 );
            writer.Write( DragonFrom );
            writer.Write( DragonKiller );
		}
		
		public override void Deserialize(GenericReader reader)
		{
			base.Deserialize( reader );
			int version = reader.ReadInt();
            DragonFrom = reader.ReadString();
            DragonKiller = reader.ReadString();
			Timer.DelayCall( TimeSpan.FromSeconds( 10.0 ), new TimerStateCallback( Cleanup ), this );
		}

		private void Cleanup( object state )
		{
			Item item = new DragonHelm();
			((BaseArmor)item).Resource = this.Resource;
			item.InfoText1 = DragonFrom;
			item.InfoText2 = DragonKiller;
			Server.Misc.Cleanup.DoCleanup( (Item)state, item );
		}
	}
}