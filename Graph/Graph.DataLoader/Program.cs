using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Graph.DataLoader.Repository;

namespace Graph.DataLoader
{
    class Program
    {
        static void Main(string[] args)
        {
            var loader = new LoadRepository();
            loader.Load();
            Console.WriteLine("OK");
            Console.ReadLine();
        }
    }
}
