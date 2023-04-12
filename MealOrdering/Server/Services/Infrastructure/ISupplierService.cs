using MealOrdering.Shared.DTOs;

namespace MealOrdering.Server.Services.Infrastructure
{
    public interface ISupplierService
    {
        public Task<List<SupplierDTO>> GetSuppliersAsync();

        public Task<SupplierDTO> CreateSupplierAsync(SupplierDTO supplierDTO);

        public Task<SupplierDTO> UpdateSupplierAsync(SupplierDTO supplierDTO);

        public Task DeleteSupplierAsync(Guid supplierId);

        public Task<SupplierDTO> GetSupplierByIdAsync(Guid id);
    }
}
