namespace DomainFluentNotificator.Domain;
/// <summary>
/// Дефолтная реализация конструктора сообщений
/// </summary>
public class Message : IMessage
{
    /// <summary>
    /// Список элементов сообщения
    /// </summary>
    protected List<IMessageElement> elements { get; } = [];
    /// <summary>
    /// Публичный параметр
    /// </summary>
    public IEnumerable<IMessageElement> Elements => elements;
    /// <summary>
    /// Добавление нового обхъекта в список элеметов сообщения
    /// </summary>
    /// <param name="message">Обязательная строка</param>
    /// <param name="data">Ссылка на объект, если есть</param>
    /// <returns></returns>
    public IMessage AddMessageElement(string message, object data = null)
    {
        elements.Add(new MessageElement() { Data = data, DefaultString = message });
        return this;
    }
    /// <summary>
    /// Добавление сообщения в список элементов сообщения
    /// </summary>
    /// <param name="message">Обязательная строка сообщения</param>
    /// <returns></returns>
    public IMessage AddMessage(string message)
    {
        return AddMessageElement(message);
    }
}
