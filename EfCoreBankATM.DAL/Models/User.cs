namespace EfCoreBankATM.DAL.Models;

public class User
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Email { get; set; }
    public string Password { get; set; }
    public int AccountNumber { get; set; }
    public decimal AccountBalance { get; set; }
    public List<Transaction> Transactions { get; set; }
}
