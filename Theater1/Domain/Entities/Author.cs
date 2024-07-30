namespace Domain.Entities;
public class Author
{
    public int Id { get; private init; }
    public string Name { get; private set; }
    public DateTime DateOfBorth { get; private set; }

    public Author( string name, DateTime dateOfBorth )
    {
        Name = name;
        DateOfBorth = dateOfBorth;
    }

    public Author()
    {
    }

    public List<Composition> Compositions { get; private set; } = new List<Composition>();
}
