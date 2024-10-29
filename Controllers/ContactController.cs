using Laboratorium1.Models;
using Laboratorium1.Models.Services;
using Microsoft.AspNetCore.Mvc;

namespace Laboratorium1.Controllers
{
    public class ContactController : Controller
    {
     
        private readonly IContactService _contactService;

        public ContactController(IContactService contactService)
        {
            _contactService = contactService;
        }
        public ActionResult Index()
        {
            return View(_contactService.GetAll());
        }

        public ActionResult Add()
        {
            return View(_contactService.GetById(id));
        }

        [HttpPost]
        public ActionResult Add(ContactModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
     
            _contactService.Add(model);
            return View("Index", _contacts);
        }
        public ActionResult Edit(ContactModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            _contactService.Update(model);
            return View("Index", _contacts);
        }

        public ActionResult Delete(int id)
        {

            return View("Index", _contacts);
        }

        public ActionResult Details(int id)
        {
            return View(_contacts[id]);
        }
    }
} 