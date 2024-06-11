using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using JBT_Server.Models;
using JBT_Server.DTOS.Resource;

namespace JBT_Server.Interfaces
{
    public interface IResourceRepo
    {
        Task<List<Resource>> GetAllAsync();
        Task<Resource?> GetByIDAsync(int id);
        Task<Resource> CreateAsync(Resource resourceModel);
        Task<Resource?> UpdateAsync(int id, UpdateResourceDTO resourceDTO);
        Task<Resource?> DeleteAsync(int id);
    }
}