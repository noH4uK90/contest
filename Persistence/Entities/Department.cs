using System.ComponentModel.DataAnnotations;

namespace Persistence.Entities;

public partial class Department
{
    [Required]
    public int IdDepartment { get; set; }

    [Required]
    public string Name { get; set; } = null!;
}
