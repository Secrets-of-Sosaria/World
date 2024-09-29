using System;
using Server;
using Server.Engines.Craft;
using Server.Gumps;
using Server.Network;

namespace Server.Items
{
	public class DJ_SP_Alchemy : PowerScroll
	{
		private SkillName m_Skill;
		private int m_Value;
		private static SkillName[] m_Skills = new SkillName[]
		{
			SkillName.Alchemy
		};
		public new SkillName[] Skills { get { return m_Skills; } }
		[Constructable]
		public DJ_SP_Alchemy(): base(SkillName.Alchemy, 125)
		{
		}
		[Constructable]
		public DJ_SP_Alchemy(SkillName skill, int value): base(0x14F0)
		{
			Name = "Alchemy";
			m_Skill = skill;
			m_Value = value;
		}

		public DJ_SP_Alchemy(Serial serial): base(serial)
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

	public class DJ_SP_AnimalLore : PowerScroll
	{
		private SkillName m_Skill;
		private int m_Value;
		private static SkillName[] m_Skills = new SkillName[]
		{
			SkillName.Druidism
		};
		public new SkillName[] Skills { get { return m_Skills; } }
		[Constructable]
		public DJ_SP_AnimalLore(): base(SkillName.Druidism, 125)
		{
		}
		[Constructable]
		public DJ_SP_AnimalLore(SkillName skill, int value): base(0x14F0)
		{
			Name = "Druidism";
			m_Skill = skill;
			m_Value = value;
		}

		public DJ_SP_AnimalLore(Serial serial): base(serial)
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

	public class DJ_SP_AnimalTaming : PowerScroll
	{
		private SkillName m_Skill;
		private int m_Value;
		private static SkillName[] m_Skills = new SkillName[]
		{
			SkillName.Taming
		};
		public new SkillName[] Skills { get { return m_Skills; } }
		[Constructable]
		public DJ_SP_AnimalTaming(): base(SkillName.Taming, 125)
		{
		}
		[Constructable]
		public DJ_SP_AnimalTaming(SkillName skill, int value): base(0x14F0)
		{
			Name = "Taming";
			m_Skill = skill;
			m_Value = value;
		}

		public DJ_SP_AnimalTaming(Serial serial): base(serial)
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

	public class DJ_SP_Archery : PowerScroll
	{
		private SkillName m_Skill;
		private int m_Value;
		private static SkillName[] m_Skills = new SkillName[]
		{
			SkillName.Marksmanship
		};
		public new SkillName[] Skills { get { return m_Skills; } }
		[Constructable]
		public DJ_SP_Archery(): base(SkillName.Marksmanship, 125)
		{
		}
		[Constructable]
		public DJ_SP_Archery(SkillName skill, int value): base(0x14F0)
		{
			Name = "Marksmanship";
			m_Skill = skill;
			m_Value = value;
		}

		public DJ_SP_Archery(Serial serial): base(serial)
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

	public class DJ_SP_ArmsLore : PowerScroll
	{
		private SkillName m_Skill;
		private int m_Value;
		private static SkillName[] m_Skills = new SkillName[]
		{
			SkillName.ArmsLore
		};
		public new SkillName[] Skills { get { return m_Skills; } }
		[Constructable]
		public DJ_SP_ArmsLore(): base(SkillName.ArmsLore, 125)
		{
		}
		[Constructable]
		public DJ_SP_ArmsLore(SkillName skill, int value): base(0x14F0)
		{
			Name = "Arms Lore";
			m_Skill = skill;
			m_Value = value;
		}

		public DJ_SP_ArmsLore(Serial serial): base(serial)
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

	public class DJ_SP_Blacksmith : PowerScroll
	{
		private SkillName m_Skill;
		private int m_Value;
		private static SkillName[] m_Skills = new SkillName[]
		{
			SkillName.Blacksmith
		};
		public new SkillName[] Skills { get { return m_Skills; } }
		[Constructable]
		public DJ_SP_Blacksmith(): base(SkillName.Blacksmith, 125)
		{
		}
		[Constructable]
		public DJ_SP_Blacksmith(SkillName skill, int value): base(0x14F0)
		{
			Name = "Blacksmithing";
			m_Skill = skill;
			m_Value = value;
		}

