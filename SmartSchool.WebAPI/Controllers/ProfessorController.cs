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

        private readonly IRepository _repo;

        public ProfessorController(IRepository repo)
        {
            _repo = repo;
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_repo.GetAllProfessores());
        }

        [HttpGet("ById/{id}")]
        public IActionResult GetById(int id)
        {
           var teacher = _repo.GetProfessorID(id);
           
           if(teacher == null){
            return BadRequest("Não existe professor com este ID");
           }
           return Ok(teacher);

        }

        [HttpGet ("ByName/{nome}")]

        public IActionResult GetByName(string nome) 
        {
            var teacher = _repo.GetProfessorByName(nome);


			if (teacher == null) 
            {
                return BadRequest("Não existe professor com este nome");
            }
            return Ok(teacher);


        }

        [HttpPost]
        public IActionResult Post(Professor professor) 
        {
            _repo.Add(professor);
            _repo.SaveChanges();
            return Ok(professor);
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id,Professor professor)
        {
            var teacher = _repo.GetProfessorID(id);

			if (teacher == null)
            {
                return BadRequest("Não existe professor com este ID");
            }
            _repo.Update(professor);
            _repo.SaveChanges();
            return Ok(professor);

        }
        [HttpPatch("{id}")]

        public IActionResult Patch(int id, Professor professor)
        {
			var teacher = _repo.GetProfessorID(id);

			if (teacher == null)
			{
				return BadRequest("Não existe professor com este ID");
			}
			_repo.Update(professor);
			_repo.SaveChanges();
			return Ok(professor);
		}


        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var teacher = _repo.GetProfessorID(id);

			if (teacher == null)
            {
                return BadRequest("Não Existe professor com este ID");
            }

            _repo.Delete(teacher);
            _repo.SaveChanges();
            return Ok();

        }

        



        
    }
}