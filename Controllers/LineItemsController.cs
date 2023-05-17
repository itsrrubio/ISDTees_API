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
    public class LineItemsController : ApiController
    {
        [HttpGet]
        public IHttpActionResult GetLineItem(int id)
        {
            try
            {
                //We use the using statement because it will opent the connection string and once
                //everything is done executing it will close it.
                using (var context = new AppDBContext())
                {
                    var lineItem = context.LineItems.FirstOrDefault(n => n.Id == id);
                    if (lineItem == null) return NotFound();
                    return Ok(lineItem);
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
                //throw;  we comment this out so that our application won't stop
            }

        }

        [HttpGet]
        public IHttpActionResult GetLineItems()
        {
            try
            {
                //We use the using statement because it will opent the connection string and once
                //everything is done executing it will close it.
                using (var context = new AppDBContext())
                {
                    var lineItems = context.LineItems.ToList();
                    return Ok(lineItems);
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
                //throw;  we comment this out so that our application won't stop
            }

        }

        [HttpPost]
        public IHttpActionResult PostLineItem([FromBody] LineItem lineItem)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);
            try
            {
                using (var context = new AppDBContext())
                {
                    context.LineItems.Add(lineItem);
                    context.SaveChanges();

                    return Ok("Line item was created!");
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut]
        public IHttpActionResult UpdateLineItem(int id, [FromBody] LineItem lineItem)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);
            if (id != lineItem.Id) return BadRequest();

            try
            {
                using (var context = new AppDBContext())
                {
                    var oldLineItem = context.LineItems.FirstOrDefault(n => n.Id == id);
                    if (oldLineItem == null) return NotFound();

                    oldLineItem.LineItemID = lineItem.LineItemID;
                    oldLineItem.ProductID = lineItem.ProductID;
                    oldLineItem.Description = lineItem.Description;
                    oldLineItem.Price = lineItem.Price;

                    context.SaveChanges();
                    return Ok("Line item updated!");
                }
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }

        [HttpDelete]
        public IHttpActionResult DeleteLineItem(int id)
        {
            try
            {
                using (var context = new AppDBContext())
                {
                    var lineItem = context.LineItems.FirstOrDefault(n => n.Id == id);
                    if (lineItem == null) return NotFound();

                    context.LineItems.Remove(lineItem);
                    context.SaveChanges();

                    return Ok("Line Item deleted.");
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
