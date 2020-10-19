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
      //  struct DataItem                             /* значения поля в момент времени t*/
      /*  {
            public float t { get; set; }
            public System.Numerics.Vector3 coordinates { get; set; }

            public DataItem(float new_t, System.Numerics.Vector3 new_coordinates)
            {
                t = new_t;
                coordinates = new_coordinates;
            }

            public override string ToString()
            {
                string str = "time is:" + t + "\ncoordinates are: ";
                str += ToString();
                str += "<" + coordinates.X + "," + coordinates.Y + "," + coordinates.Z + ">";
                return str;
            }
        }*/

       // struct Grid                                 /*параметры равномерной сетки по времени*/
        /*{
            public float t { set; get; }
            public float time_step { set; get; }
            public int number_of_grid_points { set; get; }

            public Grid(float new_t, float new_time_step, int new_number_of_grid_points)
            {
                t = new_t;
                time_step = new_time_step;
                number_of_grid_points = new_number_of_grid_points;
            }
            public override string ToString()
            {
                return "time is:" + t + "\ntime step is: " + time_step + "\nnumber of grid point:" + number_of_grid_points + "\n";
            }
        }*/

       /* abstract class V1Data
        {
            public string data { set; get; }
            public DateTime date { set; get; }

            public V1Data(string new_data, DateTime new_date)
            {
                data = new_data;
                date = new_date;
            }

            public abstract float[] NearZero(float eps);
            public abstract string ToLongString();
            public override string ToString()
            {
                return "data is:" + data + "\ndate is: " + date;
            }
        }*/

       // class V1DataOnGrid : V1Data                  /*значения поля на равномерной сетке, которые хранятся в массиве*/
       /* {
            public Grid grid { set; get; }
            public Vector3[] points_value { set; get; }

            public V1DataOnGrid(string new_data, DateTime new_date, Grid new_grid) : base(new_data, new_date)
            {
                grid = new_grid;
                points_value = new Vector3[grid.number_of_grid_points];
                InitRandom(0, 20);
            }

            public override float[] NearZero(float eps)
            {
                List<float> time = new List<float>();
                for (int i = 0; i < points_value.Length; i++)
                {
                    if (points_value[i].Length() < eps)
                    {
                        for (int j = 0; j < grid.number_of_grid_points; j++)
                        {
                            time.Add(grid.t + j * grid.time_step);
                        }
                    }
                }
                return time.ToArray();
            }

            public void InitRandom(float minValue, float maxValue)
            {
                Random rnd = new Random();
                for (int i = 0; i < points_value.Length; i++)
                {
                    points_value[i] = new Vector3(rnd.Next(Convert.ToInt32(minValue), Convert.ToInt32(maxValue)), rnd.Next(Convert.ToInt32(minValue), Convert.ToInt32(maxValue)), rnd.Next(Convert.ToInt32(minValue), Convert.ToInt32(maxValue)));
                }
            }

            public static implicit operator V1DataCollection(V1DataOnGrid value)
            {
                return new V1DataCollection(value.data, value.date);
            }

            public override string ToString()
            {
                return "type is: V1DataOnGrid\n" + base.ToString() + "\n" + grid.ToString() + "\n";
            }

            public override string ToLongString()
            {
                string str = "";
                str += ToString();
                for (int i = 0; i < points_value.Length; i++)
                    str += "<" + points_value[i].X + "," + points_value[i].Y + "," + points_value[i].Z + ">";
                return str;
            }
        }*/

       // class V1DataCollection : V1Data              /*значения поля на неравномерной сетке, которые хранятся в коллекции List<DataItem>*/
       /* {
            public List<DataItem> value;

            public V1DataCollection(string new_data, DateTime new_date) : base(new_data, new_date)
            {
                value = new List<DataItem>();
            }

            public override float[] NearZero(float eps)
            {
                List<float> time = new List<float>();
                for (int i = 0; i < value.Count; i++)
                {
                    if (value[i].coordinates.Length() < eps)
                    {
                        time.Add(value[i].t);
                    }
                }
                return time.ToArray();
            }

            public void InitRandom(int nItems, float tmin, float tmax, float minValue, float maxValue)
            {
                Random rnd = new Random();
                for (int i = 0; i < nItems; i++)
                {
                    value.Add(new DataItem(rnd.Next(Convert.ToInt32(tmin), Convert.ToInt32(tmax)), new Vector3(rnd.Next(Convert.ToInt32(minValue), Convert.ToInt32(maxValue)), rnd.Next(Convert.ToInt32(minValue), Convert.ToInt32(maxValue)), rnd.Next(Convert.ToInt32(minValue), Convert.ToInt32(maxValue)))));
                }
            }

            public override string ToString()
            {
                return "type is: V1DataCollection\n" + base.ToString() + value.Count + "\n";
            }

            public override string ToLongString()
            {
                return ToString() + value.ToString();
            }
        }*/

      /*  class V1MainCollection : IEnumerable<V1Data>
        {
            private List<V1Data> elements = new List<V1Data>();
            public int count = 0;

            public void Add(V1Data item)
            {
                elements.Add(item);
                count++;
            }

            public bool Remove(string id, DateTime dateTime)
            {
                bool flag = false;
                for (int i = 0; i < elements.Count; i++)
                {
                    if (String.Compare(elements[i].data, id) == 0 && DateTime.Compare(elements[i].date, dateTime) == 0)
                    {
                        elements.RemoveAt(i);
                        if (!flag) { flag = true; }
                    }
                }
                return flag;
            }

            public void AddDefaults()
            {
                Random rnd = new Random();
                Grid new_grid;
                V1DataOnGrid value1;
                V1DataCollection value2;
                for (int i = 0; i < 3; i++)
                {
                    new_grid = new Grid(rnd.Next(100), rnd.Next(5), rnd.Next(20));
                    value1 = new V1DataOnGrid(Convert.ToString(i * 2), DateTime.UtcNow, new_grid);
                    Add(value1);
                    value2 = new V1DataCollection(Convert.ToString(i * 2 + 1), DateTime.UtcNow);
                    Add(value2);
                }
            }

            public override string ToString()
            {
                string str = "";
                for (int i = 0; i < count; i++)
                {
                    str = str + elements[i].ToString() + "\n";
                }
                return str;
            }

            public IEnumerator<V1Data> GetEnumerator()
            {
                return ((IEnumerable<V1Data>)elements).GetEnumerator();
            }

            IEnumerator IEnumerable.GetEnumerator()
            {
                return ((IEnumerable)elements).GetEnumerator();
            }
        }*/

        static void Main(string[] args)
        {
            Grid new_grid = new Grid(3, 1, 3);
            float[] t;
            V1DataOnGrid element = new V1DataOnGrid("blablabla", DateTime.UtcNow, new_grid);
            Console.WriteLine("TASK1\n" + element.ToLongString());

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
            Console.ReadLine();
        }
    }
}
