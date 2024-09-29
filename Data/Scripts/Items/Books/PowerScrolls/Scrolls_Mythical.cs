using System;
using Server;
using Server.Engines.Craft;
using Server.Gumps;
using Server.Network;

namespace Server.Items
{
	public class DJ_SM_Alchemy : PowerScroll
	{
		private SkillName m_Skill;
		private int m_Value;
		private static SkillName[] m_Skills = new SkillName[]
		{
			SkillName.Alchemy
		};
		public new SkillName[] Skills { get { return m_Skills; } }
		[Constructable]
		public DJ_SM_Alchemy(): base(SkillName.Alchemy, 115)
		{
		}
		[Constructable]
		public DJ_SM_Alchemy(SkillName skill, int value): base(0x14F0)
		{
			Name = "Alchemy";
			m_Skill = skill;
			m_Value = value;
		}

		public DJ_SM_Alchemy(Serial serial): base(serial)
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

	public class DJ_SM_AnimalLore : PowerScroll
	{
		private SkillName m_Skill;
		private int m_Value;
		private static SkillName[] m_Skills = new SkillName[]
		{
			SkillName.Druidism
		};
		public new SkillName[] Skills { get { return m_Skills; } }
		[Constructable]
		public DJ_SM_AnimalLore(): base(SkillName.Druidism, 115)
		{
		}
		[Constructable]
		public DJ_SM_AnimalLore(SkillName skill, int value): base(0x14F0)
		{
			Name = "Druidism";
			m_Skill = skill;
			m_Value = value;
		}

		public DJ_SM_AnimalLore(Serial serial): base(serial)
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

	public class DJ_SM_AnimalTaming : PowerScroll
	{
		private SkillName m_Skill;
		private int m_Value;
		private static SkillName[] m_Skills = new SkillName[]
		{
			SkillName.Taming
		};
		public new SkillName[] Skills { get { return m_Skills; } }
		[Constructable]
		public DJ_SM_AnimalTaming(): base(SkillName.Taming, 115)
		{
		}
		[Constructable]
		public DJ_SM_AnimalTaming(SkillName skill, int value): base(0x14F0)
		{
			Name = "Taming";
			m_Skill = skill;
			m_Value = value;
		}

		public DJ_SM_AnimalTaming(Serial serial): base(serial)
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

	public class DJ_SM_Archery : PowerScroll
	{
		private SkillName m_Skill;
		private int m_Value;
		private static SkillName[] m_Skills = new SkillName[]
		{
			SkillName.Marksmanship
		};
		public new SkillName[] Skills { get { return m_Skills; } }
		[Constructable]
		public DJ_SM_Archery(): base(SkillName.Marksmanship, 115)
		{
		}
		[Constructable]
		public DJ_SM_Archery(SkillName skill, int value): base(0x14F0)
		{
			Name = "Marksmanship";
			m_Skill = skill;
			m_Value = value;
		}

		public DJ_SM_Archery(Serial serial): base(serial)
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

	public class DJ_SM_ArmsLore : PowerScroll
	{
		private SkillName m_Skill;
		private int m_Value;
		private static SkillName[] m_Skills = new SkillName[]
		{
			SkillName.ArmsLore
		};
		public new SkillName[] Skills { get { return m_Skills; } }
		[Constructable]
		public DJ_SM_ArmsLore(): base(SkillName.ArmsLore, 115)
		{
		}
		[Constructable]
		public DJ_SM_ArmsLore(SkillName skill, int value): base(0x14F0)
		{
			Name = "Arms Lore";
			m_Skill = skill;
			m_Value = value;
		}

		public DJ_SM_ArmsLore(Serial serial): base(serial)
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

	public class DJ_SM_Blacksmith : PowerScroll
	{
		private SkillName m_Skill;
		private int m_Value;
		private static SkillName[] m_Skills = new SkillName[]
		{
			SkillName.Blacksmith
		};
		public new SkillName[] Skills { get { return m_Skills; } }
		[Constructable]
		public DJ_SM_Blacksmith(): base(SkillName.Blacksmith, 115)
		{
		}
		[Constructable]
		public DJ_SM_Blacksmith(SkillName skill, int value): base(0x14F0)
		{
			Name = "Blacksmithing";
			m_Skill = skill;
			m_Value = value;
		}

