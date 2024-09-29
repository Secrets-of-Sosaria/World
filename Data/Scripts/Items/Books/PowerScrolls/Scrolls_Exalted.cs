using System;
using Server;
using Server.Engines.Craft;
using Server.Gumps;
using Server.Network;

namespace Server.Items
{
	public class DJ_SE_Anatomy : PowerScroll
	{
		private SkillName m_Skill;
		private int m_Value;
		private static SkillName[] m_Skills = new SkillName[]
		{
			SkillName.Anatomy
		};
		public new SkillName[] Skills { get { return m_Skills; } }
		[Constructable]
		public DJ_SE_Anatomy(): base(SkillName.Anatomy, 110)
		{
		}
		[Constructable]
		public DJ_SE_Anatomy(SkillName skill, int value): base(0x14F0)
		{
			Name = "Anatomy";
			m_Skill = skill;
			m_Value = value;
		}

		public DJ_SE_Anatomy(Serial serial): base(serial)
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

	public class DJ_SE_Focus : PowerScroll
	{
		private SkillName m_Skill;
		private int m_Value;
		private static SkillName[] m_Skills = new SkillName[]
		{
			SkillName.Focus
		};
		public new SkillName[] Skills { get { return m_Skills; } }
		[Constructable]
		public DJ_SE_Focus(): base(SkillName.Focus, 110)
		{
		}
		[Constructable]
		public DJ_SE_Focus(SkillName skill, int value): base(0x14F0)
		{
			Name = "Focus";
			m_Skill = skill;
			m_Value = value;
		}

		public DJ_SE_Focus(Serial serial): base(serial)
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

	public class DJ_SE_Alchemy : PowerScroll
	{
		private SkillName m_Skill;
		private int m_Value;
		private static SkillName[] m_Skills = new SkillName[]
		{
			SkillName.Alchemy
		};
		public new SkillName[] Skills { get { return m_Skills; } }
		[Constructable]
		public DJ_SE_Alchemy(): base(SkillName.Alchemy, 110)
		{
		}
		[Constructable]
		public DJ_SE_Alchemy(SkillName skill, int value): base(0x14F0)
		{
			Name = "Alchemy";
			m_Skill = skill;
			m_Value = value;
		}

		public DJ_SE_Alchemy(Serial serial): base(serial)
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

	public class DJ_SE_AnimalLore : PowerScroll
	{
		private SkillName m_Skill;
		private int m_Value;
		private static SkillName[] m_Skills = new SkillName[]
		{
			SkillName.Druidism
		};
		public new SkillName[] Skills { get { return m_Skills; } }
		[Constructable]
		public DJ_SE_AnimalLore(): base(SkillName.Druidism, 110)
		{
		}
		[Constructable]
		public DJ_SE_AnimalLore(SkillName skill, int value): base(0x14F0)
		{
			Name = "Druidism";
			m_Skill = skill;
			m_Value = value;
		}

		public DJ_SE_AnimalLore(Serial serial): base(serial)
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

	public class DJ_SE_AnimalTaming : PowerScroll
	{
		private SkillName m_Skill;
		private int m_Value;
		private static SkillName[] m_Skills = new SkillName[]
		{
			SkillName.Taming
		};
		public new SkillName[] Skills { get { return m_Skills; } }
		[Constructable]
		public DJ_SE_AnimalTaming(): base(SkillName.Taming, 110)
		{
		}
		[Constructable]
		public DJ_SE_AnimalTaming(SkillName skill, int value): base(0x14F0)
		{
			Name = "Taming";
			m_Skill = skill;
			m_Value = value;
		}

		public DJ_SE_AnimalTaming(Serial serial): base(serial)
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

	public class DJ_SE_Archery : PowerScroll
	{
		private SkillName m_Skill;
		private int m_Value;
		private static SkillName[] m_Skills = new SkillName[]
		{
			SkillName.Marksmanship
		};
		public new SkillName[] Skills { get { return m_Skills; } }
		[Constructable]
		public DJ_SE_Archery(): base(SkillName.Marksmanship, 110)
		{
		}
		[Constructable]
		public DJ_SE_Archery(SkillName skill, int value): base(0x14F0)
		{
			Name = "Marksmanship";
			m_Skill = skill;
			m_Value = value;
		}

