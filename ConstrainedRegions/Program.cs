using System;
using System.Runtime.CompilerServices;
using System.Runtime.ConstrainedExecution;

namespace ConstrainedRegions
{
    class Program
    {
        static void Main(string[] args)
        {
            // Code preparation in the finally block
            RuntimeHelpers.PrepareConstrainedRegions();

            try
            {
                Console.WriteLine("In try!");
            }
            finally
            {
                // Implicit call of the static constructor Type1
                Type1.M();
            }
        }
    }

    public sealed class Type1
    {
        static Type1()
        {
            // In case of exception M is not called
            Console.WriteLine("Type1's static ctor called");
        }

        // Using attribute, defined in the namespace
        // System.Runtime.ConstrainedExecution
        [ReliabilityContract(Consistency.WillNotCorruptState, Cer.Success)]
        public static void M() { }
    }
}
