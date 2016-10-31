using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BubbleSort
{
    public class Sorter<T>
        where T : IComparable
    {
        public static void Sort(T[] array)
        {
            for (var i = array.Length - 1; i > 0; i--)
                for (var j = 1; j <= i; j++)
                {
                    var el1 = array[j];
                    var el2 = array[j-1];
                    if (el1.CompareTo(el2) < 0)
                    {
                        var tmp = array[j - 1];
                        array[j - 1] = array[j];
                        array[j] = tmp;
                    }
                }
        }
    }
}
