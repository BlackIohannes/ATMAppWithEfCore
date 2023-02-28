using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace EfCoreBankATM.DAL.DbConfig;

public class DataContextFactory : IDesignTimeDbContextFactory<DataContext>
{
    public DataContext CreateDbContext(string[] args)
    {
        var OptionBuilder = new DbContextOptionsBuilder<DataContext>();
        var ConnectionString =
            @"Server=DESKTOP-COOCBQO\SQLEXPRESS01; Database=EntityCoreBankDB; Trusted_Connection=true; TrustServerCertificate=true";
        OptionBuilder.UseSqlServer(ConnectionString);
        return new DataContext(OptionBuilder.Options);
    }
}