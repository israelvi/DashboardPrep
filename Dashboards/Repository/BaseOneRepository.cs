using System;
using Dashboards.Repository.Entities;

namespace Dashboards.Repository
{
    public abstract class BaseOneRepository : IDisposable
    {
        protected readonly DbEntities DbEntities;

        public DbEntities Db
        {
            get
            {
                return DbEntities;
            }
        }

        protected BaseOneRepository()
        {
            DbEntities = new DbEntities();
        }
        protected BaseOneRepository(DbEntities dbEntities)
        {
            DbEntities = dbEntities;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (DbEntities != null)
                    DbEntities.Dispose();
            }
        }
    }
}
