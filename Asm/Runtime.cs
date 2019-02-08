using eldotnet.Data;

namespace eldotnet.Asm
{
    public class Runtime
    {
        public static string[] Source {get; private set;}

        public static void Init(string sourcepath)
        {
           this.Source = Parser.ReadSourceLines(sourcepath);
        }

        public static void Run()
        {
            foreach (string line in Source)
            {
                string[] parts = line.Split(' ');

                switch(parts[0].ToLower())
                {
                    case "add":
                        Execution.Add<Register16, short>(part);
                        break; 
                }

            }
            
        }
    }
}