using SmartSchool.WebAPI.Models;
using System;
using System.Collections.Generic;

/// <summary>
/// Summary description for Class1
/// </summary>
public class Disciplina
{

    public int Id { get; set; }

    public string Nome { get; set; }
    public int CargaHoraria { get; set; }
    public int? PrerequisitoId { get; set; } = null;
    public Disciplina? Prerequisito { get; set; }

    public int ProfessorId { get; set; }

    public Professor Professor { get; set; }
    public int CursoId { get; set; }

    public Curso Curso { get; set; }

    public IEnumerable<AlunoDisciplina> AlunosDisciplinas { get; set; }     

    public Disciplina(int Id,string Nome,int ProfessorId,int cursoId)
    {
        this.Id = Id;
        this.Nome = Nome;
        this.ProfessorId = ProfessorId;
        this.CursoId = cursoId;
    }

    public Disciplina()
	{
		
	}
}
