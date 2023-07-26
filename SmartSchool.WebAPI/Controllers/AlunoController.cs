using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SmartSchool.WebAPI.Data;

namespace SmartSchool.WebAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AlunoController : ControllerBase
    {
      
        private readonly IRepository _repo;
        private readonly IMapper _mapper;

        public AlunoController(IRepository repo,IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult Get()
        {
             return Ok(_repo.GetAllAlunos(true));
        }

        [HttpGet("ById/{id}")]
        public IActionResult GetId(int id)
        {
            var alunoId = _repo.GetAlunoID(id);

            if(alunoId == null)
                return BadRequest("Este aluno com este ID, não existe");
             return Ok(alunoId);
        }

        //[HttpGet("ByName")]
        //public IActionResult Getbyname(string name, string sobrenome)
        //{
        //    var alunoId = _context.Alunos.FirstOrDefault(a => a.Nome.Contains(name) && a.Sobrenome.Contains(sobrenome));

        //    if(alunoId == null)
        //        return BadRequest("Este aluno com este nome e sobrenome não existe");
        //     return Ok(alunoId);
        //}

        [HttpPost]
        public IActionResult Post(Aluno aluno)
        {
            _repo.Add(aluno);
            _repo.SaveChanges();
             return Ok(aluno);      
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, Aluno aluno)
        {
            var student = _repo.GetAlunoID(id);

            if(student == null){
                return BadRequest("Não existe nenhum aluno com este ID");
            }
            _repo.Update(aluno);
            _repo.SaveChanges();
            return Ok(aluno);
        }

         [HttpPatch("{id}")]
        public IActionResult Patch(int id, Aluno aluno)
        {

            var student = _repo.GetAlunoID(id);

            if(student == null){
                return BadRequest("Este aluno com este ID não existe");
            }
            
            _repo.Update(aluno);
            _repo.SaveChanges();
            return Ok(aluno);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var student = _repo.GetAlunoID(id);

            if(student == null){
                return BadRequest("Este Aluno com este ID não existe");
            }
            
            _repo.Delete(student);
            _repo.SaveChanges();
            return Ok();
        }


    }
}