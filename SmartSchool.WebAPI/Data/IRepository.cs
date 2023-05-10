using Microsoft.EntityFrameworkCore;

namespace SmartSchool.WebAPI.Data
{
	public interface IRepository
	{
		void Add<T>(T Entity) where T : class;
		void Update<T>(T Entity) where T : class;

		void Delete<T>(T Entity) where T : class;
		bool SaveChanges();


	    Aluno[] GetAllAlunos(bool includeProfessor = false);
		Aluno[] GetAllAlunosByDisciplinaID(int disciplinaid, bool includeProfessor = false);
		Aluno GetAlunoID(int id, bool includeProfessor = false);

		Professor[] GetAllProfessores(bool includeAlunos = false);
		Professor[] GetProfessorByDisciplinaID(int disciplinaId, bool includeAlunos = false);
		Professor GetProfessorID(int id, bool includeAlunos = false);
		public Professor GetProfessorByName(string nome, bool includeAlunos = false);




	}
}
