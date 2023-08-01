namespace SmartSchool.WebAPI.DTOs
{
	public class ProfessorDTO
	{
		public int Id { get; set; }
		public int Registro { get; set; }
		public string Nome { get; set; }
		public DateTime DataIni { get; set; } = DateTime.Now;
		public bool Ativo { get; set; } = true;
	}
}
