namespace eldotnet.Data
{
    public class Register8 : Register
    {
        private byte val;

        public Register8(byte number = 0)
        {

        }

        public byte value {
            get{
                return this.val;
            }

            set{
                this.val = value;
            }
        }
    }
}