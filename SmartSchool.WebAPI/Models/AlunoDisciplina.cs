using System;
using System.CodeDom;

/// <summary>
/// Summary description for Class1
/// </summary>
public class AlunoDisciplina
{
    public DateTime DataIni { get; set; } = DateTime.Now;
    public DateTime? DataFim { get; set; }
    public int? Nota { get; set; }
    public int AlunoId { get; set; }

    public Aluno Aluno { get; set; }


    public int DisciplinaId { get; set; }

    public Disciplina Disciplina { get; set; }

    public AlunoDisciplina(int AlunoId, int DisciplinaId)
    {
        this.AlunoId = AlunoId;
        this.DisciplinaId = DisciplinaId;
    }

    public AlunoDisciplina()
	{
		
	}
}
