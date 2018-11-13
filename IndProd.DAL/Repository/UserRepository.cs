using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using IndProd.DAL.Context;
using IndProd.DAL.Domain;
using IndProd.DAL.Repository;
using IndProd.DAL.Repository.Interface;

namespace IndProd.DAL
{
    public class UserRepository : IUserRepository
    {
        public IdentityContext DB { get; set; }

        public UserRepository(IdentityContext db)
        {
            DB = db;
        }

        public IEnumerable<User> List()
        {
            return DB.Users;
        }

        public User Get(int id)
        {
            return DB.Users.Find(id);
        }

        public void Create(User item)
        {
            DB.Users.Add(item);
            Save();
        }

        public void Update(User item)
        {
            DB.Entry(item).State = EntityState.Modified;
            Save();
        }

        public void Delete(int id)
        {
            //User user = DB.Customers.FirstOrDefault((x => (x.Id == id)));
            //if (user != null)
            //{
            //    DB.Customers.Remove(user);
            //    Save();
            //}
        }

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
