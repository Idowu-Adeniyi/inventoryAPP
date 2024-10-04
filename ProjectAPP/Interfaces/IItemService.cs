using ProjectAPP.DTOs;
using ProjectAPP.Models;

namespace ProjectAPP.Interfaces
{
    public interface IItemService
    {
        Task<IEnumerable<Item>> GetAllItemsAsync();  // Declares a method to fetch all items asynchronously, returning an enumerable list of Item objects.
        Task<Item?> GetItemByIdAsync(int id);  // Declares a method to fetch a specific item by its ID asynchronously, returning an Item object or null if not found.
        Task<Item> AddItemAsync(ItemDto itemDto); // Declares a method to add a new item asynchronously using an ItemDto object, returning the added Item.
        Task<Item?> UpdateItemAsync(int id, ItemDto itemDto); // Declares a method to update an existing item asynchronously using an ItemDto object, returning the updated Item or null if not found.
        Task<bool> DeleteItemAsync(int id);  // Declares a method to delete a specific item asynchronously by its ID, returning a boolean to indicate whether the deletion was successful.
    }
}
