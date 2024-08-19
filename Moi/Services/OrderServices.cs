
using AutoMapper;
using BackEndStructuer.DATA.DTOs;
using BackEndStructuer.Entities;
using BackEndStructuer.Repository;
using BackEndStructuer.Services;
using GaragesStructure.Repository;
using Newtonsoft.Json;

namespace BackEndStructuer.Services;


//
public interface IOrderServices
{
Task<(Order? order, string? error)> Create(OrderForm orderForm );
Task<(List<OrderDto> orders, int? totalCount, string? error)> GetAll(OrderFilter filter);
Task<(Order? order, string? error)> Update(Guid id , OrderUpdate orderUpdate);
Task<(Order? order, string? error)> Delete(Guid id);
}

public class OrderServices : IOrderServices
{
private readonly IMapper _mapper;
private readonly IRepositoryWrapper _repositoryWrapper;
private readonly HttpClient _httpClient;


public OrderServices(
    IMapper mapper ,
    IRepositoryWrapper repositoryWrapper,
        HttpClient httpClient
    )
{
    _mapper = mapper;
    _repositoryWrapper = repositoryWrapper;
    _httpClient = httpClient;

}
   
   
public async Task<(Order? order, string? error)> Create(OrderForm orderForm )
{
    throw new NotImplementedException();
      
}

public async Task CreateOrderAsync(Order order)
{
    var json = JsonConvert.SerializeObject(order);
    var content = new StringContent(json, System.Text.Encoding.UTF8, "application/json");
    await _httpClient.PostAsync("https://trendfyiq.com/api/orders", content);
}

public async Task<(List<OrderDto> orders, int? totalCount, string? error)> GetAll(OrderFilter filter)
    {
        throw new NotImplementedException();
    }

public async Task<(Order? order, string? error)> Update(Guid id ,OrderUpdate orderUpdate)
    {
        throw new NotImplementedException();
      
    }

public async Task<(Order? order, string? error)> Delete(Guid id)
    {
        throw new NotImplementedException();
   
    }

}
