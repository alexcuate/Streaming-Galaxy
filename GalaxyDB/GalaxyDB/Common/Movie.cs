using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using DataStructures.Lists;

namespace GalaxyDB.Common
{
    public class Movie
    {
        public string Name { get; set; }
        public string Category { get; set; }
        public SLinkedList<string> Tags { get; set; }

        public MovieNode GetNode()
        {
            return new MovieNode
            {
                Name = this.Name,
                Tags = this.Tags
            };
        }
    }

    public class MovieNode : IComparable<MovieNode>
    {
        public string Name { get; set; }
        public SLinkedList<string> Tags { get; set; }

        public int CompareTo(MovieNode other)
        {
            if(other.Name == null)
            {
                return 1;
            }

            return Name.CompareTo(other.Name);
        }
    }
}
