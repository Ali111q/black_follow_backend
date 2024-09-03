using AutoMapper;
using BackEndStructuer.DATA.DTOs;
using BackEndStructuer.Entities;
using BackEndStructuer.Repository;
using BackEndStructuer.Services;
using GaragesStructure.DATA.DTOs.Convertors;
using GaragesStructure.DATA.DTOs.Convertors.Request;
using GaragesStructure.Repository;
using GaragesStructure.Respository.Utils;
using GaragesStructure.Services.Referances;
using Newtonsoft.Json;

namespace BackEndStructuer.Services;

//
public interface IOrderServices
{
    Task<(OrderDto? order, string? error)> Create(OrderForm orderForm, Guid id);
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


    public async Task<(OrderDto? order, string? error)> Create(OrderForm form , Guid id)
    {
        var service = await _repositoryWrapper.Service.Get(s => s.Id == form.ServiceId);
        if (service == null) return (null, "Service not found");
        var user = await _repositoryWrapper.User.Get(u => u.Id == id);
        if (user == null) return (null, "User not found");
        if (user.Balance< service.ServicePrice * form.Quantity) return (null, "Not enough balance");
        var order = new Order
        {
            ServiceId = form.ServiceId,
            UserId = id,
            Count = form.Quantity,
            Date = DateTime.Now,
            Link = form.Link,
            State = OrderState.Pending
        };

        var (orderResponse , error) = await _trendfyiqService.AddOrder(new AddOrderRequestConvertor()
        {
            service = int.Parse(service.ServiceId!),
            link = form.Link,
            quantity = form.Quantity
        });
        
        if (error != null) return (null, error);
        
        
        order.orderNumber = orderResponse!.Order;
        
        await _repositoryWrapper.Order.Add(order);
        user.Balance -=   (service.ServicePrice??0 * form.Quantity);
        await _repositoryWrapper.User.Update(user); 
        
        var orderDto = _mapper.Map<OrderDto>(order);
        var FinancialMovement = new FinancialMovement
        {
            Amount = -(service.ServicePrice??0 * form.Quantity),
            UserId = id
        };
        await _repositoryWrapper.FinancialMovement.Add(FinancialMovement);
        return (orderDto, null);
        
        
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
    
    
    // cancel   order
    
    public async Task<(Order? order, string? error)> CancelOrder(Guid id)
    {
        var order = await _repositoryWrapper.Order.Get(o => o.Id == id);
        if (order == null) return (null, "Order not found");
        
        var (cancelOrderResponse, error) = await _trendfyiqService.CancelOrder(new CancelOrderRequestConvertor()
        {
            orderIds = order.orderNumber.ToString()
        });
       
        
        if (error != null) return (null, error);
        
        order.State = OrderState.Canceled;
        await _repositoryWrapper.Order.Update(order);
        return (order, null);
        
    }
    
    public async Task<(bool? state, string? error)> CancelOrderBulk(List<Guid> ids)
    {
        var order = await _repositoryWrapper.Order.GetAll(o => ids.Contains(o.Id));
        if (order.totalCount == 0) return (null, "Order not found");
        
        var (cancelOrderResponse, error) = await _trendfyiqService.CancelOrder(new CancelOrderRequestConvertor()
        {
            orderIds = string.Join(",", order.data.Select(o => o.orderNumber))
        });
        
        if (error != null) return (null, error);
        
        foreach (var o in order.data)
        {
            o.State = OrderState.Canceled;
            await _repositoryWrapper.Order.Update(o);
        }
        
        return (true, null);
    }
    
    
    // order status
    public  async Task<(string? order, string? error)> GetOrderState(Guid id)
    {
        var order = await _repositoryWrapper.Order.Get(o => o.Id == id);
        if (order == null) return (null, "Order not found");
        
        var (orderStatusResponse, error) = await _trendfyiqService.GetOrderState(new OrderStatusRequestConvertor()
        {
            orderId = order.orderNumber
        });
        
        if (error != null) return (null, error);

        return (orderStatusResponse.Status, null);
    }
    
    
}