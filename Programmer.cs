﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Lab9
{
    class Programmer
    {


        public delegate void EventContainer();

        public event EventContainer onDelete;
        public event EventContainer onMutate;

        List<string> ProgList = new List<string>();
        public int coffeeCups { get; private set; }
        public void Write(string s) => ProgList.Add(s);

        public void FetchCoffee(int x) => coffeeCups += x;
        public string this[int i]
        {
            get => ProgList[i];
            set => ProgList[i] = value;
        
        }


        public void Delete(string s)
        {
            if (ProgList.Count > 0)
            {
                ProgList.Remove(s);
                onDelete();
            }
        }

        public void Mutate()
        {
            if (coffeeCups > 0)
            {
                coffeeCups--; // Sip
                onMutate();
            }
        }

        public void Mutate(Action<int> D, int DParam)
        {
            if (coffeeCups > 0)
            {
                coffeeCups--; // Sip
                onMutate();
            }
            else
            {
                D(DParam);
                coffeeCups--; // Sip
                onMutate();
            }

        }

        public Programmer(int coffeeCups_arg) => coffeeCups = coffeeCups_arg;
        public Programmer() => coffeeCups = 0;
    }
}
