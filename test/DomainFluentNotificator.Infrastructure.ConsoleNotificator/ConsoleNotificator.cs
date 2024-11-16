using Application.Domain.Entities.Deposits;
using DomainFluentNotificator.Domain;

namespace DomainFluentNotificator.Infrastructure.ConsoleNotificator;

public class ConsoleNotificator<T> : INotificator<T> where T : IMessage
{
    string delimiter = "\n\r\t";
    public async Task SendMessageAsync(IMessage message, string level, CancellationToken cancellationToken = default)
    {
        string messageText = level + delimiter;
        foreach (var item in message.Elements)
        {
            if (item.Data == null)
            {
                messageText += item.DefaultString + delimiter;
            }
            else
            {
                var t = item.Data.GetType();
                if (t.Equals(typeof(Exception)))
                {
                    messageText += "EXCEPTION: " + (item.Data as Exception).Message + delimiter;
                }
                else
                if (t.Equals(typeof(Deposit)))
                {
                    messageText += "DEPOSIT: " + (item.Data as Deposit).Id + " " + (item.Data as Deposit).Hash + " " + (item.Data as Deposit).State + delimiter;
                }
                else
                {
                    messageText += item.DefaultString + delimiter;
                }
            }
        }
        Console.WriteLine(messageText);
    }
}
