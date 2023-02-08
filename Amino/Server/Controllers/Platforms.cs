using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Amino.Server.Data;
using Amino.Shared.Domain;
using Amino.Server.IRepository;

namespace Amino.Server.Controllers
{
    //[Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class PlatformsController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;

        public PlatformsController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        // GET: api/Platforms
        [HttpGet]
        public async Task<IActionResult> GetPlatforms()
        {
            var platforms = await _unitOfWork.Platforms.GetAll();
            return Ok(platforms);
        }

        // GET: api/Makes/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetPlatform(int id)
        {
            var platform = await _unitOfWork.Platforms.Get(q => q.Id == id);

            if (platform == null)
            {
                return NotFound();
            }

            return Ok(platform);
        }

        // PUT: api/Makes/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPlatform(int id, Platform platform)
        {
            if (id != platform.Id)
            {
                return BadRequest();
            }

            _unitOfWork.Platforms.Update(platform);

            try
            {
                await _unitOfWork.Save(HttpContext);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!await PlatformExistsAsync(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Makes
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Platform>> PostPlatform(Platform platform)
        {
            await _unitOfWork.Platforms.Insert(platform);
            await _unitOfWork.Save(HttpContext);

            return CreatedAtAction("GetPlatform", new { id = platform.Id }, platform);
        }

        // DELETE: api/Makes/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePlatform(int id)
        {
            var platform = _unitOfWork.Platforms.Get(p => p.Id == id);
            if (platform == null)
            {
                return NotFound();
            }

            await _unitOfWork.Platforms.Delete(id);
            await _unitOfWork.Save(HttpContext);

            return NoContent();
        }

        private async Task<bool> PlatformExistsAsync(int id)
        {
            var platform = await _unitOfWork.Platforms.Get(p => p.Id == id);
            return platform != null;
        }
    }
}
