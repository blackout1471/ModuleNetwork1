using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModuleNetwork1
{
    class LShowUsers : IModule
    {
        public string progNam { get { return "Show Users"; } }

        LdapHelper lDap = new LdapHelper();

        public void Run()
        {
            Menu();
        }

        void Menu()
        {
            List<string> gInf = new List<string>();

            if (lDap.GetUsers(out gInf))
            {
                Console.Clear();
                for (int i = 0; i < gInf.Count; i++)
                {
                    Console.WriteLine(gInf[i]);
                }
            }
            else
            {
                Console.WriteLine("No Users Were Found.");
            }

            Console.ReadKey();
            return;
        }
    }
}
