using System.ComponentModel.DataAnnotations;

namespace Theater1.Dto.PlayDto;

public class PeriodPlayRequest
{
    [Required( ErrorMessage = "StartDate is required" )]
    [DataType( DataType.Date, ErrorMessage = "Invalid StartDate format" )]
    public DateTime StartDate { get; set; }

    [Required( ErrorMessage = "EndDate is required" )]
    [DataType( DataType.Date, ErrorMessage = "Invalid EndDate format" )]
    public DateTime EndDate { get; set; }
}
