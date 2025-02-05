using Alfateam.Website.API.Abstractions;
using Alfateam.Sales.Models.General;
using Alfateam.Sales.Models.Enums;
using Alfateam.Core.Attributes.DTO;
using Alfateam.Sales.API.Models.DTO.General.Security;

namespace Alfateam.Sales.API.Models.DTO.General
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




        public string AlfateamID { get; set; }
        public UserRole Role { get; set; }


        public string Position { get; set; }


        [ForClientOnly]
        public DepartmentDTO Department { get; set; }
        [HiddenFromClient]
        public int DepartmentId { get; set; }



        public UserPermissionsDTO Permissions { get; set; }
        public bool IsBlocked { get; set; }




        /// <summary>
        /// Требуемые KPI продаж для сотрудника, если они установлены
        /// </summary>
        public SalesKPIDTO? RequiredKPI { get; set; }
        /// <summary>
        /// Желаемые KPI продаж для сотрудника, если они установлены
        /// </summary>
        public SalesKPIDTO? DesiredKPI { get; set; }






        public UserDTO CreateDTO(Alfateam.Sales.Models.General.User user, Alfateam.ID.Models.User alfateamIDuser)
        {
            var dto = base.CreateDTO(user) as UserDTO;

            dto.Name = alfateamIDuser.Name;
            dto.Surname = alfateamIDuser.Surname;
            dto.Patronymic = alfateamIDuser.Patronymic;

            dto.Phone = alfateamIDuser.Phone;
            dto.Email = alfateamIDuser.Email;

            return dto;
        }
        public IEnumerable<UserDTO> CreateDTOs(IEnumerable<Alfateam.Sales.Models.General.User> users, IEnumerable<Alfateam.ID.Models.User> alfateamIDusers)
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
