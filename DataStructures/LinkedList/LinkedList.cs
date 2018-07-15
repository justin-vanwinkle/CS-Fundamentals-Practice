using System.Runtime.ExceptionServices;

namespace DataStructures.LinkedList
{
    public class LinkedList<T>
    {
        internal LinkedListNode<T> head;
        
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

    }

    
}