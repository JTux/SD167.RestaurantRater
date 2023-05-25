using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RestaurantRaterApi.Data;

namespace RestaurantRaterApi.Controllers;

[ApiController] // Tells AspNet that it's an API controller
[Route("[controller]")] // Gets the route from the controller name
public class RestaurantController : ControllerBase
{
    private readonly RestaurantDbContext _context;
    // Dependency Injection is what provides the DbContext instance
    public RestaurantController(RestaurantDbContext context)
    {
        _context = context;
    }

    // Async GET Endpoint
    [HttpGet]
    public async Task<IActionResult> GetRestaurants()
    {
        List<Restaurant> restaurants = await _context.Restaurants.ToListAsync();
        return Ok(restaurants);
    }
}
