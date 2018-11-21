using System.Collections.Generic;
using System.Data.Entity;
using System.Security.Claims;
using System.Threading.Tasks;
using BLL.Infrastructure;
using Common.Entities;
using DAL.Identity;
using Microsoft.AspNet.Identity;

namespace BLL.Service
{
    public class UserService : IUserService
    {
        IUnitOfWork DB { get; set; }

        public UserService(IUnitOfWork db)
        {
            DB = db;
        }

        public IEnumerable<User> GetAll()
        {
            return DB.UserRepository.List();
        }

        public User Get(int id)
        {
            User user = DB.UserRepository.Get(id);

            if (user != null)
            {
                return user;
            }

            return null;
        }

        public async Task<OperationDetails> Create(User user)
        {
            var checkUser = await DB.UserManager.FindByNameAsync(user.UserName);
            if (checkUser == null)
            {

                var role1 = await DB.RoleManager.FindByNameAsync("user");
                var role2 = await DB.RoleManager.FindByNameAsync("admin");
                //if (role1 == null)
                //{
                //    role1 = new ApplicationRole { Name = "user" };
                //    await DB.RoleManager.CreateAsync(role1);
                //}
                //if (role2 == null)
                //{
                //    role2 = new ApplicationRole { Name = "admin" };
                //    await DB.RoleManager.CreateAsync(role2);
                //}

                //var role1 = new ApplicationRole { Name = "admin" };
                //var role2 = new ApplicationRole { Name = "user" };

                //DB.RoleManager.CreateAsync(role1);
                //DB.RoleManager.CreateAsync(role2);

                var result = await DB.UserManager.CreateAsync(user, user.Password);

                await DB.UserManager.AddToRoleAsync(user.Id, "user");
                await DB.UserManager.AddToRoleAsync(user.Id, "admin");

                //await DB.UserManager.SignInAsync(user, isPersistent: false, rememberBrowser: false);


                return new OperationDetails(true, "Регистрация успешно пройдена", "");
            }
            else
            {
                return new OperationDetails(false, "Пользователь с таким логином уже существует", "Email");
            }
        }

        public async Task<ClaimsIdentity> Authenticate(User user)
        {
            ClaimsIdentity claim = null;
            var findUser = await DB.UserManager.FindAsync(user.Email, user.Password);

            if (findUser != null)
            {
                claim = await DB.UserManager.CreateIdentityAsync(findUser, DefaultAuthenticationTypes.ApplicationCookie);
            }

            return claim;
        }

        public async Task SetInitialData(User admin, List<string> roles)
        {
            foreach (var roleName in roles)
            {
                var role = await DB.RoleManager.FindByNameAsync(roleName);
                if (role == null)
                {
                    role = new ApplicationRole { Name = roleName };
                    await DB.RoleManager.CreateAsync(role);
                }
            }

            await Create(admin);
        }

        public void Dispose()
        {
            DB.UserRepository.Dispose();
        }
    }
}
