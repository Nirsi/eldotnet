using System;
using System.IO;

namespace eldotnet.Asm
{
    public class Parser
    {
        static string[] ReadSourceLines(string fileName)
        {
            return File.ReadAllLines(fileName);
        }

        static bool AnalyzeCode()
        {
            //TODO: pre runtime code analysis
        }
    }
}