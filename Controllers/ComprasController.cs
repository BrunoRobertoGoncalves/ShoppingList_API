using Microsoft.EntityFrameworkCore;
using ListaDeCompras.Models;
using ListaDeCompras.Data;
using Microsoft.AspNetCore.Mvc;


namespace ListaDeCompras.Controllers
{
    [ApiController]
    [Route("api/[controller]")]

    public class ComprasController : ControllerBase
    {
        private readonly AppDbContext _context;
        public ComprasController(AppDbContext context)
        {
            _context = context;
        }

        [HttpPost]
        public IActionResult AdicionarCompra(Compra NovaCompra)
        {
            _context.Compras.Add(NovaCompra);
            _context.SaveChanges();

            return CreatedAtAction(nameof(RecuperaCompraPorID), new { id = NovaCompra.Id }, NovaCompra);
        }

        [HttpGet]
        public IActionResult ListarCompras()
        {
            var compras = _context.Compras.ToList();
            return Ok(compras);
        }

        [HttpGet("pendentes")]
        public IActionResult ListaComprasPendentes()
        {
            var ComprasPendentes = _context.Compras
                .Where(c => !c.Comprado)
                .ToList();

            return Ok(ComprasPendentes);
        }

        [HttpGet("{Id}")]
        public IActionResult RecuperaCompraPorID(int Id)
        {
            var compra = _context.Compras.FirstOrDefault(c => c.Id == Id);
            if(compra == null) return NotFound();

            return Ok(compra);
        }

        [HttpPatch("{Id}")]
        public IActionResult AtualizarStatusCompra(int Id)
        {
            var compra = _context.Compras.FirstOrDefault(c => c.Id == Id);
            if(compra == null) return NotFound();

            compra.Comprado = true;

            _context.SaveChanges();

            return Ok(compra);
        }

        [HttpPut("{Id}")]
        public IActionResult AtualizarCompra (int Id, Compra CompraAtualizada)
        {
            var compra = _context.Compras.FirstOrDefault(c => c.Id == Id);
            if (compra == null) return NotFound();

            compra.Nome = CompraAtualizada.Nome;
            compra.Quantidade = CompraAtualizada.Quantidade;

            return Ok(compra);

        }

        [HttpDelete("{Id}")]
        public IActionResult DeletarCompra (int Id)
        {
            var compra = _context.Compras.FirstOrDefault(c => c.Id == Id);
            if (compra == null) return NotFound();

            _context.Compras.Remove(compra);
            _context.SaveChanges();

            return NoContent();
        }
    }
}