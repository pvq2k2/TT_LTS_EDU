using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using QuanLyTrungTam_API.Helper;
using TT_LTS_EDU.Handle.Request.ProductReviewRequest;
using TT_LTS_EDU.Services.Interface;

namespace TT_LTS_EDU.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductReviewController : ControllerBase
    {
        private readonly IProductReviewService _productReviewService;

        public ProductReviewController(IProductReviewService productReviewService)
        {
            _productReviewService = productReviewService;
        }

        [Authorize(Roles = "Admin")]
        [HttpPost("GetAllProductReview")]
        public async Task<IActionResult> GetAllProductReview(Pagination pagination)
        {
            return Ok(await _productReviewService.GetAllProductReview(pagination));
        }

        [HttpGet("GetProductReviewByID")]
        public async Task<IActionResult> GetProductByID(int productID)
        {
            return Ok(await _productReviewService.GetProductReviewByID(productID));
        }

        [Authorize]
        [HttpPost("CreateProductReview")]
        public async Task<IActionResult> CreateProductReview(CreateProductReviewRequest request)
        {
            return Ok(await _productReviewService.CreateProductReview(request));
        }

        [Authorize]
        [HttpPut("UpdateProductReview")]
        public async Task<IActionResult> UpdateProductReview(int productReviewID, UpdateProductReviewRequest request)
        {
            return Ok(await _productReviewService.UpdateProductReview(productReviewID, request));
        }

        [Authorize]
        [HttpDelete("RemoveProductReview")]
        public async Task<IActionResult> RemoveProductReview(int productReviewID)
        {
            return Ok(await _productReviewService.RemoveProductReview(productReviewID));
        }
    }
}
