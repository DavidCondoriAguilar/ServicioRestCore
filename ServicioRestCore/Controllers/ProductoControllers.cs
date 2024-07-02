using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ServicioRestCore.Dtos;
using ServicioRestCore.Models;

namespace ServicioRestCore.Controllers
{
    //dinciamos que es un controlador
    [ApiController]
    //es definir la ruta de acceso al controlador
    [Route("api-tienditarest/producto")]
    public class ProductoController : ControllerBase
    {
        private readonly ApplicationDBContext context;


        //creamos el metodo constructor
        public ProductoController(ApplicationDBContext context)
        {
            this.context = context;
        }

        //cuando queremos obtener informacion
        [HttpGet("")]
        public async Task<ActionResult<List<ProductoDTO>>> findAll()
        {
            return await context.producto.Select(
                p => new ProductoDTO
                {
                    codpro = p.codpro,
                    nompro = p.nompro,
                    despro = p.despro,
                    prepro = p.prepro,
                    canpro = p.canpro,
                    estpro = p.estpro,
                    codcat = p.codcat
                }).ToListAsync();
        }

        //cuando queremos obtener solo los habilitados
        [HttpGet("custom")]
        public async Task<ActionResult<List<ProductoDTO>>> findAllCustom()
        {
            return await context.producto.Select(
                p => new ProductoDTO
                {
                    codpro = p.codpro,
                    nompro = p.nompro,
                    despro = p.despro,
                    prepro = p.prepro,
                    canpro = p.canpro,
                    estpro = p.estpro,
                    codcat = p.codcat
                }).Where(x => x.estpro == true).ToListAsync();
        }

        //cuando queremos guardar informacion
        [HttpPost("")]
        public async Task<ActionResult> add(ProductoDTO productoDTO)
        {
            Producto producto = new Producto
            {
                nompro = productoDTO.nompro,
                despro = productoDTO.despro,
                prepro = productoDTO.prepro,
                canpro = productoDTO.canpro,
                estpro = productoDTO.estpro,
                codcat = productoDTO.codcat
            };
            context.Add(producto);
            await context.SaveChangesAsync();
            return Ok();
        }

        //cuando queremos buscar informacion
        [HttpGet("{id:int}")]
        public async Task<ActionResult<ProductoDTO>> findById(int id)
        {
            var producto = await context.producto.Select(
                p => new ProductoDTO
                {
                    codpro = p.codpro,
                    nompro = p.nompro,
                    despro = p.despro,
                    prepro = p.prepro,
                    canpro = p.canpro,
                    estpro = p.estpro,
                    codcat = p.codcat
                })
                .FirstOrDefaultAsync(x => x.codpro == id);
            if (producto == null)
            {
                return NotFound();
            }
            else
            {
                return producto;
            }


        }

        //cuando queremos actualizar informacion
        [HttpPut("{id:int}")]
        public async Task<ActionResult> update(ProductoDTO productoDTO, int id)
        {
            if (productoDTO.codpro != id)
            {
                return BadRequest("No se encuentro el codigo correspondiente");
            }

            Producto producto = new Producto
            {
                codpro = productoDTO.codpro,
                nompro = productoDTO.nompro,
                despro = productoDTO.despro,
                prepro = productoDTO.prepro,
                canpro = productoDTO.canpro,
                estpro = productoDTO.estpro,
                codcat = productoDTO.codcat
            };

            context.Update(producto);
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

            var existe = await context.producto.AnyAsync(x => x.codpro == id);
            if (!existe)
            {
                return NotFound();
            }
            var producto = await context.producto.FirstOrDefaultAsync(x => x.codpro == id);
            producto.estpro = false;
            context.Update(producto);
            await context.SaveChangesAsync();
            return Ok();
        }
    }
}