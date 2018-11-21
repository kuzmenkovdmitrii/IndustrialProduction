using System;
using System.Threading.Tasks;
using Common.Entities;
using DAL.Context;
using DAL.Repository;
using DAL.Repository.Interface;
using Microsoft.AspNet.Identity.EntityFramework;

namespace DAL.Identity
{
    public class UnitOfWork : IUnitOfWork
    {
        private ApplicationContext db;

        public ApplicationUserManager UserManager { get; }
        public ApplicationRoleManager RoleManager { get; }
        public IUserRepository UserRepository { get; }

        public UnitOfWork()
        {
            db = new ApplicationContext();
            UserManager = new ApplicationUserManager(new UserStore<User>(db));
            RoleManager = new ApplicationRoleManager(new RoleStore<ApplicationRole>(db));
            UserRepository = new UserRepository(db);
        }

        public async Task SaveAsync()
        {
            await db.SaveChangesAsync();
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
        private bool disposed = false;

        public virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    UserManager.Dispose();
                    RoleManager.Dispose();
                    UserRepository.Dispose();
                }
                this.disposed = true;
            }
        }
    }
}
