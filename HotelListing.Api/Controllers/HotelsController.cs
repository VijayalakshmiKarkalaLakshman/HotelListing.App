using HotelListing.Api.Data;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace HotelListing.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class HotelsController : ControllerBase
{
    private static List<Hotel> hotels = new List<Hotel>
{
new Hotel{Id=1,Name="Taj",Address="Opp India gate Mumbai India", Ratings=4.9},
new Hotel{Id=2,Name="Vinvanta",Address="M G Road Bangalore India", Ratings=4.8}
};

    // GET: api/<HotelsController>
    [HttpGet("GetHotels")]
    public ActionResult<IEnumerable<Hotel>> GetHotels()
    {
        return Ok(hotels);
    }

    // GET api/<HotelsController>/5
    [HttpGet("{id}")]
    
    public ActionResult<Hotel> GetId(int id)
    {
        var singleHotel = hotels.FirstOrDefault(h => h.Id == id);
        if (singleHotel == null)
        {
            return NotFound();
        }
        return Ok(singleHotel);
    }

    // POST api/<HotelsController>
    [HttpPost]
    public ActionResult<Hotel> Post([FromBody] Hotel newHotel)
    {
        if (hotels.Any(h => h.Id == newHotel.Id))
        {
            return BadRequest("Hotel with the same ID already exists."); 
        }
        hotels.Add(newHotel);
        return CreatedAtAction(nameof(GetHotels), new { id = newHotel.Id }, newHotel);
    }

    // PUT api/<HotelsController>/5
    [HttpPut("{id}")]
    public ActionResult Put(int id, [FromBody] Hotel updatedHotel)
    {
        var existingHotel = hotels.FirstOrDefault(h => h.Id == id);
        if (existingHotel == null)
        {
            return NotFound();
        }
        existingHotel.Name = updatedHotel.Name;
        existingHotel.Address = updatedHotel.Address;
        existingHotel.Ratings = updatedHotel.Ratings;
        return NoContent();
    }

    // DELETE api/<HotelsController>/5
    [HttpDelete("{id}")]
    public ActionResult Delete(int id)
    {
        var hotelToDelete = hotels.FirstOrDefault(h => h.Id == id);
        if (hotelToDelete == null)
        {
            return NotFound();
        }
        hotels.Remove(hotelToDelete);
        return NoContent();
    }
}
