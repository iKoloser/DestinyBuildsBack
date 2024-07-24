namespace DestinyBuildsBack.Controllers;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using DestinyBuildsBack.Data;
using DestinyBuildsBack.DTOs;
using DestinyBuildsBack.Models;


[Route("api/[controller]")]
    [ApiController]
    public class SubclasesController : ControllerBase
    {
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;

        public SubclasesController(AppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<SubclaseDto>>> GetSubclases()
        {
            var subclases = await _context.Subclases.ToListAsync();
            return Ok(_mapper.Map<IEnumerable<SubclaseDto>>(subclases));
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<SubclaseDto>> GetSubclase(int id)
        {
            var subclase = await _context.Subclases.FindAsync(id);
            if (subclase == null)
            {
                return NotFound();
            }
            return Ok(_mapper.Map<SubclaseDto>(subclase));
        }

        [HttpPost]
        public async Task<ActionResult<SubclaseDto>> PostSubclase(SubclaseDto subclaseDto)
        {
            var subclase = _mapper.Map<Subclase>(subclaseDto);
            _context.Subclases.Add(subclase);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetSubclase), new { id = subclase.Id }, _mapper.Map<SubclaseDto>(subclase));
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutSubclase(int id, SubclaseDto subclaseDto)
        {
            if (id != subclaseDto.Id)
            {
                return BadRequest();
            }

            var subclase = _mapper.Map<Subclase>(subclaseDto);
            _context.Entry(subclase).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SubclaseExists(id))
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
        public async Task<IActionResult> DeleteSubclase(int id)
        {
            var subclase = await _context.Subclases.FindAsync(id);
            if (subclase == null)
            {
                return NotFound();
            }

            _context.Subclases.Remove(subclase);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool SubclaseExists(int id)
        {
            return _context.Subclases.Any(e => e.Id == id);
        }
    }