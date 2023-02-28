using EfCoreBankATM.DAL.DbConfig;
using EfCoreBankATM.DAL.Models;
using EfCoreBankATM.Service.Implementation;

namespace EfCoreBankATM.UI;

public class AppScreen
{
    public static void Run()
    {
        var dbContextFactory = new DataContextFactory();
        using var dbContext = dbContextFactory.CreateDbContext(null);
        dbContext.Database.EnsureCreated();

        var userService = new UserService(dbContext);
        var transactionService = new TransactionService(dbContext);
        var accountService = new AccountService(userService, transactionService);

        Console.Clear();
        Console.ForegroundColor = ConsoleColor.White;
        Console.WriteLine("\nWelcome to my ATM App.");

        while (true)
        {
            Console.WriteLine("Please select an option to continue: \n1. Register\n2. Login\n3. Exit\n");
            var options = Console.ReadLine();

            switch (options)
            {
                case "1":
                    Console.Write("Enter your name: ");
                    var name = Console.ReadLine();

                    Console.Write("Enter your email address: ");
                    var email = Console.ReadLine();

                    Console.Write("Create account number: ");
                    var accountNumber = int.Parse(Console.ReadLine());

                    Console.Write("Enter your password: ");
                    var password = Console.ReadLine();

                    var user = new User()
                    {
                        Name = name,
                        Email = email,
                        AccountNumber = accountNumber,
                        Password = password,
                        AccountBalance = 0,
                        Transactions = new List<Transaction>()
                    };
                    userService.CreateUser(user);
                    Console.WriteLine("\nRegistration was successfull.\n");
                    break;

                case "2":
                    Console.Write("Enter your email address: ");
                    var loginEmail = Console.ReadLine();

                    Console.Write("Enter your password: ");
                    var loginPassword = Console.ReadLine();

                    var loginUser = userService.GetUserByEmail(loginEmail);
                    if (loginUser == null || loginUser.Password != loginPassword)
                    {
                        Console.WriteLine("Invalid email or password\n");
                        break;
                    }

                    Console.Clear();
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.WriteLine($"Welcome back, {loginUser.Name}\n");

                    while (true)
                    {
                        Console.WriteLine("Please select an option to continue: ");
                        Console.WriteLine(
                            "1. Withdraw\n2. Payment\n3. Transfer\n4. Check Balance\n5. Deposit\n6. Logout\n");

                        var accountOption = Console.ReadLine();
                        switch (accountOption)
                        {
                            case "1":
                                Console.Write("Enter withdrawal amount: ");
                                var withdrawalAmount = decimal.Parse(Console.ReadLine());
                                accountService.Withdrawal(loginUser, withdrawalAmount);
                                break;
                            case "2":
                                Console.Write("Enter payment amount: ");
                                var paymentAmount = decimal.Parse(Console.ReadLine());
                                accountService.Payment(loginUser, paymentAmount);
                                break;
                            case "3":
                                Console.Write("Enter recipient's account number: ");
                                var recipientAccountNumber = int.Parse(Console.ReadLine());

                                Console.Write("Enter transfer amount: ");
                                var transferAmount = decimal.Parse(Console.ReadLine());

                                accountService.Transfer(loginUser, recipientAccountNumber, transferAmount);
                                break;
                            case "4":
                                accountService.CheckBalance(loginUser);
                                break;
                            case "5":
                                Console.Write("Enter the amount you wish to deposit: ");
                                var depositAmount = decimal.Parse(Console.ReadLine());
                                accountService.Deposit(loginUser, depositAmount);
                                break;
                            case "6":
                                Console.Clear();
                                Console.WriteLine($"Goodbye, {loginUser.Name}!\n");
                                break;
                            default:
                                Console.WriteLine("Invalid Option");
                                break;
                        }

                        if (accountOption == "6")
                        {
                            break;
                        }
                    }

                    break;
                case "3":
                    Console.WriteLine("Goodbye, chief!\n");
                    break;
                default:
                    Console.WriteLine("Invalid Option.");
                    break;
            }
        }
    }
}
