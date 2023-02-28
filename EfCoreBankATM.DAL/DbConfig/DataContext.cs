using EfCoreBankATM.DAL.Models;
using Microsoft.EntityFrameworkCore;

namespace EfCoreBankATM.DAL.DbConfig;

public class DataContext : DbContext
{
    public DataContext(DbContextOptions<DataContext> options) : base(options)
    {
    }

    public DbSet<User> Users { get; set; }
    public DbSet<Transaction> Transactions { get; set; }
}
