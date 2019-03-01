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
            ReportingSet(1);

            string[] Source = new string[] {"Add R1 5", "Mov R1 0", "Add"};
            StaticAnalyzer.ProcessCode(Source);
            Runtime.Source = Source;
            Runtime.Run();

            Console.ReadLine();

        }

        private static void ReportingSet(int level)
        {
            if (level == 2)
            {
                Log.Out.DebugLogged += DebugLoggedHandler;
                return;
            }
            if (level == 1)
            {
                Log.Out.RuntimeLogged += RuntimeLoggedHandler;
                return;
            }
            Console.WriteLine("Loging disabled");
        }

        static void DebugLoggedHandler(Object sender, ReportLogArgs e)
        {
            Console.WriteLine("DEBUG:\n" + e.Message);
        }

        static void RuntimeLoggedHandler(Object sender, ReportLogArgs e)
        {
            Console.WriteLine(e.Message);
        }
    }
}
