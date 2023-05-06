namespace SoportaAI.Domain.Entities;

public class Message
{
	public Guid Guid { get; set; }
	public string Text { get; set; }
	public DateTime Time { get; set; }
	public User Sender { get; set; }
}