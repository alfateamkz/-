using Alfateam.Core.Attributes.DTO;
using Alfateam.Messenger.Models.DTO.General.Security;
using Alfateam.Messenger.Models.Enums;
using Alfateam.Messenger.Models.General;
using Alfateam.Messenger.Models.General.Security;
using Alfateam.Website.API.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Messenger.Models.DTO.General
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


        [ForClientOnly]
        public string UniqueId { get; set; }
        [ForClientOnly]
        public string AlfateamID { get; set; }



        public string Position { get; set; }
        public bool IsBlocked { get; set; }

        [ForClientOnly]
        public DepartmentDTO Department { get; set; }
        public int DepartmentId { get; set; }


        public UserRole Role { get; set; }
        public UserPermissionsDTO Permissions { get; set; }
        public AllowedAccountsAccessDTO AllowedAccountsAccess { get; set; }



        public DateTime LastOnlineDate { get; set; }


        public UserDTO CreateDTO(Alfateam.Messenger.Models.General.User user, Alfateam.ID.Models.User alfateamIDuser)
        {
            var dto = base.CreateDTO(user) as UserDTO;

            dto.Name = alfateamIDuser.Name;
            dto.Surname = alfateamIDuser.Surname;
            dto.Patronymic = alfateamIDuser.Patronymic;

            dto.Phone = alfateamIDuser.Phone;
            dto.Email = alfateamIDuser.Email;

            return dto;
        }
        public IEnumerable<UserDTO> CreateDTOs(IEnumerable<Alfateam.Messenger.Models.General.User> users, IEnumerable<Alfateam.ID.Models.User> alfateamIDusers)
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
