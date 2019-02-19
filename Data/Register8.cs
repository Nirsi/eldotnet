namespace eldotnet.Data
{
    public class Register8 : Register
    {
        private byte val;
        public new byte size {get{ return 8; } private set{this.size = 8;}}
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