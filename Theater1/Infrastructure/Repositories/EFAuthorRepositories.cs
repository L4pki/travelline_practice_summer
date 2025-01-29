using Domain.Entities;
using Domain.Repositories;

namespace Infrastructure.Repositories;
public class EFAuthorRepositories : IAuthorRepositories
{
    private readonly TheaterDbContext _dbContext;

    public EFAuthorRepositories( TheaterDbContext dbContext )
    {
        _dbContext = dbContext;
    }
    public void Save( Author author )
    {
        _dbContext.Set<Author>().Add( author );
        _dbContext.SaveChanges();
    }
    public List<Author> GetAll()
    {
        return _dbContext.Set<Author>().ToList();
    }
}
