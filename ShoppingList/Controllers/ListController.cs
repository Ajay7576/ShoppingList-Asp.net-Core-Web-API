using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ShoppingList.Data;
using ShoppingList.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShoppingList.Controllers
{
    [Route("api/list")]
    [ApiController]
    public class ListController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ListController(ApplicationDbContext context)
        {
            _context = context;
        }
        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok(_context.Lists.ToList());

        }
        [HttpPost]
        public IActionResult Saveitems([FromBody] List lists)
        {
            if (lists != null && ModelState.IsValid)
            {
                _context.Lists.Add(lists);
                _context.SaveChanges();
                return Ok();
            }
            return BadRequest();
        }


    }
}
