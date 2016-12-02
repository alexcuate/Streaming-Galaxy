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
			var tags2 = new SLinkedList<string>();
			tags2.Append("Agentes");
			tags2.Append("Matar");

			db.AddMovie(new Common.Movie
				{
					Category = "Action",
					Name = "007",
					Tags = tags2
				});
			var tags3 = new SLinkedList<string>();
			tags3.Append("Agentes");
			tags3.Append("Matar");

			db.AddMovie(new Common.Movie
				{
					Category = "Action",
					Name = "Mision Imposible",
					Tags = tags3
				});	

			db.Recomendacion ("Action","007",1);

	

            //db.SaveDB();

            //db.GetDB();
        }
    }
}
