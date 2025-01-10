namespace INT4.ClassLibrary
{
    public class Rettangolo : IFiguraGeometrica
    {
        public double Base { get; set; } = 0.0;
        public double Altezza { get; set; } = 0.0;
        public double Area() => Base * Altezza;
        public double Perimetro() => 2 * (Base + Altezza);
    }
}
