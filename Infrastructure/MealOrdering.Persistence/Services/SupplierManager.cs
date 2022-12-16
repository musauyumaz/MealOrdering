using MealOrdering.Application.Features.Suppliers.DTOs;
using MealOrdering.Application.Repositories.Suppliers;
using MealOrdering.Application.Services.PersistenceServices;
using Microsoft.EntityFrameworkCore;

namespace MealOrdering.Persistence.Services
{
    public class SupplierManager : ISupplierService
    {
        private readonly ISupplierRepository _supplierRepository;

        public SupplierManager(ISupplierRepository supplierRepository)
        {
            _supplierRepository = supplierRepository;
        }

        public async Task<bool> CreateSupplier(CreateSupplierDTO createSupplierDTO)
        {
            await _supplierRepository.AddAsync(new() { Name = createSupplierDTO.Name, WebURL = createSupplierDTO.WebURL });
            return await _supplierRepository.SaveAsync() > 0;
        }

        public async Task<bool> DeleteSupplierById(string id)
        {
            var supplier = await _supplierRepository.GetByIdAsync(id, true);
            if (supplier == null)
                throw new Exception("Supplier Not Found");

            _supplierRepository.Remove(supplier);
            return await _supplierRepository.SaveAsync() > 0;
        }

        public async Task<List<ListSupplierDTO>> GetAllSuppliers()
        {
            List<ListSupplierDTO> suppliers = await _supplierRepository.Table.Select(s => new ListSupplierDTO
            {
                Id = s.Id.ToString(),
                Name = s.Name,
                WebURL = s.WebURL,
            }).ToListAsync();

            return suppliers;
        }

        public async Task<SupplierDTO> GetSupplierById(string id)
        {
            var supplier = await _supplierRepository.GetByIdAsync(id);
            if (supplier != null)
                return new()
                {
                    Id = supplier.Id.ToString(),
                    Name = supplier.Name,
                    WebURL = supplier.WebURL,
                };
            else
                throw new Exception("Supplier Not Found");

        }

        public async Task<bool> UpdateSupplier(UpdateSupplierDTO updateSupplierDTO)
        {
            var supplier = await _supplierRepository.GetByIdAsync(updateSupplierDTO.Id, true);

            if (supplier == null)
                throw new Exception("Supplier Not Found");

            return _supplierRepository.Update(supplier);
        }
    }
}
