
namespace INT4.ClassLibrary
{
    public class Quadrato : IFiguraGeometrica
    {
        public double Lato { get; set; } = 0;
        public Quadrato(double lato)
        {
            Lato = lato;
        }
        public Quadrato()
        {
            Lato = 0;
        }
        public double Area() => Math.Pow(Lato, 2);
        public double Perimetro() => 4 * Lato;
    }
}
