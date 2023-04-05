using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ecommerce.Common.Models;

namespace EcommerceBackend.Logic.Interfaces
{
    public interface IStoreItemService
    {
        public Task<StoreItem> GetStoreItemAsync(string id);

        public Task<StoreItem> CreateStoreItemAsync(StoreItem item);

        public Task<StoreItem> UpdateStoreItemAsync(StoreItem item);

        public Task DeleteStoreItemAsync(string id);

    }
}
