using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Kalender.Tests
{
    [TestClass()]
    public class KalenderBackTests
    {
        [TestMethod()]
        public void AnzahlTageTest_FebruarSchaltjahr()
        {
            int monat = 2;
            bool schaltjahr = true;
            int erwartet = 29;

            Assert.AreEqual(erwartet, KalenderBack.AnzahlTage(monat, schaltjahr));
        }

        [TestMethod()]
        public void AnzahlTageTest_FebruarKeinSchalt()
        {
            int monat = 2;
            int erwartet = 28;

            Assert.AreEqual(erwartet, KalenderBack.AnzahlTage(monat));
        }

        [TestMethod()]
        public void AnzahlTageTest_MonatGerade()
        {
            int monat = 6;
            int erwartet = 30;

            Assert.AreEqual(erwartet, KalenderBack.AnzahlTage(monat));
        }

        [TestMethod()]
        public void AnzahlTageTest_MonatUngerade()
        {
            int monat = 5;
            int erwartet = 31;

            Assert.AreEqual(erwartet, KalenderBack.AnzahlTage(monat));
        }
    }
}