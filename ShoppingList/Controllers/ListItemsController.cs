using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ShoppingList.Data;
using ShoppingList.Models;

namespace ShoppingList.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ListItemsController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public ListItemsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/ListItems
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Listitem>>> GetListitems()
        {
            return await _context.Listitems.ToListAsync();
        }



        [HttpGet]
        [Route("listbyitem")]

        public IActionResult Getitems(int listId)
        {
            return Ok( _context.Listitems.Where(c => c.ListId == listId).Select(i =>i.ItemId).ToList());
            
        }

        // GET: api/ListItems/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Listitem>> GetListitem(int id)
        {
            var listitem = await _context.Listitems.FindAsync(id);

            if (listitem == null)
            {
                return NotFound();
            }

            return listitem;
        }

        // PUT: api/ListItems/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutListitem(int id, Listitem listitem)
        {
            if (id != listitem.ItemId)
            {
                return BadRequest();
            }

            _context.Entry(listitem).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ListitemExists(id))
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

        // POST: api/ListItems
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Listitem>> PostListitem(Listitem listitem)
       {
            _context.Listitems.Add(listitem);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (ListitemExists(listitem.ItemId))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetListitem", new { id = listitem.ItemId }, listitem);
        }

        // DELETE: api/ListItems/
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteListitem(int id)
        {
            var listitem = await _context.Listitems.FindAsync(id);
            if (listitem == null)
            {
                return NotFound();
            }

            _context.Listitems.Remove(listitem);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ListitemExists(int id)
        {
            return _context.Listitems.Any(e => e.ItemId == id);
        }
        
    }
}
