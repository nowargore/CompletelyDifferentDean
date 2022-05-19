using AutoMapper;
using AutoMapper.QueryableExtensions;
using CompletelyDifferentDean.Dto.Disciplines;
using CompletelyDifferentDean.Model;
using DotNetCore.EntityFrameworkCore;
using DotNetCore.Objects;
using Microsoft.EntityFrameworkCore;

namespace CompletelyDifferentDean.Database.Repositories;

public class DisciplineRepository : EFRepository<Discipline>, IDisciplineRepository
{
    private readonly IMapper _mapper;

    public DisciplineRepository(AppDbContext context, IMapper mapper) : base(context)
    {
        _mapper = mapper;
    }

    public Task<DisciplineListDto?> GetDtoAsync(int id)
    {
        return Queryable
            .SingleOrDefaultAsync(Expressions.DisciplineExpression.Id(id))
            .ContinueWith(x => _mapper.Map<DisciplineListDto?>(x.Result));
    }

    public Task<Grid<DisciplineListDto>> GridDtoAsync(GridParameters parameters)
    {
        return Queryable
            .ProjectTo<DisciplineListDto>(_mapper.ConfigurationProvider)
            .GridAsync(parameters);
    }

    public async Task<IEnumerable<DisciplineListDto>> ListDtoAsync()
    {
        return await Queryable
            .ProjectTo<DisciplineListDto>(_mapper.ConfigurationProvider)
            .ToListAsync();
    }
}
