using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using QuanLyTrungTam_API.Helper;
using TT_LTS_EDU.Handle.Request.ProductRequest;
using TT_LTS_EDU.Services.Interface;

namespace TT_LTS_EDU.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    //[Authorize(Roles = "Admin")]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _productService;

        public ProductController(IProductService productService)
        {
            _productService = productService;
        }

        [HttpPost("GetAllProduct")]
        public async Task<IActionResult> GetAllProduct(Pagination pagination)
        {
            return Ok(await _productService.GetAllProduct(pagination));
        }

        [HttpGet("GetProductByID")]
        public async Task<IActionResult> GetProductByID(int productID)
        {
            return Ok(await _productService.GetProductByID(productID));
        }

        [HttpPost("CreateProduct")]
        public async Task<IActionResult> CreateProduct([FromForm] CreateProductRequest request)
        {
            return Ok(await _productService.CreateProduct(request));
        }

        [HttpPut("UpdateProduct")]
        public async Task<IActionResult> UpdateProduct(int productID, [FromForm] UpdateProductRequest request)
        {
            return Ok(await _productService.UpdateProduct(productID, request));
        }

        [HttpDelete("RemoveProduct")]
        public async Task<IActionResult> RemoveProduct(int productID)
        {
            return Ok(await _productService.RemoveProduct(productID));
        }
    }
}
