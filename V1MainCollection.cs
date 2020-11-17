using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab1_2
{
    class V1MainCollection : IEnumerable<V1Data>
    {
        private/*public*/ List<V1Data> elements = new List<V1Data>();
        public int count { get { return elements.Count; } }

        public void Add(V1Data item)
        {
            elements.Add(item);
           // count++;
        }

        public bool Remove(string id, DateTime dateTime)
        {
            bool flag = false;int i = 0;
            while (i < elements.Count)
            {
                if (String.Compare(elements[i].data, id) == 0 && DateTime.Compare(elements[i].date, dateTime) == 0)
                {
                    elements.RemoveAt(i);
                    if (!flag) { flag = true; }
                  //  count--;
                }
                else
                    i++;
            }
            return flag;
        }

         public void AddDefaults()
         {
             Random rnd = new Random();
            
        /* Add(new V1DataOnGrid("1", DateTime.UtcNow, new Grid(rnd.Next(100), rnd.Next(5), rnd.Next(20))));
         Add(new V1DataCollection("2", DateTime.UtcNow));
         Add(new V1DataOnGrid("3", DateTime.UtcNow, new Grid(rnd.Next(100), rnd.Next(5), rnd.Next(20))));*/

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
      /*  public void AddDefaults()
        {
            Random rnd = new Random();
            Grid new_grid;
            V1DataOnGrid value1;
            V1DataCollection value2;

            new_grid = new Grid(rnd.Next(100), rnd.Next(5), 4);
            value1 = new V1DataOnGrid("ID1", new DateTime(5, 5, 5),
new_grid);
            value1.InitRandom(3, 7);
            Add(value1);
            value2 = new V1DataCollection("ID2", new DateTime(5, 5, 5));
            value2.InitRandom(5, 1, 4, 3, 4);
            Add(value2);
        }*/

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


        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            return ((System.Collections.IEnumerable)elements).GetEnumerator();
        }
    }
}
