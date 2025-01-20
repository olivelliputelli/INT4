namespace INT4.ClassLibrary;
public class Persona
{


    public int Id { get; set; }
    public string Nome { get; set; } = string.Empty;

    private DateOnly dataDiNascita;

    public DateOnly DataDiNascita
    {
        get { return dataDiNascita; }
        set
        {
            if (value > DateOnly.FromDateTime(DateTime.Today))
                throw new Exception();
            dataDiNascita = value;
        }
    }


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
