using System.ComponentModel.DataAnnotations;

namespace Persistence.Entities;

public partial class Employee
{
    [Required]
    public int IdEmployee { get; set; }

    [Required]
    public string MiddleName { get; set; } = null!;

    [Required]
    public string Name { get; set; } = null!;

    [Required]
    public string LastName { get; set; } = null!;
    
    public int? IdBranch { get; set; }

    public int? IdDepartment { get; set; }

    public int? Code { get; set; }
}
