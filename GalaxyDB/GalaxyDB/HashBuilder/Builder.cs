using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.IO;
using Newtonsoft.Json;

namespace GalaxyDB.HashBuilder
{
    public class Builder
    {
        private static readonly string fileName = ".\\DB.json";
        private static Dictionary<string, object> CategoryHash = new Dictionary<string, object>();

        public void AddCategory(string category)
        {
            try
            {
                CategoryHash.Add(category, new object());
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public void DeleteCategory(string category)
        {
            try
            {
                CategoryHash.Remove(category);
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
                CategoryHash = JsonConvert.DeserializeObject<Dictionary<string, object>>(json);
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
                var jsonOfHash = JsonConvert.SerializeObject(CategoryHash);
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
