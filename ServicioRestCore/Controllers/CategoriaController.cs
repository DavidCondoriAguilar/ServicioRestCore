using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ServicioRestCore.Models;

namespace ServicioRestCore.Controllers
{
    public class CategoriaController : ControllerBase
    {
        private readonly ApplicationDBContext context;


        //creamos el metodo constructor
        public CategoriaController(ApplicationDBContext context)
        {
            this.context = context;
        }

        //cuando queremos obtener informacion
        [HttpGet("")]
        public async Task<ActionResult<List<Categoria>>> findAll()
        {
            return await context.Categorias.ToListAsync();
        }

        //cuando queremos obtener solo los habilitados
        [HttpGet("custom")]
        public async Task<ActionResult<List<Categoria>>> findAllCustom()
        {
            return await context.Categorias.Where(x => x.escat == true).ToListAsync();
        }

        //cuando queremos guardar informacion
        [HttpPost("")]
        public async Task<ActionResult> add(Categoria a)
        {
            context.Add(a);
            await context.SaveChangesAsync();
            return Ok();
        }

        //cuando queremos buscar informacion
        [HttpGet("{id:int}")]
        public async Task<ActionResult<Categoria>> findById(int id)
        {
            var autor = await context.Categorias
                .FirstOrDefaultAsync(x => x.codcat == id);
            if (autor == null)
            {
                return NotFound();
            }
            else
            {
                return autor;
            }


        }

        //cuando queremos actualizar informacion
        [HttpPut("{id:int}")]
        public async Task<ActionResult> update(Categoria a, int id)
        {
            if (a.codcat != id)
            {
                return BadRequest("No se encuentro el codigo correspondiente");
            }

            context.Update(a);
            await context.SaveChangesAsync();
            return Ok();
        }


        //cuando queremos eliminar informacion
        /*[HttpDelete("{id:int}")]
        public async Task<ActionResult> delete(int id)
        {
            var existe = await context.Autor.AnyAsync(x => x.codigo == id);
            if (!existe)
            {
                return NotFound();
            }
            context.Remove(new Autor() { codigo = id });
            await context.SaveChangesAsync();
            return Ok();
        }*/
        [HttpDelete("{id:int}")]
        public async Task<ActionResult> delete(int id)
        {

            var existe = await context.Categorias.AnyAsync(x => x.codcat == id);
            if (!existe)
            {
                return NotFound();
            }
            var autor = await context.Categorias.FirstOrDefaultAsync(x => x.codcat == id);
            autor.escat = false;
            context.Update(autor);
            await context.SaveChangesAsync();
            return Ok();
        }
    }
}
