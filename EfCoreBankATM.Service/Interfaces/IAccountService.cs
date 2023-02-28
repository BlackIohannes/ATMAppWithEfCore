using EfCoreBankATM.DAL.Models;

namespace EfCoreBankATM.Service.Interfaces;

public interface IAccountService
{
    void Deposit(User user, decimal amount);
    void Withdrawal(User user, decimal amount);
    void Payment(User user, decimal amount);
    void Transfer(User user, int recipientAccountNumber, decimal amount);
    void CheckBalance(User user);
}
