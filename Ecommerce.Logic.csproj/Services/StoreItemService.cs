using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ecommerce.Common.Models;
using EcommerceBackend.Logic.Interfaces;

namespace EcommerceBackend.Logic.Services
{
    public class StoreItemService : IStoreItemService
    {
        public StoreItemService() { }

        public Task<StoreItem> CreateStoreItemAsync(StoreItem item)
        {
            throw new NotImplementedException();
        }

        public Task DeleteStoreItemAsync(string id)
        {
            throw new NotImplementedException();
        }

        public Task<StoreItem> GetStoreItemAsync(string id)
        {
            throw new NotImplementedException();
        }

        public Task<StoreItem> UpdateStoreItemAsync(StoreItem item)
        {
            throw new NotImplementedException();
        }
    }
}
