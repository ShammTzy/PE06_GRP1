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
    public class GamesController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;

        public GamesController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        // GET: api/Games
        [HttpGet]
        public async Task<IActionResult> GetGames()
        {
            var makes = await _unitOfWork.Games.GetAll();
            return Ok(makes);
        }

        // GET: api/Makes/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetGame(int id)
        {
            var make = await _unitOfWork.Games.Get(q => q.Id == id);

            if (make == null)
            {
                return NotFound();
            }

            return Ok(make);
        }

        // PUT: api/Makes/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutGame(int id, Game make)
        {
            if (id != make.Id)
            {
                return BadRequest();
            }

            _unitOfWork.Games.Update(make);

            try
            {
                await _unitOfWork.Save(HttpContext);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!await GameExistsAsync(id))
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
        public async Task<ActionResult<Game>> PostGame(Game game)
        {
            await _unitOfWork.Games.Insert(game);
            await _unitOfWork.Save(HttpContext);

            return CreatedAtAction("GetGame", new { id = game.Id }, game);
        }

        // DELETE: api/Makes/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteGame(int id)
        {
            var game = _unitOfWork.Games.Get(p => p.Id == id);
            if (game == null)
            {
                return NotFound();
            }

            await _unitOfWork.Games.Delete(id);
            await _unitOfWork.Save(HttpContext);

            return NoContent();
        }

        private async Task<bool> GameExistsAsync(int id)
        {
            var make = await _unitOfWork.Games.Get(p => p.Id == id);
            return make != null;
        }
    }
}
