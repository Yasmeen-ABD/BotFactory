using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BotFactory.Common.Tools;

namespace BotFactory.Common.Interface
{
   public interface IReportingFactory
    {

        event EventHandler FactoryProgress;
        int QueueCapacity { get; }
        int StorageCapacity { get; }
        List<IFactoryQueueElement> Queue { get; set; }
        List<ITestingUnit> Storage { get; set; }

        int QueueFreeSlots { get; }
        int StorageFreeSlots { get; }
        TimeSpan QueueTime { get; set; }

        bool AddWorkableUnitToQueue(Type model, string name, Coordinates parkingPos, Coordinates workingPos);
    }
}