		public DJ_SE_Archery(Serial serial): base(serial)
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

	public class DJ_SE_ArmsLore : PowerScroll
	{
		private SkillName m_Skill;
		private int m_Value;
		private static SkillName[] m_Skills = new SkillName[]
		{
			SkillName.ArmsLore
		};
		public new SkillName[] Skills { get { return m_Skills; } }
		[Constructable]
		public DJ_SE_ArmsLore(): base(SkillName.ArmsLore, 110)
		{
		}
		[Constructable]
		public DJ_SE_ArmsLore(SkillName skill, int value): base(0x14F0)
		{
			Name = "Arms Lore";
			m_Skill = skill;
			m_Value = value;
		}

		public DJ_SE_ArmsLore(Serial serial): base(serial)
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

	public class DJ_SE_Blacksmith : PowerScroll
	{
		private SkillName m_Skill;
		private int m_Value;
		private static SkillName[] m_Skills = new SkillName[]
		{
			SkillName.Blacksmith
		};
		public new SkillName[] Skills { get { return m_Skills; } }
		[Constructable]
		public DJ_SE_Blacksmith(): base(SkillName.Blacksmith, 110)
		{
		}
		[Constructable]
		public DJ_SE_Blacksmith(SkillName skill, int value): base(0x14F0)
		{
			Name = "Blacksmithing";
			m_Skill = skill;
			m_Value = value;
		}

		public DJ_SE_Blacksmith(Serial serial): base(serial)
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

	public class DJ_SE_Bushido : PowerScroll
	{
		private SkillName m_Skill;
		private int m_Value;
		private static SkillName[] m_Skills = new SkillName[]
		{
			SkillName.Bushido
		};
		public new SkillName[] Skills { get { return m_Skills; } }
		[Constructable]
		public DJ_SE_Bushido(): base(SkillName.Bushido, 110)
		{
		}
		[Constructable]
		public DJ_SE_Bushido(SkillName skill, int value): base(0x14F0)
		{
			Name = "Bushido";
			m_Skill = skill;
			m_Value = value;
		}

		public DJ_SE_Bushido(Serial serial): base(serial)
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

	public class DJ_SE_Carpentry : PowerScroll
	{
		private SkillName m_Skill;
		private int m_Value;
		private static SkillName[] m_Skills = new SkillName[]
		{
			SkillName.Carpentry
		};
		public new SkillName[] Skills { get { return m_Skills; } }
		[Constructable]
		public DJ_SE_Carpentry(): base(SkillName.Carpentry, 110)
		{
		}
		[Constructable]
		public DJ_SE_Carpentry(SkillName skill, int value): base(0x14F0)
		{
			Name = "Carpentry";
			m_Skill = skill;
			m_Value = value;
		}

		public DJ_SE_Carpentry(Serial serial): base(serial)
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

	public class DJ_SE_Cartography : PowerScroll
	{
		private SkillName m_Skill;
		private int m_Value;
		private static SkillName[] m_Skills = new SkillName[]
		{
			SkillName.Cartography
		};
		public new SkillName[] Skills { get { return m_Skills; } }
		[Constructable]
		public DJ_SE_Cartography(): base(SkillName.Cartography, 110)
		{
		}
		[Constructable]
		public DJ_SE_Cartography(SkillName skill, int value): base(0x14F0)
		{
			Name = "Cartography";
			m_Skill = skill;
			m_Value = value;
		}

		public DJ_SE_Cartography(Serial serial): base(serial)
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

	public class DJ_SE_Chivalry : PowerScroll
	{
		private SkillName m_Skill;
		private int m_Value;
		private static SkillName[] m_Skills = new SkillName[]
		{
			SkillName.Knightship
		};
		public new SkillName[] Skills { get { return m_Skills; } }
		[Constructable]
		public DJ_SE_Chivalry(): base(SkillName.Knightship, 110)
		{
		}
		[Constructable]
		public DJ_SE_Chivalry(SkillName skill, int value): base(0x14F0)
		{
			Name = "Knightship";
			m_Skill = skill;
			m_Value = value;
		}

		public DJ_SE_Chivalry(Serial serial): base(serial)
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

