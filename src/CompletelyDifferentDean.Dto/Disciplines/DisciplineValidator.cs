using FluentValidation;
using Microsoft.Extensions.Localization;

namespace CompletelyDifferentDean.Dto.Disciplines;

public sealed class DisciplineValidator : AbstractValidator<DisciplineCreateUpdateDto>
{
    private readonly IStringLocalizer<DtoResources> _l;

    public DisciplineValidator(IStringLocalizer<DtoResources> localizer)
    {
        _l = localizer;

        RuleFor(x => x.Name).NotEmpty().MaximumLength(1024).WithName(_l["Name"]);
        RuleFor(x => x.Description).MaximumLength(16 * 1024).WithName(_l["Description"]);
    }
}
