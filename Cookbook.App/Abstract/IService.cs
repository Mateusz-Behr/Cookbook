using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cookbook.App.Abstract
{
    public interface IService<T>
    {
        public List<T> Items { get; set; }
        List<T> GetAllItems();
        int AddItem(T item);
        void UpdateItem(T item);
        void RemoveItem(T item);
    }
}
