using System;
using System.Collections.Generic;

namespace Kalender
{
    public class Kalenderblatt
    {
        private readonly int _monat, _anzahlTage, _ersterWochentag, _jahr;
        private readonly bool _schaltjahr;
        private readonly Dictionary<int, string> monatName = new Dictionary<int, string>
        {
            { 1, "Januar" },
            { 2, "Februar" },
            { 3, "März" },
            { 4, "April" },
            { 5, "Mai" },
            { 6, "Juni" },
            { 7, "Juli" },
            { 8, "August" },
            { 9, "September" },
            { 10, "Oktober" },
            { 11, "November" },
            { 12, "Dezember" }
        };

        public List<Feiertag> feiertage = new List<Feiertag>
        {
            new Feiertag(1, 1, "Neujahr"),
            new Feiertag(5, 1, "Tag der Arbeit"),
            new Feiertag(10, 3, "Tag der deutschen Einheit"),
            new Feiertag(12, 25, "erster Weihnachtsfeiertag"),
            new Feiertag(12, 26, "zweiter Weihnachtsfeiertag")
        };

        public Kalenderblatt(int monat, int jahr)
        {
            _monat = monat;
            _jahr = jahr;
            _schaltjahr = Schaltjahr(jahr);
            _anzahlTage = AnzahlTage(monat, _schaltjahr);
            _ersterWochentag = Wochentag.WochentagBerechnen(jahr, monat, 1, _schaltjahr);
            Feiertag ostern = FeiertageBerechnen.Ostern(jahr);
            feiertage.Add(FeiertageBerechnen.Karfreitag(ostern));
            feiertage.Add(ostern);
            feiertage.Add(FeiertageBerechnen.ChristiHimmefahrt(ostern));
        }

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
                // Februar im Schaltjahr.
                2 when schaltjahr => 29,
                // Februar wenn kein Schaltjahr.
                2 when !schaltjahr => 28,
                // Gerader Monat = 30 Tage, ungerade = 31 Tage.
                _ => monat % 2 == 0 ? 30 : 31,
            };
        }

        /// <summary>
        /// Berechnet ob ein Jahr ein Schaltjahr ist.
        /// </summary>
        /// <param name="jahr"></param>
        /// <returns>true = Schaltjahr; false = kein Schaltjahr</returns>
        public static bool Schaltjahr(int jahr)
        {
            // Schaltjahr, wenn Jahr durch 4 teilbar, aber nicht durch 100 teilbar, außer wenn durch 400 teilbar.
            return jahr % 4 == 0 && (!(jahr % 100 == 0) || jahr % 400 == 0);
        }

        /// <summary>
        /// Gibt Kalenderblatt aus
        /// </summary>
        public void PrintKalender()
        {
            string printLinie = string.Format("|{0,11}|{1,11}|{2,11}|{3,11}|{4,11}|{5,11}|{6,11}|", "___________",
                                              "___________", "___________", "___________", "___________", "___________",
                                              "___________");

            Console.WriteLine("{0, 45}", monatName[_monat] + " " + _jahr);
            Console.WriteLine(string.Format(" {0,11} {1,11} {2,11} {3,11} {4,11} {5,11} {6,11} ", "___________",
                                            "___________", "___________", "___________", "___________", "___________",
                                            "___________"));
            Console.WriteLine(string.Format("|{0,11}|{1,11}|{2,11}|{3,11}|{4,11}|{5,11}|{6,11}|", "Sonntag", "Montag",
                                            "Dienstag", "Mittwoch", "Donnerstag", "Freitag", "Samstag"));
            Console.WriteLine(printLinie);

            dynamic[] wochentagArray = new dynamic[7];
            int i = 1;

            for (int j = _ersterWochentag; j < 7; j++)
            {
                wochentagArray[j] = i;
                i++;
            }

            if (_ersterWochentag > 0)
            {
                for (int m = 0; m < _ersterWochentag; m++)
                {
                    wochentagArray[m] = null;
                }
            }

            Console.WriteLine(string.Format("|{0,11}|{1,11}|{2,11}|{3,11}|{4,11}|{5,11}|{6,11}|", wochentagArray[0],
                                            wochentagArray[1], wochentagArray[2], wochentagArray[3], wochentagArray[4],
                                            wochentagArray[5], wochentagArray[6]));
            Console.WriteLine(printLinie);

            for (int k = i; k <= _anzahlTage; k += 7)
            {
                for (int j = 0; j < 7; j++)
                {
                    if (k + j > _anzahlTage)
                    {
                        for (int l = j; l < 7; l++)
                        {
                            wochentagArray[l] = null;
                        }
                        break;
                    }
                    wochentagArray[j] = k + j;
                }

                Console.WriteLine(string.Format("|{0,11}|{1,11}|{2,11}|{3,11}|{4,11}|{5,11}|{6,11}|", wochentagArray[0],
                                                wochentagArray[1], wochentagArray[2], wochentagArray[3],
                                                wochentagArray[4], wochentagArray[5], wochentagArray[6]));
                Console.WriteLine(printLinie);
            }

            Console.WriteLine();

            foreach (Feiertag feriertag in feiertage)
            {
                if (feriertag.Monat == _monat)
                {
                    Console.WriteLine(feriertag.FeiertagName + ": " + feriertag.Tag + "." + feriertag.Monat + ".");
                }
            }
        }
    }
}