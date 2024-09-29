using System;
using Server;
using Server.Engines.Craft;
using Server.Gumps;
using Server.Network;

namespace Server.Items
{
	public class DJ_SL_Alchemy : PowerScroll
	{
		private SkillName m_Skill;
		private int m_Value;
		private static SkillName[] m_Skills = new SkillName[]
		{
			SkillName.Alchemy
		};
		public new SkillName[] Skills { get { return m_Skills; } }
		[Constructable]
		public DJ_SL_Alchemy(): base(SkillName.Alchemy, 120)
		{
		}
		[Constructable]
		public DJ_SL_Alchemy(SkillName skill, int value): base(0x14F0)
		{
			Name = "Alchemy";
			m_Skill = skill;
			m_Value = value;
		}

		public DJ_SL_Alchemy(Serial serial): base(serial)
		{
		}

		public override void Serialize(GenericWriter writer)
		{
			base.Serialize(writer);
			writer.Write((int)0); // version
			writer.Write((int)m_Skill);
			writer.Write((int)m_Value);
		}

		public override void Deserialize(GenericReader reader)
		{
			base.Deserialize(reader);
			int version = reader.ReadInt();

			switch (version)
			{
				case 0:
				{
					m_Skill = (SkillName)reader.ReadInt();
					m_Value = reader.ReadInt();
					break;
				}
			}
		}
	}

	public class DJ_SL_AnimalLore : PowerScroll
	{
		private SkillName m_Skill;
		private int m_Value;
		private static SkillName[] m_Skills = new SkillName[]
		{
			SkillName.Druidism
		};
		public new SkillName[] Skills { get { return m_Skills; } }
		[Constructable]
		public DJ_SL_AnimalLore(): base(SkillName.Druidism, 120)
		{
		}
		[Constructable]
		public DJ_SL_AnimalLore(SkillName skill, int value): base(0x14F0)
		{
			Name = "Druidism";
			m_Skill = skill;
			m_Value = value;
		}

		public DJ_SL_AnimalLore(Serial serial): base(serial)
		{
		}

		public override void Serialize(GenericWriter writer)
		{
			base.Serialize(writer);
			writer.Write((int)0); // version
			writer.Write((int)m_Skill);
			writer.Write((int)m_Value);
		}

		public override void Deserialize(GenericReader reader)
		{
			base.Deserialize(reader);
			int version = reader.ReadInt();

			switch (version)
			{
				case 0:
				{
					m_Skill = (SkillName)reader.ReadInt();
					m_Value = reader.ReadInt();
					break;
				}
			}
		}
	}

	public class DJ_SL_AnimalTaming : PowerScroll
	{
		private SkillName m_Skill;
		private int m_Value;
		private static SkillName[] m_Skills = new SkillName[]
		{
			SkillName.Taming
		};
		public new SkillName[] Skills { get { return m_Skills; } }
		[Constructable]
		public DJ_SL_AnimalTaming(): base(SkillName.Taming, 120)
		{
		}
		[Constructable]
		public DJ_SL_AnimalTaming(SkillName skill, int value): base(0x14F0)
		{
			Name = "Taming";
			m_Skill = skill;
			m_Value = value;
		}

		public DJ_SL_AnimalTaming(Serial serial): base(serial)
		{
		}

		public override void Serialize(GenericWriter writer)
		{
			base.Serialize(writer);
			writer.Write((int)0); // version
			writer.Write((int)m_Skill);
			writer.Write((int)m_Value);
		}

		public override void Deserialize(GenericReader reader)
		{
			base.Deserialize(reader);
			int version = reader.ReadInt();

			switch (version)
			{
				case 0:
				{
					m_Skill = (SkillName)reader.ReadInt();
					m_Value = reader.ReadInt();
					break;
				}
			}
		}
	}

	public class DJ_SL_Archery : PowerScroll
	{
		private SkillName m_Skill;
		private int m_Value;
		private static SkillName[] m_Skills = new SkillName[]
		{
			SkillName.Marksmanship
		};
		public new SkillName[] Skills { get { return m_Skills; } }
		[Constructable]
		public DJ_SL_Archery(): base(SkillName.Marksmanship, 120)
		{
		}
		[Constructable]
		public DJ_SL_Archery(SkillName skill, int value): base(0x14F0)
		{
			Name = "Marksmanship";
			m_Skill = skill;
			m_Value = value;
		}

		public DJ_SL_Archery(Serial serial): base(serial)
		{
		}

		public override void Serialize(GenericWriter writer)
		{
			base.Serialize(writer);
			writer.Write((int)0); // version
			writer.Write((int)m_Skill);
			writer.Write((int)m_Value);
		}

		public override void Deserialize(GenericReader reader)
		{
			base.Deserialize(reader);
			int version = reader.ReadInt();

			switch (version)
			{
				case 0:
				{
					m_Skill = (SkillName)reader.ReadInt();
					m_Value = reader.ReadInt();
					break;
				}
			}
		}
	}

	public class DJ_SL_ArmsLore : PowerScroll
	{
		private SkillName m_Skill;
		private int m_Value;
		private static SkillName[] m_Skills = new SkillName[]
		{
			SkillName.ArmsLore
		};
		public new SkillName[] Skills { get { return m_Skills; } }
		[Constructable]
		public DJ_SL_ArmsLore(): base(SkillName.ArmsLore, 120)
		{
		}
		[Constructable]
		public DJ_SL_ArmsLore(SkillName skill, int value): base(0x14F0)
		{
			Name = "Arms Lore";
			m_Skill = skill;
			m_Value = value;
		}

		public DJ_SL_ArmsLore(Serial serial): base(serial)
		{
		}

		public override void Serialize(GenericWriter writer)
		{
			base.Serialize(writer);
			writer.Write((int)0); // version
			writer.Write((int)m_Skill);
			writer.Write((int)m_Value);
		}

		public override void Deserialize(GenericReader reader)
		{
			base.Deserialize(reader);
			int version = reader.ReadInt();

			switch (version)
			{
				case 0:
				{
					m_Skill = (SkillName)reader.ReadInt();
					m_Value = reader.ReadInt();
					break;
				}
			}
		}
	}

	public class DJ_SL_Blacksmith : PowerScroll
	{
		private SkillName m_Skill;
		private int m_Value;
		private static SkillName[] m_Skills = new SkillName[]
		{
			SkillName.Blacksmith
		};
		public new SkillName[] Skills { get { return m_Skills; } }
		[Constructable]
		public DJ_SL_Blacksmith(): base(SkillName.Blacksmith, 120)
		{
		}
		[Constructable]
		public DJ_SL_Blacksmith(SkillName skill, int value): base(0x14F0)
		{
			Name = "Blacksmithing";
			m_Skill = skill;
			m_Value = value;
		}

		public DJ_SL_Blacksmith(Serial serial): base(serial)
		{
		}

		public override void Serialize(GenericWriter writer)
		{
			base.Serialize(writer);
			writer.Write((int)0); // version
			writer.Write((int)m_Skill);
			writer.Write((int)m_Value);
		}

		public override void Deserialize(GenericReader reader)
		{
			base.Deserialize(reader);
			int version = reader.ReadInt();

			switch (version)
			{
				case 0:
				{
					m_Skill = (SkillName)reader.ReadInt();
					m_Value = reader.ReadInt();
					break;
				}
			}
		}
	}

