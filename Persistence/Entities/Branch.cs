using System.ComponentModel.DataAnnotations;

namespace Persistence.Entities;

public partial class Branch
{
    [Required]
    public int IdBranch { get; set; }

    [Required]
    public string Name { get; set; } = null!;
}
