namespace INT4.ClassLibrary
{
    public class Cerchio
    {
        private double raggio = 0.0;
        public double Raggio
        {
            get { return raggio; }
            set
            {
                if (value < 0 && value > 1_000_000)
                {
                    throw new Exception("Raggio negativo!!");
                }
                this.raggio = value;
            }
        }
        public Cerchio() { }
        public Cerchio(double value)
        {
            this.Raggio = value;
        }
        public double Area() => Math.PI * Math.Pow(Raggio, 2);
        public double Circonferenza() => 2 * Math.PI * Raggio;
    }

}
