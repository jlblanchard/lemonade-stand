using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using api.Models;
using api.dto;

namespace api.Controllers;

[ApiController]
[Route("api/order")]
public class OrderController : ControllerBase
{
    private readonly ILogger<OrderController> _logger;
    private readonly LemonadeContext _context;

    public OrderController(ILogger<OrderController> logger, LemonadeContext context)
    {
        _logger = logger;
        _context = context;
    }

    [HttpPost(Name = "PostOrder")]
    public async Task<ActionResult<int>> Post(OrderDTO order)
    {
        Order newOrder = new Order();
        newOrder.Id = order.Id;
        newOrder.Name = order.Name;
        newOrder.Email = order.Email;
        newOrder.Phone = order.Phone;
        newOrder.Total = order.Total;

        _context.Order.Add(newOrder);
        
        await _context.SaveChangesAsync();

        foreach (var item in order.Items)
        {
            item.OrderId = newOrder.Id;
            _context.OrderItem.Add(item);
        }

        await _context.SaveChangesAsync();

        return newOrder.Id;
    }
}