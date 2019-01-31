using System;

namespace eldotnet.Data
{
    public struct Registers
    {
        public static Register16 R1 = new Register16();
        public static Register16 R2 = new Register16();
        public static byte       C;

        public static string[] ToArray()
        {
            return new string[] {"R1", "R2", "C"};
        }
    }
}