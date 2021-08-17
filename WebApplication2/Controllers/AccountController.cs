using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication2.Models;
using Dapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authorization;

namespace WebApplication2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly NewsDBContext context;
        private readonly ITokenProvider tokenProvider;

        public AccountController(NewsDBContext context,ITokenProvider tokenProvider)
        {
            this.context = context;
            this.tokenProvider = tokenProvider;
        }

        [HttpPost("auth")]
        [AllowAnonymous]
        
        public IActionResult Authenticate([FromForm]string NombreUsuario,[FromForm]string Contrasena)
        {
            var connection = context.Database.GetDbConnection();
            var result = connection.QuerySingleOrDefault<Usuario>("UsuarioValidacion", new { NombreUsuario, Contrasena }, commandType: System.Data.CommandType.StoredProcedure);

            if (result == null)
            {
                return BadRequest("Invalid Credentials.");
            }

            int expirationInHour = 24;

            DateTime expiration = DateTime.UtcNow.AddHours(expirationInHour);
            var token = tokenProvider.CreateToken(result, expiration);


            return Ok(new
            {
                token = token,
                expires_in = expirationInHour * 60 * 60
            }); 


        }
    }
}