	public class DJ_SE_Cooking : PowerScroll
	{
		private SkillName m_Skill;
		private int m_Value;
		private static SkillName[] m_Skills = new SkillName[]
		{
			SkillName.Cooking
		};
		public new SkillName[] Skills { get { return m_Skills; } }
		[Constructable]
		public DJ_SE_Cooking(): base(SkillName.Cooking, 110)
		{
		}
		[Constructable]
		public DJ_SE_Cooking(SkillName skill, int value): base(0x14F0)
		{
			Name = "Cooking";
			m_Skill = skill;
			m_Value = value;
		}

		public DJ_SE_Cooking(Serial serial): base(serial)
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

	public class DJ_SE_DetectHidden : PowerScroll
	{
		private SkillName m_Skill;
		private int m_Value;
		private static SkillName[] m_Skills = new SkillName[]
		{
			SkillName.Searching
		};
		public new SkillName[] Skills { get { return m_Skills; } }
		[Constructable]
		public DJ_SE_DetectHidden(): base(SkillName.Searching, 110)
		{
		}
		[Constructable]
		public DJ_SE_DetectHidden(SkillName skill, int value): base(0x14F0)
		{
			Name = "Searching";
			m_Skill = skill;
			m_Value = value;
		}

		public DJ_SE_DetectHidden(Serial serial): base(serial)
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

	public class DJ_SE_Discordance : PowerScroll
	{
		private SkillName m_Skill;
		private int m_Value;
		private static SkillName[] m_Skills = new SkillName[]
		{
			SkillName.Discordance
		};
		public new SkillName[] Skills { get { return m_Skills; } }
		[Constructable]
		public DJ_SE_Discordance(): base(SkillName.Discordance, 110)
		{
		}
		[Constructable]
		public DJ_SE_Discordance(SkillName skill, int value): base(0x14F0)
		{
			Name = "Discordance";
			m_Skill = skill;
			m_Value = value;
		}

		public DJ_SE_Discordance(Serial serial): base(serial)
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

	public class DJ_SE_EvalInt : PowerScroll
	{
		private SkillName m_Skill;
		private int m_Value;
		private static SkillName[] m_Skills = new SkillName[]
		{
			SkillName.Psychology
		};
		public new SkillName[] Skills { get { return m_Skills; } }
		[Constructable]
		public DJ_SE_EvalInt(): base(SkillName.Psychology, 110)
		{
		}
		[Constructable]
		public DJ_SE_EvalInt(SkillName skill, int value): base(0x14F0)
		{
			Name = "Psychology";
			m_Skill = skill;
			m_Value = value;
		}

		public DJ_SE_EvalInt(Serial serial): base(serial)
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

	public class DJ_SE_Fencing : PowerScroll
	{
		private SkillName m_Skill;
		private int m_Value;
		private static SkillName[] m_Skills = new SkillName[]
		{
			SkillName.Fencing
		};
		public new SkillName[] Skills { get { return m_Skills; } }
		[Constructable]
		public DJ_SE_Fencing(): base(SkillName.Fencing, 110)
		{
		}
		[Constructable]
		public DJ_SE_Fencing(SkillName skill, int value): base(0x14F0)
		{
			Name = "Fencing";
			m_Skill = skill;
			m_Value = value;
		}

		public DJ_SE_Fencing(Serial serial): base(serial)
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

	public class DJ_SE_Fishing : PowerScroll
	{
		private SkillName m_Skill;
		private int m_Value;
		private static SkillName[] m_Skills = new SkillName[]
		{
			SkillName.Seafaring
		};
		public new SkillName[] Skills { get { return m_Skills; } }
		[Constructable]
		public DJ_SE_Fishing(): base(SkillName.Seafaring, 110)
		{
		}
		[Constructable]
		public DJ_SE_Fishing(SkillName skill, int value): base(0x14F0)
		{
			Name = "Seafaring";
			m_Skill = skill;
			m_Value = value;
		}

		public DJ_SE_Fishing(Serial serial): base(serial)
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

	public class DJ_SE_Fletching : PowerScroll
	{
		private SkillName m_Skill;
		private int m_Value;
		private static SkillName[] m_Skills = new SkillName[]
		{
			SkillName.Bowcraft
		};
		public new SkillName[] Skills { get { return m_Skills; } }
		[Constructable]
		public DJ_SE_Fletching(): base(SkillName.Bowcraft, 110)
		{
		}
		[Constructable]
		public DJ_SE_Fletching(SkillName skill, int value): base(0x14F0)
		{
			Name = "Bowcrafting";
			m_Skill = skill;
			m_Value = value;
		}

