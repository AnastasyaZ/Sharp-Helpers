using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BinarySearch
{
    public class Search
    {
        /*
         * возвращает индекс первого вхождения
         */
        public static int BinarySearch(int[] arr, int element)
        {
            var left = 0;
            var right = arr.Length - 1;
            while (left<right)
            {
                var middle = left + (right - left) / 2;
                if (arr[middle] >= element)
                    right = middle;
                else
                    left = middle+1;
            }
            if (arr[left] == element)
                return left;
            return -1;
        }

        public static int BinSearchRightBorder(int[] arr, int element)
        {
            var left = 0;
            var right = arr.Length;
            while (right-left>1)
            {
                var middle = left + (right - left) / 2;
                if (arr[middle] <= element)
                    left = middle;
                else
                    right = middle;
            }
            if (arr[left] == element)
                return right;
            return -1;
        }
    }
}
