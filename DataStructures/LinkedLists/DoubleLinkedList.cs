using System;
using System.Collections.Generic;
using System.Runtime.ExceptionServices;
using System.Threading;

namespace DataStructures.LinkedList
{
    public class DoubleLinkedListNode<T>
    {
        public T Value { get; set; }
        public DoubleLinkedListNode<T> Next { get; set; }
        public DoubleLinkedListNode<T> Previous { get; set; }
        
        public DoubleLinkedListNode()
        {            
        }

        public DoubleLinkedListNode(T value)
        {
            Value = value;
        }
        
    }
    
    public class DoubleLinkedList<T>
    {
        internal DoubleLinkedListNode<T> head;
        internal DoubleLinkedListNode<T> tail;
        internal int count = 0;

        public DoubleLinkedListNode<T> First => head;
        public DoubleLinkedListNode<T> Last => tail;
        public int Count => count;

        public void AddFirst(DoubleLinkedListNode<T> newNode)
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

        public void AddLast(DoubleLinkedListNode<T> newNode)
        {
            if (count == 0)
            {
                head = newNode;
                tail = head;
            }
            else
            {
                // make nodes reference each other
                tail.Next = newNode;
                newNode.Previous = tail;
                // now we have a new tail
                tail = newNode;
            }

            count++;
        }

        public void AddBefore(DoubleLinkedListNode<T> existingNode, DoubleLinkedListNode<T> newNode)
        {
            if (this.count == 0)
            {
                return;
            }
            
            if (existingNode == head)
            {
                AddFirst(newNode);
            }
            else
            {
                var node = head;
                while (true)
                {
                    if (node == existingNode)
                    {
                        // existing node found.  update the list with newNode.
                        var previousNode = existingNode.Previous;
                        previousNode.Next = newNode;
                        existingNode.Previous = newNode;
                       
                        break;
                    }

                    if (node.Next == null)
                    {
                        // the node given was not in this list so we will do nothing
                        return;
                    }
                    
                    node = node.Next;
                }

                count++;
            }
        }
        
        public void AddAfter(DoubleLinkedListNode<T> existingNode, DoubleLinkedListNode<T> newNode)
        {
            if (this.count == 0)
            {
                return;
            }
            
            if (existingNode == tail)
            {
                AddLast(newNode);
            }
            else
            {
                var node = head;
                while (true)
                {
                    
                    if (node == existingNode)
                    {
                        // existing node found.  update the list with newNode.
                        var nextNode = existingNode.Next;
                        nextNode.Previous = newNode;
                        existingNode.Next = newNode;
                       
                        break;
                    }

                    if (node.Next == null)
                    {
                        // the node given was not in this list so we will do nothing
                        return;
                    }

                    node = node.Next;
                }

                count++;
            }            
        }

        public void Remove(DoubleLinkedListNode<T> node)
        {
            // move the references to bypass this node
            node.Previous = node.Next;
            node.Next = node.Previous;
            count--;
        }
    }
}