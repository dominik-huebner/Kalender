using System;

namespace Kalender
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            Kalenderblatt kalenderblatt = new(6, 2022);
            kalenderblatt.PrintKalender();
        }
    }
}
