using Microsoft.AspNetCore.Mvc;
using Shopbridge.Data.Repository.Interface;
using Shopbridge.Domain.Models;
using System.Threading.Tasks;

namespace Shopbridge.Controllers
{
  [Route("api/[controller]")]
  [ApiController]
  public class ItemsController : Controller
  {
    private readonly IInventoryRepository _inventory;

    public ItemsController(IInventoryRepository invertory)
    {
      _inventory = invertory;
    }

    [HttpGet("getItems")]
    public async Task<IActionResult> GetAllItems()
    {
      var items = await _inventory.GetAllItems();
      return Ok(items);
    }

    [HttpGet("getItemByCatogory/{category}")]
    public async Task<IActionResult> GetItemsByCategory([FromRoute] string category)
    {
      var items = await _inventory.GetItemsByCategory(category);
      return Ok(items);
    }

    [HttpGet("getItemById/{id}")]
    public async Task<IActionResult> GetItemsByID([FromRoute] int id)
    {
      var item = await _inventory.GetItemsById(id);
      return Ok(item);
    }

    [HttpPost("addItem")]
    public async Task<IActionResult> AddItem([FromBody] ItemModel itemModel)
    {
      var itemsId = await _inventory.AddItem(itemModel);
      return CreatedAtAction(nameof(GetItemsByID), new { id = itemsId, controller = "items" }, itemsId);
    }

    [HttpPut("updateItem/{id}")]
    public async Task<IActionResult> UpdateItemQuantity([FromBody] ItemModel itemModel, [FromRoute] int id)
    {
      await _inventory.UpdateItemQuantity(id, itemModel);
      return Ok();
    }

    [HttpDelete("deleteItemById/{id}")]
    public async Task<IActionResult> RemoveItem([FromRoute] int id)
    {
      await _inventory.RemoveItem(id);
      return Ok();
    }
  }
}
