using Domain.DTO.Security;
using Domain.Interfaces;
using Domain.Model;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace CheckList2.Controllers
{
    public class SecurityController : Controller
    {
        private readonly IUnitOfWork _context;

        public SecurityController(IUnitOfWork context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> Roles()
        {
            var rolesInfo = new RoleDTO();

            rolesInfo.Roles.AddRange(await _context._role.GetAllDTOAsync());


            rolesInfo.Actions.Add(new ActionItem() { Title = "ویرایش", Action = "EditRole", Controller = "Security" });
            rolesInfo.Actions.Add(new ActionItem() { Title = "مدیریت دسترسی", Action = "Permisions", Controller = "Security" });
            rolesInfo.Actions.Add(new ActionItem() { Title = "حذف", Action = "DeleteRole", Controller = "Security" });

            return View(rolesInfo);
        }
    }
}
