using System;

namespace Server.Items
{
	public class StatueGateGuardian : BaseStatueDeed
	{
		public override CraftResource DefaultResource{ get{ return CraftResource.Iron; } }
		public override Catalogs DefaultCatalog{ get{ return Catalogs.Stone; } }

		[Constructable]
		public StatueGateGuardian() : base()
		{
			Name = "statue of a gate guardian (east)";
			Weight = 1;
			ItemID = 0x32F0;
		}

		public StatueGateGuardian(Serial serial) : base(serial)
		{
		}

		public override void Serialize(GenericWriter writer)
		{
			base.Serialize(writer);
			writer.Write((int) 0);
		}

		public override void Deserialize(GenericReader reader)
		{
			base.Deserialize(reader);
			int version = reader.ReadInt();
		}
	}
	public class StatueGiantWarrior : BaseStatueDeed
	{
		public override CraftResource DefaultResource{ get{ return CraftResource.Iron; } }
		public override Catalogs DefaultCatalog{ get{ return Catalogs.Stone; } }

		[Constructable]
		public StatueGiantWarrior() : base()
		{
			Name = "statue of a warrior (east)";
			Weight = 3;
			ItemID = 0x32F0;
		}

		public StatueGiantWarrior(Serial serial) : base(serial)
		{
		}

		public override void Serialize(GenericWriter writer)
		{
			base.Serialize(writer);
			writer.Write((int) 0);
		}

		public override void Deserialize(GenericReader reader)
		{
			base.Deserialize(reader);
			int version = reader.ReadInt();
		}
	}
	public class StatueHorseRider : BaseStatueDeed
	{
		public override CraftResource DefaultResource{ get{ return CraftResource.Iron; } }
		public override Catalogs DefaultCatalog{ get{ return Catalogs.Stone; } }

		[Constructable]
		public StatueHorseRider() : base()
		{
			Name = "statue of a rider (east)";
			Weight = 5;
			ItemID = 0x32F0;
		}

		public StatueHorseRider(Serial serial) : base(serial)
		{
		}

		public override void Serialize(GenericWriter writer)
		{
			base.Serialize(writer);
			writer.Write((int) 0);
		}

		public override void Deserialize(GenericReader reader)
		{
			base.Deserialize(reader);
			int version = reader.ReadInt();
		}
	}
	public class StatueCapeWarrior : BaseStatueDeed
	{
		public override CraftResource DefaultResource{ get{ return CraftResource.Iron; } }
		public override Catalogs DefaultCatalog{ get{ return Catalogs.Stone; } }

		[Constructable]
		public StatueCapeWarrior() : base()
		{
			Name = "statue of a warrior (east)";
			Weight = 7;
			ItemID = 0x32F0;
		}

		public StatueCapeWarrior(Serial serial) : base(serial)
		{
		}

		public override void Serialize(GenericWriter writer)
		{
			base.Serialize(writer);
			writer.Write((int) 0);
		}

		public override void Deserialize(GenericReader reader)
		{
			base.Deserialize(reader);
			int version = reader.ReadInt();
		}
	}
	public class StoneSarcophagus : BaseStatueDeed
	{
		public override CraftResource DefaultResource{ get{ return CraftResource.Iron; } }
		public override Catalogs DefaultCatalog{ get{ return Catalogs.Stone; } }

		[Constructable]
		public StoneSarcophagus() : base()
		{
			Name = "stone sarcophagus (east)";
			Weight = 9;
			ItemID = 0x32F0;
		}

		public StoneSarcophagus(Serial serial) : base(serial)
		{
		}

		public override void Serialize(GenericWriter writer)
		{
			base.Serialize(writer);
			writer.Write((int) 0);
		}

		public override void Deserialize(GenericReader reader)
		{
			base.Deserialize(reader);
			int version = reader.ReadInt();
		}
	}
	public class StoneBenchLong : BaseStatueDeed
	{
		public override CraftResource DefaultResource{ get{ return CraftResource.Iron; } }
		public override Catalogs DefaultCatalog{ get{ return Catalogs.Stone; } }

