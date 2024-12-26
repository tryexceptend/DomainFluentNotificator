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
/// <summary>
/// Интерфейс нотификатора, который принимает сообещния с родительским интерфейсом IMessage и отправляет его
/// Эта реализация позволяет создать один класс на все типы сообщений.
/// Реализует на слое инфраструктуры рассылку отформатированных сообщений.
/// Это может быть оправка писем на почту, рассылка сообщений в мессенжер.
/// </summary>
public interface INotificator
{
    /// <summary>
    /// Отправка отредактированного сообщения нотификатором
    /// </summary>
    /// <param name="message">Конструктор сообщения</param>
    /// <param name="level">Уровень сообщения</param>
    /// <param name="cancellationToken">Отменятор</param>
    /// <returns></returns>
    public Task SendMessageAsync<T>(T message, string level, CancellationToken cancellationToken = default)
        where T : IMessage;
}
/// <summary>
/// Нотификатор не привязанный к типам сообщений. Отправляет все что к нему пришло по умолчанию.
/// </summary>
public interface INotificatorSimple
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