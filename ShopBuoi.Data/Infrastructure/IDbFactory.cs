using System;

namespace ShopBuoi.Data.Infrastructure
{
    public interface IDbFactory : IDisposable
    {
        ShopBuoiDBContext Init();
    }
}