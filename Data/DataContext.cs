using Microsoft.EntityFrameworkCore;
using test2.Entities;

namespace test2.Data;

public class DataContext: DbContext
{
    public DbSet<User> Users { get; set; }
}