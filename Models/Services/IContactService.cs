using Laboratorium1.Controllers;
using Laboratorium1.Migrations;

namespace Laboratorium1.Models.Services;

public interface IContactService
{
    void Add(ContactModel contact);
    void Update(ContactModel contact);
    void Delete(int id);
    List<ContactModel> GetAll();
    ContactModel? GetById(int id);

    List<OrganizationEntity> FindAllOrganizations();

}