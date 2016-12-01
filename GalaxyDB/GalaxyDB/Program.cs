using System;
using System.Linq;
using System.Threading.Tasks;

using GalaxyDB.HashBuilder;
using DataStructures.Lists;

namespace GalaxyDB
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var db = new Builder();
            var tags = new SLinkedList<string>();
            tags.Append("Duro");
            tags.Append("Matar");

            db.AddMovie(new Common.Movie
            {
                Category = "Action",
                Name = "Duro de matar",
                Tags = tags
            });

            db.SaveDB();

            db.GetDB();
        }
    }
}
