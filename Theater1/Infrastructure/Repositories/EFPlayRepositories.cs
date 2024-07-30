using System.Collections.Generic;
using Domain.Entities;
using Domain.Repositories;

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
        IReadOnlyList<Play> plays = _dbContext.Set<Play>()
                                    .Where( p => p.StartDate <= endDate && p.EndDate >= startDate )
                                    .ToList();
        return plays;
    }
}    