using EfCoreBankATM.DAL.DbConfig;
using EfCoreBankATM.DAL.Models;
using EfCoreBankATM.Service.Interfaces;

namespace EfCoreBankATM.Service.Implementation;

public class TransactionService : ITransactionService
{
    private readonly DataContext _context;

    public TransactionService(DataContext context)
    {
        _context = context;
    }

    public void CreateTransaction(Transaction transaction)
    {
        _context.Add(transaction);
        _context.SaveChanges();
    }

    public List<Transaction> GetTransactionsByUserId(int userId)
    {
        return _context.Transactions.Where(x => x.UserId == userId).ToList();
    }
}
