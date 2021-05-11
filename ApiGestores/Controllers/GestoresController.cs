using ApiGestores.Context;
using ApiGestores.Models;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ApiGestores.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GestoresController : ControllerBase
    {
        private readonly AppDbContext _Context;
        public GestoresController(AppDbContext context)
        {
            _Context = context;
        }
        // GET: api/<GestoresController>
        [HttpGet]
        public ActionResult Get()
        {
            try
            {
                return Ok(_Context.gestores_bd.ToList());
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }

        // GET api/<GestoresController>/5
        [HttpGet("{id}",Name ="GetGestor") ]
        public ActionResult Get(int id)
        {
            try
            {
                var gestor = _Context.gestores_bd.FirstOrDefault(g => g.id == id);
                return Ok(gestor);
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }

        // POST api/<GestoresController>
        [HttpPost]
        public ActionResult Post([FromBody] Gestores_bd gestor )
        {
            try
            {
                _Context.gestores_bd.Add(gestor);
                _Context.SaveChanges();
                return CreatedAtRoute("GetGestor", new { id = gestor.id }, gestor);
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }

        // PUT api/<GestoresController>/5
        [HttpPut("{id}")]
        public ActionResult Put(int id, [FromBody] Gestores_bd gestor)
        {
            try
            {
                if(gestor.id == id)
                {

                
                _Context.Entry(gestor).State = EntityState.Modified;
                _Context.SaveChanges();
                return CreatedAtRoute("GetGestor", new { id = gestor.id }, gestor);
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

        // DELETE api/<GestoresController>/5
        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            try
            {

                var gestor = _Context.gestores_bd.FirstOrDefault(g => g.id == id);
                if (gestor != null)
                {
                    _Context.gestores_bd.Remove(gestor);
                    _Context.SaveChanges();
                    return Ok(id);
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
    }
}