		public DJ_SM_Blacksmith(Serial serial): base(serial)
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

	public class DJ_SM_Bushido : PowerScroll
	{
		private SkillName m_Skill;
		private int m_Value;
		private static SkillName[] m_Skills = new SkillName[]
		{
			SkillName.Bushido
		};
		public new SkillName[] Skills { get { return m_Skills; } }
		[Constructable]
		public DJ_SM_Bushido(): base(SkillName.Bushido, 115)
		{
		}
		[Constructable]
		public DJ_SM_Bushido(SkillName skill, int value): base(0x14F0)
		{
			Name = "Bushido";
			m_Skill = skill;
			m_Value = value;
		}

		public DJ_SM_Bushido(Serial serial): base(serial)
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

	public class DJ_SM_Carpentry : PowerScroll
	{
		private SkillName m_Skill;
		private int m_Value;
		private static SkillName[] m_Skills = new SkillName[]
		{
			SkillName.Carpentry
		};
		public new SkillName[] Skills { get { return m_Skills; } }
		[Constructable]
		public DJ_SM_Carpentry(): base(SkillName.Carpentry, 115)
		{
		}
		[Constructable]
		public DJ_SM_Carpentry(SkillName skill, int value): base(0x14F0)
		{
			Name = "Carpentry";
			m_Skill = skill;
			m_Value = value;
		}

		public DJ_SM_Carpentry(Serial serial): base(serial)
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

	public class DJ_SM_Cartography : PowerScroll
	{
		private SkillName m_Skill;
		private int m_Value;
		private static SkillName[] m_Skills = new SkillName[]
		{
			SkillName.Cartography
		};
		public new SkillName[] Skills { get { return m_Skills; } }
		[Constructable]
		public DJ_SM_Cartography(): base(SkillName.Cartography, 115)
		{
		}
		[Constructable]
		public DJ_SM_Cartography(SkillName skill, int value): base(0x14F0)
		{
			Name = "Cartography";
			m_Skill = skill;
			m_Value = value;
		}

		public DJ_SM_Cartography(Serial serial): base(serial)
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

	public class DJ_SM_Chivalry : PowerScroll
	{
		private SkillName m_Skill;
		private int m_Value;
		private static SkillName[] m_Skills = new SkillName[]
		{
			SkillName.Knightship
		};
		public new SkillName[] Skills { get { return m_Skills; } }
		[Constructable]
		public DJ_SM_Chivalry(): base(SkillName.Knightship, 115)
		{
		}
		[Constructable]
		public DJ_SM_Chivalry(SkillName skill, int value): base(0x14F0)
		{
			Name = "Knightship";
			m_Skill = skill;
			m_Value = value;
		}

		public DJ_SM_Chivalry(Serial serial): base(serial)
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

	public class DJ_SM_Cooking : PowerScroll
	{
		private SkillName m_Skill;
		private int m_Value;
		private static SkillName[] m_Skills = new SkillName[]
		{
			SkillName.Cooking
		};
		public new SkillName[] Skills { get { return m_Skills; } }
		[Constructable]
		public DJ_SM_Cooking(): base(SkillName.Cooking, 115)
		{
		}
		[Constructable]
		public DJ_SM_Cooking(SkillName skill, int value): base(0x14F0)
		{
			Name = "Cooking";
			m_Skill = skill;
			m_Value = value;
		}

		public DJ_SM_Cooking(Serial serial): base(serial)
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

	public class DJ_SM_DetectHidden : PowerScroll
	{
		private SkillName m_Skill;
		private int m_Value;
		private static SkillName[] m_Skills = new SkillName[]
		{
			SkillName.Searching
		};
		public new SkillName[] Skills { get { return m_Skills; } }
		[Constructable]
		public DJ_SM_DetectHidden(): base(SkillName.Searching, 115)
		{
		}
		[Constructable]
		public DJ_SM_DetectHidden(SkillName skill, int value): base(0x14F0)
		{
			Name = "Searching";
			m_Skill = skill;
			m_Value = value;
		}

		public DJ_SM_DetectHidden(Serial serial): base(serial)
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

