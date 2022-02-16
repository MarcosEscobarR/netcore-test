namespace test2.Entities;

public class Post
{
    public int Id { get; set; }
    public string Description { get; set; }
    public User User { get; set; }
}