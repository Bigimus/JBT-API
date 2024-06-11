using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JBT_Server.Models
{
    public class Resource
    {
        public int ID { get; set; }
        public string Name { get; set; } = string.Empty;
        public int Amount { get; set; }
        public int Total { get; set; }
        public string Link { get; set; } = string.Empty;
        public int Price { get; set; }
        public List<InventoryReportForm> IRF { get; set; } = new List<InventoryReportForm>();

    }
}