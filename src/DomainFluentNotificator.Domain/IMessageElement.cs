namespace DomainFluentNotificator.Domain;
/// <summary>
/// Уникальный элемент сообщения. Сожержит у себя обязательный элемент строка по умолчанию 
/// и ссылку на объект, к которому относится строка.
/// </summary>
public interface IMessageElement
{
    /// <summary>
    /// Ссылка на объект, к которому относится этот элемент сообщения
    /// </summary>
    public object Data { get; }
    /// <summary>
    /// Обязательная строка с текстом по умолчанию
    /// </summary>
    public string DefaultString { get; }
}
