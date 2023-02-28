using EfCoreBankATM.DAL.Models;
using EfCoreBankATM.Domain.Enums;
using EfCoreBankATM.Service.Interfaces;

namespace EfCoreBankATM.Service.Implementation;

public class AccountService : IAccountService
{
    private readonly IUserService _userService;
    private readonly ITransactionService _transactionService;

    public AccountService(IUserService userService, ITransactionService transactionService)
    {
        _userService = userService;
        _transactionService = transactionService;
    }

    public void Deposit(User user, decimal amount)
    {
        var transaction = new Transaction()
        {
            UserId = user.Id,
            Type = TransactionType.Deposit,
            Amount = amount,
            DateTime = DateTime.Now
        };
        _transactionService.CreateTransaction(transaction);
        user.AccountBalance += amount;
        _userService.UpdateUser(user);

        Console.WriteLine(
            $"Deposit of {amount:C} was successful. Your new account balance is {user.AccountBalance:C}.\n");
    }

    public void Withdrawal(User user, decimal amount)
    {
        if (user.AccountBalance < amount)
        {
            Console.WriteLine("Insufficient fund!\n");
            return;
        }

        user.AccountBalance -= amount;
        _userService.UpdateUser(user);

        var transaction = new Transaction()
        {
            UserId = user.Id,
            Type = TransactionType.Withdrawal,
            Amount = amount,
            DateTime = DateTime.Now
        };
        _transactionService.CreateTransaction(transaction);
        Console.WriteLine($"Withdrawal of {amount:C} was successful.\n");
    }

    public void Payment(User user, decimal amount)
    {
        if (user.AccountBalance < amount)
        {
            Console.WriteLine("Insufficient fund.\n");
            return;
        }

        user.AccountBalance -= amount;
        _userService.UpdateUser(user);

        var transaction = new Transaction()
        {
            UserId = user.Id,
            Type = TransactionType.Payment,
            Amount = amount,
            DateTime = DateTime.Now
        };
        _transactionService.CreateTransaction(transaction);
        Console.WriteLine($"Payment of {amount:C} was successful.\n");
    }

    public void Transfer(User user, int recipientAccountNumber, decimal amount)
    {
        if (user.AccountBalance < amount)
        {
            Console.WriteLine("Insufficient fund.");
            return;
        }

        var recipientUser = _userService.GetUserByAccountNumber(recipientAccountNumber);
        if (recipientUser == null)
        {
            Console.WriteLine("Recipient account not found.\n");
            return;
        }

        user.AccountBalance -= amount;
        recipientUser.AccountBalance += amount;
        _userService.UpdateUser(user);
        _userService.UpdateUser(recipientUser);

        var transaction = new Transaction()
        {
            UserId = user.Id,
            Type = TransactionType.Transfer,
            Amount = amount,
            DateTime = DateTime.Now
        };
        _transactionService.CreateTransaction(transaction);
        Console.WriteLine($"Transfer of {amount:C} to {recipientUser.AccountNumber} was successful.\n");
    }

    public void CheckBalance(User user)
    {
        Console.WriteLine($"Your account balance is {user.AccountBalance:C}\n");
    }
}
