using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

using Exchange;

namespace Example
{
    class Program
    {
        static void Main(string[] args)
        {
            BinanceInstance binance = new BinanceInstance();
            binance.PopulatePairGraph("./binance-pairs.txt");
            binance.Connect();

            while (!binance.TickerData.Any())
                Thread.Sleep(500);

            Console.WriteLine("Got ticker data");

            while(true)
            {
                Thread.Sleep(1000);
                Console.WriteLine(binance.TickerData[new Ticker("BTC", "USD")]);
            }
        }
    }
}
