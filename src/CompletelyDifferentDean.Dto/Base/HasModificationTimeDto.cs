using CompletelyDifferentDean.Infrastructure.Timing;
using Humanizer;
using System.ComponentModel.DataAnnotations;

namespace CompletelyDifferentDean.Dto;

public abstract record HasModificationTimeDto
{
    [Display(Name = "Last modified")]
    public DateTime LastModified { get; init; }

    public string GetLastModifiedAsReadableText()
    {
        return LastModified.Humanize(dateToCompareAgainst: Clock.Now);
    }
}
