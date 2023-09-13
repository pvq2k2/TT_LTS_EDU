using TT_LTS_EDU.Handle.Converter;
using TT_LTS_EDU.Helpers.DBContext;

namespace TT_LTS_EDU.Services.Implement
{
    public class BaseService
    {
        public readonly AppDbContext _context;
        public readonly AuthConverter _authConverter;
        public BaseService() {
            _context = new AppDbContext();
            _authConverter = new AuthConverter();
        }
    }
}
