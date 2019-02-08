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
                return 0;
            }
            set{
                string[] vals = new string[2];

                vals[0] = Convert.ToString(value, 2).PadLeft(16, '0').Substring(0, 8);
                vals[1] = Convert.ToString(value, 2).PadLeft(16, '0').Substring(8, 8);
               
                H = Convert.ToByte(vals[0], 2);
                L = Convert.ToByte(vals[1], 2);

                Log.Out.LogDebug(string.Format(
                "original value: {0}\n"+
                "Converted to binary: {1}\n"+
                "4 higher bits: {2}\n"+
                "4 lower bits: {3}\n"+
                "4 higher bits converted: {4}\n"+
                "4 lower bits converted: {5}",
                 value, Convert.ToString(value, 2).PadLeft(16, '0'), vals[0], vals[1], this.H, this.L
                ));
            }
         }
    }
}