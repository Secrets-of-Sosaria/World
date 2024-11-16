using System;
using System.Linq;
using System.Diagnostics;
using System.Reflection;

namespace Server.Tests
{
    #if DEBUG
    public class TestHarness {
        public static void Main() {
            Console.WriteLine("Executing Tests\n---");
            RunTests(true);
        }

        public static System.Collections.Generic.IEnumerable<TestMethodAttribute> RunTests(bool inherit)
        {
            var output = new System.Collections.Generic.List<TestMethodAttribute>();

            var assemblies = AppDomain.CurrentDomain.GetAssemblies();

            foreach (var assembly in assemblies)
            {
                var assembly_types = assembly.GetTypes();

                foreach (var type in assembly_types)
                {
                    var methods = type.GetMethods()
                                    .Where(m => m.GetCustomAttributes(typeof(TestMethodAttribute), false).Any())
                                    .ToList();
                    foreach (var method in methods)
                    {
                        if (method.ReturnType != typeof(bool)){
                            Console.WriteLine("Skipping testing {0} in {1}: Test method must return bool. {0} returns {2}.", method.Name, type.Name, method.ReturnType);
                            continue;
                        }
                        if (method.GetParameters().GetLength(0) != 0) {
                            Console.WriteLine("Skipping testing {0} in {1}: Test method must not require parameters.", method.Name, type.Name);
                            continue;
                        }
                        if (!method.IsStatic){
                            Console.WriteLine("Skipping testing {0} in {1}: Test method must be static.", method.Name, type.Name);
                            continue;
                        }
                        var result = method.Invoke(null, null);  // Invoke the static method with no parameters
                        if (result != null) {
                            var passed = (bool) result;
                            if (!passed){
                                Console.WriteLine("FAILED: {0}.{1}", type.Name, method.Name);
                            } else {
                                Console.WriteLine("PASSED: {0}.{1}", type.Name, method.Name);
                            }
                        } else {
                            Console.WriteLine("ERROR: Somehow {0}.{1} returned null!", type.Name, method.Name);
                        }
                    }
                }
            }

            return output;
        }
    }
    #endif

    // Add this attribute to your methods if you want the test harness to run them.
    // The method must be static, must take no parameters, and must return true if the test passes and false if it fails.
    [Conditional("DEBUG")] // The intention is to remove all TestMethods from the "production" executable
    [System.AttributeUsage(System.AttributeTargets.Method)]
    public class TestMethodAttribute : System.Attribute{}
}