using System;
using System.IO;
using System.Linq;

using DataStructures.Dictionaries;
using DataStructures.Graphs;

using GalaxyDB.Common;

namespace GalaxyDB.HashBuilder
{
    public class Builder
    {
        private static ChainedHashTable<string, UndirectedSparseGraph<MovieNode>> graphs = new ChainedHashTable<string, UndirectedSparseGraph<MovieNode>>();



		public bool RemoveMovie(Movie movie)
        {
            if (graphs.ContainsKey(movie.Category))
            {
                var graph = graphs[movie.Category];
                var movieNode = new MovieNode
                {
                    Name = movie.Name,
                    Tags = movie.Tags
                };

                var neighbours = graph.Neighbours(movieNode);
                if(neighbours.Count > 0)
                {
                    foreach (var neighbour in neighbours)
                    {
                        graph.RemoveEdge(movieNode, neighbour);
                    }
                    var removed = graph.RemoveVertex(movieNode);
                    return removed;
                }
                else
                {
                    var removed = graph.RemoveVertex(movieNode);
                    return removed;
                }
            }
            else
            {
                return false;
            }
        }

        public void AddMovie(Movie movie)
        {
            if (graphs.ContainsKey(movie.Category))
            {
                var graph = graphs[movie.Category];
                var newNode = movie.GetNode();
                graph.AddVertex(newNode);
                var nodes = graph.BreadthFirstWalk();
                foreach (var node in nodes)
                {
                    var resultingTags = newNode.Tags.Intersect(node.Tags);
                    if(resultingTags.Count() > 0)
                    {
                        graph.AddEdge(newNode, node);
                    }
                }
            }
            else
            {
                var graph = new UndirectedSparseGraph<MovieNode>();
                graph.AddVertex(movie.GetNode());
                graphs.Add(movie.Category, graph);
            }
        }

		public void Recomendacion(String categoria,String movie,int precision)
		{
			var graph = graphs[categoria];
			var nodes = graph.BreadthFirstWalk();

			foreach (var node in nodes) {
				if(node.Name.Equals(movie)){
					Console.WriteLine ("Si hay una nodo " + movie);
					foreach (var node2 in nodes) {
						var resultingTags = node.Tags.Intersect(node2.Tags);
						if(resultingTags.Count()>=precision){
							Console.WriteLine ("Esta Pelicula te podria gustar: "+ node2.Name);
						}

					}

				}
			}
		}

        private void AddCategory(string category)
        {
            try
            {
                graphs.Add(category, new UndirectedSparseGraph<MovieNode>());
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        private void DeleteCategory(string category)
        {
            try
            {
                graphs.Remove(category);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }


    }
}
