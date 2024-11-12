namespace Laboratorium1.Models;

public class ContactMapper
{
    public static ContactModel FromEntity(ContactEntity entity)
    {
        return new ContactModel()
        {
            Id = entity.Id,
            FirstName = entity.FirstName,
            LastName = entity.LastName,
            BirthDate = entity.BirthDate,
            PhoneNumber = entity.PhoneNumber,
            Category = entity.Category,
            Email = entity.Email,
            OrganizationId = entity.OrganizationId
        };
    }

    public static ContactEntity ToEntity(ContactModel model)
    {
        return new ContactEntity()
        {
            Id = model.Id,
            FirstName = model.FirstName,
            LastName = model.LastName,
            BirthDate = model.BirthDate,
            PhoneNumber = model.PhoneNumber,
            Category = model.Category,
            Email = model.Email,
            OrganizationId = model.OrganizationId

        };
    }
}