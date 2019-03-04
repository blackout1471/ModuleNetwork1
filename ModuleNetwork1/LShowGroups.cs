using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModuleNetwork1
{
    class LShowGroups : IModule
    {
        public string progNam { get { return "Show Groups"; } }

        LdapHelper ldap = new LdapHelper();

        public void Run()
        {
            Menu();
        }

        void Menu()
        {

            List<string> gInf = new List<string>();

            if (ldap.GetGroups(out gInf))
            {
                Console.Clear();
                for (int i = 0; i < gInf.Count; i++)
                {
                    Console.WriteLine(gInf[i]);
                }
            }
            else
            {
                Console.WriteLine("No Groups were found.");
            }

            Console.ReadKey();
            return;
        }
    }
}
