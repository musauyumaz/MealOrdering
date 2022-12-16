using MealOrdering.Application.Features.Suppliers.DTOs;
using MealOrdering.Application.Services.PersistenceServices;
using Microsoft.AspNetCore.Mvc;

namespace MealOrdering.Blazor.Server.Properties
{
    [Route("api/[controller]")]
    [ApiController]
    public class SuppliersController : ControllerBase
    {
        private readonly ISupplierService _supplierService;

        public SuppliersController(ISupplierService supplierService)
        {
            _supplierService = supplierService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllSupplier()
            => Ok(await _supplierService.GetAllSuppliers());
        [HttpGet]
        public async Task<IActionResult> GetBySupplierId(string id)
            => Ok(await _supplierService.GetSupplierById(id));
        [HttpPost]
        public async Task<IActionResult> CreateSupplier(CreateSupplierDTO createSupplierDTO)
            => Ok(await _supplierService.CreateSupplier(createSupplierDTO));
        [HttpPut]
        public async Task<IActionResult> UpdateSupplier(UpdateSupplierDTO updateSupplierDTO)
            => Ok(await _supplierService.UpdateSupplier(updateSupplierDTO));
        [HttpDelete]
        public async Task<IActionResult> DeleteSupplierById(string id)
            => Ok(await _supplierService.DeleteSupplierById(id));
    }
}
