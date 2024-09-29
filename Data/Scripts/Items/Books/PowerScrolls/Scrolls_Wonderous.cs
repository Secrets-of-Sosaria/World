using System;
using Server;
using Server.Engines.Craft;
using Server.Gumps;
using Server.Network;

namespace Server.Items
{
	public class DJ_SW_Alchemy : PowerScroll
	{
		private SkillName m_Skill;
		private int m_Value;
		private static SkillName[] m_Skills = new SkillName[]
		{
			SkillName.Alchemy
		};
		public new SkillName[] Skills { get { return m_Skills; } }
		[Constructable]
		public DJ_SW_Alchemy(): base(SkillName.Alchemy, 105)
		{
		}
		[Constructable]
		public DJ_SW_Alchemy(SkillName skill, int value): base(0x14F0)
		{
			Name = "Alchemy";
			m_Skill = skill;
			m_Value = value;
		}

		public DJ_SW_Alchemy(Serial serial): base(serial)
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

	public class DJ_SW_AnimalLore : PowerScroll
	{
		private SkillName m_Skill;
		private int m_Value;
		private static SkillName[] m_Skills = new SkillName[]
		{
			SkillName.Druidism
		};
		public new SkillName[] Skills { get { return m_Skills; } }
		[Constructable]
		public DJ_SW_AnimalLore(): base(SkillName.Druidism, 105)
		{
		}
		[Constructable]
		public DJ_SW_AnimalLore(SkillName skill, int value): base(0x14F0)
		{
			Name = "Druidism";
			m_Skill = skill;
			m_Value = value;
		}

		public DJ_SW_AnimalLore(Serial serial): base(serial)
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

	public class DJ_SW_AnimalTaming : PowerScroll
	{
		private SkillName m_Skill;
		private int m_Value;
		private static SkillName[] m_Skills = new SkillName[]
		{
			SkillName.Taming
		};
		public new SkillName[] Skills { get { return m_Skills; } }
		[Constructable]
		public DJ_SW_AnimalTaming(): base(SkillName.Taming, 105)
		{
		}
		[Constructable]
		public DJ_SW_AnimalTaming(SkillName skill, int value): base(0x14F0)
		{
			Name = "Taming";
			m_Skill = skill;
			m_Value = value;
		}

		public DJ_SW_AnimalTaming(Serial serial): base(serial)
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

	public class DJ_SW_Archery : PowerScroll
	{
		private SkillName m_Skill;
		private int m_Value;
		private static SkillName[] m_Skills = new SkillName[]
		{
			SkillName.Marksmanship
		};
		public new SkillName[] Skills { get { return m_Skills; } }
		[Constructable]
		public DJ_SW_Archery(): base(SkillName.Marksmanship, 105)
		{
		}
		[Constructable]
		public DJ_SW_Archery(SkillName skill, int value): base(0x14F0)
		{
			Name = "Marksmanship";
			m_Skill = skill;
			m_Value = value;
		}

		public DJ_SW_Archery(Serial serial): base(serial)
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

	public class DJ_SW_ArmsLore : PowerScroll
	{
		private SkillName m_Skill;
		private int m_Value;
		private static SkillName[] m_Skills = new SkillName[]
		{
			SkillName.ArmsLore
		};
		public new SkillName[] Skills { get { return m_Skills; } }
		[Constructable]
		public DJ_SW_ArmsLore(): base(SkillName.ArmsLore, 105)
		{
		}
		[Constructable]
		public DJ_SW_ArmsLore(SkillName skill, int value): base(0x14F0)
		{
			Name = "Arms Lore";
			m_Skill = skill;
			m_Value = value;
		}

		public DJ_SW_ArmsLore(Serial serial): base(serial)
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

	public class DJ_SW_Blacksmith : PowerScroll
	{
		private SkillName m_Skill;
		private int m_Value;
		private static SkillName[] m_Skills = new SkillName[]
		{
			SkillName.Blacksmith
		};
		public new SkillName[] Skills { get { return m_Skills; } }
		[Constructable]
		public DJ_SW_Blacksmith(): base(SkillName.Blacksmith, 105)
		{
		}
		[Constructable]
		public DJ_SW_Blacksmith(SkillName skill, int value): base(0x14F0)
		{
			Name = "Blacksmithing";
			m_Skill = skill;
			m_Value = value;
		}

