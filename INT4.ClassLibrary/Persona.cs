namespace INT4.ClassLibrary;
public class Persona
{
    public int Id { get; set; }
    public string Nome { get; set; } = string.Empty;
    public DateOnly DataDiNascita { get; set; }
    public string Nazionalita { get; set; } = "Italia";
    public DateTime InseritoIl { get; set; } = DateTime.Now;
    public int Eta()
    {
        DateOnly oggi = DateOnly.FromDateTime(DateTime.Today);
        int eta = oggi.Year - DataDiNascita.Year;
        if (oggi.AddYears(-eta) < DataDiNascita) eta--;
        return eta;
    }
}
