namespace Domain.Entities;
public class Composition
{
    public int Id { get; private init; }
    public string Name { get; private set; }
    public string AboutComposition { get; private set; }
    public string AboutActor { get; private set; }
    public int IdAuthor { get; private set; }

    public Composition( string name, string aboutComposition, string aboutActor, int idAuthor )
    {
        Name = name;
        AboutComposition = aboutComposition;
        AboutActor = aboutActor;
        IdAuthor = idAuthor;
    }

    public Composition()
    {
    }

    public Author Author { get; private set; }
    public List<Play> Plays { get; private init; }
}
