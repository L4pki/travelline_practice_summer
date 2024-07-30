using System.ComponentModel.DataAnnotations;

namespace Theater1.Dto.AuthorDto;

public class CreateAuthorRequest
{
    [Required]
    [StringLength( 100, MinimumLength = 2 )]
    public string Name { get; set; }

    [Required]
    [DataType( DataType.Date )]
    public DateTime DateOfBorth { get; set; }
}