		public DJ_SP_Blacksmith(Serial serial): base(serial)
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

	public class DJ_SP_Bushido : PowerScroll
	{
		private SkillName m_Skill;
		private int m_Value;
		private static SkillName[] m_Skills = new SkillName[]
		{
			SkillName.Bushido
		};
		public new SkillName[] Skills { get { return m_Skills; } }
		[Constructable]
		public DJ_SP_Bushido(): base(SkillName.Bushido, 125)
		{
		}
		[Constructable]
		public DJ_SP_Bushido(SkillName skill, int value): base(0x14F0)
		{
			Name = "Bushido";
			m_Skill = skill;
			m_Value = value;
		}

		public DJ_SP_Bushido(Serial serial): base(serial)
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

	public class DJ_SP_Carpentry : PowerScroll
	{
		private SkillName m_Skill;
		private int m_Value;
		private static SkillName[] m_Skills = new SkillName[]
		{
			SkillName.Carpentry
		};
		public new SkillName[] Skills { get { return m_Skills; } }
		[Constructable]
		public DJ_SP_Carpentry(): base(SkillName.Carpentry, 125)
		{
		}
		[Constructable]
		public DJ_SP_Carpentry(SkillName skill, int value): base(0x14F0)
		{
			Name = "Carpentry";
			m_Skill = skill;
			m_Value = value;
		}

		public DJ_SP_Carpentry(Serial serial): base(serial)
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

	public class DJ_SP_Cartography : PowerScroll
	{
		private SkillName m_Skill;
		private int m_Value;
		private static SkillName[] m_Skills = new SkillName[]
		{
			SkillName.Cartography
		};
		public new SkillName[] Skills { get { return m_Skills; } }
		[Constructable]
		public DJ_SP_Cartography(): base(SkillName.Cartography, 125)
		{
		}
		[Constructable]
		public DJ_SP_Cartography(SkillName skill, int value): base(0x14F0)
		{
			Name = "Cartography";
			m_Skill = skill;
			m_Value = value;
		}

		public DJ_SP_Cartography(Serial serial): base(serial)
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

	public class DJ_SP_Chivalry : PowerScroll
	{
		private SkillName m_Skill;
		private int m_Value;
		private static SkillName[] m_Skills = new SkillName[]
		{
			SkillName.Knightship
		};
		public new SkillName[] Skills { get { return m_Skills; } }
		[Constructable]
		public DJ_SP_Chivalry(): base(SkillName.Knightship, 125)
		{
		}
		[Constructable]
		public DJ_SP_Chivalry(SkillName skill, int value): base(0x14F0)
		{
			Name = "Knightship";
			m_Skill = skill;
			m_Value = value;
		}

		public DJ_SP_Chivalry(Serial serial): base(serial)
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

	public class DJ_SP_Cooking : PowerScroll
	{
		private SkillName m_Skill;
		private int m_Value;
		private static SkillName[] m_Skills = new SkillName[]
		{
			SkillName.Cooking
		};
		public new SkillName[] Skills { get { return m_Skills; } }
		[Constructable]
		public DJ_SP_Cooking(): base(SkillName.Cooking, 125)
		{
		}
		[Constructable]
		public DJ_SP_Cooking(SkillName skill, int value): base(0x14F0)
		{
			Name = "Cooking";
			m_Skill = skill;
			m_Value = value;
		}

		public DJ_SP_Cooking(Serial serial): base(serial)
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

	public class DJ_SP_DetectHidden : PowerScroll
	{
		private SkillName m_Skill;
		private int m_Value;
		private static SkillName[] m_Skills = new SkillName[]
		{
			SkillName.Searching
		};
		public new SkillName[] Skills { get { return m_Skills; } }
		[Constructable]
		public DJ_SP_DetectHidden(): base(SkillName.Searching, 125)
		{
		}
		[Constructable]
		public DJ_SP_DetectHidden(SkillName skill, int value): base(0x14F0)
		{
			Name = "Searching";
			m_Skill = skill;
			m_Value = value;
		}

		public DJ_SP_DetectHidden(Serial serial): base(serial)
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

