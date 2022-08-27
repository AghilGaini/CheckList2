using Domain.DTO.Home;
using Domain.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Domain.Model;
namespace CheckList2.Controllers
{
    public class HomeController : Controller
    {
        private readonly IUnitOfWork _context;

        public HomeController(IUnitOfWork context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var res = new PersonDTO();
            res.PersonInfos.AddRange(await _context._person.GetAllDTOAsync());

            res.Actions.Add(new ActionItem() { Title = "Update", Action = "UpdatePerson", Controller = "home" });
            res.Actions.Add(new ActionItem() { Title = "Delete", Action = "Delete", Controller = "home" });

            return View(res);
        }

        [HttpGet]
        public async Task<IActionResult> UpdatePerson(long id)
        {
            var oldPerson = await _context._person.GetByIdAsync(id);

            if (oldPerson == null)
            {
                ModelState.AddModelError("", "شخصی پیدا نشد");
                return View();
            }

            var res = new UpdatePersonDTO()
            {
                Id = id,
                Name = oldPerson.Name,
            };

            return View(res);
        }

        [HttpPost]
        public async Task<IActionResult> UpdatePerson(UpdatePersonDTO model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var oldPerson = await _context._person.GetByIdAsync(model.Id);

            if (oldPerson == null)
            {
                ModelState.AddModelError("", "شخصی پیدا نشد");
                return View(model);
            }

            if (await _context._person.UpdatePersonDTOAsync(model))
            {
                _context.Complete();
                return RedirectToAction("Index", "Home");
            }

            return View(model);


        }

    }
}
