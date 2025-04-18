using Server.Gumps;
using Server.Items;
using Server.Mobiles;
using Server.Network;
using System;
using System.Collections.Generic;

namespace Server
{
    public class PowerGump : Gump
    {
        private const int BUTTON_SKILL_OFFSET = 100;
        private Mobile m_Merchant;
        private int m_Price;
        private readonly List<SkillName> m_sortedSkillNames;

        public PowerGump(string msg, Mobile from, Mobile merchant) : base(50, 50)
        {
            const string color = "#81aabf";
            m_Merchant = merchant;

            Closable = true;
            Disposable = true;
            Dragable = true;
            Resizable = false;

            AddPage(0);

            string skill = "105";
            string cat = "WONDEROUS";
            m_Price = 10000;

            if (merchant is WonderousDealer) { cat = "WONDEROUS"; m_Price = 10000; skill = "105"; }
            else if (merchant is ExaltedDealer) { cat = "EXALTED"; m_Price = 20000; skill = "110"; }
            else if (merchant is MythicalDealer) { cat = "MYTHICAL"; m_Price = 60000; skill = "115"; }
            else if (merchant is LegendaryDealer) { cat = "LEGENDARY"; m_Price = 200000; skill = "120"; }
            else if (merchant is PowerDealer) { cat = "POWER"; m_Price = 500000; skill = "125"; }

            AddImage(0, 0, 9592, Server.Misc.PlayerSettings.GetGumpHue(from));
            AddButton(962, 11, 4017, 4017, 0, GumpButtonType.Reply, 0);
            AddHtml(12, 12, 727, 20, "<BODY><BASEFONT Color=" + color + ">CASTLE OF KNOWLEDGE</BASEFONT></BODY>", false, false);
			AddHtml(12, 46, 976, 20, "<BODY><BASEFONT Color=" + color + ">CHOOSE A " + cat + " (" + skill + " SKILL) SCROLL TO PURCHASE FOR " + m_Price + " GOLD</BASEFONT></BODY>", false, false);
	        AddHtml(12, 80, 976, 20, "<BODY><BASEFONT Color=" + color + ">" + msg + "</BASEFONT></BODY>", false, false);


            m_sortedSkillNames = new List<SkillName>();
            Array values = Enum.GetValues(typeof(SkillName));

            foreach (SkillName name in values)
            {
                if (name == SkillName.Mysticism || name == SkillName.Imbuing || name == SkillName.Throwing)
                    continue;

                m_sortedSkillNames.Add(name);
            }

            m_sortedSkillNames.Sort((a, b) => string.Compare(a.ToString(), b.ToString(), StringComparison.Ordinal));

            const int maxRowsPerColumn = 15;

            for (int column = 0; column < 4; column++)
            {
                int x = 31 + 250 * column;
                int y = 25;
                int offset = maxRowsPerColumn * column;

                for (int index = 0; index < maxRowsPerColumn; index++)
                {
                    if (index + offset >= m_sortedSkillNames.Count)
                        break;

                    y += 30;

                    SkillName skillName = m_sortedSkillNames[index + offset];
                    AddButton(x, y + 77, 4011, 4011, index + offset + BUTTON_SKILL_OFFSET, GumpButtonType.Reply, 0);
					AddHtml(x + 50, y + 80, 252, 20, "<BODY><BASEFONT Color=" + color + ">" + skillName + "</BASEFONT></BODY>", false, false);

                }
            }
        }

        public override void OnResponse(NetState sender, RelayInfo info)
        {
            Mobile from = sender.Mobile;

            if (!from.Region.IsPartOf("the Castle of Knowledge"))
            {
                // They left the castle
                return;
            }

            if (info.ButtonID <= 0)
                return;

            bool consumed = Banker.Withdraw(from, m_Price);

            if (!consumed)
            {
                Container cont = from.Backpack;
                consumed = cont != null && cont.ConsumeTotal(typeof(Gold), m_Price);
            }

            if (consumed)
            {
                string msg;
                int value;

                if (m_Merchant is ExaltedDealer) { msg = "Exalted"; value = 110; }
                else if (m_Merchant is MythicalDealer) { msg = "Mythical"; value = 115; }
                else if (m_Merchant is LegendaryDealer) { msg = "Legendary"; value = 120; }
                else if (m_Merchant is PowerDealer) { msg = "Power"; value = 125; }
                else { msg = "Wonderous"; value = 105; }

                int index = info.ButtonID - BUTTON_SKILL_OFFSET;

                if (index < 0 || index >= m_sortedSkillNames.Count)
                    return;

                SkillName skill = m_sortedSkillNames[index];

                if (!Enum.IsDefined(typeof(SkillName), skill))
                {
                    Console.WriteLine("Failed to purchase {0} Powerscroll for '{1}'", value, skill);
                    return;
                }

                PowerScroll scroll = new PowerScroll(skill, value);
				msg = "You paid " + m_Price + " gold for the " + msg + " Scroll of " + scroll.GetSkillDisplayName(skill) + "!";


                from.AddToBackpack(scroll);
                from.PlaySound(0x32);
                from.SendGump(new PowerGump(msg, from, m_Merchant));
            }
            else
            {
                m_Merchant.SayTo(from, 500191); //Begging thy pardon, but thy bank account lacks these funds.
            }
        }
    }
}
