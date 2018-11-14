using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IndProd.DAL.Context;
using IndProd.DAL.Domain;
using IndProd.DAL.Repository.Interface;
using Microsoft.AspNet.Identity.EntityFramework;

namespace IndProd.DAL.Identity
{
    public class IdentityUnitOfWork : IUnitOfWork
    {
        private IdentityContext db;

        private ApplicationUserManager userManager;
        private ApplicationRoleManager roleManager;
        private IUserRepository userRepository;

        public IdentityUnitOfWork()
        {
            db = new IdentityContext();
            userManager = new ApplicationUserManager(new UserStore<User>(db));
            roleManager = new ApplicationRoleManager(new RoleStore<ApplicationRole>(db));
            userRepository = new UserRepository(db);
        }

        public ApplicationUserManager UserManager
        {
            get { return userManager; }
        }

        public IUserRepository UserRepository
        {
            get { return userRepository; }
        }

        public ApplicationRoleManager RoleManager
        {
            get { return roleManager; }
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
                    userManager.Dispose();
                    roleManager.Dispose();
                    userRepository.Dispose();
                }
                this.disposed = true;
            }
        }
    }
}
