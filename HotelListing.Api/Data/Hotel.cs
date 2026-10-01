namespace HotelListing.Api.Data;

public class Hotel
{
    public int Id { get; set; }
    public String Name { get; set; }
    public String Address { get; set; }
    public Double Ratings { get; set; }

    public int CountryId { get; set; }
    public Country? Country { get; set; }

}
