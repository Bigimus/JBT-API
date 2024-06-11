using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using JBT_Server.Data;
using JBT_Server.Controllers;
using JBT_Server.DTOS.Resource;
using JBT_Server.DTOS.InventoryReportForm;
using JBT_Server.Models;


namespace JBT_Server.Mappers
{
    public static class ResourceMapper
    {
        public static ResourceDTO ToResourceDTO(this Resource resourceModel){
            return new ResourceDTO {
                ID = resourceModel.ID,
                Name = resourceModel.Name
            };
        }

        public static Resource ToResourceFromCreateDTO(this CreateResourceDTO resourceDTO) {
            return new Resource {
                Name = resourceDTO.Name,
                Amount = resourceDTO.Amount,
                Total = resourceDTO.Total,
                Link = resourceDTO.Link,
                Price = resourceDTO.Price
            };
        }
    }
}