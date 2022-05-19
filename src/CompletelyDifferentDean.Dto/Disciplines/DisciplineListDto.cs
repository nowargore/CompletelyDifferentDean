﻿using System.ComponentModel.DataAnnotations;

namespace CompletelyDifferentDean.Dto.Disciplines;

public record DisciplineListDto : HasModificationTimeDto
{
    public int Id { get; init; }

    [Display(Name = "Name")]
    public string Name { get; init; } = "";

    [Display(Name = "Description")]
    public string Description { get; init; } = "";
}
