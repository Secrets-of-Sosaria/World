using System;
using Server;
using Server.Items;
using Server.Mobiles;
using Server.Gumps;
using Server.Network;

namespace Server.Items
{
    public class EtherealPowerScroll : Item
    {
        private SkillName m_Skill;

        [Constructable]
        public EtherealPowerScroll()
            : this(GetRandomSkill())
        {
        }

        [Constructable]
        public EtherealPowerScroll(SkillName skill)
            : base(0x14F0)
        {
            m_Skill = skill;
            Weight = 1.0;
            Hue = 23;
            Name = "Ethereal Power Scroll of " +m_Skill;
        }

        public EtherealPowerScroll(Serial serial) : base(serial) { }

        public override void OnDoubleClick(Mobile from)
        {
            if (!IsChildOf(from.Backpack))
            {
                from.SendMessage("The scroll must be in your backpack to use it.");
                return;
            }

            Skill skill = from.Skills[m_Skill];

            if (skill == null)
            {
                from.SendMessage("You don't know how to use this scroll.");
                return;
            }

            if (skill.Cap >= 125.0)
            {
                from.SendMessage("Your " + m_Skill.ToString() + " is already at the maximum cap of 125.0.");
                return;
            }

            from.SendGump(new EtherealPowerScrollConfirmGump(from, this, m_Skill));
        }


        public static SkillName GetRandomSkill()
        {
            Array values = Enum.GetValues(typeof(SkillName));
            return (SkillName)values.GetValue(Utility.Random(values.Length));
        }

        public override void Serialize(GenericWriter writer)
        {
            base.Serialize(writer);
            writer.Write((int)0);

            writer.Write((int)m_Skill);
        }

        public override void Deserialize(GenericReader reader)
        {
            base.Deserialize(reader);
            int version = reader.ReadInt();

            m_Skill = (SkillName)reader.ReadInt();
        }
    }

    public class EtherealPowerScrollConfirmGump : Gump
    {
        private Mobile m_From;
        private EtherealPowerScroll m_Scroll;
        private SkillName m_Skill;

        public EtherealPowerScrollConfirmGump(Mobile from, EtherealPowerScroll scroll, SkillName skill)
            : base(150, 150)
        {
            m_From = from;
            m_Scroll = scroll;
            m_Skill = skill;

            Closable = true;
            Dragable = true;
            Resizable = false;

            AddPage(0);
            AddBackground(0, 0, 350, 160, 9270);
            AddLabel(20, 20, 1152, "Are you sure?");

            string message = "Consuming this scroll will increase the cap of your <basefont color=#ffcc00>" +
                             m_Skill.ToString() +
                             "</basefont> skill by 5.<br>This cannot be undone.";

            AddHtml(20, 50, 310, 60, message, true, true);

            AddButton(60, 120, 247, 248, 1, GumpButtonType.Reply, 0); // Yes
            
            AddButton(200, 120, 241, 242, 0, GumpButtonType.Reply, 0); // No
        }

        public override void OnResponse(NetState sender, RelayInfo info)
        {
            if (info.ButtonID == 1) // Yes
            {
                Skill skill = m_From.Skills[m_Skill];

                if (skill != null && m_Scroll != null && !m_Scroll.Deleted && m_Scroll.IsChildOf(m_From.Backpack))
                {
                    if (skill.Cap < 125.0)
                    {
                        double oldCap = skill.Cap;
                        skill.Cap = Math.Min(125.0, skill.Cap + 5.0);

                        m_From.SendMessage("Your maximum " + m_Skill.ToString() + " skill cap has increased from " +
                            oldCap.ToString("F1") + " to " + skill.Cap.ToString("F1") + "!");

                        m_From.PlaySound(0x1EA);

                        Effects.SendLocationParticles(EffectItem.Create(m_From.Location, m_From.Map, EffectItem.DefaultDuration), 0, 0, 0, 0, 0, 5060, 0);
                        Effects.PlaySound(m_From.Location, m_From.Map, 0x243);

                        Effects.SendMovingParticles(new Entity(0, new Point3D(m_From.X - 6, m_From.Y - 6, m_From.Z + 15), m_From.Map), m_From, 0x36D4, 7, 0, false, true, 0x497, 0, 9502, 1, 0, (EffectLayer)255, 0x100);
                        Effects.SendMovingParticles(new Entity(0, new Point3D(m_From.X - 4, m_From.Y - 6, m_From.Z + 15), m_From.Map), m_From, 0x36D4, 7, 0, false, true, 0x497, 0, 9502, 1, 0, (EffectLayer)255, 0x100);
                        Effects.SendMovingParticles(new Entity(0, new Point3D(m_From.X - 6, m_From.Y - 4, m_From.Z + 15), m_From.Map), m_From, 0x36D4, 7, 0, false, true, 0x497, 0, 9502, 1, 0, (EffectLayer)255, 0x100);

                        Effects.SendTargetParticles(m_From, 0x375A, 35, 90, 0x00, 0x00, 9502, (EffectLayer)255, 0x100);
            
                        m_Scroll.Delete();
                    }
                    else
                    {
                        m_From.SendMessage("Your " + m_Skill.ToString() + " skill is already at the maximum cap.");
                    }
                }
            }
        }
    }
}
