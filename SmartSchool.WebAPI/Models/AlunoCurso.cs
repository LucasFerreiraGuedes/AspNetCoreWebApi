using SmartSchool.WebAPI.Models;
using System;
using System.CodeDom;

/// <summary>
/// Summary description for Class1
/// </summary>
public class AlunoCurso
{
	public DateTime DataIni { get; set; } = DateTime.Now;
	public DateTime? DataFim { get; set; }
	public int AlunoId { get; set; }

	public Aluno Aluno { get; set; }


	public int CursoId { get; set; }

	public Curso Curso { get; set; }

	public AlunoCurso(int AlunoId, int cursoId)
	{
		this.AlunoId = AlunoId;
		this.CursoId = cursoId;
	}

	public AlunoCurso()
	{

	}
}
