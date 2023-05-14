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
    [EnableCors("http://localhost:4200","*","*")]
    public class ProductsController : ApiController
    {
        [HttpGet]
        public IHttpActionResult GetProducts()
        {
            try
                {
                //We use the using statement because it will opent the connection string and once
                //everything is done executing it will close it.
                using (var context = new AppDBContext())
                {
                    var products = context.Products.ToList();
                    return Ok(products);
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
                //throw;  we comment this out so that our application won't stop
            }

        }

        [HttpPost]
        public IHttpActionResult PostEntry([FromBody] Product product)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);
            try {
                using (var context = new AppDBContext())
                {
                    context.Products.Add(product);
                    context.SaveChanges();

                    return Ok("Product was created!");
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }
    }
}
