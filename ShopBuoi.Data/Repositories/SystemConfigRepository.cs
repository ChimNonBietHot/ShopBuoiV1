using ShopBuoi.Data.Infrastructure;
using ShopBuoi.Model.Models;

namespace ShopBuoi.Data.Repositories
{
    public interface ISystemConfigRepository: IRepository<SystemConfig>
    {
    }
    public class SystemConfigRepository : RepositoryBase<SystemConfig>, ISystemConfigRepository
    {
        public SystemConfigRepository(IDbFactory dbFactory) : base(dbFactory)
        {
        }
    }
}
