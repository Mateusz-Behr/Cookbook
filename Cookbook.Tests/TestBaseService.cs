using Cookbook.App.Common;
using Cookbook.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cookbook.Tests
{
    public class TestBaseService<T> : BaseService<T> where T : BaseEntity
    {

        public void SetFreeIds(List<int> newFreeIds)
        {
            freeIds = newFreeIds;
        }

        public void SetNextId(int newNextId)
        {
            nextId = newNextId;
        }
    }
}
