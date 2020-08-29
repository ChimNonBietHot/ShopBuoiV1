using ShopBuoi.Data.Infrastructure;
using ShopBuoi.Model.Models;

namespace ShopBuoi.Data.Repositories
{
    public interface IPostTagRepository : IRepository<PostTag>
    {
    }
    public class PostTagRepository : RepositoryBase<PostTag>, IPostTagRepository
    {
        public PostTagRepository(IDbFactory dbFactory) : base(dbFactory)
        {
        }
    }
}
