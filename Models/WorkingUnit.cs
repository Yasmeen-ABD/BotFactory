using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BotFactory.Common.Tools;
using BotFactory.Common.Interface;

namespace BotFactory.Models
{
    public abstract class WorkingUnit : BaseUnit, IWorkingUnit
    {
        public Coordinates ParkingPos { get; set; }
        public Coordinates WorkingPos { get; set; }
        public bool IsWorking { get; set; }

        public WorkingUnit(double buildTime, string name, double vitesse) 
            : base(buildTime, name, 1)
        {
            
        }
        public WorkingUnit(double buildTime, double vitesse)
           : base(buildTime, 1)
        {

        }

        public WorkingUnit(Coordinates parkingPos, Coordinates workingPos, bool isWorking) : base()
        {
            this.ParkingPos = parkingPos;
            this.WorkingPos = workingPos;
            this.IsWorking = isWorking;

        }

        public virtual async Task<bool> WorkBegins()
        {   
            //await Task.Delay(1);
            return true;
        }
        public virtual async Task<bool> WorkEnds()
        {
            //await Task.Delay(1);
            return true;
        }

    }
}
