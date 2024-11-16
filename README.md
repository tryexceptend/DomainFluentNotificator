# DomainFluentNotificator

Генерация сообщений для отправки в мессенджеры или по почте на уровне домена без привязки к конкретному способу оповещения.

## Описание

Это заготовка, для формирования сообщений на уровне слоя Domain для их отправки в сообщении. На уровне слоя Infrastructute мы реализуем отправку сообщения с нужным форматированием.

Допустим в бизнескейсе мы реализуем логику обработки депозита [DepositUserCase.cs](test/Application.Domain/Interactors/DepositIteractors/DepositUserCase.cs) и отправить все изменения по нему пользователю. Для этого инъекцией подключаем интерфейс [INotificator<DepositUserCaseMessage>](src/DomainFluentNotificator.Domain/INotificator.cs) который будет непосредственно отправлять сообщение.

```c#

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

```

 Этот метод принимает объект интерфейса [IMessage](src/DomainFluentNotificator.Domain/IMessage.cs) который с использование Fluet паттерна собирает список строк сообщения с сылками на объекты если нужно.

 ```c#

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

 ```

Нотификатор может перебрать строки сообщения и отформатировать их под нужный шаблон. Исли нужена детальная информация, то можно по ссылке обратиться к объекту.

Если в домене надо расширить данные по сообщению или добавить новые, то за счет строк по умолчанию, сам нотификатор можно не дорабатывать и мы не потеряем данные, а доработать его позднее.

В пример в домене добавили в сообщение данные по ошибке:

```

INFO

	DEPOSIT: 0 HASHHASHHASH Create

	Create deposit


INFO

	DEPOSIT: 0 HASHHASHHASH Register

	Register deposit on agent


INFO

	DEPOSIT: 0 HASHHASHHASH Apply

	Apply deposit on agent


INFO

	DEPOSIT: 0 HASHHASHHASH Success

	Finish deposit on agent


ERROR

	Error deposit

```

Позже мы доработали нотификатор и уже можем отформатировать сообщение как надо нам:

```

INFO

	DEPOSIT: 0 HASHHASHHASH Create

	Create deposit


INFO

	DEPOSIT: 0 HASHHASHHASH Register

	Register deposit on agent


INFO

	DEPOSIT: 0 HASHHASHHASH Apply

	Apply deposit on agent

INFO

	DEPOSIT: 0 HASHHASHHASH Success

	Finish deposit on agent


ERROR

	EXCEPTION: Error deposit

```
