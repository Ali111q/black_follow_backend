
using AutoMapper;
using BackEndStructuer.DATA.DTOs;
using BackEndStructuer.Entities;
using BackEndStructuer.Repository;
using BackEndStructuer.Services;

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
    throw new NotImplementedException();
      
}

public async Task<(List<ServiceDto> services, int? totalCount, string? error)> GetAll(ServiceFilter filter)
    {
        throw new NotImplementedException();
    }

public async Task<(Service? service, string? error)> Update(Guid id ,ServiceUpdate serviceUpdate)
    {
        throw new NotImplementedException();
      
    }

public async Task<(Service? service, string? error)> Delete(Guid id)
    {
        throw new NotImplementedException();
   
    }

}
