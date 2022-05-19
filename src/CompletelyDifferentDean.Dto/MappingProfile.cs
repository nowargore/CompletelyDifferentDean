using AutoMapper;
using CompletelyDifferentDean.Dto.Disciplines;
using CompletelyDifferentDean.Model;

namespace CompletelyDifferentDean.Dto;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        // Add as many of these lines as you need to map your objects
        CreateMap<Discipline, Discipline>();
        CreateMap<Discipline, DisciplineListDto>();
        CreateMap<Discipline, DisciplineDetailsDto>();
        CreateMap<Discipline, DisciplineCreateUpdateDto>();
        CreateMap<DisciplineCreateUpdateDto, Discipline>();
    }
}
