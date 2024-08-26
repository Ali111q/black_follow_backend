using AutoMapper;
using BackEndStructuer.DATA.DTOs;
using BackEndStructuer.Entities;
using BackEndStructuer.Repository;
using BackEndStructuer.Services;
using GaragesStructure.DATA.DTOs.Convertors;
using GaragesStructure.DATA.DTOs.Convertors.Request;
using GaragesStructure.Repository;
using GaragesStructure.Services.Referances;
using Newtonsoft.Json;

namespace BackEndStructuer.Services;

//
public interface IOrderServices
{
    Task<(List<ServiceResponseConvertor>? order, string? error)> Create(OrderForm orderForm, Guid id);
    Task<(List<OrderDto> orders, int? totalCount, string? error)> GetAll(OrderFilter filter);
    Task<(Order? order, string? error)> Update(Guid id, OrderUpdate orderUpdate);
    Task<(Order? order, string? error)> Delete(Guid id);
}

public class OrderServices : IOrderServices
{
    private readonly IMapper _mapper;
    private readonly IRepositoryWrapper _repositoryWrapper;
    private readonly HttpClient _httpClient;
    private readonly ITrendfyiqService _trendfyiqService;


    public OrderServices(
        IMapper mapper,
        IRepositoryWrapper repositoryWrapper,
        HttpClient httpClient,
        ITrendfyiqService trendfyiqService
    )
    {
        _mapper = mapper;
        _repositoryWrapper = repositoryWrapper;
        _httpClient = httpClient;
        _trendfyiqService = trendfyiqService;
    }


    public async Task<(List<ServiceResponseConvertor>? order, string? error)> Create(OrderForm form , Guid id)
    {
        var (order , error)  = await _trendfyiqService.GetService(new ServiceRequestConvertor());
        return (order, null);
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

    public async Task<(Order? order, string? error)> Update(Guid id, OrderUpdate orderUpdate)
    {
        throw new NotImplementedException();
    }

    public async Task<(Order? order, string? error)> Delete(Guid id)
    {
        throw new NotImplementedException();
    }
}