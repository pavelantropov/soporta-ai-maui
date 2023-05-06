namespace SoportaAI.Model.Models;

public class MessageModel
{
	public string Text { get; set; }
	public DateTime Time { get; set; }
	public UserModel Sender { get; set; }
}