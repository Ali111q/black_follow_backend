using AutoMapper;
using BackEndStructuer.DATA.DTOs;
using BackEndStructuer.Entities;
using BackEndStructuer.Repository;
using BackEndStructuer.Services;
using GaragesStructure.Repository;

namespace BackEndStructuer.Services;

public interface ISubCategoryServices
{
    Task<(SubCategory? subcategory, string? error)> Create(SubCategoryForm subcategoryForm);
    Task<(List<SubCategoryDto> subcategorys, int? totalCount, string? error)> GetAll(SubCategoryFilter filter);
    Task<(SubCategory? subcategory, string? error)> Update(Guid id, SubCategoryUpdate subcategoryUpdate);
    Task<(SubCategoryByIdDto? subcategory, string? error)> GetById(Guid id);
    Task<(SubCategory? subcategory, string? error)> Delete(Guid id);
}

public class SubCategoryServices : ISubCategoryServices
{
    private readonly IMapper _mapper;
    private readonly IRepositoryWrapper _repositoryWrapper;

    public SubCategoryServices(
        IMapper mapper,
        IRepositoryWrapper repositoryWrapper
    )
    {
        _mapper = mapper;
        _repositoryWrapper = repositoryWrapper;
    }


    public async Task<(SubCategory? subcategory, string? error)> Create(SubCategoryForm subcategoryForm)
    {
        var subcategory = _mapper.Map<SubCategory>(subcategoryForm);
        subcategory = await _repositoryWrapper.SubCategory.Add(subcategory);
        if (subcategory == null) return (null, "Error creating subcategory");
        return (subcategory, null);
    }

    public async Task<(List<SubCategoryDto> subcategorys, int? totalCount, string? error)> GetAll(
        SubCategoryFilter filter)
    {
        var data = await _repositoryWrapper.SubCategory.GetAll<SubCategoryDto>(
            S => (filter.CategoriesId == null || S.CategoriesId == filter.CategoriesId) &&
                 (filter.Name == null || S.Name.Contains(filter.Name))
            ,
            filter.PageNumber, filter.PageSize, filter.Deleted);
        
        return (data.data, data.totalCount, null);
    }

    public async Task<(SubCategory? subcategory, string? error)> Update(Guid id, SubCategoryUpdate subcategoryUpdate)
    {
        var data = await _repositoryWrapper.SubCategory.GetById(id);
        var subcategory = _mapper.Map(subcategoryUpdate, data);
        subcategory = await _repositoryWrapper.SubCategory.Update(subcategory);
        return (subcategory, null);
       
    }

    public async Task<(SubCategoryByIdDto? subcategory, string? error)> GetById(Guid id)
    {
        var subcategory = await _repositoryWrapper.SubCategory.GetById(id);
        if (subcategory == null) return (null, "SubCategory not found");

        var subcategoryDto = _mapper.Map<SubCategoryByIdDto>(subcategory);
        return (subcategoryDto, null);
    }
    public async Task<(SubCategory? subcategory, string? error)> Delete(Guid id)
    {

        var subcategory = await _repositoryWrapper.SubCategory.Delete(id);
        return (subcategory, null);
    }
}