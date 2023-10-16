
using Microsoft.AspNetCore.Mvc;
using UnitOfShop.Data;
using UnitOfShop.Models;
using UnitOfShop.Repositories;

namespace UnitOfShop.Controllers
{

    [ApiController]
    [Route("v1/orders")]
    public class OrderController : ControllerBase
    {

        [HttpPost]
        [Route("")]
        public Order Post([FromServices] ICustomerRepository customerRepository,
        [FromServices] IOrderRepository orderRepository,
        [FromServices] IUnitOfWork uow)
        {
            try
            {
                var customer = new Customer { Name = "Lucas Baltavaz " };
                var order = new Order { Number = "21", Customer = customer };

                customerRepository.Save(customer);
                orderRepository.Save(order);

                uow.Commit();

                return order;

            }
            catch
            {

                uow.Rollback();
                return null;
            }
        }
    }
}