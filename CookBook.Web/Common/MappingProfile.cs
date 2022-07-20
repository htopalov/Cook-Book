using AutoMapper;
using CookBook.Web.Data.Models;
using CookBook.Web.DTOs.User;

namespace CookBook.Web.Common
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            this.CreateMap<UserRegister, User>();
        }
    }
}
