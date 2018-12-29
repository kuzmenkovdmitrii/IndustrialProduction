using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using BLL.Infrastructure;
using Common.Entities;
using DAL.Context;
using Microsoft.AspNet.Identity;
using Ninject.Infrastructure.Language;

namespace BLL.Service
{
    public class UserService : IUserService
    {
        IUnitOfWork DB { get; }

        public UserService(IUnitOfWork db)
        {
            DB = db;
        }

        public IEnumerable<User> GetAll()
        {
            return DB.UserManager.Users;
        }

        public User Get(string id)
        {
            User user = DB.UserManager.Users.
                        Include(x=>x.Orders).
                        FirstOrDefault(x => x.Id == id);

            if (user != null)
            {
                //var orders = DB.OrderRepository.List();
                user.Orders = DB.OrderRepository.List().Where(x => x.User.Id == id).ToList();
                return user;
            }

            return null;
        }

        public async Task<OperationDetails> Create(User user)
        {
            user.Orders = new List<Order>();
            var checkUser = await DB.UserManager.FindByNameAsync(user.UserName);
            if (checkUser == null)
            {

                //var role1 = new Role { Name = "user" };
                //var role2 = new Role { Name = "admin" };

                //await DB.RoleManager.CreateAsync(role1);
                //await DB.RoleManager.CreateAsync(role2);

                var result = await DB.UserManager.CreateAsync(user, user.Password);

                await DB.UserManager.AddToRoleAsync(user.Id, "user");
                await DB.UserManager.AddToRoleAsync(user.Id, "admin");

                //await DB.UserManager.SignInAsync(user, isPersistent: false, rememberBrowser: false);


                return new OperationDetails(true, "Регистрация успешно пройдена");
            }
            else
            {
                return new OperationDetails(false, "Пользователь с таким логином уже существует", "Email");
            }
        }

        public async Task<ClaimsIdentity> Authenticate(User user)
        {
            ClaimsIdentity claim = null;
            var findUser = await DB.UserManager.FindAsync(user.UserName, user.Password);

            if (findUser != null)
            {
                claim = await DB.UserManager.CreateIdentityAsync(findUser,
                    DefaultAuthenticationTypes.ApplicationCookie);
            }

            return claim;
        }

       
    }
}
