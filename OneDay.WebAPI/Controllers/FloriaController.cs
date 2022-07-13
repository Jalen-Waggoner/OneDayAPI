using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OneDay.Models;
using OneDay.Services;
using OneDay.Data;

namespace OneDay.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FloriaController : ControllerBase
    {
        private readonly IFloriaService _service;

        public FloriaController(IFloriaService service)
        {
            _service = service;

        }
        [HttpPost("Register")]
        public async Task<IActionResult> RegisterUser([FromBody] UserFloria model)
        {
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var registerResult = await _service.RegisterUserAsync(model);
            if(registerResult)
            {
                return Ok("User was registered");
            }
            return BadRequest("User could not be registered.");

        }
    }

}