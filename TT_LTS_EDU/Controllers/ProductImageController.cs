using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using QuanLyTrungTam_API.Helper;
using TT_LTS_EDU.Handle.Request.ProductImageRequest;
using TT_LTS_EDU.Services.Interface;

namespace TT_LTS_EDU.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    //[Authorize(Roles = "Admin")]
    public class ProductImageController : ControllerBase
    {
        private readonly IProductImageService _productImageService;

        public ProductImageController(IProductImageService productImageService)
        {
            _productImageService = productImageService;
        }

        [HttpPost("GetAllProductImage")]
        public async Task<IActionResult> GetAllProductImage(Pagination pagination)
        {
            return Ok(await _productImageService.GetAllProductImage(pagination));
        }

        [HttpGet("GetProductImageByID")]
        public async Task<IActionResult> GetProductByID(int productID)
        {
            return Ok(await _productImageService.GetProductImageByID(productID));
        }

        [HttpPost("CreateProductImage")]
        public async Task<IActionResult> CreateProductImage([FromForm] CreateProductImageRequest request)
        {
            return Ok(await _productImageService.CreateProductImage(request));
        }

        [HttpPut("UpdateProductImage")]
        public async Task<IActionResult> UpdateProductImage(int productImageID, [FromForm] UpdateProductImageRequest request)
        {
            return Ok(await _productImageService.UpdateProductImage(productImageID, request));
        }

        [HttpDelete("RemoveProductImage")]
        public async Task<IActionResult> RemoveProductImage(int productImageID)
        {
            return Ok(await _productImageService.RemoveProductImage(productImageID));
        }
    }
}
