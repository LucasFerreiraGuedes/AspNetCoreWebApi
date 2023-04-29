using System;
using System.Collections.Generic;

/// <summary>
/// Summary description for Class1
/// </summary>
public class Disciplina
{

    public int Id { get; set; }

    public string Nome { get; set; }

    public int ProfessorId { get; set; }

    public Professor Professor { get; set; }

    public IEnumerable<AlunoDisciplina> AlunosDisciplinas { get; set; }     

    public Disciplina(int Id,string Nome,int ProfessorId)
    {
        this.Id = Id;
        this.Nome = Nome;
        this.ProfessorId = ProfessorId;
    }

    public Disciplina()
	{
		
	}
}
