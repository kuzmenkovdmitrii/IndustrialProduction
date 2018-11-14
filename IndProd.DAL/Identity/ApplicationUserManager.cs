using IndProd.DAL.Domain;
using Microsoft.AspNet.Identity;

namespace IndProd.DAL.Identity
{
    public class ApplicationUserManager : UserManager<User>
    {
        public ApplicationUserManager(IUserStore<User> store)
            : base(store)
        {
        }
    }
}
