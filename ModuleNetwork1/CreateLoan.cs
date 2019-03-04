using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModuleNetwork1
{
    class CreateLoan : IModule
    {
        public string progNam { get { return "Create a loan";} }
        public void Run()
        {
            Console.WriteLine("What is the Rack id?");
            string rackId = Console.ReadLine();
            Console.WriteLine("What is the start date? format:dd-mm-yyyy hh:mm:ss");
            string startDate = "FORMAT(datetime, "+Console.ReadLine()+")";
            Console.WriteLine("What is the end date? format:dd-mm-yyyy hh:mm:ss");
            string endDate = "FORMAT(datetime, "+Console.ReadLine()+")";
            Console.WriteLine("What is the Class id?");
            string classId = Console.ReadLine();
            Console.WriteLine(DatabaseHelper.ExecuteFunction("CreateLaan", new[] {rackId, startDate, endDate, classId}));
        }
    }
}
