namespace DestinyBuildsBack.Controllers;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using DestinyBuildsBack.Data;
using DestinyBuildsBack.DTOs;
using DestinyBuildsBack.Models;


[Route("api/[controller]")]
    [ApiController]
    public class ArmasController : ControllerBase
    {
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;

        public ArmasController(AppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ArmaDto>>> GetArmas()
        {
            var armas = await _context.Armas.ToListAsync();
            return Ok(_mapper.Map<IEnumerable<ArmaDto>>(armas));
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ArmaDto>> GetArma(int id)
        {
            var arma = await _context.Armas.FindAsync(id);
            if (arma == null)
            {
                return NotFound();
            }
            return Ok(_mapper.Map<ArmaDto>(arma));
        }

        [HttpPost]
        public async Task<ActionResult<ArmaDto>> PostArma(ArmaDto armaDto)
        {
            var arma = _mapper.Map<Arma>(armaDto);
            _context.Armas.Add(arma);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetArma), new { id = arma.Id }, _mapper.Map<ArmaDto>(arma));
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutArma(int id, ArmaDto armaDto)
        {
            if (id != armaDto.Id)
            {
                return BadRequest();
            }

            var arma = _mapper.Map<Arma>(armaDto);
            _context.Entry(arma).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ArmaExists(id))
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
        public async Task<IActionResult> DeleteArma(int id)
        {
            var arma = await _context.Armas.FindAsync(id);
            if (arma == null)
            {
                return NotFound();
            }

            _context.Armas.Remove(arma);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ArmaExists(int id)
        {
            return _context.Armas.Any(e => e.Id == id);
        }
    }