	public class DJ_SM_Discordance : PowerScroll
	{
		private SkillName m_Skill;
		private int m_Value;
		private static SkillName[] m_Skills = new SkillName[]
		{
			SkillName.Discordance
		};
		public new SkillName[] Skills { get { return m_Skills; } }
		[Constructable]
		public DJ_SM_Discordance(): base(SkillName.Discordance, 115)
		{
		}
		[Constructable]
		public DJ_SM_Discordance(SkillName skill, int value): base(0x14F0)
		{
			Name = "Discordance";
			m_Skill = skill;
			m_Value = value;
		}

		public DJ_SM_Discordance(Serial serial): base(serial)
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

	public class DJ_SM_EvalInt : PowerScroll
	{
		private SkillName m_Skill;
		private int m_Value;
		private static SkillName[] m_Skills = new SkillName[]
		{
			SkillName.Psychology
		};
		public new SkillName[] Skills { get { return m_Skills; } }
		[Constructable]
		public DJ_SM_EvalInt(): base(SkillName.Psychology, 115)
		{
		}
		[Constructable]
		public DJ_SM_EvalInt(SkillName skill, int value): base(0x14F0)
		{
			Name = "Psychology";
			m_Skill = skill;
			m_Value = value;
		}

		public DJ_SM_EvalInt(Serial serial): base(serial)
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

	public class DJ_SM_Fencing : PowerScroll
	{
		private SkillName m_Skill;
		private int m_Value;
		private static SkillName[] m_Skills = new SkillName[]
		{
			SkillName.Fencing
		};
		public new SkillName[] Skills { get { return m_Skills; } }
		[Constructable]
		public DJ_SM_Fencing(): base(SkillName.Fencing, 115)
		{
		}
		[Constructable]
		public DJ_SM_Fencing(SkillName skill, int value): base(0x14F0)
		{
			Name = "Fencing";
			m_Skill = skill;
			m_Value = value;
		}

		public DJ_SM_Fencing(Serial serial): base(serial)
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

	public class DJ_SM_Fishing : PowerScroll
	{
		private SkillName m_Skill;
		private int m_Value;
		private static SkillName[] m_Skills = new SkillName[]
		{
			SkillName.Seafaring
		};
		public new SkillName[] Skills { get { return m_Skills; } }
		[Constructable]
		public DJ_SM_Fishing(): base(SkillName.Seafaring, 115)
		{
		}
		[Constructable]
		public DJ_SM_Fishing(SkillName skill, int value): base(0x14F0)
		{
			Name = "Seafaring";
			m_Skill = skill;
			m_Value = value;
		}

		public DJ_SM_Fishing(Serial serial): base(serial)
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

	public class DJ_SM_Fletching : PowerScroll
	{
		private SkillName m_Skill;
		private int m_Value;
		private static SkillName[] m_Skills = new SkillName[]
		{
			SkillName.Bowcraft
		};
		public new SkillName[] Skills { get { return m_Skills; } }
		[Constructable]
		public DJ_SM_Fletching(): base(SkillName.Bowcraft, 115)
		{
		}
		[Constructable]
		public DJ_SM_Fletching(SkillName skill, int value): base(0x14F0)
		{
			Name = "Bowcrafting";
			m_Skill = skill;
			m_Value = value;
		}

		public DJ_SM_Fletching(Serial serial): base(serial)
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

	public class DJ_SM_Healing : PowerScroll
	{
		private SkillName m_Skill;
		private int m_Value;
		private static SkillName[] m_Skills = new SkillName[]
		{
			SkillName.Healing
		};
		public new SkillName[] Skills { get { return m_Skills; } }
		[Constructable]
		public DJ_SM_Healing(): base(SkillName.Healing, 115)
		{
		}
		[Constructable]
		public DJ_SM_Healing(SkillName skill, int value): base(0x14F0)
		{
			Name = "Healing";
			m_Skill = skill;
			m_Value = value;
		}

		public DJ_SM_Healing(Serial serial): base(serial)
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

	public class DJ_SM_Herding : PowerScroll
	{
		private SkillName m_Skill;
		private int m_Value;
		private static SkillName[] m_Skills = new SkillName[]
		{
			SkillName.Herding
		};
		public new SkillName[] Skills { get { return m_Skills; } }
		[Constructable]
		public DJ_SM_Herding(): base(SkillName.Herding, 115)
		{
		}
		[Constructable]
		public DJ_SM_Herding(SkillName skill, int value): base(0x14F0)
		{
			Name = "Herding";
			m_Skill = skill;
			m_Value = value;
		}

