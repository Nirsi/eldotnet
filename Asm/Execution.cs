using System;
using System.Collections.Generic;

using eldotnet.Data;
using eldotnet.Report;

namespace eldotnet.Asm
{
    public class Execution
    {

        public static List<string> Instructions;

        static Execution()
        {
            Instructions = new List<string>();

            Instructions.Add("add");
            Instructions.Add("dec");
            Instructions.Add("mov");
        }

        #region instruction handling

        protected static Type rType = typeof(Register16);
        public static void Mov<T1>(Register register, T1 arg2)
        {
            if(register.GetType() == typeof(Register16))
            {
                if(arg2.GetType() == typeof(Register16))
                {
                    (register as Register16).value = (arg2 as Register16).value;
                }
                else if(arg2.GetType() == typeof(Register8))
                {
                    (register as Register16).value = (arg2 as Register8).value; 
                }
                else
                {
                    (register as Register16).value = Convert.ToInt16(arg2);
                }

                //zero register set
                SetZeroBit(register);
            }
            else
            {
                if(arg2.GetType() == typeof(Register16))
                {
                    (register as Register8).value = Convert.ToByte((arg2 as Register16).value);
                }
                else if(arg2.GetType() == typeof(Register8))
                {
                    (register as Register8).value = (arg2 as Register8).value; 
                }
                else
                {
                    (register as Register8).value = Convert.ToByte(arg2);
                }

                //zero register set
                SetZeroBit(register);
            }
            Registers.C.value += (short)1;
            Log.Out.LogDebug(string.Format("Line count increased to {0}", Registers.C.value));
        }

        public static void Add<T1>(Register register, T1 arg2)
        {
            Log.Out.LogDebug(string.Format("Add method type informations\nregister is type of {0}\narg2 is type of {1}", register.GetType(), arg2.GetType()));

            if(register.GetType() == typeof(Register16))
            {
                if(arg2.GetType() == typeof(Register16))
                {
                    (register as Register16).value += (arg2 as Register16).value;
                }
                else if (arg2.GetType() == typeof(Register8))
                {
                    (register as Register16).value += (arg2 as Register8).value;
                }
                else
                {
                    (register as Register16).value += Convert.ToInt16(arg2);
                }

                //zero register set
                SetZeroBit(register);

            }
            else
            {
                if(arg2.GetType() == typeof(Register16))
                {
                    (register as Register8).value += Convert.ToByte((arg2 as Register16).value);
                }
                else if (arg2.GetType() == typeof(Register8))
                {
                    (register as Register8).value += (arg2 as Register8).value;
                }
                else
                {
                    (register as Register8).value += Convert.ToByte(arg2);
                }

                //zero register set
                SetZeroBit(register);
            }

            Registers.C.value += (short)1;
            Log.Out.LogDebug(string.Format("Line count increased to {0}", Registers.C.value));
        }

        public static void Dec<T1>(Register register, T1 arg2)
        {
            Log.Out.LogDebug(string.Format("Add method type informations\nregister is type of {0}\narg2 is type of {1}", register.GetType(), arg2.GetType()));

            if(register.GetType() == typeof(Register16))
            {
                if(arg2.GetType() == typeof(Register16))
                {
                    (register as Register16).value -= (arg2 as Register16).value;
                }
                else if (arg2.GetType() == typeof(Register8))
                {
                    (register as Register16).value -= (arg2 as Register8).value;
                }
                else
                {
                    (register as Register16).value -= Convert.ToInt16(arg2);
                }

                //zero register set
                SetZeroBit(register);
            }
            else
            {
                if(arg2.GetType() == typeof(Register16))
                {
                    (register as Register8).value -= Convert.ToByte((arg2 as Register16).value);
                }
                else if (arg2.GetType() == typeof(Register8))
                {
                    (register as Register8).value -= (arg2 as Register8).value;
                }
                else
                {
                    (register as Register8).value -= Convert.ToByte(arg2);
                }
                //zero register set
                SetZeroBit(register);
            }

            Registers.C.value += (short)1;
            Log.Out.LogDebug(string.Format("Line count increased to {0}", Registers.C.value));
        }

        #endregion
    
        #region support methods
        
        private static void SetZeroBit(Register register)
        {
            if(register.GetType() == typeof(Register16))
            {
                if((register as Register16).value == 0)
                    Registers.Z.value = 1;
                else
                    Registers.Z.value = 0;
            }
            else
            {
                if((register as Register8).value == 0)
                    Registers.Z.value = 1;
                else
                    Registers.Z.value = 0;
            }


                Log.Out.LogDebug("Zero bit setted to " + Registers.Z.value);
        }
        
        #endregion
        

    }
}