		public DJ_SE_Fletching(Serial serial): base(serial)
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

	public class DJ_SE_Healing : PowerScroll
	{
		private SkillName m_Skill;
		private int m_Value;
		private static SkillName[] m_Skills = new SkillName[]
		{
			SkillName.Healing
		};
		public new SkillName[] Skills { get { return m_Skills; } }
		[Constructable]
		public DJ_SE_Healing(): base(SkillName.Healing, 110)
		{
		}
		[Constructable]
		public DJ_SE_Healing(SkillName skill, int value): base(0x14F0)
		{
			Name = "Healing";
			m_Skill = skill;
			m_Value = value;
		}

		public DJ_SE_Healing(Serial serial): base(serial)
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

	public class DJ_SE_Herding : PowerScroll
	{
		private SkillName m_Skill;
		private int m_Value;
		private static SkillName[] m_Skills = new SkillName[]
		{
			SkillName.Herding
		};
		public new SkillName[] Skills { get { return m_Skills; } }
		[Constructable]
		public DJ_SE_Herding(): base(SkillName.Herding, 110)
		{
		}
		[Constructable]
		public DJ_SE_Herding(SkillName skill, int value): base(0x14F0)
		{
			Name = "Herding";
			m_Skill = skill;
			m_Value = value;
		}

		public DJ_SE_Herding(Serial serial): base(serial)
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

	public class DJ_SE_Hiding : PowerScroll
	{
		private SkillName m_Skill;
		private int m_Value;
		private static SkillName[] m_Skills = new SkillName[]
		{
			SkillName.Hiding
		};
		public new SkillName[] Skills { get { return m_Skills; } }
		[Constructable]
		public DJ_SE_Hiding(): base(SkillName.Hiding, 110)
		{
		}
		[Constructable]
		public DJ_SE_Hiding(SkillName skill, int value): base(0x14F0)
		{
			Name = "Hiding";
			m_Skill = skill;
			m_Value = value;
		}

		public DJ_SE_Hiding(Serial serial): base(serial)
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

	public class DJ_SE_Inscribe : PowerScroll
	{
		private SkillName m_Skill;
		private int m_Value;
		private static SkillName[] m_Skills = new SkillName[]
		{
			SkillName.Inscribe
		};
		public new SkillName[] Skills { get { return m_Skills; } }
		[Constructable]
		public DJ_SE_Inscribe(): base(SkillName.Inscribe, 110)
		{
		}
		[Constructable]
		public DJ_SE_Inscribe(SkillName skill, int value): base(0x14F0)
		{
			Name = "Inscription";
			m_Skill = skill;
			m_Value = value;
		}

		public DJ_SE_Inscribe(Serial serial): base(serial)
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

	public class DJ_SE_Lockpicking : PowerScroll
	{
		private SkillName m_Skill;
		private int m_Value;
		private static SkillName[] m_Skills = new SkillName[]
		{
			SkillName.Lockpicking
		};
		public new SkillName[] Skills { get { return m_Skills; } }
		[Constructable]
		public DJ_SE_Lockpicking(): base(SkillName.Lockpicking, 110)
		{
		}
		[Constructable]
		public DJ_SE_Lockpicking(SkillName skill, int value): base(0x14F0)
		{
			Name = "Lockpicking";
			m_Skill = skill;
			m_Value = value;
		}

		public DJ_SE_Lockpicking(Serial serial): base(serial)
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

	public class DJ_SE_Lumberjacking : PowerScroll
	{
		private SkillName m_Skill;
		private int m_Value;
		private static SkillName[] m_Skills = new SkillName[]
		{
			SkillName.Lumberjacking
		};
		public new SkillName[] Skills { get { return m_Skills; } }
		[Constructable]
		public DJ_SE_Lumberjacking(): base(SkillName.Lumberjacking, 110)
		{
		}
		[Constructable]
		public DJ_SE_Lumberjacking(SkillName skill, int value): base(0x14F0)
		{
			Name = "Lumberjacking";
			m_Skill = skill;
			m_Value = value;
		}

