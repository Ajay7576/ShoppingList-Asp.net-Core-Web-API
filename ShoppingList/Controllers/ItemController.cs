using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ShoppingList.Data;
using ShoppingList.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShoppingList.Controllers
{
    [Route("api/items")]
    [ApiController]
    public class ItemController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ItemController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        [Route("categories")]
        public IActionResult GetAllCategories()
        {
            return Ok(_context.Categories.ToList());

        }
        [HttpGet]
        public IActionResult GetAllitems()
        {
            return Ok(_context.Items.Include(r => r.Categories).ToList());
            //return Ok(_context.Items.ToList());

        }
        [HttpGet]
        [Route("getcategorybyitem")]
        public async Task<IActionResult> Getcategoryitemby()
        {
            return Ok(await _context.Categories.Include(c => c.Items).ToListAsync());
            //return Ok(_context.Items.Include(r => r.Categories).Where(x => x.CategoryId == categoryId).ToList());

        }
        [HttpGet("api/items/{id}")]
        public IActionResult Getitems(int id)
        {
            var itemindb = _context.Items.Find(id);
            if (itemindb == null) return NotFound();
            return Ok(itemindb);
        }
        [HttpPost]
        [Route("saveitems")]
        public IActionResult Saveitems([FromBody] Item items)
        {
            if (items != null && ModelState.IsValid)
            {
                _context.Items.Add(items);
                _context.SaveChanges();
                return Ok();
            }
            return BadRequest();
        }
        [HttpPut]
        [Route("update")]

        public IActionResult Updateitems([FromBody] Item items)
        {
            if (items != null && ModelState.IsValid)
            {
                _context.Items.Update(items);
                _context.SaveChanges();
                return Ok();

            }
            return BadRequest();
        }
        [HttpDelete("{id:int}")]
        public IActionResult Deleteitems(int id)
        {
            var itemindb = _context.Items.Find(id);
            if (itemindb == null) return NotFound();
            _context.Items.Remove(itemindb);
            _context.SaveChanges();
            return Ok();
        }
    }
}
