using Domain.Entities;

namespace Domain.Repositories;
public interface ITheaterRepositories
{
    public void Save( Theater theater );
    public void Delete( int id );
    public void Update( Theater theater );
    public Theater GetById( int id );
}
