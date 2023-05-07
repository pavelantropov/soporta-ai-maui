using SoportaAI.Model.Models;

namespace SoportaAI.MauiClient.Views.Templates;

internal class MessageDataTemplateSelector : DataTemplateSelector
{
	public DataTemplate AiMessageTemplate { get; set; }
	public DataTemplate UserMessageTemplate { get; set; }

	protected override DataTemplate OnSelectTemplate(object item, BindableObject container)
	{
		var message = (MessageModel)item;

		return message.Sender == null ? AiMessageTemplate : UserMessageTemplate;
	}
}