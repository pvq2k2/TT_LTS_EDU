using TT_LTS_EDU.Handle.Converter;
using TT_LTS_EDU.Helpers.DBContext;

namespace TT_LTS_EDU.Services.Implement
{
    public class BaseService
    {
        protected readonly AppDbContext _context;
        protected readonly AuthConverter _authConverter;
        protected readonly ProductTypeConverter _productTypeConverter;
        protected readonly ProductConverter _productConverter;
        protected readonly DecentralizationConverter _decentralizationConverter;
        protected readonly ProductImageConverter _productImageConverter;
        protected readonly ProductReviewConverter _productReviewConverter;
        protected readonly CartConverter _cartConverter;
        public BaseService() {
            _context = new AppDbContext();
            _authConverter = new AuthConverter();
            _productTypeConverter = new ProductTypeConverter();
            _productConverter = new ProductConverter();
            _decentralizationConverter = new DecentralizationConverter();
            _productImageConverter = new ProductImageConverter();
            _productReviewConverter = new ProductReviewConverter();
            _cartConverter = new CartConverter();
        }
    }
}
