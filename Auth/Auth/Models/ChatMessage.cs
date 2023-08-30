namespace Auth.Models;

public class ChatMessage
{
    public int Id { get; set; }                // Уникальный идентификатор сообщения
    public int ChatId { get; set; }            // Идентификатор чата, к которому относится сообщение
    public string SenderId { get; set; }       // Идентификатор отправителя сообщения (туриста или турагента)
    public string ReceiverId { get; set; }     // Идентификатор получателя сообщения (туриста или турагента)
    public string Text { get; set; }           // Текст сообщения
    public DateTime DateTime { get; set; }     // Дата и время отправки сообщения
}