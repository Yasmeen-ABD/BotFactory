using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using BotFactory.Common.Tools;
using BotFactory.Common.Interface;

namespace BotFactory.Models
{
   public abstract class BaseUnit : ReportingUnit, IBaseUnit
    {
        public string Name { get; set; }
        public double Vitesse { get; set; }
        public double buildTime { get; set; }
        public Coordinates CurrentPos { get; set; }

        public BaseUnit()
        {

        }
        public BaseUnit(string name, double vitesse = 1)
        {
            this.Name = name;
            this.Vitesse = vitesse;
            this.CurrentPos = new Coordinates(0, 0);
        }

        public BaseUnit(double buildTime, double vitesse = 1)
            :base(buildTime)
        {
            this.Vitesse = vitesse;
            this.CurrentPos = new Coordinates(0, 0);
        }

        public BaseUnit(double buildTime, string name, double vitesse = 1)
            : base(buildTime)
        {
            this.Name = name;
            this.Vitesse = vitesse;
            this.CurrentPos = new Coordinates(0, 0);
        }
        
        public async Task<bool> Move(Coordinates departPos, Coordinates destinationPos)
        {
            return await MoveAsync(departPos, destinationPos);
        }

        private async Task<bool> MoveAsync(Coordinates departPos, Coordinates destinationPos)
        {
            try
            {
                if (!departPos.Equals(destinationPos))
                {
                    //var deplacement = Task.Run<double>(() =>
                    //{
                    double distance = Vector.Length(Vector.FromCoordinates(departPos, destinationPos));
                    int Time = Convert.ToInt32(distance / this.Vitesse);
                    //});

                    //await Task.Delay(Convert.ToInt32(deplacement.Result) * 1000);
                    await Task.Delay(Convert.ToInt32(Time) * 1000);
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
