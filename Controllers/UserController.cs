﻿using ShapeTeamBack.Models;
using ShapeTeamBack.Services;
using Microsoft.AspNetCore.Mvc;

namespace ShapeTeamBack.Controllers;

[ApiController]
[Route("[controller]")]
public class UserController : ControllerBase
{
    public UserController()
    {

    }

    // GET all action
    [HttpGet]
    public ActionResult<List<User>> GetAll() => UserService.GetAll();

    // GET by Id action
    [HttpGet("{id}")]
    public ActionResult<User> Get(int id)
    {
        var user = UserService.Get(id);

        if (user == null)
            return NotFound();

        return user;
    }


    // POST action
    [HttpPost]
    public IActionResult Create(User user)
    {
        UserService.Add(user);
        return CreatedAtAction(nameof(Get), new { id = user.Id }, user);
    }
    // PUT action
    [HttpPut("{id}")]
    public IActionResult Update(int id, User user)
    {
        if (id != user.Id)
            return BadRequest();

        var existingUser = UserService.Get(id);
        if (existingUser is null)
            return NotFound();

        UserService.Update(user);

        return NoContent();
    }
    // DELETE action
    [HttpDelete("{id}")]
    public IActionResult Delete(int id)
    {
        var user= UserService.Get(id);

        if (user is null)
            return NotFound();

        UserService.Delete(id);

        return NoContent();
    }
}