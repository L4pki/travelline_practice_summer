using Domain.Entities;

namespace Domain.Repositories;
public interface ICompositionRepositories
{
    public void Save( Composition composition );
    public Composition GetById( int id );
}
