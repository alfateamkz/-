using Alfateam.Core.Attributes.DTO;
using Alfateam.CRM2_0.Models.Enums;
using Alfateam.Telephony.API.Models.DTO.General.Security;
using Alfateam.Telephony.Models.General;
using Alfateam.Telephony.Models.General.Security;
using Alfateam.Website.API.Abstractions;

namespace Alfateam.Telephony.API.Models.DTO.General
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


        [DTOFieldFor(DTOFieldForType.CreationOnly)]
        public string Email { get; set; }
        [DTOFieldFor(DTOFieldForType.CreationOnly)]
        public string Phone { get; set; }

        #endregion



        public UserRole Role { get; set; }


        public string Position { get; set; }



        [ForClientOnly]
        public DepartmentDTO Department { get; set; }

        [HiddenFromClient]
        public int DepartmentId { get; set; }



        public UserPermissionsDTO Permissions { get; set; }
        public bool IsBlocked { get; set; }









        public UserDTO CreateDTO(Alfateam.Telephony.Models.General.User user, Alfateam.ID.Models.User alfateamIDuser)
        {
            var dto = base.CreateDTO(user) as UserDTO;

            dto.Name = alfateamIDuser.Name;
            dto.Surname = alfateamIDuser.Surname;
            dto.Patronymic = alfateamIDuser.Patronymic;

            dto.Phone = alfateamIDuser.Phone;
            dto.Email = alfateamIDuser.Email;

            return dto;
        }
        public IEnumerable<UserDTO> CreateDTOs(IEnumerable<Alfateam.Telephony.Models.General.User> users, IEnumerable<Alfateam.ID.Models.User> alfateamIDusers)
        {
            var DTOs = new List<UserDTO>();

            foreach (var user in users)
            {
                var alfateamIdUser = alfateamIDusers.FirstOrDefault(o => o.Guid == user.AlfateamID);
                DTOs.Add(CreateDTO(user, alfateamIdUser));
            }

            return DTOs;
        }
    }
}
