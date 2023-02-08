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
    public class PayTypesController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;

        public PayTypesController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        // GET: api/PayTypes
        [HttpGet]
        public async Task<IActionResult> GetPayTypes()
        {
            var paytypes = await _unitOfWork.PayTypes.GetAll();
            return Ok(paytypes);
        }

        // GET: api/PayTypes/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetPayTypes(int id)
        {
            var paytypes = await _unitOfWork.PayTypes.Get(q => q.Id == id);

            if (paytypes == null)
            {
                return NotFound();
            }

            return Ok(paytypes);
        }

        // PUT: api/PayTypes/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPayTypes(int id, PayType paytype)
        {
            if (id != paytype.Id)
            {
                return BadRequest();
            }

            _unitOfWork.PayTypes.Update(paytype);

            try
            {
                await _unitOfWork.Save(HttpContext);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!await PayTypeExistsAsync(id))
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

        // POST: api/Customers
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<PayType>> PostPayType(PayType paytype)
        {
            await _unitOfWork.PayTypes.Insert(paytype);
            await _unitOfWork.Save(HttpContext);

            return CreatedAtAction("GetPayType", new { id = paytype.Id }, paytype);
        }

        // DELETE: api/Customers/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePayType(int id)
        {
            var paytype = _unitOfWork.Customers.Get(p => p.Id == id);
            if (paytype == null)
            {
                return NotFound();
            }

            await _unitOfWork.Customers.Delete(id);
            await _unitOfWork.Save(HttpContext);

            return NoContent();
        }

        private async Task<bool> PayTypeExistsAsync(int id)
        {
            var paytype = await _unitOfWork.PayTypes.Get(p => p.Id == id);
            return paytype != null;
        }
    }
}
