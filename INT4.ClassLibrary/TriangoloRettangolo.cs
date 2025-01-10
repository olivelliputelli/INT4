namespace INT4.ClassLibrary
{
    public class TriangoloRettangolo : IFiguraGeometrica
    {
        private double @base = 0.0;
        public double Base
        {
            get { return @base; }
            set
            {
                if (value < 0)
                {
                    throw new Exception("value");
                }
                @base = value;
            }
        }

        private double altezza = 0.0;
        public double Altezza
        {
            get { return altezza; }
            set
            {
                if (value < 0)
                {
                    throw new Exception("value");
                }
                altezza = value;
            }
        }
        private double Ipotenusa() => Math.Sqrt(Math.Pow(Base, 2) + Math.Pow(Altezza, 2));
        public double Perimetro() => Base + Altezza + Ipotenusa();
        public double Area() => Base * Altezza;
    }
}