		public DJ_SW_Blacksmith(Serial serial): base(serial)
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

	public class DJ_SW_Bushido : PowerScroll
	{
		private SkillName m_Skill;
		private int m_Value;
		private static SkillName[] m_Skills = new SkillName[]
		{
			SkillName.Bushido
		};
		public new SkillName[] Skills { get { return m_Skills; } }
		[Constructable]
		public DJ_SW_Bushido(): base(SkillName.Bushido, 105)
		{
		}
		[Constructable]
		public DJ_SW_Bushido(SkillName skill, int value): base(0x14F0)
		{
			Name = "Bushido";
			m_Skill = skill;
			m_Value = value;
		}

		public DJ_SW_Bushido(Serial serial): base(serial)
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

	public class DJ_SW_Carpentry : PowerScroll
	{
		private SkillName m_Skill;
		private int m_Value;
		private static SkillName[] m_Skills = new SkillName[]
		{
			SkillName.Carpentry
		};
		public new SkillName[] Skills { get { return m_Skills; } }
		[Constructable]
		public DJ_SW_Carpentry(): base(SkillName.Carpentry, 105)
		{
		}
		[Constructable]
		public DJ_SW_Carpentry(SkillName skill, int value): base(0x14F0)
		{
			Name = "Carpentry";
			m_Skill = skill;
			m_Value = value;
		}

		public DJ_SW_Carpentry(Serial serial): base(serial)
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

	public class DJ_SW_Cartography : PowerScroll
	{
		private SkillName m_Skill;
		private int m_Value;
		private static SkillName[] m_Skills = new SkillName[]
		{
			SkillName.Cartography
		};
		public new SkillName[] Skills { get { return m_Skills; } }
		[Constructable]
		public DJ_SW_Cartography(): base(SkillName.Cartography, 105)
		{
		}
		[Constructable]
		public DJ_SW_Cartography(SkillName skill, int value): base(0x14F0)
		{
			Name = "Cartography";
			m_Skill = skill;
			m_Value = value;
		}

		public DJ_SW_Cartography(Serial serial): base(serial)
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

	public class DJ_SW_Chivalry : PowerScroll
	{
		private SkillName m_Skill;
		private int m_Value;
		private static SkillName[] m_Skills = new SkillName[]
		{
			SkillName.Knightship
		};
		public new SkillName[] Skills { get { return m_Skills; } }
		[Constructable]
		public DJ_SW_Chivalry(): base(SkillName.Knightship, 105)
		{
		}
		[Constructable]
		public DJ_SW_Chivalry(SkillName skill, int value): base(0x14F0)
		{
			Name = "Knightship";
			m_Skill = skill;
			m_Value = value;
		}

		public DJ_SW_Chivalry(Serial serial): base(serial)
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

	public class DJ_SW_Cooking : PowerScroll
	{
		private SkillName m_Skill;
		private int m_Value;
		private static SkillName[] m_Skills = new SkillName[]
		{
			SkillName.Cooking
		};
		public new SkillName[] Skills { get { return m_Skills; } }
		[Constructable]
		public DJ_SW_Cooking(): base(SkillName.Cooking, 105)
		{
		}
		[Constructable]
		public DJ_SW_Cooking(SkillName skill, int value): base(0x14F0)
		{
			Name = "Cooking";
			m_Skill = skill;
			m_Value = value;
		}

		public DJ_SW_Cooking(Serial serial): base(serial)
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

	public class DJ_SW_DetectHidden : PowerScroll
	{
		private SkillName m_Skill;
		private int m_Value;
		private static SkillName[] m_Skills = new SkillName[]
		{
			SkillName.Searching
		};
		public new SkillName[] Skills { get { return m_Skills; } }
		[Constructable]
		public DJ_SW_DetectHidden(): base(SkillName.Searching, 105)
		{
		}
		[Constructable]
		public DJ_SW_DetectHidden(SkillName skill, int value): base(0x14F0)
		{
			Name = "Searching";
			m_Skill = skill;
			m_Value = value;
		}

		public DJ_SW_DetectHidden(Serial serial): base(serial)
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

