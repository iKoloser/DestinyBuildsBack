namespace DestinyBuildsBack.Controllers;

using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using DestinyBuildsBack.Data;
using DestinyBuildsBack.DTOs;
using DestinyBuildsBack.Models;

    [Route("[controller]")]
    [ApiController]
    public class ClasesController : ControllerBase
    {
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;

        public ClasesController(AppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ClaseDto>>> GetClases()
        {
            var clases = await _context.Clases.ToListAsync();
            return Ok(_mapper.Map<IEnumerable<ClaseDto>>(clases));
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ClaseDto>> GetClase(int id)
        {
            var clase = await _context.Clases.FindAsync(id);
            if (clase == null)
            {
                return NotFound();
            }
            return Ok(_mapper.Map<ClaseDto>(clase));
        }

        [HttpPost]
        public async Task<ActionResult<ClaseDto>> PostClase(ClaseDto claseDto)
        {
            var clase = _mapper.Map<Clase>(claseDto);
            _context.Clases.Add(clase);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetClase), new { id = clase.Id }, _mapper.Map<ClaseDto>(clase));
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutClase(int id, ClaseDto claseDto)
        {
            if (id != claseDto.Id)
            {
                return BadRequest();
            }

            var clase = _mapper.Map<Clase>(claseDto);
            _context.Entry(clase).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ClaseExists(id))
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
        public async Task<IActionResult> DeleteClase(int id)
        {
            var clase = await _context.Clases.FindAsync(id);
            if (clase == null)
            {
                return NotFound();
            }

            _context.Clases.Remove(clase);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ClaseExists(int id)
        {
            return _context.Clases.Any(e => e.Id == id);
        }
    }