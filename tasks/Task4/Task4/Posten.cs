using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Task4
{
   
    public abstract class Posten
    {
        public enum art
        {
            Belastung,
            Gutschrift
        }

        [JsonIgnore]
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
            Console.WriteLine("[Bezeichnung:{0,27}] [Bank:{1,10}]  [Betrag:{2,8:f2}]   [Frequenz{3,5:f2}]", Bezeichnung, Bank, Betrag, Frequenz);
        }

    }

    public class Belastung : Posten
    {
        public override bool CheckBetrag(decimal value)
        { if (value < 0) return true;
            else return false;
        }
        [JsonConstructor]
        public Belastung(decimal betrag, string bezeichnung, string bank, decimal frequenz)
        {
            if (betrag < 0) { Betrag = betrag; Art = art.Belastung; }
            else throw new Exception("Betrag für Belastung muss negativ sein");
            Bezeichnung = bezeichnung;
            Bank = bank;
            Frequenz = frequenz;

        }

        
        

    }


    public class Gutschrift : Posten
    {

        public override bool CheckBetrag(decimal value)
        {
            if (value > 0) return true;
            else return false;
        }

        [JsonConstructor]
        public Gutschrift(decimal betrag, string bezeichnung, string bank, decimal frequenz)
        {
            if (betrag > 0) { Betrag = betrag; Art = art.Gutschrift; }
            else throw new Exception("Gutschrift braucht positiven Betrag.");
            Bezeichnung = bezeichnung;
            Bank = bank;
            Frequenz = frequenz;

        }
     

      

    }

}