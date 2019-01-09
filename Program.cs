using System;
using eldotnet.Report;
using eldotnet.Data;

namespace eldotnet
{
    class Program
    {

        static bool DEBUG = false;
        static void Main(string[] args)
        {
            if(DEBUG)
                Stream.Out.DebugLogged += DebugLoggedHandler;

            //Stream.Out.LogDebug("This is logget debug message from Main method and raised from event handler");

            Registers.HL1.L = 10;
            Registers.HL1.H = 5;

            //Console.WriteLine("HL1-L: {0} \nHL1-H: {1} \nHL1: {2}", Registers.HL1.L, Registers.HL1.H, Registers.HL1.value);

            Console.WriteLine("L: {0}\nH: {1}\n HL1: {2}\n\n setting value to whole HL1 = 50");
            Registers.HL1.value = 50;


            Console.ReadLine();

        }

        static void DebugLoggedHandler(Object sender, ReportStreamArgs e)
        {
            Console.WriteLine("DEBUG: " + e.Message);
        }

        
    }
}
