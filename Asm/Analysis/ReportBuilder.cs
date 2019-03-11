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
                "{3} |\n"+
                //source line position in report
                "{1} |   {2}\n"+
                "{3} |\n"+
                "{3} |\n"+
                "----------------------------------------------"
                , errorTitle, lineNumber, ErrorMessage, padding
            ));
        }

        /// <summary>
        /// Error message when more than the exact number of parameters follows instruction.
        /// </summary>
        /// <param name="lineNumber">A number of the line where an error occurs.</param>
        /// <param name="originalLine">Source code line that invokes this error message.</param>
        internal static void ExcessiveParams(int lineNumber, string originalLine)
        {
            GenerateReport(lineNumber, "Excessive parameter", originalLine);
        }

        /// <summary>
        /// Error message when less than the exact number of parameters follows instruction.
        /// </summary>
        /// <param name="lineNumber">A number of the line where an error occurs.</param>
        /// <param name="originalLine">Source code line that invokes this error message.</param>
        internal static void MissingParams(int lineNumber, string originalLine)
        {
            GenerateReport(lineNumber, "Missing parameter", originalLine);
        }

        /// <summary>
        /// Error message when unknown instruction is found.
        /// </summary>
        /// <param name="lineNumber">A number of the line where an error occurs.</param>
        /// <param name="originalLine">Source code line that invokes this error message.</param>
        internal static void UnknownInstruction(int lineNumber, string originalLine)
        {
            GenerateReport(lineNumber, "Unknown instruction", originalLine);
        }

        /// <summary>
        /// Error message when parameters are in wrong order
        /// </summary>
        /// <param name="lineNumber">A number of the line where an error occurs.</param>
        /// <param name="originalLine">Source code line that invokes this error message.</param>
        internal static void WrongOrder(int lineNumber, string originalLine)
        {
            GenerateReport(lineNumber,"Wrong code order", originalLine);
        }

        /// <summary>
        /// Error message when unknow register is found in code.
        /// </summary>
        /// <param name="lineNumber">A number of the line where an error occurs.</param>
        /// <param name="originalLine">Source code line that invokes this error message.</param>
        internal static void ParamNotARegister(int lineNumber, string originalLine)
        {
            GenerateReport(lineNumber, "Unknown register", originalLine);       
        }
    }
}