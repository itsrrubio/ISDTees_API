using ISDTees_API.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace ISDTees_API.Controllers
{
    public class ProductsController : ApiController
    {
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
    }
}
