using Server.Testing;

namespace Server.Tests
{
    class BoneArmsTester
    {
        [TestMethod]
        public static bool TestBasePhysicalResistance(){ // An example of testing game data
            int itemID = 42;
            Items.BoneArms ba = new Items.BoneArms(itemID);
            if (ba.BasePhysicalResistance != 3){
                return false;
            }
            return true;
        }
    }
}
