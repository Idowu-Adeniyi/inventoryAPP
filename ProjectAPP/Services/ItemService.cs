using ProjectAPP.Interfaces;
using ProjectAPP.Models;
using Microsoft.EntityFrameworkCore;
using ProjectAPP.Data;
using ProjectAPP.DTOs;

namespace ProjectAPP.Services
{
    public class ItemService : IItemService
    {
        private readonly ApplicationDbContext _context;

        public ItemService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Item>> GetAllItemsAsync()
        {
            return await _context.Items.ToListAsync();
        }

        public async Task<Item?> GetItemByIdAsync(int id)
        {
            return await _context.Items.FindAsync(id);
        }

        public async Task<Item> AddItemAsync(ItemDto itemDto)
        {
            if (itemDto == null) throw new ArgumentNullException(nameof(itemDto));

            var item = new Item
            {
                ItemName = itemDto.ItemName,
                Quantity = itemDto.Quantity,
                CategoryId = itemDto.CategoryId,
                SupplierId = itemDto.SupplierId
            };

            _context.Items.Add(item);
            await _context.SaveChangesAsync();
            return item;
        }

        public async Task<Item> UpdateItemAsync(int id, ItemDto itemDto)
        {
            if (itemDto == null) throw new ArgumentNullException(nameof(itemDto));

            var existingItem = await _context.Items.FindAsync(id);
            if (existingItem == null) return null;

            existingItem.ItemName = itemDto.ItemName;
            existingItem.Quantity = itemDto.Quantity;
            existingItem.CategoryId = itemDto.CategoryId;
            existingItem.SupplierId = itemDto.SupplierId;

            await _context.SaveChangesAsync();
            return existingItem;
        }

        public async Task<bool> DeleteItemAsync(int id)
        {
            var item = await _context.Items.FindAsync(id);
            if (item == null) return false;

            _context.Items.Remove(item);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}

