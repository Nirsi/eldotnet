using System;
using System.Linq;
using eldotnet.Report;

namespace eldotnet.Data
{
    public struct Registers
    {
        public static Register16 R1 = new Register16(0);
        public static Register16 R2 = new Register16(0);
        public static Register16 C  = new Register16(0);

        public static string[] ToArray()
        {
            return new string[] {"R1", "R2", "C"};
        }

        public static bool IsRegister(string name)
        {
            if(Registers.ToArray().Contains(name))
                return true;
            else
                return false;
        }

        public static Register NameToRegister(string registerName)
        {
            switch(registerName)
            {
                case "R1": return R1;
                case "R2": return R2;

                default:
                    Log.Out.LogDebug("Unknown register, creating new unnamed register");
                    return new Register16();
            }
        }
    }
}