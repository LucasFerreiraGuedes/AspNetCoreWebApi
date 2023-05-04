using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SmartSchool.WebAPI.Data;

namespace SmartSchool.WebAPI.Controllers
{

    [ApiController]
    [Route("api/[controller]")]
    public class ProfessorController : ControllerBase
    {
        private readonly SmartContext _context;

        public ProfessorController(SmartContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_context.Professores);
        }

        [HttpGet("ById")]
        public IActionResult GetById(int id)
        {
           var teacher = _context.Professores.FirstOrDefault(context => context.Id == id);
           
           if(teacher == null){
            return BadRequest("Não existe professor com este ID");
           }
           return Ok(teacher);

        }

        [HttpGet ("ByName")]

        public IActionResult GetByName(string nome) 
        {
            var teacher = _context.Professores.FirstOrDefault(context => context.Nome == nome);

            if(teacher == null) 
            {
                return BadRequest("Não existe professor com este nome");
            }
            return Ok(teacher);


        }

        [HttpPost]
        public IActionResult Post(Professor professor) 
        {
            _context.Add(professor);
            _context.SaveChanges();
            return Ok(professor);
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id,Professor professor)
        {
            var teacher = _context.Professores.AsNoTracking().FirstOrDefault(context => context.Id == id);

            if(teacher == null)
            {
                return BadRequest("Não existe professor com este ID");
            }
            _context.Update(professor);
            _context.SaveChanges();
            return Ok(professor);

        }
        [HttpPatch("{id}")]

        public IActionResult Patch(int id, Professor professor)
        {
			var teacher = _context.Professores.AsNoTracking().FirstOrDefault(context => context.Id == id);

			if (teacher == null)
			{
				return BadRequest("Não existe professor com este ID");
			}
			_context.Update(professor);
			_context.SaveChanges();
			return Ok(professor);
		}


        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var teacher = _context.Professores.AsNoTracking().FirstOrDefault(context => context.Id ==id);

            if(teacher == null)
            {
                return BadRequest("Não Existe professor com este ID");
            }

            _context.Remove(teacher);
            _context.SaveChanges();
            return Ok();

        }

        



        
    }
}