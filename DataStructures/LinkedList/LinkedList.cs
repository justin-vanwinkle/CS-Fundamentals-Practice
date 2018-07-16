using System;
using System.Runtime.ExceptionServices;

namespace DataStructures.LinkedList
{
    public class LinkedList<T>
    {
        internal LinkedListNode<T> head;
        internal LinkedListNode<T> tail;
        internal int count = 0;

        public LinkedList()
        {
            
        }
        
        public LinkedListNode<T> First
        {
            get { return this.head; }
        }
        public LinkedListNode<T> Last
        {
            get
            {
                return this.head.Previous;
            }
        }

        public void AddFirst(LinkedListNode<T> newNode)
        {            
            if (count == 0)
            {
                head = newNode;
                tail = head;
            }
            else
            {
                // put the new head in place.
                var previousHead = head;
                head = newNode;
                
                // move the references around to reflect the sequence
                newNode.Next = previousHead;
                newNode.Previous = tail;
                previousHead.Previous = newNode;
            }
            
            count++;
        }

        public void AddLast(LinkedListNode<T> newNode)
        {
            if (count == 0)
            {
                head = newNode;
                tail = head;
            }
            else
            {
                // point the current last node to the new node
                tail.Next = newNode;
                // now we have a new tail
                tail = newNode;
            }

            count++;
        }

        public void AddBefore(LinkedListNode<T> existingNode, LinkedListNode<T> newNode)
        {
            if (existingNode == head)
            {
                AddFirst(newNode);
            }
            else
            {
                var previousNode = existingNode.Previous;

                previousNode.Next = newNode;
                existingNode
            }
        }

    }

    
}