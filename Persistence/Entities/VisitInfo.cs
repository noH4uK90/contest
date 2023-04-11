using System.ComponentModel.DataAnnotations;

namespace Persistence.Entities;

public partial class VisitInfo
{
    [Required]
    public int IdVisitInfo { get; set; }

    [Required]
    public DateTime StartDate { get; set; }

    public DateTime? EndDate { get; set; }

    [Required]
    public string Purpose { get; set; } = null!;
}
