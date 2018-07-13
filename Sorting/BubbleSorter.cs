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
                
                // used to track the earliest point in the array that is fully sorted
                var firstSortedElement = array.Length;

                for (var i = 0; i < firstSortedElement - 1; i++)
                {
                    var comparison = array[i].CompareTo(array[i + 1]);
                    if (comparison > 0)
                    {
                        swapFound = true;
                        firstSortedElement = i + 1;
                        
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