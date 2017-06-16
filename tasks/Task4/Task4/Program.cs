using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.IO;
using System.Reactive.Linq;
using System.Reactive.Subjects;
using System.Threading;




namespace Task4
{
   
    class Program
    {
        public static bool IsOdd(decimal value)
        {
            return value % 2 != 0;
        }


        static void Main(string[] args)
        {
            var schuldensammlung = new Subject<Posten>();
            var count = 100;
            var random = new Random();
            var mammamia = new Subject<Posten>();
            Posten bla = null;
            bool check = true;
            decimal betragtotal = 0;
           
            var BigOne = Task<Posten>.Run(() =>
            {
            while (true)
            {
                    
                    while (check)
                    { 

                    mammamia
                    .Where(x => x != null)
                     .Do(x => bla=x)
                     .Subscribe()
                     ;

                    if (bla != null)
                    {
                        check = false;
                        return bla;
                    }

                    }




                }
            });



            schuldensammlung
                .Where(x => IsOdd(x.Frequenz)) 
                .Do(x => x.PrintPosten())
                .Where(x=> x.Frequenz > 106)
                .Subscribe(x =>
                {
                   Console.WriteLine($"Consumed Posten NR.{count}");

                })
                
                ;
            
          
                System.Threading.Thread.Sleep(TimeSpan.FromSeconds(1));
                var Schuldenfalle = Task<Posten>.Run(() =>
                {
                    while (true)
                    {
                        Task.Delay(TimeSpan.FromSeconds(0.5 + random.Next(2))).Wait();

                        var p = new Belastung(-1 - count * 2, "Posten " + count + "", "Thievery Corp.", count);
                        betragtotal = betragtotal + p.Betrag;
                        schuldensammlung.OnNext(p);
                        Console.WriteLine($"Created Posten NR.{count}");
                        count++;
                        if (p.Betrag < -220) mammamia.OnNext(p);
                        if (asyncs.pleite(betragtotal).Result)
                        {
                            Console.WriteLine("IT'S ALL OVER !!!!!!!!");
                            System.Environment.Exit(1);
                        }
                        

                    }
                });

            BigOne.ContinueWith(x => Console.WriteLine($"YAY!!! WE'VE REACHED {x.Result.Betrag}"));
            

            Console.ReadLine();



            /*
             var a = new Belastung(-20.99m,"Handyrechnung","Ba-Ca",1);
             var b = new Belastung(-182m, "Strom", "Raika", 0.3333);
             var c = new Gutschrift(150m, "Kindergeld", "Spaßbank", 1);
             Console.WriteLine("Monatlich wirkt sich posten a mit {0}Euro aus, Posten b mit {1}Euro und Posten c mit {2} Euro", a.get_Monat(), b.get_Monat(), c.get_Monat());
           */
            /* var MeinePosten = new Posten[]
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
             };*/

            /*foreach (var x in MeinePosten)
            {
                Console.WriteLine("\nMonatlich wirkt sich Posten'" + x.Bezeichnung + "' mit {0} aus. Es handelt sich um eine {1}", x.get_Monat(), x.get_Art());
            }
            */
            /*var settings = new JsonSerializerSettings() { Formatting = Formatting.Indented, TypeNameHandling = TypeNameHandling.Auto };
            var text = JsonConvert.SerializeObject(MeinePosten, settings);
            var folder = Environment.CurrentDirectory;
            var meinfile = Path.Combine(folder, "mein.json");
            File.WriteAllText(meinfile, text);

            var textImport = File.ReadAllText(meinfile);

            string line = "";
            using (StreamReader sr = new StreamReader(meinfile))
            {
                while ((line = sr.ReadLine()) != null)
                {
                    Console.WriteLine(line);
                }
            }
            */

            //Console.WriteLine(meinfile);
            //var import = JsonConvert.DeserializeObject<Posten[]>(JsonConvert.SerializeObject(MeinePosten, settings), settings);
            //var import = JsonConvert.DeserializeObject<Posten[]>(File.ReadAllText(meinfile), settings);
            /*var import = JsonConvert.DeserializeObject<Posten[]>(text, settings);
            foreach (var x in import) x.PrintPosten();

            File.Delete(meinfile);
            */

        }

    }

}
