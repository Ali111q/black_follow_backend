
using AutoMapper;
using BackEndStructuer.DATA.DTOs;
using BackEndStructuer.Entities;
using BackEndStructuer.Repository;
using BackEndStructuer.Services;
using GaragesStructure.Repository;

namespace BackEndStructuer.Services;


public interface IFinancialMovementServices
{
Task<(FinancialMovement? financialmovement, string? error)> Create(FinancialMovementForm financialmovementForm );
Task<(List<FinancialMovementDto> financialmovements, int? totalCount, string? error)> GetAll(FinancialMovementFilter filter);
Task<(FinancialMovement? financialmovement, string? error)> Update(Guid id , FinancialMovementUpdate financialmovementUpdate);
Task<(FinancialMovement? financialmovement, string? error)> Delete(Guid id);
}

public class FinancialMovementServices : IFinancialMovementServices
{
private readonly IMapper _mapper;
private readonly IRepositoryWrapper _repositoryWrapper;

public FinancialMovementServices(
    IMapper mapper ,
    IRepositoryWrapper repositoryWrapper
    )
{
    _mapper = mapper;
    _repositoryWrapper = repositoryWrapper;
}
   
   
public async Task<(FinancialMovement? financialmovement, string? error)> Create(FinancialMovementForm financialmovementForm )
{
    throw new NotImplementedException();
      
}

public async Task<(List<FinancialMovementDto> financialmovements, int? totalCount, string? error)> GetAll(FinancialMovementFilter filter)
{
    var (data, count) = await _repositoryWrapper.FinancialMovement.GetAll<FinancialMovementDto>(filter.PageNumber, filter.PageSize, filter.Deleted);

    return (data, count, null);


}

public async Task<(FinancialMovement? financialmovement, string? error)> Update(Guid id ,FinancialMovementUpdate financialmovementUpdate)
    {
        throw new NotImplementedException();
      
    }

public async Task<(FinancialMovement? financialmovement, string? error)> Delete(Guid id)
    {
        throw new NotImplementedException();
   
    }

}
