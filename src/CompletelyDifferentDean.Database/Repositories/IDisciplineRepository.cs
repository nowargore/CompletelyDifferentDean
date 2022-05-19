using CompletelyDifferentDean.Dto.Disciplines;
using CompletelyDifferentDean.Model;
using DotNetCore.Objects;
using DotNetCore.Repositories;

namespace CompletelyDifferentDean.Database.Repositories;

public interface IDisciplineRepository : IRepository<Discipline>
{
    Task<DisciplineListDto?> GetDtoAsync(int id);

    Task<Grid<DisciplineListDto>> GridDtoAsync(GridParameters parameters);

    Task<IEnumerable<DisciplineListDto>> ListDtoAsync();
}
