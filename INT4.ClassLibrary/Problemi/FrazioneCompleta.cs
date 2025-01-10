
namespace INT4.ClassLibrary.Problemi
{

    /// <summary>
    /// Classe principale <c>Frazione</c>.
    /// Contiene metodi per svolgere operazioni sulle frazioni.
    /// </summary>
    /// <seealso href="https://youtu.be/WDTLHUvrZp4"/>
    /// <seealso href="https://youtu.be/DCtb8NVnBQM"/>
    /// <seealso href="https://youtu.be/1uGNUOTxp7o"/>
    /// <seealso href="https://youtu.be/Rv-16CYT65U"/>
    /// <seealso href="https://youtu.be/BA96EyQZESI"/>
    public class FrazioneCompleta
    {
        /// <summary>
        /// Numeratore della frazione
        /// </summary>
        public int Numeratore { get; set; } = 0;
        private int _denominatore = 1;
        /// <summary>
        /// Denominatore della frazione
        /// </summary>
        /// <exception cref="System.ArgumentException">
        /// Lanciata quando il denominatore è 0.
        /// </exception>
        public int Denominatore
        {
            get => _denominatore;
            private set
            {
                if (value == 0)
                    throw new ArgumentException("Denominatore ZERO!");
                _denominatore = value;
            }
        }

        /// <summary>
        /// Costruire una frazione da due numeri.
        /// </summary>
        /// <param name="numeratore">Il Numeratore della frazione.</param>
        /// <param name="denominatore">Il Denominatore della frazione.</param>
        public FrazioneCompleta(int numeratore, int denominatore)
        {
            Numeratore = numeratore;
            Denominatore = denominatore;
        }
        /// <summary>
        /// Costruisce una frazione a partire da un numero intero.
        /// </summary>
        /// <param name="numero">Un numero intero.</param>
        public FrazioneCompleta(int numero) : this(numero, 1) { }
        
        /// <summary>
        /// Costruire una frazione da una stringa.
        /// </summary>
        /// <param name="s">La stringa che rappresenta la frazione.</param>
        public static FrazioneCompleta Parse(string s)
        {
            if (String.IsNullOrWhiteSpace(s)) return new FrazioneCompleta();
            if (s.Contains(','))
            {
                if (s.Contains('_')) // 123,4_1, 12,4567_2, 1,23, 1,2345_1
                {
                    string[] s2 = s.Split('_');
                    double numero = double.Parse(s2[0]);
                    int periodo = int.Parse(s2[1]);
                    return new FrazioneCompleta(numero, periodo);
                }
                else
                {
                    return new FrazioneCompleta(double.Parse(s));
                }
            }
            else if (s.Contains('/'))
            {
                string[] elementi = s.Split('/'); // ["2","7"] oppure ["5"]

                int numeratore = int.Parse(elementi[0]);
                int denominatore = 0;
                if (elementi.Length == 1) // "5"
                    denominatore = 1;
                else
                    denominatore = int.Parse(elementi[1]); // "2/7"
                return new FrazioneCompleta(numeratore, denominatore);
            }
            else if (int.TryParse(s, out int n))
            {
                return new FrazioneCompleta(n);
            }
            else
            {
                throw new ArgumentException();
            }
        }

        public FrazioneCompleta(double decimaleFinito)
        {
            // 4.654 => 4654/1000 => semplifica
            double d = decimaleFinito; // RICORDARSI: da togliere!!
            int c = 0;
            while (d != Math.Truncate(d))
            {
                d *= 10; c++;
            }
            FrazioneCompleta f = new((int)d, (int)Math.Pow(10, c));
            Numeratore = f.Semplifica().Numeratore;
            Denominatore = f.Semplifica().Denominatore;
        }
        
        /// <summary>
        /// 
        /// </summary>
        /// <param name="decimalePeriodico"></param>
        /// <param name="periodo">Numero cifre del periodo.</param>
        public FrazioneCompleta(double decimalePeriodico, int periodo)
        {
            FrazioneCompleta f = new();

            int nSenzaVirgola = NumeroSenzaVirgolaENumeroCifre(decimalePeriodico, out int c);
            int antiPeriodo = c - periodo;
            // DA SISTEMARE
            int daSottrarre = (int)Math.Truncate(decimalePeriodico * Math.Pow(10, antiPeriodo));

            f.Numeratore = (int)(nSenzaVirgola - daSottrarre);
            string den = "";
            for (int i = 0; i < periodo; i++) den += "9";
            for (int i = 0; i < antiPeriodo; i++) den += "0";
            f.Denominatore = int.Parse(den);

            Numeratore = f.Semplifica().Numeratore;
            Denominatore = f.Semplifica().Denominatore;
        }
        private int NumeroSenzaVirgolaENumeroCifre(double n, out int numeroCifre)
        {
            int c = 0;
            string nS = n.ToString();
            numeroCifre = nS.Substring(nS.IndexOf(',')).Length - 1;

            return (int)Math.Round(n * Math.Pow(10, numeroCifre));
        }
        /// <summary>
        /// Costruisce la frazione 0/1.
        /// </summary>
        public FrazioneCompleta() { }

