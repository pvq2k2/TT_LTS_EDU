using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using QuanLyTrungTam_API.Helper;
using TT_LTS_EDU.Handle.Request.ProductTypeRequest;
using TT_LTS_EDU.Services.Interface;

namespace TT_LTS_EDU.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(Roles = "Admin")]
    public class ProductTypeController : ControllerBase
    {
        private readonly IProductTypeService _productTypeService;

        public ProductTypeController(IProductTypeService productTypeService)
        {
            _productTypeService = productTypeService;
        }

        [HttpPost("GetAllProductType")]
        public async Task<IActionResult> GetAllProductType(Pagination pagination)
        {
            return Ok(await _productTypeService.GetAllProductType(pagination));
        }

        [HttpGet("GetProductTypeByID")]
        public async Task<IActionResult> GetProductByID(int productID)
        {
            return Ok(await _productTypeService.GetProductTypeByID(productID));
        }

        [HttpPost("CreateProductType")]
        public async Task<IActionResult> CreateProductType([FromForm] CreateProductTypeRequest request)
        {
            return Ok(await _productTypeService.CreateProductType(request));
        }

        [HttpPut("UpdateProductType")]
        public async Task<IActionResult> UpdateProductType(int productTypeID, [FromForm] UpdateProductTypeRequest request)
        {
            return Ok(await _productTypeService.UpdateProductType(productTypeID, request));
        }

        [HttpDelete("RemoveProductType")]
        public async Task<IActionResult> RemoveProductType(int productTypeID)
        {
            return Ok(await _productTypeService.RemoveProductType(productTypeID));
        }
    }
}