	public class DJ_SW_Discordance : PowerScroll
	{
		private SkillName m_Skill;
		private int m_Value;
		private static SkillName[] m_Skills = new SkillName[]
		{
			SkillName.Discordance
		};
		public new SkillName[] Skills { get { return m_Skills; } }
		[Constructable]
		public DJ_SW_Discordance(): base(SkillName.Discordance, 105)
		{
		}
		[Constructable]
		public DJ_SW_Discordance(SkillName skill, int value): base(0x14F0)
		{
			Name = "Discordance";
			m_Skill = skill;
			m_Value = value;
		}

		public DJ_SW_Discordance(Serial serial): base(serial)
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

	public class DJ_SW_EvalInt : PowerScroll
	{
		private SkillName m_Skill;
		private int m_Value;
		private static SkillName[] m_Skills = new SkillName[]
		{
			SkillName.Psychology
		};
		public new SkillName[] Skills { get { return m_Skills; } }
		[Constructable]
		public DJ_SW_EvalInt(): base(SkillName.Psychology, 105)
		{
		}
		[Constructable]
		public DJ_SW_EvalInt(SkillName skill, int value): base(0x14F0)
		{
			Name = "Psychology";
			m_Skill = skill;
			m_Value = value;
		}

		public DJ_SW_EvalInt(Serial serial): base(serial)
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

	public class DJ_SW_Fencing : PowerScroll
	{
		private SkillName m_Skill;
		private int m_Value;
		private static SkillName[] m_Skills = new SkillName[]
		{
			SkillName.Fencing
		};
		public new SkillName[] Skills { get { return m_Skills; } }
		[Constructable]
		public DJ_SW_Fencing(): base(SkillName.Fencing, 105)
		{
		}
		[Constructable]
		public DJ_SW_Fencing(SkillName skill, int value): base(0x14F0)
		{
			Name = "Fencing";
			m_Skill = skill;
			m_Value = value;
		}

		public DJ_SW_Fencing(Serial serial): base(serial)
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

	public class DJ_SW_Fishing : PowerScroll
	{
		private SkillName m_Skill;
		private int m_Value;
		private static SkillName[] m_Skills = new SkillName[]
		{
			SkillName.Seafaring
		};
		public new SkillName[] Skills { get { return m_Skills; } }
		[Constructable]
		public DJ_SW_Fishing(): base(SkillName.Seafaring, 105)
		{
		}
		[Constructable]
		public DJ_SW_Fishing(SkillName skill, int value): base(0x14F0)
		{
			Name = "Seafaring";
			m_Skill = skill;
			m_Value = value;
		}

		public DJ_SW_Fishing(Serial serial): base(serial)
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

	public class DJ_SW_Fletching : PowerScroll
	{
		private SkillName m_Skill;
		private int m_Value;
		private static SkillName[] m_Skills = new SkillName[]
		{
			SkillName.Bowcraft
		};
		public new SkillName[] Skills { get { return m_Skills; } }
		[Constructable]
		public DJ_SW_Fletching(): base(SkillName.Bowcraft, 105)
		{
		}
		[Constructable]
		public DJ_SW_Fletching(SkillName skill, int value): base(0x14F0)
		{
			Name = "Bowcrafting";
			m_Skill = skill;
			m_Value = value;
		}

		public DJ_SW_Fletching(Serial serial): base(serial)
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

	public class DJ_SW_Healing : PowerScroll
	{
		private SkillName m_Skill;
		private int m_Value;
		private static SkillName[] m_Skills = new SkillName[]
		{
			SkillName.Healing
		};
		public new SkillName[] Skills { get { return m_Skills; } }
		[Constructable]
		public DJ_SW_Healing(): base(SkillName.Healing, 105)
		{
		}
		[Constructable]
		public DJ_SW_Healing(SkillName skill, int value): base(0x14F0)
		{
			Name = "Healing";
			m_Skill = skill;
			m_Value = value;
		}

		public DJ_SW_Healing(Serial serial): base(serial)
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

	public class DJ_SW_Herding : PowerScroll
	{
		private SkillName m_Skill;
		private int m_Value;
		private static SkillName[] m_Skills = new SkillName[]
		{
			SkillName.Herding
		};
		public new SkillName[] Skills { get { return m_Skills; } }
		[Constructable]
		public DJ_SW_Herding(): base(SkillName.Herding, 105)
		{
		}
		[Constructable]
		public DJ_SW_Herding(SkillName skill, int value): base(0x14F0)
		{
			Name = "Herding";
			m_Skill = skill;
			m_Value = value;
		}

