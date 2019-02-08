using eldotnet.Data;
using eldotnet.Report;

namespace eldotnet.Asm
{
    public class Execution
    {

        #region instruction handling

        private Type rType = typeof(Register16);
        public static void Mov<T1>(Register16 arg1, T1 arg2)
        {
            if(T1 == rType)
            {
                if(arg2.GetType() == rType)
                {
                    (arg1 as registerType).value = (arg2 as registerType).value;
                }
                else
                {
                    (arg1 as registerType).value = (short)arg2;
                }
            }
            else
            {
                Log.Out.LogRuntime("First argument of MOV can't be of type" + arg1.GetType());
            }
        }

        public static void Add<T1, T2>(T1 arg1, T2 arg2)
        {
            if(arg1.GetType() == typeof(Register16))
            {
                if(arg2.GetType() == rType)
                {
                    (arg1 as registerType).value = (arg1 as registerType).value + (arg2 as registerType).value;
                }
                else
                {
                    (arg1 as registerType).value = (arg1 as registerType).value + (short)arg2;
                }
            }
            else
            {
                Log.Out.LogRuntime("First argument of ADD can't be of type" + arg1.GetType());
            }
        }

        #endregion
    
        
    }
}