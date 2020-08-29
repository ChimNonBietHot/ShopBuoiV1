using ShopBuoi.Data.Infrastructure;
using ShopBuoi.Model.Models;

namespace ShopBuoi.Data.Repositories
{
    public interface ISlideRepository : IRepository<Slide>
    {
    }
    public class SlideRepository : RepositoryBase<Slide>, ISlideRepository
    {
        public SlideRepository(IDbFactory dbFactory) : base(dbFactory)
        {
        }
    }
}
