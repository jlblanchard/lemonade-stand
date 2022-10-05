using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using api.Models;
using LemonadeType = api.Models.Type;

[ApiController]
[Route("api/type")]
public class TypeController : ControllerBase
{
    private readonly ILogger<TypeController> _logger;
    private readonly LemonadeContext _context;

    public TypeController(ILogger<TypeController> logger, LemonadeContext context)
    {
        _logger = logger;
        _context = context;
    }

    [HttpGet(Name = "GetType")]
    [HttpGet("{id?}")]
    public async Task<ActionResult<List<LemonadeType>>> Get(int id = 0)
    {
        if (id == 0)
        {
            return _context.Type.ToList();
        }

        var type = await _context.Type.FindAsync(id);

        if (type == null)
        {
            return NotFound();
        }

        return new List<LemonadeType>() { type };
    }

    [HttpPost(Name = "PostType")]
    public async Task<ActionResult<LemonadeType>> Post(LemonadeType type)
    {
        _context.Type.Add(type);

        await _context.SaveChangesAsync();

        return CreatedAtAction(nameof(Get), new { id = type.Id }, type);
    }

    [HttpPut(Name = "PutType")]
    [HttpPut("{id}")]
    public async Task<IActionResult> Put(int id, LemonadeType type)
    {
        if (id != type.Id)
        {
            return BadRequest();
        }

        _context.Entry(type).State = EntityState.Modified;
        
        try
        {
            await _context.SaveChangesAsync();
        } catch (DbUpdateConcurrencyException)
        {
            if (!TypeItemExists(id))
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

    private bool TypeItemExists(int id)
    {
        bool result = false;
        var type = _context.Type.Find(id);

        if (type != null)
        {
            result = true;
        }

        return result;
    }
}