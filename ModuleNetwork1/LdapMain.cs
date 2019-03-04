using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace ModuleNetwork1
{
    class LdapMain : IModule
    {
        public string progNam { get { return "Ldap"; } }

        IModule[] _subModules =
        {
            new ExitSubModule()
        };

        public void Run()
        {
            StartMenu();
        }

        void StartMenu()
        {
            int answ = Program.Menu("Pick an option ", _subModules);

            Console.Clear();
            _subModules[answ].Run();
        }
    }
}
