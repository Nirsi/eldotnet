using System;
using eldotnet.Report;

namespace eldotnet.Data
{
    public class Register16
    {
         public byte L;
         public byte H;

         public short value {
            get
            {
                return Convert.ToInt16(temp, 2);;
            }
            set{
                //TODO: come up with simplier code
                string[] vals = new string[2];
                vals[0] = temp.Substring(0, 4);
                vals[1] = temp.Substring(4, 4);
                H = Convert.ToByte(vals[0], 2);
                L = Convert.ToByte(vals[1], 2);
            }
         }
    }
}