		public DJ_SW_Herding(Serial serial): base(serial)
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

	public class DJ_SW_Hiding : PowerScroll
	{
		private SkillName m_Skill;
		private int m_Value;
		private static SkillName[] m_Skills = new SkillName[]
		{
			SkillName.Hiding
		};
		public new SkillName[] Skills { get { return m_Skills; } }
		[Constructable]
		public DJ_SW_Hiding(): base(SkillName.Hiding, 105)
		{
		}
		[Constructable]
		public DJ_SW_Hiding(SkillName skill, int value): base(0x14F0)
		{
			Name = "Hiding";
			m_Skill = skill;
			m_Value = value;
		}

		public DJ_SW_Hiding(Serial serial): base(serial)
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

	public class DJ_SW_Inscribe : PowerScroll
	{
		private SkillName m_Skill;
		private int m_Value;
		private static SkillName[] m_Skills = new SkillName[]
		{
			SkillName.Inscribe
		};
		public new SkillName[] Skills { get { return m_Skills; } }
		[Constructable]
		public DJ_SW_Inscribe(): base(SkillName.Inscribe, 105)
		{
		}
		[Constructable]
		public DJ_SW_Inscribe(SkillName skill, int value): base(0x14F0)
		{
			Name = "Inscription";
			m_Skill = skill;
			m_Value = value;
		}

		public DJ_SW_Inscribe(Serial serial): base(serial)
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

	public class DJ_SW_Lockpicking : PowerScroll
	{
		private SkillName m_Skill;
		private int m_Value;
		private static SkillName[] m_Skills = new SkillName[]
		{
			SkillName.Lockpicking
		};
		public new SkillName[] Skills { get { return m_Skills; } }
		[Constructable]
		public DJ_SW_Lockpicking(): base(SkillName.Lockpicking, 105)
		{
		}
		[Constructable]
		public DJ_SW_Lockpicking(SkillName skill, int value): base(0x14F0)
		{
			Name = "Lockpicking";
			m_Skill = skill;
			m_Value = value;
		}

		public DJ_SW_Lockpicking(Serial serial): base(serial)
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

	public class DJ_SW_Lumberjacking : PowerScroll
	{
		private SkillName m_Skill;
		private int m_Value;
		private static SkillName[] m_Skills = new SkillName[]
		{
			SkillName.Lumberjacking
		};
		public new SkillName[] Skills { get { return m_Skills; } }
		[Constructable]
		public DJ_SW_Lumberjacking(): base(SkillName.Lumberjacking, 105)
		{
		}
		[Constructable]
		public DJ_SW_Lumberjacking(SkillName skill, int value): base(0x14F0)
		{
			Name = "Lumberjacking";
			m_Skill = skill;
			m_Value = value;
		}

		public DJ_SW_Lumberjacking(Serial serial): base(serial)
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

	public class DJ_SW_Macing : PowerScroll
	{
		private SkillName m_Skill;
		private int m_Value;
		private static SkillName[] m_Skills = new SkillName[]
		{
			SkillName.Bludgeoning
		};
		public new SkillName[] Skills { get { return m_Skills; } }
		[Constructable]
		public DJ_SW_Macing(): base(SkillName.Bludgeoning, 105)
		{
		}
		[Constructable]
		public DJ_SW_Macing(SkillName skill, int value): base(0x14F0)
		{
			Name = "Bludgeoning";
			m_Skill = skill;
			m_Value = value;
		}

		public DJ_SW_Macing(Serial serial): base(serial)
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

	public class DJ_SW_Magery : PowerScroll
	{
		private SkillName m_Skill;
		private int m_Value;
		private static SkillName[] m_Skills = new SkillName[]
		{
			SkillName.Magery
		};
		public new SkillName[] Skills { get { return m_Skills; } }
		[Constructable]
		public DJ_SW_Magery(): base(SkillName.Magery, 105)
		{
		}
		[Constructable]
		public DJ_SW_Magery(SkillName skill, int value): base(0x14F0)
		{
			Name = "Magery";
			m_Skill = skill;
			m_Value = value;
		}

