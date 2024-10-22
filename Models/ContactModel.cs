using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;

namespace Laboratorium1.Models;

public class ContactModel
{
    [HiddenInput]
    public int Id { get; set; }
    
    [Required(ErrorMessage = "Musisz wpisać jakieś imię!")]
    [MaxLength(length: 20, ErrorMessage = "Imię zbyt długie, wpisz mniej niż 21 znaków")]
    public string FirstName { get; set; }
    
    [Required(ErrorMessage = "Musisz wpisać jakieś nazwisko!")]
    [MaxLength(length: 50, ErrorMessage = "Nazwisko zbyt długie, wpisz mniej niż 51 znaków")]
    public string LastName { get; set; }
    
    [EmailAddress(ErrorMessage = "Niepoprawny format adresy email!")]
    public string Email { get; set; }
    
    [Phone(ErrorMessage = "Wpisz poprawny numer telefonu")]
    [RegularExpression(pattern:"\\d\\d\\d \\d\\d\\d \\d\\d\\d")]
    public string PhoneNumber { get; set; }
    
    [DataType(DataType.Date)]
    public DateTime BirthDate { get; set; }
}