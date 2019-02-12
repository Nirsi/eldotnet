using eldotnet.Data;

namespace eldotnet.Asm
{
    public class Runtime
    {
        public static string[] Source {get; private set;}

        public static void Init(string sourcepath)
        {
           Source = Parser.ReadSourceLines(sourcepath);
        }

        public static void Run()
        {
            foreach (string line in Source)
            {
                string[] parts = line.Split(' ');

                switch(parts[0].ToLower())
                {
                    case "add":
                        if(Registers.IsRegister(parts[2]))
                            Execution.Add<Register16>(Registers.NameToRegister(parts[1]), Registers.NameToRegister(parts[2]));
                        else
                            Execution.Add<short>(Registers.NameToRegister(parts[1]), 0);
                        break; 
                }

            }
            
        }
    }
}