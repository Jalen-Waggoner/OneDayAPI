using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OneDay.Services.Jalen;
using OneDay.Models.Jalen;
using OneDay.Data;

namespace OneDay.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class JalenController : ControllerBase
    {
        private readonly ApplicationDbContext _db;
        private readonly IJalenService  _jalenService;
        public JalenController(IJalenService jalenService)
        {
            _jalenService = jalenService;
        }

        [HttpPost ("Create")]
        public async Task<IActionResult> CreateJalen([FromBody] JalenCreate request) 
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            
            if (await _jalenService.CreateJalenAsync(request))
                return Ok("Jalen created successfully.");

            return BadRequest("Jalen could not be created.");
        }

        [HttpGet("{jalenId:int}")]
        public async Task<IActionResult> GetNoteById([FromRoute] int jalenId)
        {
            var detail = await _jalenService.GetJalenByIdAsync(jalenId);

            return detail is not null
            ? Ok(detail)
            : NotFound();
        }
    }
}
