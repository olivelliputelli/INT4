
namespace INT4.ClassLibrary
{
    public class Dado
    {
        public int Faccia { get; private set; }
        public bool IsBlocked { get; set; } = false;
        public Dado() { TiraDado(); }
        public void TiraDado() {
            if (IsBlocked) return;
            Faccia = Random.Shared.Next(1, 7);
        }
    }
}
