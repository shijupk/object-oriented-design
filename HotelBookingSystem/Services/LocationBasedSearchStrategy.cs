using HotelBookingSystem.Entities;

namespace HotelBookingSystem.Services;

public interface ISearchStrategy
{
    IEnumerable<Hotel> Search(IEnumerable<Hotel> hotels, SearchCriteria criteria);
}

public class LocationBasedSearchStrategy : ISearchStrategy
{
    public IEnumerable<Hotel> Search(IEnumerable<Hotel> hotels, SearchCriteria criteria)
    {
        return hotels.Where(h => h.Location.Contains(criteria.Location, StringComparison.OrdinalIgnoreCase));
    }
}

public class PriceRangeSearchStrategy : ISearchStrategy
{
    public IEnumerable<Hotel> Search(IEnumerable<Hotel> hotels, SearchCriteria criteria)
    {
        return hotels.Where(h => h.Rooms.Any(r => r.Price >= criteria.MinPrice && r.Price <= criteria.MaxPrice));
    }
}

public class SearchCriteria
{
    public string Location { get; set; }
    public decimal MinPrice { get; set; }

    public decimal MaxPrice { get; set; }
    // Additional criteria like dates, ratings, etc.
}

public class HotelSearchService
{
    private readonly ISearchStrategy _searchStrategy;

    public HotelSearchService(ISearchStrategy searchStrategy)
    {
        _searchStrategy = searchStrategy;
    }

    public IEnumerable<Hotel> SearchHotels(IEnumerable<Hotel> hotels, SearchCriteria criteria)
    {
        return _searchStrategy.Search(hotels, criteria);
    }
}