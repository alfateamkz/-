using Alfateam.Website.API.Abstractions;
using Alfateam2._0.Models.General;

namespace Alfateam.Website.API.Models.ClientModels.General
{
    public class UserClientModel : ClientModel
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public string? Patronymic { get; set; }
        public string? AvatarPath { get; set; }


        public string Email { get; set; }
        public string? Phone { get; set; }




        public CountryClientModel? Country { get; set; }
        public CountryClientModel? RegisteredFromCountry { get; set; }


        public static UserClientModel Create(User item, int? langId)
        {
            var model = new UserClientModel();

            model.Id = item.Id;
            model.Name = item.Name;
            model.Surname = item.Surname;
            model.Patronymic = item.Patronymic;
            model.AvatarPath = item.AvatarPath;

            model.Email = item.Email;
            model.Phone = item.Phone;

            model.Country = CountryClientModel.Create(item.Country, langId);
            model.RegisteredFromCountry = CountryClientModel.Create(item.RegisteredFromCountry, langId);

            return model;
        }
        public static List<UserClientModel> CreateItems(IEnumerable<User> items, int? langId)
        {
            var models = new List<UserClientModel>();
            foreach (var item in items)
            {
                models.Add(Create(item, langId));
            }
            return models;
        }
    }
}
