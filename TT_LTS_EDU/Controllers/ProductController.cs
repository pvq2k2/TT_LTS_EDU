using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using QuanLyTrungTam_API.Helper;
using TT_LTS_EDU.Handle.Request.ProductRequest;
using TT_LTS_EDU.Services.Interface;

namespace TT_LTS_EDU.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
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
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> GetProductByID(int productID)
        {
            return Ok(await _productService.GetProductByID(productID));
        }

        [HttpGet("GetProductByIDAndUpdateView")]
        public async Task<IActionResult> GetProductByIDAndUpdateView(int productID)
        {
            return Ok(await _productService.GetProductByIDAndUpdateView(productID));
        }

        [HttpGet("GetRelatedProducts")]
        public async Task<IActionResult> GetRelatedProducts(int productID)
        {
            return Ok(await _productService.GetRelatedProducts(productID));
        }

        [HttpPost("CreateProduct")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> CreateProduct([FromForm] CreateProductRequest request)
        {
            return Ok(await _productService.CreateProduct(request));
        }

        [HttpPut("UpdateProduct")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> UpdateProduct(int productID, [FromForm] UpdateProductRequest request)
        {
            return Ok(await _productService.UpdateProduct(productID, request));
        }

        [HttpDelete("RemoveProduct")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> RemoveProduct(int productID)
        {
            return Ok(await _productService.RemoveProduct(productID));
        }
    }
}
