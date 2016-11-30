using System;
using GalaxyDB.Generics.Lists;
using System.Text;
using System.Collections;

namespace GalaxyDB.Generics
{
    public class List<T>
    {
        private LinkedListNode<T> root;
        private LinkedListNode<T> current;//This will have latest node
        public int count { get; set; }

        public void Add(T data)
        {
            if (root == null)
            {
                root = new LinkedListNode<T>();
                root.Value = data;
                root.Next = null;
                current = root;
            }
            else
            {
                LinkedListNode<T> newNode = new LinkedListNode<T>();
                newNode.Value = data;
                current.Next = newNode;
                current = newNode;
            }
            count++;
        }

        public void AddFirst(T data)
        {
            LinkedListNode<T> newNode = new LinkedListNode<T>() { Value = data };
            newNode.Next = root.Next;//new node will have reference of head's next reference
            root.Next = newNode;//and now head will refer to new node
            count++;
        }

        public void Remove()
        {
            if (count > 0)
            {
                root.Next = root.Next.Next;
                count--;
            }
            else
            {
                Console.WriteLine("Empty List");
            }
        }

        public override string ToString()
        {
            StringBuilder builder = new StringBuilder();
            LinkedListNode<T> curr = root;
            while (curr != null)
            {
                builder.Append(curr.Value);
                builder.Append(" ==> ");
                curr = curr.Next;
            }
            builder.Append("NULL");

            return builder.ToString();
        }
    }
}
