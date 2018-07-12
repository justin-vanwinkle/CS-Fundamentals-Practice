using System;
using System.Runtime.InteropServices.ComTypes;
using FluentAssertions;
using Sorting;
using Xunit;

namespace Tests
{
    public class SortingTests
    {
        BubbleSorter<int> _bubbleSorter = new BubbleSorter<int>();

        [Fact]
        public void Can_Bubble_Sort()
        {
            var result = _bubbleSorter.Sort(new[] {5, 1, 4, 2, 8});
            var x = 1;
            result.Should().BeOfType<int[]>();
        }
    }
}