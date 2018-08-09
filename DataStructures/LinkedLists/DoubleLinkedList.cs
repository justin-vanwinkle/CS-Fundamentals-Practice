namespace DataStructures.LinkedList
{
    public class DoubleLinkedListNode<T>
    {
        public T Value { get; set; }
        public DoubleLinkedListNode<T> Next { get; set; }
        public DoubleLinkedListNode<T> Previous { get; set; }
        
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
                head.Next = tail;
                tail.Previous = head;
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

            //set end pointers
            head.Previous = tail;
            tail.Next = head;
            
            count++;
        }

        public void AddLast(DoubleLinkedListNode<T> newNode)
        {
            if (count == 0)
            {
                head = newNode;
                tail = head;
                head.Next = tail;
                tail.Previous = head;
            }
            else
            {
                var previousTail = tail;
                tail = newNode;
                
                // make nodes reference each other
                previousTail.Next = tail;
                tail.Previous = previousTail;
            }

            //set end pointers
            head.Previous = tail;
            tail.Next = head;

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
                        // existing node found
                        var rightNode = existingNode;
                        var leftNode = existingNode.Previous;

                        // point surrounding nodes to new node
                        leftNode.Next = newNode;
                        rightNode.Previous = newNode;

                        // point new node to surrounding nodes
                        newNode.Next = rightNode;
                        newNode.Previous = leftNode;
                       
                        break;
                    }

                    if (node.Next == head)
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
                        // existing node found.
                        var rightNode = existingNode.Next;
                        var leftNode = existingNode;
                        
                        // point surrounding nodes to new node
                        rightNode.Previous = newNode;
                        leftNode.Next = newNode;

                        // point new node to surrounding nodes
                        newNode.Previous = leftNode;
                        newNode.Next = rightNode;
                       
                        break;
                    }

                    if (node.Next == head)
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
            var leftNode = node.Previous;
            var rightNode = node.Next;

            // point surrounding nodes to each other
            leftNode.Next = rightNode;
            rightNode.Previous = leftNode;
            
            if (node == head)
            {
                head = rightNode;
            }
            else if (node == tail)
            {
                tail = leftNode;
            }

            count--;            
        }
    }
}