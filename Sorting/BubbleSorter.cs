using System;

namespace Sorting
{
    public class BubbleSorter<T> where T : IComparable<T>
    {
        public T[] Sort(T[] array)
        {
            bool swapFound;
            do
            {
                swapFound = false;
                for (var i = 0; i < array.Length - 1; i++)
                {
                    var comparison = array[i].CompareTo(array[i + 1]);
                    if (comparison > 0)
                    {
                        swapFound = true;
                        var temp = array[i + 1];
                        array[i + 1] = array[i];
                        array[i] = temp;                
                    }
                }
            } while (swapFound);

            return array;
        }
    }
}