namespace DomainFluentNotificator.Domain;
/// <summary>
/// Построитель сообщения. Собирает элементы сообщения в упорядоченный список
/// </summary>
public interface IMessage
{
    /// <summary>
    /// Доступ к списку элементов сообщения
    /// </summary>
    public IEnumerable<IMessageElement> Elements { get; }
    /// <summary>
    /// Добавляет новый элемент сообщения в список
    /// </summary>
    /// <param name="defaultMessage">Строка по умолчанию</param>
    /// <param name="data">Ссылка на объект</param>
    /// <returns></returns>
    public IMessage AddMessageElement(string defaultMessage, object data = null);
    /// <summary>
    /// Добавляет строку в список элементов сообщения без указателя на объект
    /// </summary>
    /// <param name="message"></param>
    /// <returns></returns>
    public IMessage AddMessage(string message);
}
