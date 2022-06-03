namespace Kalender
{
    public class FeiertageBerechnen
    {
        /// <summary>
        /// Berechnet den Ostermontag mithilfe der Gaußschen Osterformel
        /// https://de.wikipedia.org/wiki/Gau%C3%9Fsche_Osterformel
        /// </summary>
        /// <param name="jahr"></param>
        /// <returns></returns>
        public static Feiertag Ostern(int jahr)
        {
            float a, b, c, p, q,
            m, n, d, e;

            a = jahr % 19;
            b = jahr % 4;
            c = jahr % 7;
            p = jahr / 100;
            q = (float)(
                (13 + (8 * p)) / 25);
            m = (15 - q + p - (p / 4)) % 30;
            n = (4 + p - (p / 4)) % 7;
            d = ((19 * a) + m) % 30;
            e = ((2 * b) + (4 * c) + (6 * d) + n) % 7;
            int days = (int)(22 + d + e);

            return (d == 29) && (e == 6)
                ? new Feiertag(4, 20, "Ostermontag")
                : (d == 28) && (e == 6)
                    ? new Feiertag(4, 19, "Ostermontag")
                    : days > 31 ? new Feiertag(4, days - 30, "Ostermontag") : new Feiertag(3, days + 1, "Ostermontag");
        }

        /// <summary>
        /// Berechnet Karfreitag
        /// </summary>
        /// <param name="ostermontag"></param>
        /// <returns></returns>
        public static Feiertag Karfreitag(Feiertag ostermontag)
        {
            return ostermontag.Tag - 3 > 0
                ? new Feiertag(ostermontag.Monat, ostermontag.Tag - 3, "Karfreitag")
                : new Feiertag(ostermontag.Monat - 1, 31 - (ostermontag.Tag - 3), "Karfreitag");
        }

        public static Feiertag ChristiHimmefahrt(Feiertag ostermontag)
        {
            int tag = ostermontag.Tag;
            int tage = ostermontag.Monat == 3 ? 31 : 30;
            int monat = ostermontag.Monat;
            for (int i = 0; i < 37; i++)
            {
                if (tag == tage)
                {
                    tag = 1;
                    monat++;
                    tage = monat == 3 ? 31 : 30;
                }
                tag++;
            }

            return new Feiertag(monat, tag, "Christi Himmelfahrt");
        }
    }
}
