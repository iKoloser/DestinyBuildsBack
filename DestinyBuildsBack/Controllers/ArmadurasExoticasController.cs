namespace DestinyBuildsBack.Controllers;

using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using DestinyBuildsBack.Data;
using DestinyBuildsBack.DTOs;
using DestinyBuildsBack.Models;

[Route("api/[controller]")]
    [ApiController]
    public class ArmadurasExoticasController : ControllerBase
    {
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;

        public ArmadurasExoticasController(AppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ArmaduraExoticaDto>>> GetArmadurasExoticas()
        {
            var armaduras = await _context.ArmadurasExoticas.ToListAsync();
            return Ok(_mapper.Map<IEnumerable<ArmaduraExoticaDto>>(armaduras));
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ArmaduraExoticaDto>> GetArmaduraExotica(int id)
        {
            var armadura = await _context.ArmadurasExoticas.FindAsync(id);
            if (armadura == null)
            {
                return NotFound();
            }
            return Ok(_mapper.Map<ArmaduraExoticaDto>(armadura));
        }

        [HttpPost]
        public async Task<ActionResult<ArmaduraExoticaDto>> PostArmaduraExotica(ArmaduraExoticaDto armaduraDto)
        {
            var armadura = _mapper.Map<ArmaduraExotica>(armaduraDto);
            _context.ArmadurasExoticas.Add(armadura);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetArmaduraExotica), new { id = armadura.Id }, _mapper.Map<ArmaduraExoticaDto>(armadura));
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutArmaduraExotica(int id, ArmaduraExoticaDto armaduraDto)
        {
            if (id != armaduraDto.Id)
            {
                return BadRequest();
            }

            var armadura = _mapper.Map<ArmaduraExotica>(armaduraDto);
            _context.Entry(armadura).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ArmaduraExoticaExists(id))
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

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteArmaduraExotica(int id)
        {
            var armadura = await _context.ArmadurasExoticas.FindAsync(id);
            if (armadura == null)
            {
                return NotFound();
            }

            _context.ArmadurasExoticas.Remove(armadura);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ArmaduraExoticaExists(int id)
        {
            return _context.ArmadurasExoticas.Any(e => e.Id == id);
        }
    }