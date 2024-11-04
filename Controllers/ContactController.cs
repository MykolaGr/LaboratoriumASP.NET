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
            return View();
        }
        
        [HttpPost]
        public ActionResult Add(ContactModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            _contactService.Add(model);
            return RedirectToAction(nameof(Index)); 
        }
        
        public ActionResult Edit(int id)
        {
            var contact = _contactService.GetById(id);
            if (contact == null)
            {
                return NotFound(); 
            }
            return View(contact);
        }

       
        [HttpPost]
        public ActionResult Edit(ContactModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            _contactService.Update(model);
            return RedirectToAction(nameof(Index)); 
        }

        
        public ActionResult Delete(int id)
        {
            var contact = _contactService.GetById(id);
            if (contact == null)
            {
                return NotFound(); 
            }
            return View(contact);
        }
        
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            _contactService.Delete(id);
            return RedirectToAction(nameof(Index)); 
        }
        public ActionResult Details(int id)
        {
            var contact = _contactService.GetById(id);
            if (contact == null)
            {
                return NotFound(); 
            }
            return View(contact);
        }

    }
}