		public DJ_SW_Magery(Serial serial): base(serial)
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

	public class DJ_SW_MagicResist : PowerScroll
	{
		private SkillName m_Skill;
		private int m_Value;
		private static SkillName[] m_Skills = new SkillName[]
		{
			SkillName.MagicResist
		};
		public new SkillName[] Skills { get { return m_Skills; } }
		[Constructable]
		public DJ_SW_MagicResist(): base(SkillName.MagicResist, 105)
		{
		}
		[Constructable]
		public DJ_SW_MagicResist(SkillName skill, int value): base(0x14F0)
		{
			Name = "Magic Resist";
			m_Skill = skill;
			m_Value = value;
		}

		public DJ_SW_MagicResist(Serial serial): base(serial)
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

	public class DJ_SW_Meditation : PowerScroll
	{
		private SkillName m_Skill;
		private int m_Value;
		private static SkillName[] m_Skills = new SkillName[]
		{
			SkillName.Meditation
		};
		public new SkillName[] Skills { get { return m_Skills; } }
		[Constructable]
		public DJ_SW_Meditation(): base(SkillName.Meditation, 105)
		{
		}
		[Constructable]
		public DJ_SW_Meditation(SkillName skill, int value): base(0x14F0)
		{
			Name = "Meditation";
			m_Skill = skill;
			m_Value = value;
		}

		public DJ_SW_Meditation(Serial serial): base(serial)
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

	public class DJ_SW_Mining : PowerScroll
	{
		private SkillName m_Skill;
		private int m_Value;
		private static SkillName[] m_Skills = new SkillName[]
		{
			SkillName.Mining
		};
		public new SkillName[] Skills { get { return m_Skills; } }
		[Constructable]
		public DJ_SW_Mining(): base(SkillName.Mining, 105)
		{
		}
		[Constructable]
		public DJ_SW_Mining(SkillName skill, int value): base(0x14F0)
		{
			Name = "Mining";
			m_Skill = skill;
			m_Value = value;
		}

		public DJ_SW_Mining(Serial serial): base(serial)
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

	public class DJ_SW_Musicianship : PowerScroll
	{
		private SkillName m_Skill;
		private int m_Value;
		private static SkillName[] m_Skills = new SkillName[]
		{
			SkillName.Musicianship
		};
		public new SkillName[] Skills { get { return m_Skills; } }
		[Constructable]
		public DJ_SW_Musicianship(): base(SkillName.Musicianship, 105)
		{
		}
		[Constructable]
		public DJ_SW_Musicianship(SkillName skill, int value): base(0x14F0)
		{
			Name = "Musicianship";
			m_Skill = skill;
			m_Value = value;
		}

		public DJ_SW_Musicianship(Serial serial): base(serial)
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

	public class DJ_SW_Necromancy : PowerScroll
	{
		private SkillName m_Skill;
		private int m_Value;
		private static SkillName[] m_Skills = new SkillName[]
		{
			SkillName.Necromancy
		};
		public new SkillName[] Skills { get { return m_Skills; } }
		[Constructable]
		public DJ_SW_Necromancy(): base(SkillName.Necromancy, 105)
		{
		}
		[Constructable]
		public DJ_SW_Necromancy(SkillName skill, int value): base(0x14F0)
		{
			Name = "Necromancy";
			m_Skill = skill;
			m_Value = value;
		}

		public DJ_SW_Necromancy(Serial serial): base(serial)
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

	public class DJ_SW_Ninjitsu : PowerScroll
	{
		private SkillName m_Skill;
		private int m_Value;
		private static SkillName[] m_Skills = new SkillName[]
		{
			SkillName.Ninjitsu
		};
		public new SkillName[] Skills { get { return m_Skills; } }
		[Constructable]
		public DJ_SW_Ninjitsu(): base(SkillName.Ninjitsu, 105)
		{
		}
		[Constructable]
		public DJ_SW_Ninjitsu(SkillName skill, int value): base(0x14F0)
		{
			Name = "Ninjitsu";
			m_Skill = skill;
			m_Value = value;
		}

		public DJ_SW_Ninjitsu(Serial serial): base(serial)
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

