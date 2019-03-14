using System;
using eldotnet.Report;

namespace eldotnet.Data
{
    public class Register16 : Register
    {
        public Register8 H;
        public Register8 L;

        public Register16(short number = 0)
        {
            H = new Register8();
            L = new Register8();
            this.Value = number;
        }

        public short Value {
            get
            {
                var parts = new string[2];
                parts[0] = Convert.ToString(this.H.Value, 2).PadLeft(8, '0');
                parts[1] = Convert.ToString(this.L.Value, 2).PadLeft(8, '0');
                var whole = parts[0] + parts[1];

                Log.Out.LogDebug(string.Format(
                "8 higher bits: {0}\n"+
                "8 lower bits: {1}\n"+
                "8 higher bits value: {2}\n"+
                "8 lower bits value: {3}\n"+
                "whole as binary: {4}\n"+
                "whole value: {5}\n",
                parts[0], parts[1], this.H.Value, this.L.Value, whole, Convert.ToInt16(whole, 2)
                ));

                return Convert.ToInt16(whole, 2);
            }
            set{
                var values = new string[2];

                values[0] = Convert.ToString(value, 2).PadLeft(16, '0').Substring(0, 8);
                values[1] = Convert.ToString(value, 2).PadLeft(16, '0').Substring(8, 8);
               
                H.Value = Convert.ToByte(values[0], 2);
                L.Value = Convert.ToByte(values[1], 2);

                Log.Out.LogDebug(string.Format(
                "original value: {0}\n"+
                "Converted to binary: {1}\n"+
                "8 higher bits: {2}\n"+
                "8 lower bits: {3}\n"+
                "8 higher bits converted: {4}\n"+
                "8 lower bits converted: {5}",
                 value, Convert.ToString(value, 2).PadLeft(16, '0'), values[0], values[1], this.H.Value, this.L.Value
                ));
            }
        }
    }
}