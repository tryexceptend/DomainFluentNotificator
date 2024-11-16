using Application.Domain.Entities.Deposits;
using Application.Domain.Interactors.DepositIteractors;
using Microsoft.Extensions.Hosting;

namespace Application;
public class Worker : BackgroundService
{
    public readonly DepositUserCase<Deposit> _depositUserCase;
    public Worker(DepositUserCase<Deposit> depositUserCase)
    {
        _depositUserCase = depositUserCase ?? throw new ArgumentNullException(nameof(depositUserCase));
    }
    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        var dep = await _depositUserCase.CreateDepositAsync("HASHHASHHASH", "sender", "recipient", 1.23m, "$");
        await _depositUserCase.RegisterDepositAsync(dep);
        await _depositUserCase.ApplyDepositAsync(dep);
        await _depositUserCase.SuccessDepositAsync(dep);
        await _depositUserCase.ErrorDepositAsync(dep);
    }
}
