namespace Theater1.Dto.PlayDto;

public class CreatePlayRequest
{
    public string Name { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
    public int TicketPrice { get; set; }
    public string About { get; set; }
    public int IdTheater { get; set; }
    public int IdComposition { get; set; }
}
