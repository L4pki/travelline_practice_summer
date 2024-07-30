namespace Theater1.Dto.CompositionDto;

public class CreateCompositionRequest
{
    public string Name { get; set; }
    public string AboutComposition { get; set; }
    public string AboutActor { get; set; }
    public int IdAuthor { get; set; }
}
