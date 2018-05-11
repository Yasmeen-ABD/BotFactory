using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BotFactory.Common.Tools;
using BotFactory.Common.Interface;

namespace BotFactory.Models
{
    public abstract class BuildableUnit : IBuildableUnit
    {
        public double BuildTime { get; set; }
        public string Model { get; set; }
        public BuildableUnit()
        {
            this.BuildTime = 5;
        }

        public BuildableUnit(double buildTime = 5)
        {
            this.BuildTime = buildTime;
        }
    }
}