	public class DJ_SW_Parry : PowerScroll
	{
		private SkillName m_Skill;
		private int m_Value;
		private static SkillName[] m_Skills = new SkillName[]
		{
			SkillName.Parry
		};
		public new SkillName[] Skills { get { return m_Skills; } }
		[Constructable]
		public DJ_SW_Parry(): base(SkillName.Parry, 105)
		{
		}
		[Constructable]
		public DJ_SW_Parry(SkillName skill, int value): base(0x14F0)
		{
			Name = "Parry";
			m_Skill = skill;
			m_Value = value;
		}

		public DJ_SW_Parry(Serial serial): base(serial)
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

	public class DJ_SW_Peacemaking : PowerScroll
	{
		private SkillName m_Skill;
		private int m_Value;
		private static SkillName[] m_Skills = new SkillName[]
		{
			SkillName.Peacemaking
		};
		public new SkillName[] Skills { get { return m_Skills; } }
		[Constructable]
		public DJ_SW_Peacemaking(): base(SkillName.Peacemaking, 105)
		{
		}
		[Constructable]
		public DJ_SW_Peacemaking(SkillName skill, int value): base(0x14F0)
		{
			Name = "Peacemaking";
			m_Skill = skill;
			m_Value = value;
		}

		public DJ_SW_Peacemaking(Serial serial): base(serial)
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

	public class DJ_SW_Poisoning : PowerScroll
	{
		private SkillName m_Skill;
		private int m_Value;
		private static SkillName[] m_Skills = new SkillName[]
		{
			SkillName.Poisoning
		};
		public new SkillName[] Skills { get { return m_Skills; } }
		[Constructable]
		public DJ_SW_Poisoning(): base(SkillName.Poisoning, 105)
		{
		}
		[Constructable]
		public DJ_SW_Poisoning(SkillName skill, int value): base(0x14F0)
		{
			Name = "Poisoning";
			m_Skill = skill;
			m_Value = value;
		}

		public DJ_SW_Poisoning(Serial serial): base(serial)
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

	public class DJ_SW_Provocation : PowerScroll
	{
		private SkillName m_Skill;
		private int m_Value;
		private static SkillName[] m_Skills = new SkillName[]
		{
			SkillName.Provocation
		};
		public new SkillName[] Skills { get { return m_Skills; } }
		[Constructable]
		public DJ_SW_Provocation(): base(SkillName.Provocation, 105)
		{
		}
		[Constructable]
		public DJ_SW_Provocation(SkillName skill, int value): base(0x14F0)
		{
			Name = "Provocation";
			m_Skill = skill;
			m_Value = value;
		}

		public DJ_SW_Provocation(Serial serial): base(serial)
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

	public class DJ_SW_RemoveTrap : PowerScroll
	{
		private SkillName m_Skill;
		private int m_Value;
		private static SkillName[] m_Skills = new SkillName[]
		{
			SkillName.RemoveTrap
		};
		public new SkillName[] Skills { get { return m_Skills; } }
		[Constructable]
		public DJ_SW_RemoveTrap(): base(SkillName.RemoveTrap, 105)
		{
		}
		[Constructable]
		public DJ_SW_RemoveTrap(SkillName skill, int value): base(0x14F0)
		{
			Name = "Remove Trap";
			m_Skill = skill;
			m_Value = value;
		}

		public DJ_SW_RemoveTrap(Serial serial): base(serial)
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

	public class DJ_SW_Snooping : PowerScroll
	{
		private SkillName m_Skill;
		private int m_Value;
		private static SkillName[] m_Skills = new SkillName[]
		{
			SkillName.Snooping
		};
		public new SkillName[] Skills { get { return m_Skills; } }
		[Constructable]
		public DJ_SW_Snooping(): base(SkillName.Snooping, 105)
		{
		}
		[Constructable]
		public DJ_SW_Snooping(SkillName skill, int value): base(0x14F0)
		{
			Name = "Snooping";
			m_Skill = skill;
			m_Value = value;
		}

		public DJ_SW_Snooping(Serial serial): base(serial)
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

