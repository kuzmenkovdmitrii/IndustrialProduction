using System;
using System.Threading.Tasks;
using Common.Entities;
using DAL.Context;
using DAL.Identity;
using DAL.Repository.Interface;
using Microsoft.AspNet.Identity.EntityFramework;

namespace DAL.Context
{
    public class UnitOfWork : IUnitOfWork
    {
        private ApplicationContext db;

        public IOrderRepository OrderRepository { get; }
        public IProductRepository ProductRepository { get; }
        public ApplicationUserManager UserManager { get; }
        public ApplicationRoleManager RoleManager { get; }

        public UnitOfWork(IOrderRepository orderRepository, IProductRepository productRepository)
        {
            db = new ApplicationContext();
            UserManager = new ApplicationUserManager(new UserStore<User>(db));
            RoleManager = new ApplicationRoleManager(new RoleStore<Role>(db));
            OrderRepository = orderRepository;
            ProductRepository = productRepository;

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
                }
                this.disposed = true;
            }
        }
    }
}
