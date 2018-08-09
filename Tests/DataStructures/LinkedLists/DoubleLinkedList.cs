using DataStructures.LinkedList;
using FluentAssertions;
using Xunit;

namespace Tests.DataStructures
{
    public class LinkedLists
    {
        [Fact]
        public void Add_First_Count_0()
        {
            var linkedList = new DoubleLinkedList<int>();
            var node = new DoubleLinkedListNode<int>(1);

            linkedList.AddFirst(node);

            linkedList.Count.Should().Be(1);
            linkedList.First.Should().Be(node);
            linkedList.First.Value.Should().Be(1);
            linkedList.Last.Should().Be(node);
            linkedList.Last.Value.Should().Be(1);
        }
        
        [Fact]
        public void Add_Last_Count_0()
        {
            var linkedList = new DoubleLinkedList<int>();
            var node = new DoubleLinkedListNode<int>(1);

            linkedList.AddLast(node);
            
            linkedList.Count.Should().Be(1);
            linkedList.First.Should().Be(node);
            linkedList.First.Value.Should().Be(1);
            linkedList.Last.Should().Be(node);
            linkedList.Last.Value.Should().Be(1);
        }
        
        [Fact]
        public void Add_Before_Count_0_Does_Not_Add()
        {
            var linkedList = new DoubleLinkedList<int>();
            var newNode = new DoubleLinkedListNode<int>(1);
            var nodeNotInList = new DoubleLinkedListNode<int>(2);

            linkedList.AddBefore(nodeNotInList, newNode);
            
            linkedList.Count.Should().Be(0);
        }
        
        [Fact]
        public void Add_After_Count_0_Does_Not_Add()
        {
            var linkedList = new DoubleLinkedList<int>();
            var newNode = new DoubleLinkedListNode<int>(1);
            var nodeNotInList = new DoubleLinkedListNode<int>(2);

            linkedList.AddAfter(nodeNotInList, newNode);
            
            linkedList.Count.Should().Be(0);
        }
        
        [Fact]
        public void Can_Add_After_Element()
        {
            var linkedList = new DoubleLinkedList<int>();
            var node1 = new DoubleLinkedListNode<int>(1);
            var node2 = new DoubleLinkedListNode<int>(2);
            var newNode = new DoubleLinkedListNode<int>(3);

            linkedList.AddFirst(node1);
            linkedList.AddLast(node2);
            linkedList.AddAfter(node1, newNode);
            
            linkedList.Count.Should().Be(3);
            linkedList.First.Should().Be(node1);
            linkedList.Last.Should().Be(node2);

            linkedList.First.Value.Should().Be(1);
            linkedList.First.Next.Value.Should().Be(3);
            linkedList.Last.Value.Should().Be(2);
            linkedList.Last.Previous.Value.Should().Be(3);
        }

        [Fact]
        public void Can_Add_Before_Element()
        {
            var linkedList = new DoubleLinkedList<int>();
            var node1 = new DoubleLinkedListNode<int>(1);
            var node2 = new DoubleLinkedListNode<int>(2);
            var newNode = new DoubleLinkedListNode<int>(3);

            linkedList.AddFirst(node1);
            linkedList.AddLast(node2);
            linkedList.AddBefore(node2, newNode);
            
            linkedList.Count.Should().Be(3);
            linkedList.First.Should().Be(node1);
            linkedList.Last.Should().Be(node2);

            linkedList.First.Value.Should().Be(1);
            linkedList.First.Next.Value.Should().Be(3);
            linkedList.Last.Value.Should().Be(2);
            linkedList.Last.Previous.Value.Should().Be(3);
        }

        [Fact]
        public void Can_Remove_Head()
        {
            var linkedList = new DoubleLinkedList<int>();

            var node1 = new DoubleLinkedListNode<int>(1);
            var node2 = new DoubleLinkedListNode<int>(2);
            var node3 = new DoubleLinkedListNode<int>(3);

            linkedList.AddFirst(node1);
            linkedList.AddLast(node2);
            linkedList.AddLast(node3);
            
            linkedList.Remove(linkedList.First);
            
            linkedList.Count.Should().Be(2);
            linkedList.First.Should().Be(node2);
            linkedList.Last.Should().Be(node3);
         
            linkedList.First.Next.Should().Be(node3);
            linkedList.First.Previous.Should().Be(node3);
            linkedList.Last.Previous.Should().Be(node2);
            linkedList.Last.Next.Should().Be(node2);

        }

        [Fact]
        public void Can_Remove_Tail()
        {
            var linkedList = new DoubleLinkedList<int>();

            var node1 = new DoubleLinkedListNode<int>(1);
            var node2 = new DoubleLinkedListNode<int>(2);
            var node3 = new DoubleLinkedListNode<int>(3);

            linkedList.AddFirst(node1);
            linkedList.AddLast(node2);
            linkedList.AddLast(node3);
            
            linkedList.Remove(node3);
            
            linkedList.Count.Should().Be(2);
            linkedList.First.Should().Be(node1);
            linkedList.Last.Should().Be(node2);
            
            linkedList.First.Next.Should().Be(node2);
            linkedList.First.Previous.Should().Be(node2);
            linkedList.Last.Previous.Should().Be(node1);
            linkedList.Last.Next.Should().Be(node1);
        }

        [Fact]
        public void Can_Remove_Middle_Node()
        {
            var linkedList = new DoubleLinkedList<int>();

            var node1 = new DoubleLinkedListNode<int>(1);
            var node2 = new DoubleLinkedListNode<int>(2);
            var node3 = new DoubleLinkedListNode<int>(3);

            linkedList.AddFirst(node1);
            linkedList.AddLast(node2);
            linkedList.AddLast(node3);
            
            linkedList.Remove(node2);
            
            linkedList.Count.Should().Be(2);
            linkedList.First.Should().Be(node1);
            linkedList.Last.Should().Be(node3);
            
            linkedList.First.Next.Should().Be(node3);
            linkedList.First.Previous.Should().Be(node3);
            linkedList.Last.Previous.Should().Be(node1);
            linkedList.Last.Next.Should().Be(node1);
        }

    }
}