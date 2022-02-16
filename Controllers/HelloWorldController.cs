using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using test2.Data;
using test2.Entities;
using test2.Models;

namespace test2.Controllers;

[ApiController]
[Route("api/[controller]")]
public class HelloWorldController: ControllerBase
{
    private readonly DataContext _context;

    public HelloWorldController(DataContext context)
    {
        _context = context;
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> Get(int id)
    {
        var users = await _context.Users
            .IgnoreQueryFilters()
            .Include(u => u.Posts)
            .ThenInclude(p => p.User)
            .Select(user => new UserHeaderModel(user.Name))
            .ToListAsync();

        return Ok(users);
    }

    [HttpPost]
    public async Task<IActionResult> Create(List<CreateUserModel> userModels)
    {
        foreach (var userModel in userModels)
        {
            var user = new User()
            {
                Deleted = false,
                Name = userModel.Name,
                LastName = userModel.LastName,
            };
            
            _context.Users.Add(user);
        }

        await _context.SaveChangesAsync();
        
        return StatusCode(201);
    }
    
    [HttpPut("{id}")]
    public async Task<IActionResult> Update(CreateUserModel userModels, int id)
    {
        var user = await _context.Users
            .Where(u => u.Id == id)
            .FirstOrDefaultAsync();

        if (user is null)
        {
            return NotFound();
        }
        
        _context.Remove(user);
        await _context.SaveChangesAsync();
        
        return StatusCode(201);
    }
}