using System;
using System.Threading.Tasks;

namespace Pizza.Admin
{
    public class Application
    {
        public Application()
        {
        }

        public async Task Run(string[] args)
        {
            char keyPress;

            do
            {
    
                Console.WriteLine(" 1. Add Large Pizza to Orders");
                Console.WriteLine(" 0. Exit");
                keyPress = Console.ReadKey().KeyChar;
            } while (keyPress != 0);
        }
    }
}