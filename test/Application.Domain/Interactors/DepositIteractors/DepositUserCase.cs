using Application.Domain.Entities.Deposits;
using DomainFluentNotificator.Domain;

namespace Application.Domain.Interactors.DepositIteractors;
/// <summary>
/// Некий юзеркейс, который обрабатывает депозиты и отправляет сообщения о ходе работы в чат.
/// </summary>
/// <typeparam name="T"></typeparam>
public class DepositUserCase<T> where T : Deposit
{
    private readonly INotificator<DepositUserCaseMessage> _notificator;
    private int _id = 0;
    public DepositUserCase(INotificator<DepositUserCaseMessage> notificator)
    {
        _notificator = notificator ?? throw new ArgumentNullException(nameof(notificator));
    }

    public async Task<Deposit> CreateDepositAsync(string hash, string sender, string recipient, decimal amount, string assetId)
    {
        Deposit deposit = new Deposit()
        {
            AssetId = assetId,
            Hash = hash,
            Recipient = recipient,
            Sender = sender,
            Amount = amount,
            Id = _id++,
            State = DepositState.Create
        };
        await _notificator.SendMessageAsync(new DepositUserCaseMessage().AddDepositInfo(deposit).AddMessage("Create deposit"), "INFO");
        return deposit;
    }
    public Task RegisterDepositAsync(Deposit deposit)
    {
        deposit.State = DepositState.Register;
        return _notificator.SendMessageAsync(new DepositUserCaseMessage().AddDepositInfo(deposit).AddMessage("Register deposit on agent"), "INFO");
    }
    public Task ApplyDepositAsync(Deposit deposit)
    {
        deposit.State = DepositState.Apply;
        return _notificator.SendMessageAsync(new DepositUserCaseMessage().AddDepositInfo(deposit).AddMessage("Apply deposit on agent"), "INFO");
    }
    public Task SuccessDepositAsync(Deposit deposit)
    {
        deposit.State = DepositState.Success;
        return _notificator.SendMessageAsync(new DepositUserCaseMessage().AddDepositInfo(deposit).AddMessage("Finish deposit on agent"), "INFO");
    }
    public Task ErrorDepositAsync(Deposit deposit)
    {
        deposit.State = DepositState.Error;
        return _notificator.SendMessageAsync(new DepositUserCaseMessage().AddException(new Exception("Error deposit")), "ERROR");
    }
}
