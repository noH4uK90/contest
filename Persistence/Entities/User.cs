using System.ComponentModel.DataAnnotations;

namespace Persistence.Entities;

public partial class User
{
    [Required]
    public int IdUser { get; set; }

    [Required]
    public string MiddleName { get; set; } = null!;

    [Required]
    public string FirstName { get; set; } = null!;

    public string? LastName { get; set; }

    public string? Login { get; set; }

    public string? Password { get; set; }

    public string? Phone { get; set; }

    [Required]
    public string Email { get; set; } = null!;

    [Required]
    public DateTime Birthsday { get; set; }

    [Required]
    public string PassportNumber { get; set; } = null!;

    [Required]
    public string PassportSeries { get; set; } = null!;

    [Required]
    public byte[]? PassportScan { get; set; }

    [Required]
    public byte[]? Photo { get; set; }

    public string? Organization { get; set; }

    public string? Note { get; set; }
}
