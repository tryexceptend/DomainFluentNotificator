using Application.Domain.Entities.Currecies;
using Application.Domain.Entities.Deposits;
using DomainFluentNotificator.Domain;

namespace Application.Domain.Interactors.DepositIteractors;
/// <summary>
/// Создаем новый тип сообщения, в котором будут данные о депозитах
/// </summary>
public class DepositUserCaseMessage : Message
{
    /// <summary>
    /// Добавляет информацию о депозите 
    /// </summary>
    /// <param name="deposit"></param>
    /// <returns></returns>
    public IMessage AddDepositInfo(Deposit deposit)
    {
        return AddMessageElement(deposit.ToString(), deposit);
    }
    /// <summary>
    /// Добавляет информацию об ошибке
    /// </summary>
    /// <param name="error"></param>
    /// <returns></returns>
    public IMessage AddException(Exception error)
    {
        return AddMessageElement(error.Message, error);
    }
    /// <summary>
    /// Добавляет информацию о валюте
    /// </summary>
    /// <param name="currency"></param>
    /// <returns></returns>
    public IMessage AddCurrency(Currency currency)
    {
        return AddMessageElement(currency.ToString(), currency);
    }
}
