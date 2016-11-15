using System;
using System.Collections;

namespace GalaxyDB.Generics.Lists
{
    public class LinkedListNode<T>
    {
        public T Value { get; set; }
        public LinkedListNode<T> NextNode { get; set; }
    }
}
