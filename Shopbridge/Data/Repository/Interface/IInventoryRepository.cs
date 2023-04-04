using Shopbridge.Domain.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Shopbridge.Data.Repository.Interface
{
    public interface IInventoryRepository
    {
        Task<int> AddItem(ItemModel item);
        Task<int> RemoveItem(int id);
        Task UpdateItemQuantity(int id, ItemModel item);
        Task<List<Items>> GetItemsByCategory(string category);
        Task<List<Items>> GetAllItems();
        Task<Items> GetItemsById(int id);
    }
}
