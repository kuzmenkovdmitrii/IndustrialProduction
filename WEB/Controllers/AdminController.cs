using System.Threading.Tasks;
using System.Web.Mvc;
using Common.Entities;
using DAL.Context;

namespace WEB.Controllers
{
    public class AdminController : Controller
    {
        IUnitOfWork DB;

        public AdminController(IUnitOfWork db)
        {
            DB = db;
        }

        public ActionResult AdminPage()
        {
            return View();
        }

        public void AddToRole(User user, Role role)
        {
            DB.UserManager.AddToRoleAsync(user.Id, role.Name);
        }

        public void CreateRole(Role role)
        {
            DB.RoleManager.CreateAsync(role);
        }
    }
}