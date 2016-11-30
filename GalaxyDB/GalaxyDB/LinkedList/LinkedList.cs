using System;

namespace LinkedList
{
	public class LinkedList
	{
		private Node root;
		private Node current;//This will have latest node
		public int count;

		public LinkedList()//Constructor
		{
			root = new Node();
			current = root;
		}

		public void Add_Node(object data)
		{
			Node newNode = new Node();
			newNode.Value = data;
			current.Next = newNode;
			current = newNode;
			count++;
		}

		public void Add_Start(object data)
		{
			Node newNode = new Node() { Value = data};
			newNode.Next = root.Next;//new node will have reference of head's next reference
			root.Next = newNode;//and now head will refer to new node
			count++;
		}

		public void Remove_Node()
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

		public void Print_Nodes()
		{
			Node curr = root;
			while (curr.Next != null)
			{
				curr = curr.Next;
				Console.Write(curr.Value);
				Console.Write("==>");
			}
			Console.Write("NULL");
		}


	}
}
