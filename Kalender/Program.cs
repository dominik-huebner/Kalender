using System;

namespace Kalender
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            Console.Write("Monat: ");
            int monat = int.Parse(Console.ReadLine());
            Console.Write("Jahr: ");
            int jahr = int.Parse(Console.ReadLine());
            Kalenderblatt kalenderblatt = new(monat, jahr);
            kalenderblatt.PrintKalender();
        }
    }
}
