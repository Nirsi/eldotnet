using System;
using System.IO;

namespace eldotnet.Asm
{
    public class Parser
    {
        private static string[] ReadSourceLines(string fileName)
        {
            return File.ReadAllLines(fileName);
        }

        /// <summary>
        /// Main method that loads code and let analyzer do its job
        /// </summary>
        /// <param name="fileName"></param>
        /// <returns></returns>
        public static string[] LoadCode(string fileName)
        {
            var source = ReadSourceLines(fileName);

            if (Analysis.StaticAnalyzer.ProcessCode(source))
                return source;
            else
            {
                Console.ReadLine();
                Environment.Exit(-1);
                return null;
            }
        }
    }
}