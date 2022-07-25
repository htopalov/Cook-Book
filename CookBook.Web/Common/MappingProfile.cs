using AutoMapper;
using CookBook.Web.Data.Models;
using CookBook.Web.DTOs.Recipe;
using CookBook.Web.DTOs.User;

namespace CookBook.Web.Common
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            this.CreateMap<UserRegister, User>();

            this.CreateMap<RecipeRequest, Recipe>()
                .ForMember(dest => dest.Image, opt => opt.Ignore())
                .ForMember(dest => dest.PreparationSteps, opt => opt.MapFrom(s => s.Steps))
                .ForMember(dest => dest.IngredientsList,
                    opt => opt.MapFrom(s => s.Ingredients.Split(",", StringSplitOptions.RemoveEmptyEntries).Select(x => new Ingredient { NameAndQuantity = x }).ToList()));

            this.CreateMap<RecipeEditRequest, Recipe>()
                .ForMember(dest => dest.Image, opt => opt.Ignore())
                .ForMember(dest => dest.PreparationSteps, opt => opt.MapFrom(s => s.Steps))
                .ForMember(dest => dest.IngredientsList,
                    opt => opt.MapFrom(s => s.Ingredients.Split(",", StringSplitOptions.RemoveEmptyEntries).Select(x => new Ingredient { NameAndQuantity = x }).ToList()));

            this.CreateMap<Recipe, RecipeResponse>()
                .ForMember(dest => dest.UserId, opt => opt.MapFrom(s => s.Id.ToString()))
                .ForMember(dest => dest.IngredientsList,
                    opt => opt.MapFrom(s => s.IngredientsList.Select(x => x.NameAndQuantity)))
                .ForMember(dest => dest.Steps, opt => opt.MapFrom(s => s.PreparationSteps))
                .ForMember(dest=>dest.Likes, opt=>opt.MapFrom(s=>s.Likes.Count))
                .ForMember(dest=>dest.Image, opt=>opt.MapFrom(s=> $"data:image/jpg;base64,{Convert.ToBase64String(s.Image.DataBytes)}"));

            this.CreateMap<Recipe,RecipeBase>()
                .ForMember(dest=>dest.Image, opt => opt.MapFrom(s => $"data:image/jpg;base64,{Convert.ToBase64String(s.Image.DataBytes)}"));

            this.CreateMap<Recipe, RecipeGuestResponse>()
                .ForMember(dest => dest.Image, opt => opt.MapFrom(s => $"data:image/jpg;base64,{Convert.ToBase64String(s.Image.DataBytes)}"));
        }
    }
}
