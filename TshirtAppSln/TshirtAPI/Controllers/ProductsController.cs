using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TshirtAPI.Data;
using TshirtAPI.Models;

namespace TshirtAPI.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly ProductsContext _context;

        public ProductsController(ProductsContext context)
        {
            _context = context;

            SeedData.Initialize(context);
        }

        // GET: api/Products
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Products>>> GetProductss()
        {
            return await _context.Productss.ToListAsync();
        }

        // GET: api/Products/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Products>> GetProducts(long id)
        {
            var products = await _context.Productss.FindAsync(id);

            if (products == null)
            {
                return NotFound();
            }

            return products;
        }

        // PUT: api/Products/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutProducts(long id, Products products)
        {
            if (id != products.ID)
            {
                return BadRequest();
            }

            _context.Entry(products).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ProductsExists(id))
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

        // POST: api/Products
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPost]
        public async Task<ActionResult<Products>> PostProducts(Products products)
        {
            _context.Productss.Add(products);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetProducts), new { id = products.ID }, products);
        }

        // DELETE: api/Products/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Products>> DeleteProducts(long id)
        {
            var products = await _context.Productss.FindAsync(id);
            if (products == null)
            {
                return NotFound();
            }

            _context.Productss.Remove(products);
            await _context.SaveChangesAsync();

            return products;
        }

        private bool ProductsExists(long id)
        {
            return _context.Productss.Any(e => e.ID == id);
        }
    }
}