	public class DJ_SL_Bushido : PowerScroll
	{
		private SkillName m_Skill;
		private int m_Value;
		private static SkillName[] m_Skills = new SkillName[]
		{
			SkillName.Bushido
		};
		public new SkillName[] Skills { get { return m_Skills; } }
		[Constructable]
		public DJ_SL_Bushido(): base(SkillName.Bushido, 120)
		{
		}
		[Constructable]
		public DJ_SL_Bushido(SkillName skill, int value): base(0x14F0)
		{
			Name = "Bushido";
			m_Skill = skill;
			m_Value = value;
		}

		public DJ_SL_Bushido(Serial serial): base(serial)
		{
		}

		public override void Serialize(GenericWriter writer)
		{
			base.Serialize(writer);
			writer.Write((int)0); // version
			writer.Write((int)m_Skill);
			writer.Write((int)m_Value);
		}

		public override void Deserialize(GenericReader reader)
		{
			base.Deserialize(reader);
			int version = reader.ReadInt();

			switch (version)
			{
				case 0:
				{
					m_Skill = (SkillName)reader.ReadInt();
					m_Value = reader.ReadInt();
					break;
				}
			}
		}
	}

	public class DJ_SL_Carpentry : PowerScroll
	{
		private SkillName m_Skill;
		private int m_Value;
		private static SkillName[] m_Skills = new SkillName[]
		{
			SkillName.Carpentry
		};
		public new SkillName[] Skills { get { return m_Skills; } }
		[Constructable]
		public DJ_SL_Carpentry(): base(SkillName.Carpentry, 120)
		{
		}
		[Constructable]
		public DJ_SL_Carpentry(SkillName skill, int value): base(0x14F0)
		{
			Name = "Carpentry";
			m_Skill = skill;
			m_Value = value;
		}

		public DJ_SL_Carpentry(Serial serial): base(serial)
		{
		}

		public override void Serialize(GenericWriter writer)
		{
			base.Serialize(writer);
			writer.Write((int)0); // version
			writer.Write((int)m_Skill);
			writer.Write((int)m_Value);
		}

		public override void Deserialize(GenericReader reader)
		{
			base.Deserialize(reader);
			int version = reader.ReadInt();

			switch (version)
			{
				case 0:
				{
					m_Skill = (SkillName)reader.ReadInt();
					m_Value = reader.ReadInt();
					break;
				}
			}
		}
	}

	public class DJ_SL_Cartography : PowerScroll
	{
		private SkillName m_Skill;
		private int m_Value;
		private static SkillName[] m_Skills = new SkillName[]
		{
			SkillName.Cartography
		};
		public new SkillName[] Skills { get { return m_Skills; } }
		[Constructable]
		public DJ_SL_Cartography(): base(SkillName.Cartography, 120)
		{
		}
		[Constructable]
		public DJ_SL_Cartography(SkillName skill, int value): base(0x14F0)
		{
			Name = "Cartography";
			m_Skill = skill;
			m_Value = value;
		}

		public DJ_SL_Cartography(Serial serial): base(serial)
		{
		}

		public override void Serialize(GenericWriter writer)
		{
			base.Serialize(writer);
			writer.Write((int)0); // version
			writer.Write((int)m_Skill);
			writer.Write((int)m_Value);
		}

		public override void Deserialize(GenericReader reader)
		{
			base.Deserialize(reader);
			int version = reader.ReadInt();

			switch (version)
			{
				case 0:
				{
					m_Skill = (SkillName)reader.ReadInt();
					m_Value = reader.ReadInt();
					break;
				}
			}
		}
	}

	public class DJ_SL_Chivalry : PowerScroll
	{
		private SkillName m_Skill;
		private int m_Value;
		private static SkillName[] m_Skills = new SkillName[]
		{
			SkillName.Knightship
		};
		public new SkillName[] Skills { get { return m_Skills; } }
		[Constructable]
		public DJ_SL_Chivalry(): base(SkillName.Knightship, 120)
		{
		}
		[Constructable]
		public DJ_SL_Chivalry(SkillName skill, int value): base(0x14F0)
		{
			Name = "Knightship";
			m_Skill = skill;
			m_Value = value;
		}

		public DJ_SL_Chivalry(Serial serial): base(serial)
		{
		}

		public override void Serialize(GenericWriter writer)
		{
			base.Serialize(writer);
			writer.Write((int)0); // version
			writer.Write((int)m_Skill);
			writer.Write((int)m_Value);
		}

		public override void Deserialize(GenericReader reader)
		{
			base.Deserialize(reader);
			int version = reader.ReadInt();

			switch (version)
			{
				case 0:
				{
					m_Skill = (SkillName)reader.ReadInt();
					m_Value = reader.ReadInt();
					break;
				}
			}
		}
	}

	public class DJ_SL_Cooking : PowerScroll
	{
		private SkillName m_Skill;
		private int m_Value;
		private static SkillName[] m_Skills = new SkillName[]
		{
			SkillName.Cooking
		};
		public new SkillName[] Skills { get { return m_Skills; } }
		[Constructable]
		public DJ_SL_Cooking(): base(SkillName.Cooking, 120)
		{
		}
		[Constructable]
		public DJ_SL_Cooking(SkillName skill, int value): base(0x14F0)
		{
			Name = "Cooking";
			m_Skill = skill;
			m_Value = value;
		}

		public DJ_SL_Cooking(Serial serial): base(serial)
		{
		}

		public override void Serialize(GenericWriter writer)
		{
			base.Serialize(writer);
			writer.Write((int)0); // version
			writer.Write((int)m_Skill);
			writer.Write((int)m_Value);
		}

		public override void Deserialize(GenericReader reader)
		{
			base.Deserialize(reader);
			int version = reader.ReadInt();

			switch (version)
			{
				case 0:
				{
					m_Skill = (SkillName)reader.ReadInt();
					m_Value = reader.ReadInt();
					break;
				}
			}
		}
	}

	public class DJ_SL_DetectHidden : PowerScroll
	{
		private SkillName m_Skill;
		private int m_Value;
		private static SkillName[] m_Skills = new SkillName[]
		{
			SkillName.Searching
		};
		public new SkillName[] Skills { get { return m_Skills; } }
		[Constructable]
		public DJ_SL_DetectHidden(): base(SkillName.Searching, 120)
		{
		}
		[Constructable]
		public DJ_SL_DetectHidden(SkillName skill, int value): base(0x14F0)
		{
			Name = "Searching";
			m_Skill = skill;
			m_Value = value;
		}

		public DJ_SL_DetectHidden(Serial serial): base(serial)
		{
		}

		public override void Serialize(GenericWriter writer)
		{
			base.Serialize(writer);
			writer.Write((int)0); // version
			writer.Write((int)m_Skill);
			writer.Write((int)m_Value);
		}

		public override void Deserialize(GenericReader reader)
		{
			base.Deserialize(reader);
			int version = reader.ReadInt();

			switch (version)
			{
				case 0:
				{
					m_Skill = (SkillName)reader.ReadInt();
					m_Value = reader.ReadInt();
					break;
				}
			}
		}
	}

	public class DJ_SL_Discordance : PowerScroll
	{
		private SkillName m_Skill;
		private int m_Value;
		private static SkillName[] m_Skills = new SkillName[]
		{
			SkillName.Discordance
		};
		public new SkillName[] Skills { get { return m_Skills; } }
		[Constructable]
		public DJ_SL_Discordance(): base(SkillName.Discordance, 120)
		{
		}
		[Constructable]
		public DJ_SL_Discordance(SkillName skill, int value): base(0x14F0)
		{
			Name = "Discordance";
			m_Skill = skill;
			m_Value = value;
		}

