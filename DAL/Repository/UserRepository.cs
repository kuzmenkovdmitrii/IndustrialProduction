using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using AutoMapper;
using Common.Entities;
using DAL.Context;
using DAL.Repository.Interface;

namespace DAL.Repository
{
    public class UserRepository : IUserRepository
    {
        public ApplicationContext DB { get; set; }

        public UserRepository(ApplicationContext db)
        {
            DB = db;
        }

        public IEnumerable<User> List()
        {
            Mapper.Initialize(x => x.CreateMap<User, User>());
            //return Mapper.Map<IEnumerable<ApplicationUser>, IEnumerable<User>>(DB.Users);
            return DB.Users;
        }

        public User Get(int id)
        {
            //return Mapper.Map<ApplicationUser, User>(DB.Users.Find(id));
            return DB.Users.Find(id);
        }

        public void Create(User item)
        {
            //DB.Users.Add(Mapper.Map<User, ApplicationUser>(item));
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
            throw new NotImplementedException();
        }

        public void Delete(string id)
        {
            var user = DB.Users.FirstOrDefault(x => x.Id == id);
            if (user != null)
            {
                DB.Users.Remove(user);
                Save();
            }
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
