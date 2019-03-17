using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1_семестровка_2._0
{
    class Program
    {
        public static void Main(string[] args)
        {
            var lst = new WordSet();
            lst.AddLast("a");
            lst.AddLast("b");
            lst.AddLast("c");

            Console.WriteLine(lst);
            Console.ReadKey();

            lst.Insert("a");
            lst.Insert("insert");
            lst.Delete("b");
            lst.Out("output.txt");
            Console.WriteLine(lst);
            Console.ReadKey();

        }
        //public static void PrintList(string list)
        //{
        //    var node = list.First;

        //    while (node != null)
        //    {
        //        Console.Write(node.Value + " ");
        //        node = node.Next;
        //    }

        //    Console.WriteLine();
        //}
    }
}