		public DJ_SL_Discordance(Serial serial): base(serial)
		{
		}

		public override void Serialize(GenericWriter writer)
		{
			base.Serialize(writer);
			writer.Write((int)0); // version
			writer.Write((int)m_Skill);
			writer.Write((int)m_Value);
		}

		public override void Deserialize(GenericReader reader)
		{
			base.Deserialize(reader);
			int version = reader.ReadInt();

			switch (version)
			{
				case 0:
				{
					m_Skill = (SkillName)reader.ReadInt();
					m_Value = reader.ReadInt();
					break;
				}
			}
		}
	}

	public class DJ_SL_EvalInt : PowerScroll
	{
		private SkillName m_Skill;
		private int m_Value;
		private static SkillName[] m_Skills = new SkillName[]
		{
			SkillName.Psychology
		};
		public new SkillName[] Skills { get { return m_Skills; } }
		[Constructable]
		public DJ_SL_EvalInt(): base(SkillName.Psychology, 120)
		{
		}
		[Constructable]
		public DJ_SL_EvalInt(SkillName skill, int value): base(0x14F0)
		{
			Name = "Psychology";
			m_Skill = skill;
			m_Value = value;
		}

		public DJ_SL_EvalInt(Serial serial): base(serial)
		{
		}

		public override void Serialize(GenericWriter writer)
		{
			base.Serialize(writer);
			writer.Write((int)0); // version
			writer.Write((int)m_Skill);
			writer.Write((int)m_Value);
		}

		public override void Deserialize(GenericReader reader)
		{
			base.Deserialize(reader);
			int version = reader.ReadInt();

			switch (version)
			{
				case 0:
				{
					m_Skill = (SkillName)reader.ReadInt();
					m_Value = reader.ReadInt();
					break;
				}
			}
		}
	}

	public class DJ_SL_Fencing : PowerScroll
	{
		private SkillName m_Skill;
		private int m_Value;
		private static SkillName[] m_Skills = new SkillName[]
		{
			SkillName.Fencing
		};
		public new SkillName[] Skills { get { return m_Skills; } }
		[Constructable]
		public DJ_SL_Fencing(): base(SkillName.Fencing, 120)
		{
		}
		[Constructable]
		public DJ_SL_Fencing(SkillName skill, int value): base(0x14F0)
		{
			Name = "Fencing";
			m_Skill = skill;
			m_Value = value;
		}

		public DJ_SL_Fencing(Serial serial): base(serial)
		{
		}

		public override void Serialize(GenericWriter writer)
		{
			base.Serialize(writer);
			writer.Write((int)0); // version
			writer.Write((int)m_Skill);
			writer.Write((int)m_Value);
		}

		public override void Deserialize(GenericReader reader)
		{
			base.Deserialize(reader);
			int version = reader.ReadInt();

			switch (version)
			{
				case 0:
				{
					m_Skill = (SkillName)reader.ReadInt();
					m_Value = reader.ReadInt();
					break;
				}
			}
		}
	}

	public class DJ_SL_Fishing : PowerScroll
	{
		private SkillName m_Skill;
		private int m_Value;
		private static SkillName[] m_Skills = new SkillName[]
		{
			SkillName.Seafaring
		};
		public new SkillName[] Skills { get { return m_Skills; } }
		[Constructable]
		public DJ_SL_Fishing(): base(SkillName.Seafaring, 120)
		{
		}
		[Constructable]
		public DJ_SL_Fishing(SkillName skill, int value): base(0x14F0)
		{
			Name = "Seafaring";
			m_Skill = skill;
			m_Value = value;
		}

		public DJ_SL_Fishing(Serial serial): base(serial)
		{
		}

		public override void Serialize(GenericWriter writer)
		{
			base.Serialize(writer);
			writer.Write((int)0); // version
			writer.Write((int)m_Skill);
			writer.Write((int)m_Value);
		}

		public override void Deserialize(GenericReader reader)
		{
			base.Deserialize(reader);
			int version = reader.ReadInt();

			switch (version)
			{
				case 0:
				{
					m_Skill = (SkillName)reader.ReadInt();
					m_Value = reader.ReadInt();
					break;
				}
			}
		}
	}

	public class DJ_SL_Fletching : PowerScroll
	{
		private SkillName m_Skill;
		private int m_Value;
		private static SkillName[] m_Skills = new SkillName[]
		{
			SkillName.Bowcraft
		};
		public new SkillName[] Skills { get { return m_Skills; } }
		[Constructable]
		public DJ_SL_Fletching(): base(SkillName.Bowcraft, 120)
		{
		}
		[Constructable]
		public DJ_SL_Fletching(SkillName skill, int value): base(0x14F0)
		{
			Name = "Bowcrafting";
			m_Skill = skill;
			m_Value = value;
		}

		public DJ_SL_Fletching(Serial serial): base(serial)
		{
		}

		public override void Serialize(GenericWriter writer)
		{
			base.Serialize(writer);
			writer.Write((int)0); // version
			writer.Write((int)m_Skill);
			writer.Write((int)m_Value);
		}

		public override void Deserialize(GenericReader reader)
		{
			base.Deserialize(reader);
			int version = reader.ReadInt();

			switch (version)
			{
				case 0:
				{
					m_Skill = (SkillName)reader.ReadInt();
					m_Value = reader.ReadInt();
					break;
				}
			}
		}
	}

	public class DJ_SL_Healing : PowerScroll
	{
		private SkillName m_Skill;
		private int m_Value;
		private static SkillName[] m_Skills = new SkillName[]
		{
			SkillName.Healing
		};
		public new SkillName[] Skills { get { return m_Skills; } }
		[Constructable]
		public DJ_SL_Healing(): base(SkillName.Healing, 120)
		{
		}
		[Constructable]
		public DJ_SL_Healing(SkillName skill, int value): base(0x14F0)
		{
			Name = "Healing";
			m_Skill = skill;
			m_Value = value;
		}

		public DJ_SL_Healing(Serial serial): base(serial)
		{
		}

		public override void Serialize(GenericWriter writer)
		{
			base.Serialize(writer);
			writer.Write((int)0); // version
			writer.Write((int)m_Skill);
			writer.Write((int)m_Value);
		}

		public override void Deserialize(GenericReader reader)
		{
			base.Deserialize(reader);
			int version = reader.ReadInt();

			switch (version)
			{
				case 0:
				{
					m_Skill = (SkillName)reader.ReadInt();
					m_Value = reader.ReadInt();
					break;
				}
			}
		}
	}

	public class DJ_SL_Herding : PowerScroll
	{
		private SkillName m_Skill;
		private int m_Value;
		private static SkillName[] m_Skills = new SkillName[]
		{
			SkillName.Herding
		};
		public new SkillName[] Skills { get { return m_Skills; } }
		[Constructable]
		public DJ_SL_Herding(): base(SkillName.Herding, 120)
		{
		}
		[Constructable]
		public DJ_SL_Herding(SkillName skill, int value): base(0x14F0)
		{
			Name = "Herding";
			m_Skill = skill;
			m_Value = value;
		}

		public DJ_SL_Herding(Serial serial): base(serial)
		{
		}

		public override void Serialize(GenericWriter writer)
		{
			base.Serialize(writer);
			writer.Write((int)0); // version
			writer.Write((int)m_Skill);
			writer.Write((int)m_Value);
		}

