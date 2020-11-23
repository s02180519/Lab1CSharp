/*данные измерений электромагнитного поля в зависимости от времени*/
using System;
using System.Collections;
using System.Collections.Generic;
using System.Dynamic;
using System.IO;
using System.Numerics;
using Lab1_2;

namespace Lab1
{
    class Program
    {

        static void Main(string[] args)
        {
             Console.WriteLine("Lab_1*");
             Grid new_grid = new Grid(3, 1, 3);
             float[] t;
             V1DataOnGrid element = new V1DataOnGrid("blablabla", DateTime.UtcNow, new_grid);
             Console.WriteLine("TASK1\n" + element.ToLongString());
             V1DataCollection element_transformed = element;
             Console.WriteLine("transformed element\n"+element_transformed.ToLongString());

             V1MainCollection element_collection = new V1MainCollection();
             element_collection.AddDefaults();
            /* V1DataOnGrid value1;
             element_collection.Add(element_collection.elements[0]);
             Console.WriteLine("\n\nTASK2\n" + element_collection.ToString());
             element_collection.Remove(element_collection.elements[0].data, element_collection.elements[0].date);*/
            Console.WriteLine("\n\nTASK2\n" + element_collection.ToString());


            Console.WriteLine("\n\nTASK3");
            foreach (V1Data elem in element_collection)
            {
                t = elem.NearZero(30);
                Console.WriteLine(elem.ToLongString()+"\nList of values:");
                if (t.Length == 0)
                    Console.WriteLine("No elements" + "\n");
                foreach (float val in t)
                {
                    Console.Write(val + " ");
                }
                Console.WriteLine("\n\n");
            }

            Console.WriteLine("\n\n*********************\nLab_2*");
            Console.WriteLine("Exercise 1");
            V1DataCollection V1DataCollection_element=new V1DataCollection("init.txt");
            Console.WriteLine(V1DataCollection_element.ToLongString("{0,3:00.00}"));
            Console.WriteLine("\n\n*********************\nExercise 2");
            Console.WriteLine("max measurement`s count: "+element_collection.max_count+"\n\nelements in descending order\n");
            foreach (var elem in element_collection.V1Data_ordered_by_coordinates_length)
            {
               // Console.WriteLine("OK");
                Console.WriteLine(elem.ToString("{0,3:00.00}"));
            }
            Console.WriteLine("\n***********************\none time t");
            foreach(var elem in element_collection.time_one_time)
            {
                Console.WriteLine(/*elem.ToString("{0,3:00.00}")*/String.Format("{0,3:00.00}",elem));
            }
            Console.ReadLine();
        }
    }
}