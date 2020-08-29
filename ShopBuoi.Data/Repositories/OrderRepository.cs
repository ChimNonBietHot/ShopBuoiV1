using ShopBuoi.Data.Infrastructure;
using ShopBuoi.Model.Models;

namespace ShopBuoi.Data.Repositories
{
    public interface IOrderRepository : IRepository<Order>
    {
    }
    public class OrderRepository : RepositoryBase<Order>, IOrderRepository
    {
        public OrderRepository(IDbFactory dbFactory) : base(dbFactory)
        {
        }
    }
}
