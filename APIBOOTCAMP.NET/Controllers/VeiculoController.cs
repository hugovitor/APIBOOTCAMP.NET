using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using APIBOOTCAMP.NET.BootCampContext;
using APIBOOTCAMP.NET.Models;

namespace APIBOOTCAMP.NET.Controllers
{
    [Route("api/bootcamp/[controller]")]
    [ApiController]
    public class VeiculoController : ControllerBase
    {
        private readonly Context _context;

        public VeiculoController(Context context)
        {
            _context = context;
        }
        
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Veiculo>>> GetVeiculos()
        {
            return await _context.Veiculos.ToListAsync();
        }

        
        [HttpGet("{id}")]
        public async Task<ActionResult<Veiculo>> GetVeiculo(int id)
        {
            var veiculo = await _context.Veiculos.FindAsync(id);

            if (veiculo == null)
            {
                return NotFound();
            }

            return veiculo;
        }


        [HttpPut("{id}")]
        public async Task<IActionResult> PutVeiculo(int id, Veiculo veiculo)
        {
            if (id != veiculo.VeiculoId)
            {
                return BadRequest();
            }

            _context.Entry(veiculo).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!VeiculoExiste(id))
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

        [HttpPost]
        public async Task<ActionResult<Veiculo>> PostVeiculo(Veiculo veiculo)
        {
            Veiculo obj = new Veiculo();
            obj.Placa = veiculo.Placa;
            obj.Marca = veiculo.Marca;
            obj.Modelo = veiculo.Modelo;
            obj.Ano = veiculo.Ano;
            obj.Cor = veiculo.Cor;
            obj.Combustivel = veiculo.Combustivel;

            _context.Veiculos.Add(obj);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetVeiculo", new { id = obj.VeiculoId }, obj);
        }


        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteVeiculo(int id)
        {
            var veiculo = await _context.Veiculos.FindAsync(id);
            if (veiculo == null)
            {
                return NotFound();
            }

            _context.Veiculos.Remove(veiculo);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool VeiculoExiste(int id)
        {
            return _context.Veiculos.Any(e => e.VeiculoId == id);
        }
    }
}
