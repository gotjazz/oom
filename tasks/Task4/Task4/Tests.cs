using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace Task4
{
    [TestFixture]
    class Tests
    {
        [Test]
        public void BetragBelastung()
        {
            Assert.Catch(() =>
            {
                var x = new Belastung(25m,"Test","Test",1);
            });
        }

        [Test]
        public void BetragGutschrift()
        {
            Assert.Catch(() =>
            {
                var x = new Gutschrift(-25m, "Test", "Test", 1);
            });
        }

        [Test]
        public void BelastungErstellen()
        {
            var x = new Belastung(-25m, "Test", "Test", 1);

            Assert.IsTrue(x.Betrag == -25m);
            Assert.IsTrue(x.Bezeichnung == "Test");
            Assert.IsTrue(x.Bank == "Test");
            Assert.IsTrue(x.Frequenz == 1);
        }

        [Test]
        public void GutschriftErstellen()
        {
            var x = new Gutschrift(25m, "Test", "Test", 1);

            Assert.IsTrue(x.Betrag == 25m);
            Assert.IsTrue(x.Bezeichnung == "Test");
            Assert.IsTrue(x.Bank == "Test");
            Assert.IsTrue(x.Frequenz == 1);
        }


        [Test]
        public void BezeichnungGutschrift()
        {
            Assert.Catch(() =>
            {
                var x = new Gutschrift(25m, "", "Test", 1);
            });
        }

        [Test]
        public void BezeichnungBelastung()
        {
            Assert.Catch(() =>
            {
                var x = new Belastung(25m, "", "Test", 1);
            });
        }

        [Test]
        public void BankBelastung()
        {
            Assert.Catch(() =>
            {
                var x = new Belastung(25m, "Test", "", 1);
            });
        }

        [Test]
        public void BankGutschrift()
        {
            Assert.Catch(() =>
            {
                var x = new Gutschrift(25m, "Test", "", 1);
            });
        }

        [Test]
        public void FrequenzBelastung()
        {
            Assert.Catch(() =>
            {
                var x = new Belastung(25m, "Test", "Test", -1);
            });
        }

        [Test]
        public void FrequenzGutschrift()
        {
            Assert.Catch(() =>
            {
                var x = new Gutschrift(25m, "Test", "Test", -1);
            });
        }

        [Test]
        public void GetMonatTest()
        {
            var MeinePosten = new Posten[]
           {
            new Belastung(-20.99m,"Handyrechnung","Ba-Ca",1),
            new Belastung(-182m, "Strom", "Raika", 0.3333m),
            new Gutschrift(150m, "Kindergeld", "Spaßbank", 1),
            new Belastung(-40m, "Handyrechnung2", "Ba-Ca", 1),
            new Belastung(-32m, "Laptopraten", "Raika", 1),
            new Gutschrift(55m, "Gehalt", "Spaßbank", (14m/12m)),
            new Belastung(-110.99m, "Fernwärme", "Ba-Ca", 1),
            new Belastung(-83m, "Zusatzversicherung Junior", "Raika", 1),
            new Gutschrift(150m, "Kindergeld", "Spaßbank", 1),
           };

            foreach (var x in MeinePosten)
            {
                decimal y = x.get_Monat();
                Assert.IsTrue(y == (x.Frequenz * x.Betrag));
            }
        }
    }
}
