using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ServicioRestCore.Dtos;
using ServicioRestCore.Models;

namespace ServicioRestCore.Controllers
{
    //dinciamos que es un controlador
    [ApiController]
    //es definir la ruta de acceso al controlador
    [Route("api-tienditarest/categoria")]
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
        public async Task<ActionResult<List<CategoriaDTO>>> findAll()
        {
            return await context.categoria.Select(c => new CategoriaDTO
            {
                codcat = c.codcat,
                nomcat = c.nomcat,
                estcat = c.escat
            }
                ).ToListAsync();
        }

        //cuando queremos obtener solo los habilitados
        [HttpGet("custom")]
        public async Task<ActionResult<List<CategoriaDTO>>> findAllCustom()
        {
            return await context.categoria.Select(c => new CategoriaDTO
            {
                codcat = c.codcat,
                nomcat = c.nomcat,
                estcat = c.escat
            }
                ).Where(x => x.estcat == true).ToListAsync();
        }

        //cuando queremos guardar informacion
        [HttpPost("")]
        public async Task<ActionResult> add(CategoriaDTO categoriaDTO)
        {
            Categoria categoria = new Categoria
            {
                nomcat = categoriaDTO.nomcat,
                escat = categoriaDTO.estcat
            };
            context.Add(categoria);
            await context.SaveChangesAsync();
            return Ok();
        }

        //cuando queremos buscar informacion
        [HttpGet("{id:int}")]
        public async Task<ActionResult<CategoriaDTO>> findById(int id)
        {
            var categoria = await context.categoria.Select(c => new CategoriaDTO
            {
                codcat = c.codcat,
                nomcat = c.nomcat,
                estcat = c.escat
            }
                )
                .FirstOrDefaultAsync(x => x.codcat == id);
            if (categoria == null)
            {
                return NotFound();
            }
            else
            {
                return categoria;
            }


        }

        //cuando queremos actualizar informacion
        [HttpPut("{id:int}")]
        public async Task<ActionResult> update(CategoriaDTO categoriaDTO, int id)
        {
            if (categoriaDTO.codcat != id)
            {
                return BadRequest("No se encuentro el codigo correspondiente");
            }
            Categoria categoria = new Categoria
            {
                codcat = categoriaDTO.codcat,
                nomcat = categoriaDTO.nomcat,
                escat = categoriaDTO.estcat
            };
            context.Update(categoria);
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

            var existe = await context.categoria.AnyAsync(x => x.codcat == id);
            if (!existe)
            {
                return NotFound();
            }
            var categoria = await context.categoria.FirstOrDefaultAsync(x => x.codcat == id);
            categoria.escat = false;
            context.Update(categoria);
            await context.SaveChangesAsync();
            return Ok();
        }
    }
}