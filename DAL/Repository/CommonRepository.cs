using System;
using DAL.Context;

namespace DAL.Repository
{
    public abstract class CommonRepository
    {
        public ApplicationContext DB { get; set; }

        public void Save()
        {
            DB.SaveChangesAsync();
        }

        protected void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (DB != null)
                {
                    DB.Dispose();
                    DB = null;
                }
            }
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}