		public DJ_SM_Herding(Serial serial): base(serial)
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

	public class DJ_SM_Hiding : PowerScroll
	{
		private SkillName m_Skill;
		private int m_Value;
		private static SkillName[] m_Skills = new SkillName[]
		{
			SkillName.Hiding
		};
		public new SkillName[] Skills { get { return m_Skills; } }
		[Constructable]
		public DJ_SM_Hiding(): base(SkillName.Hiding, 115)
		{
		}
		[Constructable]
		public DJ_SM_Hiding(SkillName skill, int value): base(0x14F0)
		{
			Name = "Hiding";
			m_Skill = skill;
			m_Value = value;
		}

		public DJ_SM_Hiding(Serial serial): base(serial)
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

	public class DJ_SM_Inscribe : PowerScroll
	{
		private SkillName m_Skill;
		private int m_Value;
		private static SkillName[] m_Skills = new SkillName[]
		{
			SkillName.Inscribe
		};
		public new SkillName[] Skills { get { return m_Skills; } }
		[Constructable]
		public DJ_SM_Inscribe(): base(SkillName.Inscribe, 115)
		{
		}
		[Constructable]
		public DJ_SM_Inscribe(SkillName skill, int value): base(0x14F0)
		{
			Name = "Inscription";
			m_Skill = skill;
			m_Value = value;
		}

		public DJ_SM_Inscribe(Serial serial): base(serial)
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

	public class DJ_SM_Lockpicking : PowerScroll
	{
		private SkillName m_Skill;
		private int m_Value;
		private static SkillName[] m_Skills = new SkillName[]
		{
			SkillName.Lockpicking
		};
		public new SkillName[] Skills { get { return m_Skills; } }
		[Constructable]
		public DJ_SM_Lockpicking(): base(SkillName.Lockpicking, 115)
		{
		}
		[Constructable]
		public DJ_SM_Lockpicking(SkillName skill, int value): base(0x14F0)
		{
			Name = "Lockpicking";
			m_Skill = skill;
			m_Value = value;
		}

		public DJ_SM_Lockpicking(Serial serial): base(serial)
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

	public class DJ_SM_Lumberjacking : PowerScroll
	{
		private SkillName m_Skill;
		private int m_Value;
		private static SkillName[] m_Skills = new SkillName[]
		{
			SkillName.Lumberjacking
		};
		public new SkillName[] Skills { get { return m_Skills; } }
		[Constructable]
		public DJ_SM_Lumberjacking(): base(SkillName.Lumberjacking, 115)
		{
		}
		[Constructable]
		public DJ_SM_Lumberjacking(SkillName skill, int value): base(0x14F0)
		{
			Name = "Lumberjacking";
			m_Skill = skill;
			m_Value = value;
		}

		public DJ_SM_Lumberjacking(Serial serial): base(serial)
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

	public class DJ_SM_Macing : PowerScroll
	{
		private SkillName m_Skill;
		private int m_Value;
		private static SkillName[] m_Skills = new SkillName[]
		{
			SkillName.Bludgeoning
		};
		public new SkillName[] Skills { get { return m_Skills; } }
		[Constructable]
		public DJ_SM_Macing(): base(SkillName.Bludgeoning, 115)
		{
		}
		[Constructable]
		public DJ_SM_Macing(SkillName skill, int value): base(0x14F0)
		{
			Name = "Bludgeoning";
			m_Skill = skill;
			m_Value = value;
		}

		public DJ_SM_Macing(Serial serial): base(serial)
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

	public class DJ_SM_Magery : PowerScroll
	{
		private SkillName m_Skill;
		private int m_Value;
		private static SkillName[] m_Skills = new SkillName[]
		{
			SkillName.Magery
		};
		public new SkillName[] Skills { get { return m_Skills; } }
		[Constructable]
		public DJ_SM_Magery(): base(SkillName.Magery, 115)
		{
		}
		[Constructable]
		public DJ_SM_Magery(SkillName skill, int value): base(0x14F0)
		{
			Name = "Magery";
			m_Skill = skill;
			m_Value = value;
		}

