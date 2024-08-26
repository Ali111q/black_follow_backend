
using AutoMapper;
using BackEndStructuer.DATA.DTOs;
using BackEndStructuer.Entities;
using BackEndStructuer.Repository;
using BackEndStructuer.Services;
using GaragesStructure.Repository;

namespace BackEndStructuer.Services;


public interface IServiceServices
{
Task<(Service? service, string? error)> Create(ServiceForm serviceForm );
Task<(List<ServiceDto> services, int? totalCount, string? error)> GetAll(ServiceFilter filter);
Task<(Service? service, string? error)> Update(Guid id , ServiceUpdate serviceUpdate);
Task<(Service? service, string? error)> Delete(Guid id);
}

public class ServiceServices : IServiceServices
{
private readonly IMapper _mapper;
private readonly IRepositoryWrapper _repositoryWrapper;

public ServiceServices(
    IMapper mapper ,
    IRepositoryWrapper repositoryWrapper
    )
{
    _mapper = mapper;
    _repositoryWrapper = repositoryWrapper;
}
   
   
public async Task<(Service? service, string? error)> Create(ServiceForm serviceForm )
{
    var service = _mapper.Map<Service>(serviceForm);
    var createdService = await _repositoryWrapper.Service.Add(service);
    return (createdService, null);
}

public async Task<(List<ServiceDto> services, int? totalCount, string? error)> GetAll(ServiceFilter filter)
    {
        var (data, count) = await _repositoryWrapper.Service.GetAll<ServiceDto>(
            S=>filter.SubcategoryId == null || filter.SubcategoryId == S.SubCategoryId
            ,0, filter.PageSize, filter.Deleted);
        return (data, count, null);
    }

public async Task<(Service? service, string? error)> Update(Guid id ,ServiceUpdate serviceUpdate)
{
    var service = await _repositoryWrapper.Service.Get(s => s.Id == id);    
    if(service == null) return (null, "Service not found");
    _mapper.Map(serviceUpdate, service);
    var updatedService = await _repositoryWrapper.Service.Update(service);
    return (updatedService, null);
    
      
    }

public async Task<(Service? service, string? error)> Delete(Guid id)
    {
        var service = await _repositoryWrapper.Service.Get(s => s.Id == id);
        if(service == null) return (null, "Service not found");
        await _repositoryWrapper.Service.SoftDelete(id);
        return (service, null);
   
    }

}
