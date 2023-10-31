using ShapeTeamBack.Models;
using ShapeTeamBack.Services;
using Microsoft.AspNetCore.Mvc;

namespace ShapeTeamBack.Controllers;

[ApiController]
[Route("[controller]")]
public class GymController : ControllerBase
{
    public GymController()
    {

    }

    // GET all action
    [HttpGet]
    public ActionResult<List<Gym>> GetAll() => GymService.GetAll();

    // GET by Id action
    [HttpGet("{id}")]
    public ActionResult<Gym> Get(int id)
    {
        var gym = GymService.Get(id);

        if (gym == null)
            return NotFound();

        return gym;
    }


    // POST action
    [HttpPost]
    public IActionResult Create(Gym gym)
    {
        GymService.Add(gym);
        return CreatedAtAction(nameof(Get), new { id = gym.Id }, gym);
    }
    // PUT action
    [HttpPut("{id}")]
    public IActionResult Update(int id, Gym gym)
    {
        if (id != gym.Id)
            return BadRequest();

        var existingGym = GymService.Get(id);
        if (existingGym is null)
            return NotFound();

        GymService.Update(gym);

        return NoContent();
    }
    // DELETE action
    [HttpDelete("{id}")]
    public IActionResult Delete(int id)
    {
        var gym = GymService.Get(id);

        if (gym is null)
            return NotFound();

        GymService.Delete(id);

        return NoContent();
    }
}