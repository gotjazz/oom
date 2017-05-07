using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


public class Posten
{
    enum art
        { Belastung,
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


    private double _Frequenz;
    public double Frequenz { get { return _Frequenz; }
                            set {
                                     if (value <= 0) throw new Exception("Frequenz muss positiv sein");
                                     else _Frequenz = value;
                                 }
                           }
    public Posten(decimal Betrag_neu, string Bezeichnung_neu, string Bank_neu, double Frequenz_neu)
    {
        if (Betrag_neu < 0) { Betrag = Betrag_neu; Art = art.Belastung; }
        else if (Betrag_neu > 0) { Betrag = Betrag_neu; Art = art.Gutschrift; }
        else throw new Exception("Betrag darf nicht 0 sein");
        Bezeichnung = Bezeichnung_neu;
        Bank = Bank_neu;
        Frequenz = Frequenz_neu;

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
           
            var a = new Posten(-20.99m,"Handyrechnung","Ba-Ca",1);
            var b = new Posten(-182m, "Strom", "Raika", 0.3333);
            var c = new Posten(150m, "Kindergeld", "Spaßbank", 1);
            Console.WriteLine("Monatlich wirkt sich posten a mit {0}Euro aus, Posten b mit {1}Euro und Posten c mit {2} Euro", a.get_Monat(), b.get_Monat(), c.get_Monat());
        }
    }
}
