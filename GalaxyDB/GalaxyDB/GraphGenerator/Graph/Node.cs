using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GalaxyDB.GraphGenerator.Graph
{
    public class Node<T>
    {
        public T Data { get; set; }
        public List<Node<T>> AdjList { get; set; }
    }
}