		public override void Deserialize(GenericReader reader)
		{
			base.Deserialize(reader);
			int version = reader.ReadInt();

			switch (version)
			{
				case 0:
				{
					m_Skill = (SkillName)reader.ReadInt();
					m_Value = reader.ReadInt();
					break;
				}
			}
		}
	}

	public class DJ_SL_Hiding : PowerScroll
	{
		private SkillName m_Skill;
		private int m_Value;
		private static SkillName[] m_Skills = new SkillName[]
		{
			SkillName.Hiding
		};
		public new SkillName[] Skills { get { return m_Skills; } }
		[Constructable]
		public DJ_SL_Hiding(): base(SkillName.Hiding, 120)
		{
		}
		[Constructable]
		public DJ_SL_Hiding(SkillName skill, int value): base(0x14F0)
		{
			Name = "Hiding";
			m_Skill = skill;
			m_Value = value;
		}

		public DJ_SL_Hiding(Serial serial): base(serial)
		{
		}

		public override void Serialize(GenericWriter writer)
		{
			base.Serialize(writer);
			writer.Write((int)0); // version
			writer.Write((int)m_Skill);
			writer.Write((int)m_Value);
		}

		public override void Deserialize(GenericReader reader)
		{
			base.Deserialize(reader);
			int version = reader.ReadInt();

			switch (version)
			{
				case 0:
				{
					m_Skill = (SkillName)reader.ReadInt();
					m_Value = reader.ReadInt();
					break;
				}
			}
		}
	}

	public class DJ_SL_Inscribe : PowerScroll
	{
		private SkillName m_Skill;
		private int m_Value;
		private static SkillName[] m_Skills = new SkillName[]
		{
			SkillName.Inscribe
		};
		public new SkillName[] Skills { get { return m_Skills; } }
		[Constructable]
		public DJ_SL_Inscribe(): base(SkillName.Inscribe, 120)
		{
		}
		[Constructable]
		public DJ_SL_Inscribe(SkillName skill, int value): base(0x14F0)
		{
			Name = "Inscription";
			m_Skill = skill;
			m_Value = value;
		}

		public DJ_SL_Inscribe(Serial serial): base(serial)
		{
		}

		public override void Serialize(GenericWriter writer)
		{
			base.Serialize(writer);
			writer.Write((int)0); // version
			writer.Write((int)m_Skill);
			writer.Write((int)m_Value);
		}

		public override void Deserialize(GenericReader reader)
		{
			base.Deserialize(reader);
			int version = reader.ReadInt();

			switch (version)
			{
				case 0:
				{
					m_Skill = (SkillName)reader.ReadInt();
					m_Value = reader.ReadInt();
					break;
				}
			}
		}
	}

	public class DJ_SL_Lockpicking : PowerScroll
	{
		private SkillName m_Skill;
		private int m_Value;
		private static SkillName[] m_Skills = new SkillName[]
		{
			SkillName.Lockpicking
		};
		public new SkillName[] Skills { get { return m_Skills; } }
		[Constructable]
		public DJ_SL_Lockpicking(): base(SkillName.Lockpicking, 120)
		{
		}
		[Constructable]
		public DJ_SL_Lockpicking(SkillName skill, int value): base(0x14F0)
		{
			Name = "Lockpicking";
			m_Skill = skill;
			m_Value = value;
		}

		public DJ_SL_Lockpicking(Serial serial): base(serial)
		{
		}

		public override void Serialize(GenericWriter writer)
		{
			base.Serialize(writer);
			writer.Write((int)0); // version
			writer.Write((int)m_Skill);
			writer.Write((int)m_Value);
		}

		public override void Deserialize(GenericReader reader)
		{
			base.Deserialize(reader);
			int version = reader.ReadInt();

			switch (version)
			{
				case 0:
				{
					m_Skill = (SkillName)reader.ReadInt();
					m_Value = reader.ReadInt();
					break;
				}
			}
		}
	}

	public class DJ_SL_Lumberjacking : PowerScroll
	{
		private SkillName m_Skill;
		private int m_Value;
		private static SkillName[] m_Skills = new SkillName[]
		{
			SkillName.Lumberjacking
		};
		public new SkillName[] Skills { get { return m_Skills; } }
		[Constructable]
		public DJ_SL_Lumberjacking(): base(SkillName.Lumberjacking, 120)
		{
		}
		[Constructable]
		public DJ_SL_Lumberjacking(SkillName skill, int value): base(0x14F0)
		{
			Name = "Lumberjacking";
			m_Skill = skill;
			m_Value = value;
		}

		public DJ_SL_Lumberjacking(Serial serial): base(serial)
		{
		}

		public override void Serialize(GenericWriter writer)
		{
			base.Serialize(writer);
			writer.Write((int)0); // version
			writer.Write((int)m_Skill);
			writer.Write((int)m_Value);
		}

		public override void Deserialize(GenericReader reader)
		{
			base.Deserialize(reader);
			int version = reader.ReadInt();

			switch (version)
			{
				case 0:
				{
					m_Skill = (SkillName)reader.ReadInt();
					m_Value = reader.ReadInt();
					break;
				}
			}
		}
	}

	public class DJ_SL_Macing : PowerScroll
	{
		private SkillName m_Skill;
		private int m_Value;
		private static SkillName[] m_Skills = new SkillName[]
		{
			SkillName.Bludgeoning
		};
		public new SkillName[] Skills { get { return m_Skills; } }
		[Constructable]
		public DJ_SL_Macing(): base(SkillName.Bludgeoning, 120)
		{
		}
		[Constructable]
		public DJ_SL_Macing(SkillName skill, int value): base(0x14F0)
		{
			Name = "Bludgeoning";
			m_Skill = skill;
			m_Value = value;
		}

		public DJ_SL_Macing(Serial serial): base(serial)
		{
		}

		public override void Serialize(GenericWriter writer)
		{
			base.Serialize(writer);
			writer.Write((int)0); // version
			writer.Write((int)m_Skill);
			writer.Write((int)m_Value);
		}

		public override void Deserialize(GenericReader reader)
		{
			base.Deserialize(reader);
			int version = reader.ReadInt();

			switch (version)
			{
				case 0:
				{
					m_Skill = (SkillName)reader.ReadInt();
					m_Value = reader.ReadInt();
					break;
				}
			}
		}
	}

	public class DJ_SL_Magery : PowerScroll
	{
		private SkillName m_Skill;
		private int m_Value;
		private static SkillName[] m_Skills = new SkillName[]
		{
			SkillName.Magery
		};
		public new SkillName[] Skills { get { return m_Skills; } }
		[Constructable]
		public DJ_SL_Magery(): base(SkillName.Magery, 120)
		{
		}
		[Constructable]
		public DJ_SL_Magery(SkillName skill, int value): base(0x14F0)
		{
			Name = "Magery";
			m_Skill = skill;
			m_Value = value;
		}

		public DJ_SL_Magery(Serial serial): base(serial)
		{
		}

		public override void Serialize(GenericWriter writer)
		{
			base.Serialize(writer);
			writer.Write((int)0); // version
			writer.Write((int)m_Skill);
			writer.Write((int)m_Value);
		}

		public override void Deserialize(GenericReader reader)
		{
			base.Deserialize(reader);
			int version = reader.ReadInt();

			switch (version)
			{
				case 0:
				{
					m_Skill = (SkillName)reader.ReadInt();
					m_Value = reader.ReadInt();
					break;
				}
			}
		}
	}

