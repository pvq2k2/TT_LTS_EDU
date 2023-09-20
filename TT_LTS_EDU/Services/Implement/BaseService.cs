using TT_LTS_EDU.Handle.Converter;
using TT_LTS_EDU.Helpers.DBContext;

namespace TT_LTS_EDU.Services.Implement
{
    public class BaseService
    {
        public readonly AppDbContext _context;
        public readonly AuthConverter _authConverter;
        public readonly ProductTypeConverter _productTypeConverter;
        public readonly ProductConverter _productConverter;
        public BaseService() {
            _context = new AppDbContext();
            _authConverter = new AuthConverter();
            _productTypeConverter = new ProductTypeConverter();
            _productConverter = new ProductConverter();
        }
    }
}
