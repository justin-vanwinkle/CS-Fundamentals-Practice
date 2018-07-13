using System;
using System.Runtime.InteropServices.ComTypes;
using FluentAssertions;
using Sorting;
using Xunit;

namespace Tests
{
    public class SortingTests
    {

        [Fact]
        public void Can_Bubble_Sort()
        {
            var bubbleSorter = new BubbleSorter<int>();
            var result = bubbleSorter.Sort(new[] {9, 5, 1, 4, 2, 8, 2});
            result.Should().BeOfType<int[]>();
            result.Should().BeInAscendingOrder();

        }
        
    }
}