namespace eldotnet.Asm.Analysis
{
    public class StaticAnalyzer
    {
        public static bool ProcessCode(string[] Source)
        {

            bool success = true;
            for (int i = 0; i < Source.Length; i++)
            {
                string[] line = Source[i].Split(' ');

                if(line.Length > 3)
                {
                    ReportBuilder.ExcessiveParams(i, Source[i]);
                    success = false;
                }

                if(InstructionTest(line))
                {
                    ReportBuilder.UnknownInstruction(i, Source[i]);
                    success = false;
                }
            }

            return success;
        }

        #region TestCases

        private static bool LineOrderTest(string[] line)
        {
            if(short.TryParse(line[1]))
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        private static bool InstructionTest(string[] line)
        {
            //inverse of result
            if(Asm.Execution.Instructions.Contains(line[0].ToLower()))
                return false;
            else
                return true;
        }
        
        private static bool RegisterTest(string[] line)
        {
            if(Data.Registers.IsRegister(line[2]))
            {

            }
        }

        #endregion
    }
}