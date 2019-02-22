using eldotnet.Report;

namespace eldotnet.Asm.Analysis
{
    public class ReportBuilder
    {

        private static void GenerateReport(int lineNumber, string errorTitle, string ErrorMessage)
        {
            string padding = "".PadLeft(lineNumber.ToString().Length, ' ');
            Log.Out.LogRuntime(string.Format(
                "{0}\n"+
                "----------------------------------------------\n"+
                "{3}|\n"+
                //source line position in report
                "{1}|  {2}\n"+
                "{3}|\n"+
                "{3}|\n"+
                "----------------------------------------------"
                , errorTitle, lineNumber, ErrorMessage, padding
            ));
        }

        internal static void ExcessiveParams(int lineNumber, string originalLine)
        {
            GenerateReport(lineNumber, "Excessive parameter", originalLine);
        }

        internal static void UnknownInstruction(int lineNumber, string originalLine)
        {
            GenerateReport(lineNumber, "Unknown instruction", originalLine);
        }

        internal static void WrongOrder(int lineNumber, string originalLine)
        {
            GenerateReport(lineNumber,"Wrong code order", originalLine);
        }

        internal static void ParamNotARegister(int lineNumber, string originalLine)
        {
            GenerateReport(lineNumber, "Unknown register", originalLine);        }
    }
}