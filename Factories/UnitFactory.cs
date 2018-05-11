using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BotFactory.Common.Interface;
using BotFactory.Common.Tools;
using System.Threading;
using BotFactory.Models;

namespace BotFactory.Factories
{
    public  class UnitFactory : IUnitFactory
    {
        
        public event EventHandler FactoryProgress;

        private static Object thisLock = new Object();

        public int QueueCapacity { get; }
        public int StorageCapacity { get; }
        public TimeSpan QueueTime { get; set; }
        public List<IFactoryQueueElement> Queue { get; set; }
        public int QueueFreeSlots {
            get {
                return QueueCapacity - Queue.Count;
            }
        }

        private List<ITestingUnit> storage {get; set;}
        public List<ITestingUnit> Storage { get; set; }
        public int StorageFreeSlots {
            get {
                return StorageCapacity - Storage.Count;
            }
        }

        public void OnStatusChangedFactory(StatusChangedEventArgs e)
        {
            if (FactoryProgress != null)
                FactoryProgress(this, e);
        }

        public UnitFactory(int queueCapacity, int storageCapacity)
        {
            this.QueueCapacity = queueCapacity;
            this.StorageCapacity = storageCapacity;
            Queue = new List<IFactoryQueueElement>();
            Storage = new List<ITestingUnit>();
        }

        public bool AddWorkableUnitToQueue(Type model, string name, Coordinates parkingPos, Coordinates workingPos)
        {
            OnStatusChangedFactory(new StatusChangedEventArgs("Adding " + name + " to Queue ..."));
            if (this.Queue.Count < this.QueueCapacity && this.Storage.Count < this.StorageCapacity)
            {
                FactoryQueueElement commande = new FactoryQueueElement(name, model, parkingPos, workingPos);
                Queue.Add(commande);
                OnStatusChangedFactory(new StatusChangedEventArgs("test"));

                object robot = Activator.CreateInstance(model);
                ITestingUnit robotToTest = Activator.CreateInstance(commande.Model, new object[] { }) as ITestingUnit;

                robotToTest.Model = name;
                robotToTest.ParkingPos = parkingPos;
                robotToTest.WorkingPos = workingPos;
                Thread th = new Thread(() =>
                {
                    OnStatusChangedFactory(new StatusChangedEventArgs ("test"));
                    lock (thisLock)
                    {

                        Thread.Sleep(Convert.ToInt32(robotToTest.BuildTime) * 1000);
                        Storage.Add(robotToTest);
                        Queue.RemoveAt(Queue.Count - 1);
                        QueueTime += DateTime.Now.AddSeconds(Convert.ToInt32(robotToTest.BuildTime)) - DateTime.Now;
                        OnStatusChangedFactory(new StatusChangedEventArgs("test"));
                    }
                    OnStatusChangedFactory(new StatusChangedEventArgs("test 2"));
                });

                th.Start();
                return true;
            }
            return false;
        }

        

        
    }
}
