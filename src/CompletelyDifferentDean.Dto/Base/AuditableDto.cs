using System.ComponentModel.DataAnnotations;

namespace CompletelyDifferentDean.Dto;

public abstract record AuditableDto: HasModificationTimeDto
{
    [Display(Name = "Last modified by")]
    public string LastModifiedBy { get; set; } = "";
}
