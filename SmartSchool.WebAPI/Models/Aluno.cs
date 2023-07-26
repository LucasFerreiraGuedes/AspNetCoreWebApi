using System;
using System.Collections.Generic;

/// <summary>
/// Summary description for Class1
/// </summary>
public class Aluno
{
	public int Id { get; set; }
    public int Matricula { get; set; }

    public string Nome { get; set; }

    public string Sobrenome { get; set; }

    public string Telefone { get; set; }
    public DateTime DataNasc { get; set; }
    public DateTime DataIni { get; set; } = DateTime.Now;
	public DateTime? DataFim { get; set; } = null;
	public bool Ativo { get; set; } = true;

    public IEnumerable<AlunoDisciplina> AlunosDisciplinas { get; set; }

	public Aluno()
	{

	}

	public Aluno(int id, int matricula, string nome, string sobrenome, string telefone, DateTime dataNasc)
	{
		Id = id;
		Matricula = matricula;
		Nome = nome;
		Sobrenome = sobrenome;
		Telefone = telefone;
		DataNasc = dataNasc;
	}
}