	public class DJ_SL_MagicResist : PowerScroll
	{
		private SkillName m_Skill;
		private int m_Value;
		private static SkillName[] m_Skills = new SkillName[]
		{
			SkillName.MagicResist
		};
		public new SkillName[] Skills { get { return m_Skills; } }
		[Constructable]
		public DJ_SL_MagicResist(): base(SkillName.MagicResist, 120)
		{
		}
		[Constructable]
		public DJ_SL_MagicResist(SkillName skill, int value): base(0x14F0)
		{
			Name = "Magic Resist";
			m_Skill = skill;
			m_Value = value;
		}

		public DJ_SL_MagicResist(Serial serial): base(serial)
		{
		}

		public override void Serialize(GenericWriter writer)
		{
			base.Serialize(writer);
			writer.Write((int)0); // version
			writer.Write((int)m_Skill);
			writer.Write((int)m_Value);
		}

		public override void Deserialize(GenericReader reader)
		{
			base.Deserialize(reader);
			int version = reader.ReadInt();

			switch (version)
			{
				case 0:
				{
					m_Skill = (SkillName)reader.ReadInt();
					m_Value = reader.ReadInt();
					break;
				}
			}
		}
	}

	public class DJ_SL_Meditation : PowerScroll
	{
		private SkillName m_Skill;
		private int m_Value;
		private static SkillName[] m_Skills = new SkillName[]
		{
			SkillName.Meditation
		};
		public new SkillName[] Skills { get { return m_Skills; } }
		[Constructable]
		public DJ_SL_Meditation(): base(SkillName.Meditation, 120)
		{
		}
		[Constructable]
		public DJ_SL_Meditation(SkillName skill, int value): base(0x14F0)
		{
			Name = "Meditation";
			m_Skill = skill;
			m_Value = value;
		}

		public DJ_SL_Meditation(Serial serial): base(serial)
		{
		}

		public override void Serialize(GenericWriter writer)
		{
			base.Serialize(writer);
			writer.Write((int)0); // version
			writer.Write((int)m_Skill);
			writer.Write((int)m_Value);
		}

		public override void Deserialize(GenericReader reader)
		{
			base.Deserialize(reader);
			int version = reader.ReadInt();

			switch (version)
			{
				case 0:
				{
					m_Skill = (SkillName)reader.ReadInt();
					m_Value = reader.ReadInt();
					break;
				}
			}
		}
	}

	public class DJ_SL_Mining : PowerScroll
	{
		private SkillName m_Skill;
		private int m_Value;
		private static SkillName[] m_Skills = new SkillName[]
		{
			SkillName.Mining
		};
		public new SkillName[] Skills { get { return m_Skills; } }
		[Constructable]
		public DJ_SL_Mining(): base(SkillName.Mining, 120)
		{
		}
		[Constructable]
		public DJ_SL_Mining(SkillName skill, int value): base(0x14F0)
		{
			Name = "Mining";
			m_Skill = skill;
			m_Value = value;
		}

		public DJ_SL_Mining(Serial serial): base(serial)
		{
		}

		public override void Serialize(GenericWriter writer)
		{
			base.Serialize(writer);
			writer.Write((int)0); // version
			writer.Write((int)m_Skill);
			writer.Write((int)m_Value);
		}

		public override void Deserialize(GenericReader reader)
		{
			base.Deserialize(reader);
			int version = reader.ReadInt();

			switch (version)
			{
				case 0:
				{
					m_Skill = (SkillName)reader.ReadInt();
					m_Value = reader.ReadInt();
					break;
				}
			}
		}
	}

	public class DJ_SL_Musicianship : PowerScroll
	{
		private SkillName m_Skill;
		private int m_Value;
		private static SkillName[] m_Skills = new SkillName[]
		{
			SkillName.Musicianship
		};
		public new SkillName[] Skills { get { return m_Skills; } }
		[Constructable]
		public DJ_SL_Musicianship(): base(SkillName.Musicianship, 120)
		{
		}
		[Constructable]
		public DJ_SL_Musicianship(SkillName skill, int value): base(0x14F0)
		{
			Name = "Musicianship";
			m_Skill = skill;
			m_Value = value;
		}

		public DJ_SL_Musicianship(Serial serial): base(serial)
		{
		}

		public override void Serialize(GenericWriter writer)
		{
			base.Serialize(writer);
			writer.Write((int)0); // version
			writer.Write((int)m_Skill);
			writer.Write((int)m_Value);
		}

		public override void Deserialize(GenericReader reader)
		{
			base.Deserialize(reader);
			int version = reader.ReadInt();

			switch (version)
			{
				case 0:
				{
					m_Skill = (SkillName)reader.ReadInt();
					m_Value = reader.ReadInt();
					break;
				}
			}
		}
	}

	public class DJ_SL_Necromancy : PowerScroll
	{
		private SkillName m_Skill;
		private int m_Value;
		private static SkillName[] m_Skills = new SkillName[]
		{
			SkillName.Necromancy
		};
		public new SkillName[] Skills { get { return m_Skills; } }
		[Constructable]
		public DJ_SL_Necromancy(): base(SkillName.Necromancy, 120)
		{
		}
		[Constructable]
		public DJ_SL_Necromancy(SkillName skill, int value): base(0x14F0)
		{
			Name = "Necromancy";
			m_Skill = skill;
			m_Value = value;
		}

		public DJ_SL_Necromancy(Serial serial): base(serial)
		{
		}

		public override void Serialize(GenericWriter writer)
		{
			base.Serialize(writer);
			writer.Write((int)0); // version
			writer.Write((int)m_Skill);
			writer.Write((int)m_Value);
		}

		public override void Deserialize(GenericReader reader)
		{
			base.Deserialize(reader);
			int version = reader.ReadInt();

			switch (version)
			{
				case 0:
				{
					m_Skill = (SkillName)reader.ReadInt();
					m_Value = reader.ReadInt();
					break;
				}
			}
		}
	}

	public class DJ_SL_Ninjitsu : PowerScroll
	{
		private SkillName m_Skill;
		private int m_Value;
		private static SkillName[] m_Skills = new SkillName[]
		{
			SkillName.Ninjitsu
		};
		public new SkillName[] Skills { get { return m_Skills; } }
		[Constructable]
		public DJ_SL_Ninjitsu(): base(SkillName.Ninjitsu, 120)
		{
		}
		[Constructable]
		public DJ_SL_Ninjitsu(SkillName skill, int value): base(0x14F0)
		{
			Name = "Ninjitsu";
			m_Skill = skill;
			m_Value = value;
		}

		public DJ_SL_Ninjitsu(Serial serial): base(serial)
		{
		}

		public override void Serialize(GenericWriter writer)
		{
			base.Serialize(writer);
			writer.Write((int)0); // version
			writer.Write((int)m_Skill);
			writer.Write((int)m_Value);
		}

		public override void Deserialize(GenericReader reader)
		{
			base.Deserialize(reader);
			int version = reader.ReadInt();

			switch (version)
			{
				case 0:
				{
					m_Skill = (SkillName)reader.ReadInt();
					m_Value = reader.ReadInt();
					break;
				}
			}
		}
	}

