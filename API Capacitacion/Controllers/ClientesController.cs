using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using API_Capacitacion;

namespace API_Capacitacion.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClientesController : ControllerBase
    {
        private readonly MiContexto _context;

        public ClientesController(MiContexto context)
        {
            _context = context;
        }

        // GET: api/Clientes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Cliente>>> GetClientes()
        {
            return await _context.Clientes.ToListAsync();
        }

        // GET: api/Clientes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Cliente>> GetCliente(int id)
        {
            var cliente = await _context.Clientes.FindAsync(id);

            if (cliente == null)
            {
                return NotFound();
            }

            return cliente;
        }
        // GET: api/Clientes/NIT/{nit}
        [HttpGet("NIT/{nit}")]
        public async Task<ActionResult<Cliente>> GetClientePorNIT(string nit)
        {
            var cliente = await _context.Clientes.FirstOrDefaultAsync(c => c.NIT == nit);

            if (cliente == null)
            {
                return NotFound();
            }

            return cliente;
        }
        // PUT: api/Clientes/ActualizarPorNIT/nit
        [HttpPut("ActualizarPorNIT/{nit}")]
        public async Task<IActionResult> ActualizarClientePorNIT(string nit, [FromBody] ClienteActualizarDto clienteActualizarDto)
        {
            try
            {
                var cliente = await _context.Clientes.FirstOrDefaultAsync(c => c.NIT == nit);
                if (cliente == null)
                {
                    return NotFound($"Cliente con NIT {nit} no encontrado.");
                }

                // Verificar si el banco existe
                var bancoExiste = await _context.Bancos.AnyAsync(b => b.Nombre == clienteActualizarDto.Banco);
                if (!bancoExiste)
                {
                    return BadRequest($"El banco '{clienteActualizarDto.Banco}' no existe.");
                }

                cliente.Banco = clienteActualizarDto.Banco;
                cliente.Contrato = clienteActualizarDto.Contrato;

                _context.Clientes.Update(cliente);
                await _context.SaveChangesAsync();

                return Ok($"Cliente con NIT {nit} actualizado correctamente.");
            }
            catch (Exception ex)
            {
                // Log the error here
                return StatusCode(500, $"Error interno al actualizar el cliente: {ex.InnerException?.Message ?? ex.Message}");
            }
        }


        // PUT: api/Clientes/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCliente(int id, Cliente cliente)
        {
            if (id != cliente.CodigoCliente)
            {
                return BadRequest();
            }

            _context.Entry(cliente).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ClienteExists(id))
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

        // POST: api/Clientes
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Cliente>> PostCliente(Cliente cliente)
        {
            _context.Clientes.Add(cliente);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetCliente", new { id = cliente.CodigoCliente }, cliente);
        }

        // DELETE: api/Clientes/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCliente(int id)
        {
            var cliente = await _context.Clientes.FindAsync(id);
            if (cliente == null)
            {
                return NotFound();
            }

            _context.Clientes.Remove(cliente);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ClienteExists(int id)
        {
            return _context.Clientes.Any(e => e.CodigoCliente == id);
        }
    }
}
