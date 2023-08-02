using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SmartSchool.WebAPI.Data;
using SmartSchool.WebAPI.DTOs;

namespace SmartSchool.WebAPI.Controllers
{

    [ApiController]
	[ApiVersion("2.0")]
	[Route("api/v{version:apiVersion}/[controller]")]
    public class ProfessorController : ControllerBase
    {

        private readonly IRepository _repo;
        private readonly IMapper _mapper;

        public ProfessorController(IRepository repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_repo.GetAllProfessores());
        }

        [HttpGet("ById/{id}")]
        public IActionResult GetById(int id)
        {
           var teacher = _mapper.Map<ProfessorDTO>(_repo.GetProfessorID(id));
           
           if(teacher == null){
            return BadRequest("Não existe professor com este ID");
           }
           return Ok(teacher);

        }

        [HttpGet ("ByName/{nome}")]

        public IActionResult GetByName(string nome) 
        {
            var teacher = _mapper.Map<ProfessorDTO>(_repo.GetProfessorByName(nome));


			if (teacher == null) 
            {
                return BadRequest("Não existe professor com este nome");
            }
            return Ok(teacher);


        }

        [HttpPost]
        public IActionResult Post(ProfessorRegisterDTO professorDTO) 
        {
            var professor = _mapper.Map<Professor>(professorDTO);
            _repo.Add(professor);
            _repo.SaveChanges();
            return Ok(professor);
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id,ProfessorRegisterDTO professorDTO)
        {
            var teacher = _repo.GetProfessorID(id);

			if (teacher == null)
            {
                return BadRequest("Não existe professor com este ID");
            }
			var professor = _mapper.Map<Professor>(professorDTO);
			_repo.Update(professor);
            _repo.SaveChanges();
            return Ok(professor);

        }
        [HttpPatch("{id}")]

        public IActionResult Patch(int id, ProfessorRegisterDTO professorDTO)
        {
			var teacher = _repo.GetProfessorID(id);

			if (teacher == null)
			{
				return BadRequest("Não existe professor com este ID");
			}
			var professor = _mapper.Map<Professor>(professorDTO);
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
            return Ok("Professor apagado com sucesso");

        }

        



        
    }
}