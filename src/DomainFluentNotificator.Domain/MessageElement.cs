namespace DomainFluentNotificator.Domain;
/// <summary>
/// Дефолтный элемент сообщения
/// </summary>
public class MessageElement : IMessageElement
{
    /// <summary>
    /// Ссылка на объект
    /// </summary>
#pragma warning disable CS8766 // Nullability of reference types in return type doesn't match implicitly implemented member (possibly because of nullability attributes).
    public object? Data { get; set; }
#pragma warning restore CS8766 // Nullability of reference types in return type doesn't match implicitly implemented member (possibly because of nullability attributes).
    /// <summary>
    /// Строк по умолчанию
    /// </summary>
    public required string DefaultString { get; set; }
}
