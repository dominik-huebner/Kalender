using System;

namespace Kalender
{
    internal class Program
    {
        private static void Main()
        {
            int monat = 0;
            int jahr = 0;

            while (true)
            {
                bool monatSuccess = false;
                bool jahrSuccess = false;

                while (!monatSuccess)
                {
                    Console.WriteLine("Gib eine Zahl zwischen 1 (Januar) und 12 (Dezember) ein \nGib exit ein um das Programm zu beenden");

                    Console.Write("Monat: ");
                    string inputMonat = Console.ReadLine();
                    monatSuccess = int.TryParse(inputMonat, out monat);

                    if (!monatSuccess || monat > 12 || monat < 1)
                    {
                        if (string.Equals(inputMonat.ToLower(), "exit"))
                        {
                            Environment.Exit(0);
                        }

                        monatSuccess = false;
                    }
                }

                while (!jahrSuccess)
                {
                    Console.WriteLine("Gib ein Jahr zwischen 1582 und 3000 ein \nGib exit ein um das Programm zu beenden");
                    Console.Write("Jahr: ");
                    string inputJahr = Console.ReadLine();
                    jahrSuccess = int.TryParse(inputJahr, out jahr);

                    if (!jahrSuccess || jahr > 3000 || jahr < 1582)
                    {
                        if (string.Equals(inputJahr.ToLower(), "exit"))
                        {
                            Environment.Exit(0);
                        }

                        jahrSuccess = false;
                    }
                }

                if (monatSuccess && jahrSuccess)
                {
                    Kalenderblatt kalenderblatt = new(monat, jahr);
                    kalenderblatt.PrintKalender();
                }
                Console.WriteLine();
            }
        }
    }
}