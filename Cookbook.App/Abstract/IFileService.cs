using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cookbook.App.Abstract
{
    public interface IFileService
    {
        List<T> LoadItemsFromJson<T>(string path);
        void SaveItemsToJson<T>(List<T> items, string path);
    }
}
