namespace ApiTravelCompany.Dto
{
    public class BookingRequestDto
    {
        public string HouseId { get; set; }
        public string NamesOfPeople { get; set; }
        public DateOnly DateFrom { get; set; }
        public DateOnly DateTo { get; set; }
    }
}
