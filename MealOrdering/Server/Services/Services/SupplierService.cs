using AutoMapper;
using AutoMapper.QueryableExtensions;
using MealOrdering.Server.Data.Contexts;
using MealOrdering.Server.Data.Models;
using MealOrdering.Server.Services.Infrastructure;
using MealOrdering.Shared.DTOs;
using Microsoft.EntityFrameworkCore;

namespace MealOrdering.Server.Services.Services
{
    public class SupplierService : ISupplierService
    {
        private readonly MealOrderingDbContext _context;
        private readonly IMapper _mapper;
        public SupplierService(MealOrderingDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<List<SupplierDTO>> GetSuppliersAsync()
        {
            List<SupplierDTO> supplierDTOs = await _context.Suppliers//.Where(s => s.IsActive)
                      .ProjectTo<SupplierDTO>(_mapper.ConfigurationProvider)
                      .OrderBy(s => s.CreatedDate)
                      .ToListAsync();

            return supplierDTOs;
        }

        public async Task<SupplierDTO> CreateSupplierAsync(SupplierDTO supplierDTO)
        {
            Supplier supplier = _mapper.Map<Supplier>(supplierDTO);
            await _context.AddAsync(supplier);
            await _context.SaveChangesAsync();

            return _mapper.Map<SupplierDTO>(supplier);
        }

        public async Task<SupplierDTO> UpdateSupplierAsync(SupplierDTO supplierDTO)
        {
            Supplier supplier = await _context.Suppliers.FirstOrDefaultAsync(s => s.Id == supplierDTO.Id);
            if (supplier == null)
                throw new Exception("Restorant Bulunamadı");

            _mapper.Map(supplierDTO, supplier);
            await _context.SaveChangesAsync();

            return _mapper.Map<SupplierDTO>(supplier);
        }

        public async Task DeleteSupplierAsync(Guid supplierId)
        {
            Supplier supplier = await _context.Suppliers.FirstOrDefaultAsync(s => s.Id == supplierId);
            if (supplier == null)
                throw new Exception("Restorant bulunamadı");

            int orderCount = await _context.Suppliers.Include(s => s.Orders).Select(s => s.Orders.Count).FirstOrDefaultAsync();

            if (orderCount > 0)
                throw new Exception($"Silmeye çalıştığınız restorant için oluşturulmuş {orderCount} adet sipariş mevcut.");

            _context.Suppliers.Remove(supplier);
            await _context.SaveChangesAsync();
        }

        public async Task<SupplierDTO> GetSupplierByIdAsync(Guid id)
        {
            return await _context.Suppliers.Where(s => s.Id == id)
                      .ProjectTo<SupplierDTO>(_mapper.ConfigurationProvider)
                      .FirstOrDefaultAsync();
        }

    }
}