		public DJ_SM_Magery(Serial serial): base(serial)
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

	public class DJ_SM_MagicResist : PowerScroll
	{
		private SkillName m_Skill;
		private int m_Value;
		private static SkillName[] m_Skills = new SkillName[]
		{
			SkillName.MagicResist
		};
		public new SkillName[] Skills { get { return m_Skills; } }
		[Constructable]
		public DJ_SM_MagicResist(): base(SkillName.MagicResist, 115)
		{
		}
		[Constructable]
		public DJ_SM_MagicResist(SkillName skill, int value): base(0x14F0)
		{
			Name = "Magic Resist";
			m_Skill = skill;
			m_Value = value;
		}

		public DJ_SM_MagicResist(Serial serial): base(serial)
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

	public class DJ_SM_Meditation : PowerScroll
	{
		private SkillName m_Skill;
		private int m_Value;
		private static SkillName[] m_Skills = new SkillName[]
		{
			SkillName.Meditation
		};
		public new SkillName[] Skills { get { return m_Skills; } }
		[Constructable]
		public DJ_SM_Meditation(): base(SkillName.Meditation, 115)
		{
		}
		[Constructable]
		public DJ_SM_Meditation(SkillName skill, int value): base(0x14F0)
		{
			Name = "Meditation";
			m_Skill = skill;
			m_Value = value;
		}

		public DJ_SM_Meditation(Serial serial): base(serial)
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

	public class DJ_SM_Mining : PowerScroll
	{
		private SkillName m_Skill;
		private int m_Value;
		private static SkillName[] m_Skills = new SkillName[]
		{
			SkillName.Mining
		};
		public new SkillName[] Skills { get { return m_Skills; } }
		[Constructable]
		public DJ_SM_Mining(): base(SkillName.Mining, 115)
		{
		}
		[Constructable]
		public DJ_SM_Mining(SkillName skill, int value): base(0x14F0)
		{
			Name = "Mining";
			m_Skill = skill;
			m_Value = value;
		}

		public DJ_SM_Mining(Serial serial): base(serial)
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

	public class DJ_SM_Musicianship : PowerScroll
	{
		private SkillName m_Skill;
		private int m_Value;
		private static SkillName[] m_Skills = new SkillName[]
		{
			SkillName.Musicianship
		};
		public new SkillName[] Skills { get { return m_Skills; } }
		[Constructable]
		public DJ_SM_Musicianship(): base(SkillName.Musicianship, 115)
		{
		}
		[Constructable]
		public DJ_SM_Musicianship(SkillName skill, int value): base(0x14F0)
		{
			Name = "Musicianship";
			m_Skill = skill;
			m_Value = value;
		}

		public DJ_SM_Musicianship(Serial serial): base(serial)
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

	public class DJ_SM_Necromancy : PowerScroll
	{
		private SkillName m_Skill;
		private int m_Value;
		private static SkillName[] m_Skills = new SkillName[]
		{
			SkillName.Necromancy
		};
		public new SkillName[] Skills { get { return m_Skills; } }
		[Constructable]
		public DJ_SM_Necromancy(): base(SkillName.Necromancy, 115)
		{
		}
		[Constructable]
		public DJ_SM_Necromancy(SkillName skill, int value): base(0x14F0)
		{
			Name = "Necromancy";
			m_Skill = skill;
			m_Value = value;
		}

		public DJ_SM_Necromancy(Serial serial): base(serial)
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

	public class DJ_SM_Ninjitsu : PowerScroll
	{
		private SkillName m_Skill;
		private int m_Value;
		private static SkillName[] m_Skills = new SkillName[]
		{
			SkillName.Ninjitsu
		};
		public new SkillName[] Skills { get { return m_Skills; } }
		[Constructable]
		public DJ_SM_Ninjitsu(): base(SkillName.Ninjitsu, 115)
		{
		}
		[Constructable]
		public DJ_SM_Ninjitsu(SkillName skill, int value): base(0x14F0)
		{
			Name = "Ninjitsu";
			m_Skill = skill;
			m_Value = value;
		}

		public DJ_SM_Ninjitsu(Serial serial): base(serial)
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

