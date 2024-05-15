using SupermarketApp.Model.DataAccessLayer.DataContext;

namespace SupermarketApp.Model.DataAccessLayer.Repository
{
    public class BaseRepository
    {
        protected readonly SupermarketDbContext _context;

        public BaseRepository(SupermarketDbContext context)
        {
            _context = context;
        }
    }
}