	public class DJ_SL_Parry : PowerScroll
	{
		private SkillName m_Skill;
		private int m_Value;
		private static SkillName[] m_Skills = new SkillName[]
		{
			SkillName.Parry
		};
		public new SkillName[] Skills { get { return m_Skills; } }
		[Constructable]
		public DJ_SL_Parry(): base(SkillName.Parry, 120)
		{
		}
		[Constructable]
		public DJ_SL_Parry(SkillName skill, int value): base(0x14F0)
		{
			Name = "Parry";
			m_Skill = skill;
			m_Value = value;
		}

		public DJ_SL_Parry(Serial serial): base(serial)
		{
		}

		public override void Serialize(GenericWriter writer)
		{
			base.Serialize(writer);
			writer.Write((int)0); // version
			writer.Write((int)m_Skill);
			writer.Write((int)m_Value);
		}

		public override void Deserialize(GenericReader reader)
		{
			base.Deserialize(reader);
			int version = reader.ReadInt();

			switch (version)
			{
				case 0:
				{
					m_Skill = (SkillName)reader.ReadInt();
					m_Value = reader.ReadInt();
					break;
				}
			}
		}
	}

	public class DJ_SL_Peacemaking : PowerScroll
	{
		private SkillName m_Skill;
		private int m_Value;
		private static SkillName[] m_Skills = new SkillName[]
		{
			SkillName.Peacemaking
		};
		public new SkillName[] Skills { get { return m_Skills; } }
		[Constructable]
		public DJ_SL_Peacemaking(): base(SkillName.Peacemaking, 120)
		{
		}
		[Constructable]
		public DJ_SL_Peacemaking(SkillName skill, int value): base(0x14F0)
		{
			Name = "Peacemaking";
			m_Skill = skill;
			m_Value = value;
		}

		public DJ_SL_Peacemaking(Serial serial): base(serial)
		{
		}

		public override void Serialize(GenericWriter writer)
		{
			base.Serialize(writer);
			writer.Write((int)0); // version
			writer.Write((int)m_Skill);
			writer.Write((int)m_Value);
		}

		public override void Deserialize(GenericReader reader)
		{
			base.Deserialize(reader);
			int version = reader.ReadInt();

			switch (version)
			{
				case 0:
				{
					m_Skill = (SkillName)reader.ReadInt();
					m_Value = reader.ReadInt();
					break;
				}
			}
		}
	}

	public class DJ_SL_Poisoning : PowerScroll
	{
		private SkillName m_Skill;
		private int m_Value;
		private static SkillName[] m_Skills = new SkillName[]
		{
			SkillName.Poisoning
		};
		public new SkillName[] Skills { get { return m_Skills; } }
		[Constructable]
		public DJ_SL_Poisoning(): base(SkillName.Poisoning, 120)
		{
		}
		[Constructable]
		public DJ_SL_Poisoning(SkillName skill, int value): base(0x14F0)
		{
			Name = "Poisoning";
			m_Skill = skill;
			m_Value = value;
		}

		public DJ_SL_Poisoning(Serial serial): base(serial)
		{
		}

		public override void Serialize(GenericWriter writer)
		{
			base.Serialize(writer);
			writer.Write((int)0); // version
			writer.Write((int)m_Skill);
			writer.Write((int)m_Value);
		}

		public override void Deserialize(GenericReader reader)
		{
			base.Deserialize(reader);
			int version = reader.ReadInt();

			switch (version)
			{
				case 0:
				{
					m_Skill = (SkillName)reader.ReadInt();
					m_Value = reader.ReadInt();
					break;
				}
			}
		}
	}

	public class DJ_SL_Provocation : PowerScroll
	{
		private SkillName m_Skill;
		private int m_Value;
		private static SkillName[] m_Skills = new SkillName[]
		{
			SkillName.Provocation
		};
		public new SkillName[] Skills { get { return m_Skills; } }
		[Constructable]
		public DJ_SL_Provocation(): base(SkillName.Provocation, 120)
		{
		}
		[Constructable]
		public DJ_SL_Provocation(SkillName skill, int value): base(0x14F0)
		{
			Name = "Provocation";
			m_Skill = skill;
			m_Value = value;
		}

		public DJ_SL_Provocation(Serial serial): base(serial)
		{
		}

		public override void Serialize(GenericWriter writer)
		{
			base.Serialize(writer);
			writer.Write((int)0); // version
			writer.Write((int)m_Skill);
			writer.Write((int)m_Value);
		}

		public override void Deserialize(GenericReader reader)
		{
			base.Deserialize(reader);
			int version = reader.ReadInt();

			switch (version)
			{
				case 0:
				{
					m_Skill = (SkillName)reader.ReadInt();
					m_Value = reader.ReadInt();
					break;
				}
			}
		}
	}

	public class DJ_SL_RemoveTrap : PowerScroll
	{
		private SkillName m_Skill;
		private int m_Value;
		private static SkillName[] m_Skills = new SkillName[]
		{
			SkillName.RemoveTrap
		};
		public new SkillName[] Skills { get { return m_Skills; } }
		[Constructable]
		public DJ_SL_RemoveTrap(): base(SkillName.RemoveTrap, 120)
		{
		}
		[Constructable]
		public DJ_SL_RemoveTrap(SkillName skill, int value): base(0x14F0)
		{
			Name = "Remove Trap";
			m_Skill = skill;
			m_Value = value;
		}

		public DJ_SL_RemoveTrap(Serial serial): base(serial)
		{
		}

		public override void Serialize(GenericWriter writer)
		{
			base.Serialize(writer);
			writer.Write((int)0); // version
			writer.Write((int)m_Skill);
			writer.Write((int)m_Value);
		}

		public override void Deserialize(GenericReader reader)
		{
			base.Deserialize(reader);
			int version = reader.ReadInt();

			switch (version)
			{
				case 0:
				{
					m_Skill = (SkillName)reader.ReadInt();
					m_Value = reader.ReadInt();
					break;
				}
			}
		}
	}

	public class DJ_SL_Snooping : PowerScroll
	{
		private SkillName m_Skill;
		private int m_Value;
		private static SkillName[] m_Skills = new SkillName[]
		{
			SkillName.Snooping
		};
		public new SkillName[] Skills { get { return m_Skills; } }
		[Constructable]
		public DJ_SL_Snooping(): base(SkillName.Snooping, 120)
		{
		}
		[Constructable]
		public DJ_SL_Snooping(SkillName skill, int value): base(0x14F0)
		{
			Name = "Snooping";
			m_Skill = skill;
			m_Value = value;
		}

		public DJ_SL_Snooping(Serial serial): base(serial)
		{
		}

		public override void Serialize(GenericWriter writer)
		{
			base.Serialize(writer);
			writer.Write((int)0); // version
			writer.Write((int)m_Skill);
			writer.Write((int)m_Value);
		}

		public override void Deserialize(GenericReader reader)
		{
			base.Deserialize(reader);
			int version = reader.ReadInt();

			switch (version)
			{
				case 0:
				{
					m_Skill = (SkillName)reader.ReadInt();
					m_Value = reader.ReadInt();
					break;
				}
			}
		}
	}

	public class DJ_SL_Elementalism: PowerScroll
	{
		private SkillName m_Skill;
		private int m_Value;
		private static SkillName[] m_Skills = new SkillName[]
		{
			SkillName.Elementalism
		};
		public new SkillName[] Skills { get { return m_Skills; } }
		[Constructable]
		public DJ_SL_Elementalism(): base(SkillName.Elementalism, 120)
		{
		}
		[Constructable]
		public DJ_SL_Elementalism(SkillName skill, int value): base(0x14F0)
		{
			Name = "Elementalism";
			m_Skill = skill;
			m_Value = value;
		}

