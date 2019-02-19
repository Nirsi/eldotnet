namespace eldotnet.Asm.Analysis
{
    public class StaticAnalyzer
    {
        public static bool ProcessCode(string[] Source)
        {
            for (int i = 0; i < Source.Length; i++)
            {
                string[] line = Source[i].Split(' ');

                if(line.Length > 3)
                {
                    ReportBuilder.ExcessiveParams(i, Source[i]);
                    return false;
                }
            }

            return true;
        }
    }
}