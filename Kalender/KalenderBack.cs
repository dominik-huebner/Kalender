namespace Kalender
{
    public class KalenderBack
    {
        /// <summary>
        /// Nimmt Monat und den optionalen Parameter Schaltjahr(als bool) als Eingabe und gibt die Anzahl der Tage in dem Monat zurück
        /// </summary>
        /// <param name="monat">Monat</param>
        /// <param name="schaltjahr">Schaltjahr ja/nein(optional, standardwert ist false)</param>
        /// <returns>Anzahl der Tage in dem Monat</returns>
        public static int AnzahlTage(int monat, bool schaltjahr = false)
        {
            if (monat == 2 && schaltjahr) // wenn monat Februar und Schaltjahr
            {
                return 29;
            }
            else if (monat == 2 && !schaltjahr) // wenn monat Februar und kein Schaltjahr
            {
                return 28;
            }
            else if (monat % 2 == 0) // wenn monat gerade Zahl
            {
                return 30;
            }
            else // wenn monat keine gerade Zahl
            {
                return 31;
            }
        }

        /// <summary>
        /// Berechnet ob Jahr ein Schaltjahr ist
        /// </summary>
        /// <param name="jahr"></param>
        /// <returns></returns>
        public static bool Schaltjahr(int jahr)
        {
            if (jahr % 4 == 0 && (!(jahr % 100 == 0) || jahr % 400 == 0))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
