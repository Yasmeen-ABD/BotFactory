using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BotFactory.Common.Tools;


namespace BotFactory.Common.Interface
{
    public interface IBaseUnit
    {
        string Name { get; set; }
        double Vitesse { get; set; }
        Coordinates CurrentPos { get; set; }
        Task<bool> Move(Coordinates departPos, Coordinates destinationPos);

    }
}
