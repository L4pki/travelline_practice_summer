namespace Domain.Entities;
public class Play
{
    public int Id { get; private init; }
    public string Name { get; private set; }
    public DateTime StartDate { get; private set; }
    public DateTime EndDate { get; private set; }
    public int TicketPrice { get; private set; }
    public string About { get; private set; }
    public int IdTheater { get; private set; }
    public int IdComposition { get; private set; }

    public Play( string name, DateTime startDate, DateTime endDate, int ticketPrice, string about, int idTheater, int idComposition )
    {
            Name = name;
            StartDate = startDate;
            EndDate = endDate;
            TicketPrice = ticketPrice;
            About = about;
            IdTheater = idTheater;
            IdComposition = idComposition;
    }
    public Play() { }

    public Theater Theater { get; private set; }
    public Composition Composition { get; private set; }
}

public class PlayInfo
{
    public string Name { get; set; }
    public int TicketPrice { get; set; }
    public string AboutPlay { get; set; }
    public string AboutComposition { get; set; }
    public string AboutActors { get; set; }
}

public class AvailablePlaysResponse
{
    public string TheaterName { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
    public List<PlayInfo> Plays { get; set; }
}