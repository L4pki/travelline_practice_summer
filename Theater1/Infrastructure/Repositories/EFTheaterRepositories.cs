using Domain.Entities;
using Domain.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories;
public class EFTheaterRepositories : ITheaterRepositories
{
    private readonly TheaterDbContext _dbContext;

    public EFTheaterRepositories( TheaterDbContext dbContext )
    {
        _dbContext = dbContext;
    }

    public void Save( Theater theater )
    {
        _dbContext.Set<Theater>().Add( theater );
        _dbContext.SaveChanges();
    }

    public void Update( Theater modifiedTheater )
    {
        var theater = _dbContext.Set<Theater>().FirstOrDefault( t => t.Id == modifiedTheater.Id );
        if ( theater == null )
        {
            Save( modifiedTheater );
            return;
        }

        theater.Name = modifiedTheater.Name;
        theater.Phone = modifiedTheater.Phone;
        theater.About = modifiedTheater.About;
        theater.StartTime = modifiedTheater.StartTime;
        theater.EndTime = modifiedTheater.EndTime;

        _dbContext.SaveChanges();
    }

    public void Delete( int id )
    {
        var theater = _dbContext.Set<Theater>().FirstOrDefault( t => t.Id == id );
        if ( theater != null )
        {
            _dbContext.Remove( theater );
            _dbContext.SaveChanges();
        }
    }

    public Theater GetById( int id )
    {
        return _dbContext.Set<Theater>().FirstOrDefault( t => t.Id == id );
    }
}
