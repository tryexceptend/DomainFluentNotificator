namespace DomainFluentNotificator.Domain;
/// <summary>
/// Отправка отформатирвоанных сообщений нотификатором.
/// Реализует на слое инфраструктуры рассылку отформатированных сообщений.
/// Это может быть оправка писем на почту, рассылка сообщений в мессенжер.
/// </summary>
/// <typeparam name="T">Наследуется от IMessage</typeparam>
public interface INotificator<T> where T : IMessage
{
    /// <summary>
    /// Отправка отредактированного сообщения нотификатором
    /// </summary>
    /// <param name="message">Конструктор сообщения</param>
    /// <param name="level">Уровень сообщения</param>
    /// <param name="cancellationToken">Отменятор</param>
    /// <returns></returns>
    public Task SendMessageAsync(IMessage message, string level, CancellationToken cancellationToken = default);
}
