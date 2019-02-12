using System;
using eldotnet.Data;
using eldotnet.Report;

namespace eldotnet.Asm
{
    public class Execution
    {

        #region instruction handling

        protected static Type rType = typeof(Register16);
        public static void Mov<T1>(Register16 register, T1 arg2)
        {
            
            if(arg2.GetType() == rType)
            {
                register.value = (arg2 as Register16).value;
            }
            else
            {
                register.value = Convert.ToInt16(arg2);
            }
        }

        public static void Add<T1>(Register16 register, T1 arg2)
        {
            if(arg2.GetType() == rType)
            {
                    register.value += (arg2 as Register16).value;
            }
            else
            {
                register.value += Convert.ToInt16(arg2);
            }
        }

        #endregion
    
        
    }
}