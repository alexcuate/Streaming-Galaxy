using GalaxyDB.Generics.Lists;

namespace GalaxyDB.Generics
{
    public class List<T>
    {
        private LinkedListNode<T> First;

        public void Add(T node)
        {
            if (First == null)
            {
                First = new LinkedListNode<T>
                {
                    Value = node,
                    NextNode = null
                };
            }
            else
            {
                var newNode = new LinkedListNode<T>
                {
                    Value = node,
                    NextNode = First
                };

                First = newNode;
            }
        }
        public void Remove(T node)
        {
            var tempNode = Find(node);

        }
        
        public LinkedListNode<T> Find(T node)
        {
            if (First != null)
            {
                var temp = First;
                do
                {
                    if (temp.Value.Equals(node))
                    {
                        return temp;
                    }
                    else
                    {
                        temp = temp.NextNode;
                    }
                } while (temp != null);
                return null;
            }
            return null;
        }
    }
}
