namespace Domain.Entities;
public class Theater
{
    public int Id { get; private init; }
    public string Name { get; set; }
    public string Address { get; private set; }
    public DateTime OpenSince { get; private set; }
    public string WorkTime { get; set; }
    public string About { get; set; }
    public string Phone { get; set; }

    public List<Play> Plays { get; private init; }

    public Theater(string name, string address, string about, DateTime openSince, string workTime, string phone)
    {
        Name = name;
        Address = address;
        WorkTime = workTime;
        OpenSince = openSince;
        About = about;
        Phone = phone;
    }
    public Theater() { }
}
