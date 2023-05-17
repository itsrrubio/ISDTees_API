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
    public class SpecsController : ApiController
    {
        [HttpGet]
        public IHttpActionResult GetSpec(int id)
        {
            try
            {
                //We use the using statement because it will opent the connection string and once
                //everything is done executing it will close it.
                using (var context = new AppDBContext())
                {
                    var spec = context.Specs.FirstOrDefault(n => n.Id == id);
                    if (spec == null) return NotFound();
                    return Ok(spec);
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
                //throw;  we comment this out so that our application won't stop
            }

        }

        [HttpGet]
        public IHttpActionResult GetSpecs()
        {
            try
            {
                //We use the using statement because it will opent the connection string and once
                //everything is done executing it will close it.
                using (var context = new AppDBContext())
                {
                    var specs = context.Specs.ToList();
                    return Ok(specs);
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
                //throw;  we comment this out so that our application won't stop
            }

        }

        [HttpPost]
        public IHttpActionResult PostSpec([FromBody] Spec spec)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);
            try
            {
                using (var context = new AppDBContext())
                {
                    context.Specs.Add(spec);
                    context.SaveChanges();

                    return Ok("Spec was created!");
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut]
        public IHttpActionResult UpdateSpec(int id, [FromBody] Spec spec)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);
            if (id != spec.Id) return BadRequest();

            try
            {
                using (var context = new AppDBContext())
                {
                    var oldSpec = context.Specs.FirstOrDefault(n => n.Id == id);
                    if (oldSpec == null) return NotFound();

                    oldSpec.SpecID = spec.SpecID;
                    oldSpec.SizeName = spec.SizeName;
                    oldSpec.SizeOrder  = spec.SizeOrder;
                    oldSpec.SpecName = spec.SpecName;
                    oldSpec.Value = spec.Value;

                    context.SaveChanges();
                    return Ok("Spec updated!");
                }
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }

        }

        [HttpDelete]
        public IHttpActionResult DeleteSpec(int id)
        {
            try
            {
                using (var context = new AppDBContext())
                {
                    var spec = context.Specs.FirstOrDefault(n => n.Id == id);
                    if (spec == null) return NotFound();

                    context.Specs.Remove(spec);
                    context.SaveChanges();

                    return Ok("Spec deleted.");
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
