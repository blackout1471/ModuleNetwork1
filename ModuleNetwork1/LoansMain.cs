using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModuleNetwork1
{
    class LoansMain : IModule
    {
        public string progNam { get {return "Loans Menu"; } }

        IModule[] _subModules =
        {
            new ShowLoans(),
            new CreateLoan(),
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
