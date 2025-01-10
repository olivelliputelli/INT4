namespace INT4.ClassLibrary
{
    public class Cilindro : Cerchio {
        public double Altezza { get; set; } = 0.0;

        public double Area() => 2 * base.Area() + Circonferenza() * Altezza;
        public double Volume() => base.Area() * Altezza ;
    }
}
