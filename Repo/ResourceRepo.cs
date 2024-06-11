using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using JBT_Server.Data;
using JBT_Server.Interfaces;
using JBT_Server.Models;
using JBT_Server.DTOS.Resource;

namespace JBT_Server.Repo
{
    public class ResourceRepo : IResourceRepo
    {
        private readonly ApplicationDBContext _context;
        public ResourceRepo(ApplicationDBContext context)
        {
            _context = context;
        }
        public Task<List<Resource>> GetAllAsync()
        {
            return _context.Resource.ToListAsync();
        }

        public async Task<Resource> GetByIDAsync(int id)
        {
            return await _context.Resource.FirstOrDefaultAsync(r => r.ID == id);
        }

        public async Task<Resource> CreateAsync(Resource resourceModel)
        {
            await _context.Resource.AddAsync(resourceModel);
            await _context.SaveChangesAsync();
            return resourceModel;
        }

        public async Task<Resource> UpdateAsync(int id, UpdateResourceDTO updateDTO)
        {
            var resourceModel = await _context.Resource.FirstOrDefaultAsync(x => x.ID == id);

            if (resourceModel == null)
            {
                return null;
            }
            else
            {
                resourceModel.Name = updateDTO.Name;
                resourceModel.Amount = updateDTO.Amount;
                resourceModel.Total = updateDTO.Total; // TODO: REMOVE FROM DTO'S, CAN BE CALCULATED FROM IRF
                resourceModel.Link = updateDTO.Link;
                resourceModel.Price = updateDTO.Price;
                await _context.SaveChangesAsync();
                return resourceModel;
            }
        }

        public async Task<Resource> DeleteAsync(int id)
        {
            var resourceModel = await _context.Resource.FirstOrDefaultAsync(x => x.ID == id);

            if (resourceModel == null)
            {
                return null;
            }
            else
            {
                _context.Resource.Remove(resourceModel);
                await _context.SaveChangesAsync();
                return resourceModel;
            }
        }

    }
}