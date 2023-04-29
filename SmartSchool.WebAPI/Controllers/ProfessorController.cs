using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace SmartSchool.WebAPI.Controllers
{

    [ApiController]
    [Route("api/[Controller]")]
    public class ProfessorController : ControllerBase
    {
        
        public ProfessorController()
        {

        }

        [HttpGet]
        public IActionResult Get()
        {
             return Ok("Professor desta disciplina é Marcos Paulo");
        }


    }
}