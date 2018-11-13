using System.Collections.Generic;
using System.Data.Entity.Validation;
using System.Security.Claims;
using System.Threading.Tasks;
using AutoMapper;
using IndProd.BLL.DTO;
using IndProd.BLL.Infrastructure;
using IndProd.BLL.Service.Interface;
using IndProd.DAL.Domain;
using IndProd.DAL.Identity;
using Microsoft.AspNet.Identity;

namespace IndProd.BLL.Service
{
    public class UserService : IUserService
    {
        IUnitOfWork DB { get; set; }

        public UserService(IUnitOfWork db)
        {
            DB = db;
        }

        public IEnumerable<UserDTO> GetAll()
        {
            Mapper.Initialize(cfg => cfg.CreateMap<User, UserDTO>());
            return Mapper.Map<IEnumerable<User>, List<UserDTO>>(DB.UserRepository.List());
        }

        public UserDTO Get(int id)
        {
            User user = DB.UserRepository.Get(id);

            if (user != null)
            {
                return Mapper.Map<User, UserDTO>(user);
            }

            return null;
        }

        public async Task<OperationDetails> Create(UserDTO userDto)
        {
            var checkUser = await DB.UserManager.FindByEmailAsync(userDto.Email);
            if (checkUser == null)
            {
                var user = new ApplicationUser()
                {
                    Email = userDto.Email,
                    UserName = userDto.UserName,
                    FirstName = userDto.FirstName,
                    LastName = userDto.LastName,
                };

                var result = await DB.UserManager.CreateAsync(user, userDto.Password);

                await DB.UserManager.AddToRoleAsync(user.Id, userDto.Role);

                return new OperationDetails(true, "Регистрация успешно пройдена", "");
            }
            else
            {
                return new OperationDetails(false, "Пользователь с таким логином уже существует", "Email");
            }
        }

        public async Task<ClaimsIdentity> Authenticate(UserDTO userDto)
        {
            ClaimsIdentity claim = null;
            var user = await DB.UserManager.FindAsync(userDto.Email, userDto.Password);

            if (user != null)
            {
                claim = await DB.UserManager.CreateIdentityAsync(user, DefaultAuthenticationTypes.ApplicationCookie);
            }

            return claim;
        }

        public async Task SetInitialData(UserDTO adminDto, List<string> roles)
        {
            foreach (string roleName in roles)
            {
                var role = await DB.RoleManager.FindByNameAsync(roleName);
                if (role == null)
                {
                    role = new ApplicationRole {Name = roleName};
                    await DB.RoleManager.CreateAsync(role);
                }
            }

            await Create(adminDto);
        }

        public void Dispose()
        {
            DB.UserRepository.Dispose();
        }
    }
}