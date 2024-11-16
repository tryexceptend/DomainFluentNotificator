namespace Application.Domain.Entities.Deposits;
/// <summary>
/// Депозит
/// </summary>
public class Deposit
{
    public int Id { get; set; }
    public required string Hash { get; set; }
    public required string Sender { get; set; }
    public required string Recipient { get; set; }
    public decimal Amount { get; set; }
    public required string AssetId { get; set; }
    public DepositState State { get; set; }
    public override string ToString()
    {
        return $"[{State}] {Id} {Hash} from {Sender} to {Recipient} {Amount} {AssetId}";
    }
}

public enum DepositState
{
    Create = 0,
    Register,
    Apply,
    Success,
    Error
}