		[Constructable]
		public StoneBenchLong() : base()
		{
			Name = "long stone bench (east)";
			Weight = 11;
			ItemID = 0x32F0;
		}

		public StoneBenchLong(Serial serial) : base(serial)
		{
		}

		public override void Serialize(GenericWriter writer)
		{
			base.Serialize(writer);
			writer.Write((int) 0);
		}

		public override void Deserialize(GenericReader reader)
		{
			base.Deserialize(reader);
			int version = reader.ReadInt();
		}
	}
	public class StoneBenchShort : BaseStatueDeed
	{
		public override CraftResource DefaultResource{ get{ return CraftResource.Iron; } }
		public override Catalogs DefaultCatalog{ get{ return Catalogs.Stone; } }

		[Constructable]
		public StoneBenchShort() : base()
		{
			Name = "short stone bench (east)";
			Weight = 13;
			ItemID = 0x32F0;
		}

		public StoneBenchShort(Serial serial) : base(serial)
		{
		}

		public override void Serialize(GenericWriter writer)
		{
			base.Serialize(writer);
			writer.Write((int) 0);
		}

		public override void Deserialize(GenericReader reader)
		{
			base.Deserialize(reader);
			int version = reader.ReadInt();
		}
	}
	public class StoneTableLong : BaseStatueDeed
	{
		public override CraftResource DefaultResource{ get{ return CraftResource.Iron; } }
		public override Catalogs DefaultCatalog{ get{ return Catalogs.Stone; } }

		[Constructable]
		public StoneTableLong() : base()
		{
			Name = "long stone table (east)";
			Weight = 15;
			ItemID = 0x32F0;
		}

		public StoneTableLong(Serial serial) : base(serial)
		{
		}

		public override void Serialize(GenericWriter writer)
		{
			base.Serialize(writer);
			writer.Write((int) 0);
		}

		public override void Deserialize(GenericReader reader)
		{
			base.Deserialize(reader);
			int version = reader.ReadInt();
		}
	}
	public class StoneTableShort : BaseStatueDeed
	{
		public override CraftResource DefaultResource{ get{ return CraftResource.Iron; } }
		public override Catalogs DefaultCatalog{ get{ return Catalogs.Stone; } }

		[Constructable]
		public StoneTableShort() : base()
		{
			Name = "short stone table (east)";
			Weight = 17;
			ItemID = 0x32F0;
		}

		public StoneTableShort(Serial serial) : base(serial)
		{
		}

		public override void Serialize(GenericWriter writer)
		{
			base.Serialize(writer);
			writer.Write((int) 0);
		}

		public override void Deserialize(GenericReader reader)
		{
			base.Deserialize(reader);
			int version = reader.ReadInt();
		}
	}
	public class StatueAngelTall : BaseStatueDeed
	{
		public override CraftResource DefaultResource{ get{ return CraftResource.Iron; } }
		public override Catalogs DefaultCatalog{ get{ return Catalogs.Stone; } }

		[Constructable]
		public StatueAngelTall() : base()
		{
			Name = "statue of an angel (east)";
			Weight = 19;
			ItemID = 0x32F0;
		}

		public StatueAngelTall(Serial serial) : base(serial)
		{
		}

		public override void Serialize(GenericWriter writer)
		{
			base.Serialize(writer);
			writer.Write((int) 0);
		}

		public override void Deserialize(GenericReader reader)
		{
			base.Deserialize(reader);
			int version = reader.ReadInt();
		}
	}
	public class StatueWiseManTall : BaseStatueDeed
	{
		public override CraftResource DefaultResource{ get{ return CraftResource.Iron; } }
		public override Catalogs DefaultCatalog{ get{ return Catalogs.Stone; } }

		[Constructable]
		public StatueWiseManTall() : base()
		{
			Name = "statue of a wise man (east)";
			Weight = 21;
			ItemID = 0x32F0;
		}

		public StatueWiseManTall(Serial serial) : base(serial)
		{
		}

		public override void Serialize(GenericWriter writer)
		{
			base.Serialize(writer);
			writer.Write((int) 0);
		}

