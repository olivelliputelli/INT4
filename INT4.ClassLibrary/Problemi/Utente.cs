namespace INT4.ClassLibrary.Problemi;
public class Utente
{
    public string Nome { get; set; } = String.Empty;
    public string Cognome { get; set; } = String.Empty;
    public DateOnly DataDiNascita { get; set; }
    public int Eta()
    {
        int eta = DateTime.Now.Year - DataDiNascita.Year;
        if (DateOnly.FromDateTime(DateTime.Now.AddYears(-eta)) < DataDiNascita) eta--;
        return eta;
    }
    public int GiorniProssimoCompleanno()
    {
        return (DataDiNascita.ToDateTime(new TimeOnly()).AddYears(Eta() + 1)
            - DateTime.Today).Days;
    }
}