		public DJ_SE_Lumberjacking(Serial serial): base(serial)
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

	public class DJ_SE_Macing : PowerScroll
	{
		private SkillName m_Skill;
		private int m_Value;
		private static SkillName[] m_Skills = new SkillName[]
		{
			SkillName.Bludgeoning
		};
		public new SkillName[] Skills { get { return m_Skills; } }
		[Constructable]
		public DJ_SE_Macing(): base(SkillName.Bludgeoning, 110)
		{
		}
		[Constructable]
		public DJ_SE_Macing(SkillName skill, int value): base(0x14F0)
		{
			Name = "Bludgeoning";
			m_Skill = skill;
			m_Value = value;
		}

		public DJ_SE_Macing(Serial serial): base(serial)
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

	public class DJ_SE_Magery : PowerScroll
	{
		private SkillName m_Skill;
		private int m_Value;
		private static SkillName[] m_Skills = new SkillName[]
		{
			SkillName.Magery
		};
		public new SkillName[] Skills { get { return m_Skills; } }
		[Constructable]
		public DJ_SE_Magery(): base(SkillName.Magery, 110)
		{
		}
		[Constructable]
		public DJ_SE_Magery(SkillName skill, int value): base(0x14F0)
		{
			Name = "Magery";
			m_Skill = skill;
			m_Value = value;
		}

		public DJ_SE_Magery(Serial serial): base(serial)
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

	public class DJ_SE_MagicResist : PowerScroll
	{
		private SkillName m_Skill;
		private int m_Value;
		private static SkillName[] m_Skills = new SkillName[]
		{
			SkillName.MagicResist
		};
		public new SkillName[] Skills { get { return m_Skills; } }
		[Constructable]
		public DJ_SE_MagicResist(): base(SkillName.MagicResist, 110)
		{
		}
		[Constructable]
		public DJ_SE_MagicResist(SkillName skill, int value): base(0x14F0)
		{
			Name = "Magic Resist";
			m_Skill = skill;
			m_Value = value;
		}

		public DJ_SE_MagicResist(Serial serial): base(serial)
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

	public class DJ_SE_Meditation : PowerScroll
	{
		private SkillName m_Skill;
		private int m_Value;
		private static SkillName[] m_Skills = new SkillName[]
		{
			SkillName.Meditation
		};
		public new SkillName[] Skills { get { return m_Skills; } }
		[Constructable]
		public DJ_SE_Meditation(): base(SkillName.Meditation, 110)
		{
		}
		[Constructable]
		public DJ_SE_Meditation(SkillName skill, int value): base(0x14F0)
		{
			Name = "Meditation";
			m_Skill = skill;
			m_Value = value;
		}

		public DJ_SE_Meditation(Serial serial): base(serial)
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

	public class DJ_SE_Mining : PowerScroll
	{
		private SkillName m_Skill;
		private int m_Value;
		private static SkillName[] m_Skills = new SkillName[]
		{
			SkillName.Mining
		};
		public new SkillName[] Skills { get { return m_Skills; } }
		[Constructable]
		public DJ_SE_Mining(): base(SkillName.Mining, 110)
		{
		}
		[Constructable]
		public DJ_SE_Mining(SkillName skill, int value): base(0x14F0)
		{
			Name = "Mining";
			m_Skill = skill;
			m_Value = value;
		}

		public DJ_SE_Mining(Serial serial): base(serial)
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

	public class DJ_SE_Musicianship : PowerScroll
	{
		private SkillName m_Skill;
		private int m_Value;
		private static SkillName[] m_Skills = new SkillName[]
		{
			SkillName.Musicianship
		};
		public new SkillName[] Skills { get { return m_Skills; } }
		[Constructable]
		public DJ_SE_Musicianship(): base(SkillName.Musicianship, 110)
		{
		}
		[Constructable]
		public DJ_SE_Musicianship(SkillName skill, int value): base(0x14F0)
		{
			Name = "Musicianship";
			m_Skill = skill;
			m_Value = value;
		}

		public DJ_SE_Musicianship(Serial serial): base(serial)
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