	public class DJ_SM_Parry : PowerScroll
	{
		private SkillName m_Skill;
		private int m_Value;
		private static SkillName[] m_Skills = new SkillName[]
		{
			SkillName.Parry
		};
		public new SkillName[] Skills { get { return m_Skills; } }
		[Constructable]
		public DJ_SM_Parry(): base(SkillName.Parry, 115)
		{
		}
		[Constructable]
		public DJ_SM_Parry(SkillName skill, int value): base(0x14F0)
		{
			Name = "Parry";
			m_Skill = skill;
			m_Value = value;
		}

		public DJ_SM_Parry(Serial serial): base(serial)
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

	public class DJ_SM_Peacemaking : PowerScroll
	{
		private SkillName m_Skill;
		private int m_Value;
		private static SkillName[] m_Skills = new SkillName[]
		{
			SkillName.Peacemaking
		};
		public new SkillName[] Skills { get { return m_Skills; } }
		[Constructable]
		public DJ_SM_Peacemaking(): base(SkillName.Peacemaking, 115)
		{
		}
		[Constructable]
		public DJ_SM_Peacemaking(SkillName skill, int value): base(0x14F0)
		{
			Name = "Peacemaking";
			m_Skill = skill;
			m_Value = value;
		}

		public DJ_SM_Peacemaking(Serial serial): base(serial)
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

	public class DJ_SM_Poisoning : PowerScroll
	{
		private SkillName m_Skill;
		private int m_Value;
		private static SkillName[] m_Skills = new SkillName[]
		{
			SkillName.Poisoning
		};
		public new SkillName[] Skills { get { return m_Skills; } }
		[Constructable]
		public DJ_SM_Poisoning(): base(SkillName.Poisoning, 115)
		{
		}
		[Constructable]
		public DJ_SM_Poisoning(SkillName skill, int value): base(0x14F0)
		{
			Name = "Poisoning";
			m_Skill = skill;
			m_Value = value;
		}

		public DJ_SM_Poisoning(Serial serial): base(serial)
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

	public class DJ_SM_Provocation : PowerScroll
	{
		private SkillName m_Skill;
		private int m_Value;
		private static SkillName[] m_Skills = new SkillName[]
		{
			SkillName.Provocation
		};
		public new SkillName[] Skills { get { return m_Skills; } }
		[Constructable]
		public DJ_SM_Provocation(): base(SkillName.Provocation, 115)
		{
		}
		[Constructable]
		public DJ_SM_Provocation(SkillName skill, int value): base(0x14F0)
		{
			Name = "Provocation";
			m_Skill = skill;
			m_Value = value;
		}

		public DJ_SM_Provocation(Serial serial): base(serial)
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

	public class DJ_SM_RemoveTrap : PowerScroll
	{
		private SkillName m_Skill;
		private int m_Value;
		private static SkillName[] m_Skills = new SkillName[]
		{
			SkillName.RemoveTrap
		};
		public new SkillName[] Skills { get { return m_Skills; } }
		[Constructable]
		public DJ_SM_RemoveTrap(): base(SkillName.RemoveTrap, 115)
		{
		}
		[Constructable]
		public DJ_SM_RemoveTrap(SkillName skill, int value): base(0x14F0)
		{
			Name = "Remove Trap";
			m_Skill = skill;
			m_Value = value;
		}

		public DJ_SM_RemoveTrap(Serial serial): base(serial)
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

	public class DJ_SM_Snooping : PowerScroll
	{
		private SkillName m_Skill;
		private int m_Value;
		private static SkillName[] m_Skills = new SkillName[]
		{
			SkillName.Snooping
		};
		public new SkillName[] Skills { get { return m_Skills; } }
		[Constructable]
		public DJ_SM_Snooping(): base(SkillName.Snooping, 115)
		{
		}
		[Constructable]
		public DJ_SM_Snooping(SkillName skill, int value): base(0x14F0)
		{
			Name = "Snooping";
			m_Skill = skill;
			m_Value = value;
		}

		public DJ_SM_Snooping(Serial serial): base(serial)
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

