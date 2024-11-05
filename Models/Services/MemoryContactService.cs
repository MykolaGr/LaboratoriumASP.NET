using Laboratorium1.Controllers;

namespace Laboratorium1.Models.Services;

public class MemoryContactService: IContactService
{
    
    private  Dictionary<int, ContactModel> _contacts = new ()
    {
        {
            1,
            new ContactModel
            {
                Id = 1, Email = "st@wsei.edu.pl", FirstName = "Adam", LastName = "Johnson", Category = Category.Family,
                PhoneNumber = "123 432 543",
            }
        },
        {
            2,
            new ContactModel
            {
                Id = 2, Email = "abcd@wsei.edu.pl", FirstName = "John", LastName = "Doe", Category = Category.Business,
                PhoneNumber = "898 432 543",
            }
        },
        {
            3,
            new ContactModel
            {
                Id = 3, Email = "qwerasd@wsei.edu.pl", FirstName = "Dave", LastName = "Green", Category = Category.Friend,
                PhoneNumber = "124 474 543",
            }
        }
    };
    private static int _currentId = 3;

    public void Add(ContactModel model)
    {
        model.Id = ++_currentId;
        _contacts.Add(model.Id, model);
    }
    public void Update(ContactModel contact)
    {
        if (_contacts.ContainsKey(contact.Id))
        {
            _contacts[contact.Id] = contact;
        }
    }
    
    public void Delete(int id)
    {
        _contacts.Remove(id);
    }

    public List<ContactModel> GetAll()
    {
        return _contacts.Values.ToList();
    }

    public ContactModel? GetById(int id)
    {
        return _contacts[id];
    }
}

