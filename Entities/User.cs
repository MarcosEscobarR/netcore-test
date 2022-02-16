namespace test2.Entities;

public class User
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string LastName { get; set; }
    public Post Posts { get; set; } = new();
    public bool Deleted { get; set; }
}