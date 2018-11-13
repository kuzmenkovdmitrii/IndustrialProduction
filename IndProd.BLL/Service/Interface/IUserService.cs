using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;
using IndProd.BLL.DTO;
using IndProd.BLL.Infrastructure;

namespace IndProd.BLL.Service.Interface
{
    public interface IUserService : IDisposable
    {
        Task<OperationDetails> Create(UserDTO userDto);
        Task<ClaimsIdentity> Authenticate(UserDTO userDto);
        Task SetInitialData(UserDTO adminDto, List<string> roles);
    }
}
