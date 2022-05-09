namespace Kalender
{
    public class Kalender
    {
        /// <summary>
        /// Berechnet die Anzahl der Tage eines Monats.
        /// </summary>
        /// <param name="monat">Monat in MM</param>
        /// <param name="schaltjahr">Schaltjahr ja/nein(optional, standardwert ist false)</param>
        /// <returns>Anzahl der Tage im gegebenen Monat</returns>
        public static int AnzahlTage(int monat, bool schaltjahr = false)
        {
            return monat switch
            {
                2 when schaltjahr => 29,
                2 when !schaltjahr => 28,
                _ => monat % 2 == 0 ? 30 : 31,
            };
        }

        /// <summary>
        /// Berechnet ob Jahr ein Schaltjahr ist.
        /// </summary>
        /// <param name="jahr"></param>
        /// <returns>true = Schaltjahr; false = kein Schaltjahr</returns>
        public static bool Schaltjahr(int jahr)
        {
            return jahr % 4 == 0 && (!(jahr % 100 == 0) || jahr % 400 == 0);
        }
    }
}