using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModuleNetwork1
{
    class ShowLoans : IModule
    {
        public string progNam => "Show Loans";

        public void Run()
        {
            GetLoans();
            Console.WriteLine("Press a key to continue");
            Console.ReadKey();
        }

        void GetLoans()
        {
            
            string[,] data = DatabaseHelper.GetTable("Udlaant");
            Console.WriteLine(Logic.FormatString(data));
        }
    }
}
