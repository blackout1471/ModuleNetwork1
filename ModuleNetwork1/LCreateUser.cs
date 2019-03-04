using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModuleNetwork1
{
    class LCreateUser : IModule
    {
        public string progNam { get { return "Create User"; } }

        LdapHelper lDap = new LdapHelper();

        public void Run()
        {
            Menu();
        }

        void Menu()
        {
            lDap.CreateUser("Emil", "Andersen", "Emil01", "Hej!");
        }
    }
}
