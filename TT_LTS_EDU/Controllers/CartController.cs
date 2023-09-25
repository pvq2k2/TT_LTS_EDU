using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TT_LTS_EDU.Handle.Request.CartRequest;
using TT_LTS_EDU.Services.Interface;

namespace TT_LTS_EDU.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class CartController : ControllerBase
    {
        private readonly ICartService _iCartService;

        public CartController(ICartService iCartService)
        {
            _iCartService = iCartService;
        }

        [HttpPost("AddToCart")]
        public async Task<IActionResult> AddToCart(AddToCartRequest request)
        {
            return Ok(await _iCartService.AddToCart(request));
        }

        [HttpGet("GetAllCartItemWhereCartExist")]
        public async Task<IActionResult> GetAllCartItemWhereCartExist()
        {
            return Ok(await _iCartService.GetAllCartItemWhereCartExist());
        }

        [HttpPatch("UpdateQuantityCartItemExistInCart")]
        public async Task<IActionResult> UpdateQuantityCartItemExistInCart(UpdateQuantityCartItemRequest request)
        {
            return Ok(await _iCartService.UpdateQuantityCartItemExistInCart(request));
        }

        [HttpDelete("RemoveCartItem")]
        public async Task<IActionResult> RemoveCartItem(int cartItemID)
        {
            return Ok(await _iCartService.RemoveCartItem(cartItemID));
        }
    }
}
