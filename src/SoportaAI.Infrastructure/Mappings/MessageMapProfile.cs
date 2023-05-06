using AutoMapper;
using SoportaAI.Domain.Entities;
using SoportaAI.Model.Models;

namespace SoportaAI.Infrastructure.Mappings;

public class MessageMapProfile : Profile
{
	public MessageMapProfile()
	{
		RegisterMappings();
	}

	private void RegisterMappings()
	{
		CreateMap<MessageModel, Message>();
		CreateMap<Message, MessageModel>();
	}
}