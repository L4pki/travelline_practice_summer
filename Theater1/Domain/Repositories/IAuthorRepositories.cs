using Domain.Entities;

namespace Domain.Repositories;
public interface IAuthorRepositories
{
    public void Save( Author author );
    public List<Author> GetAll();
}