		public DJ_SL_Elementalism(Serial serial): base(serial)
		{
		}

		public override void Serialize(GenericWriter writer)
		{
			base.Serialize(writer);
			writer.Write((int)0); // version
			writer.Write((int)m_Skill);
			writer.Write((int)m_Value);
		}

		public override void Deserialize(GenericReader reader)
		{
			base.Deserialize(reader);
			int version = reader.ReadInt();

			switch (version)
			{
				case 0:
				{
					m_Skill = (SkillName)reader.ReadInt();
					m_Value = reader.ReadInt();
					break;
				}
			}
		}
	}

	public class DJ_SL_SpiritSpeak : PowerScroll
	{
		private SkillName m_Skill;
		private int m_Value;
		private static SkillName[] m_Skills = new SkillName[]
		{
			SkillName.Spiritualism
		};
		public new SkillName[] Skills { get { return m_Skills; } }
		[Constructable]
		public DJ_SL_SpiritSpeak(): base(SkillName.Spiritualism, 120)
		{
		}
		[Constructable]
		public DJ_SL_SpiritSpeak(SkillName skill, int value): base(0x14F0)
		{
			Name = "Spiritualism";
			m_Skill = skill;
			m_Value = value;
		}

		public DJ_SL_SpiritSpeak(Serial serial): base(serial)
		{
		}

		public override void Serialize(GenericWriter writer)
		{
			base.Serialize(writer);
			writer.Write((int)0); // version
			writer.Write((int)m_Skill);
			writer.Write((int)m_Value);
		}

		public override void Deserialize(GenericReader reader)
		{
			base.Deserialize(reader);
			int version = reader.ReadInt();

			switch (version)
			{
				case 0:
				{
					m_Skill = (SkillName)reader.ReadInt();
					m_Value = reader.ReadInt();
					break;
				}
			}
		}
	}

	public class DJ_SL_Stealing : PowerScroll
	{
		private SkillName m_Skill;
		private int m_Value;
		private static SkillName[] m_Skills = new SkillName[]
		{
			SkillName.Stealing
		};
		public new SkillName[] Skills { get { return m_Skills; } }
		[Constructable]
		public DJ_SL_Stealing(): base(SkillName.Stealing, 120)
		{
		}
		[Constructable]
		public DJ_SL_Stealing(SkillName skill, int value): base(0x14F0)
		{
			Name = "Stealing";
			m_Skill = skill;
			m_Value = value;
		}

		public DJ_SL_Stealing(Serial serial): base(serial)
		{
		}

		public override void Serialize(GenericWriter writer)
		{
			base.Serialize(writer);
			writer.Write((int)0); // version
			writer.Write((int)m_Skill);
			writer.Write((int)m_Value);
		}

		public override void Deserialize(GenericReader reader)
		{
			base.Deserialize(reader);
			int version = reader.ReadInt();

			switch (version)
			{
				case 0:
				{
					m_Skill = (SkillName)reader.ReadInt();
					m_Value = reader.ReadInt();
					break;
				}
			}
		}
	}

	public class DJ_SL_Stealth : PowerScroll
	{
		private SkillName m_Skill;
		private int m_Value;
		private static SkillName[] m_Skills = new SkillName[]
		{
			SkillName.Stealth
		};
		public new SkillName[] Skills { get { return m_Skills; } }
		[Constructable]
		public DJ_SL_Stealth(): base(SkillName.Stealth, 120)
		{
		}
		[Constructable]
		public DJ_SL_Stealth(SkillName skill, int value): base(0x14F0)
		{
			Name = "Stealth";
			m_Skill = skill;
			m_Value = value;
		}

		public DJ_SL_Stealth(Serial serial): base(serial)
		{
		}

		public override void Serialize(GenericWriter writer)
		{
			base.Serialize(writer);
			writer.Write((int)0); // version
			writer.Write((int)m_Skill);
			writer.Write((int)m_Value);
		}

		public override void Deserialize(GenericReader reader)
		{
			base.Deserialize(reader);
			int version = reader.ReadInt();

			switch (version)
			{
				case 0:
				{
					m_Skill = (SkillName)reader.ReadInt();
					m_Value = reader.ReadInt();
					break;
				}
			}
		}
	}

	public class DJ_SL_Swords : PowerScroll
	{
		private SkillName m_Skill;
		private int m_Value;
		private static SkillName[] m_Skills = new SkillName[]
		{
			SkillName.Swords
		};
		public new SkillName[] Skills { get { return m_Skills; } }
		[Constructable]
		public DJ_SL_Swords(): base(SkillName.Swords, 120)
		{
		}
		[Constructable]
		public DJ_SL_Swords(SkillName skill, int value): base(0x14F0)
		{
			Name = "Sword Fighting";
			m_Skill = skill;
			m_Value = value;
		}

		public DJ_SL_Swords(Serial serial): base(serial)
		{
		}

		public override void Serialize(GenericWriter writer)
		{
			base.Serialize(writer);
			writer.Write((int)0); // version
			writer.Write((int)m_Skill);
			writer.Write((int)m_Value);
		}

		public override void Deserialize(GenericReader reader)
		{
			base.Deserialize(reader);
			int version = reader.ReadInt();

			switch (version)
			{
				case 0:
				{
					m_Skill = (SkillName)reader.ReadInt();
					m_Value = reader.ReadInt();
					break;
				}
			}
		}
	}

	public class DJ_SL_Tactics : PowerScroll
	{
		private SkillName m_Skill;
		private int m_Value;
		private static SkillName[] m_Skills = new SkillName[]
		{
			SkillName.Tactics
		};
		public new SkillName[] Skills { get { return m_Skills; } }
		[Constructable]
		public DJ_SL_Tactics(): base(SkillName.Tactics, 120)
		{
		}
		[Constructable]
		public DJ_SL_Tactics(SkillName skill, int value): base(0x14F0)
		{
			Name = "Tactics";
			m_Skill = skill;
			m_Value = value;
		}

		public DJ_SL_Tactics(Serial serial): base(serial)
		{
		}

		public override void Serialize(GenericWriter writer)
		{
			base.Serialize(writer);
			writer.Write((int)0); // version
			writer.Write((int)m_Skill);
			writer.Write((int)m_Value);
		}

		public override void Deserialize(GenericReader reader)
		{
			base.Deserialize(reader);
			int version = reader.ReadInt();

			switch (version)
			{
				case 0:
				{
					m_Skill = (SkillName)reader.ReadInt();
					m_Value = reader.ReadInt();
					break;
				}
			}
		}
	}

	public class DJ_SL_Tailoring : PowerScroll
	{
		private SkillName m_Skill;
		private int m_Value;
		private static SkillName[] m_Skills = new SkillName[]
		{
			SkillName.Tailoring
		};
		public new SkillName[] Skills { get { return m_Skills; } }
		[Constructable]
		public DJ_SL_Tailoring(): base(SkillName.Tailoring, 120)
		{
		}
		[Constructable]
		public DJ_SL_Tailoring(SkillName skill, int value): base(0x14F0)
		{
			Name = "Tailoring";
			m_Skill = skill;
			m_Value = value;
		}

		public DJ_SL_Tailoring(Serial serial): base(serial)
		{
		}

		public override void Serialize(GenericWriter writer)
		{
			base.Serialize(writer);
			writer.Write((int)0); // version
			writer.Write((int)m_Skill);
			writer.Write((int)m_Value);
		}

