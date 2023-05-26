using Microsoft.AspNetCore.Mvc;
using RestaurantRaterApi.Data;

[ApiController]
[Route("[controller]")]
public class RatingController : ControllerBase
{
    private readonly RestaurantDbContext _context;
    public RatingController(RestaurantDbContext context)
    {
        _context = context;
    }

    [HttpPost]
    public async Task<IActionResult> RateRestaurant([FromBody] Rating request)
    {
        // Check if the request model is valid
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        // Add it to our db context
        _context.Ratings.Add(request);

        // Save changes
        await _context.SaveChangesAsync();

        // Respond to the user
        return Ok();
    }
}