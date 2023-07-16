using Alfateam.CRM2_0.Models.Abstractions;
using Alfateam.CRM2_0.Models.General;
using Alfateam.CRM2_0.Models.General.Info;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.CRM2_0.Models.Other.StopList
{
    public class StopListItem : AbsModel
    {
        [MaxLength(50)]
        public string Name { get; set; }
        [MaxLength(50)]
        public string Surname { get; set; }
        [MaxLength(50)]
        public string? Patronymic { get; set; }

        [MaxLength(100)]
        public string? Phone { get; set; }
        [MaxLength(100)]
        public string? Email { get; set; }


        public Country Country { get; set; }
        public LegalForm LegalForm { get; set; }


        [MaxLength(100)]
        public string? CompanyName { get; set; }
        [MaxLength(100)]
        public string? Website { get; set; }




        public SocialNetworksInfo SocialNetworksInfo { get; set; }

        [MaxLength(1000)]
        public string OrderInfo { get; set; }
        [MaxLength(3000)]
        public string Comment { get; set; }


        /// <summary>
        /// Информация, откуда был найден клиент
        /// </summary>
        [MaxLength(200)]
        public string TrafficInfo { get; set; }

        /// <summary>
        /// Дата добавления в стоп-лист(если задним числом)
        /// </summary>
        public DateTime? AddedToStopListDate { get; set; }

    }
}
