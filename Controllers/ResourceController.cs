using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using JBT_Server.Data;
using JBT_Server.DTOS.Resource;
using JBT_Server.DTOS;
using JBT_Server.Mappers;
using JBT_Server.Interfaces;
using JBT_Server.Repo;

namespace JBT_Server.Controllers
{
    [Route("api/resource")]
    [ApiController]
    public class ResourceController : ControllerBase

    {
        private readonly ApplicationDBContext _context;
        private readonly IResourceRepo _resourceRepo;
        public ResourceController(ApplicationDBContext context, IResourceRepo resourceRepo)
        {
            _resourceRepo = resourceRepo;
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var resource = await _resourceRepo.GetAllAsync();
            return Ok(resource);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetByID([FromRoute] int id)
        {
            var resource = await _resourceRepo.GetByIDAsync(id);

            if (resource == null)
            {
                return NotFound();
            }
            else
            {
                return Ok(resource);
            }
        }

        [HttpGet("DTO")]
        public async Task<IActionResult> GetAllDTO()
        {
            var resource = await _resourceRepo.GetAllAsync();
            var resourceDTO = resource.Select(s => s.ToResourceDTO());
            return Ok(resource);
        }

        [HttpGet("DTO/{id}")]
        public async Task<IActionResult> GetDTOByID([FromRoute] int id)
        {
            var resource = await _resourceRepo.GetByIDAsync(id);

            if (resource == null)
            {
                return NotFound();
            }
            else
            {
                return Ok(resource.ToResourceDTO());
            }
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateResourceDTO createDTO)
        {
            var resourceModel = createDTO.ToResourceFromCreateDTO();
            await _resourceRepo.CreateAsync(resourceModel);
            return CreatedAtAction(nameof(GetByID), new { id = resourceModel.ID }, createDTO.ToResourceFromCreateDTO());
        }

        [HttpPut]
        [Route("{id}")]
        public async Task<IActionResult> Update([FromRoute] int id, [FromBody] UpdateResourceDTO updateDTO)
        {
            var resourceModel = await _resourceRepo.UpdateAsync(id, updateDTO);

            if (resourceModel == null)
            {
                return NotFound();
            }
            else
            {
                return Ok(resourceModel.ToResourceDTO());
            }
        }

        [HttpDelete]
        [Route("{id}")]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            var resourceModel = await _resourceRepo.DeleteAsync(id);

            if (resourceModel == null)
            {
                return NotFound();
            }
            else
            {
                return NoContent();
            }
        }
    }
}