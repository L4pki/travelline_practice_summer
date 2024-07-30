using System.ComponentModel.DataAnnotations;

namespace Theater1.Dto.TheaterDto;

public class ModifyTheaterRequest
{
    [Required]
    [StringLength( 100, MinimumLength = 2 )]
    public string Name { get; set; }
    public string WorkTime { get; set; }
    public string About { get; set; }
    public string Phone { get; set; }
}
