namespace SmartSchool.WebAPI.Helpers
{
	public static class DataExtensions
	{
		public static int GetCurrentAge(this DateTime dt)
		{
			int age = DateTime.Now.Year - dt.Year;
			return age;
		}
	}
}
