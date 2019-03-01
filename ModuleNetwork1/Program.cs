using System;

namespace ModuleNetwork1
{
    class Program
    {
        static void Main(string[] args)
        {

            IModule[] mainModules = {

            };

            // List Main modules
            for (int i = 0; i < mainModules.Length; i++)
            {
                Console.WriteLine(i + ". " + mainModules[i].progNam);
            }

            Console.Write("Type your choice: ");
            int answ = Int32.Parse(Console.ReadLine());
        }
    }
}
