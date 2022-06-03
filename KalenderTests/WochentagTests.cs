using Kalender;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace KalenderTests
{
    [TestClass()]
    public class WochentagTests
    {
        [TestMethod()]
        public void WochentagBerechnenTestkeinSchaltjahr()
        {
            int jahr = 2022;
            int monat = 5;
            int tag = 6;
            bool schaltJahr = false;
            int erwartet = 5;

            Assert.AreEqual(erwartet, Wochentag.WochentagBerechnen(jahr, monat, tag, schaltJahr));
        }

        [TestMethod()]
        public void WochentagBerechnenTestSchaltjahrNachFebruar()
        {
            int jahr = 2024;
            int monat = 9;
            int tag = 23;
            bool schaltJahr = true;
            int erwartet = 1;

            Assert.AreEqual(erwartet, Wochentag.WochentagBerechnen(jahr, monat, tag, schaltJahr));
        }

        [TestMethod()]
        public void WochentagBerechnenTestSchaltjahrFebruar29()
        {
            int jahr = 2024;
            int monat = 2;
            int tag = 29;
            bool schaltJahr = true;
            int erwartet = 4;

            Assert.AreEqual(erwartet, Wochentag.WochentagBerechnen(jahr, monat, tag, schaltJahr));
        }

        [TestMethod()]
        public void WochentagBerechnenTestSchaltjahrJanuar()
        {
            int jahr = 2024;
            int monat = 1;
            int tag = 1;
            bool schaltJahr = true;
            int erwartet = 1;

            Assert.AreEqual(erwartet, Wochentag.WochentagBerechnen(jahr, monat, tag, schaltJahr));
        }

        [TestMethod()]
        public void WochentagBerechnenTestErsterGregorianischerTag()
        {
            int jahr = 1582;
            int monat = 10;
            int tag = 15;
            bool schaltJahr = false;
            int erwartet = 5;

            Assert.AreEqual(erwartet, Wochentag.WochentagBerechnen(jahr, monat, tag, schaltJahr));
        }

        [TestMethod()]
        public void WochentagBerechnenEnde3000()
        {
            int jahr = 3000;
            int monat = 12;
            int tag = 31;
            bool schaltJahr = false;
            int erwartet = 3;

            Assert.AreEqual(erwartet, Wochentag.WochentagBerechnen(jahr, monat, tag, schaltJahr));
        }

        [TestMethod()]
        public void JahrCodeTest()
        {
            int jahr = 2022;
            int erwartet = 6;

            Assert.AreEqual(erwartet, Wochentag.JahrCode(jahr));
        }
    }
}