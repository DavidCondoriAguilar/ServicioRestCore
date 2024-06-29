using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ServicioRestCore.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ServicioRestCore.Controllers
{
    [ApiController]
    [Route("api-tienditarest/producto")]
    public class ProductoController : ControllerBase
    {
        private readonly ApplicationDBContext _context;

        public ProductoController(ApplicationDBContext context)
        {
            _context = context;
        }

        [HttpGet("")]
        public async Task<IActionResult> GetAll()
        {
            var productos = await _context.Productos.ToListAsync();
            return Ok(productos);
        }

        [HttpGet("custom")]
        public async Task<IActionResult> GetEnabled()
        {
            var productos = await _context.Productos.Where(x => x.estpro).ToListAsync();
            return Ok(productos);
        }

        [HttpPost("")]
        public async Task<IActionResult> Add([FromBody] Producto producto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.Add(producto);
            await _context.SaveChangesAsync();
            return Ok();
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetById(int id)
        {
            var producto = await _context.Productos.FindAsync(id);
            if (producto == null)
            {
                return NotFound();
            }
            return Ok(producto);
        }

        [HttpPut("{id:int}")]
        public async Task<IActionResult> Update(int id, [FromBody] Producto producto)
        {
            if (id != producto.codpro)
            {
                return BadRequest("El ID proporcionado no coincide con el ID del producto");
            }

            _context.Entry(producto).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return Ok();
        }

        [HttpDelete("{id:int}")]
        public async Task<IActionResult> Delete(int id)
        {
            var producto = await _context.Productos.FindAsync(id);
            if (producto == null)
            {
                return NotFound();
            }

            producto.estpro = false; // Cambio de estado en lugar de eliminación física
            await _context.SaveChangesAsync();
            return Ok();
        }
    }
}
