﻿using Cookbook.App.Abstract;
using Cookbook.Domain.Common;
using Cookbook.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace Cookbook.App.Common
{
    public class BaseService<T> : IService<T> where T : BaseEntity
    {
        public List<T> Items { get; set; }

        protected int nextId = 1;
        protected List<int> freeIds = new();

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
        
        public T GetItemById(int id)
        {
            var entity = Items.FirstOrDefault(p =>p.Id == id);
            return entity;
        }

        public int GetFreeId()
        {
            int searchedId;

            if (freeIds.Count > 0)
            {
                searchedId = freeIds[0];
                freeIds.RemoveAt(0);
                return searchedId;
            }
            else
            {
                searchedId = nextId;
                nextId++;
                return searchedId;
            }
        }
    }
}
