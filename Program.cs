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

            StaticAnalyzer.ProcessCode(new string[] {"Add 1 R1"});

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
