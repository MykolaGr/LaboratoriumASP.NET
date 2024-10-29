using Laboratorium1.Controllers;

namespace Laboratorium1.Models.Services;

public interface IContactService
{
    void Add(ContactController contact);
    void Update(ContactController contact);
    void Delete(int id);
    List<ContactModel> GetAll();
    ContactModel GetById(int id);
}