		public override void Deserialize(GenericReader reader)
		{
			base.Deserialize(reader);
			int version = reader.ReadInt();
		}
	}
	public class StatueWomanTall : BaseStatueDeed
	{
		public override CraftResource DefaultResource{ get{ return CraftResource.Iron; } }
		public override Catalogs DefaultCatalog{ get{ return Catalogs.Stone; } }

		[Constructable]
		public StatueWomanTall() : base()
		{
			Name = "statue of a woman (east)";
			Weight = 23;
			ItemID = 0x32F0;
		}

		public StatueWomanTall(Serial serial) : base(serial)
		{
		}

		public override void Serialize(GenericWriter writer)
		{
			base.Serialize(writer);
			writer.Write((int) 0);
		}

		public override void Deserialize(GenericReader reader)
		{
			base.Deserialize(reader);
			int version = reader.ReadInt();
		}
	}
	public class LargeStatueLion : BaseStatueDeed
	{
		public override CraftResource DefaultResource{ get{ return CraftResource.Iron; } }
		public override Catalogs DefaultCatalog{ get{ return Catalogs.Stone; } }

		[Constructable]
		public LargeStatueLion() : base()
		{
			Name = "large statue of a lion (east)";
			Weight = 25;
			ItemID = 0x32F0;
		}

		public LargeStatueLion(Serial serial) : base(serial)
		{
		}

		public override void Serialize(GenericWriter writer)
		{
			base.Serialize(writer);
			writer.Write((int) 0);
		}

		public override void Deserialize(GenericReader reader)
		{
			base.Deserialize(reader);
			int version = reader.ReadInt();
		}
	}
	public class MediumStatueLion : BaseStatueDeed
	{
		public override CraftResource DefaultResource{ get{ return CraftResource.Iron; } }
		public override Catalogs DefaultCatalog{ get{ return Catalogs.Stone; } }

		[Constructable]
		public MediumStatueLion() : base()
		{
			Name = "medium statue of a lion (east)";
			Weight = 27;
			ItemID = 0x32F0;
		}

		public MediumStatueLion(Serial serial) : base(serial)
		{
		}

		public override void Serialize(GenericWriter writer)
		{
			base.Serialize(writer);
			writer.Write((int) 0);
		}

		public override void Deserialize(GenericReader reader)
		{
			base.Deserialize(reader);
			int version = reader.ReadInt();
		}
	}
	public class SmallStatueLion : BaseStatueDeed
	{
		public override CraftResource DefaultResource{ get{ return CraftResource.Iron; } }
		public override Catalogs DefaultCatalog{ get{ return Catalogs.Stone; } }

		[Constructable]
		public SmallStatueLion() : base()
		{
			Name = "small statue of a lion (east)";
			Weight = 29;
			ItemID = 0x32F0;
		}

		public SmallStatueLion(Serial serial) : base(serial)
		{
		}

		public override void Serialize(GenericWriter writer)
		{
			base.Serialize(writer);
			writer.Write((int) 0);
		}

		public override void Deserialize(GenericReader reader)
		{
			base.Deserialize(reader);
			int version = reader.ReadInt();
		}
	}
	public class StatueDemonicFace : BaseStatueDeed
	{
		public override CraftResource DefaultResource{ get{ return CraftResource.Iron; } }
		public override Catalogs DefaultCatalog{ get{ return Catalogs.Stone; } }

		[Constructable]
		public StatueDemonicFace() : base()
		{
			Name = "stone demonic face (east)";
			Weight = 31;
			ItemID = 0x32F0;
		}

		public StatueDemonicFace(Serial serial) : base(serial)
		{
		}

		public override void Serialize(GenericWriter writer)
		{
			base.Serialize(writer);
			writer.Write((int) 0);
		}

		public override void Deserialize(GenericReader reader)
		{
			base.Deserialize(reader);
			int version = reader.ReadInt();
		}
	}
	public class TallStatueLion : BaseStatueDeed
	{
		public override CraftResource DefaultResource{ get{ return CraftResource.Iron; } }
		public override Catalogs DefaultCatalog{ get{ return Catalogs.Stone; } }

		[Constructable]
		public TallStatueLion() : base()
		{
			Name = "tall statue of a lion (east)";
			Weight = 33;
			ItemID = 0x32F0;
		}

