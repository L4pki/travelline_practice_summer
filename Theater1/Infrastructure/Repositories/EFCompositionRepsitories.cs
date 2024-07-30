using Domain.Entities;
using Domain.Repositories;

namespace Infrastructure.Repositories;
public class EFCompositionRepsitories : ICompositionRepositories
{
    private readonly TheaterDbContext _dbContext;

    public EFCompositionRepsitories ( TheaterDbContext dbContext )
    {
        _dbContext = dbContext;
    }
    public void Save( Composition composition )
    {
        _dbContext.Set<Composition>().Add( composition );
        _dbContext.SaveChanges();
    }
    public Composition GetById( int id )
    {
        return _dbContext.Set<Composition>().FirstOrDefault( t => t.Id == id );
    }
}
