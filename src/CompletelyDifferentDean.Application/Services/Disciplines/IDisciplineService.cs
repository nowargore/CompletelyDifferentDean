using CompletelyDifferentDean.Dto.Disciplines;
using DotNetCore.Objects;
using DotNetCore.Results;

namespace CompletelyDifferentDean.Application.Services;

public interface IDisciplineService
{
    Task<IResult<int>> AddAsync(DisciplineCreateUpdateDto model);

    Task<IResult> DeleteAsync(int id);

    Task<DisciplineDetailsDto?> GetAsync(int id);

    Task<DisciplineCreateUpdateDto?> GetForEditAsync(int id);

    Task<Grid<DisciplineListDto>> GridAsync(GridParameters parameters);

    Task<IEnumerable<DisciplineListDto>> ListAsync();

    Task<IResult> UpdateAsync(DisciplineCreateUpdateDto model);

    Task<bool> ExistsAsync(int id);
}
