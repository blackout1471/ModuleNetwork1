using System;

namespace ModuleNetwork1
{
    class Program
    {
        static void Main(string[] args)
        {

            IModule[] _mainModules = {
                new LdapMain(),
                new DbMain()
            };

            // List Main modules
            void StartMenu()
            {
                int answ = Menu("Choose an option", _mainModules);
                
                Console.Clear();
                _mainModules[answ].Run();

                Console.WriteLine("\n\n\nPress Key To Go To Startmenu");
                Console.ReadKey();
                Console.Clear();

                StartMenu();
            }


            // Start The main Menu
            StartMenu();

            Console.ReadKey();
            
        }

        public static int Menu(string inputString, IModule[] options)
        {
            Console.WriteLine(inputString);
            int minLine = Console.CursorTop;
            int maxLine = minLine + options.Length - 1;
            int currentLine = minLine;
            foreach (IModule option in options)
            {
                Console.WriteLine(option.progNam);
            }
            ChangeLineColour(ConsoleColor.Cyan, minLine, options[0].progNam);
            ConsoleKeyInfo input;
            do
            {
                input = Console.ReadKey(true);
                ChangeLineColour(ConsoleColor.Gray, currentLine, options[currentLine - minLine].progNam);
                if (currentLine > minLine && input.Key == ConsoleKey.UpArrow)
                {
                    currentLine--;
                }
                else if (currentLine < maxLine && input.Key == ConsoleKey.DownArrow)
                {
                    currentLine++;
                }
                ChangeLineColour(ConsoleColor.Cyan, currentLine, options[currentLine - minLine].progNam);
            } while (input.Key != ConsoleKey.Enter);
            // Set the cursor back to normal, under the menu
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.SetCursorPosition(0, maxLine + 1);
            return currentLine - minLine;
        }

        public static void ChangeLineColour(ConsoleColor colour, int line, string text)
        {
            Console.ForegroundColor = colour;
            Console.SetCursorPosition(0, line);
            Console.Write(text);
        }
    }
}
