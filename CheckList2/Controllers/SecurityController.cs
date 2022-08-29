using Domain.DTO.Security;
using Domain.Interfaces;
using Domain.Model;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
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

        [HttpGet]
        public async Task<IActionResult> Permisions(long Id)
        {
            var res = new PermisionDTO();

            res.Permisions.AddRange(await _context._permision.GetAllDTOAsync());
            res.RoleId = Id;

            var role = await _context._role.GetByIdAsync(Id);
            if (role == null)
            {
                ModelState.AddModelError("", "نقشی پیدا نشد");
                return View(res);
            }

            var rolePermisionsId = await _context._rolePermision.GetAllPermisionsIdByRoleIDAsync(Id);

            foreach (var item in res.Permisions)
            {
                if (rolePermisionsId.Any(r => r == item.Id))
                    item.IsSelected = true;
            }

            ViewBag.RoleTitle = role.Title;


            return View(res);
        }

        [HttpPost]
        public IActionResult Permisions(PermisionDTO model)
        {
            return RedirectToAction("index", "home");
        }


    }
}
