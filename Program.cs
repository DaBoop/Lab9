using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace Lab9
{
    
    static class Extensions 
    {
   
        public static void RemoveLast<T>(this List<T> list) => list.RemoveAt(list.Count-1);
        public static void RemoveFirst<T>(this List<T> list) => list.RemoveAt(0);
        public static void Print<T>(this List<int> list) => list.ForEach(Console.WriteLine);


    }
    class Program
    {


        static void Main(string[] args)
        {

            var rand = new Random();
            
            
            var programmer = new Programmer(3);
            var list1 = new List<int>();
            var list2 = new List<int>();

            
            for (int i = 0; i < 5; i++)
            {
                list1.Add(rand.Next()%10);
                list2.Add(rand.Next()%10);
            }

            Console.WriteLine("--List1");
            list1.Print<int>();
            Console.WriteLine("--List2");
            list2.Print<int>();

            programmer.onDelete += list1.RemoveFirst;
            programmer.onDelete += list2.RemoveFirst;
            programmer.onMutate += list1.RemoveLast;
            programmer.onMutate += list2.RemoveLast;

            // ========

            programmer.Write("prog1");
            programmer.Write("prog2");
            programmer.Write("prog3");
            programmer.Delete("prog3");
            programmer.Mutate();

            Console.WriteLine("--List1");
            list1.Print<int>();
            Console.WriteLine("--List2");
            list2.Print<int>();
        }
    }

}