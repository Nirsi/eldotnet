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

                if(line.Length < 2)
                {
                    ReportBuilder.MissingParams(i, Source[i]);
                    success = false;
                }

                if(InstructionTest(line))
                {
                    ReportBuilder.UnknownInstruction(i, Source[i]);
                    success = false;
                }

                if(LineOrderTest(line))
                {
                    ReportBuilder.WrongOrder(i, Source[i]);
                    success = false;
                }
                else
                {
                    if(RegisterTest(line))
                    {
                        ReportBuilder.ParamNotARegister(i, Source[i]);
                        success = false;
                    }
                }
            }

            return success;
        }

        #region TestCases

        private static bool LineOrderTest(string[] line)
        {
            short a;
            if(short.TryParse(line[1], out a))
            {
                return true;
            }
            else
            {
                return false;
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
            short a;
            if(!short.TryParse(line[2], out a))
            {
                if(Data.Registers.IsRegister(line[2]))
                {
                    return false;
                }
                else
                {
                    return true;
                }
            }
            return false;
            
        }

        #endregion
    }
}