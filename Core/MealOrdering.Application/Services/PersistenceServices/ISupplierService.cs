using MealOrdering.Application.Features.Suppliers.DTOs;

namespace MealOrdering.Application.Services.PersistenceServices
{
    public interface ISupplierService
    {
        Task<List<ListSupplierDTO>> GetAllSuppliers();
        Task<SupplierDTO> GetSupplierById(string id);
        Task<bool> CreateSupplier(CreateSupplierDTO createSupplierDTO);
        Task<bool> UpdateSupplier(UpdateSupplierDTO updateSupplierDTO);
        Task<bool> DeleteSupplierById(string id);

    }

}
