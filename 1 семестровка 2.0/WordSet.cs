using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace _1_семестровка_2._0
{
    class WordSet : SingleLinkedList
    {
        public WordSet() { }

        public WordSet(string[] arr)
        {
            foreach (var item in arr)
            {
                AddLast(item);
            }
        }

        public WordSet(WordSet w1, WordSet w2)
        {
            if (!w1.IsOrdered() || !w2.IsOrdered())
            {
                throw new Exception("неупорядочены");
            }

            var data1 = w1.First;
            var data2 = w2.First;
            var current = new WordSet();

            if (data1 == null)
            {
                while (data2 != null)
                {
                    current.AddLast(data2.Info);
                    data2 = data2.Next;
                }
            }
            else
            {
                while (data1 != null)
                {
                    current.AddLast(data1.Info);
                    data1 = data1.Next;
                }
            }
            First = current.First;

            while (data1 != null && data2 != null)
            {
                if (data1.Info.CompareTo(data2.Info) < 0)
                {
                    current.AddLast(data1.Info);
                    data1 = data1.Next;
                }
                else
                {
                    current.AddLast(data2.Info);
                    data2 = data2.Next;
                }
            }
        }
    }
}
