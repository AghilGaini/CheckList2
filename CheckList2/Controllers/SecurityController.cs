using CheckList2.Filters;
using Domain.DTO.Security;
using Domain.Interfaces;
using Domain.Model;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Threading.Tasks;
using CoreServices;

namespace CheckList2.Controllers
{
    [Authorize]
    public class SecurityController : Controller
    {
        private readonly IUnitOfWork _context;

        public SecurityController(IUnitOfWork context)
        {
            _context = context;
        }

        [CustomAuthorization(PermisionManager.Permisions.Security_Users_HTTPGet, "")]
        [HttpGet]
        public async Task<IActionResult> Users()
        {
            var usersInfo = new UserDTO();

            usersInfo.Users.AddRange(await _context._user.GetAllDTOAsync());


            usersInfo.Actions.Add(new ActionItem() { Title = "ویرایش", Action = "EditRole", Controller = "Security" });
            usersInfo.Actions.Add(new ActionItem() { Title = "مدیریت نقش", Action = "UserRole", Controller = "Security" });
            usersInfo.Actions.Add(new ActionItem() { Title = "حذف", Action = "DeleteRole", Controller = "Security" });

            return View(usersInfo);
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
        public async Task<IActionResult> Permisions(PermisionDTO model)
        {
            var role = await _context._role.GetByIdAsync(model.RoleId);
            if (role == null)
            {
                ModelState.AddModelError("", "نقشی پیدا نشد");
                return View(model);
            }

            if (await _context._rolePermision.DeletePermisionsByRoleIdAsync(model.RoleId))
            {
                var newRolePermisions = new PermisionDTO();
                foreach (var item in model.Permisions)
                {
                    if (item.IsSelected)
                        newRolePermisions.Permisions.Add(item);
                }
                newRolePermisions.RoleId = model.RoleId;

                if (await _context._rolePermision.InsertRolePermisionDTOAsync(newRolePermisions))
                {
                    _context.Complete();
                    return RedirectToAction("Roles", "Security");
                }


            }


            return RedirectToAction("index", "home");
        }


        [HttpGet]
        public async Task<IActionResult> UserRole(long Id)
        {
            var res = new UserRoleDTO();

            res.Roles.AddRange(await _context._role.GetAllDTOAsync());
            res.UserId = Id;

            var user = await _context._user.GetByIdAsync(Id);
            if (user == null)
            {
                ModelState.AddModelError("", "کاربری پیدا نشد");
                return View(user);
            }

            var userRoleId = await _context._userRole.GetAllRolesIdByUserIDAsync(Id);

            foreach (var item in res.Roles)
            {
                if (userRoleId.Any(r => r == item.Id))
                    item.IsSelected = true;
            }

            ViewBag.UserTitle = user.Username;

            return View(res);

        }

        [HttpPost]
        public async Task<IActionResult> UserRole(UserRoleDTO model)
        {
            var user = await _context._user.GetByIdAsync(model.UserId);
            if (user == null)
            {
                ModelState.AddModelError("", "کاربری پیدا نشد");
                return View(model);
            }

            if (await _context._userRole.DeleteRolesByUserIdAsync(model.UserId))
            {
                var newUserRoles = new UserRoleDTO();
                foreach (var item in model.Roles)
                {
                    if (item.IsSelected)
                        newUserRoles.Roles.Add(item);
                }
                newUserRoles.UserId = model.UserId;

                if (await _context._userRole.InsertUserRoleDTOAsync(newUserRoles))
                {
                    _context.Complete();
                    return RedirectToAction("Users", "Security");
                }
            }

            return View(model);
        }


    }
}