	public class DJ_SM_Elementalism : PowerScroll
	{
		private SkillName m_Skill;
		private int m_Value;
		private static SkillName[] m_Skills = new SkillName[]
		{
			SkillName.Elementalism
		};
		public new SkillName[] Skills { get { return m_Skills; } }
		[Constructable]
		public DJ_SM_Elementalism(): base(SkillName.Elementalism, 115)
		{
		}
		[Constructable]
		public DJ_SM_Elementalism(SkillName skill, int value): base(0x14F0)
		{
			Name = "Elementalism";
			m_Skill = skill;
			m_Value = value;
		}

		public DJ_SM_Elementalism(Serial serial): base(serial)
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

	public class DJ_SM_SpiritSpeak : PowerScroll
	{
		private SkillName m_Skill;
		private int m_Value;
		private static SkillName[] m_Skills = new SkillName[]
		{
			SkillName.Spiritualism
		};
		public new SkillName[] Skills { get { return m_Skills; } }
		[Constructable]
		public DJ_SM_SpiritSpeak(): base(SkillName.Spiritualism, 115)
		{
		}
		[Constructable]
		public DJ_SM_SpiritSpeak(SkillName skill, int value): base(0x14F0)
		{
			Name = "Spiritualism";
			m_Skill = skill;
			m_Value = value;
		}

		public DJ_SM_SpiritSpeak(Serial serial): base(serial)
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

	public class DJ_SM_Stealing : PowerScroll
	{
		private SkillName m_Skill;
		private int m_Value;
		private static SkillName[] m_Skills = new SkillName[]
		{
			SkillName.Stealing
		};
		public new SkillName[] Skills { get { return m_Skills; } }
		[Constructable]
		public DJ_SM_Stealing(): base(SkillName.Stealing, 115)
		{
		}
		[Constructable]
		public DJ_SM_Stealing(SkillName skill, int value): base(0x14F0)
		{
			Name = "Stealing";
			m_Skill = skill;
			m_Value = value;
		}

		public DJ_SM_Stealing(Serial serial): base(serial)
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

	public class DJ_SM_Stealth : PowerScroll
	{
		private SkillName m_Skill;
		private int m_Value;
		private static SkillName[] m_Skills = new SkillName[]
		{
			SkillName.Stealth
		};
		public new SkillName[] Skills { get { return m_Skills; } }
		[Constructable]
		public DJ_SM_Stealth(): base(SkillName.Stealth, 115)
		{
		}
		[Constructable]
		public DJ_SM_Stealth(SkillName skill, int value): base(0x14F0)
		{
			Name = "Stealth";
			m_Skill = skill;
			m_Value = value;
		}

		public DJ_SM_Stealth(Serial serial): base(serial)
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

	public class DJ_SM_Swords : PowerScroll
	{
		private SkillName m_Skill;
		private int m_Value;
		private static SkillName[] m_Skills = new SkillName[]
		{
			SkillName.Swords
		};
		public new SkillName[] Skills { get { return m_Skills; } }
		[Constructable]
		public DJ_SM_Swords(): base(SkillName.Swords, 115)
		{
		}
		[Constructable]
		public DJ_SM_Swords(SkillName skill, int value): base(0x14F0)
		{
			Name = "Sword Fighting";
			m_Skill = skill;
			m_Value = value;
		}

		public DJ_SM_Swords(Serial serial): base(serial)
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

	public class DJ_SM_Tactics : PowerScroll
	{
		private SkillName m_Skill;
		private int m_Value;
		private static SkillName[] m_Skills = new SkillName[]
		{
			SkillName.Tactics
		};
		public new SkillName[] Skills { get { return m_Skills; } }
		[Constructable]
		public DJ_SM_Tactics(): base(SkillName.Tactics, 115)
		{
		}
		[Constructable]
		public DJ_SM_Tactics(SkillName skill, int value): base(0x14F0)
		{
			Name = "Tactics";
			m_Skill = skill;
			m_Value = value;
		}

		public DJ_SM_Tactics(Serial serial): base(serial)
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

	public class DJ_SM_Tailoring : PowerScroll
	{
		private SkillName m_Skill;
		private int m_Value;
		private static SkillName[] m_Skills = new SkillName[]
		{
			SkillName.Tailoring
		};
		public new SkillName[] Skills { get { return m_Skills; } }
		[Constructable]
		public DJ_SM_Tailoring(): base(SkillName.Tailoring, 115)
		{
		}
		[Constructable]
		public DJ_SM_Tailoring(SkillName skill, int value): base(0x14F0)
		{
			Name = "Tailoring";
			m_Skill = skill;
			m_Value = value;
		}

