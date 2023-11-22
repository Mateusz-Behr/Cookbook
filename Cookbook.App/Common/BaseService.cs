using Cookbook.App.Abstract;
using Cookbook.Domain.Common;
using Cookbook.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace Cookbook.App.Common
{
    public class BaseService<T> : IService<T> where T : BaseEntity
    {
        public List<T> Items { get; set; }
        public BaseService() 
        {
            Items = new List<T>();
        }  

        public int AddItem(T item)
        {
            Items.Add(item);
            return item.Id;
        }

        public List<T> GetAllItems()
        {
            return Items;
        }

        public void RemoveItem(T item)
        {
            Items.Remove(item);
        }

        public int UpdateItem(T item)
        {
            var entity = Items.FirstOrDefault(p => p.Id == item.Id);
            if (entity != null)
            {
                entity = item;
            }
            return entity.Id;
        }
        
        public T GetItemById(int id)
        {
            var entity = Items.FirstOrDefault(p =>p.Id == id);
            return entity;
        }
    }
}
