using System;
using System.Collections.Generic;

/// <summary>
/// Summary description for Class1
/// </summary>
public class Aluno
{
	public int Id { get; set; }

	public string Nome { get; set; }

    public string Sobrenome { get; set; }

    public string Telefone { get; set; }

	public IEnumerable<AlunoDisciplina> AlunosDisciplinas { get; set; }

	public Aluno(int Id, string Nome, string Sobrenome,string Telefone) 
	{
		this.Id = Id;
		this.Nome = Nome;
		this.Sobrenome = Sobrenome;
		this.Telefone = Telefone;
	}
    public Aluno()
	{
		
	}
}
