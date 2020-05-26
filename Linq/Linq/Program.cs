using System;
using System.Collections.Generic;
using Linq;
using System.Linq;
using System.Security.Cryptography;

namespace Linq
{
    class Program
    {
        static void task1()
        {

            int[] arr;
            Console.WriteLine("Введите элементы последовательности через пробел");
            string s = Console.ReadLine();
            arr = s.Split(' ').Select(int.Parse).ToArray();
            var ans = from z in arr
                      where z % 2 == 1
                      select z;
            ans = ans.Distinct();
            Console.WriteLine("Результат: ");
            foreach (int i in ans)
            {
                Console.Write(i + " ");
            }
        }
        static void task2()
        {
            int[] arr;
            Console.WriteLine("Введите элементы последовательности через пробел");
            string s = Console.ReadLine();
            arr = s.Split(' ').Select(int.Parse).ToArray();
            var ans = from z in arr
                          where z > 9
                          where z < 100
                          orderby z ascending
                          select z;
            Console.WriteLine("Результат: ");
            foreach (int i in ans)
            {
                Console.Write(i + " ");
            }
        }
        static void task3()
        {
            string[] arr;
            Console.WriteLine("Введите элементы последовательности через пробел");
            string s = Console.ReadLine();
            arr = s.Split(' ').ToArray();
            var ans = from z in arr
                          orderby z.Length ascending
                          select z;
            ans.ThenByDescending(s => s);
            Console.WriteLine("Результат: ");
            foreach (var i in ans)
            {
                Console.Write(i + " ");
            }
        }
        static void task4()
        {

            string[] arr;
            Console.WriteLine("Введите элементы последовательности через пробел");
            string s = Console.ReadLine();
            arr = s.Split(' ').ToArray();
            var ans = from z in arr
                          select z;
            ans = ans.Select(s => s.Substring(0, 1));
            ans = ans.Reverse();
            Console.WriteLine("Результат: ");
            foreach (var i in ans)
            {
                Console.Write(i + " ");
            }
        }
        static void task5()
        {
            int[] arr;
            Console.WriteLine("Введите элементы последовательности через пробел");
            string s = Console.ReadLine();
            arr = s.Split(' ').Select(int.Parse).ToArray();
            var ans = from z in arr
                          where z > 0
                          select z;
            ans = ans.Select(s => (s % 10));
            ans = ans.Distinct();
            Console.WriteLine("Результат: ");
            foreach (int i in ans)
            {
                Console.Write(i + " ");
            }
        }
        static void task6()
        {
            var myList = new List<int>();
            int[] arr;
            Console.WriteLine("Введите элементы последовательности через пробел");
            string s = Console.ReadLine();
            arr = s.Split(' ').Select(int.Parse).ToArray();
            foreach (int i in arr)
            {
                myList.Add(i);
            }
            var ans = from item in myList
                         where (myList.IndexOf(item) + 1) % 3 != 0
                         select item;

            ans = ans.Select(s => s * (((myList.IndexOf(s) + 1) * 2) % 3));
            Console.WriteLine("Результат: ");
            foreach (int i in ans)
            {
                Console.Write(i + " ");
            }
        }
        static void task7()
        {
            int k1, k2;
            string s;
            int[] arr1;
            int[] arr2;
            Console.WriteLine("Введите элементы первой последовательности через пробел");
            s = Console.ReadLine();
            arr1 = s.Split(' ').Select(int.Parse).ToArray();
            Console.WriteLine("Введите элементы второй последовательности через пробел");
            s = Console.ReadLine();
            arr2 = s.Split(' ').Select(int.Parse).ToArray();
            Console.WriteLine("Введите параметр для первой последовательности");
            k1 = int.Parse(Console.ReadLine());
            Console.WriteLine("Введите параметр для второй последовательности");
            k2 = int.Parse(Console.ReadLine());
            var ans1 = from z in arr1
                           where z > k1
                           select z;
            var ans2 = from z in arr2
                           where z < k2
                           select z;
            ans1 = ans1.Concat(ans2);
            ans1 = ans1.OrderBy(s => s);
            Console.WriteLine("Результат: ");
            foreach (int i in ans1)
            {
                Console.Write(i + " ");
            }
        }
        static void task8()
        {
            string s;
            int[] arr1;
            int[] arr2;
            Console.WriteLine("Введите элементы первой последовательности через пробел");
            s = Console.ReadLine();
            arr1 = s.Split(' ').Select(int.Parse).ToArray();
            Console.WriteLine("Введите элементы второй последовательности через пробел");
            s = Console.ReadLine();
            arr2 = s.Split(' ').Select(int.Parse).ToArray();
            var ans1 = arr1.Select(s => new { g = s, last = s % 10 });
            var ans2 = arr2.Select(s => new { l = s, last = s % 10 });
            var ans = from z in ans1
                          join b in ans2
                               on z.last equals b.last
                          select (z.g + "-" + b.l);
            Console.WriteLine("Результат: ");
            foreach (var i in ans)
            {
                Console.Write(i + " ");
            }
        }
        static void task9()
        {
            string s;
            int[] arr1;
            int[] arr2;
            Console.WriteLine("Введите элементы первой последовательности через пробел");
            s = Console.ReadLine();
            arr1 = s.Split(' ').Select(int.Parse).ToArray();
            Console.WriteLine("Введите элементы второй последовательности через пробел");
            s = Console.ReadLine();
            arr2 = s.Split(' ').Select(int.Parse).ToArray();
            var ans1 = arr1.Select(s => new { g = s, ind = 0 });
            var ans2 = arr2.Select(s => new { g = s, ind = 0 });
            var ans = from z in ans1
                          join b in ans2
                               on z.ind equals b.ind
                          select (z.g + b.g);
            ans = ans.Distinct();
            ans = ans.OrderBy(s => s);
            Console.WriteLine("Результат: ");
            foreach (var i in ans)
            {
                Console.Write(i + " ");
            }
        }
        public class client : IComparable<client>
        {
            public int code, year, month, hours;
            public client(int c, int y, int m, int h)
            {
                code = c;
                month = m;
                year = y;
                hours = h;
            }
            public int CompareTo(client another)
            {
                return hours.CompareTo(another.hours);
            }
        }
        static void task10()
        {
            var arr = new List<client>();
            int n;
            Console.WriteLine("Введите количество клиентов");
            n = int.Parse(Console.ReadLine());
            Console.WriteLine("Введите информацию о клиентах:");
            Console.WriteLine("-----------------------------");
            for (int i = 0; i < n; i++)
            {
                Console.WriteLine("Клиент " + (i + 1) + ":");
                int c, y, m, h;
                Console.WriteLine("Введите код "+ (i+1) + "-го клиента:");
                c = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("Введите год рождения " + (i+1) + "-го клиента:");
                y = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("Введите номер месяца " + (i+1) + "-го клиента:");
                m = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("Введите продолжительность занятий " + (i+1) + "-го клиента:");
                h = Convert.ToInt32(Console.ReadLine());
                arr.Add(new client(c, y, m, h));
                Console.WriteLine("-----------------------------");
            }
            arr.Reverse();
            var ans = arr;
            client min = ans.Min();
            Console.Write("Минимальная продолжительность занятий в часах: " + min.hours + ", год: " + min.year + ", месяц: " + min.month);
        }
        static void Main(string[] args)
        {
            Console.WriteLine("Введите номер задания");
            int n = int.Parse(Console.ReadLine());
            switch (n)
            {
                case 1: task1(); break;
                case 2: task2(); break;
                case 3: task3(); break;
                case 4: task4(); break;
                case 5: task5(); break;
                case 6: task6(); break;
                case 7: task7(); break;
                case 8: task8(); break;
                case 9: task9(); break;
                case 10: task10(); break;
            }
            Console.ReadKey();
        }
    }
}
