namespace INT4.ClassLibrary;
public class TodoItem
{
    public int Id { get; set; }
    public string? Titolo { get; set; }
    public bool IsDone { get; set; }
    public DateOnly InseritoIl { get; private set; }
        = DateOnly.FromDateTime(DateTime.Now);
    public DateTime UltimaModifica { get; set; }= DateTime.Now;
}
