using System.ComponentModel.DataAnnotations;

namespace OldWest.Ui.Models;

public class User
{
    [Display(Name = "First name")]
    [Required(ErrorMessage = "Required")]
    public string FirstName { get; set; } = null!;

    [Display(Name = "Last name")]
    [Required(ErrorMessage = "Required")]
    public string LastName { get; set; } = null!;

    [Required(ErrorMessage = "Required")]
    [EmailAddress(ErrorMessage = "Invalid Email Address.")]
    public string Email { get; set; } = null!;

    [Required(ErrorMessage = "Required")]
    [Phone]
    public string? Phone { get; set; }
}