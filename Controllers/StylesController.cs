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
    public class StylesController : ApiController
    {
        [HttpGet]
        public IHttpActionResult GetStyle(int id)
        {
            try
            {
                //We use the using statement because it will opent the connection string and once
                //everything is done executing it will close it.
                using (var context = new AppDBContext())
                {
                    var style = context.Styles.FirstOrDefault(n => n.Id == id);
                    if (style == null) return NotFound();
                    return Ok(style);
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
                //throw;  we comment this out so that our application won't stop
            }

        }

        [HttpGet]
        public IHttpActionResult GetStyles()
        {
            try
            {
                //We use the using statement because it will opent the connection string and once
                //everything is done executing it will close it.
                using (var context = new AppDBContext())
                {
                    var styles = context.Styles.ToList();
                    return Ok(styles);
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
                //throw;  we comment this out so that our application won't stop
            }

        }

        [HttpPost]
        public IHttpActionResult PostStyle([FromBody] Style style)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);
            try
            {
                using (var context = new AppDBContext())
                {
                    context.Styles.Add(style);
                    context.SaveChanges();

                    return Ok("Style was created!");
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut]
        public IHttpActionResult UpdateStyle(int id, [FromBody] Style style)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);
            if (id != style.Id) return BadRequest();

            try
            {
                using (var context = new AppDBContext())
                {
                    var oldStyle = context.Styles.FirstOrDefault(n => n.Id == id);
                    if (oldStyle == null) return NotFound();

                    oldStyle.StyleID  = style.StyleID;
                    oldStyle.PartNumber = style.PartNumber;
                    oldStyle.BrandName = style.BrandName;
                    oldStyle.StyleName = style.StyleName;
                    oldStyle.UniquestyleName = style.UniquestyleName;
                    oldStyle.Title = style.Title;
                    oldStyle.BaseCategory = style.BaseCategory;
                    oldStyle.ComparableGroup = style.ComparableGroup;
                    oldStyle.CompanionGroup = style.CompanionGroup;

                    context.SaveChanges();
                    return Ok("Style updated!");
                }
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }

        }

        [HttpDelete]
        public IHttpActionResult DeleteStyle(int id)
        {
            try
            {
                using (var context = new AppDBContext())
                {
                    var style = context.Styles.FirstOrDefault(n => n.Id == id);
                    if (style == null) return NotFound();

                    context.Styles.Remove(style);
                    context.SaveChanges();

                    return Ok("Style deleted.");
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
