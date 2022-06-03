using Kalender;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace KalenderTests
{
    [TestClass()]
    public class KalenderblattTest
    {
        [TestMethod()]
        public void AnzahlTageTest_FebruarSchaltjahr()
        {
            int monat = 2;
            bool schaltjahr = true;
            int erwartet = 29;

            Assert.AreEqual(erwartet, Kalenderblatt.AnzahlTage(monat, schaltjahr));
        }

        [TestMethod()]
        public void AnzahlTageTest_FebruarKeinSchalt()
        {
            int monat = 2;
            int erwartet = 28;

            Assert.AreEqual(erwartet, Kalenderblatt.AnzahlTage(monat));
        }

        [TestMethod()]
        public void AnzahlTageTest_MonatGerade()
        {
            int monat = 6;
            int erwartet = 30;

            Assert.AreEqual(erwartet, Kalenderblatt.AnzahlTage(monat));
        }

        [TestMethod()]
        public void AnzahlTageTest_MonatUngerade()
        {
            int monat = 5;
            int erwartet = 31;

            Assert.AreEqual(erwartet, Kalenderblatt.AnzahlTage(monat));
        }

        [TestMethod()]
        public void SchaltjahrTest_Schaltjahr()
        {
            int jahr = 2024;
            bool erwartet = true;

            Assert.AreEqual(erwartet, Kalenderblatt.Schaltjahr(jahr));
        }

        [TestMethod()]
        public void SchaltjahrTest_keinSJ()
        {
            int jahr = 2023;
            bool erwartet = false;

            Assert.AreEqual(erwartet, Kalenderblatt.Schaltjahr(jahr));
        }
    }
}