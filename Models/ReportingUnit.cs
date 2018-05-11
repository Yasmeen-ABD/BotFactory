using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BotFactory.Common.Interface;


namespace BotFactory.Models
{
    public abstract class ReportingUnit: BuildableUnit, IReportingUnit
    {
        public event EventHandler<IStatusChangedEventArgs> UnitStatusChanged;

        public ReportingUnit()
        {

        }
        public ReportingUnit(double buildTime) 
            : base(buildTime)
        {

        }
        public virtual void OnStatusChanged(StatusChangedEventArgs e) {
            if (UnitStatusChanged != null)
                UnitStatusChanged(this, e);
        }
    }
}