	public class DJ_SE_Necromancy : PowerScroll
	{
		private SkillName m_Skill;
		private int m_Value;
		private static SkillName[] m_Skills = new SkillName[]
		{
			SkillName.Necromancy
		};
		public new SkillName[] Skills { get { return m_Skills; } }
		[Constructable]
		public DJ_SE_Necromancy(): base(SkillName.Necromancy, 110)
		{
		}
		[Constructable]
		public DJ_SE_Necromancy(SkillName skill, int value): base(0x14F0)
		{
			Name = "Necromancy";
			m_Skill = skill;
			m_Value = value;
		}

		public DJ_SE_Necromancy(Serial serial): base(serial)
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

	public class DJ_SE_Ninjitsu : PowerScroll
	{
		private SkillName m_Skill;
		private int m_Value;
		private static SkillName[] m_Skills = new SkillName[]
		{
			SkillName.Ninjitsu
		};
		public new SkillName[] Skills { get { return m_Skills; } }
		[Constructable]
		public DJ_SE_Ninjitsu(): base(SkillName.Ninjitsu, 110)
		{
		}
		[Constructable]
		public DJ_SE_Ninjitsu(SkillName skill, int value): base(0x14F0)
		{
			Name = "Ninjitsu";
			m_Skill = skill;
			m_Value = value;
		}

		public DJ_SE_Ninjitsu(Serial serial): base(serial)
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

	public class DJ_SE_Parry : PowerScroll
	{
		private SkillName m_Skill;
		private int m_Value;
		private static SkillName[] m_Skills = new SkillName[]
		{
			SkillName.Parry
		};
		public new SkillName[] Skills { get { return m_Skills; } }
		[Constructable]
		public DJ_SE_Parry(): base(SkillName.Parry, 110)
		{
		}
		[Constructable]
		public DJ_SE_Parry(SkillName skill, int value): base(0x14F0)
		{
			Name = "Parry";
			m_Skill = skill;
			m_Value = value;
		}

		public DJ_SE_Parry(Serial serial): base(serial)
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

	public class DJ_SE_Peacemaking : PowerScroll
	{
		private SkillName m_Skill;
		private int m_Value;
		private static SkillName[] m_Skills = new SkillName[]
		{
			SkillName.Peacemaking
		};
		public new SkillName[] Skills { get { return m_Skills; } }
		[Constructable]
		public DJ_SE_Peacemaking(): base(SkillName.Peacemaking, 110)
		{
		}
		[Constructable]
		public DJ_SE_Peacemaking(SkillName skill, int value): base(0x14F0)
		{
			Name = "Peacemaking";
			m_Skill = skill;
			m_Value = value;
		}

		public DJ_SE_Peacemaking(Serial serial): base(serial)
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

	public class DJ_SE_Poisoning : PowerScroll
	{
		private SkillName m_Skill;
		private int m_Value;
		private static SkillName[] m_Skills = new SkillName[]
		{
			SkillName.Poisoning
		};
		public new SkillName[] Skills { get { return m_Skills; } }
		[Constructable]
		public DJ_SE_Poisoning(): base(SkillName.Poisoning, 110)
		{
		}
		[Constructable]
		public DJ_SE_Poisoning(SkillName skill, int value): base(0x14F0)
		{
			Name = "Poisoning";
			m_Skill = skill;
			m_Value = value;
		}

		public DJ_SE_Poisoning(Serial serial): base(serial)
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

	public class DJ_SE_Provocation : PowerScroll
	{
		private SkillName m_Skill;
		private int m_Value;
		private static SkillName[] m_Skills = new SkillName[]
		{
			SkillName.Provocation
		};
		public new SkillName[] Skills { get { return m_Skills; } }
		[Constructable]
		public DJ_SE_Provocation(): base(SkillName.Provocation, 110)
		{
		}
		[Constructable]
		public DJ_SE_Provocation(SkillName skill, int value): base(0x14F0)
		{
			Name = "Provocation";
			m_Skill = skill;
			m_Value = value;
		}

		public DJ_SE_Provocation(Serial serial): base(serial)
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

