namespace INT4.ClassLibrary.Problemi
{
    public class FrazioneJava
    {
        private int numeratore;
        private int denominatore;

        private int massimoComunDivisore(int a, int b)
        {
            while (a != b)
                if (a > b)
                    a = a - b;
                else
                    b = b - a;
            return a;
        }

        private int elevamentoPotenza(int b, int e)
        {
            int p = 1;

            while (e > 0)
            {
                p = p * b;
                e--;
            }
            return p;
        }

        private void semplifica()
        {
            int MCD = massimoComunDivisore(numeratore < 0 ? -numeratore : numeratore,
                                           denominatore < 0 ? -denominatore : denominatore);
            numeratore = numeratore / MCD;
            denominatore = denominatore / MCD;
            if ((numeratore >= 0 && denominatore < 0) ||
                (numeratore < 0 && denominatore < 0))
            {
                numeratore = -numeratore;
                denominatore = -denominatore;
            }
        }

        public FrazioneJava()
        {
            numeratore = 0;
            denominatore = 1;
        }

        public FrazioneJava(int numeratore, int denominatore)
        {
            if (denominatore != 0)
            {
                this.numeratore = numeratore;
                this.denominatore = denominatore;
                semplifica();
            }
            else
            {
                this.numeratore = 0;
                this.denominatore = 1;
            }
        }

        public void setNumeratore(int numeratore)
        {
            this.numeratore = numeratore;
            semplifica();
        }

        public void setDenominatore(int denominatore)
        {
            if (denominatore != 0)
            {
                this.denominatore = denominatore;
                semplifica();
            }
        }

        public int getNumeratore()
        {
            return numeratore;
        }

        public int getDenominatore()
        {
            return denominatore;
        }

        public FrazioneJava inverso()
        {
            FrazioneJava risultato = new FrazioneJava(-numeratore, denominatore);
            return risultato;
        }

        public FrazioneJava reciproco()
        {
            FrazioneJava risultato = new FrazioneJava(denominatore, numeratore);
            return risultato;
        }

        public FrazioneJava somma(FrazioneJava frazione)
        {
            FrazioneJava risultato = new FrazioneJava();
            risultato.denominatore = denominatore * frazione.denominatore;
            risultato.numeratore = numeratore * frazione.denominatore + frazione.numeratore * denominatore;
            risultato.semplifica();
            return risultato;
        }

        public FrazioneJava differenza(FrazioneJava frazione)
        {
            FrazioneJava risultato = new FrazioneJava();
            risultato.denominatore = denominatore * frazione.denominatore;
            risultato.numeratore = numeratore * frazione.denominatore - frazione.numeratore * denominatore;
            risultato.semplifica();
            return risultato;
        }

        FrazioneJava prodotto(FrazioneJava frazione)
        {
            FrazioneJava risultato = new FrazioneJava();
            risultato.denominatore = denominatore * frazione.denominatore;
            risultato.numeratore = numeratore * frazione.numeratore;
            risultato.semplifica();
            return risultato;
        }

        FrazioneJava quoziente(FrazioneJava frazione)
        {
            FrazioneJava risultato = new FrazioneJava();

            if (frazione.numeratore == 0)
                return risultato; // errore -> restituisce frazione con valore nullo
            risultato.denominatore = denominatore * frazione.numeratore;
            risultato.numeratore = numeratore * frazione.denominatore;
            risultato.semplifica();
            return risultato;
        }

        FrazioneJava potenza(int esponente)
        {
            FrazioneJava risultato = new FrazioneJava();

            if (esponente >= 0)
            {
                risultato.denominatore = elevamentoPotenza(denominatore, esponente);
                risultato.numeratore = elevamentoPotenza(numeratore, esponente);
            }
            else
            {
                if (numeratore == 0)
                    return risultato;
                risultato.denominatore = elevamentoPotenza(numeratore, -esponente);
                risultato.numeratore = elevamentoPotenza(denominatore, -esponente);
            }
            risultato.semplifica();
            return risultato;
        }

        public override String ToString()
        {
            return numeratore + "/" + denominatore;
        }
    }
}
