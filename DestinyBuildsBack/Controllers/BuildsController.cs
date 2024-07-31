namespace DestinyBuildsBack.Controllers;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using DestinyBuildsBack.Data;
using DestinyBuildsBack.DTOs;
using DestinyBuildsBack.Models;

[Route("api/[controller]")]
    [ApiController]
    public class BuildsController : ControllerBase
    {
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;

        public BuildsController(AppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<BuildDto>>> GetBuilds()
        {
            var builds = await _context.Builds
                .Select(b => new BuildDto
                {
                    Id = b.Id,
                    Nombre = b.Nombre,
                    ClaseId = b.ClaseId,
                    SubclaseId = b.SubclaseId,
                    ArmaPrincipalId = b.ArmaPrincipalId,
                    ArmaSecundariaId = b.ArmaSecundariaId,
                    ArmaTerciariaId = b.ArmaTerciariaId,
                    ArmaduraExoticaId = b.ArmaduraExoticaId,
                    Mods = b.Mods
                })
                .ToListAsync();

            return Ok(builds);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<BuildDto>> GetBuild(int id)
        {
            var build = await _context.Builds
                .Where(b => b.Id == id)
                .Select(b => new BuildDto
                {
                    Id = b.Id,
                    Nombre = b.Nombre,
                    ClaseId = b.ClaseId,
                    SubclaseId = b.SubclaseId,
                    ArmaPrincipalId = b.ArmaPrincipalId,
                    ArmaSecundariaId = b.ArmaSecundariaId,
                    ArmaTerciariaId = b.ArmaTerciariaId,
                    ArmaduraExoticaId = b.ArmaduraExoticaId,
                    Mods = b.Mods
                })
                .SingleOrDefaultAsync();

            if (build == null)
            {
                return NotFound();
            }

            return Ok(build);
        }

        [HttpPost]
        public async Task<ActionResult<BuildDto>> PostBuild(BuildDto buildDto)
        {
            var build = _mapper.Map<Build>(buildDto);
            _context.Builds.Add(build);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetBuild), new { id = build.Id }, _mapper.Map<BuildDto>(build));
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutBuild(int id, BuildDto buildDto)
        {
            if (id != buildDto.Id)
            {
                return BadRequest();
            }

            var build = _mapper.Map<Build>(buildDto);
            _context.Entry(build).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BuildExists(id))
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
        public async Task<IActionResult> DeleteBuild(int id)
        {
            var build = await _context.Builds.FindAsync(id);
            if (build == null)
            {
                return NotFound();
            }

            _context.Builds.Remove(build);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool BuildExists(int id)
        {
            return _context.Builds.Any(e => e.Id == id);
        }
    }