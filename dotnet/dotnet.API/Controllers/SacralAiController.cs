
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using dotnet.DataAccess;
using dotnet.DTO;
using dotnet.Service;
using Microsoft.AspNetCore.Mvc;

namespace dotnet.API
{
    [ApiController]
    [Route("api/[controller]")]
    public class SacralAiController : ControllerBase
    {
        private readonly ISacralAiService _service;

        public SacralAiController(ISacralAiService service)
        {
            _service = service;
        }

        [HttpPost]
        public async Task<IActionResult> AddAsync(SacralAiModel model)
        {
            try
            {
                int id = await _service.AddAsync(model);
                return Ok(id);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetByIdAsync(int id)
        {
            try
            {
                SacralAiModel model = await _service.GetByIdAsync(id);
                if (model == null)
                {
                    return NotFound();
                }
                return Ok(model);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        public async Task<IActionResult> GetAllAsync()
        {
            try
            {
                List<SacralAiModel> models = await _service.GetAllAsync();
                return Ok(models);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateAsync(int id, SacralAiModel model)
        {
            try
            {
                if (id != model.Id)
                {
                    return BadRequest("Invalid Id");
                }
                await _service.UpdateAsync(model);
                return NoContent();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            try
            {
                await _service.DeleteAsync(id);
                return NoContent();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