	public class DJ_SP_Discordance : PowerScroll
	{
		private SkillName m_Skill;
		private int m_Value;
		private static SkillName[] m_Skills = new SkillName[]
		{
			SkillName.Discordance
		};
		public new SkillName[] Skills { get { return m_Skills; } }
		[Constructable]
		public DJ_SP_Discordance(): base(SkillName.Discordance, 125)
		{
		}
		[Constructable]
		public DJ_SP_Discordance(SkillName skill, int value): base(0x14F0)
		{
			Name = "Discordance";
			m_Skill = skill;
			m_Value = value;
		}

		public DJ_SP_Discordance(Serial serial): base(serial)
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

	public class DJ_SP_EvalInt : PowerScroll
	{
		private SkillName m_Skill;
		private int m_Value;
		private static SkillName[] m_Skills = new SkillName[]
		{
			SkillName.Psychology
		};
		public new SkillName[] Skills { get { return m_Skills; } }
		[Constructable]
		public DJ_SP_EvalInt(): base(SkillName.Psychology, 125)
		{
		}
		[Constructable]
		public DJ_SP_EvalInt(SkillName skill, int value): base(0x14F0)
		{
			Name = "Psychology";
			m_Skill = skill;
			m_Value = value;
		}

		public DJ_SP_EvalInt(Serial serial): base(serial)
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

	public class DJ_SP_Fencing : PowerScroll
	{
		private SkillName m_Skill;
		private int m_Value;
		private static SkillName[] m_Skills = new SkillName[]
		{
			SkillName.Fencing
		};
		public new SkillName[] Skills { get { return m_Skills; } }
		[Constructable]
		public DJ_SP_Fencing(): base(SkillName.Fencing, 125)
		{
		}
		[Constructable]
		public DJ_SP_Fencing(SkillName skill, int value): base(0x14F0)
		{
			Name = "Fencing";
			m_Skill = skill;
			m_Value = value;
		}

		public DJ_SP_Fencing(Serial serial): base(serial)
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

	public class DJ_SP_Fishing : PowerScroll
	{
		private SkillName m_Skill;
		private int m_Value;
		private static SkillName[] m_Skills = new SkillName[]
		{
			SkillName.Seafaring
		};
		public new SkillName[] Skills { get { return m_Skills; } }
		[Constructable]
		public DJ_SP_Fishing(): base(SkillName.Seafaring, 125)
		{
		}
		[Constructable]
		public DJ_SP_Fishing(SkillName skill, int value): base(0x14F0)
		{
			Name = "Seafaring";
			m_Skill = skill;
			m_Value = value;
		}

		public DJ_SP_Fishing(Serial serial): base(serial)
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

	public class DJ_SP_Fletching : PowerScroll
	{
		private SkillName m_Skill;
		private int m_Value;
		private static SkillName[] m_Skills = new SkillName[]
		{
			SkillName.Bowcraft
		};
		public new SkillName[] Skills { get { return m_Skills; } }
		[Constructable]
		public DJ_SP_Fletching(): base(SkillName.Bowcraft, 125)
		{
		}
		[Constructable]
		public DJ_SP_Fletching(SkillName skill, int value): base(0x14F0)
		{
			Name = "Bowcrafting";
			m_Skill = skill;
			m_Value = value;
		}

		public DJ_SP_Fletching(Serial serial): base(serial)
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

	public class DJ_SP_Healing : PowerScroll
	{
		private SkillName m_Skill;
		private int m_Value;
		private static SkillName[] m_Skills = new SkillName[]
		{
			SkillName.Healing
		};
		public new SkillName[] Skills { get { return m_Skills; } }
		[Constructable]
		public DJ_SP_Healing(): base(SkillName.Healing, 125)
		{
		}
		[Constructable]
		public DJ_SP_Healing(SkillName skill, int value): base(0x14F0)
		{
			Name = "Healing";
			m_Skill = skill;
			m_Value = value;
		}

		public DJ_SP_Healing(Serial serial): base(serial)
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

	public class DJ_SP_Herding : PowerScroll
	{
		private SkillName m_Skill;
		private int m_Value;
		private static SkillName[] m_Skills = new SkillName[]
		{
			SkillName.Herding
		};
		public new SkillName[] Skills { get { return m_Skills; } }
		[Constructable]
		public DJ_SP_Herding(): base(SkillName.Herding, 125)
		{
		}
		[Constructable]
		public DJ_SP_Herding(SkillName skill, int value): base(0x14F0)
		{
			Name = "Herding";
			m_Skill = skill;
			m_Value = value;
		}