	public class DJ_SW_Elementalism : PowerScroll
	{
		private SkillName m_Skill;
		private int m_Value;
		private static SkillName[] m_Skills = new SkillName[]
		{
			SkillName.Elementalism
		};
		public new SkillName[] Skills { get { return m_Skills; } }
		[Constructable]
		public DJ_SW_Elementalism(): base(SkillName.Elementalism, 105)
		{
		}
		[Constructable]
		public DJ_SW_Elementalism(SkillName skill, int value): base(0x14F0)
		{
			Name = "Elementalism";
			m_Skill = skill;
			m_Value = value;
		}

		public DJ_SW_Elementalism(Serial serial): base(serial)
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

	public class DJ_SW_SpiritSpeak : PowerScroll
	{
		private SkillName m_Skill;
		private int m_Value;
		private static SkillName[] m_Skills = new SkillName[]
		{
			SkillName.Spiritualism
		};
		public new SkillName[] Skills { get { return m_Skills; } }
		[Constructable]
		public DJ_SW_SpiritSpeak(): base(SkillName.Spiritualism, 105)
		{
		}
		[Constructable]
		public DJ_SW_SpiritSpeak(SkillName skill, int value): base(0x14F0)
		{
			Name = "Spiritualism";
			m_Skill = skill;
			m_Value = value;
		}

		public DJ_SW_SpiritSpeak(Serial serial): base(serial)
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

	public class DJ_SW_Stealing : PowerScroll
	{
		private SkillName m_Skill;
		private int m_Value;
		private static SkillName[] m_Skills = new SkillName[]
		{
			SkillName.Stealing
		};
		public new SkillName[] Skills { get { return m_Skills; } }
		[Constructable]
		public DJ_SW_Stealing(): base(SkillName.Stealing, 105)
		{
		}
		[Constructable]
		public DJ_SW_Stealing(SkillName skill, int value): base(0x14F0)
		{
			Name = "Stealing";
			m_Skill = skill;
			m_Value = value;
		}

		public DJ_SW_Stealing(Serial serial): base(serial)
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

	public class DJ_SW_Stealth : PowerScroll
	{
		private SkillName m_Skill;
		private int m_Value;
		private static SkillName[] m_Skills = new SkillName[]
		{
			SkillName.Stealth
		};
		public new SkillName[] Skills { get { return m_Skills; } }
		[Constructable]
		public DJ_SW_Stealth(): base(SkillName.Stealth, 105)
		{
		}
		[Constructable]
		public DJ_SW_Stealth(SkillName skill, int value): base(0x14F0)
		{
			Name = "Stealth";
			m_Skill = skill;
			m_Value = value;
		}

		public DJ_SW_Stealth(Serial serial): base(serial)
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

	public class DJ_SW_Swords : PowerScroll
	{
		private SkillName m_Skill;
		private int m_Value;
		private static SkillName[] m_Skills = new SkillName[]
		{
			SkillName.Swords
		};
		public new SkillName[] Skills { get { return m_Skills; } }
		[Constructable]
		public DJ_SW_Swords(): base(SkillName.Swords, 105)
		{
		}
		[Constructable]
		public DJ_SW_Swords(SkillName skill, int value): base(0x14F0)
		{
			Name = "Sword Fighting";
			m_Skill = skill;
			m_Value = value;
		}

		public DJ_SW_Swords(Serial serial): base(serial)
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

	public class DJ_SW_Tactics : PowerScroll
	{
		private SkillName m_Skill;
		private int m_Value;
		private static SkillName[] m_Skills = new SkillName[]
		{
			SkillName.Tactics
		};
		public new SkillName[] Skills { get { return m_Skills; } }
		[Constructable]
		public DJ_SW_Tactics(): base(SkillName.Tactics, 105)
		{
		}
		[Constructable]
		public DJ_SW_Tactics(SkillName skill, int value): base(0x14F0)
		{
			Name = "Tactics";
			m_Skill = skill;
			m_Value = value;
		}

		public DJ_SW_Tactics(Serial serial): base(serial)
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

	public class DJ_SW_Tailoring : PowerScroll
	{
		private SkillName m_Skill;
		private int m_Value;
		private static SkillName[] m_Skills = new SkillName[]
		{
			SkillName.Tailoring
		};
		public new SkillName[] Skills { get { return m_Skills; } }
		[Constructable]
		public DJ_SW_Tailoring(): base(SkillName.Tailoring, 105)
		{
		}
		[Constructable]
		public DJ_SW_Tailoring(SkillName skill, int value): base(0x14F0)
		{
			Name = "Tailoring";
			m_Skill = skill;
			m_Value = value;
		}

