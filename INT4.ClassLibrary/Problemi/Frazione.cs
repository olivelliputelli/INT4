
namespace INT4.ClassLibrary.Problemi
{
    public class Frazione
    {
        private int numeratore = 0;

        public int Numeratore
        {
            get { return numeratore; }
            set
            {
                numeratore = value;
                Semplifica();
            }
        }

        private int denominatore = 1;

        public int Denominatore
        {
            get { return denominatore; }
            set
            {
                if (value == 0) throw new DivideByZeroException();

                denominatore = value;
                Semplifica();
            }
        }

        public Frazione() { }
        public Frazione(int num, int den)
        {
            Numeratore = num;
            Denominatore = den;
        }
        private int MassimoComunDivisore(int a, int b)
        {
            while (a != b)
                if (a > b)
                    a -= b;
                else
                    b -= a;
            return a;
        }
        private void Semplifica()
        {
            int MCD = MassimoComunDivisore(Math.Abs(numeratore), Math.Abs(denominatore));

            numeratore /= MCD;
            denominatore /= MCD;
            if ((numeratore >= 0 && denominatore < 0) ||
                (numeratore < 0 && denominatore < 0))
            {
                numeratore = -numeratore;
                denominatore = -denominatore;
            }
        }
        public Frazione Inverso()
        {
            Frazione risultato = new Frazione(-Numeratore, Denominatore);
            return risultato;
        }
        public static Frazione operator -(Frazione f)
        {
            return f.Inverso();
        }
        public Frazione Reciproco()
        {
            return new Frazione(Denominatore, Numeratore);
        }

        public Frazione Somma(Frazione f)
        {
            int n = f.Denominatore * this.Numeratore + this.Denominatore * f.Numeratore;
            int d = this.Denominatore * f.Denominatore;

            return new Frazione(n, d);
        }
        public static Frazione operator -(Frazione f1, Frazione f2)
        {
            return f1 + -f2;
        }
        public static Frazione operator +(Frazione f1, Frazione f2)
        {
            return f1.Somma(f2);
        }
        public override String ToString()
        {
            string str = "";
            if (Denominatore != 1)
                str = numeratore + "/" + denominatore;
            else
                str = numeratore.ToString();
            return str;
        }
    }
}
