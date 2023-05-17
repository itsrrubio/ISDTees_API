using ISDTees_API.Data;
using ISDTees_API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;

namespace ISDTees_API.Controllers
{
    [EnableCors("http://localhost:4200", "*", "*")]
    public class OrdersController : ApiController
    {
        [HttpGet]
        public IHttpActionResult GetOrder(int id)
        {
            try
            {
                //We use the using statement because it will opent the connection string and once
                //everything is done executing it will close it.
                using (var context = new AppDBContext())
                {
                    var order = context.Orders.FirstOrDefault(n => n.Id == id);
                    if (order == null) return NotFound();
                    return Ok(order);
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
                //throw;  we comment this out so that our application won't stop
            }

        }

        [HttpGet]
        public IHttpActionResult GetOrders()
        {
            try
            {
                //We use the using statement because it will opent the connection string and once
                //everything is done executing it will close it.
                using (var context = new AppDBContext())
                {
                    var orders = context.Orders.ToList();
                    return Ok(orders);
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
                //throw;  we comment this out so that our application won't stop
            }

        }

        [HttpPost]
        public IHttpActionResult PostOrder([FromBody] Order order)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);
            try
            {
                using (var context = new AppDBContext())
                {
                    context.Orders.Add(order);
                    context.SaveChanges();

                    return Ok("Order was created!");
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut]
        public IHttpActionResult UpdateOrder(int id, [FromBody] Order order)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);
            if (id != order.Id) return BadRequest();

            try
            {
                using (var context = new AppDBContext())
                {
                    var oldOrder = context.Orders.FirstOrDefault(n => n.Id == id);
                    if (oldOrder == null) return NotFound();

                    oldOrder.OrderNo  = order.OrderNo;
                    oldOrder.OrderName  = order.OrderName;
                    oldOrder.CustomerID  = order.CustomerID;
                    oldOrder.ContactName = order.ContactName;
                    oldOrder.OrderDate = order.OrderDate;
                    oldOrder.OrderNotes = order.OrderNotes;
                    oldOrder.SubTotal = order.SubTotal;
                    oldOrder.Tax = order.Tax;
                    oldOrder.Total = order.Total;

                    context.SaveChanges();
                    return Ok("Order updated!");
                }
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }

        }

        [HttpDelete]
        public IHttpActionResult DeleteOrder(int id)
        {
            try
            {
                using (var context = new AppDBContext())
                {
                    var order = context.Orders.FirstOrDefault(n => n.Id == id);
                    if (order == null) return NotFound();

                    context.Orders.Remove(order);
                    context.SaveChanges();

                    return Ok("Order deleted.");
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

    }
}