		public TallStatueLion(Serial serial) : base(serial)
		{
		}

		public override void Serialize(GenericWriter writer)
		{
			base.Serialize(writer);
			writer.Write((int) 0);
		}

		public override void Deserialize(GenericReader reader)
		{
			base.Deserialize(reader);
			int version = reader.ReadInt();
		}
	}
	public class LargeStatueWolf : BaseStatueDeed
	{
		public override CraftResource DefaultResource{ get{ return CraftResource.Iron; } }
		public override Catalogs DefaultCatalog{ get{ return Catalogs.Stone; } }

		[Constructable]
		public LargeStatueWolf() : base()
		{
			Name = "statue of a wolf (east)";
			Weight = 35;
			ItemID = 0x32F0;
		}

		public LargeStatueWolf(Serial serial) : base(serial)
		{
		}

		public override void Serialize(GenericWriter writer)
		{
			base.Serialize(writer);
			writer.Write((int) 0);
		}

		public override void Deserialize(GenericReader reader)
		{
			base.Deserialize(reader);
			int version = reader.ReadInt();
		}
	}
	public class StatueGuardian : BaseStatueDeed
	{
		public override CraftResource DefaultResource{ get{ return CraftResource.Iron; } }
		public override Catalogs DefaultCatalog{ get{ return Catalogs.Stone; } }

		[Constructable]
		public StatueGuardian() : base()
		{
			Name = "statue of a guardian (east)";
			Weight = 37;
			ItemID = 0x32F0;
		}

		public StatueGuardian(Serial serial) : base(serial)
		{
		}

		public override void Serialize(GenericWriter writer)
		{
			base.Serialize(writer);
			writer.Write((int) 0);
		}

		public override void Deserialize(GenericReader reader)
		{
			base.Deserialize(reader);
			int version = reader.ReadInt();
		}
	}
	public class StatueMinotaurDefend : BaseStatueDeed
	{
		public override CraftResource DefaultResource{ get{ return CraftResource.Iron; } }
		public override Catalogs DefaultCatalog{ get{ return Catalogs.Stone; } }

		[Constructable]
		public StatueMinotaurDefend() : base()
		{
			Name = "statue of a minotaur (east)";
			Weight = 39;
			ItemID = 0x32F0;
		}

		public StatueMinotaurDefend(Serial serial) : base(serial)
		{
		}

		public override void Serialize(GenericWriter writer)
		{
			base.Serialize(writer);
			writer.Write((int) 0);
		}

		public override void Deserialize(GenericReader reader)
		{
			base.Deserialize(reader);
			int version = reader.ReadInt();
		}
	}
	public class StatueMinotaurAttack : BaseStatueDeed
	{
		public override CraftResource DefaultResource{ get{ return CraftResource.Iron; } }
		public override Catalogs DefaultCatalog{ get{ return Catalogs.Stone; } }

		[Constructable]
		public StatueMinotaurAttack() : base()
		{
			Name = "statue of a minotaur (east)";
			Weight = 41;
			ItemID = 0x32F0;
		}

		public StatueMinotaurAttack(Serial serial) : base(serial)
		{
		}

		public override void Serialize(GenericWriter writer)
		{
			base.Serialize(writer);
			writer.Write((int) 0);
		}

		public override void Deserialize(GenericReader reader)
		{
			base.Deserialize(reader);
			int version = reader.ReadInt();
		}
	}
	public class StatueDaemon : BaseStatueDeed
	{
		public override CraftResource DefaultResource{ get{ return CraftResource.Iron; } }
		public override Catalogs DefaultCatalog{ get{ return Catalogs.Stone; } }

		[Constructable]
		public StatueDaemon() : base()
		{
			Name = "statue of a daemon";
			Weight = 43;
			ItemID = 0x32F0;
		}

		public StatueDaemon(Serial serial) : base(serial)
		{
		}

		public override void Serialize(GenericWriter writer)
		{
			base.Serialize(writer);
			writer.Write((int) 0);
		}

		public override void Deserialize(GenericReader reader)
		{
			base.Deserialize(reader);
			int version = reader.ReadInt();
		}
	}
}