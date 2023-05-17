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
    public class CustomersController : ApiController
    {
        [HttpGet]
        public IHttpActionResult GetCustomer(int id)
        {
            try
            {
                //We use the using statement because it will opent the connection string and once
                //everything is done executing it will close it.
                using (var context = new AppDBContext())
                {
                    var customer = context.Customers.FirstOrDefault(n => n.Id == id);
                    if (customer == null) return NotFound();
                    return Ok(customer);
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
                //throw;  we comment this out so that our application won't stop
            }

        }

        [HttpGet]
        public IHttpActionResult GetCustomers()
        {
            try
            {
                //We use the using statement because it will opent the connection string and once
                //everything is done executing it will close it.
                using (var context = new AppDBContext())
                {
                    var customers = context.Customers.ToList();
                    return Ok(customers);
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
                //throw;  we comment this out so that our application won't stop
            }

        }


        [HttpPost]
        public IHttpActionResult PostCustomer([FromBody] Customer customer)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);
            try
            {
                using (var context = new AppDBContext())
                {
                    context.Customers.Add(customer);
                    context.SaveChanges();

                    return Ok("Customer was created!");
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut]
        public IHttpActionResult UpdateCustomer(int id, [FromBody] Customer customer)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);
            if (id != customer.Id) return BadRequest();

            try
            {
                using (var context = new AppDBContext())
                {
                    var oldCustomer = context.Customers.FirstOrDefault(n => n.Id == id);
                    if (oldCustomer == null) return NotFound();

                    oldCustomer.CustomerID = customer.CustomerID;
                    oldCustomer.CustomerName = customer.CustomerName;
                    oldCustomer.AddressID = customer.AddressID;

                    context.SaveChanges();
                    return Ok("Customer updated!");
                }
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }

        [HttpDelete]
        public IHttpActionResult DeleteCustomer(int id)
        {
            try
            {
                using (var context = new AppDBContext())
                {
                    var customer = context.Customers.FirstOrDefault(n => n.Id == id);
                    if (customer == null) return NotFound();

                    context.Customers.Remove(customer);
                    context.SaveChanges();

                    return Ok("Customer deleted.");
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
