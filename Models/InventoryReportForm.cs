using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JBT_Server.Models
{
    public class InventoryReportForm
    {
        public int ID { get; set; }
        public int UUID { get; set; }
        public int Amount { get; set; }
        public DateTime CreatedOn { get; set; } = DateTime.Now;
        public int? IRFID { get; set; }
        public Resource? Resource { get; set; }
    }
}