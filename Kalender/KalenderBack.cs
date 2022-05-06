using System;

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

    public class Wochentag
    {
        public static int JahrCode(int jahr)
        {
            string jahrString = jahr.ToString();
            int jahr2letzteStellen = int.Parse(jahrString.Substring(jahrString.Length - 2));
            int jahrCode = (jahr2letzteStellen + (int)(jahr2letzteStellen / 4)) % 7;

            return jahrCode;
        }

        public static int MonatCode(int monat)
        {
            int monatCode = 0;

            if (monat == 1 || monat == 10)
            {
                monatCode = 0;
            }
            else if (monat == 2 || monat == 3 || monat == 11)
            {
                monatCode = 3;
            }
            else if (monat == 4 || monat == 7)
            {
                monatCode = 6;
            }
            else if (monat == 5)
            {
                monatCode = 1;
            }
            else if (monat == 6)
            {
                monatCode = 4;
            }
            else if (monat == 8)
            {
                monatCode = 2;
            }
            else if (monat == 9 || monat == 12)
            {
                monatCode = 5;
            }

            return monatCode;
        }

        public static int JHundertCode(int jahr)
        {
            string jahrString = jahr.ToString();
            int jhundertCode = 0;
            int jahrhundert = int.Parse(jahrString.Substring(0, 2));

            if (jahrhundert == 15 || jahrhundert == 19 || jahrhundert == 23 || jahrhundert == 27)
            {
                jhundertCode = 0;
            }
            else if (jahrhundert == 16 || jahrhundert == 20 || jahrhundert == 24 || jahrhundert == 28)
            {
                jhundertCode = 6;
            }
            else if (jahrhundert == 17 || jahrhundert == 21 || jahrhundert == 25 || jahrhundert == 29)
            {
                jhundertCode = 4;
            }
            else if (jahrhundert == 18 || jahrhundert == 22 || jahrhundert == 26 || jahrhundert == 30)
            {
                jhundertCode = 2;
            }

            return jhundertCode;
        }

        public static int WochentagFunktion(int jahr, int monat, int tag)
        {
            bool schaltJahr = KalenderBack.Schaltjahr(jahr);
            int jahrCode = JahrCode(jahr);
            int monatCode = MonatCode(monat);
            int jHundertCode = JHundertCode(jahr);

            if (monat == 1 && schaltJahr || monat == 2 && schaltJahr)
            {
                return (jahrCode + monatCode + jHundertCode + tag - 1) % 7;
            }
            else
            {
                return (jahrCode + monatCode + jHundertCode + tag) % 7;
            }
        }
    }
}
