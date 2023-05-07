using AutoMapper;
using SoportaAI.Domain.Entities;
using SoportaAI.Model.Models;

namespace SoportaAI.Infrastructure.Mappings;

public class UserMapProfile : Profile
{
	public UserMapProfile()
	{
		RegisterMappings();
	}

	private void RegisterMappings()
	{
		CreateMap<User, UserModel>();
		CreateMap<UserModel, User>();
	}
}