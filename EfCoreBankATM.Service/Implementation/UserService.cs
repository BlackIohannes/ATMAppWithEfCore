using EfCoreBankATM.DAL.DbConfig;
using EfCoreBankATM.DAL.Models;
using EfCoreBankATM.Service.Interfaces;

namespace EfCoreBankATM.Service.Implementation;

public class UserService : IUserService
{
    private readonly DataContext _context;

    public UserService(DataContext context)
    {
        _context = context;
    }

    public User CreateUser(User user)
    {
        _context.Add(user);
        _context.SaveChanges();
        return user;
    }

    public User GetUserById(int id)
    {
        return _context.Users.FirstOrDefault(x => x.Id == id);
    }

    public User GetUserByEmail(string email)
    {
        return _context.Users.FirstOrDefault(x => x.Email == email);
    }

    public User GetUserByAccountNumber(int accountNumber)
    {
        return _context.Users.FirstOrDefault(x => x.AccountNumber == accountNumber);
    }

    public void UpdateUser(User user)
    {
        _context.Users.Update(user);
        _context.SaveChanges();
    }
}
