using System;
using eldotnet.Report;
using eldotnet.Data;
using eldotnet.Asm;
using eldotnet.Asm.Analysis;

namespace eldotnet
{
    class Program
    {
        static readonly string programName = "test.asm";
        static void Main(string[] args)
        {
            ReportingSet(1);

            /*
            testing asm file
            TODO: forward args to path
            */
            Runtime.Init(programName);
            Runtime.Run(true);

            Console.WriteLine("End of the program "  + programName);
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
            Console.WriteLine("Logging disabled");
        }

        private static void DebugLoggedHandler(object sender, ReportLogArgs e)
        {
            Console.WriteLine("DEBUG:\n" + e.Message);
        }

        private static void RuntimeLoggedHandler(object sender, ReportLogArgs e)
        {
            Console.WriteLine(e.Message);
        }
    }
}
