using Cookbook.App.Abstract;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cookbook.App.Concrete
{
    public class FileService : IFileService
    {
        public List<T> LoadItemsFromJson<T>(string path)
        {
            string jsonFile = File.ReadAllText(path);
            return JsonConvert.DeserializeObject<List<T>>(jsonFile);
        }

        public void SaveItemsToJson<T>(List<T> items, string path)
        {
            string json = JsonConvert.SerializeObject(items, Formatting.Indented);
            File.WriteAllText(path, json);
        }
    }
}
