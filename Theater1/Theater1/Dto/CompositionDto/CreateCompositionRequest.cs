using System.ComponentModel.DataAnnotations;

namespace Theater1.Dto.CompositionDto;

public class CreateCompositionRequest
{
    [Required( ErrorMessage = "Name is required" )]
    [StringLength( 100, ErrorMessage = "Name length can't be more than 100 characters" )]
    public string Name { get; set; }

    // Описание композиции
    [StringLength( 1000, ErrorMessage = "AboutComposition length can't be more than 1000 characters" )]
    public string AboutComposition { get; set; }

    // Описание актера
    [StringLength( 1000, ErrorMessage = "AboutActor length can't be more than 1000 characters" )]
    public string AboutActor { get; set; }
    public int IdAuthor { get; set; }
}
