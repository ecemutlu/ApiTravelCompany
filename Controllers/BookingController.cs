using ApiTravelCompany.Db;
using ApiTravelCompany.Models;
using Microsoft.AspNetCore.Mvc;
using ApiTravelCompany.Dto;
using Microsoft.AspNetCore.Http.HttpResults;



namespace ApiTravelCompany.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookingController : ControllerBase
    {
        private readonly TravelContext _context;

        public BookingController(TravelContext context)
        {
            _context = context;
        }

        [HttpGet,Route("")]
        public IEnumerable<House> GetHouses(int page, int recordsInPage, DateOnly dateFrom, DateOnly dateTo, int noOfPeople, string? city)
        {
            var allHouses = _context.Houses.
                            Where(h => h.Capacity >= noOfPeople);
            if (city != null)
                allHouses = allHouses.Where(h => h.City == city);
            var booked = _context.Bookings.
                        Where(b => (dateFrom <= b.DateFrom && dateTo >= b.DateFrom)
                        || (dateFrom <= b.DateTo && dateTo >= b.DateTo)
                        || (dateFrom <= b.DateFrom && dateTo >= b.DateTo))
                        .Select(b => b.HouseId);
            var result = allHouses.Where(h => !booked.Contains(h.Id))
                .OrderBy(h => h.Id)
                .Skip((page - 1) * recordsInPage)
                .Take(recordsInPage);
            return result;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Booking>> GetBooking(string id)
        {
            var booking = await _context.Bookings.FindAsync(id);

            if (booking == null)
            {
                return NotFound();
            }

            return booking;
        }

        [HttpPost,Route("")]
        public  IActionResult BookAHouse(BookingRequestDto bookingRequest)
        {
            var presentBookings = _context.Bookings.
                Where(b => b.HouseId == bookingRequest.HouseId && 
                    ((bookingRequest.DateFrom <= b.DateFrom && bookingRequest.DateTo >= b.DateFrom)
                        || (bookingRequest.DateFrom <= b.DateTo && bookingRequest.DateTo >= b.DateTo)
                        || (bookingRequest.DateFrom <= b.DateFrom && bookingRequest.DateTo >= b.DateTo)))
                .Any();
            if (presentBookings)
                throw new Exception("These dates are not available!");
                       
            var booking = new Booking
            {
                Id= Guid.NewGuid().ToString(),
                HouseId = bookingRequest.HouseId,
                DateFrom = bookingRequest.DateFrom,
                DateTo = bookingRequest.DateTo,
                CustomerNames = bookingRequest.NamesOfPeople
            };
            return CreatedAtAction("GetBooking", new { id = booking.Id }, booking);
        }

    }
}
