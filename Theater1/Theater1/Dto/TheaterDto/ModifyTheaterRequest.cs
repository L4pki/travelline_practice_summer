using System.ComponentModel.DataAnnotations;

namespace Theater1.Dto.TheaterDto;

public class ModifyTheaterRequest
{
    [Required( ErrorMessage = "Name is required" )]
    [StringLength( 100, ErrorMessage = "Name length can't be more than 100 characters" )]
    public string Name { get; set; }

    [StringLength( 500, ErrorMessage = "About length can't be more than 500 characters" )]
    public string About { get; set; }

    [Required( ErrorMessage = "StartTime is required" )]
    public TimeSpan StartTime { get; set; }

    [Required( ErrorMessage = "EndTime is required" )]
    public TimeSpan EndTime { get; set; }

    [Required( ErrorMessage = "Phone is required" )]
    [Phone( ErrorMessage = "Invalid phone number" )]
    public string Phone { get; set; }
}