        /// <summary>
        /// Operatore + unario.
        /// </summary>
        /// <param name="f">Una frazione.</param>
        /// <returns>La frazione</returns>
        public static FrazioneCompleta operator +(FrazioneCompleta f) => f;
        /// <summary>
        /// Operatore - unario.
        /// </summary>
        /// <param name="f">Una frazione.</param>
        /// <returns>Restituisce la frazione opposta.</returns>
        public static FrazioneCompleta operator -(FrazioneCompleta f) => new(-f.Numeratore, f.Denominatore);
        /// <summary>
        /// Somma due frazioni <paramref name="f1"/> e <paramref name="f2"/> 
        /// e restituisce il risultato.
        /// es. <c>var f = f1 + f2;</c>
        /// </summary>
        /// <param name="f1">Una frazione.</param>
        /// <param name="f2">Una frazione.</param>
        /// <returns>La somma di due frazioni.</returns>
        /// <example>
        /// <code>
        /// var a = new Frazione(5);
        /// var b = new Frazione(6, 2);
        /// var c = a + b;
        /// </code>
        /// </example>
        /// <see href = "https://github.com" > GitHub </see>
        public static FrazioneCompleta operator +(FrazioneCompleta f1, FrazioneCompleta f2)
        {
            return new FrazioneCompleta(
               f1.Numeratore * f2.Denominatore + f1.Denominatore * f2.Numeratore,
               f1.Denominatore * f2.Denominatore);
        }

