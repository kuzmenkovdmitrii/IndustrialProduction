using Microsoft.AspNet.Identity.EntityFramework;

namespace IndProd.DAL.Identity
{
    public class ApplicationRole : IdentityRole
    {
        public ApplicationRole()
        {
        }

        public string Description { get; set; }
    }
}
