using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CechDobrodruhu
{
    public enum Zbran { Mec, Luk, Hul, Dyky }
    public enum Brneni { Latove, Kozene, Latkove }
    public enum TypObchodu { Lektvary, Zbrane, Brneni, Jidlo }

    public class ClenCechu
    {
        private string jmeno;
        public string Jmeno
        {
            get => jmeno;
            set { /* Doplnit logiku validace */ }
        }
        public int Zdravi { get; protected set; } = 100;
        public int Energie { get; protected set; } = 50;
        public int Uroven { get; protected set; } = 1;
        public bool JeAktivni { get; protected set; } = true;

        public ClenCechu(string jmeno) { this.jmeno = jmeno; }

        public void Trenuj(int pocet) { /* :p */ }
        public void UtrzZraneni(int dmg) { /* c: */ }
        public virtual void Odpocivej() { /* :D */ }
        public override string ToString() => "";
    }

    public class Dobrodruh : ClenCechu
    {
        public string Povolani { get; set; }
        private Zbran zbran;
        private Brneni brneni;
        public int Zkusenosti = 0;

        public Dobrodruh(string jmeno, string povolani, Zbran zbran, Brneni brneni) : base(jmeno) { }

        public void PridejZkusenosti(int xp) { }
        public bool PouzijSchopnost() => false;
        public override string ToString() => "";
    }

    public class Obchodnik : ClenCechu
    {
        public TypObchodu TypObchodu;
        public bool MaSlevu;
        public int PocetPredmetu = 10;

        public Obchodnik(string jmeno, TypObchodu typ, bool sleva) : base(jmeno) { }
        public Obchodnik(string jmeno, TypObchodu typ) : base(jmeno) { }

        public void Prodej(int pocet) { }
        public void DoplnZbozi(int pocet) { }
        public sealed override void Odpocivej() { }
    }
}