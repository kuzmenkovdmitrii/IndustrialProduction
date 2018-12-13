using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;
using BLL.Infrastructure;
using Common.Entities;

namespace BLL.Service
{
    public interface IUserService
    {
        Task<OperationDetails> Create(User user);
        Task<ClaimsIdentity> Authenticate(User user);
        User Get(string id);
        IEnumerable<User> GetAll();
    }
}
