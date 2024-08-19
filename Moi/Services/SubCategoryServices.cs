
using AutoMapper;
using BackEndStructuer.DATA.DTOs;
using BackEndStructuer.Entities;
using BackEndStructuer.Repository;
using BackEndStructuer.Services;
using GaragesStructure.Repository;

namespace BackEndStructuer.Services;


public interface ISubCategoryServices
{
Task<(SubCategory? subcategory, string? error)> Create(SubCategoryForm subcategoryForm );
Task<(List<SubCategoryDto> subcategorys, int? totalCount, string? error)> GetAll(SubCategoryFilter filter);
Task<(SubCategory? subcategory, string? error)> Update(Guid id , SubCategoryUpdate subcategoryUpdate);
Task<(SubCategory? subcategory, string? error)> Delete(Guid id);
}

public class SubCategoryServices : ISubCategoryServices
{
private readonly IMapper _mapper;
private readonly IRepositoryWrapper _repositoryWrapper;

public SubCategoryServices(
    IMapper mapper ,
    IRepositoryWrapper repositoryWrapper
    )
{
    _mapper = mapper;
    _repositoryWrapper = repositoryWrapper;
}
   
   
public async Task<(SubCategory? subcategory, string? error)> Create(SubCategoryForm subcategoryForm )
{
    throw new NotImplementedException();
      
}

public async Task<(List<SubCategoryDto> subcategorys, int? totalCount, string? error)> GetAll(SubCategoryFilter filter)
    {
        throw new NotImplementedException();
    }

public async Task<(SubCategory? subcategory, string? error)> Update(Guid id ,SubCategoryUpdate subcategoryUpdate)
    {
        throw new NotImplementedException();
      
    }

public async Task<(SubCategory? subcategory, string? error)> Delete(Guid id)
    {
        throw new NotImplementedException();
   
    }

}
