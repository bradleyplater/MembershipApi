using AutoMapper;
using MembershipApi.Dtos;
using MembershipApi.Models;


namespace MembershipApi
{
	public class UserProfile : Profile
	{
		public UserProfile()
		{
			CreateMap<User, UserDto>();
			CreateMap<UserPostDto, User>();
		}
	}
}