		public DJ_SM_Tailoring(Serial serial): base(serial)
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

	public class DJ_SM_Tinkering : PowerScroll
	{
		private SkillName m_Skill;
		private int m_Value;
		private static SkillName[] m_Skills = new SkillName[]
		{
			SkillName.Tinkering
		};
		public new SkillName[] Skills { get { return m_Skills; } }
		[Constructable]
		public DJ_SM_Tinkering(): base(SkillName.Tinkering, 115)
		{
		}
		[Constructable]
		public DJ_SM_Tinkering(SkillName skill, int value): base(0x14F0)
		{
			Name = "Tinkering";
			m_Skill = skill;
			m_Value = value;
		}

		public DJ_SM_Tinkering(Serial serial): base(serial)
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

	public class DJ_SM_Tracking : PowerScroll
	{
		private SkillName m_Skill;
		private int m_Value;
		private static SkillName[] m_Skills = new SkillName[]
		{
			SkillName.Tracking
		};
		public new SkillName[] Skills { get { return m_Skills; } }
		[Constructable]
		public DJ_SM_Tracking(): base(SkillName.Tracking, 115)
		{
		}
		[Constructable]
		public DJ_SM_Tracking(SkillName skill, int value): base(0x14F0)
		{
			Name = "Tracking";
			m_Skill = skill;
			m_Value = value;
		}

		public DJ_SM_Tracking(Serial serial): base(serial)
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

	public class DJ_SM_Veterinary : PowerScroll
	{
		private SkillName m_Skill;
		private int m_Value;
		private static SkillName[] m_Skills = new SkillName[]
		{
			SkillName.Veterinary
		};
		public new SkillName[] Skills { get { return m_Skills; } }
		[Constructable]
		public DJ_SM_Veterinary(): base(SkillName.Veterinary, 115)
		{
		}
		[Constructable]
		public DJ_SM_Veterinary(SkillName skill, int value): base(0x14F0)
		{
			Name = "Veterinary";
			m_Skill = skill;
			m_Value = value;
		}

		public DJ_SM_Veterinary(Serial serial): base(serial)
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

	public class DJ_SM_Wrestling : PowerScroll
	{
		private SkillName m_Skill;
		private int m_Value;
		private static SkillName[] m_Skills = new SkillName[]
		{
			SkillName.FistFighting
		};
		public new SkillName[] Skills { get { return m_Skills; } }
		[Constructable]
		public DJ_SM_Wrestling(): base(SkillName.FistFighting, 115)
		{
		}
		[Constructable]
		public DJ_SM_Wrestling(SkillName skill, int value): base(0x14F0)
		{
			Name = "Fist Fighting";
			m_Skill = skill;
			m_Value = value;
		}

		public DJ_SM_Wrestling(Serial serial): base(serial)
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
	public class DJ_SM_Anatomy : PowerScroll
	{
		private SkillName m_Skill;
		private int m_Value;
		private static SkillName[] m_Skills = new SkillName[]
		{
			SkillName.Anatomy
		};
		public new SkillName[] Skills { get { return m_Skills; } }
		[Constructable]
		public DJ_SM_Anatomy(): base(SkillName.Anatomy, 115)
		{
		}
		[Constructable]
		public DJ_SM_Anatomy(SkillName skill, int value): base(0x14F0)
		{
			Name = "Anatomy";
			m_Skill = skill;
			m_Value = value;
		}

		public DJ_SM_Anatomy(Serial serial): base(serial)
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
	public class DJ_SM_Focus : PowerScroll
	{
		private SkillName m_Skill;
		private int m_Value;
		private static SkillName[] m_Skills = new SkillName[]
		{
			SkillName.Focus
		};
		public new SkillName[] Skills { get { return m_Skills; } }
		[Constructable]
		public DJ_SM_Focus(): base(SkillName.Focus, 115)
		{
		}
		[Constructable]
		public DJ_SM_Focus(SkillName skill, int value): base(0x14F0)
		{
			Name = "Focus";
			m_Skill = skill;
			m_Value = value;
		}

		public DJ_SM_Focus(Serial serial): base(serial)
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