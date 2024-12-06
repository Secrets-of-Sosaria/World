// Tests Race.cs
using System;
using Server.Testing;

namespace Server.Tests
{
    public class TestRace 
    {
        [TestMethod]
		public static bool TestGetRaceNames(){ // A passing test that meets the criteria
            try {
                Race.GetRaceNames();
            } 
            catch (Exception e) {
                Console.WriteLine("Exception while getting race names: {0}", e);
                return false;
            }
            return true;
		}

        [TestMethod]
		public bool TestGetRaceValues(){ // Not static, so it will be skipped
			try {
                Race.GetRaceValues();
            } 
            catch (Exception e) {
                Console.WriteLine("Exception while getting race values: {0}", e);
                return false;
            }
            return true;
		}

        [TestMethod]
		public static bool TestParse( string value ) { // Takes parameters, so it will be skipped
			try {
                Race.Parse( value );
            }
            catch (Exception e) {
                Console.WriteLine("Exception while parsing race name: {0}", e);
                return false;
            }
			return true;
		}

		[TestMethod]
		public static bool TestParseCentaur() { // An example of a failing test. If we wanted to make _sure_ that we could parse the Centaur race name.
			var test_string = "Centaur";
			try {
				var parsed = Race.Parse(test_string);
			}
			catch (ArgumentException e) {
				Console.WriteLine("Testing Parse failed: {0}", e);
				return false;
			}
			return true;
		}

        [TestMethod]
		public static void TestCheckNamesAndValues() {} // Doesn't return bool, so will be skipped
    }
}