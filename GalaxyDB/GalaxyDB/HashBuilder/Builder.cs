using System;
using System.IO;
using System.Linq;
using Newtonsoft.Json;

using DataStructures.Dictionaries;
using DataStructures.Graphs;

using GalaxyDB.Common;

namespace GalaxyDB.HashBuilder
{
    public class Builder
    {
        private static readonly string fileName = ".\\DB.json";
        private static ChainedHashTable<string, UndirectedSparseGraph<MovieNode>> graphs = new ChainedHashTable<string, UndirectedSparseGraph<MovieNode>>();

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

        public bool GetDB()
        {
            try
            {
                var json = File.ReadAllText(fileName);
                graphs = JsonConvert.DeserializeObject<ChainedHashTable<string, UndirectedSparseGraph<MovieNode>>>(json);
                return true;
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
        }

        public bool SaveDB()
        {
            try
            {
                var jsonOfHash = JsonConvert.SerializeObject(graphs);
                File.WriteAllText(fileName, jsonOfHash);
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
        }
    }
}
