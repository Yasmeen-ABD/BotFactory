using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BotFactory.Common.Interface;


namespace BotFactory.Models
{
    public class R2D2 : WorkingUnit, IR2D2,ITestingUnit
    {
        

        public R2D2() : base(5.5, "R2D2", 1.5)
        {
        }

        public override async Task<bool> WorkBegins()
        {
            //Position actuelle --> WorkingPos
            OnStatusChanged(new StatusChangedEventArgs("le Robot " + this.Name + " se deplace vers son lieu de travail..."));
            bool res = await Move(this.CurrentPos, this.WorkingPos);
            this.IsWorking = true;
            this.CurrentPos.X = WorkingPos.X;
            this.CurrentPos.Y = WorkingPos.Y;
            return  res;
        }



        public override async Task<bool> WorkEnds()
        {
            //Position actuelle --> ParkingPos
            OnStatusChanged(new StatusChangedEventArgs("le Robot " + this.Name + " se deplace vers sa position de stationnement..."));
            bool res = await Move(this.CurrentPos, this.ParkingPos);
            this.IsWorking = false;
            this.CurrentPos.X = ParkingPos.X;
            this.CurrentPos.Y = ParkingPos.Y;
            return res;
        }


    }
}
