using eldotnet.Report;

namespace eldotnet.Asm.Analysis
{
    public class ReportBuilder
    {

        private static void GenerateReport(string message)
        {
            Log.Out.LogRuntime(string.Format(
                "Code Report\n"+
                "----------------------------------------------\n"+
                "{0}\n"+
                "----------------------------------------------"
                , message
            ));
        }

        internal static void ExcessiveParams(int lineNumber, string originalLine)
        {
            GenerateReport(string.Format("Excessive parameter on line\n{0}: {1}", lineNumber, originalLine));
        }
    }
}