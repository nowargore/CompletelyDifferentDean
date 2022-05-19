using AutoMapper;
using CompletelyDifferentDean.Database.Repositories;
using CompletelyDifferentDean.Dto.Disciplines;
using CompletelyDifferentDean.Model;
using DotNetCore.EntityFrameworkCore;
using DotNetCore.Objects;
using DotNetCore.Results;
using Microsoft.AspNetCore.Identity;

namespace CompletelyDifferentDean.Application.Services;

public class DisciplineService : IDisciplineService
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly UserManager<IdentityUser> _userManager;
    private readonly IDisciplineRepository _disciplineRepository;
    private readonly DisciplineValidator _disciplineValidator;
    private readonly IMapper _mapper;

    public DisciplineService
    (
        IUnitOfWork unitOfWork,
        UserManager<IdentityUser> userManager,
        IDisciplineRepository disciplineRepository,
        DisciplineValidator disciplineValidator,
        IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _userManager = userManager;
        _disciplineRepository = disciplineRepository;
        _disciplineValidator = disciplineValidator;
        _mapper = mapper;
    }

    public async Task<IResult<int>> AddAsync(DisciplineCreateUpdateDto model)
    {
        var validation = _disciplineValidator.Validate(model);
        if (!validation.IsValid)
        {
            return Result<int>.Fail(validation.ToString());
        }

        var discipline = _mapper.Map<Discipline>(model);

        await _disciplineRepository.AddAsync(discipline);
        await _unitOfWork.SaveChangesAsync();

        return model.Id.Success();
    }

    public async Task<IResult> DeleteAsync(int id)
    {
        await _disciplineRepository.DeleteAsync(id);
        await _unitOfWork.SaveChangesAsync();
        
        return Result.Success();
    }

    public async Task<DisciplineDetailsDto?> GetAsync(int id)
    {
        var discipline = await _disciplineRepository.GetAsync(id);
        if (discipline is null)
        {
            return null;
        }
       
        var detailsDto = _mapper.Map<DisciplineDetailsDto>(discipline);
        
        return await detailsDto.MakeReadableLastModifiedBy(_userManager);
    }

    public async Task<DisciplineCreateUpdateDto?> GetForEditAsync(int id)
    {
        var discipline = await _disciplineRepository.GetAsync(id);
        if (discipline is null)
        {
            return null;
        }

        return _mapper.Map<DisciplineCreateUpdateDto>(discipline);
    }

    public Task<Grid<DisciplineListDto>> GridAsync(GridParameters parameters)
    {
        return _disciplineRepository.GridDtoAsync(parameters);
    }

    public Task<IEnumerable<DisciplineListDto>> ListAsync()
    {
        return _disciplineRepository.ListDtoAsync();
    }

    public async Task<IResult> UpdateAsync(DisciplineCreateUpdateDto model)
    {
        var validation = _disciplineValidator.Validate(model);
        if (!validation.IsValid)
        {
            return Result.Fail(validation.ToString());
        }

        var discipline = await _disciplineRepository.GetAsync(model.Id);
        if (discipline is null)
        {
            return Result.Success();
        }

        _mapper.Map(model, discipline);

        await _disciplineRepository.UpdateAsync(discipline);
        await _unitOfWork.SaveChangesAsync();

        return Result.Success();
    }

    public async Task<bool> ExistsAsync(int id)
    {
        return await _disciplineRepository.AnyAsync(x => x.Id == id);
    }
}
