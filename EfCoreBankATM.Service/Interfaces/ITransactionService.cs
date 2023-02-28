using EfCoreBankATM.DAL.Models;

namespace EfCoreBankATM.Service.Interfaces;

public interface ITransactionService
{
    void CreateTransaction(Transaction transaction);
    List<Transaction> GetTransactionsByUserId(int userId);
}
