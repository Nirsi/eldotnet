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
                " |\n"+
                "----------------------------------------------"
                , message
            ));
        }

        internal static void ExcessiveParams(int lineNumber, string originalLine)
        {
            GenerateReport(string.Format("Excessive parameter on line\n{0}|  {1}", lineNumber, originalLine));
        }

        internal static void UnknownInstruction(int lineNumber, string originalLine)
        {
            GenerateReport(string.Format("Unknown instruction on line\n |\n{0}|  {1}\n |   ^", lineNumber, originalLine));
        }

        internal static void WrongOrder(int lineNumber, string originalLine)
        {
            GenerateReport(string.Format("Wrong code order on line \n{0}|  {1}", lineNumber, originalLine));
        }

        internal static void ParamNotARegister(int lineNumber, string originalLine)
        {
            GenerateReport(string.Format("Unknown register on line \n{0}|  {1}", lineNumber, originalLine));
        }
    }
}