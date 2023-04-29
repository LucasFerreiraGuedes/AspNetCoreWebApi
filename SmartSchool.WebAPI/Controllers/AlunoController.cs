using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace SmartSchool.WebAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AlunoController : ControllerBase
    {
        List<Aluno> Alunos = new List<Aluno>() {
             new Aluno(){
                Id = 1,
                Nome = "Lucas",
                Sobrenome = "Ferreira Guedes",
                Telefone = "31 97527-5120"
             },
             new Aluno(){
                Id = 2,
                Nome = "Thais",
                Sobrenome = "Alves Silva",
                Telefone = "5446546"
             }

        };
        public AlunoController()
        {
            
        }

        [HttpGet]
        public IActionResult Get()
        {
             return Ok(Alunos);
        }

        [HttpGet("ById")]
        public IActionResult GetId(int id)
        {
            var alunoId = Alunos.Find(a => a.Id == id);

            if(alunoId == null)
                return BadRequest("Este aluno com este ID, não existe");
             return Ok(alunoId);
        }

        [HttpGet("ByName")]
        public IActionResult Getbyname(string name, string sobrenome)
        {
            var alunoId = Alunos.Find(a => a.Nome.Contains(name) && a.Sobrenome.Contains(sobrenome));

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