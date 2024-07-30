using System.ComponentModel.DataAnnotations;

namespace Theater1.Dto.PlayDto;

public class CreatePlayRequest
{
    [Required( ErrorMessage = "Name is required" )]
    [StringLength( 100, ErrorMessage = "Name length can't be more than 100 characters" )]
    public string Name { get; set; }

    [Required( ErrorMessage = "StartDate is required" )]
    [DataType( DataType.Date, ErrorMessage = "Invalid StartDate format" )]
    public DateTime StartDate { get; set; }

    [Required( ErrorMessage = "EndDate is required" )]
    [DataType( DataType.Date, ErrorMessage = "Invalid EndDate format" )]
    public DateTime EndDate { get; set; }

    [Required( ErrorMessage = "TicketPrice is required" )]
    [Range( 0, int.MaxValue, ErrorMessage = "TicketPrice must be a non-negative number" )]
    public int TicketPrice { get; set; }

    [StringLength( 500, ErrorMessage = "About length can't be more than 500 characters" )]
    public string About { get; set; }
    public int IdTheater { get; set; }
    public int IdComposition { get; set; }
}
