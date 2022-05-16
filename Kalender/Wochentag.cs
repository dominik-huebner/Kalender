using System.Collections.Generic;

namespace Kalender
{
    public class Wochentag
    {
        private static readonly Dictionary<int, int> _monatCode = new()
        {
            { 1, 0 },
            { 2, 3 },
            { 3, 3 },
            { 4, 6 },
            { 5, 1 },
            { 6, 4 },
            { 7, 6 },
            { 8, 2 },
            { 9, 5 },
            { 10, 0 },
            { 11, 3 },
            { 12, 5 }
        };

        private static readonly Dictionary<int, int> _jHCode = new()
        {
            { 15, 0 },
            { 19, 0 },
            { 23, 0 },
            { 27, 0 },
            { 16, 6 },
            { 20, 6 },
            { 24, 6 },
            { 28, 6 },
            { 17, 4 },
            { 21, 4 },
            { 25, 4 },
            { 29, 4 },
            { 18, 2 },
            { 22, 2 },
            { 26, 2 },
            { 30, 2 }
        };

        /// <summary>
        /// Berechnet den Wochentag eines Datums.
        /// Rechenmethode: https://artofmemory.com/blog/how-to-calculate-the-day-of-the-week/
        /// </summary>
        /// <param name="jahr">Jahr in YYYY</param>
        /// <param name="monat">Monat in MM</param>
        /// <param name="tag">Tag in DD</param>
        /// <param name="schaltJahr">true = schaltjahr; false = kein schaltjahr</param>
        /// <returns>Wochentag von 0(Sonntag) bis 6(Samstag)</returns>
        public static int WochentagBerechnen(int jahr, int monat, int tag, bool schaltJahr)
        {
            switch (monat)
            {
                // Wenn Monat Januar oder Frebruar im Schaltjahr.
                case 1 when schaltJahr:
                case 2 when schaltJahr:
                    return (JahrCode(jahr)
                        + _monatCode[monat]
                        + _jHCode[int.Parse(jahr.ToString().Substring(0, 2))]
                        + tag - 1) % 7;
                // Wenn kein Schaltjahr oder Schaltjahr nach Februar.
                default:
                    return (JahrCode(jahr)
                        + _monatCode[monat]
                        + _jHCode[int.Parse(jahr.ToString().Substring(0, 2))]
                        + tag) % 7;
            }
        }

        /// <summary>
        /// Berechnet den Jahrescode.
        /// </summary>
        /// <param name="jahr">Jahr in YYYY</param>
        /// <returns>Jahrescode</returns>
        public static int JahrCode(int jahr)
        {
            // Die letzten beide Stellen des Jahrs (yyYY).
            int jahr2letzteStellen = int.Parse(jahr.ToString()[^2..]);

            return (jahr2letzteStellen + jahr2letzteStellen / 4) % 7;
        }
    }
}