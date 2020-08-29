using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopBuoi.Data.Infrastructure
{
    public class DbFactory : Disposable, IDbFactory
    {
        private ShopBuoiDBContext dbContext;

        public ShopBuoiDBContext Init()
        {
            return dbContext ?? (dbContext = new ShopBuoiDBContext());
        }

        protected override void DisposeCore()
        {
            if (dbContext != null)
                dbContext.Dispose();
        }
    }
}
