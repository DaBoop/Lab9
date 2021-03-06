﻿using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace Lab9
{
    
    static class Extensions 
    {
   
        public static void RemoveLast<T>(this List<T> list) => list.RemoveAt(list.Count-1);
        public static void RemoveFirst<T>(this List<T> list) => list.RemoveAt(0);
        public static void Print<T>(this List<int> list) => list.ForEach(Console.WriteLine);


    }

    public delegate void Del(int x);
    class Program
    {


        static void Main(string[] args)
        {

            var rand = new Random();
            
            
            var programmer = new Programmer(1);
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
            Console.WriteLine();

            programmer.Write("prog1");
            programmer.Write("prog2");
            programmer.Write("prog3");
            programmer.Delete("prog3");
            programmer.Mutate();

            Console.WriteLine("--List1");
            list1.Print<int>();
            Console.WriteLine("--List2");
            list2.Print<int>();

            // =========
            Console.WriteLine();
            

            // Количество чашек кофе сейчас 0
            Console.WriteLine("Coffee Cups Amount:" + programmer.coffeeCups);
            
            Action<int> D; // 1
            D = programmer.FetchCoffee;
            
            programmer.Mutate(D,3);
            // Стало 3, 1 выпивает на месте
            Console.WriteLine("Coffee Cups Amount:" + programmer.coffeeCups);
            Console.WriteLine();

            Console.WriteLine("--List1");
            list1.Print<int>();

            string s = "This is a string, a lovely small string.";
            Console.WriteLine("s = " + s);
            Func<string, int, string> shiftLeft = delegate (string s, int pos) // 2
             {
                 string temp = "";
                 for (int i = 0; i < pos; i++)
                 {
                     temp += s[i];
                 }
                 for (int i = pos+1; i < s.Length-1; i++)
                 {
                     temp += s[i];
                 }
                 return (string)temp.Clone();
             };

            Func<string, string> trim = delegate (string s) // 3
            {
                for (int i = 0; i < s.Length; i++)
                {
                    if (s[i] == ' ')
                    {
                        s = shiftLeft(s, i);
                    }

                }
                return s;
            };
            s = trim(s);
            Console.WriteLine("trimmed s: " + s);
            string sEmpty = "";

            Predicate<string> isEmpty = delegate (string s) // 4
            {
                return s == "";
            };

            Console.WriteLine("s is empty: " + isEmpty(s));

            Console.WriteLine("sEmpty is empty: " + isEmpty(sEmpty));

            Func<string,int> half = delegate (string s) // 5
            {
                return s.Length / 2;
            };

            Console.WriteLine("s cleared by half: " + s.Remove(half(s)));
            
        }

    }

}