	public class DJ_SE_RemoveTrap : PowerScroll
	{
		private SkillName m_Skill;
		private int m_Value;
		private static SkillName[] m_Skills = new SkillName[]
		{
			SkillName.RemoveTrap
		};
		public new SkillName[] Skills { get { return m_Skills; } }
		[Constructable]
		public DJ_SE_RemoveTrap(): base(SkillName.RemoveTrap, 110)
		{
		}
		[Constructable]
		public DJ_SE_RemoveTrap(SkillName skill, int value): base(0x14F0)
		{
			Name = "Remove Trap";
			m_Skill = skill;
			m_Value = value;
		}

		public DJ_SE_RemoveTrap(Serial serial): base(serial)
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

	public class DJ_SE_Snooping : PowerScroll
	{
		private SkillName m_Skill;
		private int m_Value;
		private static SkillName[] m_Skills = new SkillName[]
		{
			SkillName.Snooping
		};
		public new SkillName[] Skills { get { return m_Skills; } }
		[Constructable]
		public DJ_SE_Snooping(): base(SkillName.Snooping, 110)
		{
		}
		[Constructable]
		public DJ_SE_Snooping(SkillName skill, int value): base(0x14F0)
		{
			Name = "Snooping";
			m_Skill = skill;
			m_Value = value;
		}

		public DJ_SE_Snooping(Serial serial): base(serial)
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

	public class DJ_SE_Elementalism : PowerScroll
	{
		private SkillName m_Skill;
		private int m_Value;
		private static SkillName[] m_Skills = new SkillName[]
		{
			SkillName.Elementalism
		};
		public new SkillName[] Skills { get { return m_Skills; } }
		[Constructable]
		public DJ_SE_Elementalism(): base(SkillName.Elementalism, 110)
		{
		}
		[Constructable]
		public DJ_SE_Elementalism(SkillName skill, int value): base(0x14F0)
		{
			Name = "Elementalism";
			m_Skill = skill;
			m_Value = value;
		}

		public DJ_SE_Elementalism(Serial serial): base(serial)
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

	public class DJ_SE_SpiritSpeak : PowerScroll
	{
		private SkillName m_Skill;
		private int m_Value;
		private static SkillName[] m_Skills = new SkillName[]
		{
			SkillName.Spiritualism
		};
		public new SkillName[] Skills { get { return m_Skills; } }
		[Constructable]
		public DJ_SE_SpiritSpeak(): base(SkillName.Spiritualism, 110)
		{
		}
		[Constructable]
		public DJ_SE_SpiritSpeak(SkillName skill, int value): base(0x14F0)
		{
			Name = "Spiritualism";
			m_Skill = skill;
			m_Value = value;
		}

		public DJ_SE_SpiritSpeak(Serial serial): base(serial)
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

	public class DJ_SE_Stealing : PowerScroll
	{
		private SkillName m_Skill;
		private int m_Value;
		private static SkillName[] m_Skills = new SkillName[]
		{
			SkillName.Stealing
		};
		public new SkillName[] Skills { get { return m_Skills; } }
		[Constructable]
		public DJ_SE_Stealing(): base(SkillName.Stealing, 110)
		{
		}
		[Constructable]
		public DJ_SE_Stealing(SkillName skill, int value): base(0x14F0)
		{
			Name = "Stealing";
			m_Skill = skill;
			m_Value = value;
		}

		public DJ_SE_Stealing(Serial serial): base(serial)
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

	public class DJ_SE_Stealth : PowerScroll
	{
		private SkillName m_Skill;
		private int m_Value;
		private static SkillName[] m_Skills = new SkillName[]
		{
			SkillName.Stealth
		};
		public new SkillName[] Skills { get { return m_Skills; } }
		[Constructable]
		public DJ_SE_Stealth(): base(SkillName.Stealth, 110)
		{
		}
		[Constructable]
		public DJ_SE_Stealth(SkillName skill, int value): base(0x14F0)
		{
			Name = "Stealth";
			m_Skill = skill;
			m_Value = value;
		}

		public DJ_SE_Stealth(Serial serial): base(serial)
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

	public class DJ_SE_Swords : PowerScroll
	{
		private SkillName m_Skill;
		private int m_Value;
		private static SkillName[] m_Skills = new SkillName[]
		{
			SkillName.Swords
		};
		public new SkillName[] Skills { get { return m_Skills; } }
		[Constructable]
		public DJ_SE_Swords(): base(SkillName.Swords, 110)
		{
		}
		[Constructable]
		public DJ_SE_Swords(SkillName skill, int value): base(0x14F0)
		{
			Name = "Sword Fighting";
			m_Skill = skill;
			m_Value = value;
		}

