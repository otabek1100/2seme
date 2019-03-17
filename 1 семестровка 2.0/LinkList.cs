using System.Text;
using System.IO;
using System.Collections.Generic;
using System;

namespace _1_семестровка_2._0
{
    class Elem
    {
        public string Info { get; set; }
        public Elem Next { get; set; }
    }

    class SingleLinkedList
    {
        public Elem First { get; set; }
        public Elem tail = null;

        private int count;

        public int Count
        {
            get
            {
                return count;
            }
        }

        public int Length
        {
            get
            {
                int k = 0;
                var el = First;
                while (el != null)
                {
                    k++;
                    el = el.Next;
                }
                return k;
            }
        }

        public void AddFirst(string x)
        {
            var el = new Elem() { Info = x, Next = First };
            First = el;
        }

        public void AddLast(string x)
        {
            var el = First;
            if (el == null)
            {
                AddFirst(x);
                return;
            }
            while (el.Next != null)
                el = el.Next;
            el.Next = new Elem() { Info = x };
        }

        public bool IsOrdered()
        {
            var el = First;
            if (el == null || el.Next == null)
                return true;
            while (el.Next != null)
            {
                if (el.Info.CompareTo(el.Next.Info) > 0)
                    return false;
                el = el.Next;
            }
            return true;
        }

        public override string ToString()
        {
            if (First == null)
                throw new Exception("First is null");
            StringBuilder sb = new StringBuilder();
            var el = First;
            while (el != null)
            {
                sb.Append($"{el.Info} ");
                el = el.Next;
            }
            return sb.ToString();
        }

        public void Out(string fileName)
        {
            File.WriteAllText(fileName, this.ToString());
        }

        public void Insert(string data)
        {

            if (Contains(data))
                return;

            var current = First;
            if (current.Info == null)
            {
                AddLast(data);
                return;
            }

            while (current.Next != null)
            {
                if (current.Info.CompareTo(data) > 0)
                {
                    AddFirst(data);
                    return;
                }
                else if (current.Info.CompareTo(data) < 0 && current.Next.Info.CompareTo(data) > 0)
                {
                    var newEl = new Elem { Info = data, Next = current.Next };
                    current.Next = newEl;
                    return;
                }
                current = current.Next;
            }
            AddLast(data);
        }

        public bool Contains(string data)
        {
            var current = First;
            while (current != null)
            {
                if (current.Info == data)
                    return true;
                current = current.Next;
            }
            return false;
        }

        public void Delete(string data)
        {
            //входной аргумент на null
            if (data == null)
            {
                throw new ArgumentNullException(nameof(data));
            }

            //Текущий обозреваемый элемент списка
            var current = First;

            //Предыдущий элемент списка, перед обозреваемым.
            Elem previous = null;

            while (current != null)
            {
                if (current.Info.Equals(data))
                {
                    if (previous != null)
                    {
                        previous.Next = current.Next;

                        if (current.Next == null)
                        {
                            tail = previous;
                        }
                    }
                    else
                    {
                        First = First.Next;

                        if (First == null)
                        {
                            tail = null;
                        }
                    }
                    count--;
                    break;
                }

                previous = current;
                current = current.Next;
            }
        }

        public WordSet NewWordSetByWordLength(int l)
        {

            var dataList = new List<string>();
            var el = First;
            while (el != null)
            {
                if (el.Info.Length == l)
                    dataList.Add(el.Info);
                el = el.Next;
            }
            var FixedLengthWordSet = new WordSet(dataList.ToArray());
            return FixedLengthWordSet;
        }

        public WordSet[] VowelDivide()
        {
            var vowel = ("аеёиоуыэюя".ToUpper() + "аеёиоуыэюя").ToCharArray();
            var consonant = ("бвгджзйклмнпрстфхцчшщъь" + "бвгджзйклмнпрстфхцчшщъь".ToUpper()).ToCharArray();

            var vowelWordSet = new WordSet();
            var consonantWordSet = new WordSet();

            var el = First;
            while (el != null)
            {
                if (IsLetterContainedInArray(el.Info[0], vowel))
                    vowelWordSet.AddLast(el.Info);
                else
                    consonantWordSet.AddLast(el.Info);
                el = el.Next;
            }

            return new WordSet[] { consonantWordSet, vowelWordSet };
        }

        public bool IsLetterContainedInArray(char letter, char[] array)
        {
            for (int i = 0; i < array.Length; i++)
                if (array[i] == letter)
                    return true;
            return false;
        }

        public static bool Palindromtest(string s)
        {
            for (int i = 0, j = s.Length - 1; i < j; i++, j--)

                if (s[i] != s[j])
                {
                    return false;
                }
            return true;

        }

        public void DeletePalindrome()
        {
            var current = First;

            while (current != null)
            {
                if (Palindromtest(current.Info))
                {
                    Delete(current.Info);
                }
                current = current.Next;
            }
        }
    }
}