		public DJ_SP_Herding(Serial serial): base(serial)
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

	public class DJ_SP_Hiding : PowerScroll
	{
		private SkillName m_Skill;
		private int m_Value;
		private static SkillName[] m_Skills = new SkillName[]
		{
			SkillName.Hiding
		};
		public new SkillName[] Skills { get { return m_Skills; } }
		[Constructable]
		public DJ_SP_Hiding(): base(SkillName.Hiding, 125)
		{
		}
		[Constructable]
		public DJ_SP_Hiding(SkillName skill, int value): base(0x14F0)
		{
			Name = "Hiding";
			m_Skill = skill;
			m_Value = value;
		}

		public DJ_SP_Hiding(Serial serial): base(serial)
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

	public class DJ_SP_Inscribe : PowerScroll
	{
		private SkillName m_Skill;
		private int m_Value;
		private static SkillName[] m_Skills = new SkillName[]
		{
			SkillName.Inscribe
		};
		public new SkillName[] Skills { get { return m_Skills; } }
		[Constructable]
		public DJ_SP_Inscribe(): base(SkillName.Inscribe, 125)
		{
		}
		[Constructable]
		public DJ_SP_Inscribe(SkillName skill, int value): base(0x14F0)
		{
			Name = "Inscription";
			m_Skill = skill;
			m_Value = value;
		}

		public DJ_SP_Inscribe(Serial serial): base(serial)
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

	public class DJ_SP_Lockpicking : PowerScroll
	{
		private SkillName m_Skill;
		private int m_Value;
		private static SkillName[] m_Skills = new SkillName[]
		{
			SkillName.Lockpicking
		};
		public new SkillName[] Skills { get { return m_Skills; } }
		[Constructable]
		public DJ_SP_Lockpicking(): base(SkillName.Lockpicking, 125)
		{
		}
		[Constructable]
		public DJ_SP_Lockpicking(SkillName skill, int value): base(0x14F0)
		{
			Name = "Lockpicking";
			m_Skill = skill;
			m_Value = value;
		}

		public DJ_SP_Lockpicking(Serial serial): base(serial)
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

	public class DJ_SP_Lumberjacking : PowerScroll
	{
		private SkillName m_Skill;
		private int m_Value;
		private static SkillName[] m_Skills = new SkillName[]
		{
			SkillName.Lumberjacking
		};
		public new SkillName[] Skills { get { return m_Skills; } }
		[Constructable]
		public DJ_SP_Lumberjacking(): base(SkillName.Lumberjacking, 125)
		{
		}
		[Constructable]
		public DJ_SP_Lumberjacking(SkillName skill, int value): base(0x14F0)
		{
			Name = "Lumberjacking";
			m_Skill = skill;
			m_Value = value;
		}

		public DJ_SP_Lumberjacking(Serial serial): base(serial)
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

	public class DJ_SP_Macing : PowerScroll
	{
		private SkillName m_Skill;
		private int m_Value;
		private static SkillName[] m_Skills = new SkillName[]
		{
			SkillName.Bludgeoning
		};
		public new SkillName[] Skills { get { return m_Skills; } }
		[Constructable]
		public DJ_SP_Macing(): base(SkillName.Bludgeoning, 125)
		{
		}
		[Constructable]
		public DJ_SP_Macing(SkillName skill, int value): base(0x14F0)
		{
			Name = "Bludgeoning";
			m_Skill = skill;
			m_Value = value;
		}

		public DJ_SP_Macing(Serial serial): base(serial)
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

	public class DJ_SP_Magery : PowerScroll
	{
		private SkillName m_Skill;
		private int m_Value;
		private static SkillName[] m_Skills = new SkillName[]
		{
			SkillName.Magery
		};
		public new SkillName[] Skills { get { return m_Skills; } }
		[Constructable]
		public DJ_SP_Magery(): base(SkillName.Magery, 125)
		{
		}
		[Constructable]
		public DJ_SP_Magery(SkillName skill, int value): base(0x14F0)
		{
			Name = "Magery";
			m_Skill = skill;
			m_Value = value;
		}