        /// <summary>
        /// Sottrae da una frazione <paramref name="f1"/> una frazione <paramref name="f2"/> 
        /// e restituisce il risultato.
        /// </summary>
        /// <param name="f1">Una frazione.</param>
        /// <param name="f2">Una frazione.</param>
        /// <returns>La differenza di due frazioni.</returns>
        public static FrazioneCompleta operator -(FrazioneCompleta f1, FrazioneCompleta f2) => f1 + (-f2);
        /// <summary>
        /// Moltiplica due frazioni <paramref name="f1"/> e <paramref name="f2"/> 
        /// e restituisce il risultato.
        /// </summary>
        /// <param name="f1">Una frazione.</param>
        /// <param name="f2">Una frazione.</param>
        /// <returns>Il prodotto di due frazioni.</returns>
        public static FrazioneCompleta operator *(FrazioneCompleta f1, FrazioneCompleta f2)
        {
            return new FrazioneCompleta(
                f1.Numeratore * f2.Numeratore,
                f1.Denominatore * f2.Denominatore);
        }
        /// <summary>
        /// Divide due frazioni <paramref name="f1"/> e <paramref name="f2"/> 
        /// e restituisce il risultato.
        /// </summary>
        /// <param name="f1">Una frazione.</param>
        /// <param name="f2">Una frazione</param>
        /// <returns>Il rapporto di due frazioni.</returns>
        /// <exception cref="DivideByZeroException">
        /// Thrown quando il denominatore è 0.
        /// </exception>
        public static FrazioneCompleta operator /(FrazioneCompleta f1, FrazioneCompleta f2)
        {
            if (f2.Numeratore == 0) throw new DivideByZeroException("Divisione per ZERO!");
            return new FrazioneCompleta(f1.Numeratore * f2.Denominatore, f1.Denominatore * f2.Numeratore);
        }
        public static FrazioneCompleta operator ++(FrazioneCompleta f) => f + 1;
        public static FrazioneCompleta operator --(FrazioneCompleta f) => f - 1;
        public static implicit operator FrazioneCompleta(int n) => new FrazioneCompleta(n);
        public static explicit operator FrazioneCompleta(string n) => FrazioneCompleta.Parse(n);
        public static bool operator ==(FrazioneCompleta f1, FrazioneCompleta f2)
            => f1.Numeratore * f2.Denominatore == f2.Numeratore * f1.Denominatore;
        public override bool Equals(object? obj)
        {
            return (FrazioneCompleta)obj == this;
        }
        public static bool operator !=(FrazioneCompleta f1, FrazioneCompleta f2) => !(f1 == f2);
        public static bool operator <(FrazioneCompleta f1, FrazioneCompleta f2)
        {
            if (f1.Numeratore * f2.Denominatore < f2.Numeratore * f1.Denominatore) return true;
            return false;
        }
        public static bool operator >(FrazioneCompleta f1, FrazioneCompleta f2)
        {
            if (f1 == f2) return false;
            return !(f1 < f2);
        }
        /// <summary>
        /// Confronta <paramref name="f1" /> e <paramref name="f2" />. 
        /// </summary>
        /// <param name="f1">Una frazione.</param>
        /// <param name="f2">Una frazione.</param>
        /// <returns>true se f1 &lt;= f2 false altrimenti.</returns>
        public static bool operator <=(FrazioneCompleta f1, FrazioneCompleta f2) => !(f1 > f2);
        public static bool operator >=(FrazioneCompleta f1, FrazioneCompleta f2) => !(f1 < f2);
        /// <summary>
        /// Necessario per poter operare sulla forma come numero razionale 
        /// delle frazioni.
        /// </summary>
        /// <param name="n"></param>
        public static explicit operator double(FrazioneCompleta n)
            => n.Numeratore / (double)n.Denominatore;
        /// <summary>
        /// Restituisce la frazione reciproca di <paramref name="f"/>.
        /// </summary>
        /// <returns>La frazione reciproca.</returns>
        public FrazioneCompleta Reciproca() => new(this.Denominatore, this.Numeratore);
        public static FrazioneCompleta Reciproca(FrazioneCompleta f) => new(f.Denominatore, f.Numeratore);
        /// <summary>
        /// Semplifica ai minimi termini una frazione.
        /// </summary>
        /// <returns>Restituisce una frazione <paramref name="f"/> semplificata.</returns>
        public FrazioneCompleta Semplifica()
        {
            int mcd = Mcd(Numeratore, Denominatore);
            return new FrazioneCompleta(Numeratore / mcd, Denominatore / mcd);
        }
        /// <summary>
        /// Il segno della frazione.
        /// </summary>
        /// <returns>+1 positiva, -1 negativa oppure 0</returns>
        public int Segno() => Math.Sign(this.Numeratore * this.Denominatore);
        /// <summary>
        /// <see href="https://it.wikipedia.org/wiki/Algoritmo_di_Euclide">Algoritmo di Euclide</see> per calcolare il massimo comune divisore tra due interi <paramref name="n1"/> e <paramref name="n2"/>.
        /// </summary>
        /// <param name="n1">Un intero.</param>
        /// <param name="n2">Un intero.</param>
        /// <returns>Il MCD di n1 e n2</returns>
        /// <seealso cref="FrazioneCompleta.Mcm(int, int)"/>
        private static int Mcd(int n1, int n2)
        {
            int temp;
            while (n2 != 0)
            {
                temp = n2; n2 = n1 % n2; n1 = temp;
            }
            return n1;
        }
        /// <summary>
        /// Calcola il minimo comune multiplo tra due interi <paramref name="n1"/> e <paramref name="n2"/>
        /// </summary>
        /// <param name="n1">Un intero.</param>
        /// <param name="n2">Un intero.</param>
        /// <returns>Il mcm di n1 e n2</returns>
        /// <seealso cref="FrazioneCompleta.Mcd(int, int)"/>
        private static int Mcm(int n1, int n2)
        {
            for (int i = Math.Max(n1, n2); i < n1 * n2; i++)
                if (i % n1 == 0 && i % n2 == 0) return i;
            return n1 * n2;
        }

        /// <summary>
        /// Restituisce <c>true</c> se la frazione è decimale finita.
        /// </summary>
        /// <returns><c>true</c> se la frazione è decimale finita; <c>false</c> altrimenti.</returns>
        public bool IsDecimaleFinito()
        {
            if (this.Numeratore == 0) return false;
            var d = this.Semplifica().Denominatore;
            do
            {
                if (d % 2 == 0)
                    d /= 2;
                else if (d % 5 == 0)
                    d /= 5;
                else
                    return false;
            } while (Math.Abs(d) != 1);
            return true;
        }
        /// <summary>
        /// Restituisce <c>true</c> se la frazione è decimale periodico.
        /// </summary>
        /// <returns><c>true</c> se la frazione è decimale periodico; <c>false</c> altrimenti.</returns>
        public bool IsDecimalePeriodico()
        {
            FrazioneCompleta f = this.Semplifica();
            if (f.IsDecimaleFinito())
                return false;
            if (Math.Abs(f.Denominatore) == 1)
                return false;
            return true;
        }
        /// <summary>
        /// Overload del metodo.
        /// </summary>
        /// <returns>Rappresentazione di una frazione come stringa.</returns>
        public override string ToString()
        {
            Mcd(3, 4);
            if (Numeratore == 0) return "0";
            return String.Concat((this.Segno() < 0) ? "-" : "", (Denominatore == 1) ? $"{Math.Abs(Numeratore)}"
                : $"{Math.Abs(Numeratore)}/{Math.Abs(Denominatore)}");
        }
    }
}

