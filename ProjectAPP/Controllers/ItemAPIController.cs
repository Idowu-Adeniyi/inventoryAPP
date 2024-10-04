using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ProjectAPP.Interfaces;
using ProjectAPP.DTOs;
using ProjectAPP.Models;

namespace ProjectAPP.Controllers
{
    /// <summary>
    /// API Controller responsible for managing item-related operations via HTTP requests.
    /// It supports CRUD operations for Items.
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class ItemAPIController : ControllerBase
    {
        private readonly IItemService _itemService;


        /// <summary>
        /// Constructor for the ItemAPIController. It takes an IItemService as a dependency.
        /// </summary>
        /// <param name="itemService">An instance of IItemService injected by the DI framework.</param>
        public ItemAPIController(IItemService itemService)
        {
            _itemService = itemService;
        }

        /// <summary>
        /// HTTP GET: api/ItemAPI
        /// Retrieves a list of all items from the system.
        /// </summary>
        /// <returns>A list of ItemDto objects representing all items.</returns>
       
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ItemDto>>> GetItems()
        {
            var items = await _itemService.GetAllItemsAsync();
            return Ok(items);
        }

        /// <summary>
        /// HTTP GET: api/ItemAPI/{id}
        /// Retrieves a single item by its ID.
        /// </summary>
        // GET: api/ItemAPI/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ItemDto>> GetItem(int id)
        {
            var item = await _itemService.GetItemByIdAsync(id);

            if (item == null)
            {
                return NotFound();
            }

            // Convert item to DTO here if necessary
            var itemDto = new ItemDto
            {
                ItemId = item.ItemId,
                ItemName = item.ItemName,
                Quantity = item.Quantity,
                CategoryId = item.CategoryId,
                SupplierId = item.SupplierId
            };

            return Ok(itemDto);
        }

        /// <summary>
        /// HTTP POST: api/ItemAPI
        /// Creates a new item in the system.
        /// </summary>
        // POST: api/ItemAPI
        [HttpPost]
        public async Task<ActionResult<ItemDto>> PostItem(ItemDto itemDto)
        {
            if (itemDto == null)
            {
                return BadRequest("ItemDto cannot be null.");
            }

            var newItem = await _itemService.AddItemAsync(itemDto);
            var newItemDto = new ItemDto
            {
                ItemId = newItem.ItemId,
                ItemName = newItem.ItemName,
                Quantity = newItem.Quantity,
                CategoryId = newItem.CategoryId,
                SupplierId = newItem.SupplierId
            };

            return CreatedAtAction(nameof(GetItem), new { id = newItemDto.ItemId }, newItemDto);
        }

        /// <summary>
        /// HTTP PUT: api/ItemAPI/{id}
        /// Updates an existing item by its ID.
        /// </summary>

        // PUT: api/ItemAPI/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutItem(int id, ItemDto itemDto)
        {
            if (itemDto == null)
            {
                return BadRequest("ItemDto cannot be null.");
            }

            if (id != itemDto.ItemId)
            {
                return BadRequest("Item ID mismatch.");
            }

            var updatedItem = await _itemService.UpdateItemAsync(id, itemDto);
            if (updatedItem == null)
            {
                return NotFound();
            }

            return NoContent();
        }

        /// <summary>
        /// HTTP DELETE: api/ItemAPI/{id}
        /// Deletes an existing item by its ID.
        /// </summary>
        // DELETE: api/ItemAPI/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteItem(int id)
        {
            var result = await _itemService.DeleteItemAsync(id);
            if (!result)
            {
                return NotFound();
            }

            return NoContent();
        }
    }
}
