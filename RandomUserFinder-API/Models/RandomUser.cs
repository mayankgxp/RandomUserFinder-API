#nullable enable
namespace RandomUserFinder.Models;
public class Name
{
    public string Title { get; set; }
    public string First { get; set; }
    public string Last { get; set; }
}

public class Dob
{
    public DateTime Date { get; set; }
    public int Age { get; set; }
}

public class Picture
{
    public string Large { get; set; }
    public string Medium { get; set; }
    public string Thumbnail { get; set; }
}

public class RandomeUserInfo
{
    public string Gender { get; set; }
    public Name Name { get; set; }
    public string Email { get; set; }
    public Dob Dob { get; set; }
    public string Phone { get; set; }
    public object Id { get; set; }
    public Picture Picture { get; set; }

}

public class RandomUser
{
    public List<RandomeUserInfo> Results { get; set; }
}