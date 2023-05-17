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
    public class ConfigsController : ApiController
    {
        [HttpGet]
        public IHttpActionResult GetConfig(int id)
        {
            try
            {
                //We use the using statement because it will opent the connection string and once
                //everything is done executing it will close it.
                using (var context = new AppDBContext())
                {
                    var config = context.Configs.FirstOrDefault(n => n.Id == id);
                    if (config == null) return NotFound();
                    return Ok(config);
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
                //throw;  we comment this out so that our application won't stop
            }

        }

        [HttpGet]
        public IHttpActionResult GetConfigs()
        {
            try
            {
                //We use the using statement because it will opent the connection string and once
                //everything is done executing it will close it.
                using (var context = new AppDBContext())
                {
                    var configs = context.Configs.ToList();
                    return Ok(configs);
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
                //throw;  we comment this out so that our application won't stop
            }

        }

        [HttpPost]
        public IHttpActionResult PostConfig([FromBody] Config config)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);
            try
            {
                using (var context = new AppDBContext())
                {
                    context.Configs.Add(config);
                    context.SaveChanges();

                    return Ok("Config was created!");
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut]
        public IHttpActionResult UpdateConfig(int id, [FromBody] Config config)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);
            if (id != config.Id) return BadRequest();

            try
            {
                using (var context = new AppDBContext())
                {
                    var oldConfig = context.Configs.FirstOrDefault(n => n.Id == id);
                    if (oldConfig == null) return NotFound();

                    oldConfig.ConfigName  = config.ConfigName;
                    oldConfig.ConfigValue  = config.ConfigValue;
                    oldConfig.ConfigDescription  = config.ConfigDescription;

                    context.SaveChanges();
                    return Ok("Config updated!");
                }
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }

        }

        [HttpDelete]
        public IHttpActionResult DeleteConfig(int id)
        {
            try
            {
                using (var context = new AppDBContext())
                {
                    var config = context.Configs.FirstOrDefault(n => n.Id == id);
                    if (config == null) return NotFound();

                    context.Configs.Remove(config);
                    context.SaveChanges();

                    return Ok("Config deleted.");
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
