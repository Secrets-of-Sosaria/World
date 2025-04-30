using System;
using Server;
using Server.Items;
using Server.Mobiles;
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
                from.SendMessage("your" +m_Skill+ " is already at the maximum cap of 125.0.");
                return;
            }

            double oldCap = skill.Cap;
            skill.Cap = Math.Min(125.0, skill.Cap + 5.0);

            from.SendMessage("Your maximum" + m_Skill +" skill cap has increased from "+oldCap+" to "+ skill.Cap + " !");
            from.PlaySound(0x1EA);
            this.Delete();
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
}
