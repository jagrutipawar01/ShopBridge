using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Shopbridge.Data.Repository.Interface;
using Shopbridge.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Shopbridge.Data.Repository
{
  public class InventoryRepository : IInventoryRepository
  {
    private readonly InventoryDbContext _inventoryContext;
    private readonly IMapper _mapper;
    public InventoryRepository(InventoryDbContext inventoryContext, IMapper mapper)
    {
      _inventoryContext = inventoryContext;
      _mapper = mapper;
    }

    public async Task<int> AddItem(ItemModel itemModel)
    {
      //var item = _mapper.Map<Items>(itemModel);

      var item = new Items()
      {
        ItemName = itemModel.Name,
        ItemDescription = itemModel.Description,
        ItemCategory = itemModel.Category,
        ItemQuantity = itemModel.Quantity,
        ItemPrice = itemModel.Price,
        ItemDiscount = itemModel.Discount,
        CountryOfOrigin = itemModel.CountryOfOrigin,
        Brand = itemModel.Brand,
      };

      await _inventoryContext.Items.AddRangeAsync(item);
      await _inventoryContext.SaveChangesAsync();
      return item.ItemID;
    }

    public async Task<List<Items>> GetAllItems()
    {
      var inventoryList = await _inventoryContext.Items.ToListAsync();
      return _mapper.Map<List<Items>>(inventoryList);
    }

    public async Task<List<Items>> GetItemsByCategory(string category)
    {
      var inventoryList = await _inventoryContext.Items.Where(x => x.ItemCategory.Equals(category)).ToListAsync();
      return _mapper.Map<List<Items>>(inventoryList);
    }

    public async Task<Items> GetItemsById(int id)
    {
      var item = await _inventoryContext.Items.FindAsync(id);
      return _mapper.Map<Items>(item);
    }

    public async Task<int> RemoveItem(int id)
    {
      var item = _inventoryContext.Items.Where(x => x.ItemID == id).FirstOrDefault();
      _inventoryContext.Items.Remove(item);
      await _inventoryContext.SaveChangesAsync();
      return item.ItemID;
    }

    public async Task UpdateItemQuantity(int itemId, ItemModel itemModel)
    {
      var item = await _inventoryContext.Items.FindAsync(itemId);
      if (item != null)
      {
        item.ItemQuantity = itemModel.Quantity;
        await _inventoryContext.SaveChangesAsync();
      }
    }
  }
}
