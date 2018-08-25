using Dormitory.Modul;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dormitory
{
    class Program
    {
        static void Main(string[] args)
        {
            ServiceDormitory d = new ServiceDormitory();
            d.Create();
            d.Queue();
            d.Print();
            Console.WriteLine("\n\n\n");
        }
    }
}
