namespace ProjectAPP.Services
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.EntityFrameworkCore;
    using ProjectAPP.Data;
    using ProjectAPP.DTOs;
    using ProjectAPP.Models;

    public class FitnessEquipmentService
    {
        private readonly ApplicationDbContext _context;

        public FitnessEquipmentService(ApplicationDbContext context)
        {
            _context = context;
        }

        // Get all fitness equipment with optional filters
        public async Task<List<FitnessEquipmentDTO>> GetFitnessEquipmentsAsync(string searchTerm, string category, string supplier)
        {
            var query = _context.FitnessEquipments.AsQueryable();

            if (!string.IsNullOrEmpty(searchTerm))
            {
                query = query.Where(e => e.ItemName.Contains(searchTerm));
            }
            if (!string.IsNullOrEmpty(category))
            {
                query = query.Where(e => e.Category == category);
            }
            if (!string.IsNullOrEmpty(supplier))
            {
                query = query.Where(e => e.Supplier == supplier);
            }

            var equipments = await query.ToListAsync();

            return equipments.Select(e => new FitnessEquipmentDTO
            {
                Id = e.Id,
                ItemName = e.ItemName,
                Quantity = e.Quantity,
                Category = e.Category,
                Supplier = e.Supplier
            }).ToList();
        }

        // Fetch fitness equipment by supplier
        public async Task<List<FitnessEquipmentDTO>> GetItemsBySupplierAsync(string supplier)
        {
            var equipments = await _context.FitnessEquipments
                .Where(e => e.Supplier == supplier)
                .ToListAsync();

            return equipments.Select(e => new FitnessEquipmentDTO
            {
                Id = e.Id,
                ItemName = e.ItemName,
                Quantity = e.Quantity,
                Category = e.Category,
                Supplier = e.Supplier
            }).ToList();
        }

        // Fetch fitness equipment by category
        public async Task<List<FitnessEquipmentDTO>> GetItemsByCategoryAsync(string category)
        {
            var equipments = await _context.FitnessEquipments
                .Where(e => e.Category == category)
                .ToListAsync();

            return equipments.Select(e => new FitnessEquipmentDTO
            {
                Id = e.Id,
                ItemName = e.ItemName,
                Quantity = e.Quantity,
                Category = e.Category,
                Supplier = e.Supplier
            }).ToList();
        }

        // Add a new fitness equipment
        public async Task<FitnessEquipment> AddFitnessEquipmentAsync(FitnessEquipmentDTO equipmentDto)
        {
            var equipment = new FitnessEquipment
            {
                ItemName = equipmentDto.ItemName,
                Quantity = equipmentDto.Quantity,
                Category = equipmentDto.Category,
                Supplier = equipmentDto.Supplier
            };

            _context.FitnessEquipments.Add(equipment);
            await _context.SaveChangesAsync();

            return equipment;
        }

        // Update an existing fitness equipment
        public async Task<FitnessEquipment> UpdateFitnessEquipmentAsync(int id, FitnessEquipmentDTO equipmentDto)
        {
            var equipment = await _context.FitnessEquipments.FindAsync(id);

            if (equipment != null)
            {
                equipment.ItemName = equipmentDto.ItemName;
                equipment.Quantity = equipmentDto.Quantity;
                equipment.Category = equipmentDto.Category;
                equipment.Supplier = equipmentDto.Supplier;

                await _context.SaveChangesAsync();
            }

            return equipment;
        }

        // Delete a fitness equipment
        public async Task<bool> DeleteFitnessEquipmentAsync(int id)
        {
            var equipment = await _context.FitnessEquipments.FindAsync(id);

            if (equipment != null)
            {
                _context.FitnessEquipments.Remove(equipment);
                await _context.SaveChangesAsync();
                return true;
            }

            return false;
        }
    }
}