		public DJ_SP_Magery(Serial serial): base(serial)
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

	public class DJ_SP_MagicResist : PowerScroll
	{
		private SkillName m_Skill;
		private int m_Value;
		private static SkillName[] m_Skills = new SkillName[]
		{
			SkillName.MagicResist
		};
		public new SkillName[] Skills { get { return m_Skills; } }
		[Constructable]
		public DJ_SP_MagicResist(): base(SkillName.MagicResist, 125)
		{
		}
		[Constructable]
		public DJ_SP_MagicResist(SkillName skill, int value): base(0x14F0)
		{
			Name = "Magic Resist";
			m_Skill = skill;
			m_Value = value;
		}

		public DJ_SP_MagicResist(Serial serial): base(serial)
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

	public class DJ_SP_Meditation : PowerScroll
	{
		private SkillName m_Skill;
		private int m_Value;
		private static SkillName[] m_Skills = new SkillName[]
		{
			SkillName.Meditation
		};
		public new SkillName[] Skills { get { return m_Skills; } }
		[Constructable]
		public DJ_SP_Meditation(): base(SkillName.Meditation, 125)
		{
		}
		[Constructable]
		public DJ_SP_Meditation(SkillName skill, int value): base(0x14F0)
		{
			Name = "Meditation";
			m_Skill = skill;
			m_Value = value;
		}

		public DJ_SP_Meditation(Serial serial): base(serial)
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

	public class DJ_SP_Mining : PowerScroll
	{
		private SkillName m_Skill;
		private int m_Value;
		private static SkillName[] m_Skills = new SkillName[]
		{
			SkillName.Mining
		};
		public new SkillName[] Skills { get { return m_Skills; } }
		[Constructable]
		public DJ_SP_Mining(): base(SkillName.Mining, 125)
		{
		}
		[Constructable]
		public DJ_SP_Mining(SkillName skill, int value): base(0x14F0)
		{
			Name = "Mining";
			m_Skill = skill;
			m_Value = value;
		}

		public DJ_SP_Mining(Serial serial): base(serial)
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

	public class DJ_SP_Musicianship : PowerScroll
	{
		private SkillName m_Skill;
		private int m_Value;
		private static SkillName[] m_Skills = new SkillName[]
		{
			SkillName.Musicianship
		};
		public new SkillName[] Skills { get { return m_Skills; } }
		[Constructable]
		public DJ_SP_Musicianship(): base(SkillName.Musicianship, 125)
		{
		}
		[Constructable]
		public DJ_SP_Musicianship(SkillName skill, int value): base(0x14F0)
		{
			Name = "Musicianship";
			m_Skill = skill;
			m_Value = value;
		}

		public DJ_SP_Musicianship(Serial serial): base(serial)
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

	public class DJ_SP_Necromancy : PowerScroll
	{
		private SkillName m_Skill;
		private int m_Value;
		private static SkillName[] m_Skills = new SkillName[]
		{
			SkillName.Necromancy
		};
		public new SkillName[] Skills { get { return m_Skills; } }
		[Constructable]
		public DJ_SP_Necromancy(): base(SkillName.Necromancy, 125)
		{
		}
		[Constructable]
		public DJ_SP_Necromancy(SkillName skill, int value): base(0x14F0)
		{
			Name = "Necromancy";
			m_Skill = skill;
			m_Value = value;
		}

		public DJ_SP_Necromancy(Serial serial): base(serial)
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

	public class DJ_SP_Ninjitsu : PowerScroll
	{
		private SkillName m_Skill;
		private int m_Value;
		private static SkillName[] m_Skills = new SkillName[]
		{
			SkillName.Ninjitsu
		};
		public new SkillName[] Skills { get { return m_Skills; } }
		[Constructable]
		public DJ_SP_Ninjitsu(): base(SkillName.Ninjitsu, 125)
		{
		}
		[Constructable]
		public DJ_SP_Ninjitsu(SkillName skill, int value): base(0x14F0)
		{
			Name = "Ninjitsu";
			m_Skill = skill;
			m_Value = value;
		}

		public DJ_SP_Ninjitsu(Serial serial): base(serial)
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

