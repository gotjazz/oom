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
    class asyncs
    {
        public static Task<decimal> kontostand(decimal belastungen)
        {
            //Task.Delay(TimeSpan.FromSeconds(5.0)).Wait();
            decimal kontostand = 5000;
            return Task.Run(() =>
            {

                return kontostand + belastungen;
            });
        }

        public static async Task<bool> pleiteChek(decimal belastungen)
        {
            var random = new Random();
            decimal stand = await kontostand(belastungen);
            //Zahlungsverzögerung
            Task.Delay(TimeSpan.FromSeconds(0.5 + random.Next(2))).Wait();
            if (stand <= 0) return true;
            else return false;

        }

        public static async Task<bool> pleite(decimal belastungen)
        {
            bool Pleite = await pleiteChek(belastungen);
            return Pleite;

        }
    }
}
