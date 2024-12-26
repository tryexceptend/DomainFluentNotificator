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
    private readonly INotificator _notificator2;
    private readonly INotificatorSimple _notificatorSimple;
    private int _id = 0;
    public DepositUserCase(
        INotificator<DepositUserCaseMessage> notificator,
        INotificator notificator2,
        INotificatorSimple notificatorSimple
        )
    {
        _notificator = notificator ?? throw new ArgumentNullException(nameof(notificator));
        _notificator2 = notificator2 ?? throw new ArgumentNullException(nameof(notificator2));
        _notificatorSimple = notificatorSimple ?? throw new ArgumentNullException(nameof(notificatorSimple));
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
        await _notificator2.SendMessageAsync(new DepositUserCaseMessage().AddDepositInfo(deposit).AddMessage("Create deposit"), "INFO");
        await _notificatorSimple.SendMessageAsync(new DepositUserCaseMessage().AddDepositInfo(deposit).AddMessage("Create deposit"), "INFO");
        return deposit;
    }
    public async Task RegisterDepositAsync(Deposit deposit)
    {
        deposit.State = DepositState.Register;
        await _notificator.SendMessageAsync(new DepositUserCaseMessage().AddDepositInfo(deposit).AddMessage("Register deposit on agent"), "INFO");
        await _notificator2.SendMessageAsync(new DepositUserCaseMessage().AddDepositInfo(deposit).AddMessage("Register deposit on agent"), "INFO");
        await _notificatorSimple.SendMessageAsync(new DepositUserCaseMessage().AddDepositInfo(deposit).AddMessage("Register deposit on agent"), "INFO");
    }
    public async Task ApplyDepositAsync(Deposit deposit)
    {
        deposit.State = DepositState.Apply;
        await _notificator.SendMessageAsync(new DepositUserCaseMessage().AddDepositInfo(deposit).AddMessage("Apply deposit on agent"), "INFO");
        await _notificator2.SendMessageAsync(new DepositUserCaseMessage().AddDepositInfo(deposit).AddMessage("Apply deposit on agent"), "INFO");
        await _notificatorSimple.SendMessageAsync(new DepositUserCaseMessage().AddDepositInfo(deposit).AddMessage("Apply deposit on agent"), "INFO");
    }
    public async Task SuccessDepositAsync(Deposit deposit)
    {
        deposit.State = DepositState.Success;
        await _notificator.SendMessageAsync(new DepositUserCaseMessage().AddDepositInfo(deposit).AddMessage("Finish deposit on agent"), "INFO");
        await _notificator2.SendMessageAsync(new DepositUserCaseMessage().AddDepositInfo(deposit).AddMessage("Finish deposit on agent"), "INFO");
        await _notificatorSimple.SendMessageAsync(new DepositUserCaseMessage().AddDepositInfo(deposit).AddMessage("Finish deposit on agent"), "INFO");
    }
    public async Task ErrorDepositAsync(Deposit deposit)
    {
        deposit.State = DepositState.Error;
        await _notificator.SendMessageAsync(new DepositUserCaseMessage().AddException(new Exception("Error deposit")), "ERROR");
        await _notificator2.SendMessageAsync(new DepositUserCaseMessage().AddException(new Exception("Error deposit")), "ERROR");
        await _notificatorSimple.SendMessageAsync(new DepositUserCaseMessage().AddException(new Exception("Error deposit")), "ERROR");
    }
}
