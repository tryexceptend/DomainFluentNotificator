namespace Application.Domain.Entities.Currecies;
/// <summary>
/// Валюта
/// </summary>
public class Currency
{
    public int Id { get; set; }
    public required string ShortName { get; set; }
    public required string AssetId { get; set; }
    public int Decimals { get; set; }
    public override string ToString()
    {
        return $"{Id} {ShortName}({AssetId}) {Decimals} decimals";
    }
}
