namespace eldotnet.Asm.Analysis
{
    public class StaticAnalyzer
    {
        public static bool ProcessCode(string[] Source)
        {

            bool sucses = true;
            for (int i = 0; i < Source.Length; i++)
            {
                string[] line = Source[i].Split(' ');

                if(line.Length > 3)
                {
                    ReportBuilder.ExcessiveParams(i, Source[i]);
                    sucses = false;
                }
            }

            return sucses;
        }

        #region TestCases

        private static bool InstructionTest(string[] line)
        {
            if(Asm.Execution.Instructions.Contains(line[0].ToLower()))
                return true;
            else
                return false;
        }

        #endregion
    }
}