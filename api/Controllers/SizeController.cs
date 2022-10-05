using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using api.Models;

namespace api.Controllers;

[ApiController]
[Route("api/size")]
public class SizeController : ControllerBase
{
    private readonly ILogger<SizeController> _logger;
    private readonly LemonadeContext _context;

    public SizeController(ILogger<SizeController> logger, LemonadeContext context)
    {
        _logger = logger;
        _context = context;
    }

    [HttpGet(Name = "GetSize")]
    [HttpGet("{id?}")]
    public async Task<ActionResult<List<Size>>> Get(int id = 0)
    {
        if (id == 0)
        {
            return _context.Size.ToList();
        }

        var size = await _context.Size.FindAsync(id);

        if (size == null)
        {
            return NotFound();
        }

        return new List<Size>() { size };
    }

    [HttpPost(Name = "PostSize")]
    public async Task<ActionResult<Size>> Post(Size size)
    {
        _context.Size.Add(size);

        await _context.SaveChangesAsync();

        return CreatedAtAction(nameof(Get), new { id = size.Id }, size);
    }

    [HttpPut(Name = "PutSize")]
    [HttpPut("{id}")]
    public async Task<IActionResult> Put(int id, Size size)
    {
        if (id != size.Id)
        {
            return BadRequest();
        }

        _context.Entry(size).State = EntityState.Modified;

        try
        {
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!SizeItemExists(id))
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

    private bool SizeItemExists(int id)
    {
        bool result = false;
        var size = _context.Size.Find(id);

        if (size != null)
        {
            result = true;
        }

        return result;
    }
}