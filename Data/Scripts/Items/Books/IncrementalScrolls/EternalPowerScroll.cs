using System;
using Server;
using Server.Items;
using Server.Mobiles;
using Server.Network;
using Server.Gumps;

namespace Server.Items
{
    public class EternalPowerScroll : Item
    {
        [Constructable]
        public EternalPowerScroll() : base(0x14F0)
        {
            Weight = 1.0;
            Hue = 518;
            Name = "Eternal Power Scroll";
        }

        public EternalPowerScroll(Serial serial) : base(serial) { }

        public override void OnDoubleClick(Mobile from)
        {
            if (!IsChildOf(from.Backpack))
            {
                from.SendMessage("This scroll must be in your backpack to use it.");
                return;
            }

            from.SendGump(new SkillSelectGump(from, this, 0));
        }

        private class SkillSelectGump : Gump
        {
            private const int SkillsPerPage = 10;

            private readonly Mobile m_User;
            private readonly EternalPowerScroll m_Scroll;
            private readonly int m_Page;

            public SkillSelectGump(Mobile user, EternalPowerScroll scroll, int page) : base(50, 50)
            {
                m_User = user;
                m_Scroll = scroll;
                m_Page = page;

                Skill[] allSkills = new Skill[m_User.Skills.Length];
                int count = 0;

                for (int i = 0; i < m_User.Skills.Length; i++)
                {
                    Skill sk = m_User.Skills[i];
                    if (sk != null && sk.Cap < 125.0)
                        allSkills[count++] = sk;
                }

                Skill[] skills = new Skill[count];
                Array.Copy(allSkills, skills, count);
                Array.Sort(skills, delegate(Skill a, Skill b) { return a.Name.CompareTo(b.Name); });

                AddPage(0);
                AddBackground(0, 0, 420, 400, 5054);

                if (skills.Length == 0)
                {
                    AddLabel(20, 20, 33, "Somehow, all of your skills are already at the cap of 125.0!");
                    AddLabel(20, 50, 33, "This scroll cannot be used.");
                    return;
                }

                int totalPages = (int)Math.Ceiling(skills.Length / (double)SkillsPerPage);
                AddLabel(20, 20, 1152, string.Format("Choose a skill to raise the cap by 5 (Page {0} of {1})", page + 1, totalPages));

                int start = page * SkillsPerPage;
                int end = Math.Min(start + SkillsPerPage, skills.Length);

                int y = 50;
                int buttonId = 1;

                for (int i = start; i < end; i++)
                {
                    Skill sk = skills[i];
                    AddButton(20, y, 4005, 4007, buttonId, GumpButtonType.Reply, 0);
                    AddLabel(55, y, 0, string.Format("{0} ({1:F1}/125.0)", sk.Name, sk.Cap));
                    y += 25;
                    buttonId++;
                }

                if (page > 0)
                {
                    AddButton(20, 360, 4014, 4015, 1000, GumpButtonType.Reply, 0);
                    AddLabel(55, 362, 0, "Previous");
                }

                if (page < totalPages - 1)
                {
                    AddButton(300, 360, 4005, 4007, 1001, GumpButtonType.Reply, 0);
                    AddLabel(335, 362, 0, "Next");
                }
            }

            public override void OnResponse(NetState sender, RelayInfo info)
            {
                Skill[] allSkills = new Skill[m_User.Skills.Length];
                int count = 0;

                for (int i = 0; i < m_User.Skills.Length; i++)
                {
                    Skill sk = m_User.Skills[i];
                    if (sk != null && sk.Cap < 125.0)
                        allSkills[count++] = sk;
                }

                Skill[] skills = new Skill[count];
                Array.Copy(allSkills, skills, count);
                Array.Sort(skills, delegate(Skill a, Skill b) { return a.Name.CompareTo(b.Name); });

                int totalPages = (int)Math.Ceiling(skills.Length / (double)SkillsPerPage);

                if (info.ButtonID == 1000 && m_Page > 0)
                {
                    m_User.SendGump(new SkillSelectGump(m_User, m_Scroll, m_Page - 1));
                    return;
                }

                if (info.ButtonID == 1001 && m_Page < totalPages - 1)
                {
                    m_User.SendGump(new SkillSelectGump(m_User, m_Scroll, m_Page + 1));
                    return;
                }

                int skillIndex = (m_Page * SkillsPerPage) + (info.ButtonID - 1);

                if (skillIndex < 0 || skillIndex >= skills.Length)
                    return;

                Skill selectedSkill = skills[skillIndex];
                m_User.SendGump(new ConfirmSkillIncreaseGump(m_User, m_Scroll, selectedSkill));
            }
        }

        private class ConfirmSkillIncreaseGump : Gump
        {
            private readonly Mobile m_User;
            private readonly EternalPowerScroll m_Scroll;
            private readonly Skill m_Skill;

            public ConfirmSkillIncreaseGump(Mobile user, EternalPowerScroll scroll, Skill skill) : base(100, 100)
            {
                m_User = user;
                m_Scroll = scroll;
                m_Skill = skill;

                AddPage(0);
                AddBackground(0, 0, 350, 150, 5054);
                AddLabel(20, 20, 1152, string.Format("Increase {0} cap from {1:F1} to {2:F1}?", m_Skill.Name, m_Skill.Cap, Math.Min(125.0, m_Skill.Cap + 5.0)));
                AddLabel(20, 50, 0, "This cannot be undone.");

                AddButton(50, 100, 4005, 4007, 1, GumpButtonType.Reply, 0);
                AddLabel(85, 102, 0, "Yes");

                AddButton(200, 100, 4005, 4007, 2, GumpButtonType.Reply, 0);
                AddLabel(235, 102, 0, "No");
            }

            public override void OnResponse(NetState sender, RelayInfo info)
            {
                if (info.ButtonID == 1)
                {
                    if (m_Scroll.Deleted || !m_Scroll.IsChildOf(m_User.Backpack))
                    {
                        m_User.SendMessage("The scroll must be in your backpack to use it.");
                        return;
                    }

                    if (m_Skill.Cap >= 125.0)
                    {
                        m_User.SendMessage(string.Format("{0} is already at the maximum cap of 125.0.", m_Skill.Name));
                        return;
                    }

                    double oldCap = m_Skill.Cap;
                    m_Skill.Cap = Math.Min(125.0, m_Skill.Cap + 5.0);

                    m_User.SendMessage(string.Format("Your maximum {0} skill cap has increased from {1:F1} to {2:F1}.", m_Skill.Name, oldCap, m_Skill.Cap));
                    m_User.PlaySound(0x1EA);
                    m_Scroll.Delete();
                }
                else
                {
                    m_User.SendMessage("You decided not to use the scroll.");
                }
            }
        }

        public override void Serialize(GenericWriter writer)
        {
            base.Serialize(writer);
            writer.Write(0);
        }

        public override void Deserialize(GenericReader reader)
        {
            base.Deserialize(reader);
            int version = reader.ReadInt();
        }
    }
}
