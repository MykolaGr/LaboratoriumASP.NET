using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;

namespace Laboratorium1.Models;

public class ContactModel
{
    [HiddenInput]
    public int Id { get; set; }
    
    [Required(ErrorMessage = "Musisz wpisać jakieś imię!")]
    [MaxLength(length: 20, ErrorMessage = "Imię zbyt długie, wpisz mniej niż 21 znaków")]
    [Display(Name = "Imię")]
    public string FirstName { get; set; }
    
    [Required(ErrorMessage = "Musisz wpisać jakieś nazwisko!")]
    [MaxLength(length: 50, ErrorMessage = "Nazwisko zbyt długie, wpisz mniej niż 51 znaków")]
    [Display(Name = "Nazwisko")]
    public string LastName { get; set; }
    
    [EmailAddress(ErrorMessage = "Niepoprawny format adresy email!")]
    [Display(Name = "Adres e-mail")]
    public string Email { get; set; }
    
    [Display(Name = "Telefon")]
    [Phone(ErrorMessage = "Wpisz poprawny numer telefonu")]
    [RegularExpression(pattern:"\\d\\d\\d \\d\\d\\d \\d\\d\\d")]
    public string PhoneNumber { get; set; }
    
    [Display(Name = "Data urodzenia")]
    [DataType(DataType.Date)]
    public DateTime BirthDate { get; set; }
    
    [Display(Name = "Kategoria")]
    public Category Category { get; set; }
}