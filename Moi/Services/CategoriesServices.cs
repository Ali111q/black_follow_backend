
using AutoMapper;
using BackEndStructuer.DATA.DTOs;
using BackEndStructuer.Entities;
using BackEndStructuer.Repository;
using BackEndStructuer.Services;
using GaragesStructure.Repository;

namespace BackEndStructuer.Services;


public interface ICategoriesServices
{
Task<(Categories? categories, string? error)> Create(CategoriesForm categoriesForm );
Task<(List<CategoriesDto> categoriess, int? totalCount, string? error)> GetAll(CategoriesFilter filter);
Task<(Categories? categories, string? error)> Update(Guid id , CategoriesUpdate categoriesUpdate);
Task<(Categories? categories, string? error)> Delete(Guid id);
}

public class CategoriesServices : ICategoriesServices
{
private readonly IMapper _mapper;
private readonly IRepositoryWrapper _repositoryWrapper;

public CategoriesServices(
    IMapper mapper ,
    IRepositoryWrapper repositoryWrapper
    )
{
    _mapper = mapper;
    _repositoryWrapper = repositoryWrapper;
}
   
   
public async Task<(Categories? categories, string? error)> Create(CategoriesForm categoriesForm )
{
    throw new NotImplementedException();
      
}

public async Task<(List<CategoriesDto> categoriess, int? totalCount, string? error)> GetAll(CategoriesFilter filter)
    {
        throw new NotImplementedException();
    }

public async Task<(Categories? categories, string? error)> Update(Guid id ,CategoriesUpdate categoriesUpdate)
    {
        throw new NotImplementedException();
      
    }

public async Task<(Categories? categories, string? error)> Delete(Guid id)
    {
        throw new NotImplementedException();
   
    }

}
