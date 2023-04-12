using MealOrdering.Server.Services.Infrastructure;
using MealOrdering.Shared.DTOs;
using MealOrdering.Shared.ResponseModels;
using Microsoft.AspNetCore.Mvc;

namespace MealOrdering.Server.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class SuppliersController : ControllerBase
    {
        private readonly ISupplierService _supplierService;

        public SuppliersController(ISupplierService supplierService)
        {
            _supplierService = supplierService;
        }



        [HttpGet("{id}")]
        public async Task<ServiceResponse<SupplierDTO>> GetSupplierById(Guid id)
        {
            return new ServiceResponse<SupplierDTO>()
            {
                Value = await _supplierService.GetSupplierByIdAsync(id)
            };
        }


        [HttpGet]
        public async Task<ServiceResponse<List<SupplierDTO>>> GetSuppliers()
        {
            return new ServiceResponse<List<SupplierDTO>>()
            {
                Value = await _supplierService.GetSuppliersAsync()
            };
        }


        [HttpPost]
        public async Task<ServiceResponse<SupplierDTO>> CreateSupplier(SupplierDTO supplierDTO)
        {
            return new ServiceResponse<SupplierDTO>()
            {
                Value = await _supplierService.CreateSupplierAsync(supplierDTO)
            };
        }


        [HttpPut]
        public async Task<ServiceResponse<SupplierDTO>> UpdateSupplier(SupplierDTO supplierDTO)
        {
            return new ServiceResponse<SupplierDTO>()
            {
                Value = await _supplierService.UpdateSupplierAsync(supplierDTO)
            };
        }


        [HttpDelete]
        public async Task<BaseResponse> DeleteSupplier([FromBody] Guid supplierId)
        {
            await _supplierService.DeleteSupplierAsync(supplierId);
            return new BaseResponse();
        }
    }
}
