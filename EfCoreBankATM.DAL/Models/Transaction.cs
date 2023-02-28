using EfCoreBankATM.Domain.Enums;

namespace EfCoreBankATM.DAL.Models;

public class Transaction
{
    public int Id { get; set; }
    public int UserId { get; set; }
    public TransactionType Type { get; set; }
    public decimal Amount { get; set; }
    public DateTime DateTime { get; set; }
}
