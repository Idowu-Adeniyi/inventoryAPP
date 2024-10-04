using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ProjectAPP.Data;
using ProjectAPP.DTOs;
using ProjectAPP.Models;

public class SupplierService : ISupplierService
{
    private readonly ApplicationDbContext _context;

    public SupplierService(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<SupplierDto>> GetAllSuppliersAsync()
    {
        return await _context.Suppliers
            .Select(s => new SupplierDto { SupplierId = s.SupplierId, SupplierName = s.SupplierName, SupplierInfo = s.SupplierInfo })
            .ToListAsync();
    }

    public async Task<SupplierDto> GetSupplierByIdAsync(int id)
    {
        var supplier = await _context.Suppliers.FindAsync(id);
        if (supplier == null) return null;
        return new SupplierDto { SupplierId = supplier.SupplierId, SupplierName = supplier.SupplierName, SupplierInfo = supplier.SupplierInfo };
    }

    public async Task<SupplierDto> AddSupplierAsync(SupplierDto supplierDto)
    {
        var supplier = new Supplier { SupplierName = supplierDto.SupplierName, SupplierInfo = supplierDto.SupplierInfo };
        _context.Suppliers.Add(supplier);
        await _context.SaveChangesAsync();
        supplierDto.SupplierId = supplier.SupplierId;
        return supplierDto;
    }

    public async Task<SupplierDto> UpdateSupplierAsync(int id, SupplierDto supplierDto)
    {
        var supplier = await _context.Suppliers.FindAsync(id);
        if (supplier == null) return null;

        supplier.SupplierName = supplierDto.SupplierName;
        supplier.SupplierInfo = supplierDto.SupplierInfo;
        await _context.SaveChangesAsync();

        return supplierDto;
    }

    public async Task<bool> DeleteSupplierAsync(int id)
    {
        var supplier = await _context.Suppliers.FindAsync(id);
        if (supplier == null) return false;

        _context.Suppliers.Remove(supplier);
        await _context.SaveChangesAsync();
        return true;
    }
}

