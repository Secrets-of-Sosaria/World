using System;
using Server;

namespace Server.Items
{
    public class MarksOfHonor : Item
    {
        [Constructable]
        public MarksOfHonor() : this(1)
        {
        }

        [Constructable]
        public MarksOfHonor(int amount) : base(0xFF5)
        {
            Stackable = true;
            Weight = 0.1;
            Hue = 0x35;
            Amount = amount;
            Name = "Mark of Honor";
        }

        public MarksOfHonor(Serial serial) : base(serial)
        {
        }

        public override void Serialize(GenericWriter writer)
        {
            base.Serialize(writer);
            writer.Write((int)0);
        }

        public override void Deserialize(GenericReader reader)
        {
            base.Deserialize(reader);
            int version = reader.ReadInt();
        }
    }
}
