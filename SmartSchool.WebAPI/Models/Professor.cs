using System;
using System.Collections.Generic;

/// <summary>
/// Summary description for Class1
/// </summary>
public class Professor 
{
    public int Id { get; set; }

    public string Nome { get; set; }

    public IEnumerable<Disciplina> Disciplinas { get; set; }

    public Professor(int Id, string Nome)
    {
        this.Nome = Nome;
        this.Id = Id;
    }

    public Professor() 
    { 

	}
}
