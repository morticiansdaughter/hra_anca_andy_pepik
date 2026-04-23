using Microsoft.VisualStudio.TestTools.UnitTesting;
using hra;
using CechDobrodruhu;

namespace hra.Tests
{
    [TestClass]
    public class CechTests
    {

        [TestMethod]
        public void ClenCechu_Vytvoreni_NastaviVychoziHodnoty()
        {
            ClenCechu clen = new ClenCechu("Geralt");
            Assert.AreEqual(100, clen.Zdravi);
            Assert.AreEqual(50, clen.Energie);
            Assert.AreEqual(1, clen.Uroven);
            Assert.IsTrue(clen.JeAktivni);
        }

        [TestMethod]
        public void Jmeno_PrilisDlouhe_NeuloziSe()
        {
            ClenCechu clen = new ClenCechu("PuvodniJmeno");
            clen.Jmeno = "TohleJmenoJeMocDlouheNaCech";
            Assert.AreEqual("PuvodniJmeno", clen.Jmeno);
        }

        [TestMethod]
        public void Jmeno_NullNeboPrazdne_NeuloziSe()
        {
            ClenCechu clen = new ClenCechu("Puvodni");
            clen.Jmeno = "";
            Assert.AreEqual("Puvodni", clen.Jmeno);
        }

        [TestMethod]
        public void Trenuj_KladnaHodnota_ZvysiEnergii()
        {
            ClenCechu clen = new ClenCechu("Test");
            clen.Trenuj(20);
            Assert.AreEqual(70, clen.Energie);
        }

        [TestMethod]
        public void Trenuj_PresMaximum_ZustaneNa100()
        {
            ClenCechu clen = new ClenCechu("Test");
            clen.Trenuj(200);
            Assert.AreEqual(100, clen.Energie);
        }

        [TestMethod]
        public void UtrzZraneni_VelkyDmg_NastaviAktivituNaFalse()
        {
            ClenCechu clen = new ClenCechu("Test");
            clen.UtrzZraneni(150);
            Assert.AreEqual(0, clen.Zdravi);
            Assert.IsFalse(clen.JeAktivni);
        }

        [TestMethod]
        public void UtrzZraneni_ZapornyDmg_NicSeNestane()
        {
            ClenCechu clen = new ClenCechu("Test");
            clen.UtrzZraneni(-50);
            Assert.AreEqual(100, clen.Zdravi);
        }

        [TestMethod]
        public void Odpocivej_ZvysiZdraviAEnergii()
        {
            ClenCechu clen = new ClenCechu("Test");
            clen.UtrzZraneni(20); 
            clen.Odpocivej();
            Assert.AreEqual(90, clen.Zdravi);
            Assert.AreEqual(55, clen.Energie);
        }

        

        [TestMethod]
        public void Dobrodruh_NeplatnePovolani_NeuloziSe()
        {
            Dobrodruh d = new Dobrodruh("Conan", "Válečník", Zbran.Mec, Brneni.Latove);
            d.Povolani = "Uklizec"; 
            Assert.AreEqual("Válečník", d.Povolani);
        }

        [TestMethod]
        public void PridejZkusenosti_LevelUp_ZvysiUroven()
        {
            Dobrodruh d = new Dobrodruh("Mág", "Mág", Zbran.Hul, Brneni.Latkove);
            d.PridejZkusenosti(150); 
            Assert.AreEqual(2, d.Uroven);
        }

        [TestMethod]
        public void PridejZkusenosti_Zaporne_NicSeNestane()
        {
            Dobrodruh d = new Dobrodruh("X", "Zloděj", Zbran.Dyky, Brneni.Kozene);
            d.PridejZkusenosti(-100);
            Assert.AreEqual(0, d.Zkusenosti);
        }

        [TestMethod]
        public void PouzijSchopnost_DostatekEnergie_VratiTrueASebereEnergii()
        {
            Dobrodruh d = new Dobrodruh("X", "Mág", Zbran.Hul, Brneni.Latkove);
            bool vysledek = d.PouzijSchopnost();
            Assert.IsTrue(vysledek);
            Assert.AreEqual(40, d.Energie);
        }

        [TestMethod]
        public void PouzijSchopnost_MaloEnergie_VratiFalse()
        {
            Dobrodruh d = new Dobrodruh("X", "Mág", Zbran.Hul, Brneni.Latkove);
         
            for (int i = 0; i < 5; i++)
            {
                d.PouzijSchopnost();
            }

            bool vysledek = d.PouzijSchopnost(); 
            Assert.IsFalse(vysledek);
        }

       

        [TestMethod]
        public void Obchodnik_DruhyKonstruktor_MaSlevuJeFalse()
        {
            Obchodnik o = new Obchodnik("Trhovec", TypObchodu.Jidlo);
            Assert.IsFalse(o.MaSlevu);
        }

        [TestMethod]
        public void Obchodnik_VychoziPocetPredmetu_JeDeset()
        {
            Obchodnik o = new Obchodnik("Trhovec", TypObchodu.Zbrane);
            Assert.AreEqual(10, o.PocetPredmetu);
        }

        [TestMethod]
        public void Prodej_PlatnyPocet_SniziZasoby()
        {
            Obchodnik o = new Obchodnik("Trhovec", TypObchodu.Brneni);
            o.Prodej(3);
            Assert.AreEqual(7, o.PocetPredmetu);
        }

        [TestMethod]
        public void Prodej_ViceNezJeSkladem_ZustaneNula()
        {
            Obchodnik o = new Obchodnik("Trhovec", TypObchodu.Lektvary);
            o.Prodej(50);
            Assert.AreEqual(0, o.PocetPredmetu);
        }

        [TestMethod]
        public void DoplnZbozi_Kladne_PridáPredmety()
        {
            Obchodnik o = new Obchodnik("Trhovec", TypObchodu.Jidlo);
            o.DoplnZbozi(5);
            Assert.AreEqual(15, o.PocetPredmetu);
        }

        [TestMethod]
        public void DoplnZbozi_Zaporne_NicSeNestane()
        {
            Obchodnik o = new Obchodnik("Trhovec", TypObchodu.Jidlo);
            o.DoplnZbozi(-10);
            Assert.AreEqual(10, o.PocetPredmetu);
        }

        [TestMethod]
        public void Obchodnik_Odpocivej_NezvysujeEnergii()
        {
            Obchodnik o = new Obchodnik("Trhovec", TypObchodu.Jidlo);
            int puvodniEnergie = o.Energie;
            o.Odpocivej();
            Assert.AreEqual(puvodniEnergie, o.Energie);
        }

        [TestMethod]
        public void Obchodnik_Odpocivej_ZvysiZdraviO5()
        {
            Obchodnik o = new Obchodnik("Trhovec", TypObchodu.Jidlo);
            o.UtrzZraneni(10); 
            o.Odpocivej();
            Assert.AreEqual(95, o.Zdravi);
        }
    }
}