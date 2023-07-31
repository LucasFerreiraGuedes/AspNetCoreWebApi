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

            var result = _mapper.Map<AlunoDTO>(alunoId);

            if(result == null)
                return BadRequest("Este aluno com este ID, não existe");
             return Ok(result);
        }


        [HttpPost]
        public IActionResult Post(AlunoRegisterDTO alunoDTO)
        {
            var aluno = _mapper.Map<Aluno>(alunoDTO);
            _repo.Add(aluno);
            _repo.SaveChanges();
             return Ok(alunoDTO);      
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, AlunoRegisterDTO alunoDTO)
        {
            var student = _repo.GetAlunoID(id);

            if(student == null){
                return BadRequest("Não existe nenhum aluno com este ID");
            }
            var aluno = _mapper.Map<Aluno>(alunoDTO);
            _repo.Update(aluno);
            _repo.SaveChanges();
            return Ok(aluno);
        }

         [HttpPatch("{id}")]
        public IActionResult Patch(int id, AlunoRegisterDTO alunoDTO)
        {

            var student = _repo.GetAlunoID(id);

            if(student == null){
                return BadRequest("Este aluno com este ID não existe");
            }

			var aluno = _mapper.Map<Aluno>(alunoDTO);
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
            return Ok("Aluno deletado com sucesso");
        }


    }
}