		public DJ_SE_Swords(Serial serial): base(serial)
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

	public class DJ_SE_Tactics : PowerScroll
	{
		private SkillName m_Skill;
		private int m_Value;
		private static SkillName[] m_Skills = new SkillName[]
		{
			SkillName.Tactics
		};
		public new SkillName[] Skills { get { return m_Skills; } }
		[Constructable]
		public DJ_SE_Tactics(): base(SkillName.Tactics, 110)
		{
		}
		[Constructable]
		public DJ_SE_Tactics(SkillName skill, int value): base(0x14F0)
		{
			Name = "Tactics";
			m_Skill = skill;
			m_Value = value;
		}

		public DJ_SE_Tactics(Serial serial): base(serial)
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

	public class DJ_SE_Tailoring : PowerScroll
	{
		private SkillName m_Skill;
		private int m_Value;
		private static SkillName[] m_Skills = new SkillName[]
		{
			SkillName.Tailoring
		};
		public new SkillName[] Skills { get { return m_Skills; } }
		[Constructable]
		public DJ_SE_Tailoring(): base(SkillName.Tailoring, 110)
		{
		}
		[Constructable]
		public DJ_SE_Tailoring(SkillName skill, int value): base(0x14F0)
		{
			Name = "Tailoring";
			m_Skill = skill;
			m_Value = value;
		}

		public DJ_SE_Tailoring(Serial serial): base(serial)
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

	public class DJ_SE_Tinkering : PowerScroll
	{
		private SkillName m_Skill;
		private int m_Value;
		private static SkillName[] m_Skills = new SkillName[]
		{
			SkillName.Tinkering
		};
		public new SkillName[] Skills { get { return m_Skills; } }
		[Constructable]
		public DJ_SE_Tinkering(): base(SkillName.Tinkering, 110)
		{
		}
		[Constructable]
		public DJ_SE_Tinkering(SkillName skill, int value): base(0x14F0)
		{
			Name = "Tinkering";
			m_Skill = skill;
			m_Value = value;
		}

		public DJ_SE_Tinkering(Serial serial): base(serial)
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

	public class DJ_SE_Tracking : PowerScroll
	{
		private SkillName m_Skill;
		private int m_Value;
		private static SkillName[] m_Skills = new SkillName[]
		{
			SkillName.Tracking
		};
		public new SkillName[] Skills { get { return m_Skills; } }
		[Constructable]
		public DJ_SE_Tracking(): base(SkillName.Tracking, 110)
		{
		}
		[Constructable]
		public DJ_SE_Tracking(SkillName skill, int value): base(0x14F0)
		{
			Name = "Tracking";
			m_Skill = skill;
			m_Value = value;
		}

		public DJ_SE_Tracking(Serial serial): base(serial)
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

	public class DJ_SE_Veterinary : PowerScroll
	{
		private SkillName m_Skill;
		private int m_Value;
		private static SkillName[] m_Skills = new SkillName[]
		{
			SkillName.Veterinary
		};
		public new SkillName[] Skills { get { return m_Skills; } }
		[Constructable]
		public DJ_SE_Veterinary(): base(SkillName.Veterinary, 110)
		{
		}
		[Constructable]
		public DJ_SE_Veterinary(SkillName skill, int value): base(0x14F0)
		{
			Name = "Veterinary";
			m_Skill = skill;
			m_Value = value;
		}

		public DJ_SE_Veterinary(Serial serial): base(serial)
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

	public class DJ_SE_Wrestling : PowerScroll
	{
		private SkillName m_Skill;
		private int m_Value;
		private static SkillName[] m_Skills = new SkillName[]
		{
			SkillName.FistFighting
		};
		public new SkillName[] Skills { get { return m_Skills; } }
		[Constructable]
		public DJ_SE_Wrestling(): base(SkillName.FistFighting, 110)
		{
		}
		[Constructable]
		public DJ_SE_Wrestling(SkillName skill, int value): base(0x14F0)
		{
			Name = "Wrestling";
			m_Skill = skill;
			m_Value = value;
		}

		public DJ_SE_Wrestling(Serial serial): base(serial)
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