	public class DJ_SP_Parry : PowerScroll
	{
		private SkillName m_Skill;
		private int m_Value;
		private static SkillName[] m_Skills = new SkillName[]
		{
			SkillName.Parry
		};
		public new SkillName[] Skills { get { return m_Skills; } }
		[Constructable]
		public DJ_SP_Parry(): base(SkillName.Parry, 125)
		{
		}
		[Constructable]
		public DJ_SP_Parry(SkillName skill, int value): base(0x14F0)
		{
			Name = "Parry";
			m_Skill = skill;
			m_Value = value;
		}

		public DJ_SP_Parry(Serial serial): base(serial)
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

	public class DJ_SP_Peacemaking : PowerScroll
	{
		private SkillName m_Skill;
		private int m_Value;
		private static SkillName[] m_Skills = new SkillName[]
		{
			SkillName.Peacemaking
		};
		public new SkillName[] Skills { get { return m_Skills; } }
		[Constructable]
		public DJ_SP_Peacemaking(): base(SkillName.Peacemaking, 125)
		{
		}
		[Constructable]
		public DJ_SP_Peacemaking(SkillName skill, int value): base(0x14F0)
		{
			Name = "Peacemaking";
			m_Skill = skill;
			m_Value = value;
		}

		public DJ_SP_Peacemaking(Serial serial): base(serial)
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

	public class DJ_SP_Poisoning : PowerScroll
	{
		private SkillName m_Skill;
		private int m_Value;
		private static SkillName[] m_Skills = new SkillName[]
		{
			SkillName.Poisoning
		};
		public new SkillName[] Skills { get { return m_Skills; } }
		[Constructable]
		public DJ_SP_Poisoning(): base(SkillName.Poisoning, 125)
		{
		}
		[Constructable]
		public DJ_SP_Poisoning(SkillName skill, int value): base(0x14F0)
		{
			Name = "Poisoning";
			m_Skill = skill;
			m_Value = value;
		}

		public DJ_SP_Poisoning(Serial serial): base(serial)
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

	public class DJ_SP_Provocation : PowerScroll
	{
		private SkillName m_Skill;
		private int m_Value;
		private static SkillName[] m_Skills = new SkillName[]
		{
			SkillName.Provocation
		};
		public new SkillName[] Skills { get { return m_Skills; } }
		[Constructable]
		public DJ_SP_Provocation(): base(SkillName.Provocation, 125)
		{
		}
		[Constructable]
		public DJ_SP_Provocation(SkillName skill, int value): base(0x14F0)
		{
			Name = "Provocation";
			m_Skill = skill;
			m_Value = value;
		}

		public DJ_SP_Provocation(Serial serial): base(serial)
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

	public class DJ_SP_RemoveTrap : PowerScroll
	{
		private SkillName m_Skill;
		private int m_Value;
		private static SkillName[] m_Skills = new SkillName[]
		{
			SkillName.RemoveTrap
		};
		public new SkillName[] Skills { get { return m_Skills; } }
		[Constructable]
		public DJ_SP_RemoveTrap(): base(SkillName.RemoveTrap, 125)
		{
		}
		[Constructable]
		public DJ_SP_RemoveTrap(SkillName skill, int value): base(0x14F0)
		{
			Name = "Remove Trap";
			m_Skill = skill;
			m_Value = value;
		}

		public DJ_SP_RemoveTrap(Serial serial): base(serial)
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

	public class DJ_SP_Snooping : PowerScroll
	{
		private SkillName m_Skill;
		private int m_Value;
		private static SkillName[] m_Skills = new SkillName[]
		{
			SkillName.Snooping
		};
		public new SkillName[] Skills { get { return m_Skills; } }
		[Constructable]
		public DJ_SP_Snooping(): base(SkillName.Snooping, 125)
		{
		}
		[Constructable]
		public DJ_SP_Snooping(SkillName skill, int value): base(0x14F0)
		{
			Name = "Snooping";
			m_Skill = skill;
			m_Value = value;
		}

		public DJ_SP_Snooping(Serial serial): base(serial)
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

