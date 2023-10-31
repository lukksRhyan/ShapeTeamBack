using ShapeTeamBack.Models;
using ShapeTeamBack.Services;
using Microsoft.AspNetCore.Mvc;

namespace ShapeTeamBack.Controllers;

[ApiController]
[Route("[controller]")]
public class EventController : ControllerBase
{
    public EventController()
    {

    }

    // GET all action
    [HttpGet]
    public ActionResult<List<Event>> GetAll() => EventService.GetAll();

    // GET by Id action
    [HttpGet("{id}")]
    public ActionResult<Event> Get(int id)
    {
        var evento = EventService.Get(id);

        if (evento == null)
            return NotFound();

        return evento;
    }


    // POST action
    [HttpPost]
    public IActionResult Create(Event evento)
    {
        EventService.Add(evento);
        return CreatedAtAction(nameof(Get), new { id = evento.Id }, evento);
    }
    // PUT action
    [HttpPut("{id}")]
    public IActionResult Update(int id, Event evento)
    {
        if (id != evento.Id)
            return BadRequest();

        var existingEvent = EventService.Get(id);
        if (existingEvent is null)
            return NotFound();

        EventService.Update(evento);

        return NoContent();
    }
    // DELETE action
    [HttpDelete("{id}")]
    public IActionResult Delete(int id)
    {
        var evento = EventService.Get(id);

        if (evento is null)
            return NotFound();

        EventService.Delete(id);

        return NoContent();
    }
}