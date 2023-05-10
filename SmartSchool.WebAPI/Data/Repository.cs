using Microsoft.EntityFrameworkCore;

namespace SmartSchool.WebAPI.Data
{
	public class Repository : IRepository
	{
		private readonly SmartContext _context;
        public Repository(SmartContext context)
        {
            _context = context;
        }
        public void Add<T>(T Entity) where T : class
		{
			_context.Add(Entity);
		}

		public void Delete<T>(T Entity) where T : class
		{
			_context.Remove(Entity);
		}

		public bool SaveChanges()
		{
			return (_context.SaveChanges() > 0) ; 
		}

		public void Update<T>(T Entity) where T : class
		{
			_context.Update(Entity);
		}

		public Aluno[] GetAllAlunos(bool includeProfessor = false)
		{
			IQueryable<Aluno> query = _context.Alunos;


			if(includeProfessor)
			{
				query = query.Include(c => c.AlunosDisciplinas)
									 .ThenInclude(d => d.Disciplina)
									 .ThenInclude(p => p.Professor);
			}

			query = query.AsNoTracking().OrderBy(c => c.Id);

			return query.ToArray();


		}

		public Aluno[] GetAllAlunosByDisciplinaID(int disciplinaid, bool includeProfessor = false)
		{
			IQueryable<Aluno> query = _context.Alunos;

			if (includeProfessor)
			{
				query = query.Include(c => c.AlunosDisciplinas)
									 .ThenInclude(d => d.Disciplina)
									 .ThenInclude(p => p.Professor);
			}

			query = query.AsNoTracking().Where(aluno => aluno.AlunosDisciplinas.Any(ad => ad.DisciplinaId == disciplinaid));

			return query.ToArray();

		}

		public Aluno GetAlunoID(int id, bool includeProfessor = false)
		{
			IQueryable<Aluno> query = _context.Alunos;

			if (includeProfessor)
			{
				query = query.Include(c => c.AlunosDisciplinas)
									.ThenInclude(d => d.Disciplina)
									.ThenInclude(p => p.Professor);
			}



			query = query.AsNoTracking().Where(c => c.Id == id);

			return query.FirstOrDefault();
		}

		public Professor GetProfessorID(int id, bool includeAlunos = false)
		{
			IQueryable<Professor> query = _context.Professores;

			if (includeAlunos)
			{
				query = query.Include(c => c.Disciplinas)
									 .ThenInclude(d => d.AlunosDisciplinas)
									 .ThenInclude(a => a.Aluno);
			}

			query = query.AsNoTracking().Where(professor => professor.Id == id);

			return query.FirstOrDefault();
		}

		public Professor[] GetAllProfessores(bool includeAlunos = false)
		{
			IQueryable<Professor> query = _context.Professores;

			if (includeAlunos)
			{
				query = query.Include(c => c.Disciplinas)
									 .ThenInclude(d => d.AlunosDisciplinas)
									 .ThenInclude(a => a.Aluno);
			}

			return query.AsNoTracking().ToArray();
		}

		public Professor GetProfessorByName(string nome, bool includeAlunos = false)
		{
			IQueryable<Professor> query = _context.Professores;

			if (includeAlunos)
			{
				query = query.Include(c => c.Disciplinas)
									 .ThenInclude(d => d.AlunosDisciplinas)
									 .ThenInclude(a => a.Aluno);
			}
			query = query.AsNoTracking().Where(professor => professor.Nome == nome);

			return query.FirstOrDefault();
		}

		public Professor[] GetProfessorByDisciplinaID(int disciplinaId, bool includeAlunos = false)
		{
			IQueryable<Professor> query = _context.Professores;


			if (includeAlunos)
			{
				query = query.Include(c => c.Disciplinas)
									 .ThenInclude(d => d.AlunosDisciplinas)
									 .ThenInclude(a => a.Aluno);
			}
			query = query.AsNoTracking().Where(professor => professor.Disciplinas.Any(d => d.AlunosDisciplinas.Any(ad => ad.DisciplinaId == disciplinaId)));

			return query.ToArray();

		}
	}
}