		public DJ_SW_Tailoring(Serial serial): base(serial)
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

	public class DJ_SW_Tinkering : PowerScroll
	{
		private SkillName m_Skill;
		private int m_Value;
		private static SkillName[] m_Skills = new SkillName[]
		{
			SkillName.Tinkering
		};
		public new SkillName[] Skills { get { return m_Skills; } }
		[Constructable]
		public DJ_SW_Tinkering(): base(SkillName.Tinkering, 105)
		{
		}
		[Constructable]
		public DJ_SW_Tinkering(SkillName skill, int value): base(0x14F0)
		{
			Name = "Tinkering";
			m_Skill = skill;
			m_Value = value;
		}

		public DJ_SW_Tinkering(Serial serial): base(serial)
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

	public class DJ_SW_Tracking : PowerScroll
	{
		private SkillName m_Skill;
		private int m_Value;
		private static SkillName[] m_Skills = new SkillName[]
		{
			SkillName.Tracking
		};
		public new SkillName[] Skills { get { return m_Skills; } }
		[Constructable]
		public DJ_SW_Tracking(): base(SkillName.Tracking, 105)
		{
		}
		[Constructable]
		public DJ_SW_Tracking(SkillName skill, int value): base(0x14F0)
		{
			Name = "Tracking";
			m_Skill = skill;
			m_Value = value;
		}

		public DJ_SW_Tracking(Serial serial): base(serial)
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

	public class DJ_SW_Veterinary : PowerScroll
	{
		private SkillName m_Skill;
		private int m_Value;
		private static SkillName[] m_Skills = new SkillName[]
		{
			SkillName.Veterinary
		};
		public new SkillName[] Skills { get { return m_Skills; } }
		[Constructable]
		public DJ_SW_Veterinary(): base(SkillName.Veterinary, 105)
		{
		}
		[Constructable]
		public DJ_SW_Veterinary(SkillName skill, int value): base(0x14F0)
		{
			Name = "Veterinary";
			m_Skill = skill;
			m_Value = value;
		}

		public DJ_SW_Veterinary(Serial serial): base(serial)
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

	public class DJ_SW_Wrestling : PowerScroll
	{
		private SkillName m_Skill;
		private int m_Value;
		private static SkillName[] m_Skills = new SkillName[]
		{
			SkillName.FistFighting
		};
		public new SkillName[] Skills { get { return m_Skills; } }
		[Constructable]
		public DJ_SW_Wrestling(): base(SkillName.FistFighting, 105)
		{
		}
		[Constructable]
		public DJ_SW_Wrestling(SkillName skill, int value): base(0x14F0)
		{
			Name = "Fist Fighting";
			m_Skill = skill;
			m_Value = value;
		}

		public DJ_SW_Wrestling(Serial serial): base(serial)
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

	public class DJ_SW_Anatomy : PowerScroll
	{
		private SkillName m_Skill;
		private int m_Value;
		private static SkillName[] m_Skills = new SkillName[]
		{
			SkillName.Anatomy
		};
		public new SkillName[] Skills { get { return m_Skills; } }
		[Constructable]
		public DJ_SW_Anatomy(): base(SkillName.Anatomy, 105)
		{
		}
		[Constructable]
		public DJ_SW_Anatomy(SkillName skill, int value): base(0x14F0)
		{
			Name = "Anatomy";
			m_Skill = skill;
			m_Value = value;
		}

		public DJ_SW_Anatomy(Serial serial): base(serial)
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

	public class DJ_SW_Focus : PowerScroll
	{
		private SkillName m_Skill;
		private int m_Value;
		private static SkillName[] m_Skills = new SkillName[]
		{
			SkillName.Focus
		};
		public new SkillName[] Skills { get { return m_Skills; } }
		[Constructable]
		public DJ_SW_Focus(): base(SkillName.Focus, 105)
		{
		}
		[Constructable]
		public DJ_SW_Focus(SkillName skill, int value): base(0x14F0)
		{
			Name = "Focus";
			m_Skill = skill;
			m_Value = value;
		}

		public DJ_SW_Focus(Serial serial): base(serial)
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