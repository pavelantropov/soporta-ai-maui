namespace SoportaAI.Model.Models;

public class MessageModel
{
	public Guid Guid { get; set; }
	public string Text { get; set; }
	public string Time { get; set; }
	public UserModel Sender { get; set; }
}