using System.ComponentModel.DataAnnotations;

namespace StronaAzure.Models;

public class Client
{
    public int Id { get; set; }

    [Required]
    [StringLength(100)]
    [Display(Name = "Imię")]
    public string FirstName { get; set; } = string.Empty;

    [Required]
    [StringLength(100)]
    [Display(Name = "Nazwisko")]
    public string LastName { get; set; } = string.Empty;

    [Range(0, 120)]
    [Display(Name = "Wiek")]
    public int Age { get; set; }
}