	public class DJ_SP_Elementalism : PowerScroll
	{
		private SkillName m_Skill;
		private int m_Value;
		private static SkillName[] m_Skills = new SkillName[]
		{
			SkillName.Elementalism
		};
		public new SkillName[] Skills { get { return m_Skills; } }
		[Constructable]
		public DJ_SP_Elementalism(): base(SkillName.Elementalism, 125)
		{
		}
		[Constructable]
		public DJ_SP_Elementalism(SkillName skill, int value): base(0x14F0)
		{
			Name = "Elementalism";
			m_Skill = skill;
			m_Value = value;
		}

		public DJ_SP_Elementalism(Serial serial): base(serial)
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

	public class DJ_SP_SpiritSpeak : PowerScroll
	{
		private SkillName m_Skill;
		private int m_Value;
		private static SkillName[] m_Skills = new SkillName[]
		{
			SkillName.Spiritualism
		};
		public new SkillName[] Skills { get { return m_Skills; } }
		[Constructable]
		public DJ_SP_SpiritSpeak(): base(SkillName.Spiritualism, 125)
		{
		}
		[Constructable]
		public DJ_SP_SpiritSpeak(SkillName skill, int value): base(0x14F0)
		{
			Name = "Spiritualism";
			m_Skill = skill;
			m_Value = value;
		}

		public DJ_SP_SpiritSpeak(Serial serial): base(serial)
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

	public class DJ_SP_Stealing : PowerScroll
	{
		private SkillName m_Skill;
		private int m_Value;
		private static SkillName[] m_Skills = new SkillName[]
		{
			SkillName.Stealing
		};
		public new SkillName[] Skills { get { return m_Skills; } }
		[Constructable]
		public DJ_SP_Stealing(): base(SkillName.Stealing, 125)
		{
		}
		[Constructable]
		public DJ_SP_Stealing(SkillName skill, int value): base(0x14F0)
		{
			Name = "Stealing";
			m_Skill = skill;
			m_Value = value;
		}

		public DJ_SP_Stealing(Serial serial): base(serial)
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

	public class DJ_SP_Stealth : PowerScroll
	{
		private SkillName m_Skill;
		private int m_Value;
		private static SkillName[] m_Skills = new SkillName[]
		{
			SkillName.Stealth
		};
		public new SkillName[] Skills { get { return m_Skills; } }
		[Constructable]
		public DJ_SP_Stealth(): base(SkillName.Stealth, 125)
		{
		}
		[Constructable]
		public DJ_SP_Stealth(SkillName skill, int value): base(0x14F0)
		{
			Name = "Stealth";
			m_Skill = skill;
			m_Value = value;
		}

		public DJ_SP_Stealth(Serial serial): base(serial)
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

	public class DJ_SP_Swords : PowerScroll
	{
		private SkillName m_Skill;
		private int m_Value;
		private static SkillName[] m_Skills = new SkillName[]
		{
			SkillName.Swords
		};
		public new SkillName[] Skills { get { return m_Skills; } }
		[Constructable]
		public DJ_SP_Swords(): base(SkillName.Swords, 125)
		{
		}
		[Constructable]
		public DJ_SP_Swords(SkillName skill, int value): base(0x14F0)
		{
			Name = "Sword Fighting";
			m_Skill = skill;
			m_Value = value;
		}

		public DJ_SP_Swords(Serial serial): base(serial)
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

	public class DJ_SP_Tactics : PowerScroll
	{
		private SkillName m_Skill;
		private int m_Value;
		private static SkillName[] m_Skills = new SkillName[]
		{
			SkillName.Tactics
		};
		public new SkillName[] Skills { get { return m_Skills; } }
		[Constructable]
		public DJ_SP_Tactics(): base(SkillName.Tactics, 125)
		{
		}
		[Constructable]
		public DJ_SP_Tactics(SkillName skill, int value): base(0x14F0)
		{
			Name = "Tactics";
			m_Skill = skill;
			m_Value = value;
		}

		public DJ_SP_Tactics(Serial serial): base(serial)
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

	public class DJ_SP_Tailoring : PowerScroll
	{
		private SkillName m_Skill;
		private int m_Value;
		private static SkillName[] m_Skills = new SkillName[]
		{
			SkillName.Tailoring
		};
		public new SkillName[] Skills { get { return m_Skills; } }
		[Constructable]
		public DJ_SP_Tailoring(): base(SkillName.Tailoring, 125)
		{
		}
		[Constructable]
		public DJ_SP_Tailoring(SkillName skill, int value): base(0x14F0)
		{
			Name = "Tailoring";
			m_Skill = skill;
			m_Value = value;
		}

