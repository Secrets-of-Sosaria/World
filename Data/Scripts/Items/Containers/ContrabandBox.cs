using System;
using Server;
using Server.Items;
using Server.Mobiles;

namespace Server.Items
{
    public abstract class ContrabandBox : Item
    {
        public ContrabandBox(int itemID, int hue) : base(itemID)
        {
            Weight    = 5.0;
            Movable   = true;
        }

        public override string DefaultDescription{ get{ return "This box contains illegal goods. They can be given to the guildmaster in the thieves guild, who will know who might be interested in the contents of such ill gotten goods."; } }

        public override void OnDoubleClick(Mobile from)
        {
            if (from != null && !from.Deleted)
                from.SendMessage("You cannot open this contraband box.");
        }

        public ContrabandBox(Serial serial) : base(serial) { }

        public override void Serialize(GenericWriter writer)
        {
            base.Serialize(writer);
            writer.Write((int)0); // version
        }

        public override void Deserialize(GenericReader reader)
        {
            base.Deserialize(reader);
            int version = reader.ReadInt();
        }
    }

    [Flipable(0xE7C, 0xE7D)]
    public class CommonContrabandBox : ContrabandBox
    {
        [Constructable]
        public CommonContrabandBox() : base(0xE7C, 0)
        {
            Name = "Common Contraband Box";
            Hue = 0x835;
        }

        public CommonContrabandBox(Serial serial) : base(serial) { }
        public override void Serialize(GenericWriter writer)
        {
            base.Serialize(writer);
            writer.Write((int)0); // version
        }

        public override void Deserialize(GenericReader reader)
        {
            base.Deserialize(reader);
            int version = reader.ReadInt();
        }
    }

    [Flipable(0xE7C, 0xE7D)]
    public class UncommonContrabandBox : ContrabandBox
    {
        [Constructable]
        public UncommonContrabandBox() : base(0xE7C, 0x59)
        {
            Name = "Uncommon Contraband Box";
            Hue = 0x8B0;
        }

        public UncommonContrabandBox(Serial serial) : base(serial) { }
        public override void Serialize(GenericWriter writer)
        {
            base.Serialize(writer);
            writer.Write((int)0); // version
        }

        public override void Deserialize(GenericReader reader)
        {
            base.Deserialize(reader);
            int version = reader.ReadInt();
        }
    }

    [Flipable(0xE7C, 0xE7D)]
    public class RareContrabandBox : ContrabandBox
    {
        [Constructable]
        public RareContrabandBox() : base(0xE7C, 0x4BE)
        {
            Name = "Rare Contraband Box";
            Hue = 0x89B;
        }

        public RareContrabandBox(Serial serial) : base(serial) { }
        public override void Serialize(GenericWriter writer)
        {
            base.Serialize(writer);
            writer.Write((int)0); // version
        }

        public override void Deserialize(GenericReader reader)
        {
            base.Deserialize(reader);
            int version = reader.ReadInt();
        }
    }

    [Flipable(0xE7C, 0xE7D)]
    public class VeryRareContrabandBox : ContrabandBox
    {
        [Constructable]
        public VeryRareContrabandBox() : base(0xE7C, 0x489)
        {
            Name = "Very Rare Contraband Box";
            Hue = 0x88E;
        }

        public VeryRareContrabandBox(Serial serial) : base(serial) { }
        public override void Serialize(GenericWriter writer)
        {
            base.Serialize(writer);
            writer.Write((int)0); // version
        }

        public override void Deserialize(GenericReader reader)
        {
            base.Deserialize(reader);
            int version = reader.ReadInt();
        }
    }

    [Flipable(0xE7C, 0xE7D)]
    public class ExtremelyRareContrabandBox : ContrabandBox
    {
        [Constructable]
        public ExtremelyRareContrabandBox() : base(0xE7C, 0x8A5)
        {
            Name = "Extremely Rare Contraband Box";
            Hue = 0x86C;
        }

        public ExtremelyRareContrabandBox(Serial serial) : base(serial) { }
        public override void Serialize(GenericWriter writer)
        {
            base.Serialize(writer);
            writer.Write((int)0); // version
        }

        public override void Deserialize(GenericReader reader)
        {
            base.Deserialize(reader);
            int version = reader.ReadInt();
        }
    }

    [Flipable(0xE7C, 0xE7D)]
    public class LegendaryContrabandBox : ContrabandBox
    {
        [Constructable]
        public LegendaryContrabandBox() : base(0xE7C, 0xAA0)
        {
            Name = "Legendary Contraband Box";
            Hue = 0x21;
        }

        public LegendaryContrabandBox(Serial serial) : base(serial) { }
        public override void Serialize(GenericWriter writer)
        {
            base.Serialize(writer);
            writer.Write((int)0); // version
        }

        public override void Deserialize(GenericReader reader)
        {
            base.Deserialize(reader);
            int version = reader.ReadInt();
        }
    }
}