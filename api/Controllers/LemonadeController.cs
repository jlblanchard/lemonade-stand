using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using api.Models;

namespace api.Controllers;

[ApiController]
[Route("api/lemonade")]
public class LemonadeController : ControllerBase
{
    private readonly ILogger<LemonadeController> _logger;
    private readonly LemonadeContext _context;

    public LemonadeController(ILogger<LemonadeController> logger, LemonadeContext context)
    {
        _logger = logger;
        _context = context;
    }

    [HttpGet(Name = "GetLemonade")]
    [HttpGet("{id?}")]
    public async Task<ActionResult<List<Lemonade>>> Get(int id  = 0)
    {
        if (id == 0)
        {
            return _context.Lemonades.Include(l => l.size).Include(l => l.type).ToList();
        }

        var lemonade = await _context.Lemonades.Include(l => l.size).Include(l => l.type).Where(l => l.Id == id).FirstOrDefaultAsync();

        if (lemonade == null)
        {
            return NotFound();
        }

        return new List<Lemonade>() { lemonade };
    }

    [HttpPost(Name = "PostLemonade")]
    public async Task<ActionResult<Lemonade>> Post(Lemonade lemonade)
    {
        _context.Lemonades.Add(lemonade);

        await _context.SaveChangesAsync();

        return CreatedAtAction(nameof(Get), new { id = lemonade.Id }, lemonade);
    }

    [HttpPut(Name = "PutLemonade")]
    [HttpPut("{id}")]
    public async Task<IActionResult> Put(int id, Lemonade lemonade)
    {
        if (id != lemonade.Id)
        {
            return BadRequest();
        }

        _context.Entry(lemonade).State = EntityState.Modified;

        try
        {
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!LemonadeItemExists(id))
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

    private bool LemonadeItemExists(int id)
    {
        bool result = false;
        var lemonade = _context.Lemonades.Find(id);

        if (lemonade != null)
        {
            result = true;
        }

        return result;
    }
}