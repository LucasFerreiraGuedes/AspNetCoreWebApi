using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SmartSchool.WebAPI.Data;

namespace SmartSchool.WebAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AlunoController : ControllerBase
    {
       
        private readonly SmartContext _context;

        public AlunoController( SmartContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult Get()
        {
             return Ok(_context.Alunos);
        }

        [HttpGet("ById")]
        public IActionResult GetId(int id)
        {
            var alunoId = _context.Alunos.FirstOrDefault(a => a.Id == id);

            if(alunoId == null)
                return BadRequest("Este aluno com este ID, não existe");
             return Ok(alunoId);
        }

        [HttpGet("ByName")]
        public IActionResult Getbyname(string name, string sobrenome)
        {
            var alunoId = _context.Alunos.FirstOrDefault(a => a.Nome.Contains(name) && a.Sobrenome.Contains(sobrenome));

            if(alunoId == null)
                return BadRequest("Este aluno com este nome e sobrenome não existe");
             return Ok(alunoId);
        }

        [HttpPost]
        public IActionResult Post(Aluno aluno)
        {
             return Ok(aluno);      
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, Aluno aluno)
        {
            return Ok(aluno);
        }

         [HttpPatch("{id}")]
        public IActionResult Patch(int id, Aluno aluno)
        {
            return Ok(aluno);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            return Ok();
        }


    }
}