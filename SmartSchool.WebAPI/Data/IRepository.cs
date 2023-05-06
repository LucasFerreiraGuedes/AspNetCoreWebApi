namespace SmartSchool.WebAPI.Data
{
	public interface IRepository
	{
		void Add<T>(T Entity) where T : class;
		void Update<T>(T Entity) where T : class;

		void Delete<T>(T Entity) where T : class;
		bool SaveChanges();
	}
}
