using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public interface Posten
{
    decimal get_Monat();
    string Bezeichnung { get; set; }
    string get_Art();

}

//Codeduplizierung zwischen Belastung und Gutscrhift weil laut Angabe explizit Interface gefragt - vieles hätte in eine "substanzreichere" abstrakte Basisklasse Posten besser gepasst.
public class Belastung:Posten
{
    enum art
        {
          Belastung,
          Gutschrift
        }
    private art Art;
    private decimal Betrag;
    private string _Bezeichnung;
    public string Bezeichnung { get { return _Bezeichnung; }
                                set {
                                        if (string.IsNullOrWhiteSpace(value)) throw new Exception("Bezeichnung fehlt");
                                            else _Bezeichnung = value;
                                    }
                                }


    private string _Bank;
    public string Bank { get { return _Bank; }
                         set
                             {
                                if (string.IsNullOrWhiteSpace(value)) throw new Exception("Bankname fehlt");
                                else _Bank = value;
                             }
                        }


    private decimal _Frequenz;
    public decimal Frequenz { get { return _Frequenz; }
                            set {
                                     if (value <= 0) throw new Exception("Frequenz muss positiv sein");
                                     else _Frequenz = value;
                                 }
                           }
    public Belastung(decimal Betrag_neu, string Bezeichnung_neu, string Bank_neu, decimal Frequenz_neu)
    {
        if (Betrag_neu < 0) { Betrag = Betrag_neu; Art = art.Belastung; }
        else throw new Exception("Betrag für Belastung muss negativ sein");
        Bezeichnung = Bezeichnung_neu;
        Bank = Bank_neu;
        Frequenz = Frequenz_neu;

    }

    public string get_Art()
    {
        if (Art == art.Belastung) return "Belastung";
        else return "Gutschrift";
    }
    public decimal get_Monat()
    {
        return (decimal)Frequenz * Betrag;
    }
        
}


public class Gutschrift : Posten
{
    enum art
    {
        Belastung,
        Gutschrift
    }
    private art Art;
    private decimal Betrag;
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
    public Gutschrift(decimal Betrag_neu, string Bezeichnung_neu, string Bank_neu, decimal Frequenz_neu)
    {
        if (Betrag_neu > 0) { Betrag = Betrag_neu; Art = art.Gutschrift; }
        else throw new Exception("Gutschrift braucht positiven Betrag.");
        Bezeichnung = Bezeichnung_neu;
        Bank = Bank_neu;
        Frequenz = Frequenz_neu;

    }
    public string get_Art()
    {
        if (Art == art.Belastung) return "Belastung";
        else return "Gutschrift";
    }

    public decimal get_Monat()
    {
        return (decimal)Frequenz * Betrag;
    }

}


namespace Task2
{
    class Program
    {
        static void Main(string[] args)
        {
            /*
             var a = new Belastung(-20.99m,"Handyrechnung","Ba-Ca",1);
             var b = new Belastung(-182m, "Strom", "Raika", 0.3333);
             var c = new Gutschrift(150m, "Kindergeld", "Spaßbank", 1);
             Console.WriteLine("Monatlich wirkt sich posten a mit {0}Euro aus, Posten b mit {1}Euro und Posten c mit {2} Euro", a.get_Monat(), b.get_Monat(), c.get_Monat());
             */
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
                Console.WriteLine("\nMonatlich wirkt sich Posten'"+x.Bezeichnung+"' mit {0} aus. Es handelt sich um eine {1}",x.get_Monat(),x.get_Art());
            }

        }
        
    }
    
}
