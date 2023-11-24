using Microsoft.AspNetCore.Mvc;
using exam_azure.Entities;
using exam_azure.DTOs;
using exam_azure.Models;
namespace exam_azure.Controllers
{
    [ApiController]
    [Route("/api/orders")]
    public class OrderController : Controller
    {
        private readonly DataContext _context;

        public OrderController(DataContext context) 
        {
            _context = context;
        }
        [HttpGet]
        public IActionResult Index()
        {
            List<Order> orders = _context.Orders.ToList();
            List<OrderDTO> data = new List<OrderDTO>();
            foreach (Order o in orders)
            {
                data.Add(new OrderDTO { id = o.id, item_name = o.item_name, quantity=o.quantity,delivery_time=o.delivery_time,delivery_address=o.delivery_address,contact_phone=o.contact_phone });
            }
            return Ok(data);
        }
        [HttpPost]
        public IActionResult Create(CreateOrder model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    Order data = new Order { item_name = model.item_name,quantity=model.quantity,delivery_time=model.delivery_time,delivery_address=model.delivery_address,contact_phone=model.contact_phone };
                    _context.Orders.Add(data);
                    _context.SaveChanges();
                    return Created($"get-by-id?id={data.id}",
                        new OrderDTO { id = data.id, item_name = data.item_name,quantity=data.quantity,delivery_time=data.delivery_time,delivery_address=data.delivery_address,contact_phone=data.contact_phone });
                }
                catch (Exception e)
                {
                    return BadRequest(e.Message);
                }
            }
            var msgs = ModelState.Values.SelectMany(v => v.Errors)
                .Select(v => v.ErrorMessage);
            return BadRequest(string.Join(" | ", msgs));
        }

        [HttpPut]
        public IActionResult Update(OrderDTO model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    Order order = new Order { id=model.id, delivery_time = model.delivery_time, delivery_address = model.delivery_address};
                    if (order != null)
                    {
                        _context.Orders.Update(order);
                        return NoContent();
                    }
                }
                catch (Exception e)
                {
                    return BadRequest(e.Message);

                }

            }
            return BadRequest();
        }
    }
}
