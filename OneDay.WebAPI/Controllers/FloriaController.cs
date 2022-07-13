using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OneDay.Models;
using OneDay.Services;
using OneDay.Data;
using OneDay.Models.UserFloria;

namespace OneDay.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FloriaController : ControllerBase
    {
        private readonly IFloriaService _service;
        public FloriaController(IFloriaService Service)
        {
            _service = Service;
        }

        [HttpPost]
        public async Task<IActionResult> CommentPost([FromBody] UserFloria comment)
        {
            if (!ModelState.IsValid) 
            {
                return BadRequest(ModelState);
            }
            if (await _service.CreateNewComment(comment))
            {
                return Ok();
            }
                
            return BadRequest();
        }

        [HttpGet("{commentId:int}")]
        public async Task<IActionResult> GetCommentById([FromRoute] int commentId)
        {
            var detail = await _service.GetCommentByIdAsync(commentId);
            return detail is not null
            ? Ok(detail)
            : NotFound();
        }
        }
    }