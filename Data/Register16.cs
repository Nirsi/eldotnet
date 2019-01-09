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
                string temp = Convert.ToString(H, 2).PadLeft(4, '0') + Convert.ToString(L, 2).PadLeft(4, '0');
                Stream.Out.LogDebug("temp from Register16: " + temp);
                return Convert.ToInt16(temp, 2);;
            }
            set{

                //TODO: come up with simplier code
                string temp = Convert.ToString(value, 2).PadLeft(8, '0');
                string[] vals = new string[2];
                vals[0] = temp.Substring(0, 4);
                vals[1] = temp.Substring(4, 4);
                Stream.Out.LogDebug("temp: "+temp+"\n vals[0]: "+vals[0]+"\n vals[1]: "+vals[1]);
                H = Convert.ToByte(vals[0], 2);
                L = Convert.ToByte(vals[1], 2);
            }
         }
    }
}