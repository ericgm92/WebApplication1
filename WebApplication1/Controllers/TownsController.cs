using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WebApplication1.Context;
using WebApplication1.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebApplication1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TownsController : ControllerBase
    {
        private readonly AppDbContext context;

        public TownsController(AppDbContext context)
        {
            this.context = context;
        }
        // GET: api/<townsController>
        [HttpGet]
        public ActionResult Get()
        {
            try
            {
                return Ok(context.towns_bd.ToString());

            } catch (Exception ex)
            {
                return BadRequest (ex.Message);
            }
        }

        // GET api/<townsController>/5
        [HttpGet("{id}", Name ="GetTown")]
        public ActionResult Get(int id)
        {
            try
            {
                var town = context.towns_bd.FirstOrDefault(g => g.id == id);
                return Ok(town);
            } catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // POST api/<townsController>
        [HttpPost]
        public ActionResult Post([FromBody]Towns_Bd town)
        {
            try
            {
                context.towns_bd.Add(town);
                context.SaveChanges();
                return CreatedAtRoute("GetTown", new { id = town.id }, town);
            } catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // PUT api/<townsController>/5
        [HttpPut("{id}")]
        public ActionResult Put(int id, [FromBody] Towns_Bd town)
        {
            try
            {
                if (town.id == id)
                {
                    context.Entry(town).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                    context.SaveChanges();
                    return CreatedAtRoute("GetTown", new { id = town.id }, town);
                }
                else
                {
                    return BadRequest();
                }
                
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // DELETE api/<townsController>/5
        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            try
            {
                var town = context.towns_bd.FirstOrDefault(g => g.id == id);
                if (town != null)
                {
                    context.towns_bd.Remove(town);
                    context.SaveChanges();
                    return Ok(id);
                }
                else
                {
                    return BadRequest();
                }

            } catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
