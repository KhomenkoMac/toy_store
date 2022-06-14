using BuisnessLogic.Enums;
using System.Linq;

namespace BuisnessLogic
{
    public static class MapExtensions
    {
        public static Toy FromDto(this entities.DTO.Toy obj)
        {
            return new Toy()
            {
                Id = obj.Id,
                Name = obj.Name,
                Price = obj.Price,
                Rate = obj.Rate,
                Description = obj.Description,
                Subject = (Subject)obj.Subject,
            };
        }

        public static entities.DTO.Toy ToDto(this Toy obj)
        {
            return new entities.DTO.Toy()
            {
                Id = obj.Id,
                Name = obj.Name,
                Price = obj.Price,
                Rate = obj.Rate,
                Description = obj.Description,
                Subject = (int)obj.Subject,
            };
        }

        public static entities.DTO.User ToDto(this BuisnessLogic.User obj)
        {
            return new entities.DTO.User()
            {
                Id = obj.Id,
                Login = obj.Login,
                Email = obj.Email,
                Password = obj.Password,
            };
        }

        public static BuisnessLogic.User FromDto(this entities.DTO.User obj)
        {
            return new BuisnessLogic.User()
            {
                Email = obj.Email,
                Login = obj.Login,
                Password = obj.Password
            };
        }
    }
}
