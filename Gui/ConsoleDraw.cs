using System;
using eldotnet.Data;

namespace eldotnet.Gui
{
    public class ConsoleDraw
    {
        public static void DrawRegisteresTable()
        {
            Console.WriteLine(
                "------------"+
                "|" + Registers.C + "|" +
                "------------"
            );
            foreach (var keyValuePair in Registers.registers)
            {
                Console.WriteLine(keyValuePair.Key + "\t\t" + GetValue(keyValuePair.Value));
            }
        }

        private static int GetValue(Register register)
        {
            if(register.GetType() == typeof(Register16))
                return int.Parse((register as Register16).value.ToString());
            if(register.GetType() == typeof(Register8))
                return int.Parse((register as Register8).value.ToString());

            return 0;
        }
    }
}