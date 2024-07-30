namespace Domain.Entities;
public class Theater
{
    public int Id { get; private init; }
    public string Name { get; set; }
    public string Address { get; private set; }
    public DateTime OpenSince { get; private set; }
    public TimeSpan StartTime { get; private set; }
    public TimeSpan EndTime { get; private set; }
    public string About { get; set; }
    public string Phone { get; set; }

    public List<Play> Plays { get; private init; }

    public Theater(string name, string address, string about, DateTime openSince, TimeSpan startTime, TimeSpan endTime, string phone)
    {
        Name = name;
        Address = address;
        StartTime = startTime;
        EndTime = endTime;
        OpenSince = openSince;
        About = about;
        Phone = phone;
    }
    public Theater() { }
}
