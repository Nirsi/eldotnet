using System;
using eldotnet.Report;
using eldotnet.Data;
using eldotnet.Asm;
using eldotnet.Asm.Analysis;

namespace eldotnet
{
    class Program
    {
        static void Main(string[] args)
        {
            Init();
            

            ReportBuilder.ExcessiveParams(20, "Add R1 5 R2");

            Registers.R1.value = (short)20;
            Registers.R2.value = (short)5;


            Execution.Add<short>(Registers.R1, 10);
            Execution.Add<short>(Registers.R2, 5);
            Execution.Add<Register16>(Registers.R1, Registers.R2);

            Console.WriteLine(Registers.R1.value);
            Console.WriteLine(Registers.R2.value);
            
            
            
            
            Console.ReadLine();

        }

        private static void Init()
        {
            //Log.Out.DebugLogged += DebugLoggedHandler;
            Log.Out.RuntimeLogged += RuntimeLoggedHandler;
        }

        static void DebugLoggedHandler(Object sender, ReportLogArgs e)
        {
            Console.WriteLine("DEBUG:\n" + e.Message);
        }

        static void RuntimeLoggedHandler(Object sender, ReportLogArgs e)
        {
            Console.WriteLine("DEBUG:\n" + e.Message);
        }
    }
}
