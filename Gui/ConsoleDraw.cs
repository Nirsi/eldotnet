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
                "|" + "vCPU Registers" + "|" +
                "------------"
            );
            
            foreach (var keyValuePair in Registers.ToDictionary())
            {
                Console.WriteLine(keyValuePair.Key + "\t\t" + GetValue(keyValuePair.Value));
            }
        }

        private static int GetValue(Register register)
        {
            if(register.GetType() == typeof(Register16))
                return int.Parse((register as Register16).Value.ToString());
            if(register.GetType() == typeof(Register8))
                return int.Parse((register as Register8).Value.ToString());

            return 0;
        }
    }
}