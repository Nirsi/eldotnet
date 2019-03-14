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
            Instructions = new List<string> {"add", "dec", "mov"};

        }

        #region instruction handling

        public static void Mov<T1>(Register register, T1 arg2)
        {
            if(register.GetType() == typeof(Register16))
            {
                if(arg2.GetType() == typeof(Register16))
                {
                    (register as Register16).Value = (arg2 as Register16).Value;
                }
                else if(arg2.GetType() == typeof(Register8))
                {
                    (register as Register16).Value = (arg2 as Register8).Value; 
                }
                else
                {
                    (register as Register16).Value = Convert.ToInt16(arg2);
                }

                //zero register set
                SetZeroBit(register);
            }
            else
            {
                if(arg2.GetType() == typeof(Register16))
                {
                    (register as Register8).Value = Convert.ToByte((arg2 as Register16).Value);
                }
                else if(arg2.GetType() == typeof(Register8))
                {
                    (register as Register8).Value = (arg2 as Register8).Value; 
                }
                else
                {
                    (register as Register8).Value = Convert.ToByte(arg2);
                }

                //zero register set
                SetZeroBit(register);
            }
            Registers.C.Value += (short)1;
            Log.Out.LogDebug($"Line count increased to {Registers.C.Value}");
        }

        public static void Add<T1>(Register register, T1 arg2)
        {
            Log.Out.LogDebug(
                $"Add method type informations\nregister is type of {register.GetType()}\narg2 is type of {arg2.GetType()}");

            if(register.GetType() == typeof(Register16))
            {
                if(arg2.GetType() == typeof(Register16))
                {
                    (register as Register16).Value += (arg2 as Register16).Value;
                }
                else if (arg2.GetType() == typeof(Register8))
                {
                    (register as Register16).Value += (arg2 as Register8).Value;
                }
                else
                {
                    (register as Register16).Value += Convert.ToInt16(arg2);
                }

                //zero register set
                SetZeroBit(register);

            }
            else
            {
                if(arg2.GetType() == typeof(Register16))
                {
                    (register as Register8).Value += Convert.ToByte((arg2 as Register16).Value);
                }
                else if (arg2.GetType() == typeof(Register8))
                {
                    (register as Register8).Value += (arg2 as Register8).Value;
                }
                else
                {
                    (register as Register8).Value += Convert.ToByte(arg2);
                }

                //zero register set
                SetZeroBit(register);
            }

            Registers.C.Value += (short)1;
            Log.Out.LogDebug($"Line count increased to {Registers.C.Value}");
        }

        public static void Dec<T1>(Register register, T1 arg2)
        {
            Log.Out.LogDebug(string.Format("Add method type information\nregister is type of {0}\narg2 is type of {1}", register.GetType(), arg2.GetType()));

            if(register.GetType() == typeof(Register16))
            {
                if(arg2.GetType() == typeof(Register16))
                {
                    (register as Register16).Value -= (arg2 as Register16).Value;
                }
                else if (arg2.GetType() == typeof(Register8))
                {
                    (register as Register16).Value -= (arg2 as Register8).Value;
                }
                else
                {
                    (register as Register16).Value -= Convert.ToInt16(arg2);
                }

                //zero register set
                SetZeroBit(register);
            }
            else
            {
                if(arg2.GetType() == typeof(Register16))
                {
                    (register as Register8).Value -= Convert.ToByte((arg2 as Register16).Value);
                }
                else if (arg2.GetType() == typeof(Register8))
                {
                    (register as Register8).Value -= (arg2 as Register8).Value;
                }
                else
                {
                    (register as Register8).Value -= Convert.ToByte(arg2);
                }
                //zero register set
                SetZeroBit(register);
            }

            Registers.C.Value += (short)1;
            Log.Out.LogDebug($"Line count increased to {Registers.C.Value}");
        }

        #endregion
    
        #region support methods
        
        private static void SetZeroBit(Register register)
        {
            if(register.GetType() == typeof(Register16))
            {
                if((register as Register16).Value == 0)
                    Registers.Z.Value = 1;
                else
                    Registers.Z.Value = 0;
            }
            else
            {
                if((register as Register8).Value == 0)
                    Registers.Z.Value = 1;
                else
                    Registers.Z.Value = 0;
            }


                Log.Out.LogDebug($"Zero bit set to {Registers.Z.Value}");
        }
        
        #endregion
        

    }
}