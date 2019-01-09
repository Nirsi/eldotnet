using System;
using eldotnet.Report;

namespace eldotnet
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            Stream.Out.DebugLogged += DebugLoggedHandler;

            Stream.Out.LogDebug("This is logget debug message from Main method and raised from event handler");
            Console.ReadLine();

        }

        static void DebugLoggedHandler(Object sender, ReportStreamArgs e)
        {
            Console.WriteLine(e.Message);
        }

        
    }
}
