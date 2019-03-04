using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModuleNetwork1
{
    class LSearchUser : IModule
    {
        public string progNam { get { return "Search User"; } }

        LdapHelper ldap = new LdapHelper();

        /// <summary>
        /// The sub modules own main function
        /// </summary>
        public void Run()
        {
            Menu();
        }

        void Menu()
        {
            Console.Write("Type in the username: ");
            string answ = Console.ReadLine();

            List<string> usrInf = new List<string>();

            if (ldap.GetUserInfo(out usrInf, answ))
            {
                Console.Clear();
                for (int i = 0; i < usrInf.Count; i++)
                {
                    Console.WriteLine(usrInf[i]);
                }
            }
            else
            {
                Console.WriteLine("No user was found");
            }

            Console.ReadKey();
            return;
        }
    }
}
