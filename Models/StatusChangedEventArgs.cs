using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BotFactory.Common.Interface;

namespace BotFactory.Models
{
    public class StatusChangedEventArgs : EventArgs, IStatusChangedEventArgs
    {
        public string NewStatus { get; set; }
       
        public StatusChangedEventArgs(string newStatus)
        {
            this.NewStatus = newStatus;
        }
    }
}
