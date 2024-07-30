namespace Theater1.Dto.TheaterDto;

public class CreateTheaterRequest
{
    public string Name { get; set; }
    public string Address { get; set; }
    public DateTime OpenSince { get; set; }
    public string WorkTime { get; set; }
    public string About { get; set; }
    public string Phone { get; set; }

}
