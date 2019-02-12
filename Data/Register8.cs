namespace eldotnet.Data
{
    public class Register8 : IRegister
    {
        private byte val;
        public byte size {get{ return 8; } private set{this.size = value;}}
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