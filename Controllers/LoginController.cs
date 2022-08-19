using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ElTataAPI.Context;
using ElTataAPI.Models;



namespace ElTataAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private readonly AppDbContext context;

        public LoginController(AppDbContext context)
        {
            this.context = context;
        }

        // GET api/<UsersController>/5
        [HttpGet("{id}", Name = "GetUser")]
        public ActionResult Get(int id)
        {
            try
            {
                
                var user = context.Usuarios.FirstOrDefault(g => g.Id_Usuario == id);

                return Ok(user);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // Login api/<UsersController>/5
        [HttpPost]
        public ActionResult Post([FromBody] Usuario user)
        {
            try
            {
                var userResolve = context.Usuarios.FirstOrDefault(g => g.Username == user.Username && g.Password == user.Password);

                return Ok(userResolve);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


    }
}