		public DJ_SP_Tailoring(Serial serial): base(serial)
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

	public class DJ_SP_Tinkering : PowerScroll
	{
		private SkillName m_Skill;
		private int m_Value;
		private static SkillName[] m_Skills = new SkillName[]
		{
			SkillName.Tinkering
		};
		public new SkillName[] Skills { get { return m_Skills; } }
		[Constructable]
		public DJ_SP_Tinkering(): base(SkillName.Tinkering, 125)
		{
		}
		[Constructable]
		public DJ_SP_Tinkering(SkillName skill, int value): base(0x14F0)
		{
			Name = "Tinkering";
			m_Skill = skill;
			m_Value = value;
		}

		public DJ_SP_Tinkering(Serial serial): base(serial)
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

	public class DJ_SP_Tracking : PowerScroll
	{
		private SkillName m_Skill;
		private int m_Value;
		private static SkillName[] m_Skills = new SkillName[]
		{
			SkillName.Tracking
		};
		public new SkillName[] Skills { get { return m_Skills; } }
		[Constructable]
		public DJ_SP_Tracking(): base(SkillName.Tracking, 125)
		{
		}
		[Constructable]
		public DJ_SP_Tracking(SkillName skill, int value): base(0x14F0)
		{
			Name = "Tracking";
			m_Skill = skill;
			m_Value = value;
		}

		public DJ_SP_Tracking(Serial serial): base(serial)
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

	public class DJ_SP_Veterinary : PowerScroll
	{
		private SkillName m_Skill;
		private int m_Value;
		private static SkillName[] m_Skills = new SkillName[]
		{
			SkillName.Veterinary
		};
		public new SkillName[] Skills { get { return m_Skills; } }
		[Constructable]
		public DJ_SP_Veterinary(): base(SkillName.Veterinary, 125)
		{
		}
		[Constructable]
		public DJ_SP_Veterinary(SkillName skill, int value): base(0x14F0)
		{
			Name = "Veterinary";
			m_Skill = skill;
			m_Value = value;
		}

		public DJ_SP_Veterinary(Serial serial): base(serial)
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

	public class DJ_SP_Wrestling : PowerScroll
	{
		private SkillName m_Skill;
		private int m_Value;
		private static SkillName[] m_Skills = new SkillName[]
		{
			SkillName.FistFighting
		};
		public new SkillName[] Skills { get { return m_Skills; } }
		[Constructable]
		public DJ_SP_Wrestling(): base(SkillName.FistFighting, 125)
		{
		}
		[Constructable]
		public DJ_SP_Wrestling(SkillName skill, int value): base(0x14F0)
		{
			Name = "Fist Fighting";
			m_Skill = skill;
			m_Value = value;
		}

		public DJ_SP_Wrestling(Serial serial): base(serial)
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

	public class DJ_SP_Anatomy : PowerScroll
	{
		private SkillName m_Skill;
		private int m_Value;
		private static SkillName[] m_Skills = new SkillName[]
		{
			SkillName.Anatomy
		};
		public new SkillName[] Skills { get { return m_Skills; } }
		[Constructable]
		public DJ_SP_Anatomy(): base(SkillName.Anatomy, 125)
		{
		}
		[Constructable]
		public DJ_SP_Anatomy(SkillName skill, int value): base(0x14F0)
		{
			Name = "Anatomy";
			m_Skill = skill;
			m_Value = value;
		}

		public DJ_SP_Anatomy(Serial serial): base(serial)
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

	public class DJ_SP_Focus : PowerScroll
	{
		private SkillName m_Skill;
		private int m_Value;
		private static SkillName[] m_Skills = new SkillName[]
		{
			SkillName.Focus
		};
		public new SkillName[] Skills { get { return m_Skills; } }
		[Constructable]
		public DJ_SP_Focus(): base(SkillName.Focus, 125)
		{
		}
		[Constructable]
		public DJ_SP_Focus(SkillName skill, int value): base(0x14F0)
		{
			Name = "Focus";
			m_Skill = skill;
			m_Value = value;
		}

		public DJ_SP_Focus(Serial serial): base(serial)
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