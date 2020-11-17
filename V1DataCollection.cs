using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Numerics;

namespace Lab1_2
{
    class V1DataCollection:V1Data           /*значения поля на неравномерной сетке, которые хранятся в коллекции List<DataItem>*/
    {
        public List<DataItem> value { get; set; }

        public V1DataCollection(string new_data, DateTime new_date) : base(new_data, new_date)
        {
            Random rnd = new Random();
            DataItem tmp;
            value = new List<DataItem>();
            for (int i = 0; i < 3; i++)
            {
                tmp = new DataItem(rnd.Next(100), new Vector3(rnd.Next(Convert.ToInt32(0), Convert.ToInt32(30)), rnd.Next(Convert.ToInt32(0), Convert.ToInt32(30)), rnd.Next(Convert.ToInt32(0), Convert.ToInt32(30))));
                value.Add(tmp);
            }
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
            return "type is: V1DataCollection\n" + base.ToString() +"\nCount is:"+ value.Count + "\n";
        }

        public override string ToLongString()
        {
            string str = ToString();
            for (int i = 0; i < value.Count; i++)
            {
                str = str + "\n" + value[i].ToString();
            }
            return str;
        }
    }
}
