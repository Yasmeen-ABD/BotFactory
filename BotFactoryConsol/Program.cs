using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BotFactory.Common.Tools;
using BotFactory.Factories;
using BotFactory.Models;

namespace BotFactoryConsol
{
    class Program
    {
        static void Main(string[] args)
        {
            Coordinates from = new Coordinates(2, 9);
            Coordinates to = new Coordinates(21, 19);

            UnitFactory uf = new UnitFactory(5, 7);

            Console.WriteLine("Les emplacements libres pour la queue : " + uf.QueueFreeSlots);
            Console.WriteLine("Les emplacements libres pour l'l’entrepôt : " + uf.StorageFreeSlots);


            uf.AddWorkableUnitToQueue(typeof(T_800), "le T 800", from, to);
            //uf.AddWorkableUnitToQueue(typeof(Wall_E), "le Wall E", from, to);
            //uf.AddWorkableUnitToQueue(typeof(T_800), "le T 800", from, to);
            //uf.AddWorkableUnitToQueue(typeof(T_800), "le T 800", from, to);


            Console.WriteLine("Press any key to exit ...!");
            Console.ReadLine();

        }
    }
}
