
namespace INT4.ClassLibrary
{
    public class Persona
    {
        public string Nome { get; set; } = string.Empty;
        public DateOnly DataDiNascita { get; set; }
        public string Nazionalita { get; set; } = "Italia";
        public int Eta()
        {
            DateTime oggi = DateTime.Today;
            int eta = oggi.Year - DataDiNascita.Year;
            if (oggi.Month < DataDiNascita.Month || (oggi.Month == DataDiNascita.Month && oggi.Day < DataDiNascita.Day))
            {
                eta--;
            }
            return eta;
        }
    }
}