		public override void Deserialize(GenericReader reader)
		{
			base.Deserialize(reader);
			int version = reader.ReadInt();

			switch (version)
			{
				case 0:
				{
					m_Skill = (SkillName)reader.ReadInt();
					m_Value = reader.ReadInt();
					break;
				}
			}
		}
	}

	public class DJ_SL_Tinkering : PowerScroll
	{
		private SkillName m_Skill;
		private int m_Value;
		private static SkillName[] m_Skills = new SkillName[]
		{
			SkillName.Tinkering
		};
		public new SkillName[] Skills { get { return m_Skills; } }
		[Constructable]
		public DJ_SL_Tinkering(): base(SkillName.Tinkering, 120)
		{
		}
		[Constructable]
		public DJ_SL_Tinkering(SkillName skill, int value): base(0x14F0)
		{
			Name = "Tinkering";
			m_Skill = skill;
			m_Value = value;
		}

		public DJ_SL_Tinkering(Serial serial): base(serial)
		{
		}

		public override void Serialize(GenericWriter writer)
		{
			base.Serialize(writer);
			writer.Write((int)0); // version
			writer.Write((int)m_Skill);
			writer.Write((int)m_Value);
		}

		public override void Deserialize(GenericReader reader)
		{
			base.Deserialize(reader);
			int version = reader.ReadInt();

			switch (version)
			{
				case 0:
				{
					m_Skill = (SkillName)reader.ReadInt();
					m_Value = reader.ReadInt();
					break;
				}
			}
		}
	}

	public class DJ_SL_Tracking : PowerScroll
	{
		private SkillName m_Skill;
		private int m_Value;
		private static SkillName[] m_Skills = new SkillName[]
		{
			SkillName.Tracking
		};
		public new SkillName[] Skills { get { return m_Skills; } }
		[Constructable]
		public DJ_SL_Tracking(): base(SkillName.Tracking, 120)
		{
		}
		[Constructable]
		public DJ_SL_Tracking(SkillName skill, int value): base(0x14F0)
		{
			Name = "Tracking";
			m_Skill = skill;
			m_Value = value;
		}

		public DJ_SL_Tracking(Serial serial): base(serial)
		{
		}

		public override void Serialize(GenericWriter writer)
		{
			base.Serialize(writer);
			writer.Write((int)0); // version
			writer.Write((int)m_Skill);
			writer.Write((int)m_Value);
		}

		public override void Deserialize(GenericReader reader)
		{
			base.Deserialize(reader);
			int version = reader.ReadInt();

			switch (version)
			{
				case 0:
				{
					m_Skill = (SkillName)reader.ReadInt();
					m_Value = reader.ReadInt();
					break;
				}
			}
		}
	}

	public class DJ_SL_Veterinary : PowerScroll
	{
		private SkillName m_Skill;
		private int m_Value;
		private static SkillName[] m_Skills = new SkillName[]
		{
			SkillName.Veterinary
		};
		public new SkillName[] Skills { get { return m_Skills; } }
		[Constructable]
		public DJ_SL_Veterinary(): base(SkillName.Veterinary, 120)
		{
		}
		[Constructable]
		public DJ_SL_Veterinary(SkillName skill, int value): base(0x14F0)
		{
			Name = "Veterinary";
			m_Skill = skill;
			m_Value = value;
		}

		public DJ_SL_Veterinary(Serial serial): base(serial)
		{
		}

		public override void Serialize(GenericWriter writer)
		{
			base.Serialize(writer);
			writer.Write((int)0); // version
			writer.Write((int)m_Skill);
			writer.Write((int)m_Value);
		}

		public override void Deserialize(GenericReader reader)
		{
			base.Deserialize(reader);
			int version = reader.ReadInt();

			switch (version)
			{
				case 0:
				{
					m_Skill = (SkillName)reader.ReadInt();
					m_Value = reader.ReadInt();
					break;
				}
			}
		}
	}

	public class DJ_SL_Wrestling : PowerScroll
	{
		private SkillName m_Skill;
		private int m_Value;
		private static SkillName[] m_Skills = new SkillName[]
		{
			SkillName.FistFighting
		};
		public new SkillName[] Skills { get { return m_Skills; } }
		[Constructable]
		public DJ_SL_Wrestling(): base(SkillName.FistFighting, 120)
		{
		}
		[Constructable]
		public DJ_SL_Wrestling(SkillName skill, int value): base(0x14F0)
		{
			Name = "Fist Fighting";
			m_Skill = skill;
			m_Value = value;
		}

		public DJ_SL_Wrestling(Serial serial): base(serial)
		{
		}

		public override void Serialize(GenericWriter writer)
		{
			base.Serialize(writer);
			writer.Write((int)0); // version
			writer.Write((int)m_Skill);
			writer.Write((int)m_Value);
		}

		public override void Deserialize(GenericReader reader)
		{
			base.Deserialize(reader);
			int version = reader.ReadInt();

			switch (version)
			{
				case 0:
				{
					m_Skill = (SkillName)reader.ReadInt();
					m_Value = reader.ReadInt();
					break;
				}
			}
		}
	}

	public class DJ_SL_Anatomy : PowerScroll
	{
		private SkillName m_Skill;
		private int m_Value;
		private static SkillName[] m_Skills = new SkillName[]
		{
			SkillName.Anatomy
		};
		public new SkillName[] Skills { get { return m_Skills; } }
		[Constructable]
		public DJ_SL_Anatomy(): base(SkillName.Anatomy, 120)
		{
		}
		[Constructable]
		public DJ_SL_Anatomy(SkillName skill, int value): base(0x14F0)
		{
			Name = "Anatomy";
			m_Skill = skill;
			m_Value = value;
		}

		public DJ_SL_Anatomy(Serial serial): base(serial)
		{
		}

		public override void Serialize(GenericWriter writer)
		{
			base.Serialize(writer);
			writer.Write((int)0); // version
			writer.Write((int)m_Skill);
			writer.Write((int)m_Value);
		}

		public override void Deserialize(GenericReader reader)
		{
			base.Deserialize(reader);
			int version = reader.ReadInt();

			switch (version)
			{
				case 0:
				{
					m_Skill = (SkillName)reader.ReadInt();
					m_Value = reader.ReadInt();
					break;
				}
			}
		}
	}
	public class DJ_SL_Focus : PowerScroll
	{
		private SkillName m_Skill;
		private int m_Value;
		private static SkillName[] m_Skills = new SkillName[]
		{
			SkillName.Focus
		};
		public new SkillName[] Skills { get { return m_Skills; } }
		[Constructable]
		public DJ_SL_Focus(): base(SkillName.Focus, 120)
		{
		}
		[Constructable]
		public DJ_SL_Focus(SkillName skill, int value): base(0x14F0)
		{
			Name = "Focus";
			m_Skill = skill;
			m_Value = value;
		}

		public DJ_SL_Focus(Serial serial): base(serial)
		{
		}

		public override void Serialize(GenericWriter writer)
		{
			base.Serialize(writer);
			writer.Write((int)0); // version
			writer.Write((int)m_Skill);
			writer.Write((int)m_Value);
		}

		public override void Deserialize(GenericReader reader)
		{
			base.Deserialize(reader);
			int version = reader.ReadInt();

			switch (version)
			{
				case 0:
				{
					m_Skill = (SkillName)reader.ReadInt();
					m_Value = reader.ReadInt();
					break;
				}
			}
		}
	}
}