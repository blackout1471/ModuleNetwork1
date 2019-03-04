using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModuleNetwork1
{
    class DbMain : IModule
    {
        IModule[] _subModules = 
        {
            new ExitSubModule()
        };

        public string progNam { get { return "DB System"; } }

        public void Run()
        {
            int answ = Program.Menu("Choose an option", _subModules);
        }
    }
}
