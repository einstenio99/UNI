using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HelloWorldApp
{
    class Program
    {
        private static List<string> nacionalities; 
        private static void InitList() { 
            nacionalities = new List<string>() {
                "Australian",
                "Italian",
                "Mongolian", 
                "Russian", 
                "Austrian", 
                "Brazilian",
                "Mari Carmen"
            }; 
        }
        static void Main(string[] args)
        {
            InitList(); 
            nacionalities.Sort(); 
            foreach (string nacionality in nacionalities) { 
                Console.WriteLine(nacionality); 
            }
        }
    }
}
