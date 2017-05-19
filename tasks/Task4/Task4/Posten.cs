using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace Task4
{

    public abstract class Posten
    {
        public enum art
        {
            Belastung,
            Gutschrift
        }
        public art Art;
        private decimal _Betrag;
        public virtual decimal Betrag
        {
            get
            { return _Betrag; }

                set
                {
                if (CheckBetrag(value) == true) _Betrag = value;
                else throw new Exception("Betrag passt nicht zu Art!");
                }
         }
        private string _Bezeichnung;
        public string Bezeichnung
        {
            get { return _Bezeichnung; }
            set
            {
                if (string.IsNullOrWhiteSpace(value)) throw new Exception("Bezeichnung fehlt");
                else _Bezeichnung = value;
            }
        }

        private string _Bank;
        public string Bank
        {
            get { return _Bank; }
            set
            {
                if (string.IsNullOrWhiteSpace(value)) throw new Exception("Bankname fehlt");
                else _Bank = value;
            }
        }

        private decimal _Frequenz;
        public decimal Frequenz
        {
            get { return _Frequenz; }
            set
            {
                if (value <= 0) throw new Exception("Frequenz muss positiv sein");
                else _Frequenz = value;
            }
        }

        public decimal get_Monat()
        {
            return (decimal)Frequenz * Betrag;
        }
        
        public string get_Art()
        {
            if (Art == art.Belastung) return "Belastung";
            else return "Gutschrift";
        }

        public abstract bool CheckBetrag(decimal value);
    
        public void PrintPosten()
        {
            Console.WriteLine("[Bezeichnung:{0}] [Bank:{1}]  [Betrag:{2}]   [Frequenz{3}]", Bezeichnung, Bank, Betrag, Frequenz);
        }

    }

    //Codeduplizierung zwischen Belastung und Gutscrhift weil laut Angabe explizit Interface gefragt - vieles hätte in eine "substanzreichere" abstrakte Basisklasse Posten besser gepasst.
    public class Belastung : Posten
    {
        public override bool CheckBetrag(decimal value)
        { if (value < 0) return true;
            else return false;
        }

        public Belastung(decimal Betrag_neu, string Bezeichnung_neu, string Bank_neu, decimal Frequenz_neu)
        {
            if (Betrag_neu < 0) { Betrag = Betrag_neu; Art = art.Belastung; }
            else throw new Exception("Betrag für Belastung muss negativ sein");
            Bezeichnung = Bezeichnung_neu;
            Bank = Bank_neu;
            Frequenz = Frequenz_neu;

        }

        
        

    }


    public class Gutschrift : Posten
    {

        public override bool CheckBetrag(decimal value)
        {
            if (value > 0) return true;
            else return false;
        }


        public Gutschrift(decimal Betrag_neu, string Bezeichnung_neu, string Bank_neu, decimal Frequenz_neu)
        {
            if (Betrag_neu > 0) { Betrag = Betrag_neu; Art = art.Gutschrift; }
            else throw new Exception("Gutschrift braucht positiven Betrag.");
            Bezeichnung = Bezeichnung_neu;
            Bank = Bank_neu;
            Frequenz = Frequenz_neu;

        }
     

      

    }

}