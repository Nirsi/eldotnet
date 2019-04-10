using System;
using System.Linq;
using System.Collections.Generic;
using eldotnet.Report;

namespace eldotnet.Data
{
    public struct Registers
    {
        public static Register16 R1 = new Register16(0);
        public static Register16 R2 = new Register16(0);

        /// <summary>
        /// Instruction counter
        /// </summary>
        /// <returns>It's value</returns>
        public static Register16 C  = new Register16(0);

        /// <summary>
        /// Zero register
        /// Set to 1 if last operation equals 0
        /// </summary>
        /// <returns></returns>
        public static Register8  Z  = new Register8 (0);

        private static readonly Dictionary<string, Register> registers;

        static Registers()
        {
            registers = new Dictionary<string, Register>
            {
                {"R1", R1},
                {"R1.L", R1.L},
                {"R1.H", R1.H},
                {"R2", R2},
                {"R2.L", R2.L},
                {"R2.H", R2.H},
                {"C", C},
                {"Z", Z}
            };


        }

        
        public static Dictionary<string, Register> ToDictionary()
        {
            return registers;
        }
        

        public static bool IsRegister(string name)
        {
            return registers.ContainsKey(name);
        }

        public static Register NameToRegister(string registerName)
        {
            foreach (var pair in registers)
            {
                if(pair.Key == registerName)
                    return pair.Value;
            }
            Log.Out.LogRuntime("No register with name " + registerName + " found returning null");
            return null;
        }
    }
}