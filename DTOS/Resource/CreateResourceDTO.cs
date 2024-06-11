using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JBT_Server.DTOS.Resource
{
    public class CreateResourceDTO
    {
        public string Name { get; set; } = string.Empty;
        public int Amount { get; set; }
        public int Total { get; set; }
        public string Link { get; set; } = string.Empty;
        public int Price { get; set; }
    }
}