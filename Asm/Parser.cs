using System;
using System.IO;

namespace eldotnet.Asm
{
    public class Parser
    {
        internal static string[] ReadSourceLines(string fileName)
        {
            return File.ReadAllLines(fileName);
        }

        static bool AnalyzeCode()
        {
            //TODO: pre runtime code analysis
            
            Report.Log.Out.LogDebug("AnalyzeCode is unimplemented");
            return false;
        }
    }
}