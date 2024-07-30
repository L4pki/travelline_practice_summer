using Domain.Entities;
using Domain.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories;

public class EFPlayRepositories : IPlayRepositories
{
    private readonly TheaterDbContext _dbContext;

    public EFPlayRepositories( TheaterDbContext dbContext )
    {
        _dbContext = dbContext;
    }

    public void Save( Play play )
    {
        _dbContext.Set<Play>().Add( play );
        _dbContext.SaveChanges();
    }

    public IReadOnlyList<Play> GetByPeriod( DateTime startDate, DateTime endDate )
    {
        return _dbContext.Set<Play>()
            .Where( p => p.StartDate <= endDate && p.EndDate >= startDate )
            .Include( p => p.Composition )
            .ToList();
    }

    public List<AvailablePlaysResponse> GetAvailablePlays( DateTime startDate, DateTime endDate )
    {
        if ( startDate == default( DateTime ) || endDate == default( DateTime ) )
        {
            throw new ArgumentException( "Start date and end date must be valid dates." );
        }

        if ( startDate > endDate )
        {
            throw new ArgumentException( "Start date must be earlier than or equal to end date." );
        }

        var plays = GetByPeriod( startDate, endDate );
        if ( plays == null || !plays.Any() )
        {
            throw new FileNotFoundException( "No plays available for the given date range." );
        }

        var theaterPlayGroups = plays.GroupBy( p => p.IdTheater );

        var availablePlaysResponses = new List<AvailablePlaysResponse>();

        foreach ( var theaterPlayGroup in theaterPlayGroups )
        {
            var theater = _dbContext.Theaters.FirstOrDefault( t => t.Id == theaterPlayGroup.Key );
            if ( theater == null )
            {
                throw new FileNotFoundException( "Theater not found." );
            }

            var playInfos = theaterPlayGroup.Select( play => new PlayInfo
            {
                Name = play.Name,
                TicketPrice = play.TicketPrice,
                AboutPlay = play.About,
                AboutComposition = play.Composition?.AboutComposition,
                AboutActors = play.Composition?.AboutActor
            } ).ToList();

            availablePlaysResponses.Add( new AvailablePlaysResponse
            {
                TheaterName = theater.Name,
                StartDate = startDate,
                EndDate = endDate,
                Plays = playInfos
            } );
        }

        return availablePlaysResponses;
    }
}