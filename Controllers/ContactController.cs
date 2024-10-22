using Laboratorium1.Models;
using Microsoft.AspNetCore.Mvc;

namespace Laboratorium1.Controllers
{
    public class Contact : Controller
    {
        static private Dictionary<int, ContactModel> _contacts = new Dictionary<int, ContactModel>()
        {
            { 1, new() { Id = 1, Email = "st@wsei.edu/pl", FirstName = "Adam", LastName = "Johnson", PhoneNumber = "1234 4321 5432 6789",} }
        };
        private static int currentId = 0;
        
        public ActionResult Index()
        {
            return View(_contacts);
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

            model.Id = ++currentId;
            _contacts.Add(model.Id, model);
            return View("Index", _contacts);
        }

        public ActionResult Delete(int id)
        {
            _contacts.Remove(id);
            return View("Index", _contacts);
        }

        public ActionResult Details(int id)
        {
            return View(_contacts[id]);
        }
    }
} 