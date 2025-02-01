using Alfateam.Core.Attributes.DTO;
using Alfateam.EDM.API.Models.DTO.General.Security;
using Alfateam.EDM.Models.Enums;
using Alfateam.EDM.Models.General;
using Alfateam.EDM.Models.General.Security;
using Alfateam.Website.API.Abstractions;

namespace Alfateam.EDM.API.Models.DTO.General
{
    public class UserDTO : DTOModelAbs<User>
    {


        #region Поля, получаемые из Alfateam ID, в сущности пользователя в ЭДО таких полей нет
        [DTOFieldFor(DTOFieldForType.CreationOnly)]
        public string Surname { get; set; }
        [DTOFieldFor(DTOFieldForType.CreationOnly)]
        public string Name { get; set; }
        [DTOFieldFor(DTOFieldForType.CreationOnly)]
        public string? Patronymic { get; set; }


        [ForClientOnly]
        public string FIO => $"{Surname} {Name} {Patronymic}";


        [DTOFieldFor(DTOFieldForType.CreationOnly)]
        public string Email { get; set; }
        [DTOFieldFor(DTOFieldForType.CreationOnly)]
        public string Phone { get; set; }

        #endregion



        [ForClientOnly]
        public string AlfateamID { get; set; }
        [ForClientOnly]
        public UserRole Role { get; set; }

        public string Position { get; set; }



        [ForClientOnly]
        public DepartmentDTO Department { get; set; }
        public int DepartmentId { get; set; }


        public UserPermissionsDTO Permissions { get; set; }
        public DocumentsAccessDTO DocumentsAccess { get; set; }
        public EmailNotificationSettingsDTO NotificationSettings { get; set; }


        [ForClientOnly]
        public List<TrustedUserIPAddressDTO> TrustedUserIPs { get; set; } = new List<TrustedUserIPAddressDTO>();
   

        public bool IsBlocked { get; set; }








        public UserDTO CreateDTO(Alfateam.EDM.Models.General.User user, Alfateam.ID.Models.User alfateamIDuser)
        {
            var dto = base.CreateDTO(user) as UserDTO;

            dto.Name = alfateamIDuser.Name;
            dto.Surname = alfateamIDuser.Surname;
            dto.Patronymic = alfateamIDuser.Patronymic;

            dto.Phone = alfateamIDuser.Phone;
            dto.Email = alfateamIDuser.Email;

            return dto;
        }
        public IEnumerable<UserDTO> CreateDTOs(IEnumerable<Alfateam.EDM.Models.General.User> users, IEnumerable<Alfateam.ID.Models.User> alfateamIDusers)
        {
            var DTOs = new List<UserDTO>();

            foreach(var user in users)
            {
                var alfateamIdUser = alfateamIDusers.FirstOrDefault(o => o.Guid == user.AlfateamID);
                DTOs.Add(CreateDTO(user, alfateamIdUser));
            }

            return DTOs;
        }
    }
}
