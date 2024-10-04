using ProjectAPP.DTOs;
using System.Collections.Generic;
using System.Threading.Tasks;

public interface ISupplierService
{
    Task<IEnumerable<SupplierDto>> GetAllSuppliersAsync(); // Declares the `ISupplierService` interface, which defines the contract for all supplier-related services.
    Task<SupplierDto> GetSupplierByIdAsync(int id); // Declares a method to fetch a specific supplier by its ID asynchronously, returning a SupplierDto object.
    Task<SupplierDto> AddSupplierAsync(SupplierDto supplier); // Declares a method to add a new supplier asynchronously using a SupplierDto object, returning the added SupplierDto.
    Task<SupplierDto> UpdateSupplierAsync(int id, SupplierDto supplier);  // Declares a method to update an existing supplier asynchronously using a SupplierDto object, returning the updated SupplierDto.
    Task<bool> DeleteSupplierAsync(int id);  // Declares a method to delete a specific supplier asynchronously by its ID, returning a boolean indicating whether the deletion was successful.
}
